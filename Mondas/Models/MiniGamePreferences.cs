using System;

namespace Mondas.Models
{
    public enum MiniGameType
    {
        PhishingSimulator = 1,
        PasswordWorkshop = 2
    }

    public enum MiniGameHintMode
    {
        Off = 0,
        Basic = 1,
        Full = 2
    }

    public enum MiniGameFeedbackMode
    {
        Instant = 0,
        EndOfRound = 1
    }

    public sealed class MiniGamePreferences
    {
        public MiniGameType GameType { get; set; } = MiniGameType.PhishingSimulator;
        public bool UseDefaults { get; set; } = true;
        public int RoundCount { get; set; } = 10;
        public bool TimerEnabled { get; set; }
        public DifficultyBand? Difficulty { get; set; } = DifficultyBand.Medium;
        public int PhishingEmailCount { get; set; } = 10;
        public bool IncludeAttachments { get; set; } = true;
        public bool IncludeLinks { get; set; } = true;
        public bool IncludeUrgency { get; set; } = true;
        public bool IncludeStrength { get; set; } = true;
        public bool IncludeReuse { get; set; } = true;
        public bool IncludeManager { get; set; } = true;
        public bool IncludePatterns { get; set; } = true;

        public MiniGameHintMode HintMode { get; set; } = MiniGameHintMode.Basic;
        public MiniGameFeedbackMode FeedbackMode { get; set; } = MiniGameFeedbackMode.Instant;
    
        public static MiniGamePreferences CreateDefault(MiniGameType gameType)
        {
            return new MiniGamePreferences
            { 
                GameType = gameType,
                UseDefaults = true,
                RoundCount = 10,
                TimerEnabled = false,
                Difficulty = DifficultyBand.Medium,
                PhishingEmailCount = 10,
                IncludeAttachments = true,
                IncludeLinks = true,
                IncludeUrgency = true,
                IncludeStrength = true,
                IncludeReuse = true,
                IncludeManager = true,
                IncludePatterns = true,
                HintMode = MiniGameHintMode.Basic,
                FeedbackMode = MiniGameFeedbackMode.Instant
            };
        }

        public static MiniGamePreferences Normalise(MiniGamePreferences prefs)
        {
            prefs ??= CreateDefault(MiniGameType.PhishingSimulator);

            if (prefs.RoundCount <= 0)
            {
                prefs.RoundCount = 10;
            }

            if (prefs.PhishingEmailCount <= 0)
            {
                prefs.PhishingEmailCount = prefs.RoundCount;
            }

            if (!prefs.Difficulty.HasValue)
            {
                prefs.Difficulty = DifficultyBand.Medium;
            }

            return prefs;
        }
    }
}