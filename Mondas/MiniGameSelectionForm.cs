using Mondas.Models;
using Mondas.Services;
using Syncfusion.WinForms.Controls;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using static Mondas.Services.MiniGamePreferencesStore;

namespace Mondas
{
    public partial class MiniGameSelectionForm : SfForm
    {
        private readonly string _userKey;
        private readonly long _userId;
        private readonly string _dbPath;
        private readonly DashboardStatsService _statsService;
        private readonly PhishingAttemptStore _phishingStore;
        private readonly MiniGamePreferencesStore _prefsStore;
        private MiniGamePreferences _phishingPrefs;
        private MiniGamePreferences _passwordPrefs;
        private MiniGamePreferences _recommendedPrefs;
        private MiniGamePreferences _recommendedOverride;
        private string _recommendedReason = "";

        public MiniGameSelectionForm() : this("local")
        {

        }

        public MiniGameSelectionForm(string userKey)
        {
            InitializeComponent();

            _userKey = string.IsNullOrWhiteSpace(userKey) ? "local" : userKey.Trim();
            _userId = ParseUserId(_userKey);
            _dbPath = Path.Combine(AppContext.BaseDirectory, "mondas.db");

            _statsService = new DashboardStatsService(_dbPath);
            _phishingStore = new PhishingAttemptStore(_dbPath);
            _prefsStore = new MiniGamePreferencesStore();
        }

        private void MiniGameSelectionForm_Load(object sender, EventArgs e)
        {
            if (btnNavMiniGames != null)
            {
                btnNavMiniGames.Enabled = false;
            }

            InitPerformanceFilters();
            LoadPrefs();
            RefreshPage(true);
        }

        private void InitPerformanceFilter()
        {
            if (cmbPerfSource == null)
            {
                return;
            }

            if (cmbPerfSource.Items.Count == 0)
            {
                cmbPerfSource.Items.AddRange(new object[] { "All", "Phishing Simulator", "Password Workshop" });
            }

            if (cmbPerfSource.SelectedIndex < 0 && cmbPerfSource.Items.Count > 0)
            {
                cmbPerfSource.SelectedIndex = 0;
            }
        }

        private void LoadPrefs()
        {
            var data = _prefsStore.Load(_userKey);

            _phishingPrefs = MiniGamePreferences.Normalise(data.Phishing);
            _passwordPrefs = MiniGamePreferences.Normalise(data.Password);
            _recommendedOverride = data.RecommendedOverride == null ? null : MiniGamePreferences.Normalise(data.RecommendedOverride);
        }

        private void SavePrefs()
        {
            _prefsStore.Save(_userKey, new MiniGamePrefsData { Phishing = _phishingPrefs, Password = _passwordPrefs, RecommendedOverride = _recommendedOverride });
        }

        private void RefreshPage(bool recomputeRecommended)
        {
            ApplyHeader();

            if (recomputeRecommended || _recommendedPrefs == null)
            {
                _recommendedPrefs = BuildRecommendedPreferences(out _recommendedReason);
            }

            if (_recommendedOverride != null)
            {
                _recommendedPrefs = MiniGamePreferences.Normalise(_recommendedOverride);
                _recommendedPrefs.GameType = MiniGameType.PhishingSimulator;
                _recommendedReason = "Using your custom recommended settings.";
            }

            UpdateRecommendedCard();
            UpdateModeCards();
            LoadReecentPerformance();
        }

        private void ApplyHeader()
        {
            DashboardStats stats;

            try
            {
                stats = _statsService.Load(_userId, _userKey, StatsSource.All);
            }

            catch
            {
                stats = new DashboardStats { FullName = "USER" };
            }

            var name = (_statsService == null ? "USER" : (stats.FullName ?? "USER")).Trim().ToUpperInvariant();

            if (lblUser != null)
            {
                lblUser.Text = name;
            }

            if (lblTitle != null)
            {
                lblTitle.Text = "MINI GAME SELECTION";
            }

            if (lblSub != null)
            {
                lblSub.Text = "CHOOSE A MINI GAME MODE AND START PRACTISING";
            }
        }

