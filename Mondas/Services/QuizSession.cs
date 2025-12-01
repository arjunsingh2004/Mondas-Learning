using System.Collections.Generic;
using Mondas.Contracts.Services;
using Mondas.Models;

namespace Mondas.Services
{
    public sealed class QuizSession
    {
        public IReadOnlyList<Question> Questions { get; private set; }
        public IRuleEngine RuleEngine { get; private set; }
        public UserModel UserModel { get; private set; }
        public List<QuestionAttempt> Attempts { get; private set; }

        public QuizSession(IReadOnlyList<Question> questions, IRuleEngine ruleEngine, UserModel userModel)
        {
            Questions = questions;
            RuleEngine = ruleEngine;
            UserModel = userModel;
            Attempts = new List<QuestionAttempt>();
        }

        public SelectionResult GetNextQuestion()
        {
            return RuleEngine.SelectNextQuestion(UserModel, Questions, Attempts);
        }

        public void RecordAttempt(Question question, QuestionAttempt attempt)
        {
            Attempts.Add(attempt);
            UserModel.UpdateFromAttempt(question, attempt);
        }
    }
}