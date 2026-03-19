using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;
using Mondas.Models;

namespace Mondas.Services
{
    public sealed class AuthenticationDefenseScenarioRepository
    {
        private readonly string _filePath;
        private readonly JsonSerializerOptions _json = new JsonSerializerOptions { PropertyNameCaseInsensitive = true, Converters = { new JsonStringEnumConverter() } };

        public AuthenticationDefenseScenarioRepository(string filePath)
        {
            _filePath = filePath;
        }

        public IReadOnlyList<AuthenticationDefenseScenario> LoadAll()
        {
            if (!File.Exists(_filePath))
            {
                return new List<AuthenticationDefenseScenario>();
            }

            try
            {
                var json = File.ReadAllText(_filePath);
                var items = JsonSerializer.Deserialize<List<AuthenticationDefenseScenario>>(json, _json);

                return items ?? new List<AuthenticationDefenseScenario>();
            }

            catch
            {
                return new List<AuthenticationDefenseScenario>();
            }
        }
    }
}