using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using Mondas.Models;
using Newtonsoft.Json;

namespace Mondas.Services
{
    internal class SharedAdaptiveLearningService
    {
        private readonly SqliteAttemptRepository _quizAttemptRepo;
        private readonly JsonQuestionRepository _questionRepo;
        private readonly PhishingAttemptStore _phishingAttemptStore;
        private readonly AuthenticationDefenseAttemptStore _authenticationAttemptStore;

        public SharedAdaptiveLearningService(string dbPath, string questionsJsonPath)
        {
            _quizAttemptRepo = new SqliteAttemptRepository(dbPath);
            _questionRepo = new JsonQuestionRepository(questionsJsonPath);
            _phishingAttemptStore = new PhishingAttemptStore(dbPath);
            _authenticationAttemptStore = new AuthenticationDefenseAttemptStore(dbPath);
        }

        public UserModel BuildUserModel(string userKey)
        {
            var safeKey = string.IsNullOrWhiteSpace(userKey) ? "local" : userKey.Trim();
            var model = new UserModel();

            LoadQuizAttempts(model, safeKey);
            LoadPhishingAttempts(model, safeKey);
            LoadAuthenticationAttempts(model, safeKey);

            return model;
        }

        public Topic ? GetWeakestTopic(UserModel model, IEnumerable<Topic> allowedTopics = null)
        {
            if (model == null)
            {
                return null;
            }

            var topics = (allowedTopics ?? Enum.GetValues(typeof(Topic)).Cast<Topic>()).Where(x => x != Topic.Other).Distinct().ToList();

            if (topics.Count == 0)
            {
                return null;
            }

            Topic? weakest = null;
            double weakestMastery = double.MaxValue;

            foreach (var topic in topics)
            {
                var mastery = GetMastery01(model, topic);

                if (!weakest.HasValue || mastery < weakestMastery)
                {
                    weakest = topic;
                    weakestMastery = mastery;
                }
            }

            return weakest;
        }

        public double GetMastery01(UserModel model, Topic topic)
        {
            if (model == null)
            {
                return 0.0;
            }

            if (!model.TopicStats.TryGetValue(topic, out var stats) || stats == null)
            {
                return 0.0;
            }

            var mastery = stats.Mastery;

            if (mastery < 0.0)
            {
                return 0.0;
            }

            if (mastery > 1.0)
            {
                return 1.0;
            }

            return mastery;
        }

        public DifficultyBand ResolveTargetDifficulty(IReadOnlyList<double> recentAccuracy01, DifficultyBand baseline)
        {
            if (recentAccuracy01 == null || recentAccuracy01.Count < 2)
            {
                return baseline;
            }

            var recent = recentAccuracy01.Take(4).ToList();

            int strongStreak = 0;
            int weakStreak = 0;

            foreach (var raw in recent)
            {
                var accuracy = Clamp01(raw);

                if (accuracy >= 0.80)
                {
                    if (weakStreak > 0)
                    {
                        break;
                    }

                    strongStreak++;
                }

                else if (accuracy <= 0.40)
                {
                    if (strongStreak > 0)
                    {
                        break;
                    }

                    weakStreak++;
                }

                else
                {
                    break;
                }
            }

            if (weakStreak >= 2)
            {
                return ShiftDifficulty(baseline, -1);
            }

            if (strongStreak >= 3)
            {
                return ShiftDifficulty(baseline, +1);
            }

            return baseline;
        }

        public Topic MapPhishingTopic(PhishingEmail email)
        {
            if (email == null)
            {
                return Topic.Phishing;
            }

            var tags = email.Tags ?? new List<string>();

            if (HasAnyTag(tags, "social-engineering", "impersonation", "helpdesk", "pretext") || LooksUrgent(email))
            {
                return Topic.SocialEngineering;
            }

            if (HasAnyTag(tags, "attachment", "macro", "malware", "device", "token", "session"))
            {
                return Topic.DeviceSecurity;
            }

            return Topic.Phishing;
        }

        public Topic MapAuthenticationTopic(AuthenticationDefenseScenario scenario)
        {
            if (scenario == null)
            {
                return Topic.Passwords;
            }

            switch (scenario.ThreatType)
            {
                case AuthThreatType.HelpdeskTakeover:
                case AuthThreatType.MfaFatigue:
                    return Topic.SocialEngineering;

                case AuthThreatType.SessionHijack:
                case AuthThreatType.TokenReplay:
                case AuthThreatType.LegacyProtocolAbuse:
                    return Topic.DeviceSecurity;

                default:
                    return Topic.Passwords;
            }
        }

        public static int DifficultyDistance(DifficultyBand a, DifficultyBand b)
        {
            var order = new[] { DifficultyBand.Easy, DifficultyBand.Medium, DifficultyBand.Hard };

            var ia = Array.IndexOf(order, a);
            var ib = Array.IndexOf(order, b);

            if (ia < 0 || ib < 0)
            {
                return 0;
            }

            return Math.Abs(ia - ib);
        }

