using System;
using System.IO;
using System.Text.Json;
using Mondas.Models;

namespace Mondas.Services
{
    public sealed class MiniGamePreferencesStore
    {
        private readonly JsonSerializerOptions _json = new JsonSerializerOptions { WriteIndented = true, PropertyNameCaseInsensitive = true };

        public MiniGamePrefsData Load(string userKey)
        {
            var path = BuildPath(userKey);

            try
            {
                if (!File.Exists(path))
                {
                    return CreateDefaultData();
                }

                var json = File.ReadAllText(path);
                var data = JsonSerializer.Deserialize<MiniGamePrefsData>(json, _json) ?? CreateDefaultData();

                data.Phishing = MiniGamePreferences.Normalise(data.Phishing);
                data.Authentication = MiniGamePreferences.Normalise(data.Authentication);

                if (data.RecommendedOverride != null)
                {
                    data.RecommendedOverride = MiniGamePreferences.Normalise(data.RecommendedOverride);
                }

                return data;
            }

            catch
            {
                return CreateDefaultData();
            }
        }

        public void Save(string userKey, MiniGamePrefsData data)
        {
            data ??= CreateDefaultData();

            data.Phishing = MiniGamePreferences.Normalise(data.Phishing);
            data.Authentication = MiniGamePreferences.Normalise(data.Authentication);

            if (data.RecommendedOverride != null)
            {
                data.RecommendedOverride = MiniGamePreferences.Normalise(data.RecommendedOverride);
            }

            var path = BuildPath(userKey);
            Directory.CreateDirectory(Path.GetDirectoryName(path) ?? AppContext.BaseDirectory);

            var json = JsonSerializer.Serialize(data, _json);
            File.WriteAllText(path, json);
        }

        private static string BuildPath(string userKey)
        {
            var safe = (string.IsNullOrWhiteSpace(userKey) ? "local" : userKey.Trim()).Replace(":", "_").Replace("/", "_").Replace("\\", "_");
            return Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Mondas", "minigame_prefs_" + safe + ".json");
        }

        private static MiniGamePrefsData CreateDefaultData()
        {
            return new MiniGamePrefsData { Phishing = MiniGamePreferences.CreateDefault(MiniGameType.PhishingSimulator), Authentication = MiniGamePreferences.CreateDefault(MiniGameType.AuthenticationDefense), RecommendedOverride = null };
        }

        public sealed class MiniGamePrefsData
        {
            public MiniGamePreferences Phishing { get; set; } = MiniGamePreferences.CreateDefault(MiniGameType.PhishingSimulator);
            public MiniGamePreferences Authentication { get; set; } = MiniGamePreferences.CreateDefault(MiniGameType.AuthenticationDefense);
            public MiniGamePreferences RecommendedOverride { get; set; }
        }
    }
}