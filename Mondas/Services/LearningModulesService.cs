using System;
using Mondas.Models;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using Microsoft.Data.Sqlite;

namespace Mondas.Services
{
    public sealed class LearningModulesService
    {
        private readonly string _modulesPath;
        private readonly string _dbPath;
        private readonly JsonSerializerOptions _json = new JsonSerializerOptions { PropertyNameCaseInsensitive = true, WriteIndented = true };

        public LearningModulesService(string modulesPath, string dbPath)
        {
            _modulesPath = modulesPath ?? throw new ArgumentNullException(nameof(modulesPath));
            _dbPath = dbPath ?? throw new ArgumentNullException(nameof(dbPath));
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
            var state = new LearningModuleState { UserKey = NormaliseUserKey(userKey), CompletedModuleIds = new List<string>(), BookmarkedModuleIds = new List<string>(), PassedCheckModuleIds = new List<string>() };

            using var conn = Open();

            if (!TableExists(conn, "LearningModuleProgress"))
            {
                return state;
            }

            using var cmd = conn.CreateCommand();
            cmd.CommandText = @"SELECT ModuleId, IsCompleted, IsBookmarked, CheckPassed FROM LearningModuleProgress WHERE UserKey = $uk;";
            cmd.Parameters.AddWithValue("$uk", state.UserKey);

            using var r = cmd.ExecuteReader();

            while (r.Read())
            {
                var moduleId = r.IsDBNull(0) ? "" : (r.GetString(0) ?? "").Trim();

                if (moduleId.Length == 0)
                {
                    continue;
                }

                if (!r.IsDBNull(1) && r.GetInt32(1) == 1)
                {
                    state.CompletedModuleIds.Add(moduleId);
                }

                if (!r.IsDBNull(2) && r.GetInt32(2) == 1)
                {
                    state.BookmarkedModuleIds.Add(moduleId);
                }

                if (!r.IsDBNull(3) && r.GetInt32(3) == 1)
                {
                    state.PassedCheckModuleIds.Add(moduleId);
                }
            }

            return state;
        }

        public bool ToggleComplete(string userKey, string moduleId)
        {
            return ToggleFlag(userKey, moduleId, "IsCompleted", "CompletedAt");
        }

        public bool ToggleBookmark(string userKey, string moduleId)
        {
            return ToggleFlag(userKey, moduleId, "IsBookmarked", "BookmarkedAt");
        }

        public void MarkCheckPassed(string userKey, string moduleId)
        {
            SetFlag(userKey, moduleId, "CheckPassed", "CheckPassedAt", true);
        }

