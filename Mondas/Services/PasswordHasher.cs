using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace Mondas.Services
{
    public sealed class PasswordHasher
    {
        private const int DefaultIterations = 150_000;
        private const int SaltBytes = 16;
        private const int HashBytes = 32;

        public PasswordHashResult Hash(string password)
        {
            if (string.IsNullOrWhiteSpace(password))
            {
                throw new ArgumentException("Password cannot be empty.", nameof(password));
            }

            var salt = new byte[SaltBytes];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(salt);
            }

            byte[] hash;
            using (var pbkdf2 = new Rfc2898DeriveBytes(password, salt, DefaultIterations, HashAlgorithmName.SHA256))
            {
                hash = pbkdf2.GetBytes(HashBytes);
            }

            return new PasswordHashResult{ HashBase64 = Convert.ToBase64String(hash), SaltBase64 = Convert.ToBase64String(salt), Iterations = DefaultIterations };
        }

        public bool Verify(string password, string hashBase64, string saltBase64, int iterations)
        {
            if (string.IsNullOrWhiteSpace(password) || string.IsNullOrWhiteSpace(hashBase64) || string.IsNullOrWhiteSpace(saltBase64) || iterations <= 0)
            {
                return false;
            }

            byte[] salt;
            byte[] expected;

            try
            {
                salt = Convert.FromBase64String(saltBase64);
                expected = Convert.FromBase64String(hashBase64);
            }

            catch
            {
                return false;
            }

            byte[] actual;
            using (var pbkdf2 = new Rfc2898DeriveBytes(password, salt, iterations, HashAlgorithmName.SHA256))
            {
                actual = pbkdf2.GetBytes(expected.Length);
            }

            return FixedTimeEquals(actual, expected);
        }

        private bool FixedTimeEquals(byte[] a, byte[] b)
        {
            if (a == null || b == null)
            {
                return false;
            }

            if (a.Length != b.Length)
            {
                return false;
            }

            int diff = 0;
            for (int i = 0; i < a.Length; i++)
            {
                diff |= a[i] ^ b[i];
            }

            return diff == 0;
        }
    }

    public sealed class PasswordHashResult
    {
        public string HashBase64 { get; set; }
        public string SaltBase64 { get; set; }
        public int Iterations { get; set; }
    }
}