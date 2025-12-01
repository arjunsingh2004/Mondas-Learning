using System.Collections.Generic;
using Mondas.Models;

namespace Mondas.Contracts.Services
{
    public sealed class SelectionResult
    {
        public Question SelectedQuestion { get; set; } = null!;
        public string ReasonString { get; set; } = "";
        public List<string> RulesFired { get; set; } = new();
    }

    public interface IRuleEngine
    {
        SelectionResult SelectNextQuestion(
            UserModel userModel,
            IReadOnlyList<Question> allQuestions,
            IReadOnlyList<QuestionAttempt> previousAttempts);
    }
}