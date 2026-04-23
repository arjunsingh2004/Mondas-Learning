using Syncfusion.Windows.Forms.Tools.Win32API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;


namespace Mondas.Contracts.Services
{
    public sealed class TotpService
    {
        private const int StepSeconds = 30;
        private const int TotpDigits = 6;

        public byte[] GenerateSecretBytes(int bytes = 20)
        {
            var secret = new byte[bytes];

            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(secret);
            }

            return secret;
        }

        public string BuildOtpAuthUri(string issuer, string email, string secretBase32)
        {
            var label = Uri.EscapeDataString($"{issuer}:{email}");
            var iss = Uri.EscapeDataString(issuer);
            var secret = Uri.EscapeDataString(secretBase32);

            return $"otpauth://totp/{label}?secret={secret}&issuer={iss}&digits={TotpDigits}&period={StepSeconds}";
        }
    
        public bool VerifyCode(string secretBase32, string code)
        {
            if (string.IsNullOrWhiteSpace(secretBase32) || string.IsNullOrWhiteSpace(code))
            {
                return false;
            }

            code = code.Trim().Replace(" ", "");

            if (code.Length != 6)
            {
                return false;
            }

            var secret = Base32.Decode(secretBase32);
            var now = DateTime.UtcNow;

            return ComputeCode(secret, now.AddSeconds(-StepSeconds)) == code || ComputeCode(secret, now) == code || ComputeCode(secret, now.AddSeconds(+StepSeconds)) == code;
        }

        public string ComputeCode(byte[] secret, DateTime utcNow)
        {
            long counter = GetCounter(utcNow);
            var counterBytes = BitConverter.GetBytes(counter);

            if (BitConverter.IsLittleEndian)
            {
                Array.Reverse(counterBytes);
            }

            using var hmac = new HMACSHA1(secret);
            var hash =hmac.ComputeHash(counterBytes);

            int offset = hash[hash.Length - 1] & 0x0F;
            int binary = ((hash[offset] & 0x7f) << 24) | ((hash[offset + 1] & 0xff) << 16) | ((hash[offset + 2] & 0xff) << 8) | ((hash[offset + 3] & 0xff));

            int otp = binary % (int)Math.Pow(10, TotpDigits);
            return otp.ToString(new string('0', TotpDigits));               
        }
        
        private static long GetCounter(DateTime utcNow)
        {
            var unix = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            var seconds = (long)(utcNow - unix).TotalSeconds;
            return seconds / StepSeconds;
        }
    }
}