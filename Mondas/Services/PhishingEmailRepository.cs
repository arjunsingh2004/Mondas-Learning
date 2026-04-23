using System;
using System.Collections.Generic;
using System.IO;
using Mondas.Models;
using Newtonsoft.Json;

namespace Mondas.Services
{
    public sealed class PhishingEmailRepository
    {
        private readonly string _filePath;

        public PhishingEmailRepository(string filePath)
        {
            _filePath = filePath;
        }

        public IReadOnlyList<PhishingEmail> LoadAll()
        {
            if (!File.Exists(_filePath))
            {
                return new List<PhishingEmail>();
            }

            try
            {
                var json = File.ReadAllText(_filePath);
                var items = JsonConvert.DeserializeObject<List<PhishingEmail>>(json);
                return items ?? new List<PhishingEmail>();
            }

            catch
            {
                return new List<PhishingEmail>();
            }
        }
    }
}