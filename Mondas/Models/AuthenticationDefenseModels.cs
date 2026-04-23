using System;
using System.Collections.Generic;

namespace Mondas.Models
{
    public enum AuthThreatType
    {
        CredentialStuffing,
        PasswordSpraying,
        MfaFatigue,
        HelpdeskTakeover,
        SessionHijack,
        TokenReplay,
        LegacyProtocolAbuse
    }

    public enum AuthGoalType
    {
        ProtectUserSignIn,
        ProtectAdminSignIn,
        ProtectPasswordReset,
        ProtectRemoteAccess,
        ProtectHighRiskAction
    }

    public enum AuthMethodType
    {
        PasswordAndOtp,
        PasswordAndPush,
        Passkey,
        SecurityKey,
        PasswordOnly
    }

    public enum PasswordPolicyType
    {
        StrongUnique,
        Passphrase,
        PasswordManagerRequired,
        Basic
    }

    public enum RecoveryType
    {
        BackupCodes,
        VerifiedRecoveryDesk,
        AdminApproval,
        EmailReset,
        SmsReset
    }

    public enum MonitoringType
    {
        BasicLogs,
        RiskDetection,
        RealTimeAlerts,
        FullAudit,
        None
    }

    public enum RateLimitType
    {
        BasicLockout,
        SmartThrottle,
        UserAndIpThrottle,
        None
    }

    public enum SessionControlType
    {
        Basic,
        ShortSession,
        ReauthOnRisk,
        DeviceBound
    }

    public enum FindingImpactType
    {
        Low,
        Medium,
        High
    }

    public sealed class AuthenticationDefenseScenario
    {
        public string Id { get; set; } = "";
        public string Title { get; set; } = "";
        public AuthThreatType ThreatType { get; set; } = AuthThreatType.CredentialStuffing;
        public AuthGoalType GoalType { get; set; } = AuthGoalType.ProtectUserSignIn;
        public DifficultyBand Difficulty { get; set; } = DifficultyBand.Medium;
        public string Body { get; set; } = "";
        public List<string> Hints { get; set; } = new List<string>();
        public List<string> Tags { get; set; } = new List<string>();
        public AuthMethodType RecommendedAuthMethod { get; set; } = AuthMethodType.PasswordAndOtp;
        public PasswordPolicyType RecommendedPasswordPolicy { get; set; } = PasswordPolicyType.StrongUnique;
        public RecoveryType RecommendedRecovery { get; set; } = RecoveryType.BackupCodes;
        public MonitoringType RecommendedMonitoring { get; set; } = MonitoringType.BasicLogs;
        public RateLimitType RecommendedRateLimit { get; set; } = RateLimitType.BasicLockout;
        public SessionControlType RecommendedSessionControl { get; set; } = SessionControlType.Basic;
        public bool RequireMfa { get; set; }
        public bool RequirePhishingResistant { get; set; }
        public bool RequireDeviceBinding { get; set; }
        public bool RequireRiskBasedStepUp { get; set; }
        public bool RequireBlockLegacyAuth { get; set; }
        public bool RequireAlertOnSuspicious { get; set; }
    }

    public sealed class AuthenticationDefenseSelection
    {
        public AuthMethodType AuthMethod { get; set; } = AuthMethodType.PasswordAndOtp;
        public PasswordPolicyType PasswordPolicy { get; set; } = PasswordPolicyType.StrongUnique;
        public RecoveryType Recovery { get; set; } = RecoveryType.BackupCodes;
        public MonitoringType Monitoring { get; set; } = MonitoringType.BasicLogs;
        public RateLimitType RateLimit { get; set; } = RateLimitType.BasicLockout;
        public SessionControlType SessionControl { get; set; } = SessionControlType.Basic;

        public bool RequireMfa { get; set; }
        public bool RequirePhishingResistant { get; set; }
        public bool RequireDeviceBinding { get; set; }
        public bool RequireRiskBasedStepUp { get; set; }
        public bool RequireBlockLegacyAuth { get; set; }
        public bool RequireAlertOnSuspicious { get; set; }
    }

    public sealed class AuthenticationDefenseFinding
    {
        public string Title { get; set; } = "";
        public string Detail { get; set; } = "";
        public FindingImpactType Impact { get; set; } = FindingImpactType.Low;
    }

    public sealed class AuthenticationDefenseResult
    {
        public bool IsCorrect { get; set; }
        public int ScoreDelta { get; set; }
        public double Accuracy01 { get; set; }
        public double TimePenaltySeconds { get; set; }
        public string Headline { get; set; } = "";
        public string Explanation { get; set; } = "";
        public List<AuthenticationDefenseFinding> Findings { get; set; } = new List<AuthenticationDefenseFinding>();
    }

    public sealed class AuthenticationDefenseAttemptRow
    {
        public long Id { get; set; }
        public string UserKey { get; set; } = "local";
        public string ScenarioId { get; set; } = "";
        public bool IsCorrect { get; set; }
        public int ScoreDelta { get; set; }
        public double SecondsTaken { get; set; }
        public double? Accuracy01 { get; set; }
        public DateTime SubmittedUtc { get; set; }
        public string TagsJson { get; set; } = "[]";
        public string FindingsJson { get; set; } = "[]";
        public string ScenarioSnapshotJson { get; set; } = "{}";
    }
}