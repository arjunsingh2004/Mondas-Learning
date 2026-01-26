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

        private readonly bool _focusWeakTopic;
        private readonly DifficultyBand? _preferredDifficulty;

        public RuleEngineV1(bool focusWeakTopic = true, DifficultyBand? preferredDifficulty = DifficultyBand.Medium)
        {
            _focusWeakTopic = focusWeakTopic;
            _preferredDifficulty = preferredDifficulty;
        }

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

            if (candidates.Count == 0)
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

            if (_focusWeakTopic && weakestTopic != null)
            {
                var topicCandidates = candidates.Where(q => q.Metadata.Topic == weakestTopic.Value).ToList();

                if (topicCandidates.Count > 0)
                {
                    candidates = topicCandidates;
                    trace.Add("FocusWeakTopic:" + weakestTopic.Value);
                }
                else
                {
                    trace.Add("WeakTopicHadNoCandidates");
                }
            }
            else
            {
                trace.Add("SkipWeakTopicFocus");
            }

            if (candidates.Count == 0)
            {
                trace.Add("NoCandidatesAfterTopicPhase");
                return new SelectionResult
                {
                    SelectedQuestion = null,
                    ReasonString = "No more questions available.",
                    RulesFired = trace
                };
            }

            List<Question> preferred = candidates;

            if (_preferredDifficulty.HasValue)
            {
                var byDifficulty = candidates.Where(q => q.Metadata.Difficulty == _preferredDifficulty.Value).ToList();
                if (byDifficulty.Count > 0)
                {
                    preferred = byDifficulty;
                    trace.Add("TargetDifficulty:" + _preferredDifficulty.Value);
                }
                else
                {
                    trace.Add("FallbackDifficulty");
                }
            }
            else
            {
                trace.Add("NoDifficultyPreference");
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