using System;
using Mondas.Models;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Net.Http.Headers;
using Syncfusion.Windows.Forms.Tools;

namespace Mondas.Services
{
    public sealed class LearningModulesService
    {
        private readonly string _modulesPath;
        private readonly JsonSerializerOptions _json = new JsonSerializerOptions { PropertyNameCaseInsensitive = true, WriteIndented = true };

        public LearningModulesService(string modulesPath)
        {
            _modulesPath = modulesPath ?? throw new ArgumentNullException(nameof(modulesPath));
        }

        public List<LearningModule> LoadModules()
        {
            try
            {
                if (!File.Exists(_modulesPath))
                {
                    return new List<LearningModule>();
                }

                var json = File.ReadAllText(_modulesPath);
                return JsonSerializer.Deserialize<List<LearningModule>>(json, _json) ?? new List<LearningModule>();
            }

            catch
            {
                return new List<LearningModule>();
            }
        }

        public LearningModuleState LoadState(string userKey)
        {
            var path = GetStatePath(userKey);

            try
            {
                if (!File.Exists(path))
                {
                    return new LearningModuleState { UserKey = NormaliseUserKey(userKey) };
                }

                var json = File.ReadAllText(path);
                var state = JsonSerializer.Deserialize<LearningModuleState>(json, _json) ?? new LearningModuleState();
                state.UserKey = NormaliseUserKey(userKey);
                state.CompletedModuleIds ??= new List<string>();
                state.BookmarkedModuleIds ??= new List<string>();
                return state;
            }

            catch
            {
                return new LearningModuleState { UserKey = NormaliseUserKey(userKey) };
            }
        }

        public void SaveState(LearningModuleState state)
        {
            if (state == null)
            {
                return;
            }

            state.UserKey = NormaliseUserKey(state.UserKey);
            state.CompletedModuleIds ??= new List<string>();
            state.BookmarkedModuleIds ??= new List<string>();

            var path = GetStatePath(state.UserKey);
            Directory.CreateDirectory(Path.GetDirectoryName(path) ?? AppContext.BaseDirectory);

            var json = JsonSerializer.Serialize(state, _json);
            File.WriteAllText(path, json);
        }

        public bool ToggleComplete(string userKey, string moduleId)
        {
            var state = LoadState(userKey);
            var id = (moduleId ?? "").Trim();

            if (id.Length == 0)
            {
                return false;
            }

            if (state.CompletedModuleIds.Any(x => string.Equals(x, id, StringComparison.OrdinalIgnoreCase)))
            {
                state.CompletedModuleIds = state.CompletedModuleIds.Where(x => !string.Equals(x, id, StringComparison.OrdinalIgnoreCase)).ToList();
                SaveState(state);

                return false;
            }

            state.CompletedModuleIds.Add(id);
            SaveState(state);

            return true;
        }

        public bool ToggleBookmark(string userKey, string moduleId)
        {
            var state = LoadState(userKey);
            var id = (moduleId ?? "").Trim();

            if (id.Length == 0)
            {
                return false;
            }

            if (state.BookmarkedModuleIds.Any(x => string.Equals(x, id, StringComparison.OrdinalIgnoreCase)))
            {
                state.BookmarkedModuleIds = state.BookmarkedModuleIds.Where(x => !string.Equals(x, id, StringComparison.OrdinalIgnoreCase)).ToList();
                SaveState(state);

                return false;
            }

            state.BookmarkedModuleIds.Add(id);
            SaveState(state);

            return true;
        }

        public bool AppliesToSource(LearningModule module, StatsSource source)
        {
            if (module == null)
            {
                return false;
            }

            if (source == StatsSource.All)
            {
                return true;
            }

            var sources = module.AppliesToSources ?? new List<string>();

            if (sources.Count == 0)
            {
                return true;
            }

            return sources.Any(x => SourceMatches(x, source) || string.Equals((x ?? "").Trim(), "All", StringComparison.OrdinalIgnoreCase));
        }

        public bool TopicMatches(LearningModule module, string topicText)
        {
            if (module == null)
            {
                return false;
            }

            var left = Normalise(module.Topic);
            var right = Normalise(topicText);

            if (right.Length == 0 || right == "ALL")
            {
                return true;
            }

            return left == right;
        }

