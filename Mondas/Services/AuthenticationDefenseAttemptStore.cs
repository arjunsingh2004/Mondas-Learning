using System;
using System.Collections.Generic;
using System.Globalization;
using Microsoft.Data.Sqlite;
using Mondas.Models;

namespace Mondas.Services
{
    public sealed class AuthenticationDefenseAttemptStore
    {
        private readonly string _dbPath;

        public AuthenticationDefenseAttemptStore(string dbPath)
        {
            _dbPath = dbPath;
            EnsureSchema();
        }

        public void Add(AuthenticationDefenseAttemptRow row)
        {
            if (row == null)
            {
                return;
            }

            using var conn = Open();
            using var cmd = conn.CreateCommand();

            cmd.CommandText = "INSERT INTO AuthenticationDefenseAttempts " + "(UserKey, ScenarioId, IsCorrect, ScoreDelta, SecondsTaken, Accuracy01, SubmittedAt, TagsJson, FindingsJson, ScenarioSnapshotJson) " + "VALUES " + "($uk, $sid, $ok, $score, $secs, $acc, $ts, $tags, $findings, $snap);";
            cmd.Parameters.AddWithValue("$uk", string.IsNullOrWhiteSpace(row.UserKey) ? "local" : row.UserKey.Trim());
            cmd.Parameters.AddWithValue("$sid", row.ScenarioId ?? "");
            cmd.Parameters.AddWithValue("$ok", row.IsCorrect ? 1 : 0);
            cmd.Parameters.AddWithValue("$score", row.ScoreDelta);
            cmd.Parameters.AddWithValue("$secs", row.SecondsTaken > 0 ? row.SecondsTaken : 0.0);
            cmd.Parameters.AddWithValue("$acc", row.Accuracy01 < 0 ? 0.0 : row.Accuracy01 > 1 ? 1.0 : row.Accuracy01);
            cmd.Parameters.AddWithValue("$ts", row.SubmittedUtc.Kind == DateTimeKind.Utc ? row.SubmittedUtc.ToString("o") : row.SubmittedUtc.ToUniversalTime().ToString("o"));
            cmd.Parameters.AddWithValue("$tags", row.TagsJson ?? "[]");
            cmd.Parameters.AddWithValue("$findings", row.FindingsJson ?? "[]");
            cmd.Parameters.AddWithValue("$snap", row.ScenarioSnapshotJson ?? "{}");
            
            cmd.ExecuteNonQuery();
        }

        public List<AuthenticationDefenseAttemptRow> GetForUser(string userKey, int limit = 2000)
        {
            var rows = new List<AuthenticationDefenseAttemptRow>();
            var uk = string.IsNullOrWhiteSpace(userKey) ? "local" : userKey.Trim();

            using var conn = Open();
            using var cmd = conn.CreateCommand();

            cmd.CommandText = "SELECT Id, UserKey, ScenarioId, IsCorrect, ScoreDelta, SecondsTaken, Accuracy01, SubmittedAt, TagsJson, FindingsJson, ScenarioSnapshotJson " + "FROM AuthenticationDefenseAttempts " + "WHERE UserKey = $uk " + "ORDER BY SubmittedAt DESC " + "LIMIT $lim;";
            cmd.Parameters.AddWithValue("$uk", uk);
            cmd.Parameters.AddWithValue("$lim", limit <= 0 ? 2000 : limit);

            using var r = cmd.ExecuteReader();

            while (r.Read())
            {
                rows.Add(new AuthenticationDefenseAttemptRow
                {
                    Id = r.GetInt64(0),
                    UserKey = r.IsDBNull(1) ? uk : r.GetString(1),
                    ScenarioId = r.IsDBNull(2) ? "" : r.GetString(2),
                    IsCorrect = !r.IsDBNull(3) && r.GetInt32(3) == 1,
                    ScoreDelta = r.IsDBNull(4) ? 0 : r.GetInt32(4),
                    SecondsTaken = r.IsDBNull(5) ? 0.0 : r.GetDouble(5),
                    Accuracy01 = r.IsDBNull(6) ? (double?)null : r.GetDouble(6), 
                    SubmittedUtc = r.IsDBNull(7) ? DateTime.UtcNow : DateTime.Parse(r.GetString(7), CultureInfo.InvariantCulture, DateTimeStyles.RoundtripKind).ToUniversalTime(),
                    TagsJson = r.IsDBNull(8) ? "[]" : r.GetString(8),
                    FindingsJson = r.IsDBNull(9) ? "[]" : r.GetString(9),
                    ScenarioSnapshotJson = r.IsDBNull(10) ? "{}" : r.GetString(10)
                });
            }

            return rows;
        }

        private void EnsureSchema()
        {
            using var conn = Open();
            using var cmd = conn.CreateCommand();

            cmd.CommandText = "CREATE TABLE IF NOT EXISTS AuthenticationDefenseAttempts (Id INTEGER PRIMARY KEY AUTOINCREMENT, UserKey TEXT NOT NULL, ScenarioId TEXT NOT NULL, IsCorrect INTEGER NOT NULL, ScoreDelta INTEGER NOT NULL, SecondsTaken REAL NOT NULL, SubmittedAt TEXT NOT NULL, TagsJson TEXT NOT NULL DEFAULT '[]', FindingsJson TEXT NOT NULL DEFAULT '[]', ScenarioSnapshotJson TEXT NOT NULL DEFAULT '{}'); CREATE INDEX IF NOT EXISTS IX_AuthenticationDefenseAttempts_User_Submitted ON AuthenticationDefenseAttempts(UserKey, SubmittedAt DESC);";
            cmd.ExecuteNonQuery();

            EnsureColumn(conn, "AuthenticationDefenseAttempts", "Accuracy01", "REAL NULL");
        }

        private static void EnsureColumn(SqliteConnection conn, string tableName, string columnName, string columnDefinition)
        {
            using var check = conn.CreateCommand();
            check.CommandText = $"Pragma table_info({tableName})";

            using var reader = check.ExecuteReader();

            while (reader.Read())
            {
                var existingName = reader.IsDBNull(1) ? "" : reader.GetString(1);

                if (string.Equals(existingName, columnName, StringComparison.OrdinalIgnoreCase))
                {
                    return;
                }
            }

            using var alter = conn.CreateCommand();
            alter.CommandText = $"ALTER TABLE {tableName} ADD COLUMN {columnName} {columnDefinition};";
            alter.ExecuteNonQuery();
        }

        private SqliteConnection Open()
        {
            var conn = new SqliteConnection("Data Source=" + _dbPath);
            conn.Open();

            using var pragma = conn.CreateCommand();
            pragma.CommandText = "PRAGMA foreign_keys = ON;";
            pragma.ExecuteNonQuery();

            return conn;
        }
    }
}