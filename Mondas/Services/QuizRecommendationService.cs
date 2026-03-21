using System.Collections.Generic;
using System.Linq;
using Mondas.Models;

namespace Mondas.Services
{
    public sealed class QuizRecommendationService
    {
        private readonly JsonQuestionRepository _questionRepo;
        private readonly SharedAdaptiveLearningService _sharedAdaptiveLearningService;

        public QuizRecommendationService(string dbPath, string questionsJsonPath)
        {
            _questionRepo = new JsonQuestionRepository(questionsJsonPath);
            _sharedAdaptiveLearningService = new SharedAdaptiveLearningService(dbPath, questionsJsonPath);
        }

        public QuizPreferences BuildRecommended(string userKey)
        {
            var allQuestions = _questionRepo.GetAllQuestions() ?? new List<Question>();
            
            if (allQuestions.Count == 0)
            {
                return new QuizPreferences { UseDefaults = false, QuestionCount = 15, TimerEnabled = false, PrioritiseWeakTopics = true, Difficulty = DifficultyBand.Medium, Topics = new List<Topic> { Topic.Phishing }, QuestionTypes = new List<QuestionType>() };
            }

            var userModel = _sharedAdaptiveLearningService.BuildUserModel(userKey);
            var topicsAvailable = allQuestions.Select(q => q.Metadata.Topic).Where(t => t != Topic.Other).Distinct().ToList();
            var weakest = _sharedAdaptiveLearningService.GetWeakestTopic(userModel, topicsAvailable);

            if (!weakest.HasValue)
            {
                return new QuizPreferences { UseDefaults = false, QuestionCount = 15, TimerEnabled = false, PrioritiseWeakTopics = true, Difficulty = DifficultyBand.Medium, Topics = new List<Topic> { Topic.Phishing }, QuestionTypes = new List<QuestionType>() };
            }

            var weakestAccuracy = _sharedAdaptiveLearningService.GetMastery01(userModel, weakest.Value);

            return new QuizPreferences { UseDefaults = false, QuestionCount = 15, TimerEnabled = false, PrioritiseWeakTopics = true, Difficulty = weakestAccuracy < 0.45 ? DifficultyBand.Easy : DifficultyBand.Medium, Topics = new List<Topic> { weakest.Value }, QuestionTypes = new List<QuestionType>() };
        }
    }
}