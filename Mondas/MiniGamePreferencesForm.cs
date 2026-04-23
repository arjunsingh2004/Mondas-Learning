using Mondas.Models;
using Syncfusion.WinForms.Controls;
using Syncfusion.WinForms.Input.Styles;
using System;
using System.Linq;
using System.Windows.Forms;

namespace Mondas
{
    public partial class MiniGamePreferencesForm : SfForm
    {
        private bool _loading;
        private readonly bool _lockGameType;
        private readonly MiniGameType _lockedGameType;

        public MiniGamePreferences Preferences
        {
            get;
            private set;
        }

        public MiniGamePreferencesForm() : this(MiniGamePreferences.CreateDefault(MiniGameType.PhishingSimulator), false)
        {

        }

        public MiniGamePreferencesForm(MiniGamePreferences initial) : this(initial, false)
        {

        }

        public MiniGamePreferencesForm(MiniGamePreferences initial, bool lockGameType)
        {
            InitializeComponent();
            var safe = MiniGamePreferences.Normalise(initial);
            Preferences = Clone(safe);
            _lockGameType = lockGameType;
            _lockedGameType = safe.GameType;
        }

        private void MiniGamePreferencesForm_Load(object sender, EventArgs e)
        {
            FillUiLists();

            if (_lockGameType && cmbMiniGameType != null)
            {
                cmbMiniGameType.Enabled = false;
            }

            ApplyToUi(Preferences);
            ApplyMode(Preferences.UseDefaults);
            UpdateSummary();
        }

        private void FillUiLists()
        {
            cmbMiniGameType.Items.Clear();
            cmbMiniGameType.Items.AddRange(new object[] { "Phishing Simulator", "Authentication Defense" });

            cmbRoundCount.Items.Clear();
            cmbRoundCount.Items.AddRange(new object[] { 5, 10, 15, 20 });

            cmbTimer.Items.Clear();
            cmbTimer.Items.AddRange(new object[] { "Off", "On" });

            cmbDifficulty.Items.Clear();
            cmbDifficulty.Items.Add("Any");
            cmbDifficulty.Items.AddRange(Enum.GetNames(typeof(DifficultyBand)));

            cmbEmailCount.Items.Clear();
            cmbEmailCount.Items.AddRange(new object[] { 5, 10, 15, 20 });

            cmbHints.Items.Clear();
            cmbHints.Items.AddRange(new object[] { "Off", "Basic", "Full" });

            cmbFeedbackMode.Items.Clear();
            cmbFeedbackMode.Items.AddRange(new object[] { "Instant", "End Of Round" });
        }

        private void ApplyToUi(MiniGamePreferences prefs)
        {
            _loading = true;
            prefs = MiniGamePreferences.Normalise(prefs);

            var gameType = _lockGameType ? _lockedGameType : prefs.GameType;

            cmbMiniGameType.SelectedItem = gameType == MiniGameType.AuthenticationDefense ? "Authentication Defense" : "Phishing Simulator";

            rbDefault.Checked = prefs.UseDefaults;
            rbCustom.Checked = !prefs.UseDefaults;

            cmbRoundCount.SelectedItem = FindOrFallback(cmbRoundCount, prefs.RoundCount, 10);
            cmbTimer.SelectedItem = prefs.TimerEnabled ? "On" : "Off";
            cmbDifficulty.SelectedItem = prefs.Difficulty.HasValue ? prefs.Difficulty.Value.ToString() : "Any";

            cmbEmailCount.SelectedItem = FindOrFallback(cmbEmailCount, prefs.PhishingEmailCount, 10);
            chkIncludeAttachments.Checked = prefs.IncludeAttachments;
            chkIncludeLinks.Checked = prefs.IncludeLinks;
            chkIncludeUrgency.Checked = prefs.IncludeUrgency;

            chkIncludeCredentialAttacks.Checked = prefs.IncludeStrength;
            chkIncludeMfaScenarios.Checked = prefs.IncludeReuse;
            chkIncludeRecoveryScenarios.Checked = prefs.IncludeManager;
            chkIncludeSessionScenarios.Checked = prefs.IncludePatterns;

            cmbHints.SelectedItem = prefs.HintMode.ToString();
            cmbFeedbackMode.SelectedItem = prefs.FeedbackMode == MiniGameFeedbackMode.EndOfRound ? "End Of Round" : "Instant";

            ApplyGameSections();
            _loading = false;
        }

        private object FindOrFallback(ComboBox cmb, int value, int fallback)
        {
            return cmb.Items.Cast<object>().FirstOrDefault(x => Convert.ToInt32(x) == value) ?? fallback;
        }

