using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using Microsoft.Data.Sqlite;
using Mondas.Models;

namespace Mondas.Services
{
    public sealed class SqliteDatabaseInitializer
    {
        private readonly string _dbPath;
        private readonly string _jsonPath;

        public SqliteDatabaseInitializer(string dbPath, string jsonPath)
        {
            _dbPath = dbPath;
            _jsonPath = jsonPath;
        }

        public void Initialize()
        {
            Directory.CreateDirectory(Path.GetDirectoryName(_dbPath) ?? AppContext.BaseDirectory);

            using var conn = new SqliteConnection($"Data Source={_dbPath}");
            conn.Open();

            using (var pragma = conn.CreateCommand())
            {
                pragma.CommandText = "PRAGMA foreign_keys = ON;";
                pragma.ExecuteNonQuery();
            }

            CreateSchema(conn);

            if (GetQuestionCount(conn) == 0)
            {
                SeedFromJson(conn);
            }
        }

        private static void CreateSchema(SqliteConnection conn)
        {
            var sql = @"
            CREATE TABLE IF NOT EXISTS Questions (
            Id INTEGER PRIMARY KEY,
            Text TEXT NOT NULL,
            Explanation TEXT NOT NULL,
            Topic INTEGER NOT NULL,
            Difficulty INTEGER NOT NULL,
            QuestionType INTEGER NOT NULL
            );

            CREATE TABLE IF NOT EXISTS AnswerOptions (
            Id INTEGER PRIMARY KEY AUTOINCREMENT,
            QuestionId INTEGER NOT NULL,
            Text TEXT NOT NULL,
            IsCorrect INTEGER NOT NULL,
            FOREIGN KEY (QuestionId) REFERENCES Questions(Id) ON DELETE CASCADE
            );


            CREATE TABLE IF NOT EXISTS MisconceptionTags (
            Id  INTEGER PRIMARY KEY,
            Tag TEXT NOT NULL UNIQUE
            );

            CREATE TABLE IF NOT EXISTS QuestionMisconceptionTags (
            QuestionId INTEGER NOT NULL,
            TagId INTEGER NOT NULL,
            PRIMARY KEY (QuestionId, TagId),
            FOREIGN KEY (QuestionId) REFERENCES Questions(Id) ON DELETE CASCADE,
            FOREIGN KEY (TagId) REFERENCES MisconceptionTags(Id) ON DELETE CASCADE
            );

            CREATE TABLE IF NOT EXISTS Users (
            id INTEGER PRIMARY KEY AUTOINCREMENT,
            FullName TEXT NOT NULL,
            Email TEXT NOT NULL UNIQUE,
            IsAdmin INTEGER NOT NULL DEFAULT 0,
            PasswordHash TEXT NOT NULL,
            PasswordSalt TEXT NOT NULL,
            PasswordIterations INTEGER NOT NULL,
            TotpSecretBase32 TEXT,
            TotpEnabled INTEGER NOT NULL DEFAULT 0,
            CreatedUtc TEXT NOT NULL                                                           
            );

            CREATE TABLE IF NOT EXISTS Attempts (
            Id INTEGER PRIMARY KEY AUTOINCREMENT,
            UserKey TEXT NOT NULL,
            QuestionId INTEGER NOT NULL,
            SelectedOptionIdsJson TEXT NOT NULL,
            IsCorrect INTEGER NOT NULL,
            SecondsTaken REAL NOT NULL DEFAULT 0,
            SubmittedAt TEXT NOT NULL,
            ReasonString TEXT NOT NULL,
            RulesFiredJson TEXT NOT NULL
            );

            CREATE TABLE IF NOT EXISTS PhishingAttempts (
            Id INTEGER PRIMARY KEY AUTOINCREMENT,
            UserKey TEXT NOT NULL,
            EmailId TEXT NOT NULL,
            Action INTEGER NOT NULL,
            IsCorrect INTEGER NOT NULL,
            ScoreDelta INTEGER NOT NULL,
            SecondsTaken REAL NOT NULL DEFAULT 0,
            SubmittedAt TEXT NOT NULL,
            ReasonString TEXT NOT NULL,
            SignalsJson TEXT NOT NULL,
            EmailSnapshotJson TEXT NOT NULL
            );

            CREATE TABLE IF NOT EXISTS LearningModuleProgress (
            UserKey TEXT NOT NULL,
            ModuleId TEXT NOT NULL,
            IsCompleted INTEGER NOT NULL DEFAULT 0,
            IsBookmarked INTEGER NOT NULL DEFAULT 0,
            CheckPassed INTEGER NOT NULL DEFAULT 0,
            CompletedAt TEXT,
            BookmarkedAt TEXT,
            CheckPassedAt TEXT,
            PRIMARY KEY (UserKey, ModuleId)
            );

            CREATE TABLE IF NOT EXISTS LearningModuleAttempts (
            Id INTEGER PRIMARY KEY AUTOINCREMENT,
            UserKey TEXT NOT NULL,
            ModuleId TEXT NOT NULL,
            Topic INTEGER NOT NULL,
            Difficulty INTEGER NOT NULL DEFAULT 1,
            QuestionIndex INTEGER NOT NULL,
            IsCorrect INTEGER NOT NULL,
            SecondsTaken REAL NOT NULL DEFAULT 0,
            SubmittedAt TEXT NOT NULL,
            MisconceptionTagsJson TEXT NOT NULL DEFAULT '[]'
            );

            CREATE INDEX IF NOT EXISTS IX_LearningModuleProgress_User_Module
            ON LearningModuleProgress(UserKey, ModuleId);

            CREATE INDEX IF NOT EXISTS IX_LearningModuleAttempts_User_Submitted
            ON LearningModuleAttempts(UserKey, SubmittedAt);

            CREATE INDEX IF NOT EXISTS IX_LearningModuleAttempts_User_Module
            ON LearningModuleAttempts(UserKey, ModuleId);

            CREATE INDEX IF NOT EXISTS IX_PhishingAttempts_User_Submitted
            ON PhishingAttempts(UserKey, SubmittedAt);

            CREATE INDEX IF NOT EXISTS IX_PhishingAttempts_User_Email
            ON PhishingAttempts(UserKey, EmailId);

            CREATE INDEX IF NOT EXISTS IX_Questions_Topic_Difficulty
            ON Questions(Topic, Difficulty);

            CREATE INDEX IF NOT EXISTS IX_AnswerOptions_QuestionId
            ON AnswerOptions(QuestionId);

            CREATE INDEX IF NOT EXISTS IX_QMT_TagId
            ON QuestionMisconceptionTags(TagId);

            CREATE INDEX IF NOT EXISTS IX_Attempts_User_Submitted
            ON Attempts(UserKey, SubmittedAt);

            CREATE INDEX IF NOT EXISTS IX_Users_Email
            ON Users(Email);
            ";

            using var cmd = conn.CreateCommand();
            cmd.CommandText = sql;
            cmd.ExecuteNonQuery();
        }

