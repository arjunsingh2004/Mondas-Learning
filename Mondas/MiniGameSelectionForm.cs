using Mondas.Models;
using Mondas.Services;
using Syncfusion.WinForms.Controls;
using System;
using System.Collections.Generic;
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
        private readonly AuthenticationDefenseAttemptStore _authenticationStore;
        private readonly MiniGamePreferencesStore _prefsStore;
        private MiniGamePreferences _phishingPrefs;
        private MiniGamePreferences _authenticationPrefs;
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
            _authenticationStore = new AuthenticationDefenseAttemptStore(_dbPath);
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

        private void InitPerformanceFilters()
        {
            if (cmbPerfSource == null)
            {
                return;
            }

            if (cmbPerfSource.Items.Count == 0)
            {
                cmbPerfSource.Items.AddRange(new object[] { "All", "Phishing Simulator", "Authentication Defense" });
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
            _authenticationPrefs = MiniGamePreferences.Normalise(data.Authentication);
            _recommendedOverride = data.RecommendedOverride == null ? null : MiniGamePreferences.Normalise(data.RecommendedOverride);
        }

        private void SavePrefs()
        {
            _prefsStore.Save(_userKey, new MiniGamePrefsData { Phishing = _phishingPrefs, Authentication = _authenticationPrefs, RecommendedOverride = _recommendedOverride });
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
                _recommendedReason = "Using your custom recommended settings.";
            }

            UpdateRecommendedCard();
            UpdateModeCards();
            LoadRecentPerformance();
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

            var name = (stats.FullName ?? "USER").Trim().ToUpperInvariant();

            if (lblUser != null)
            {
                lblUser.Text = name.Length == 0 ? "USER" : name;
            }

            if (lblTitle != null)
            {
                lblTitle.Text = "MINI GAME SELECTION";
            }

            if (lblSub != null)
            {
                lblSub.Text = "CHOOSE A MINI GAME MODE AND START PRACTISING!";
            }
        }

        private MiniGamePreferences BuildRecommendedPreferences(out string reason)
        {
            try
            {
                var stats = _statsService.Load(_userId, _userKey, StatsSource.All);

                if (stats.WeakestTopic == Topic.Passwords || stats.WeakestTopic == Topic.DeviceSecurity)
                {
                    var authPrefs = MiniGamePreferences.CreateDefault(MiniGameType.AuthenticationDefense);
                    authPrefs.UseDefaults = false;
                    authPrefs.RoundCount = 10;
                    authPrefs.Difficulty = stats.WeakestAccuracy01 < 0.45 ? DifficultyBand.Easy : DifficultyBand.Medium;

                    reason = $"Recommended because {stats.WeakestTopic.Value.ToString().ToUpperInvariant()} is currently one of your weakest areas.";
                    return authPrefs;
                }

                if (stats.WeakestTopic == Topic.Phishing || stats.WeakestTopic == Topic.SocialEngineering)
                {
                    var phishingPrefs = MiniGamePreferences.CreateDefault(MiniGameType.PhishingSimulator);
                    phishingPrefs.UseDefaults = false;
                    phishingPrefs.PhishingEmailCount = 10;
                    phishingPrefs.RoundCount = 10;
                    phishingPrefs.Difficulty = stats.WeakestAccuracy01 < 0.45 ? DifficultyBand.Easy : DifficultyBand.Medium;

                    reason = $"Recommended because {stats.WeakestTopic.Value.ToString().ToUpperInvariant()} is currently one of your weakest areas.";
                    return phishingPrefs;
                }
            }

            catch
            {

            }

            var fallback = MiniGamePreferences.CreateDefault(MiniGameType.PhishingSimulator);
            fallback.UseDefaults = false;
            fallback.PhishingEmailCount = 10;
            fallback.RoundCount = 10;
            fallback.Difficulty = DifficultyBand.Medium;

            reason = "Recommended because Phishing Simulator is still the quickest practice mode to jump into.";
            return fallback;
        }

        private void UpdateRecommendedCard()
        {
            if (lblRecSummary != null)
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

            if (lblAuthenticationTitle != null)
            {
                lblAuthenticationTitle.Text = "AUTHENTICATION DEFENSE";
            }

            if (lblAuthenticationDesc != null)
            {
                var prefs = _authenticationPrefs.UseDefaults ? MiniGamePreferences.CreateDefault(MiniGameType.AuthenticationDefense) : _authenticationPrefs;
                lblAuthenticationDesc.Text ="BUILD THE BEST DEFENSE FOR EACH ATTACK SCENARIO.\r\n" + FormatMiniGameSummary(prefs);
            }

            if (btnStartAuthentication != null)
            {
                btnStartAuthentication.Enabled = true;
            }

            if (btnAuthenticationPreferences != null)
            {
                btnAuthenticationPreferences.Enabled = true;
            }
        }

        private string FormatMiniGameSummary(MiniGamePreferences prefs)
        {
            prefs = MiniGamePreferences.Normalise(prefs);

            if (prefs.GameType == MiniGameType.AuthenticationDefense)
            {
                return $"GAME: AUTHENTICATION DEFENSE · ROUNDS: {prefs.RoundCount} · DIFFICULTY: {(prefs.Difficulty.HasValue ? prefs.Difficulty.Value.ToString().ToUpperInvariant() : "ANY")} · TIMER: {(prefs.TimerEnabled ? "ON" : "OFF")}";
            }

            return $"GAME: PHISHING SIMULATOR · EMAILS: {prefs.PhishingEmailCount} · DIFFICULTY: {(prefs.Difficulty.HasValue ? prefs.Difficulty.Value.ToString().ToUpperInvariant() : "ANY")} · TIMER: {(prefs.TimerEnabled ? "ON" : "OFF")}";
        }

        private void LoadRecentPerformance()
        {
            if (lvRecentPerformance == null)
            {
                return;
            }

            var sourceText = (cmbPerfSource?.SelectedItem?.ToString() ?? cmbPerfSource?.Text ?? "").Trim().ToUpperInvariant();
            var rows = new List<(string Game, string Result, string Accuracy, DateTime When)>();

            if (sourceText == "ALL" || sourceText.Contains("PHISH"))
            {
                try
                {
                    var phishingRows = _phishingStore.GetForUser(_userKey, 100).Where(x => x.Action == (int)PhishingAction.TrustKeep || x.Action == (int)PhishingAction.ReportPhishing).Select(x => ("PHISHING", BuildResultText(x), x.IsCorrect ? "100%" : "0%", x.SubmittedUtc)).ToList();
                    rows.AddRange(phishingRows);
                }

                catch
                {

                }
            }

            if (sourceText == "ALL" || sourceText.Contains("AUTH"))
            {
                try
                {
                    var authRows = _authenticationStore.GetForUser(_userKey, 100).Select(x => ("AUTH DEFENSE", BuildResultText(x), BuildAccuracyText(x), x.SubmittedUtc)).ToList(); 
                    rows.AddRange(authRows);
                }

                catch
                {

                }
            }

            rows = rows.OrderByDescending(x => x.When).Take(20).ToList();

            lvRecentPerformance.BeginUpdate();
            lvRecentPerformance.Items.Clear();

            foreach (var row in rows)
            {
                var item = new ListViewItem(row.Game);
                item.SubItems.Add(row.Result);
                item.SubItems.Add(row.Accuracy);
                item.SubItems.Add(row.When.ToLocalTime().ToString("dd MMM yyyy HH:mm", CultureInfo.InvariantCulture));
                lvRecentPerformance.Items.Add(item);
            }

            lvRecentPerformance.EndUpdate();
        }

        private static string BuildResultText(PhishingAttemptRow row)
        {
            if (row.Action == (int)PhishingAction.TrustKeep)
            {
                return row.IsCorrect ? "SAFE CALL" : "MISSED PHISH";
            }

            if (row.Action == (int)PhishingAction.ReportPhishing)
            {
                return row.IsCorrect ? "GOOD CATCH" : "FALSE ALARM";
            }

            return row.IsCorrect ? "CORRECT" : "INCORRECT";
        }

        private static string BuildResultText(AuthenticationDefenseAttemptRow row)
        {
            if (!row.Accuracy01.HasValue)
            {
                return row.IsCorrect ? "PASS" : "MISS";
            }

            var accuracy = row.Accuracy01.Value;

            if (accuracy < 0)
            {
                accuracy = 0;
            }

            if (accuracy > 1)
            {
                accuracy = 1;
            }

            if (row.IsCorrect)
            {
                return "PASS";
            }

            if (accuracy >= 0.40)
            {
                return "PARTIAL";
            }

            return "MISS";
        }

        private static string BuildAccuracyText(AuthenticationDefenseAttemptRow row)
        {
            if (!row.Accuracy01.HasValue)
            {
                return "-";
            }

            var accuracy = row.Accuracy01.Value;

            if (accuracy < 0)
            {
                accuracy = 0;
            }

            if (accuracy > 1)
            {
                accuracy = 1;
            }

            return (accuracy * 100.0).ToString("0", CultureInfo.InvariantCulture) + "%";
        }

        private void OpenPhishingPreferences()
        {
            using var dlg = new MiniGamePreferencesForm(_phishingPrefs, true);
            
            if (dlg.ShowDialog(this) != DialogResult.OK)
            {
                return;
            }

            _phishingPrefs = MiniGamePreferences.Normalise(dlg.Preferences);
            _phishingPrefs.GameType = MiniGameType.PhishingSimulator;

            SavePrefs();
            RefreshPage(false);
        }

        private void OpenAuthenticationPreferences()
        {
            using var dlg = new MiniGamePreferencesForm(_authenticationPrefs, true);

            if (dlg.ShowDialog(this) != DialogResult.OK)
            {
                return;
            }

            _authenticationPrefs = MiniGamePreferences.Normalise(dlg.Preferences);
            _authenticationPrefs.GameType = MiniGameType.AuthenticationDefense;

            SavePrefs();
            RefreshPage(false);
        }

        private void StartMiniGame(MiniGamePreferences prefs)
        {
            prefs = MiniGamePreferences.Normalise(prefs);

            Form form;

            if (prefs.GameType == MiniGameType.AuthenticationDefense)
            {
                form = new AuthenticationDefenseForm(_userKey, prefs);
            }

            else
            {
                form = new PhishingSimulatorForm(_userKey, prefs);
            }

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
            StartMiniGame(_authenticationPrefs);
        }

        private void btnPasswordPreferences_Click(object sender, EventArgs e)
        {
            OpenAuthenticationPreferences();
        }

        private void cmbPerfSource_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadRecentPerformance();
        }
    }
}