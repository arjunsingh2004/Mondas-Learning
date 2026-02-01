using System;
using System.IO;
using System.Text.Json;
using Mondas.Models;

namespace Mondas.Services
{
    public sealed class QuizPreferencesStore
    {
        private readonly string _filePath;
        private readonly JsonSerializerOptions _json;

        public QuizPreferencesStore(string filePath)
        {
            _filePath = filePath;
            _json = new JsonSerializerOptions { WriteIndented = true };
        }

        public QuizPreferences LoadOrDefault()
        {
            try
            {
                if (!File.Exists(_filePath))
                {
                    return new QuizPreferences { UseDefaults = true };
                }

                var json = File.ReadAllText(_filePath);
                var prefs = JsonSerializer.Deserialize<QuizPreferences>(json, _json);

                return prefs ?? new QuizPreferences { UseDefaults = true };
            }
            catch
            {
                return new QuizPreferences { UseDefaults = true };
            }
        }
        
        public void Save (QuizPreferences prefs)
        {
            if (prefs == null)
            {
                return;
            }

            var dir = Path.GetDirectoryName(_filePath);

            if (!string.IsNullOrWhiteSpace(dir) && !Directory.Exists(dir))
            {
                Directory.CreateDirectory(dir);
            }

            var json = JsonSerializer.Serialize(prefs, _json);
            File.WriteAllText(_filePath, json);
        }
    }
}