        private static int GetQuestionCount(SqliteConnection conn)
        {
            using var cmd = conn.CreateCommand();
            cmd.CommandText = "SELECT COUNT(1) FROM Questions;";
            return Convert.ToInt32(cmd.ExecuteScalar());
        }

        private void SeedFromJson(SqliteConnection conn)
        {
            if (!File.Exists(_jsonPath))
            {
                throw new FileNotFoundException("questions.json not found", _jsonPath);
            }                

            var json = File.ReadAllText(_jsonPath);
            var opts = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            var items = JsonSerializer.Deserialize<List<QuestionJson>>(json, opts) ?? new List<QuestionJson>();

            using var tx = conn.BeginTransaction();

            foreach (var q in items)
            {
                InsertQuestion(conn, tx, q);
            }

            tx.Commit();
        }

        private static void InsertQuestion(SqliteConnection conn, SqliteTransaction tx, QuestionJson q)
        {
            using (var cmd = conn.CreateCommand())
            {
                cmd.Transaction = tx;
                cmd.CommandText = @"
                INSERT INTO Questions
                (Id, Text, Explanation, Topic, Difficulty, QuestionType)
                VALUES
                ($id, $text, $explanation, $topic, $difficulty, $qtype);";

                cmd.Parameters.AddWithValue("$id", q.Id);
                cmd.Parameters.AddWithValue("$text", q.Text ?? "");
                cmd.Parameters.AddWithValue("$explanation", q.Explanation ?? "");
                cmd.Parameters.AddWithValue("$topic", (int)ParseEnum(typeof(Topic), q.Metadata?.Topic, Topic.Other));
                cmd.Parameters.AddWithValue("$difficulty", (int)ParseEnum(typeof(DifficultyBand), q.Metadata?.Difficulty, DifficultyBand.Easy));
                cmd.Parameters.AddWithValue("$qtype", (int)ParseEnum(typeof(QuestionType), q.Metadata?.QuestionType, QuestionType.SingleChoice));
                cmd.ExecuteNonQuery();
            }

            if (q.Options != null)
            {
                foreach (var opt in q.Options)
                {
                    using var cmd = conn.CreateCommand();
                    cmd.Transaction = tx;
                    cmd.CommandText = @"INSERT INTO AnswerOptions (QuestionId, Text, IsCorrect) VALUES ($qid, $text, $iscorrect);";
                    cmd.Parameters.AddWithValue("$qid", q.Id);
                    cmd.Parameters.AddWithValue("$text", opt.Text ?? "");
                    cmd.Parameters.AddWithValue("$iscorrect", opt.IsCorrect ? 1 : 0);
                    cmd.ExecuteNonQuery();
                }
            }

            var tags = q.Metadata?.MisconceptionTags;
            if (tags != null)
            {
                foreach (var tag in tags)
                {
                    var tagId = GetOrCreateTagId(conn, tx, tag ?? "");
                    using var cmd = conn.CreateCommand();
                    cmd.Transaction = tx;
                    cmd.CommandText = @"
                    INSERT OR IGNORE INTO QuestionMisconceptionTags (QuestionId, TagId)
                    VALUES ($qid, $tid);";
                    cmd.Parameters.AddWithValue("$qid", q.Id);
                    cmd.Parameters.AddWithValue("$tid", tagId);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        private static object ParseEnum(Type enumType, string? value, object fallback)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                return fallback; 
            }
              

            try
            {
                return Enum.Parse(enumType, value.Trim(), true);
            }

            catch
            {
                return fallback;
            }
        }


        private static long GetOrCreateTagId(SqliteConnection conn, SqliteTransaction tx, string tag)
        {
            tag = tag?.Trim() ?? "";
            if (tag.Length == 0)
                return -1;

            using (var find = conn.CreateCommand())
            {
                find.Transaction = tx;
                find.CommandText = "SELECT Id FROM MisconceptionTags WHERE Tag = $tag;";
                find.Parameters.AddWithValue("$tag", tag);
                var existing = find.ExecuteScalar();
                if (existing != null && existing != DBNull.Value)
                    return Convert.ToInt64(existing);
            }

            using (var ins = conn.CreateCommand())
            {
                ins.Transaction = tx;
                ins.CommandText = "INSERT INTO MisconceptionTags (Tag) VALUES ($tag);";
                ins.Parameters.AddWithValue("$tag", tag);
                ins.ExecuteNonQuery();
            }

            using (var id = conn.CreateCommand())
            {
                id.Transaction = tx;
                id.CommandText = "SELECT Id FROM MisconceptionTags WHERE Tag = $tag;";
                id.Parameters.AddWithValue("$tag", tag);
                return Convert.ToInt64(id.ExecuteScalar());
            }
        }

        private sealed class QuestionJson
        {
            public int Id { get; set; }
            public string? Text { get; set; }
            public string? Explanation { get; set; }
            public MetadataJson? Metadata { get; set; }
            public List<OptionJson>? Options { get; set; }
        }

        private sealed class MetadataJson
        {
            public string? Topic { get; set; }
            public string? Difficulty { get; set; }
            public string? QuestionType { get; set; }
            public List<string>? MisconceptionTags { get; set; }
        }

        private sealed class OptionJson
        {
            public int Id { get; set; }
            public string? Text { get; set; }
            public bool IsCorrect { get; set; }
        }
    }
}