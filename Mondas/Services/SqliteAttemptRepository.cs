using System;
using System.Collections.Generic;
using System.Globalization;
using Microsoft.Data.Sqlite;
using Mondas.Models;

namespace Mondas.Services
{
    public sealed class SqliteAttemptRepository
    {
        private readonly string _dbPath;

        public SqliteAttemptRepository(string dbPath)
        {
            _dbPath = dbPath;
        }

        public void Add(AttemptRecord attempt)
        {
            using var conn = Open();
            using var cmd = conn.CreateCommand();

            cmd.CommandText = @"INSERT INTO Attempts(UserKey, QuestionId, SelectedOptionIdsJson, IsCorrect, SecondsTaken, SubmittedAt, ReasonString, RulesFiredJson)
            VALUES($userKey, $questionId, $selectedJson, $isCorrect, $secondsTaken, $submittedAt, $reason, $rulesJson);";

            cmd.Parameters.AddWithValue("$userKey", attempt.UserKey ?? "");
            cmd.Parameters.AddWithValue("$questionId", attempt.QuestionId);
            cmd.Parameters.AddWithValue("$selectedJson", attempt.SelectedOptionIdsJson ?? "[]");
            cmd.Parameters.AddWithValue("$isCorrect", attempt.IsCorrect ? 1 : 0);

            if (attempt.SecondsTaken <= 0)
                cmd.Parameters.AddWithValue("$secondsTaken", DBNull.Value);
            else
                cmd.Parameters.AddWithValue("$secondsTaken", attempt.SecondsTaken);

            var submittedUtc = attempt.SubmittedAt.Kind == DateTimeKind.Utc
                ? attempt.SubmittedAt
                : attempt.SubmittedAt.ToUniversalTime();

            cmd.Parameters.AddWithValue("$submittedAt", submittedUtc.ToString("o"));
            cmd.Parameters.AddWithValue("$reason", attempt.ReasonString ?? "");
            cmd.Parameters.AddWithValue("$rulesJson", attempt.RulesFiredJson ?? "[]");

            cmd.ExecuteNonQuery();
        }

        public List<AttemptRecord> GetForUser(string userKey)
        {
            var result = new List<AttemptRecord>();

            using var conn = Open();
            using var cmd = conn.CreateCommand();

            cmd.CommandText = @"
            SELECT Id, UserKey, QuestionId, SelectedOptionIdsJson, IsCorrect, SecondsTaken, SubmittedAt, ReasonString, RulesFiredJson
            FROM Attempts
            WHERE UserKey = $userKey
            ORDER BY SubmittedAt DESC;";

            cmd.Parameters.AddWithValue("$userKey", userKey);

            using var r = cmd.ExecuteReader();
            while (r.Read())
            {
                var submittedUtc = DateTime.Parse(
                    r.GetString(6),
                    CultureInfo.InvariantCulture,
                    DateTimeStyles.RoundtripKind
                );

                result.Add(new AttemptRecord
                {
                    Id = r.GetInt64(0),
                    UserKey = r.GetString(1),
                    QuestionId = r.GetInt32(2),
                    SelectedOptionIdsJson = r.GetString(3),
                    IsCorrect = r.GetInt32(4) == 1,
                    SecondsTaken = r.IsDBNull(5) ? 0 : r.GetDouble(5),
                    SubmittedAt = submittedUtc,
                    ReasonString = r.IsDBNull(7) ? "" : r.GetString(7),
                    RulesFiredJson = r.IsDBNull(8) ? "[]" : r.GetString(8)
                });
            }

            return result;
        }

        public void ClearUser(string userKey)
        {
            using var conn = Open();
            using var cmd = conn.CreateCommand();

            cmd.CommandText = "DELETE FROM Attempts WHERE UserKey = $userKey;";
            cmd.Parameters.AddWithValue("$userKey", userKey);

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
    }
}