        private void SwitchGameTemplate()
        {
            var gameType = ReadGameType();
            Preferences = MiniGamePreferences.CreateDefault(gameType);
            ApplyToUi(Preferences);
            ApplyMode(Preferences.UseDefaults);
            UpdateSummary();
        }

        private void ApplyMode(bool useDefaults)
        {
            gbBasics.Enabled = !useDefaults;
            gbPhishing.Enabled = !useDefaults && ReadGameType() == MiniGameType.PhishingSimulator;
            gbAuthentication.Enabled = !useDefaults && ReadGameType() == MiniGameType.AuthenticationDefense;
            gbAdvanced.Enabled = !useDefaults;
        }

        private void ApplyGameSections()
        {
            var isPhishing = ReadGameType() == MiniGameType.PhishingSimulator;

            gbPhishing.Visible = isPhishing;
            gbAuthentication.Visible = !isPhishing;
        }

        private MiniGameType ReadGameType()
        {
            if (_lockGameType)
            {
                return _lockedGameType;
            }

            var text = (cmbMiniGameType.SelectedItem?.ToString() ?? cmbMiniGameType.Text ?? "").Trim().ToUpperInvariant();
            
            return text.Contains("AUTHENTICATION") ? MiniGameType.AuthenticationDefense : MiniGameType.PhishingSimulator;
        }

        private MiniGamePreferences ReadFromUi()
        {
            var gameType = ReadGameType();

            if (rbDefault.Checked)
            {
                return MiniGamePreferences.CreateDefault(gameType);
            }

            var prefs = new MiniGamePreferences
            {
                GameType = gameType,
                UseDefaults = false,
                RoundCount = TryGetInt(cmbRoundCount.SelectedItem, 10),
                TimerEnabled = string.Equals(cmbTimer.Text, "On", StringComparison.OrdinalIgnoreCase),
                Difficulty = cmbDifficulty.Text == "Any" ? (DifficultyBand?)null : Enum.TryParse(cmbDifficulty.Text, out DifficultyBand d) ? d : (DifficultyBand?)null,
                PhishingEmailCount = TryGetInt(cmbEmailCount.SelectedItem, 10),
                IncludeAttachments = chkIncludeAttachments.Checked,
                IncludeLinks = chkIncludeLinks.Checked,
                IncludeUrgency = chkIncludeUrgency.Checked,
                IncludeStrength = chkIncludeCredentialAttacks.Checked,
                IncludeReuse = chkIncludeMfaScenarios.Checked,
                IncludeManager = chkIncludeRecoveryScenarios.Checked,
                IncludePatterns = chkIncludeSessionScenarios.Checked,
                HintMode = ParseHintMode(),
                FeedbackMode = ParseFeedbackMode()
            };

            return MiniGamePreferences.Normalise(prefs);
        }

        private int TryGetInt(object item, int fallback)
        {
            if (item == null)
            {
                return fallback;
            }

            if (item is int value)
            {
                return value;
            }

            return int.TryParse(item.ToString(), out var parsed) ? parsed : fallback;
        }

        private MiniGameHintMode ParseHintMode()
        {
            var text = (cmbHints.SelectedItem?.ToString() ?? cmbHints.Text ?? "").Trim().ToUpperInvariant();

            if (text.Contains("FULL"))
            {
                return MiniGameHintMode.Full;
            }

            if (text.Contains("BASIC"))
            {
                return MiniGameHintMode.Basic;
            }

            return MiniGameHintMode.Off;
        }

        private MiniGameFeedbackMode ParseFeedbackMode()
        {
            var text = (cmbFeedbackMode.SelectedItem?.ToString() ?? cmbFeedbackMode.Text ?? "").Trim().ToUpperInvariant();
            return text.Contains("END") ? MiniGameFeedbackMode.EndOfRound : MiniGameFeedbackMode.Instant;
        }

