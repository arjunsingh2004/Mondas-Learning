using System;
using Microsoft.Data.Sqlite;

namespace Mondas.Services
{
    public sealed class SqliteUserRepository
    {
        private readonly string _dbPath;

        public SqliteUserRepository(string dbPath)
        {
            if (string.IsNullOrWhiteSpace(dbPath))
            {
                throw new ArgumentNullException(nameof(dbPath));
            }

            _dbPath = dbPath;
        }

        private SqliteConnection Open()
        {
            var conn = new SqliteConnection("Data Source=" + _dbPath);
            conn.Open();

            using (var pragma = conn.CreateCommand())
            {
                pragma.CommandText = "PRAGMA foreign_keys = ON;";
                pragma.ExecuteNonQuery();
            }

            return conn;
        }

        public bool EmailExists(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
            {
                return false;
            }

            var cleanEmail = email.Trim().ToLowerInvariant();

            using (var conn = Open())
            using (var cmd = conn.CreateCommand())
            {
                cmd.CommandText = "SELECT 1 FROM Users WHERE Email = @email LIMIT 1;";
                cmd.Parameters.AddWithValue("@email", cleanEmail);

                var result = cmd.ExecuteScalar();
                return result != null && result != DBNull.Value;
            }
        }

        public long CreateUser(string fullName, string email, string passwordHash, string passwordSalt, int iterations)
        {
            if (string.IsNullOrWhiteSpace(fullName))
            {
                throw new ArgumentException("Full name is required.", nameof(fullName));
            }

            if (string.IsNullOrWhiteSpace(email))
            {
                throw new ArgumentException("Email is required.", nameof(email));
            }

            if (string.IsNullOrWhiteSpace(passwordHash))
            {
                throw new ArgumentException("PasswordHash is required.", nameof(passwordHash));
            }

            if (string.IsNullOrWhiteSpace(passwordSalt))
            {
                throw new ArgumentException("PasswordSalt is required.", nameof(passwordSalt));
            }

            if (iterations <= 0)
            {
                throw new ArgumentException("Iterations must be > 0.", nameof(iterations));
            }

            var cleanEmail = email.Trim().ToLowerInvariant();
            var createdUtc = DateTime.UtcNow.ToString("o");

            using (var conn = Open())
            using (var cmd = conn.CreateCommand())
            {
                cmd.CommandText = @"INSERT INTO Users (FullName, Email, IsAdmin, PasswordHash, PasswordSalt, PasswordIterations, TotpSecretBase32, TotpEnabled, CreatedUtc)
                                    VALUES (@name, @email, 0, @hash, @salt, @iters, NULL, 0, @created);
                                    SELECT last_insert_rowid();";

                cmd.Parameters.AddWithValue("@name", fullName.Trim());
                cmd.Parameters.AddWithValue("@email", cleanEmail);
                cmd.Parameters.AddWithValue("@hash", passwordHash);
                cmd.Parameters.AddWithValue("@salt", passwordSalt);
                cmd.Parameters.AddWithValue("@iters", iterations);
                cmd.Parameters.AddWithValue("@created", createdUtc);

                return Convert.ToInt64(cmd.ExecuteScalar());
            }
        }

