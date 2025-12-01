using System;
using System.Collections.Generic;

namespace Mondas.Models
{
    public sealed class QuestionAttempt
    {
        public int QuestionId { get; set; }
        public DateTime StartedAt { get; set; }
        public DateTime SubmittedAt { get; set; }
        public bool IsCorrect { get; set; }
        public List<int> SelectedOptionIds { get; set; } = new();
        public string? ReasonString { get; set; }
        public List<string> RulesFired { get; set; } = new();
    }
}