        public bool TypeMatches(LearningModule module, string typeText)
        {
            if (module == null)
            {
                return false;
            }

            var left = Normalise(module.Type);
            var right = Normalise(typeText);

            if (right.Length == 0 || right == "ALL")
            {
                return true;
            }

            return left == right;
        }

        public List<LearningModuleRecommendation> BuildRecommendations(IEnumerable<LearningModule> modules, DashboardStats stats, StatsSource source, int take = 6)
        {
            var list = (modules ?? Enumerable.Empty<LearningModule>()).Select(x => new LearningModuleRecommendation { Module = x, Score = ScoreModule(x, stats, source) }).OrderByDescending(x => x.Score).ThenBy(x => x.Module.Title, StringComparer.OrdinalIgnoreCase).ToList();

            var matched = list.Where(x => x.Score > 0).Take(Math.Max(1, take)).ToList();

            if (matched.Count > 0)
            {
                return matched;
            }

            return list.Take(Math.Max(1, take)).ToList();
        }

        public string BuildMatchReason(LearningModule module, DashboardStats stats, StatsSource source)
        {
            if (module == null)
            {
                return "Recommended modules will appear here based on your weak areas and isconceptions.";
            }

            var reasons = new List<string>();

            if (stats != null && stats.WeakestTopic.HasValue)
            {
                if (Normalise(module.Topic) == Normalise(stats.WeakestTopic.Value.ToString()))
                {
                    reasons.Add("Matches your weakest topic.");
                }
            }

            var overlaps = GetOverlapTags(module, stats);

            if (overlaps.Count > 0)
            {
                reasons.Add("Covers: " + string.Join(", ", overlaps));
            }

            if (source != StatsSource.All && AppliesToSource(module, source))
            {
                reasons.Add("Fits the selected learning source.");
            }

            if (reasons.Count == 0)
            {
                reasons.Add("Useful for general cyber awareness.");
            }

            return string.Join(" ", reasons);
        }

        private int ScoreModule(LearningModule module, DashboardStats stats, StatsSource source)
        {
            if (module == null)
            {
                return 0;
            }

            int score = 0;

            if (source != StatsSource.All && AppliesToSource(module, source))
            {
                score += 2;
            }

            if (stats != null && stats.WeakestTopic.HasValue)
            {
                if (Normalise(module.Topic) == Normalise(stats.WeakestTopic.Value.ToString()))
                {
                    score += 5;
                }
            }

            var overlaps = GetOverlapTags(module, stats);
            score += Math.Min(9, overlaps.Count * 3);

            return score;
        }

        private List<string> GetOverlapTags(LearningModule module, DashboardStats stats)
        {
            var result = new List<string>();

            if (module == null || stats == null)
            {
                return result;
            }

            var moduleTags = (module.MisconceptionTags ?? new List<string>()).Select(Normalise).Where(x => x.Length > 0).ToHashSet(StringComparer.OrdinalIgnoreCase);
        
            if (moduleTags.Count == 0)
            {
                return result;
            }

            foreach (var item in stats.TopMisconceptions)
            {
                var tag = Normalise(item.Tag);

                if (tag.Length == 0)
                {
                    continue;
                }

                if (moduleTags.Contains(tag))
                {
                    result.Add(item.Tag);
                }
            }

            return result;
        }

        private static bool SourceMatches(string raw, StatsSource source)
        {
            var text = Normalise(raw);

            return source switch { StatsSource.Quiz => text == "QUIZ", StatsSource.PhishingSimulator => text == "PHISHINGSIMULATOR" || text == "PHISHING", StatsSource.PasswordWorkshop => text == "PASSWORDWORKSHOP" || text == "PASSWORDS", _ => text == "ALL" };
        }

        private static string Normalise(string value)
        {
            return (value ?? "").Trim().Replace(" ", "").Replace("_", "").ToUpperInvariant();
        }

        private static string NormaliseUserKey(string userKey)
        {
            return string.IsNullOrWhiteSpace(userKey) ? "local" : userKey.Trim();
        }

        private static string GetSafeUserKey(string userKey)
        {
            return NormaliseUserKey(userKey).Replace(":", "_").Replace("/", "_").Replace("\\", "_");
        }

        private static string GetStatePath(string userKey)
        {
            var safe = GetSafeUserKey(userKey);
            return Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Mondas", "learning", safe + ".json");
        }
    }
}
