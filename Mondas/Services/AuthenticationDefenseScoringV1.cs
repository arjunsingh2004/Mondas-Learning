using System;
using System.Collections.Generic;
using Mondas.Models;

namespace Mondas.Services
{
    public sealed class AuthenticationDefenseScoringV1
    {
        public AuthenticationDefenseResult Evaluate(AuthenticationDefenseScenario scenario, AuthenticationDefenseSelection selection, double secondsTaken)
        {
            var result = new AuthenticationDefenseResult();

            if (scenario == null)
            {
                result.IsCorrect = false;
                result.ScoreDelta = -5;
                result.Accuracy01 = 0.0;
                result.Headline = "NO SCENARIO";
                result.Explanation = "No scenario has been loaded.";
                return result;
            }

            var findings = new List<AuthenticationDefenseFinding>();

            int checks = 0;
            int matched = 0;
            int bigMisses = 0;

            CompareDropdown("Auth method mismatch", selection.AuthMethod, scenario.RecommendedAuthMethod, "The sign-in method does not match what this threat needs.", FindingImpactType.High);
            CompareDropdown("Password policy mismatch", selection.PasswordPolicy, scenario.RecommendedPasswordPolicy, "The password policy is too weak for this attack path.", FindingImpactType.Medium);
            CompareDropdown("Recovery path mismatch", selection.Recovery, scenario.RecommendedRecovery, "The recovery flow could be abused if the attacker pivots through account recovery.", FindingImpactType.High);
            CompareDropdown("Monitoring gap", selection.Monitoring, scenario.RecommendedMonitoring, "The monitoring level is too weak to catch this attack quickly.", FindingImpactType.Medium);
            CompareDropdown("Rate limiting gap", selection.RateLimit, scenario.RecommendedRateLimit, "The rate limiting choice is not strong enough for this scenario.", FindingImpactType.Medium);
            CompareDropdown("Session control gap", selection.SessionControl, scenario.RecommendedSessionControl, "The session control does not properly contain this threat.", FindingImpactType.Medium);

            ToggleNeeded("MFA missing", selection.RequireMfa, scenario.RequireMfa, "This scenario needs MFA to stop single-factor compromise.", FindingImpactType.High);
            ToggleNeeded("Phishing-resistant MFA missing", selection.RequirePhishingResistant, scenario.RequirePhishingResistant, "Standard MFA is not strong enough here; phishing-resistant MFA is needed.", FindingImpactType.High);
            ToggleNeeded("Device binding missing", selection.RequireDeviceBinding, scenario.RequireDeviceBinding, "This attack is safer to contain with device-bound access.", FindingImpactType.Medium);
            ToggleNeeded("Risk-based step-up missing", selection.RequireRiskBasedStepUp, scenario.RequireRiskBasedStepUp, "The flow should re-check identity when risk increases.", FindingImpactType.Medium);
            ToggleNeeded("Legacy auth still allowed", selection.RequireBlockLegacyAuth, scenario.RequireBlockLegacyAuth, "Legacy authentication paths stay open to bypasses.", FindingImpactType.High);
            ToggleNeeded("Alerting missing", selection.RequireAlertOnSuspicious, scenario.RequireAlertOnSuspicious, "Suspicious behaviour should trigger an alert in this scenario.", FindingImpactType.Medium);
        
            if (findings.Count == 0)
            {
                findings.Add(new AuthenticationDefenseFinding { Title = "Strong coverage", Detail = "This build covers the main attack path cleanly.", Impact = FindingImpactType.Low });
            }

            var accuracy = checks <= 0 ? 0.0 : (double)matched / checks;
            var timePenalty = CalcTimePenalty(secondsTaken, scenario.Difficulty);
            var timePenaltyPoints = (int)Math.Round(Math.Min(3.0, timePenalty));

            result.Accuracy01 = accuracy;
            result.TimePenaltySeconds = timePenalty;
            result.Findings = findings;

            var nearMiss = accuracy >= 0.50 && bigMisses <= 1;
            result.IsCorrect = bigMisses == 0 && accuracy >= 0.65;

            if (result.IsCorrect)
            {
                result.ScoreDelta = Math.Max(4, 8 + (int)Math.Round(accuracy * 4.0) - timePenaltyPoints);
                result.Headline = accuracy >= 0.85 ? "STRONG DEFENSE" : "DEFENSE HOLDS";
                result.Explanation = "Your setup blocks the main attack route and applies the right controls for this scenario.";
            }

            else if (nearMiss)
            {

                result.ScoreDelta = Math.Min(-1, -2 - timePenaltyPoints);
                result.Headline = "PARTIAL COVERAGE";
                result.Explanation = "You got some important controls right, but one or two gaps still leave this scenario exposed.";
            }

            else
            {
                result.ScoreDelta = Math.Min(-3, -4 - bigMisses - timePenaltyPoints);
                result.Headline = "DEFENSE GAPS FOUND";
                result.Explanation = FailureExplanation(scenario, findings);
            }

            return result;

            void CompareDropdown<T>(string title, T chosen, T expected, string detail, FindingImpactType impact) where T : struct, Enum
            {
                checks++;

                if (EqualityComparer<T>.Default.Equals(chosen, expected))
                {
                    matched++;
                    return;
                }

                findings.Add(new AuthenticationDefenseFinding { Title = title, Detail = detail + " Recommended: " + ToUiText(expected) + ".", Impact = impact });

                if (impact == FindingImpactType.High)
                {
                    bigMisses++;
                }
            }

            void ToggleNeeded(string title, bool chosen, bool required, string detail, FindingImpactType impact)
            {
                if (!required)
                {
                    return;
                }

                checks++;

                if (chosen)
                {
                    matched++;
                    return;
                }

                findings.Add(new AuthenticationDefenseFinding { Title = title, Detail = detail, Impact = impact });

                if (impact == FindingImpactType.High)
                {
                    bigMisses++;
                }
            }
        }

        private static double CalcTimePenalty(double secondsTaken, DifficultyBand difficulty)
        {
            if (secondsTaken <= 0)
            {
                return 0.0;
            }

            var softCap = difficulty == DifficultyBand.Easy ? 20.0 : difficulty == DifficultyBand.Medium ? 30.0 : 45.0;
            var over = secondsTaken - softCap;

            if (over <= 0)
            {
                return 0.0;
            }

            return over / 10.0;
        }

        private static string FailureExplanation(AuthenticationDefenseScenario scenario, List<AuthenticationDefenseFinding> findings)
        {
            if (findings == null || findings.Count == 0)
            {
                return "The build does not cover the scenario strongly enough.";
            }

            var first = findings[0].Title;
            var second = findings.Count > 1 ? " " + findings[1].Title + "." : "";

            return "Main issue: " + first + "." + second + " Tighten the controls around " + ToUiText(scenario.ThreatType) + " and " + ToUiText(scenario.GoalType) + ".";
        }

        private static string ToUiText(Enum value)
        {
            var raw = value.ToString();

            if (string.IsNullOrWhiteSpace(raw))
            {
                return "";
            }

            var chars = new List<char>(raw.Length + 8);

            for (int i = 0; i < raw.Length; i++)
            {
                var c = raw[i];

                if (i > 0 && char.IsUpper(c) && !char.IsUpper(raw[i - 1]))
                {
                    chars.Add(' ');
                }

                chars.Add(c);
            }

            return new string(chars.ToArray()).ToUpperInvariant();
        }
    }
}