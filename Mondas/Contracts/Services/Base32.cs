using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mondas.Contracts.Services
{
    public static class Base32
    {
        private const string Alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ234567";
        public static string Encode(byte[] data)
        {
            if (data == null || data.Length == 0)
            {
                return string.Empty;
            }

            var result = new StringBuilder();
            int buffer = data[0];
            int next = 1;
            int bitsLeft = 8;

            while (bitsLeft > 0 || next < data.Length)
            {
                if (bitsLeft < 5)
                {
                    if (next  < data.Length)
                    {
                        buffer <<= 8;
                        buffer |= data[next++] & 0xff;
                        bitsLeft += 8;
                    }

                    else
                    {
                        int pad = 5 - bitsLeft;
                        buffer <<= pad;
                        bitsLeft += pad;
                    }
                }

                int index = (buffer >> (bitsLeft - 5)) & 0x1f;
                bitsLeft -= 5;
                result.Append(Alphabet[index]);
            }

            return result.ToString();
        }

        public static byte[] Decode(string base32)
        {
            if (string.IsNullOrWhiteSpace(base32))
            {
                return Array.Empty<byte>();
            }

            base32 = base32.Trim().Replace(" ", "").ToUpperInvariant();

            var output = new List<byte>();
            int buffer = 0;
            int bitsLeft = 0;

            foreach (char c in base32)
            {
                int val = Alphabet.IndexOf(c);

                if (val < 0)
                {
                    continue;
                }

                buffer <<= 5;
                buffer |= val & 0x1f;
                bitsLeft += 5;

                if (bitsLeft >= 8)
                {
                    output.Add((byte)((buffer >> (bitsLeft - 8)) & 0xff));
                    bitsLeft -= 8;
                }
            }

            return output.ToArray();
        }
    }
}