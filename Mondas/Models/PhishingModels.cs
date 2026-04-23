using System;
using System.Collections.Generic;

namespace Mondas.Models
{
    public enum PhishingAction
    {
        TrustKeep = 1,
        ReportPhishing = 2,
        OpenLink = 3,
        OpenAttachment = 4
    }

    public sealed class PhishingLink
    {
        public string DisplayText { get; set; } = "";
        public string Url { get; set; } = "";
    }

    public sealed class PhishingAttachment
    {
        public string FileName { get; set; } = "";
    }

    public sealed class PhishingEmail
    {
        public int Id { get; set; }
        public DifficultyBand Difficulty { get; set; } = DifficultyBand.Medium;
        public string SenderName { get; set; } = "";
        public string SenderEmail { get; set; } = "";
        public string ToEmail { get; set; } = "";
        public string Subject { get; set; } = "";
        public string Body { get; set; } = "";
        public string ReplyToEmail { get; set; } = "";
        public PhishingLink Link { get; set; } = new PhishingLink();
        public PhishingAttachment Attachment { get; set; } = new PhishingAttachment();
        public bool IsPhishing { get; set; }
        public string Explanation { get; set; } = "";
        public List<string> Tags { get; set; } = new List<string>();
        public bool HasLink => Link != null && !string.IsNullOrWhiteSpace(Link.Url);
        public bool HasAttachment => Attachment != null && !string.IsNullOrWhiteSpace(Attachment.FileName);
    }

    public sealed class PhishingSignal
    {
        public string Title { get; set; } = "";
        public string Detail { get; set; } = "";
        public int Weight { get; set; }
    }

    public sealed class PhishingDecisionResult
    {
        public PhishingAction Action { get; set; }
        public bool IsCorrect { get; set; }
        public int ScoreDelta { get; set; }
        public double TimePenaltySeconds { get; set; }
        public string Headline { get; set; } = "";
        public string Explanation { get; set; } = "";
        public List<PhishingSignal> Signals { get; set; } = new List<PhishingSignal>();
        public List<string> RulesFired { get; set; } = new List<string>();
        public string ReasonString { get; set; } = "";
    }

    public sealed class PhishingAttemptRow
    {
        public long Id { get; set; }
        public string UserKey { get; set; } = "local";
        public string EmailId { get; set; } = "";
        public int Action { get; set; }
        public bool IsCorrect { get; set; }
        public int ScoreDelta { get; set; }
        public double SecondsTaken { get; set; }
        public DateTime SubmittedUtc { get; set; }
        public string ReasonString { get; set; } = "";
        public string SignalsJson { get; set; } = "[]";
        public string EmailSnapshotJson { get; set; } = "{}";
    }
}