        public void SaveCheckAttempt(string userKey, LearningModule module, int questionIndex, bool isCorrect, double secondsTaken)
        {
            if (module == null)
            {
                return;
            }

            using var conn = Open();

            if (!TableExists(conn, "LearningModuleAttempts"))
            {
                return;
            }

            using var cmd = conn.CreateCommand();

            cmd.CommandText = @"INSERT INTO LearningModuleAttempts (UserKey, ModuleId, Topic, Difficulty, QuestionIndex, IsCorrect, SecondsTaken, SubmittedAt, MisconceptionTagsJson) VALUES ($uk, $mid, $topic, $difficulty, $qidx, $ok, $secs, $ts, $tags);";

            cmd.Parameters.AddWithValue("$uk", NormaliseUserKey(userKey));
            cmd.Parameters.AddWithValue("$mid", (module.Id ?? "").Trim());
            cmd.Parameters.AddWithValue("$topic", (int)ParseTopic(module.Topic));
            cmd.Parameters.AddWithValue("$difficulty", (int)DifficultyBand.Medium);
            cmd.Parameters.AddWithValue("$qidx", questionIndex);
            cmd.Parameters.AddWithValue("$ok", isCorrect ? 1 : 0);
            cmd.Parameters.AddWithValue("$secs", Math.Max(0.0, secondsTaken));
            cmd.Parameters.AddWithValue("$ts", DateTime.UtcNow.ToString("o"));
            cmd.Parameters.AddWithValue("$tags", JsonSerializer.Serialize(module.MisconceptionTags ?? new List<string>(), _json));
            
            cmd.ExecuteNonQuery();
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
                return "Recommended modules will show here based on your weak areas and misconceptions.";
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

        private bool ToggleFlag(string userKey, string moduleId, string flagColumn, string timeColumn)
        {
            var next = !ReadFlag(userKey, moduleId, flagColumn);
            SetFlag(userKey, moduleId, flagColumn, timeColumn, next);

            return next;
        }

        private bool ReadFlag(string userKey, string moduleId, string flagColumn)
        {
            using var conn = Open();

            if (!TableExists(conn, "LearningModuleProgress"))
            {
                return false;
            }

            using var cmd = conn.CreateCommand();
            cmd.CommandText = $"SELECT {flagColumn} FROM LearningModuleProgress WHERE UserKey = $uk AND ModuleId = $mid LIMIT 1;";
            cmd.Parameters.AddWithValue("$uk", NormaliseUserKey(userKey));
            cmd.Parameters.AddWithValue("$mid", (moduleId ?? "").Trim());

            var obj = cmd.ExecuteScalar();

            if (obj == null || obj == DBNull.Value)
            {
                return false;
            }

            return Convert.ToInt32(obj) == 1;
        }

        private void SetFlag(string userKey, string moduleId, string flagColumn, string timeColumn, bool value)
        {
            var id = (moduleId ?? "").Trim();

            if (id.Length == 0)
            {
                return;
            }

            using var conn = Open();

            if (!TableExists(conn, "LearningModuleProgress"))
            {
                return;
            }

            using var cmd = conn.CreateCommand();
            cmd.CommandText = $@"INSERT INTO LearningModuleProgress (UserKey, ModuleId, {flagColumn}, {timeColumn}) VALUES ($uk, $mid, $value, $at) ON CONFLICT(UserKey, ModuleId) DO UPDATE SET {flagColumn} = excluded.{flagColumn}, {timeColumn} = excluded.{timeColumn};";
        
            cmd.Parameters.AddWithValue("$uk", NormaliseUserKey(userKey));
            cmd.Parameters.AddWithValue("$mid", id);
            cmd.Parameters.AddWithValue("$value", value ? 1 : 0);
            cmd.Parameters.AddWithValue("$at", value ? DateTime.UtcNow.ToString("o") : (object)DBNull.Value);

            cmd.ExecuteNonQuery();
        }

        private SqliteConnection Open()
        {
            var conn = new SqliteConnection($"Data Source={_dbPath}");
            conn.Open();

            using var pragma = conn.CreateCommand();
            pragma.CommandText = "PRAGMA foreign_keys = ON;";
            pragma.ExecuteNonQuery();

            return conn;
        }

        private static bool TableExists(SqliteConnection conn, string tableName)
        {
            using var cmd = conn.CreateCommand();
            cmd.CommandText = "SELECT 1 FROM sqlite_master WHERE type = 'table' AND name = $name LIMIT 1;";
            cmd.Parameters.AddWithValue("$name", tableName);

            var obj = cmd.ExecuteScalar();
            return obj != null && obj != DBNull.Value;
        }

        private static Topic ParseTopic(string value)
        {
            var text = Normalise(value);

            return text switch { "PHISHING" => Topic.Phishing, "PASSWORD" => Topic.Passwords, "PASSWORDS" => Topic.Passwords, "DEVICESECURITY" => Topic.DeviceSecurity, "SOCIALENGINEERING" => Topic.SocialEngineering, _ => Topic.Other };
        }

        private static bool SourceMatches(string raw, StatsSource source)
        {
            var text = Normalise(raw);

            return source switch { StatsSource.Quiz => text == "QUIZ", StatsSource.PhishingSimulator => text == "PHISHINGSIMULATOR" || text == "PHISHING", StatsSource.PasswordWorkshop => text == "PASSWORDWORKSHOP" || text == "PASSWORDS", StatsSource.LearningModules => text == "LEARNINGMODULES", _ => text == "ALL" };
        }

        private static string Normalise(string value)
        {
            return (value ?? "").Trim().Replace(" ", "").Replace("_", "").ToUpperInvariant();
        }

        private static string NormaliseUserKey(string userKey)
        {
            return string.IsNullOrWhiteSpace(userKey) ? "local" : userKey.Trim();
        }
    }
}