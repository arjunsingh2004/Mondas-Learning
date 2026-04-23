using System;
using System.Collections.Generic;

namespace Mondas.Models
{
    public sealed class TopicStats
    {
        public int QuestionsSeen { get; set; }
        public int QuestionsCorrect { get; set; }
        public double MasteryScoreTotal { get; set; }
        public double Mastery => QuestionsSeen == 0 ? 0.0 : (double)QuestionsCorrect / QuestionsSeen;
    }

    public sealed class UserModel
    {
        public Dictionary<Topic, TopicStats> TopicStats { get; } = new();
        public Dictionary<string, int> MisconceptionCounts { get; } = new();
        public HashSet<int> RecentlySeenQuestionIds { get; } = new();

        public void UpdateFromAttempt(Question question, QuestionAttempt attempt)
        {
            if (question == null || attempt == null)
            {
                return;
            }

            var stats = GetOrCreateTopicStats(question.Metadata.Topic);

            stats.QuestionsSeen++;

            if (attempt.IsCorrect)
            {
                stats.QuestionsCorrect++;
                stats.MasteryScoreTotal += 1.0;
            }

            if (!attempt.IsCorrect)
            {
                foreach (var tag in question.Metadata.MisconceptionTags)
                {
                    AddMisconceptionTag(tag);
                }
            }

            RecentlySeenQuestionIds.Add(question.Id);
        }

        public void UpdateTopicAttempt(Topic topic, double accuracy01, IEnumerable<string> misconceptionTags = null)
        {
            var stats = GetOrCreateTopicStats(topic);
            var credit = Clamp01(accuracy01);

            stats.QuestionsSeen++;
            stats.MasteryScoreTotal += credit;

            if (credit >= 0.999)
            {
                stats.QuestionsCorrect++;
            }

            if (credit < 0.999 && misconceptionTags != null)
            {
                foreach (var raw in misconceptionTags)
                {
                    AddMisconceptionTag(raw);
                }
            }
        }

        private TopicStats GetOrCreateTopicStats(Topic topic)
        {
            if (!TopicStats.TryGetValue(topic, out var stats))
            {
                stats = new TopicStats();
                TopicStats[topic] = stats;
            }

            return stats;
        }

        private void AddMisconceptionTag(string raw)
        {
            var tag = (raw ?? "").Trim();

            if (tag.Length == 0)
            {
                return;
            }

            if (!MisconceptionCounts.TryGetValue(tag, out var current))
            {
                current = 0;
            }

            MisconceptionCounts[tag] = current + 1;
        }

        private static double Clamp01(double value)
        {
            if (value < 0.0)
            {
                return 0.0;
            }

            if (value > 1.0)
            {
                return 1.0;
            }

            return value;
        }
    }
}