        private MiniGamePreferences BuildRecommendedPreferences(out string reason)
        {
            var prefs = MiniGamePreferences.CreateDefault(MiniGameType.PhishingSimulator);
            prefs.UseDefaults = false;
            prefs.Difficulty = DifficultyBand.Medium;
            prefs.PhishingEmailCount = 10;
            prefs.RoundCount = 10;

            try
            {
                var stats = _statsService.Load(_userId, _userKey, StatsSource.All);

                if (stats.WeakestTopic == Topic.Phishing || stats.WeakestTopic == Topic.SocialEngineering)
                {
                    prefs.Difficulty = stats.WeakestAccuracy01 < 0.45 ? DifficultyBand.Easy : DifficultyBand.Medium;
                    reason = $"Recommended because {stats.WeakestTopic.Value.ToString().ToUpperInvariant()} is one of your weakest areas right now.";
                    return prefs;
                }

                if (stats.WeakestTopic == Topic.Passwords)
                {
                    reason = "Change this once Password Workshop is live.";
                    return prefs;
                }
            }

            catch
            {

            }

            reason = "Recommended because Phishing Simulator is the live mini game available right now and gives quick decision practice.";
            return prefs;
        }

        private void UpdateRecommendedCard()
        {
            if (lblRecReason != null)
            {
                lblRecSummary.Text = FormatMiniGameSummary(_recommendedPrefs);
            }

            if (lblRecReason != null)
            {
                lblRecReason.Text = _recommendedReason ?? "";
            }

            if (btnStartRecommended != null)
            {
                btnStartRecommended.Enabled = true;
            }
        }

        private void UpdateModeCards()
        {
            if (lblPhishingTitle != null)
            {
                lblPhishingTitle.Text = "PHISHING SIMULATOR";
            }

            if (lblPhishingDesc != null)
            {
                var prefs = _phishingPrefs.UseDefaults ? MiniGamePreferences.CreateDefault(MiniGameType.PhishingSimulator) : _phishingPrefs;
                lblPhishingDesc.Text = "SPOT PHISHING EMAILS, LINKS AND ATTACHMENTS.\r\n" + FormatMiniGameSummary(prefs);
            }

            if (lblPasswordTitle != null)
            {
                lblPasswordTitle.Text = "PASSWORD WORKSHOP";
            }

            if (lblPasswordDesc != null)
            {
                lblPasswordDesc.Text = "COMING SOON.";
            }

            if (btnPasswordPreferences != null)
            {
                btnPasswordPreferences.Enabled = false;
            }
        }

        private string FormatMiniGameSummary(MiniGamePreferences prefs)
        {
            prefs = MiniGamePreferences.Normalise(prefs);

            if (prefs.GameType == MiniGameType.PasswordWorkshop)
            {
                return $"GAME: PASSWORD WORKSHOP · ROUNDS: {prefs.RoundCount} · DIFFICULTY: {(prefs.Difficulty.HasValue ? prefs.Difficulty.Value.ToString().ToUpperInvariant() : "ANY")} · TIMER: {(prefs.TimerEnabled ? "ON" : "OFF")}";
            }

            return $"GAME : PHISHING SIMULATOR · EMAILS: {prefs.PhishingEmailCount} · DIFFICULTY {(prefs.Difficulty.HasValue ? prefs.Difficulty.Value.ToString().ToUpperInvariant() : "ANY")} · TIMER: {(prefs.TimerEnabled ? "ON" : "OFF")}";
        }

        private void LoadRecentPerformance()
        {
            if (lvRecentPerformance == null)
            {
                return;
            }

            var sourceText = (cmbPerfSource?.SelectedItem?.ToString() ?? cmbPerfSource?.Text ?? "").Trim().ToUpperInvariant();
            var items = new List<PhishingAttemptRow>();

            if (!sourceText.Contains("PASSWORD"))
            {
                try
                {
                    items = _phishingStore.GetForUser(_userKey, 100).Where(x => x.Action == (int)PhishingAction.TrustKeep || x.Action == (int)PhishingAction.ReportPhishing).Take(20).ToList();
                }

                catch
                {
                    items = new List<PhishingAttemptRow>();
                }

                lvRecentPerformance.BeginUpdate();
                lvRecentPerformance.Items.Clear();
            }
            foreach (var row in items)
            {
                var result = BuildResultText(row);
                var accuracy = row.IsCorrect ? "100%" : "0%";
                var date = row.SubmittedUtc.ToLocalTime().ToString("dd MMM yyyy HH:mm", CultureInfo.InvariantCulture);
                var item = new ListViewItem("PHISHING");

                item.SubItems.Add(result);
                item.SubItems.Add(accuracy);
                item.SubItems.Add(date);

                lvRecentPerformance.Items.Add(item);
            }

            lvRecentPerformance.EndUpdate();
        }

