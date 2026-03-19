using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Microsoft.Data.Sqlite;
using Mondas.Models;
using Newtonsoft.Json;

namespace Mondas.Services
{
    public sealed class DashboardStatsService
    {
        private readonly string _dbPath;

        public DashboardStatsService(string dbPath)
        {
            if (string.IsNullOrWhiteSpace(dbPath))
            {
                throw new ArgumentNullException(nameof(dbPath));
            }

            _dbPath = dbPath;
        }

        public DashboardStats Load(long userId, string userKey, StatsSource source = StatsSource.All, int minTopicAttempts = 3, int misconceptionLimit = 20)
        {
            var uk = NormaliseUserKey(userKey);
            var stats = new DashboardStats { UserId = userId, UserKey = uk, FullName = "USER" };

            using var conn = Open();

            if (userId > 0)
            {
                using var cmdName = conn.CreateCommand();
                cmdName.CommandText = "SELECT FullName FROM Users WHERE Id = $id LIMIT 1;";
                cmdName.Parameters.AddWithValue("$id", userId);

                var nameObj = cmdName.ExecuteScalar();

                if (nameObj != null && nameObj != DBNull.Value)
                {
                    var name = (nameObj.ToString() ?? "").Trim();

                    if (name.Length > 0)
                    {
                        stats.FullName = name;
                    }
                }
            }

            int quizTotal = 0;
            int quizCorrect = 0;
            int phishTotal = 0;
            int phishCorrect = 0;
            int learningTotal = 0;
            int learningCorrect = 0;
            int authTotal = 0;
            int authCorrect = 0;

            if (source == StatsSource.All || source == StatsSource.Quiz)
            {
                quizTotal = ScalarInt(conn, "SELECT COUNT(1) FROM Attempts WHERE UserKey = $uk;", ("$uk", uk));
                quizCorrect = ScalarInt(conn, "SELECT COUNT(1) FROM Attempts WHERE UserKey = $uk AND IsCorrect = 1;", ("$uk", uk));
            }

            if ((source == StatsSource.All || source == StatsSource.PhishingSimulator) && TableExists(conn, "PhishingAttempts"))
            {
                phishTotal = ScalarInt(conn, "SELECT COUNT(1) FROM PhishingAttempts WHERE UserKey = $uk AND Action IN ($a1, $a2);", ("$uk", uk), ("$a1", (int)PhishingAction.TrustKeep), ("$a2", (int)PhishingAction.ReportPhishing));
                phishCorrect = ScalarInt(conn, "SELECT COUNT(1) FROM PhishingAttempts WHERE UserKey = $uk AND Action IN ($a1, $a2) AND IsCorrect = 1;", ("$uk", uk), ("$a1", (int)PhishingAction.TrustKeep), ("$a2", (int)PhishingAction.ReportPhishing));
            }

            if ((source == StatsSource.All || source == StatsSource.LearningModules) && TableExists(conn, "LearningModuleAttempts"))
            {
                learningTotal = ScalarInt(conn, "SELECT COUNT(1) FROM LearningModuleAttempts WHERE UserKey = $uk;", ("$uk", uk));
                learningCorrect = ScalarInt(conn, "SELECT COUNT(1) FROM LearningModuleAttempts WHERE UserKey = $uk AND IsCorrect = 1;", ("$uk", uk));
            }

            if ((source == StatsSource.All || source == StatsSource.AuthenticationDefense) && TableExists(conn, "AuthenticationDefenseAttempts"))
            {
                authTotal = ScalarInt(conn, "SELECT COUNT(1) FROM AuthenticationDefenseAttempts WHERE UserKey = $uk;", ("$uk;", uk));
                authCorrect = ScalarInt(conn, "SELECT COUNT(1) FROM AuthenticationDefenseAttempts WHERE UserKey = $uk AND IsCorrect = 1;", ("$uk", uk));
            }

            stats.TotalAttempts = quizTotal + phishTotal + learningTotal + authTotal;
            stats.CorrectAttempts = quizCorrect + phishCorrect + learningCorrect + authTotal;
            stats.AvgSeconds = LoadAvgSeconds(conn, uk, source);
            stats.CurrentStreak = CalcStreak(conn, uk, source, take: 250);

            LoadTopicMastery(conn, uk, stats, source);
            CalcWeakStrong(stats, minTopicAttempts);
            LoadTopMisconceptions(conn, uk, stats, source, misconceptionLimit);

            return stats;
        }

