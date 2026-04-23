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
        private readonly bool _allowDifficultyDrift;

        public RuleEngineV1(bool focusWeakTopic = true, DifficultyBand? preferredDifficulty = DifficultyBand.Medium, bool allowDifficultyDrift = true)
        {
            _focusWeakTopic = focusWeakTopic;
            _preferredDifficulty = preferredDifficulty;
            _allowDifficultyDrift = allowDifficultyDrift;
        }

        public SelectionResult SelectNextQuestion(UserModel userModel, IReadOnlyList<Question> allQuestions, IReadOnlyList<QuestionAttempt> previousAttempts)
        {
            if (userModel == null)
            {
                userModel = new UserModel();
            }

            if (allQuestions == null || allQuestions.Count == 0)
            {
                return new SelectionResult{ SelectedQuestion = null, ReasonString = "No questions available.", RulesFired = new List<string> { "NoQuestionsAvailable" } };
            }

            if (previousAttempts == null)
            {
                previousAttempts = Array.Empty<QuestionAttempt>();
            }

            var trace = new List<string>();

            var alreadySeen = new HashSet<int>(previousAttempts.Select(a => a.QuestionId));
            var candidates = allQuestions.Where(q => !alreadySeen.Contains(q.Id)).ToList();
            trace.Add("AvoidSeenInSession");
            

            if (candidates.Count == 0)
            {
                trace.Add("NoCandidatesAfterAvoidSeen");
                return new SelectionResult { SelectedQuestion = null, ReasonString = "No more questions available.", RulesFired = trace };
            }

            var topicMastery = BuildTopicMasteryMap(userModel, candidates);
            Topic? weakestTopic = null;
            double weakestMastery = double.MaxValue;

            foreach (var kv in topicMastery)
            {
                if (kv.Value < weakestMastery)
                {
                    weakestMastery = kv.Value;
                    weakestTopic = kv.Key;
                }
            }

            DifficultyBand? targetDifficulty = _preferredDifficulty;

            if (_preferredDifficulty.HasValue && _allowDifficultyDrift)
            {
                var drift = ComputeDifficultyDrift(previousAttempts);
                if (drift != 0)
                {
                    targetDifficulty = ShiftDifficulty(_preferredDifficulty.Value, drift);
                    trace.Add("DifficultyDrift:" + drift);
                }
            }

            if (_focusWeakTopic)
            {
                trace.Add(weakestTopic.HasValue ? "PreferWeakTopic:" + weakestTopic.Value : "PreferWeakTopic:None");
            }

            else
            {
                trace.Add("SkipWeakTopicPreference");
            }

            if (targetDifficulty.HasValue)
            {
                trace.Add("TargetDifficulty:" + targetDifficulty.Value);
            }

            else
            {
                trace.Add("NoDifficultyPreference");
            }

            var weighted = new List<(Question q, double w)>(candidates.Count);

            foreach (var q in candidates)
            {
                double w = 1.0;

                if (_focusWeakTopic)
                {
                    var mastery = topicMastery.TryGetValue(q.Metadata.Topic, out var m) ? m : 0.0;
                    var weakness = 1.0 - mastery;

                    w *= 0.35 + (0.65 * weakness);
                }

                if (targetDifficulty.HasValue)
                {
                    var dist = DifficultyDistance(q.Metadata.Difficulty, targetDifficulty.Value);
                    w *= dist == 0 ? 1.0 : dist == 1 ? 0.65 : 0.35;
                }

                w *= 0.90 + (_random.NextDouble() * 0.20);

                weighted.Add((q, w));
            }

            var selected = PickWeighted(weighted);
            var reason = BuildReasonString(selected, weakestTopic, weakestMastery, targetDifficulty);

            return new SelectionResult{ SelectedQuestion = selected, ReasonString = reason, RulesFired = trace };
        }

        private static Dictionary<Topic, double> BuildTopicMasteryMap(UserModel userModel, List<Question> candidates)
        {
            var topics = candidates.Select(q => q.Metadata.Topic).Where(t => t != Topic.Other).Distinct().ToList();

            var map = new Dictionary<Topic, double>();

            foreach (var t in topics)
            {
                map[t] = GetMastery01(userModel, t);
            }

            if (map.Count == 0)
            {
                map[Topic.Other] = 0.0;
            }

            return map;
        }

        private static double GetMastery01(UserModel userModel, Topic topic)
        {
            if (userModel == null)
            {
                return 0.0;
            }

            userModel.TopicStats.TryGetValue(topic, out var stats);

            var mastery = stats == null ? 0.0 : stats.Mastery;

            if (mastery > 1.0)
            {
                mastery /= 100.0;
            }

            if (mastery < 0.0)
            {
                mastery = 0.0;
            }

            if (mastery > 1.0)
            {
                mastery = 1.0;
            }

            return mastery;
        }

        private static int ComputeDifficultyDrift(IReadOnlyList<QuestionAttempt> attempts)
        {
            if (attempts == null || attempts.Count < 2)
            {
                return 0;
            }

            var recent = attempts.OrderByDescending(a => a.SubmittedAt).Take(4).ToList();

            int correctStreak = 0;
            int incorrectStreak = 0;

            foreach (var a in recent)
            {
                if (a.IsCorrect)
                {
                    if (incorrectStreak > 0)
                    {
                        break;
                    }

                    correctStreak++;
                }

                else
                {
                    if (correctStreak > 0)
                    {
                        break;
                    }

                    incorrectStreak++;
                }
            }

            if (incorrectStreak >= 2)
            {
                return -1;
            }

            if (correctStreak >= 3)
            {
                return +1;
            }

            return 0;
        }

        private static int DifficultyDistance(DifficultyBand a, DifficultyBand b)
        {
            var order = Enum.GetValues(typeof(DifficultyBand)).Cast<DifficultyBand>().OrderBy(x => (int)x).ToArray();

            int ia = Array.IndexOf(order, a);
            int ib = Array.IndexOf(order, b);

            if (ia < 0 || ib < 0)
            {
                return 0;
            }

            return Math.Abs(ia - ib);
        }

        private static DifficultyBand ShiftDifficulty(DifficultyBand start, int delta)
        {
            var order = Enum.GetValues(typeof(DifficultyBand)).Cast<DifficultyBand>().OrderBy(x => (int)x).ToArray();

            int idx = Array.IndexOf(order, start);

            if (idx < 0)
            {
                return start;
            }

            idx += delta;

            if (idx < 0)
            {
                idx = 0;
            }

            if (idx >= order.Length)
            {
                idx = order.Length - 1;
            }

            return order[idx];
        }

        private Question PickWeighted(List<(Question q, double w)> items)
        {
            double total = 0.0;

            for (int i = 0; i < items.Count; i++)
            {
                var w = items[i].w;
                if (w > 0.0) total += w;
            }

            if (total <= 0.0)
            {
                return items[_random.Next(items.Count)].q;
            }

            var roll = _random.NextDouble() * total;

            for (int i = 0; i < items.Count; i++)
            {
                var w = items[i].w;
                if (w <= 0.0) continue;

                roll -= w;
                if (roll <= 0.0)
                {
                    return items[i].q;
                }
            }

            return items[items.Count - 1].q;
        }

        private static string BuildReasonString(Question q, Topic? weakestTopic, double weakestMastery, DifficultyBand? targetDifficulty)
        {
            var parts = new List<string>();

            if (weakestTopic.HasValue && q.Metadata.Topic == weakestTopic.Value)
            {
                parts.Add("Focusing on " + weakestTopic.Value + " (mastery " + weakestMastery.ToString("P0") + ")");
            }

            if (targetDifficulty.HasValue)
            {
                parts.Add("Aiming for " + targetDifficulty.Value + " difficulty");
            }

            if (parts.Count == 0)
            {
                parts.Add("Picking a question to keep variety");
            }

            return string.Join(". ", parts) + ".";
        }
    }
}