        private void EnsurePerformanceColumns()
        {
            if (lvRecentPerformance.Columns.Count > 0)
            {
                return;
            }

            lvRecentPerformance.View = View.Details;
            lvRecentPerformance.FullRowSelect = true;
            lvRecentPerformance.MultiSelect = false;
            lvRecentPerformance.HeaderStyle = ColumnHeaderStyle.Nonclickable;

            lvRecentPerformance.Columns.Add("GAME", 180, HorizontalAlignment.Left);
            lvRecentPerformance.Columns.Add("RESULT", 180, HorizontalAlignment.Left);
            lvRecentPerformance.Columns.Add("ACCURACY", 120, HorizontalAlignment.Center);
            lvRecentPerformance.Columns.Add("DATE", 220, HorizontalAlignment.Center);
        }

        private static string BuildResultsText(PhishingAttemptRow row)
        {
            if (row.Action == (int)PhishingAction.TrustKeep)
            {
                return row.IsCorrect ? "SAFE CALL" : "MISSED PHISH";
            }

            if (row.Action == (int)PhihsingAction.ReportPhishing)
            {
                return row.IsCorrect ? "GOOD CATCH" : "FALSE ALARM";
            }

            return row.IsCorrect ? "CORRECT" : "INCORRECT";
        }

        private void OpenPhishingPreferences()
        {
            using var dlg = new MiniGamePreferencesForm(_phishingPrefs);
            
            if (dlg.ShowDialog(this) != DialogResult.OK)
            {
                return;
            }

            _phishingPrefs = MiniGamePreferences.Normalise(dlg.Preferences);
            _phishingPrefs.GameType = MiniGameType.PhishingSimulator;

            SavePrefs();
            RefreshPage(false);
        }

        private void OpenRecommendedPreferences()
        {
            var seed = _recommendedOverride ?? _recommendedPrefs ?? MiniGamePreferences.CreateDefault(MiniGameType.PhishingSimulator);

            using var dlg = new MiniGamePreferencesForm(seed);
            
            if (dlg.ShowDialog(this) != DialogResult.OK)
            {
                return;
            }

            var picked = MiniGamePreferences.Normalise(dlg.Preferences);
            picked.GameType = MiniGameType.PhishingSimulator;
            picked.UseDefaults = false;

            _recommendedOverride = picked;

            SavePrefs();
            RefreshPage(true);
        }

        private void StartMiniGame(MiniGamePreferences prefs)
        {
            prefs = MiniGamePreferences.Normalise(prefs);

            if (prefs.GameType == MiniGameType.PasswordWorkshop)
            {
                MessageBox.Show(this, "Password Workshop has not been developed yet.", "Mondas", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var form = new PhishingSimulatorForm(_userKey, prefs);

            form.FormClosed += (_, __) =>
            {
                try
                {
                    Show();
                    RefreshPage(true);
                }

                catch
                {

                }
            };

            form.Show();
            Hide();
        }

        private static long ParseUserId(string userKey)
        {
            if (string.IsNullOrWhiteSpace(userKey))
            {
                return 0;
            }

            userKey = userKey.Trim();

            if (!userKey.StartsWith("u:", StringComparison.OrdinalIgnoreCase))
            {
                return 0;
            }

            var raw = userKey.Substring(2);
            return long.TryParse(raw, out var id) ? id : 0;
        }

        private void btnStartRecommended_Click(object sender, EventArgs e)
        {
            StartMiniGame(_recommendedPrefs);
        }

        private void lnkChangePreferences_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            OpenRecommendedPreferences();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            var start = new Start();
            start.Show();
            Close();
        }

        private void btnStartPhishing_Click(object sender, EventArgs e)
        {
            StartMiniGame(_phishingPrefs);
        }

        private void btnPhishingPreferences_Click(object sender, EventArgs e)
        {
            OpenPhishingPreferences();
        }

        private void btnStartPassword_Click(object sender, EventArgs e)
        {
            MessageBox.Show(this, "Password Workshop has not been developed yet.", "Mondas", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnPasswordPreferences_Click(object sender, EventArgs e)
        {
            MessageBox.Show(this, "Password Workshop has not been developed yet.", "Mondas", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void cmbPerfSource_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadRecentPerformance();
        }
    }
}