        public void SetTotp(long userId, string totpSecretBase32, bool enabled)
        {
            if (userId <= 0)
            {
                throw new ArgumentException("Invalid user id.", nameof(userId));
            }

            using (var conn = Open())
            using (var cmd = conn.CreateCommand())
            {
                cmd.CommandText = @"UPDATE Users SET TotpSecretBase32 = @secret, TotpEnabled = @enabled WHERE Id = @id;";

                cmd.Parameters.AddWithValue("@secret", (object)totpSecretBase32 ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@enabled", enabled ? 1 : 0);
                cmd.Parameters.AddWithValue("@id", userId);

                cmd.ExecuteNonQuery();
            }
        }

        public void SetTotpEnabled(long userId, bool enabled)
        {
            if (userId <= 0)
            {
                throw new ArgumentException("Invalid user id.", nameof(userId));
            }

            using (var conn = Open())
            using (var cmd = conn.CreateCommand())
            {
                cmd.CommandText = @"UPDATE Users SET TotpEnabled = @enabled WHERE Id = @id;";
                cmd.Parameters.AddWithValue("@enabled", enabled ? 1 : 0);
                cmd.Parameters.AddWithValue("@id", userId);
                cmd.ExecuteNonQuery();
            }
        }

        public UserRow GetByEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
            {
                return null;
            }

            var cleanEmail = email.Trim().ToLowerInvariant();

            using (var conn = Open())
            using (var cmd = conn.CreateCommand())
            {
                cmd.CommandText = @"SELECT Id, FullName, Email, IsAdmin, PasswordHash, PasswordSalt, PasswordIterations, TotpSecretBase32, TotpEnabled, CreatedUtc
                                    FROM Users
                                    WHERE Email = @email
                                    LIMIT 1;";

                cmd.Parameters.AddWithValue("@email", cleanEmail);

                using (var r = cmd.ExecuteReader())
                {
                    if (!r.Read())
                    {
                        return null;
                    }

                    return new UserRow
                    {
                        Id = r.GetInt64(0),
                        FullName = r.GetString(1),
                        Email = r.GetString(2),
                        IsAdmin = r.GetInt32(3) == 1,
                        PasswordHash = r.GetString(4),
                        PasswordSalt = r.GetString(5),
                        PasswordIterations = r.GetInt32(6),
                        TotpSecretBase32 = r.IsDBNull(7) ? null : r.GetString(7),
                        TotpEnabled = r.GetInt32(8) == 1,
                        CreatedUtc = DateTime.Parse(r.GetString(9)).ToUniversalTime()
                    };
                }
            }
        }
   
        public UserRow GetById(long id)
        {
            if (id <= 0)
            {
                return null;
            }

            using (var conn = Open())
            using (var cmd = conn.CreateCommand())
            {
                cmd.CommandText = @"SELECT Id, FullName, Email, IsAdmin, PasswordHash, PasswordSalt, PasswordIterations, TotpSecretBase32, TotpEnabled, CreatedUtc FROM Users WHERE Id = @id LIMIT 1;";
                cmd.Parameters.AddWithValue("@id", id);

                using (var r = cmd.ExecuteReader())
                {
                    if (!r.Read())
                    {
                        return null;
                    }

                    return new UserRow
                    {
                        Id = r.GetInt64(0),
                        FullName = r.GetString(1),
                        Email = r.GetString(2),
                        IsAdmin = r.GetInt32(3) == 1,
                        PasswordHash = r.GetString(4),
                        PasswordSalt = r.GetString(5),
                        PasswordIterations = r.GetInt32(6),
                        TotpSecretBase32 = r.IsDBNull(7) ? null : r.GetString(7),
                        TotpEnabled = r.GetInt32(8) == 1,
                        CreatedUtc = DateTime.Parse(r.GetString(9)).ToUniversalTime()
                    };
                }
            }
        }

        public void SetAdminByEmail(string email, bool isAdmin)
        {
            if (string.IsNullOrWhiteSpace(email))
            {
                return;
            }

            using var conn = Open();
            using var cmd = conn.CreateCommand();

            cmd.CommandText = "UPDATE Users SET IsAdmin = @isAdmin WHERE Email = @email;";
            cmd.Parameters.AddWithValue("@isAdmin", isAdmin ? 1 : 0);
            cmd.Parameters.AddWithValue("@email", email.Trim().ToLowerInvariant());

            cmd.ExecuteNonQuery();
        }
    }

    public sealed class UserRow
    {
        public long Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public bool IsAdmin { get; set; }
        public string PasswordHash { get; set; }
        public string PasswordSalt { get; set; }
        public int PasswordIterations { get; set; }
        public string TotpSecretBase32 { get; set; }
        public bool TotpEnabled { get; set; }
        public DateTime CreatedUtc { get; set; }
    }
}