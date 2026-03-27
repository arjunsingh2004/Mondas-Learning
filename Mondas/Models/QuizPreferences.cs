using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mondas.Models
{
    public sealed class QuizPreferences
    {
        public bool UseDefaults { get; set; } = true;

        public int QuestionCount { get; set; } = 15;
        public bool TimerEnabled { get; set; } = false;

        public List<Topic> Topics { get; set; } = new();
        public bool PrioritiseWeakTopics { get; set; } = true;

        public DifficultyBand? Difficulty { get; set; } = null;
        public List<QuestionType> QuestionTypes { get; set; } = new();
    }
}