using System.Collections.Generic;

namespace Mondas.Models
{
    public sealed class LearningModule
    {
        public string Id { get; set; } = "";
        public string Title { get; set; } = "";
        public string Topic { get; set; } = "";
        public string Type { get; set; } = "";
        public string Overview { get; set; } = "";
        public int EstimatedMinutes { get; set; }
        public string OpenUrl { get; set; } = "";
        public string PreviewUrl { get; set; } = "";
        public List<string> AppliesToSources { get; set; } = new List<string>();
        public List<string> MisconceptionTags { get; set; } = new List<string>();
        public List<LearningResource> Resources { get; set; } = new List<LearningResource>();
        public List<string> Objectives { get; set; } = new List<string>();
        public List<string> KeyPoints { get; set; } = new List<string>();
        public List<string> RedFlags { get; set; } = new List<string>();
        public List<string> Checklist { get; set; } = new List<string>();
        public List<LearningExample> Examples { get; set; } = new List<LearningExample>();
        public List<string> ReflectionQuestions { get; set; } = new List<string>();
        public List<LearningCheckQuestion> CheckQuestions { get; set; } = new List<LearningCheckQuestion>();
    }

    public sealed class LearningResource
    {
        public string Title { get; set; } = "";
        public string Type { get; set; } = "";
        public string Source { get; set; } = "";
        public string Url { get; set; } = "";
    }

    public sealed class LearningExample
    {
        public string Title { get; set; } = "";
        public string Scenario { get; set; } = "";
        public string Takeaway { get; set; } = "";
    }

    public sealed class LearningCheckQuestion
    {
        public string Prompt { get; set; } = "";
        public List<LearningCheckOption> Options { get; set; } = new List<LearningCheckOption>();
    }

    public sealed class LearningCheckOption
    {
        public string Text { get; set; } = "";
        public bool IsCorrect { get; set; }
        public string Feedback { get; set; } = "";
    }

    public sealed class LearningModuleState
    {
        public string UserKey { get; set; } = "local";
        public List<string> CompletedModuleIds { get; set; } = new List<string>();
        public List<string> BookmarkedModuleIds { get; set; } = new List<string>();
        public List<string> PassedCheckModuleIds { get; set; } = new List<string>(); 
    }

    public sealed class LearningModuleRecommendation
    {
        public LearningModule Module { get; set; }
        public int Score { get; set; }

        public string MatchText
        {
            get
            {
                if (Score >= 8)
                {
                    return "HIGH";
                }

                if (Score >= 4)
                {
                    return "MEDIUM";
                }

                return "LOW";
            }
        }
    }
}