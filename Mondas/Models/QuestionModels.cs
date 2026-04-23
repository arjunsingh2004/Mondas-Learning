using System.Collections.Generic;

namespace Mondas.Models
{
    public enum Topic
    {
        Phishing,
        Passwords,
        DeviceSecurity,
        SocialEngineering,
        Other
    }

    public enum DifficultyBand
    {
        Easy,
        Medium,
        Hard
    }

    public enum QuestionType
    {
        SingleChoice,
        MultipleChoice,
        TrueFalse,
        Scenario
    }

    public sealed class QuestionMetadata
    {
        public Topic Topic { get; set; }
        public DifficultyBand Difficulty { get; set; }
        public QuestionType QuestionType { get; set; }
        public List<string> MisconceptionTags { get; set; } = new();
    }

    public sealed class AnswerOption
    {
        public int Id { get; set; }
        public string Text { get; set; } = "";
        public bool IsCorrect { get; set; }
    }

    public sealed class Question
    {
        public int Id { get; set; }
        public string Text { get; set; } = "";
        public string Explanation { get; set; } = "";
        public QuestionMetadata Metadata { get; set; } = new();
        public List<AnswerOption> Options { get; set; } = new();
    }
}