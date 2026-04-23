using System;
using System.Collections.Generic;
using System.Linq;
using Mondas.Models;

namespace Mondas.Services
{
    public sealed class PhishingEngineV1
    {
        private readonly Random _rng = new Random();
        private readonly bool _focusWeakTags;
        private readonly DifficultyBand? _preferredDifficulty;
        private readonly bool _allowDifficultyDrift;

        public PhishingEngineV1(bool focusWeakTags = true, DifficultyBand? preferredDifficulty = DifficultyBand.Medium, bool allowDifficultyDrift = true)
        {
            _focusWeakTags = focusWeakTags;
            _preferredDifficulty = preferredDifficulty;
            _allowDifficultyDrift = allowDifficultyDrift;
        }

        public (PhishingEmail email, string reason, List<string> rulesFired) PickNext(IReadOnlyList<PhishingEmail> allEmails, IReadOnlyList<PhishingAttemptRow> history, HashSet<int> seenThisRun, Func<string, double> tagMastery)
        {
            var trace = new List<string>();
            var candidates = allEmails.Where(e => e != null).Where(e => seenThisRun == null || !seenThisRun.Contains(e.Id)).ToList();

            trace.Add("AvoidSeenInSession");

            if (candidates.Count == 0)
            {
                trace.Add("NoCandidatesAfterAvoidSeen");
                return (null, "No more emails available in this run.", trace);
            }

            var weakestTag = "";
            var weakestMastery = double.MaxValue;

            if (_focusWeakTags)
            {
                var tagPool = new HashSet<string>(StringComparer.OrdinalIgnoreCase);

                for (int i = 0; i < candidates.Count; i++)
                {
                    var tags = candidates[i].Tags ?? new List<string>();

                    if (tags.Count == 0)
                    {
                        tagPool.Add("general");
                        continue;
                    }

                    for (int j = 0; j < tags.Count; j++)
                    {
                        var t = (tags[j] ?? "").Trim();

                        if (t.Length == 0)
                        {
                            continue;
                        }

                        tagPool.Add(t);
                    }
                }
            
                foreach (var t in tagPool)
                {
                    var m = tagMastery == null ? 0.0 : tagMastery(t);

                    if (m < weakestMastery)
                    {
                        weakestMastery = m;
                        weakestTag = t;
                    }
                }
            
                trace.Add(weakestTag.Length > 0 ? "PreferWeakTag:" + weakestTag : "PreferWeakTag:None");
            }

            else
            {
                trace.Add("SkipWeakTagPreference");
            }

            var targetDifficulty = _preferredDifficulty;

            if (_preferredDifficulty.HasValue && _allowDifficultyDrift)
            {
                var drift = GetDifficultyDrift(history);

                if (drift != 0)
                {
                    targetDifficulty = ShiftDifficulty(_preferredDifficulty.Value, drift);
                    trace.Add("DifficultyDrift:" + drift);
                }
            }

            if (targetDifficulty.HasValue)
            {
                trace.Add("TargetDifficulty:" + targetDifficulty.Value);
            }

            else
            {
                trace.Add("NoDifficultyPreference");
            }

            var weighted = new List<(PhishingEmail e, double w)>(candidates.Count);

            for (int i = 0; i < candidates.Count; i++)
            {
                var e = candidates[i];
                double w = 1.0;

                var tags = e.Tags ?? new List<string>();

                if (tags.Count == 0)
                {
                    tags = new List<string> { "general" };
                }

                if (_focusWeakTags && weakestTag.Length > 0)
                {
                    var m = tagMastery == null ? 0.0 : tagMastery(weakestTag);
                    var weakness = 1.0 - Clamp(m);

                    var has = tags.Any(t => string.Equals(t, weakestTag, StringComparison.OrdinalIgnoreCase));
                    w *= has ? (0.55 + 0.85 * weakness) : (0.35 + 0.50 * weakness);
                }

                if (targetDifficulty.HasValue)
                {
                    var dist = DifficultyDistance(e.Difficulty, targetDifficulty.Value);
                    w *= dist == 0 ? 1.0 : dist == 1 ? 0.70 : 0.45;
                }

                w *= 0.90 + (_rng.NextDouble() * 0.20);
                weighted.Add((e, w));
            }

            var chosen = PickWeighted(weighted);

            var reasonParts = new List<string>();

            if (_focusWeakTags && weakestTag.Length > 0)
            {
                reasonParts.Add("Focusing on '" + weakestTag + "' (mastery " + Clamp(weakestMastery).ToString("P0") + ").");
            }

            if (targetDifficulty.HasValue)
            {
                reasonParts.Add("Aiming for " + targetDifficulty.Value + " difficulty.");
            }

            if (reasonParts.Count == 0)
            {
                reasonParts.Add("Picking an email for variety purposes.");
            }

            return (chosen, string.Join(". ", reasonParts) + ".", trace);
        }

        private PhishingEmail PickWeighted(List<(PhishingEmail e, double w)> items)
        {
            double total = 0.0;

            for (int i = 0; i < items.Count; i++)
            {
                var w = items[i].w;

                if (w > 0.0)
                {
                    total += w;
                }
            }

            if (total <= 0.0)
            {
                return items[_rng.Next(items.Count)].e;
            }

            var roll = _rng.NextDouble() * total;

            for (int i = 0; i < items.Count; i++)
            {
                var w = items[i].w;
                if (w <= 0.0) continue;

                roll -= w;
                if (roll <= 0.0)
                {
                    return items[i].e;
                }
            }

            return items[items.Count - 1].e;
        }

        private static int GetDifficultyDrift(IReadOnlyList<PhishingAttemptRow> attempts)
        {
            if (attempts == null || attempts.Count < 2)
            {
                return 0;
            }

            var recent = attempts.OrderByDescending(a => a.SubmittedUtc).Take(5).ToList();

            int correctStreak = 0;
            int incorrectStreak = 0;

            for (int i = 0; i < recent.Count; i++)
            {
                if (recent[i].IsCorrect)
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
            var order = new[] { DifficultyBand.Easy, DifficultyBand.Medium, DifficultyBand.Hard };

            int ia = Array.IndexOf(order, a);
            int ib = Array.IndexOf(order, b);

            if (ia < 0 || ib < 0)
            {
                return 0;
            }

            return Math.Abs(ia -  ib);
        }

        private static DifficultyBand ShiftDifficulty(DifficultyBand start, int delta)
        {
            var order = new[] { DifficultyBand.Easy, DifficultyBand.Medium, DifficultyBand.Hard };
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

        private static double Clamp(double value)
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