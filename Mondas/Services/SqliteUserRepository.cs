using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.Sqlite;
using System;

namespace Mondas.Services
{
    public sealed class SqliteUserRepository(string dbPath)
    {
        private readonly string _dbPath = dbPath ?? throw new ArgumentNullException(nameof(dbPath));

        private SqliteConnection Open()
        {
            var conn = new SqliteConnection($"Data Source={_dbPath}");
            conn.Open();
            return conn;
        }

        public bool EmailExists(string email)
        {
            using var conn = Open();
            using var cmd = conn.CreateCommand();
            cmd.CommandText = "SELECT 1 FROM users WHERE email = @email LIMIT 1;";
            cmd.Parameters.AddWithValue("@Email", email);
            var result = cmd.ExecuteScalar();
            return result != null;
        }

        public int CreateUser(string fullName, string email, string passwordHash, string passwordSalt, int iterations, string totpSecretBase32)
        {
            using var conn = Open();
            using var cmd = conn.CreateCommand();

            cmd.CommandText = @"INSERT INTO users (full_name, email, password_hash, password_salt, password_iterations, totp_secret_base32, totp_enabled, created_utc)
                                VALUES (@name, @email, @hash, @salt, @iters, @totp, 0, @created);
                                SELECT last_insert_rowid();";

            cmd.Parameters.AddWithValue("@name", fullName);
            cmd.Parameters.AddWithValue("@email", email);
            cmd.Parameters.AddWithValue("@hash", passwordHash);
            cmd.Parameters.AddWithValue("@salt", passwordSalt);
            cmd.Parameters.AddWithValue("@iters", iterations);
            cmd.Parameters.AddWithValue("@totp", (object)totpSecretBase32 ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@created", DateTime.UtcNow.ToString("O"));

            var id = Convert.ToInt32(cmd.ExecuteScalar());
            return id;
        }

        public void SetTotpEnabled(int userId, bool enabled)
        {
            using var conn = Open();
            using var cmd = conn.CreateCommand();
            cmd.CommandText = "UPDATE users SET totp_enabled = @enabled WHERE id = @id;";
            cmd.Parameters.AddWithValue("@enabled", enabled ? 1 : 0);
            cmd.Parameters.AddWithValue("@id", userId);
            cmd.ExecuteNonQuery();
        }

        public UserRow GetByEmail(string email)
        {
            using var conn = Open();
            using var cmd = conn.CreateCommand();

            cmd.CommandText = @"SELECT id, full_name, email, password_hash, password_salt, password_iterations, totp_secret_base32, totp_enabled
                                FROM users
                                WHERE email = @Email
                                LIMIT 1;";

            cmd.Parameters.AddWithValue("@Email", email);

            using var r = cmd.ExecuteReader();
            if (!r.Read())
            {
                return null;
            }

            return new UserRow
            {
                Id = r.GetInt32(0),
                FullName = r.GetString(1),
                Email = r.GetString(2),
                PasswordHash = r.GetString(3),
                PasswordSalt = r.GetString(4),
                PasswordIterations = r.GetInt32(5),
                TotpSecretBase32 = r.IsDBNull(6) ? null : r.GetString(6),
                TotpEnabled = r.GetInt32(7) == 1
            };
        }
    }

    public sealed class UserRow
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public string PasswordSalt { get; set; }
        public int PasswordIterations { get; set; }
        public string TotpSecretBase32 { get; set; }
        public bool TotpEnabled { get; set; }
    }
}