        private void LoadQuizAttempts(UserModel model, string userKey)
        {
            IReadOnlyList<Question> questions;
            Dictionary<int, Question> byId;
            List<AttemptRecord> history;

            try
            {
                questions = _questionRepo.GetAllQuestions() ?? Array.Empty<Question>();
                byId = questions.ToDictionary(x => x.Id, x => x);
            }

            catch
            {
                return;
            }

            try
            {
                history = _quizAttemptRepo.GetForUser(userKey)?.OrderBy(x => x.SubmittedAt).ToList() ?? new List<AttemptRecord>();
            }

            catch
            {
                return;
            }

            foreach (var record in history)
            {
                if (!byId.TryGetValue(record.QuestionId, out var question))
                {
                    continue;
                }

                var attempt = new QuestionAttempt
                {
                    QuestionId = record.QuestionId,
                    StartedAt = record.SubmittedAt.AddSeconds(-record.SecondsTaken).ToUniversalTime(),
                    SubmittedAt = record.SubmittedAt.ToUniversalTime(),
                    IsCorrect = record.IsCorrect,
                    SelectedOptionIds = SafeReadIds(record.SelectedOptionIdsJson),
                    ReasonString = record.ReasonString ?? "",
                    RulesFired = SafeReadRules(record.RulesFiredJson)
                };

                model.UpdateFromAttempt(question, attempt);
            }
        }

        private void LoadPhishingAttempts(UserModel model, string userKey)
        {
            List<PhishingAttemptRow> history;

            try
            {
                history = _phishingAttemptStore.GetForUser(userKey, 5000)?.Where(x => x.Action == (int)PhishingAction.TrustKeep || x.Action == (int)PhishingAction.ReportPhishing).OrderBy(x => x.SubmittedUtc).ToList() ?? new List<PhishingAttemptRow>();
            }

            catch
            {
                return;
            }

            foreach (var row in history)
            {
                var email = ReadPhishingEmail(row.EmailSnapshotJson);
                var topic = MapPhishingTopic(email);

                var tags = email?.Tags ?? new List<string>();

                if (tags.Count == 0)
                {
                    tags = new List<string> { "phishing-general" };
                }

                model.UpdateTopicAttempt(topic, row.IsCorrect ? 1.0 : 0.0, row.IsCorrect ? null : tags);
            }
        }

        private void LoadAuthenticationAttempts(UserModel model, string userKey)
        {
            List<AuthenticationDefenseAttemptRow> history;

            try
            {
                history = _authenticationAttemptStore.GetForUser(userKey, 5000)?.OrderBy(x => x.SubmittedUtc).ToList() ?? new List<AuthenticationDefenseAttemptRow>();
            }

            catch
            {
                return;
            }

            foreach (var row in history)
            {
                var scenario = ReadAuthScenario(row.ScenarioSnapshotJson);
                var topic = MapAuthenticationTopic(scenario);
                var accuracy = row.Accuracy01 ?? (row.IsCorrect ? 1.0 : 0.0);
                var tags = ReadTags(row.TagsJson);

                model.UpdateTopicAttempt(topic, accuracy, accuracy >= 0.999 ? null : tags);
            }
        }

        private static List<int> SafeReadIds(string json)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(json))
                {
                    return new List<int>();
                }

                return System.Text.Json.JsonSerializer.Deserialize<List<int>>(json) ?? new List<int>();
            }
            catch
            {
                return new List<int>();
            }
        }

        private static List<string> SafeReadRules(string json)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(json))
                {
                    return new List<string>();
                }

                return System.Text.Json.JsonSerializer.Deserialize<List<string>>(json) ?? new List<string>();
            }
            catch
            {
                return new List<string>();
            }
        }

        private static AuthenticationDefenseScenario ReadAuthScenario(string json)
        {
            try
            {
                return string.IsNullOrWhiteSpace(json) ? null : JsonConvert.DeserializeObject<AuthenticationDefenseScenario>(json);
            }

            catch
            {
                return null;
            }
        }

        private static PhishingEmail ReadPhishingEmail(string json)
        {
            try
            {
                return string.IsNullOrWhiteSpace(json) ? null : JsonConvert.DeserializeObject<PhishingEmail>(json);
            }

            catch
            {
                return null;
            }
        }

        private static List<string> ReadTags(string json)
        {
            try
            {
                return string.IsNullOrWhiteSpace(json) ? new List<string>() : JsonConvert.DeserializeObject<List<string>>(json) ?? new List<string>();
            }

            catch
            {
                return new List<string>();
            }
        }

        private static bool LooksUrgent(PhishingEmail email)
        {
            var subject = (email?.Subject ?? "").ToUpperInvariant();
            var body = (email?.Body ?? "").ToUpperInvariant();

            return subject.Contains("URGENT") || subject.Contains("IMMEDIATE") || subject.Contains("ACTION REQUIRED") || body.Contains("URGENT") || body.Contains("IMMEDIATE") || body.Contains("ACTION REQUIRED") || body.Contains("SUSPEND") || body.Contains("LOCK");
        }

        private static bool HasAnyTag(IEnumerable<string> tags, params string[] wanted)
        {
            if (tags == null)
            {
                return false;
            }

            var set = new HashSet<string>(tags.Where(x => !string.IsNullOrWhiteSpace(x)).Select(x => x.Trim()), StringComparer.OrdinalIgnoreCase);

            return wanted.Any(set.Contains);
        }

        private static double Clamp01(double value)
        {
            if (value < 0.0)
            {
                return 0.0;
            }

            if (value > 1.0)
            {
                return 1.0;
            }

            return value;
        }

        private static DifficultyBand ShiftDifficulty(DifficultyBand start, int delta)
        {
            var order = new[] { DifficultyBand.Easy, DifficultyBand.Medium, DifficultyBand.Hard };
            var index = Array.IndexOf(order, start);

            if (index < 0)
            {
                return start;
            }

            index += delta;

            if (index < 0)
            {
                index = 0;
            }

            if (index >= order.Length)
            {
                index = order.Length - 1;
            }

            return order[index];
        }
    }
}