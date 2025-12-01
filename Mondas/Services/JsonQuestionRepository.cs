using Mondas.Contracts.Services;
using Mondas.Models;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Text.Json.Serialization;

namespace Mondas.Services
{
    public sealed class JsonQuestionRepository : IQuestionRepository
    {
        private readonly string _filePath;

        public JsonQuestionRepository(string filePath)
        {
            _filePath = filePath;
        }

        public IReadOnlyList<Question> GetAllQuestions()
        {
            if (!File.Exists(_filePath))
                return new List<Question>();

            var json = File.ReadAllText(_filePath);
            var questions = JsonConvert.DeserializeObject<List<Question>>(json);
            return questions ?? new List<Question>();
        }
    }
}