        private void UpdateSummary()
        {
            if (_loading || lblSummary == null)
            {
                return;
            }

            var prefs = ReadFromUi();

            if (prefs.GameType == MiniGameType.PhishingSimulator)
            {
                lblSummary.Text = $"GAME: PHISHING SIMULATOR · EMAILS: {prefs.PhishingEmailCount} · DIFFICULTY: {(prefs.Difficulty.HasValue ? prefs.Difficulty.Value.ToString().ToUpperInvariant() : "ANY")} · TIMER: {(prefs.TimerEnabled ? "ON" : "OFF")}\r\nFILTERS: LINKS {(prefs.IncludeLinks ? "ON" : "OFF")} · ATTACHMENTS {(prefs.IncludeAttachments ? "ON" : "OFF")} · URGENCY {(prefs.IncludeUrgency ? "ON" : "OFF")}\r\nHINTS: {prefs.HintMode.ToString().ToUpperInvariant()} · FEEDBACK: {(prefs.FeedbackMode == MiniGameFeedbackMode.Instant ? "INSTANT" : "END OF ROUND")}";
                return;
            }

            lblSummary.Text = $"GAME: AUTHENTICATION DEFENSE · ROUNDS: {prefs.RoundCount} · DIFFICULTY: {(prefs.Difficulty.HasValue ? prefs.Difficulty.Value.ToString().ToUpperInvariant() : "ANY")} · TIMER: {(prefs.TimerEnabled ? "ON" : "OFF")}\r\nSCENARIOS: CREDENTIAL ATTACKS {(prefs.IncludeStrength ? "ON" : "OFF")} · MFA/STEP-UP {(prefs.IncludeReuse ? "ON" : "OFF")} · RECOVERY/HELPDESK {(prefs.IncludeManager ? "ON" : "OFF")} · SESSION/LEGACY {(prefs.IncludePatterns ? "ON" : "OFF")}\r\nHINTS: {prefs.HintMode.ToString().ToUpperInvariant()} · FEEDBACK: {(prefs.FeedbackMode == MiniGameFeedbackMode.Instant ? "INSTANT" : "END OF ROUND")}";
        }

        private static MiniGamePreferences Clone(MiniGamePreferences prefs)
        {
            prefs = MiniGamePreferences.Normalise(prefs);

            return new MiniGamePreferences
            {
                GameType = prefs.GameType,
                UseDefaults = prefs.UseDefaults,
                RoundCount = prefs.RoundCount,
                TimerEnabled = prefs.TimerEnabled,
                Difficulty = prefs.Difficulty,
                PhishingEmailCount = prefs.PhishingEmailCount,
                IncludeAttachments = prefs.IncludeAttachments,
                IncludeLinks = prefs.IncludeLinks,
                IncludeUrgency = prefs.IncludeUrgency,
                IncludeStrength = prefs.IncludeStrength,
                IncludeReuse = prefs.IncludeReuse,
                IncludeManager = prefs.IncludeManager,
                IncludePatterns = prefs.IncludePatterns,
                HintMode = prefs.HintMode,
                FeedbackMode = prefs.FeedbackMode
            };
        }

        private void cmbMiniGameType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_loading || _lockGameType)
            {
                return;
            }

            SwitchGameTemplate();
        }

        private void rbDefault_CheckedChanged(object sender, EventArgs e)
        {
            if (!rbDefault.Checked || _loading)
            {
                return;
            }

            ApplyMode(true);
            UpdateSummary();
        }

        private void rbCustom_CheckedChanged(object sender, EventArgs e)
        {
            if (!rbCustom.Checked || _loading)
            {
                return;
            }

            ApplyMode(false);
            UpdateSummary();
        }

        private void cmbRoundCount_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateSummary();
        }

        private void cmbTimer_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateSummary();
        }

        private void cmbDifficulty_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateSummary();
        }

        private void cmbEmailCount_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateSummary();
        }

        private void chkIncludeAttachments_CheckedChanged(object sender, EventArgs e)
        {
            UpdateSummary();
        }

        private void chkIncludeLinks_CheckedChanged(object sender, EventArgs e)
        {
            UpdateSummary();
        }

        private void chkIncludeUrgency_CheckedChanged(object sender, EventArgs e)
        {
            UpdateSummary();
        }

        private void chkIncludeStrength_CheckedChanged(object sender, EventArgs e)
        {
            UpdateSummary();
        }

        private void chkIncludeReuse_CheckedChanged(object sender, EventArgs e)
        {
            UpdateSummary();
        }

        private void chkIncludeManager_CheckedChanged(object sender, EventArgs e)
        {
            UpdateSummary();
        }

        private void chkIncludePatterns_CheckedChanged(object sender, EventArgs e)
        {
            UpdateSummary();
        }

        private void cmbHints_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateSummary();
        }

        private void cmbFeedbackMode_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateSummary();
        }

        private void btnUseDefaults_Click(object sender, EventArgs e)
        {
            Preferences = MiniGamePreferences.CreateDefault(ReadGameType());
            ApplyToUi(Preferences);
            ApplyMode(true);
            UpdateSummary();
        }

        private void btnApply_Click(object sender, EventArgs e)
        {
            Preferences = ReadFromUi();
            DialogResult = DialogResult.OK;
            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}