using System;
using System.Collections.Generic;
using System.Globalization;
using System.Windows.Media.Animation;
using Microsoft.Data.Sqlite;
using Mondas.Models;

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

        public DashboardStats Load(long userId, string userKey, int minTopicAttempts = 3, int misconceptionLimit = 6)
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

            stats.TotalAttempts = ScalarInt(conn, "SELECT COUNT(1) FROM Attempts WHERE UserKey = $uk;", ("$uk", uk));
            stats.CorrectAttempts = ScalarInt(conn, "SELECT COUNT(1) FROM Attempts WHERE UserKey = $uk AND IsCorrect = 1;", ("$uk", uk));
            stats.AvgSeconds = ScalarDouble(conn, "SELECT AVG(SecondsTaken) FROM Attempts WHERE UserKey = $uk AND SecondsTaken > 0;", ("$uk", uk));
            stats.CurrentStreak = ComputeStreak(conn, uk, take: 250);
            LoadTopicMastery(conn, uk, stats);
            ComputeWeakStrong(stats, minTopicAttempts);
            LoadTopMisconceptions(conn, uk, stats, misconceptionLimit);

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

        private static int ComputeStreak(SqliteConnection conn, string userKey, int take)
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

        private static void LoadTopicMastery(SqliteConnection conn, string userKey, DashboardStats stats)
        {
            using var cmd = conn.CreateCommand();
            cmd.CommandText = @"SELECT q.Topic, COUNT(1) AS Seen, SUM(a.IsCorrect) AS Correct
                                FROM Attempts a
                                JOIN Questions q ON q.Id = a.QuestionId
                                WHERE a.UserKey = $uk
                                GROUP BY q.Topic
                                ORDER BY Seen DESC;";

            cmd.Parameters.AddWithValue("$uk", userKey);

            using var r = cmd.ExecuteReader();

            while (r.Read())
            {
                int topicInt = r.GetInt32(0);
                int seen = Convert.ToInt32(r.GetInt64(1));
                int correct = r.IsDBNull(2) ? 0 : Convert.ToInt32(r.GetInt64(2));

                var row = new TopicMasteryRow { Topic = (Topic)topicInt, Seen = seen, Correct = correct };

                stats.MasteryByTopic.Add(row);
            }
        }

        private static void ComputeWeakStrong(DashboardStats stats, int minTopicAttempts)
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
   
        private static void LoadTopMisconceptions(SqliteConnection conn, string userKey, DashboardStats stats, int limit)
        {
            using var cmd = conn.CreateCommand();
            cmd.CommandText = @"SELECT mt.Tag, COUNT(1) AS Cnt, MAX(a.SubmittedAt) AS LastUtc
                                FROM Attempts a
                                JOIN QuestionMisconceptionTags qmt ON qmt.QuestionId = a.QuestionId
                                JOIN MisconceptionTags mt ON mt.Id = qmt.TagId
                                WHERE a.UserKey = $uk AND a.IsCorrect = 0
                                GROUP BY mt.Tag
                                ORDER BY Cnt DESC
                                LIMIT $limit;";

            cmd.Parameters.AddWithValue("$uk", userKey);
            cmd.Parameters.AddWithValue("$limit", Math.Max(1, limit));

            using var r = cmd.ExecuteReader();

            while (r.Read())
            {
                var tag = r.GetString(0);
                int count = Convert.ToInt32(r.GetInt64(1));

                DateTime lastUtc = DateTime.UtcNow;

                if (!r.IsDBNull(2))
                {
                    lastUtc = DateTime.Parse(r.GetString(2), CultureInfo.InvariantCulture, DateTimeStyles.RoundtripKind).ToUniversalTime();
                }

                stats.TopMisconceptions.Add(new MisconceptionRow { Tag = tag ?? "", Count = count, LastSeenUtc = lastUtc });
            }
        }
    }
}