        private static string NormaliseUserKey(string userKey)
            => string.IsNullOrWhiteSpace(userKey) ? "local" : userKey.Trim();

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
            cmd.CommandText = "SELECT 1 FROM sqlite_master WHERE type='table' AND name=$name LIMIT 1;";
            cmd.Parameters.AddWithValue("$name", tableName);

            var obj = cmd.ExecuteScalar();
            return obj != null && obj != DBNull.Value;
        }

        private static int ScalarInt(SqliteConnection conn, string sql, params (string name, object value)[] p)
        {
            using var cmd = conn.CreateCommand();
            cmd.CommandText = sql;
            foreach (var (name, value) in p)
            {
                cmd.Parameters.AddWithValue(name, value ?? DBNull.Value);
            }

            var obj = cmd.ExecuteScalar();

            if (obj == null || obj == DBNull.Value)
            {
                return 0;
            }

            return Convert.ToInt32(obj, CultureInfo.InvariantCulture);
        }

        private static double ScalarDouble(SqliteConnection conn, string sql, params (string name, object value)[] p)
        {
            using var cmd = conn.CreateCommand();
            cmd.CommandText = sql;

            foreach (var (name, value) in p)
            {
                cmd.Parameters.AddWithValue(name, value ?? DBNull.Value);

            }

            var obj = cmd.ExecuteScalar();

            if (obj == null || obj == DBNull.Value)
            {
                return 0.0;

            }

            return Convert.ToDouble(obj, CultureInfo.InvariantCulture);
        }

        private static double LoadAvgSeconds(SqliteConnection conn, string userKey, StatsSource source)
        {
            if (source == StatsSource.Quiz)
            {
                return ScalarDouble(conn, "SELECT AVG(SecondsTaken) FROM Attempts WHERE UserKey = $uk AND SecondsTaken > 0;", ("$uk", userKey));
            }

            if (source == StatsSource.PhishingSimulator)
            {
                if (!TableExists(conn, "PhishingAttempts"))
                {
                    return 0.0;
                }

                return ScalarDouble(conn, "SELECT AVG(SecondsTaken) FROM PhishingAttempts WHERE UserKey = $uk AND Action IN ($a1, $a2) AND SecondsTaken > 0;", ("$uk", userKey), ("$a1", (int)PhishingAction.TrustKeep), ("$a2", (int)PhishingAction.ReportPhishing));
            }

            if (source == StatsSource.LearningModules)
            {
                if (!TableExists(conn, "LearningModuleAttempts"))
                {
                    return 0.0;
                }

                return ScalarDouble(conn, "SELECT AVG(SecondsTaken) FROM LearningModuleAttempts WHERE UserKey = $uk AND SecondsTaken > 0;", ("$uk", userKey));
            }

            if (source == StatsSource.AuthenticationDefense)
            {
                if (!TableExists(conn, "AuthenticationDefenseAttempts"))
                {
                    return 0.0;
                }

                return ScalarDouble(conn, "SELECT AVG(SecondsTaken) FROM AuthenticationDefenseAttempts WHERE UserKey = $uk AND SecondsTaken > 0;", ("$uk", userKey));
            }

            var parts = new List<string> { "SELECT SecondsTaken FROM Attempts WHERE UserKey = $uk AND SecondsTaken > 0" };

            if (TableExists(conn, "PhishingAttempts"))
            {
                parts.Add("SELECT SecondsTaken FROM PhishingAttempts WHERE UserKey = $uk AND Action IN ($a1, $a2) AND SecondsTaken > 0");
            }

            if (TableExists(conn, "LearningModuleAttempts"))
            {
                parts.Add("SELECT SecondsTaken FROM LearningModuleAttempts WHERE UserKey = $uk AND SecondsTaken > 0");
            }

            if (TableExists(conn, "AuthenticationDefenseAttempts"))
            {
                parts.Add("SELECT SecondsTaken FROM AuthenticationDefenseAttempts WHERE UserKey = $uk AND SecondsTaken > 0");
            }

            var sql = "SELECT AVG(t.SecondsTaken) FROM (" + string.Join(" UNION ALL ", parts) + ") AS t;";

            return ScalarDouble(conn, sql, ("$uk", userKey), ("$a1", (int)PhishingAction.TrustKeep), ("$a2", (int)PhishingAction.ReportPhishing));
        }

