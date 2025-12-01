using System.Collections.Generic;

namespace Mondas.Models
{
    public sealed class TopicStats
    {
        public int QuestionsSeen { get; set; }
        public int QuestionsCorrect { get; set; }

        public double Mastery => QuestionsSeen == 0
            ? 0.0
            : (double)QuestionsCorrect / QuestionsSeen;
    }

    public sealed class UserModel
    {
        public Dictionary<Topic, TopicStats> TopicStats { get; } = new();
        public Dictionary<string, int> MisconceptionCounts { get; } = new();
        public HashSet<int> RecentlySeenQuestionIds { get; } = new();

        public void UpdateFromAttempt(Question question, QuestionAttempt attempt)
        {
            if (!TopicStats.TryGetValue(question.Metadata.Topic, out var stats))
            {
                stats = new TopicStats();
                TopicStats[question.Metadata.Topic] = stats;
            }

            stats.QuestionsSeen++;
            if (attempt.IsCorrect)
                stats.QuestionsCorrect++;

            if (!attempt.IsCorrect)
            {
                foreach (var tag in question.Metadata.MisconceptionTags)
                {
                    int current;
                    if (!MisconceptionCounts.TryGetValue(tag, out current))
                    {
                        current = 0;
                    }

                    MisconceptionCounts[tag] = current + 1;
                }
            }

            RecentlySeenQuestionIds.Add(question.Id);
        }
    }
}