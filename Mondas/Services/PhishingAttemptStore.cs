using System;
using System.Collections.Generic;
using System.Globalization;
using Microsoft.Data.Sqlite;
using Mondas.Models;

namespace Mondas.Services
{
    public sealed class PhishingAttemptStore
    {
        private readonly string _dbPath;
        
        public PhishingAttemptStore(string dbPath)
        {
            _dbPath = dbPath;
            EnsureSchema();
        }

        public void Add(PhishingAttemptRow row)
        {
            if (row == null)
            {
                return;
            }

            using var conn = Open();
            using var cmd = conn.CreateCommand();

            cmd.CommandText = @"INSERT INTO PhishingAttempts(UserKey, EmailId, Action, IsCorrect, ScoreDelta, SecondsTaken, SubmittedAt, ReasonString, SignalsJson, EmailSnapshotJson)
                                VALUES($uk, $eid, $act, $ok, $sd, $sec, $ts, $reason, $signals, $snap);";

            var uk = string.IsNullOrWhiteSpace(row.UserKey) ? "local" : row.UserKey.Trim();

            cmd.Parameters.AddWithValue("$uk", uk);
            cmd.Parameters.AddWithValue("$eid", row.EmailId ?? "");
            cmd.Parameters.AddWithValue("$act", row.Action);
            cmd.Parameters.AddWithValue("$ok", row.IsCorrect ? 1 : 0);
            cmd.Parameters.AddWithValue("$sd", row.ScoreDelta);
            cmd.Parameters.AddWithValue("$sec", row.SecondsTaken > 0 ? row.SecondsTaken : 0.0);

            var utc = row.SubmittedUtc.Kind == DateTimeKind.Utc ? row.SubmittedUtc : row.SubmittedUtc.ToUniversalTime();
            
            cmd.Parameters.AddWithValue("$ts", utc.ToString("o"));
            cmd.Parameters.AddWithValue("$reason", row.ReasonString ?? "");
            cmd.Parameters.AddWithValue("$signals", row.SignalsJson ?? "[]");
            cmd.Parameters.AddWithValue("$snap", row.EmailSnapshotJson ?? "{}");

            cmd.ExecuteNonQuery();
        }

        public List<PhishingAttemptRow> GetForUser(string userKey, int limit = 2000)
        {
            var uk = string.IsNullOrWhiteSpace(userKey) ? "local" : userKey.Trim();

            if (limit <= 0)
            {
                limit = 2000;
            }

            var result = new List<PhishingAttemptRow>();

            using var conn = Open();
            using var cmd = conn.CreateCommand();

            cmd.CommandText = @"SELECT Id, UserKey, EmailId, Action, IsCorrect, ScoreDelta, SecondsTaken, SubmittedAt, ReasonString, SignalsJson, EmailSnapshotJson
                                FROM PhishingAttempts
                                WHERE UserKey = $uk
                                ORDER BY SubmittedAt DESC
                                LIMIT $lim;";

            cmd.Parameters.AddWithValue("$uk", uk);
            cmd.Parameters.AddWithValue("$lim", limit);

            using var r = cmd.ExecuteReader();

            while (r.Read())
            {
                var submittedUtc = DateTime.Parse(r.GetString(7), CultureInfo.InvariantCulture, DateTimeStyles.RoundtripKind).ToUniversalTime();

                var row = new PhishingAttemptRow
                {
                    Id = r.GetInt64(0),
                    UserKey = r.IsDBNull(1) ? uk : r.GetString(1),
                    EmailId = r.IsDBNull(2) ? "" : r.GetString(2),
                    Action = r.IsDBNull(3) ? 0 : r.GetInt32(3),
                    IsCorrect = !r.IsDBNull(4) && r.GetInt32(4) == 1,
                    ScoreDelta = r.IsDBNull(5) ? 0 : r.GetInt32(5),
                    SecondsTaken = r.IsDBNull(6) ? 0.0 : r.GetDouble(6),
                    SubmittedUtc = submittedUtc,
                    ReasonString = r.IsDBNull(8) ? "" : r.GetString(8),
                    SignalsJson = r.IsDBNull(9) ? "[]" : r.GetString(9),
                    EmailSnapshotJson = r.IsDBNull(10) ? "{}" : r.GetString(10)
                };

                result.Add(row);
            }

            return result;
        }

        public void ClearUser(string userKey)
        {
            var uk = string.IsNullOrWhiteSpace(userKey) ? "local" : userKey.Trim();

            using var conn = Open();
            using var cmd = conn.CreateCommand();

            cmd.CommandText = "DELETE FROM PhishingAttempts WHERE UserKey =$uk;";
            cmd.Parameters.AddWithValue("$uk", uk);

            cmd.ExecuteNonQuery();
        }

        private void EnsureSchema()
        {
            using var conn = Open();
            using var cmd = conn.CreateCommand();

            cmd.CommandText = @"CREATE TABLE IF NOT EXISTS PhishingAttempts (Id INTEGER PRIMARY KEY AUTOINCREMENT,
                                UserKey TEXT NOT NULL,
                                EmailId TEXT NOT NULL,
                                Action INTEGER NOT NULL,
                                IsCorrect INTEGER NOT NULL,
                                ScoreDelta INTEGER NOT NULL,
                                SecondsTaken REAL NOT NULL,
                                SubmittedAt TEXT NOT NULL,
                                ReasonString TEXT,
                                SignalsJson TEXT,
                                EmailSnapshotJson TEXT);

                                CREATE INDEX IF NOT EXISTS IX_PhishingAttempts_UserKey_SubmittedAt
                                ON PhishingAttempts(UserKey, SubmittedAt DESC);";

            cmd.ExecuteNonQuery();
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