        private static int CalcStreak(SqliteConnection conn, string userKey, StatsSource source, int take)
        {            
            if (source == StatsSource.Quiz)
            {
                return CalcQuizStreak(conn, userKey, take);
            }

            if (source == StatsSource.PhishingSimulator)
            {
                return CalcPhishStreak(conn, userKey, take);
            }

            if (source == StatsSource.LearningModules)
            {
                return CalcLearningStreak(conn, userKey, take);
            }

            if (source == StatsSource.AuthenticationDefense)
            {
                return CalcAuthenticationStreak(conn, userKey, take);
            }

            var parts = new List<string>{"SELECT IsCorrect, SubmittedAt FROM Attempts WHERE UserKey = $uk"};

            var hasPhish = TableExists(conn, "PhishingAttempts");
            var hasLearning = TableExists(conn, "LearningModuleAttempts");
            var hasAuth = TableExists(conn, "AuthenticationDefenseAttempts");

            if (hasPhish)
            {
                parts.Add("SELECT IsCorrect, SubmittedAt FROM PhishingAttempts WHERE UserKey = $uk AND Action IN ($a1, $a2)");
            }

            if (hasLearning)
            {
                parts.Add("SELECT IsCorrect, SubmittedAt FROM LearningModuleAttempts WHERE UserKey = $uk");
            }

            if (hasAuth)
            {
                parts.Add("SELECT IsCorrect, SubmittedAt FROM AuthenticationDefenseAttempts WHERE UserKey = $uk");
            }

            using var cmd = conn.CreateCommand();
            cmd.CommandText = "SELECT IsCorrect FROM (" + string.Join(" UNION ALL ", parts) + ") ORDER BY SubmittedAt DESC LIMIT $take;";
            cmd.Parameters.AddWithValue("$uk", userKey);
            cmd.Parameters.AddWithValue("$take", take);

            if (hasPhish)
            {
                cmd.Parameters.AddWithValue("$a1", (int)PhishingAction.TrustKeep);
                cmd.Parameters.AddWithValue("$a2", (int)PhishingAction.ReportPhishing);
            }

            int streak = 0;
            using var r = cmd.ExecuteReader();

            while (r.Read())
            {
                var isCorrect = r.GetInt32(0) == 1;

                if (!isCorrect)
                {
                    break;
                }

                streak++;
            }

            return streak;
        }

        private static int CalcQuizStreak(SqliteConnection conn, string userKey, int take)
        {
            using var cmd = conn.CreateCommand();
            cmd.CommandText = @"SELECT IsCorrect FROM Attempts WHERE UserKey = $uk ORDER BY SubmittedAt DESC LIMIT $take;";

            cmd.Parameters.AddWithValue("$uk", userKey);
            cmd.Parameters.AddWithValue("$take", take);

            int streak = 0;
            using var r = cmd.ExecuteReader();

            while (r.Read())
            {
                bool isCorrect = r.GetInt32(0) == 1;

                if (!isCorrect)
                {
                    break;
                }

                streak++;
            }

            return streak;
        }

