using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Mondas.Models;
using Syncfusion.Windows.Forms.Tools.Navigation;

namespace Mondas.Services
{
    public sealed class QuizRecommendationService
    {
        private readonly SqliteAttemptRepository _attemptRepo;
        private readonly JsonQuestionRepository _questionRepo;

        public QuizRecommendationService(string dbPath, string questionsJsonPath)
        {
            _attemptRepo = new SqliteAttemptRepository(dbPath);
            _questionRepo = new JsonQuestionRepository(questionsJsonPath);
        }

        public QuizPreferences BuildRecommended(string userKey)
        {
            var allQuestions = _questionRepo.GetAllQuestions();
            var byId = allQuestions.ToDictionary(q => q.Id, q => q);

            var history = _attemptRepo.GetForUser(userKey).OrderBy(r=>r.SubmittedAt).ToList();

            if (history.Count == 0)
            {
                return new QuizPreferences { UseDefaults = false, QuestionCount = 15, TimerEnabled = false, PrioritiseWeakTopics = true, Difficulty = DifficultyBand.Medium, Topics = new List<Topic> { Topic.Phishing }, QuestionTypes = new List<QuestionType>() };

            }

            var stats = new Dictionary<Topic, (int total, int correct)>();

            foreach (var record in history)
            {
                if (!byId.TryGetValue(record.QuestionId, out var q))
                {
                    continue;
                }

                var t = q.Metadata.Topic;
                if (!stats.TryGetValue(t, out var s))
                {
                    s = (0, 0);
                }

                s.total++;
                if (record.IsCorrect) s.correct++;
                stats[t] = s;
            }

            Topic weakest = Topic.Phishing;
            double weakestAcc = double.MaxValue;

            foreach (Topic t in Enum.GetValues(typeof(Topic)))
            {
                if (t == Topic.Other)
                {
                    continue;
                }

                if (!stats.TryGetValue(t, out var s) || s.total == 0)
                {
                    continue;
                }

                var acc = (double)s.correct / s.total;

                if (acc < weakestAcc)
                {
                    weakestAcc = acc;
                    weakest = t;
                }
            }

            return new QuizPreferences { UseDefaults = false, QuestionCount = 15, TimerEnabled = false, PrioritiseWeakTopics = true, Difficulty = DifficultyBand.Medium, Topics = new List<Topic> { weakest }, QuestionTypes = new List<QuestionType>() };
        }
    }
}