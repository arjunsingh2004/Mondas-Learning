using System;
using System.Collections.Generic;
using System.Linq;
using Mondas.Contracts.Services;
using Mondas.Models;

namespace Mondas.Services
{
    public sealed class RuleEngineV1 : IRuleEngine
    {
        private readonly Random _random = new Random();

        public SelectionResult SelectNextQuestion(
            UserModel userModel,
            IReadOnlyList<Question> allQuestions,
            IReadOnlyList<QuestionAttempt> previousAttempts)
        {
            var trace = new List<string>();
            var candidates = allQuestions.ToList();

            var recentIds = new HashSet<int>(previousAttempts.OrderByDescending(a => a.SubmittedAt).Take(5).Select(a => a.QuestionId));
            candidates = candidates.Where(q => !recentIds.Contains(q.Id)).ToList();
            trace.Add("AvoidRecentQuestions");

            if (!candidates.Any())
            {
                trace.Add("NoCandidatesAfterAvoidRecent");
                return new SelectionResult
                {
                    SelectedQuestion = null,
                    ReasonString = "No more questions available.",
                    RulesFired = trace
                };
            }

            Topic? weakestTopic = null;
            double weakestMastery = double.MaxValue;

            foreach (Topic topic in Enum.GetValues(typeof(Topic)))
            {
                TopicStats stats;
                userModel.TopicStats.TryGetValue(topic, out stats);
                var mastery = stats == null ? 0.0 : stats.Mastery;

                if (mastery < weakestMastery)
                {
                    weakestMastery = mastery;
                    weakestTopic = topic;
                }
            }

            if (weakestTopic != null)
            {
                var topicCandidates = candidates.Where(q => q.Metadata.Topic == weakestTopic.Value).ToList();

                if (topicCandidates.Any())
                {
                    candidates = topicCandidates;
                    trace.Add("FocusWeakTopic:" + weakestTopic.Value);
                }
            }

            if (!candidates.Any())
            {
                trace.Add("NoCandidatesAfterWeakTopicFocus");
                return new SelectionResult
                {
                    SelectedQuestion = null,
                    ReasonString = "No more questions available.",
                    RulesFired = trace
                };
            }

            var preferred = candidates.Where(q => q.Metadata.Difficulty == DifficultyBand.Medium).ToList();

            if (!preferred.Any())
            {
                preferred = candidates;
                trace.Add("FallbackDifficulty");
            }
            else
            {
                trace.Add("TargetDifficulty:Medium");
            }

            if (!preferred.Any())
            {
                trace.Add("NoPreferredCandidates");
                return new SelectionResult
                {
                    SelectedQuestion = null,
                    ReasonString = "No more questions available.",
                    RulesFired = trace
                };
            }

            var selected = preferred[_random.Next(preferred.Count)];
            var reason = BuildReasonString(selected, weakestTopic, weakestMastery);

            return new SelectionResult
            {
                SelectedQuestion = selected,
                ReasonString = reason,
                RulesFired = trace
            };
        }

        private static string BuildReasonString(Question question, Topic? weakestTopic, double weakestMastery)
        {
            if (weakestTopic != null && question.Metadata.Topic == weakestTopic.Value)
            {
                return "Focusing on " + weakestTopic.Value + " because your mastery is currently " + weakestMastery.ToString("P0") + ".";
            }

            return "Showing a " + question.Metadata.Difficulty + " " + question.Metadata.Topic + " question to keep variety.";
        }
    }
}