        private static int CalcPhishStreak(SqliteConnection conn, string userKey, int take)
        {
            if (!TableExists(conn, "PhishingAttempts"))
            {
                return 0;
            }

            using var cmd = conn.CreateCommand();
            cmd.CommandText = @"SELECT IsCorrect FROM PhishingAttempts WHERE UserKey = $uk AND Action IN ($a1, $a2) ORDER BY SubmittedAt DESC LIMIT $take;";

            cmd.Parameters.AddWithValue("$uk", userKey);
            cmd.Parameters.AddWithValue("$a1", (int)PhishingAction.TrustKeep);
            cmd.Parameters.AddWithValue("$a2", (int)PhishingAction.ReportPhishing);
            cmd.Parameters.AddWithValue("$take", take);

            int streak = 0;
            using var r = cmd.ExecuteReader();

            while (r.Read())
            {
                bool isCorrect = r.GetInt32(0) == 1;

                if (!isCorrect)
                {
                    break;
                }

                streak++;
            }

            return streak;
        }

        private static int CalcLearningStreak(SqliteConnection conn, string userKey, int take)
        {
            if (!TableExists(conn, "LearningModuleAttempts"))
            {
                return 0;
            }

            using var cmd = conn.CreateCommand();
            cmd.CommandText = @"SELECT IsCorrect FROM LearningModuleAttempts WHERE UserKey = $uk ORDER BY SubmittedAt DESC LIMIT $take;";

            cmd.Parameters.AddWithValue("$uk", userKey);
            cmd.Parameters.AddWithValue("$take", take);

            int streak = 0;
            using var r = cmd.ExecuteReader();

            while (r.Read())
            {
                var isCorrect = r.GetInt32(0) == 1;

                if (!isCorrect)
                {
                    break;
                }

                streak++;
            }

            return streak;
        }

        private static int ComputeAuthenticationStreak(SqliteConnection conn, string userKey, int take)
        {
            if (!TableExists(conn, "AuthenticationDefenseAttempts"))
            {
                return 0;
            }

            using var cmd = conn.CreateCommand();
            cmd.CommandText = "SELECT IsCorrect FROM AuthenticationDefenseAttempts WHERE UserKey = $uk ORDER BY SubmittedAt DESC LIMIT $take;";
            cmd.Parameters.AddWithValue("$uk", userKey);
            cmd.Parameters.AddWithValue("$take", take);

            int streak = 0;
            using var r = cmd.ExecuteReader();

            while (r.Read())
            {
                var isCorrect = r.GetInt32(0) == 1;

                if (!isCorrect)
                {
                    break;
                }

                streak++;
            }

            return streak;
        }

