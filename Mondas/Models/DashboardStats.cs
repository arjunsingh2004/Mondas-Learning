using System;
using System.Collections.Generic;

namespace Mondas.Models
{
    public sealed class DashboardStats
    {
        public long UserId { get; set; }
        public string UserKey { get; set; } = "local";
        public string FullName { get; set; } = "USER";

        public int TotalAttempts { get; set; }
        public int CorrectAttempts { get; set; }
        public double Accuracy01 => TotalAttempts <= 0 ? 0.0 : (double)CorrectAttempts / TotalAttempts;

        public double AvgSeconds { get; set; }
        public int CurrentStreak { get; set; }
        public int TotalMistakes => Math.Max(0, TotalAttempts - CorrectAttempts);

        public Topic? WeakestTopic { get; set; }
        public double WeakestAccuracy01 { get; set; }
        public Topic? StrongestTopic { get; set; }
        public double StrongestAccuracy01 { get; set; }

        public List<TopicMasteryRow> MasteryByTopic { get; } = new List<TopicMasteryRow>();
        public List<MisconceptionRow> TopMisconceptions { get; } = new List<MisconceptionRow>();
    }

    public sealed class TopicMasteryRow
    {
        public Topic Topic { get; set; }
        public int Seen { get; set; }
        public int Correct { get; set; }
        public double MasteryScoreTotal { get; set; }
        public double Accuracy01
        {
            get
            {
                if (Seen <= 0)
                {
                    return 0.0;
                }

                var score = MasteryScoreTotal > 0.0 || Correct > 0 ? (MasteryScoreTotal > 0.0 ? MasteryScoreTotal : Correct) : 0.0;

                return score / Seen; 
            }
        }
    }

    public sealed class MisconceptionRow
    {
        public string Tag { get; set; } = "";
        public int Count { get; set; }
        public DateTime LastSeenUtc { get; set; }
    }
}