        private static void LoadTopicMastery(SqliteConnection conn, string userKey, DashboardStats stats, StatsSource source)
        {
            stats.MasteryByTopic.Clear();

            if (source == StatsSource.All || source == StatsSource.Quiz)
            {
                using var cmd = conn.CreateCommand();

                cmd.CommandText = @"SELECT q.Topic, COUNT(1) AS Seen, SUM(a.IsCorrect) AS Correct FROM Attempts a JOIN Questions q ON q.Id = a.QuestionId WHERE a.UserKey = $uk GROUP BY q.Topic ORDER BY Seen DESC;";
                cmd.Parameters.AddWithValue("$uk", userKey);
                using var r = cmd.ExecuteReader();

                while (r.Read())
                {
                    int topicInt = r.GetInt32(0);
                    int seen = Convert.ToInt32(r.GetInt64(1));
                    int correct = r.IsDBNull(2) ? 0 : Convert.ToInt32(r.GetInt64(2));

                    AddTopic(stats, (Topic)topicInt, seen, correct);
                }
            }

            if ((source == StatsSource.All || source == StatsSource.LearningModules) && TableExists(conn, "LearningModuleAttempts"))
            {
                using var learningCmd = conn.CreateCommand();
                learningCmd.CommandText = @"SELECT Topic, COUNT(1) AS Seen, SUM(IsCorrect) AS Correct FROM LearningModuleAttempts WHERE UserKey = $uk GROUP BY Topic ORDER BY Seen DESC;";
                learningCmd.Parameters.AddWithValue("$uk", userKey);

                using var learningReader = learningCmd.ExecuteReader();

                while (learningReader.Read())
                {
                    int topicInt = learningReader.GetInt32(0);
                    int seen = Convert.ToInt32(learningReader.GetInt64(1));
                    int correct = learningReader.IsDBNull(2) ? 0 : Convert.ToInt32(learningReader.GetInt64(2));

                    AddTopic(stats, (Topic)topicInt, seen, correct);
                }
            }

            if ((source == StatsSource.All || source == StatsSource.PhishingSimulator) && TableExists(conn, "PhishingAttempts"))
            {
                using var phishCmd = conn.CreateCommand();
                phishCmd.CommandText = @"SELECT COUNT(1) AS Seen, SUM(IsCorrect) AS Correct FROM PhishingAttempts WHERE UserKey = $uk AND Action IN ($a1, $a2);";
                phishCmd.Parameters.AddWithValue("$uk", userKey);
                phishCmd.Parameters.AddWithValue("$a1", (int)PhishingAction.TrustKeep);
                phishCmd.Parameters.AddWithValue("$a2", (int)PhishingAction.ReportPhishing);

                using var phishReader = phishCmd.ExecuteReader();

                if (phishReader.Read())
                {
                    int seen = phishReader.IsDBNull(0) ? 0 : Convert.ToInt32(phishReader.GetInt64(0));
                    int correct = phishReader.IsDBNull(1) ? 0 : Convert.ToInt32(phishReader.GetInt64(1));

                    if (seen > 0)
                    {
                        AddTopic(stats, Topic.Phishing, seen, correct);
                    }
                }
            }

            if ((source == StatsSource.All || source == StatsSource.AuthenticationDefense) && TableExists(conn, "AuthenticationDefenseAttempts"))
            {
                using var authCmd = conn.CreateCommand();
                authCmd.CommandText = "SELECT IsCorrect, ScenarioSnapshotJson FROM AuthenticationDefenseAttempts WHERE UserKey = $uk;";
                authCmd.Parameters.AddWithValue("$uk", userKey);

                using var authReader = authCmd.ExecuteReader();

                while (authReader.Read())
                {
                    var isCorrect = !authReader.IsDBNull(0) && authReader.GetInt32(0) == 1;
                    var scenarioJson = authReader.IsDBNull(1) ? "" : authReader.GetString(1);
                    var scenario = ReadAuthScenario(scenarioJson);
                    var topic = MapAuthTopic(scenario);

                    AddTopic(stats, topic, 1, isCorrect ? 1 : 0);
                }
            }

            stats.MasteryByTopic.Sort((a, b) => b.Seen.CompareTo(a.Seen));
        }

        private static void AddTopic(DashboardStats stats, Topic topic, int seen, int correct)
        {
            var existing = stats.MasteryByTopic.FirstOrDefault(x => x.Topic == topic);

            if (existing == null)
            {
                stats.MasteryByTopic.Add(new TopicMasteryRow { Topic = topic, Seen = seen, Correct = correct });
                return;
            }

            existing.Seen += seen;
            existing.Correct += correct;
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

        private static Topic MapAuthTopic(AuthenticationDefenseScenario scenario)
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
                    return Topic.DeviceSecurity;

                default:
                    return Topic.Passwords;
            }
        }

        private static void CalcWeakStrong(DashboardStats stats, int minTopicAttempts)
        {
            TopicMasteryRow weakest = null;
            TopicMasteryRow strongest = null;

            foreach (var row in stats.MasteryByTopic)
            {
                if (row.Seen < minTopicAttempts)
                {
                    continue;
                }

                if (weakest == null || row.Accuracy01 < weakest.Accuracy01)
                {
                    weakest = row;
                }

                if (strongest == null || row.Accuracy01 > strongest.Accuracy01)
                {
                    strongest = row;
                }
            }

            if (weakest != null)
            {
                stats.WeakestTopic = weakest.Topic;
                stats.WeakestAccuracy01 = weakest.Accuracy01;
            }

            if (strongest != null)
            {
                stats.StrongestTopic = strongest.Topic;
                stats.StrongestAccuracy01 = strongest.Accuracy01;
            }
        }

        private static void LoadTopMisconceptions(SqliteConnection conn, string userKey, DashboardStats stats, StatsSource source, int limit)
        {
            var combined = new Dictionary<string, (int Count, DateTime LastUtc)>(StringComparer.OrdinalIgnoreCase);

            if (source == StatsSource.All || source == StatsSource.Quiz)
            {
                LoadQuizMisconceptions(conn, userKey, combined);
            }

            if ((source == StatsSource.All || source == StatsSource.PhishingSimulator) && TableExists(conn, "PhishingAttempts"))
            {
                LoadPhishingMistakeTags(conn, userKey, combined);
            }

            if ((source == StatsSource.All || source == StatsSource.LearningModules) && TableExists(conn, "LearningModuleAttempts"))
            {
                LoadLearningMisconceptions(conn, userKey, combined);
            }

            if ((source == StatsSource.All || source == StatsSource.AuthenticationDefense) && TableExists(conn, "AuthenticationDefenseAttempts"))
            {
                LoadAuthenticationMisconceptions(conn, userKey, combined);
            }

            var rows = new List<MisconceptionRow>();

            foreach (var kvp in combined)
            {
                rows.Add(new MisconceptionRow { Tag = kvp.Key ?? "", Count = kvp.Value.Count, LastSeenUtc = kvp.Value.LastUtc });
            }

            rows = rows.OrderByDescending(x => x.LastSeenUtc).ThenByDescending(x => x.Count).ThenBy(x => x.Tag, StringComparer.OrdinalIgnoreCase).Take(Math.Max(1, limit)).ToList();

            stats.TopMisconceptions.Clear();
            stats.TopMisconceptions.AddRange(rows);
        }
   
        private static void LoadQuizMisconceptions(SqliteConnection conn, string userKey, Dictionary<string, (int Count, DateTime LastUtc)> combined)
        {
            using var cmd = conn.CreateCommand();
            cmd.CommandText = @"SELECT mt.Tag, COUNT(1) AS Cnt, MAX(a.SubmittedAt) AS LastUtc
                                FROM Attempts a
                                JOIN QuestionMisconceptionTags qmt ON qmt.QuestionId = a.QuestionId
                                JOIN MisconceptionTags mt ON mt.Id = qmt.TagId
                                WHERE a.UserKey = $uk AND a.IsCorrect = 0
                                GROUP BY mt.Tag;";

            cmd.Parameters.AddWithValue("$uk", userKey);

            using var r = cmd.ExecuteReader();

            while (r.Read())
            {
                var tag = r.IsDBNull(0) ? "" : (r.GetString(0) ?? "");
                tag = tag.Trim();

                if (tag.Length == 0)
                {
                    continue;
                }

                int count = r.IsDBNull(1) ? 0 : Convert.ToInt32(r.GetInt64(1));
                DateTime lastUtc = DateTime.UtcNow;

                if (!r.IsDBNull(2))
                {
                    lastUtc = DateTime.Parse(r.GetString(2), CultureInfo.InvariantCulture, DateTimeStyles.RoundtripKind).ToUniversalTime();
                }

                combined[tag] = combined.TryGetValue(tag, out var existing) ? (existing.Count + count, existing.LastUtc > lastUtc ? existing.LastUtc : lastUtc) : (count, lastUtc);
            }
        }

        private static void LoadLearningMisconceptions(SqliteConnection conn, string userKey, Dictionary<string, (int Count, DateTime LastUtc)> combined)
        {
            using var cmd = conn.CreateCommand();
            cmd.CommandText = @"SELECT MisconceptionTagsJson, SubmittedAt FROM LearningModuleAttempts WHERE UserKey = $uk AND IsCorrect = 0 ORDER BY SubmittedAt DESC LIMIT 800;";
            cmd.Parameters.AddWithValue("$uk", userKey);

            using var r = cmd.ExecuteReader();

            while (r.Read())
            {
                var tagsJson = r.IsDBNull(0) ? "[]" : (r.GetString(0) ?? "[]");
                var submittedAtText = r.IsDBNull(1) ? "" : (r.GetString(1) ?? "");

                List<string> tags;

                try
                {
                    tags = JsonConvert.DeserializeObject<List<string>>(tagsJson) ?? new List<string>();
                }

                catch
                {
                    tags = new List<string>();
                }

                if (tags.Count == 0)
                {
                    continue;
                }

                DateTime submittedUtc = DateTime.UtcNow;

                if (!string.IsNullOrWhiteSpace(submittedAtText))
                {
                    try
                    {
                        submittedUtc = DateTime.Parse(submittedAtText, CultureInfo.InvariantCulture, DateTimeStyles.RoundtripKind).ToUniversalTime();
                    }

                    catch
                    {
                        submittedUtc = DateTime.UtcNow;
                    }
                }

                foreach (var raw in tags)
                {
                    var tag = (raw ?? "").Trim();

                    if (tag.Length == 0)
                    {
                        continue;
                    }

                    if (combined.TryGetValue(tag, out var existing))
                    {
                        var last = existing.LastUtc > submittedUtc ? existing.LastUtc : submittedUtc;
                        combined[tag] = (existing.Count + 1, last);
                    }

                    else
                    {
                        combined[tag] = (1, submittedUtc);
                    }
                }
            }
        }



        private static void LoadPhishingMistakeTags(SqliteConnection conn, string userKey, Dictionary<string, (int Count, DateTime LastUtc)> combined)
        {
            using var cmd = conn.CreateCommand();
            cmd.CommandText = @"SELECT EmailSnapshotJson, SubmittedAt FROM PhishingAttempts WHERE UserKey = $uk AND Action IN ($a1, $a2) AND IsCorrect = 0 ORDER BY SubmittedAt DESC LIMIT 800;";

            cmd.Parameters.AddWithValue("$uk", userKey);
            cmd.Parameters.AddWithValue("$a1", (int)PhishingAction.TrustKeep);
            cmd.Parameters.AddWithValue("$a2", (int)PhishingAction.ReportPhishing);

            using var r = cmd.ExecuteReader();

            while (r.Read())
            {
                var snapJson = r.IsDBNull(0) ? "" : (r.GetString(0) ?? "");
                var submittedAtText = r.IsDBNull(1) ? "" : (r.GetString(1) ?? "");

                if (string.IsNullOrWhiteSpace(snapJson))
                {
                    continue;
                }

                DateTime submittedUtc = DateTime.UtcNow;

                try
                {
                    if (!string.IsNullOrWhiteSpace(submittedAtText))
                    {
                        submittedUtc = DateTime.Parse(submittedAtText, CultureInfo.InvariantCulture, DateTimeStyles.RoundtripKind).ToUniversalTime();
                    }
                }

                catch
                {
                    submittedUtc = DateTime.UtcNow;
                }

                PhishingEmail email;

                try
                {
                    email = JsonConvert.DeserializeObject<PhishingEmail>(snapJson);
                }

                catch
                {
                    email = null;
                }

                if (email == null)
                {
                    continue;
                }

                var tags = email.Tags ?? new List<string>();

                if (tags.Count == 0)
                {
                    tags = new List<string> { "phishing-general" };
                }

                for (int i = 0; i < tags.Count; i++)
                {
                    var t = (tags[i] ?? "").Trim();

                    if (t.Length == 0)
                    {
                        continue;
                    }

                    if (combined.TryGetValue(t, out var existing))
                    {
                        var last = existing.LastUtc > submittedUtc ? existing.LastUtc : submittedUtc;
                        combined[t] = (existing.Count + 1, last);
                    }

                    else
                    {
                        combined[t] = (1, submittedUtc);
                    }
                }
            }
        }
    }
}