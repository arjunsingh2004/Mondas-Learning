using Mondas.Models;
using Mondas.Services;
using Newtonsoft.Json;
using Syncfusion.WinForms.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Mondas
{
    public partial class AuthenticationDefenseForm : SfForm
    {
        private readonly string _userKey;
        private readonly long _userId;
        private readonly string _dbPath;
        private readonly string _scenariosPath;

        private readonly DashboardStatsService _statsService;
        private readonly AuthenticationDefenseScenarioRepository _scenarioRepo;
        private readonly AuthenticationDefenseAttemptStore _attemptStore;
        private readonly AuthenticationDefenseScoringV1 _scoring;
        private readonly Random _rng = new Random();

        private IReadOnlyList<AuthenticationDefenseScenario> _allScenarios = Array.Empty<AuthenticationDefenseScenario>();

        private List<AuthenticationDefenseAttemptRow> _history = new List<AuthenticationDefenseAttemptRow>();
        private readonly HashSet<String> _seenRun = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
        private readonly List<AuthenticationDefenseAttemptRow> _runLog = new List<AuthenticationDefenseAttemptRow>();
        private AuthenticationDefenseScenario _currentScenario;
        private ListViewItem _currentQueueItem;

        private bool _currentScenarioResolved;
        private int _score;
        private int _streak;
        private bool _runStarted;
        private bool _runClockPaused;

        private TimeSpan _runClockFrozen;
        private DateTime _runStartedUtc;
        private DateTime _scenarioShownUtc;

        private readonly MiniGamePreferences _prefs;
        private readonly SharedAdaptiveLearningService _sharedAdaptiveLearningService;
        private UserModel _sharedUserModel = new UserModel();

        public AuthenticationDefenseForm() : this("local", null)
        {

        }

        public AuthenticationDefenseForm(string userKey) : this(userKey, null)
        {

        }

        public AuthenticationDefenseForm(string userKey, MiniGamePreferences prefs)
        {
            InitializeComponent();

            _userKey = string.IsNullOrWhiteSpace(userKey) ? "local" : userKey.Trim();
            _userId = ParseUserId(_userKey);
            _dbPath = Path.Combine(AppContext.BaseDirectory, "mondas.db");
            _scenariosPath = FindScenariosPath();

            _prefs = MiniGamePreferences.Normalise(prefs ?? MiniGamePreferences.CreateDefault(MiniGameType.AuthenticationDefense));

            _statsService = new DashboardStatsService(_dbPath);
            _scenarioRepo = new AuthenticationDefenseScenarioRepository(_scenariosPath);
            _attemptStore = new AuthenticationDefenseAttemptStore(_dbPath);
            _scoring = new AuthenticationDefenseScoringV1();
            _sharedAdaptiveLearningService = new SharedAdaptiveLearningService(_dbPath, FindQuestionsPath());
        }

        private void AuthenticationDefenseForm_Load(object sender, EventArgs e)
        {
            if (LicenseManager.UsageMode == LicenseUsageMode.Designtime)
            {
                return;
            }

            FillComboboxes();
            LoadData();
            AddHeader();
            ResetUi();
            EnsureTimer();
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

        private string FindScenariosPath()
        {
            var baseDir = AppContext.BaseDirectory;

            var p1 = Path.Combine(baseDir, "auth_defense_scenarios.json");
            var p2 = Path.Combine(baseDir, "Resources", "auth_defense_scenarios.json");
            var p3 = Path.Combine(baseDir, "Data", "auth_defense_scenarios.json");

            if (File.Exists(p1))
            {
                return p1;
            }

            if (File.Exists(p2))
            {
                return p2;
            }

            if (File.Exists(p3))
            {
                return p3;
            }

            return p2;
        }

        private void LoadData()
        {
            try
            {
                _allScenarios = _scenarioRepo.LoadAll() ?? Array.Empty<AuthenticationDefenseScenario>();
            }

            catch
            {
                _allScenarios = Array.Empty<AuthenticationDefenseScenario>();
            }

            try
            {
                _history = _attemptStore.GetForUser(_userKey, 5000) ?? new List<AuthenticationDefenseAttemptRow>();
            }

            catch
            {
                _history = new List<AuthenticationDefenseAttemptRow>();
            }

            try
            {
                _sharedUserModel = _sharedAdaptiveLearningService.BuildUserModel(_userKey);
            }
            catch
            {
                _sharedUserModel = new UserModel();
            }
        }

        private void AddHeader()
        {
            try
            {
                var stats = _statsService.Load(_userId, _userKey, StatsSource.All);
                var name = (stats.FullName ?? "USER").Trim().ToUpperInvariant();

                if (lblUser != null)
                {
                    lblUser.Text = name.Length == 0 ? "USER" : name;
                }
            }

            catch
            {
                if (lblUser != null)
                {
                    lblUser.Text = "USER";
                }
            }
        }

        private void FillComboboxes()
        {
            FillEnumCombo<AuthMethodType>(cmbAuthMethod);
            FillEnumCombo<PasswordPolicyType>(cmbPasswordPolicy);
            FillEnumCombo<RecoveryType>(cmbRecovery);
            FillEnumCombo<MonitoringType>(cmbMonitoring);
            FillEnumCombo<RateLimitType>(cmbRateLimit);
            FillEnumCombo<SessionControlType>(cmbSession);

            SetDefaults();
        }

        private void FillEnumCombo<T>(ComboBox cmb) where T : struct, Enum
        {
            if (cmb == null)
            {
                return;
            }

            cmb.Format -= EnumCombo_Format;
            cmb.Format += EnumCombo_Format;
            cmb.DataSource = Enum.GetValues(typeof(T)).Cast<T>().ToList();
            cmb.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private void EnumCombo_Format(object sender, ListControlConvertEventArgs e)
        {
            if (e.ListItem is Enum value)
            {
                e.Value = ToUiText(value);
            }
        }

        private static string ToUiText(Enum value)
        {
            var raw = value.ToString();

            if (string.IsNullOrEmpty(raw))
            {
                return "";
            }

            var sb = new StringBuilder(raw.Length + 8);

            for (int i = 0; i < raw.Length; i++)
            {
                var c = raw[i];

                if (i > 0 && char.IsUpper(c) && !char.IsUpper(raw[i - 1]))
                {
                    sb.Append(' ');
                }

                sb.Append(c);
            }

            return sb.ToString().ToUpperInvariant();
        }

        private void SetDefaults()
        {
            SelectComboValue(cmbAuthMethod, AuthMethodType.PasswordAndOtp);
            SelectComboValue(cmbPasswordPolicy, PasswordPolicyType.StrongUnique);
            SelectComboValue(cmbRecovery, RecoveryType.BackupCodes);
            SelectComboValue(cmbMonitoring, MonitoringType.BasicLogs);
            SelectComboValue(cmbRateLimit, RateLimitType.BasicLockout);
            SelectComboValue(cmbSession, SessionControlType.Basic);

            if (chkRequireMfa != null)
            {
                chkRequireMfa.Checked = false;
            }

            if (chkPhishingResistant != null)
            {
                chkPhishingResistant.Checked = false;
            }

            if (chkDeviceBinding != null)
            {
                chkDeviceBinding.Checked = false;
            }

            if (chkRiskBasedStepUp != null)
            {
                chkRiskBasedStepUp.Checked = false;
            }

            if (chkBlockLegacyAuth != null)
            {
                chkBlockLegacyAuth.Checked = false;
            }

            if (chkAlertOnSuspicious != null)
            {
                chkAlertOnSuspicious.Checked = false;
            }
        }

        private void SelectComboValue<T>(ComboBox cmb, T value) where T : struct, Enum
        {
            if (cmb == null || cmb.Items.Count == 0)
            {
                return;
            }

            foreach (var item in cmb.Items)
            {
                if (item is T typed && EqualityComparer<T>.Default.Equals(typed, value))
                {
                    cmb.SelectedItem = typed;
                    return;
                }
            }

            cmb.SelectedIndex = 0;
        }

        private string FindQuestionsPath()
        {
            var baseDir = AppContext.BaseDirectory;

            var p1 = Path.Combine(baseDir, "questions.json");
            var p2 = Path.Combine(baseDir, "Resources", "questions.json");
            var p3 = Path.Combine(baseDir, "Data", "questions.json");

            if (File.Exists(p1))
            {
                return p1;
            }

            if (File.Exists(p2))
            {
                return p2;
            }

            if (File.Exists(p3))
            {
                return p3;
            }

            return p2;
        }

        private void ResetUi()
        {
            _currentScenario = null;
            _currentQueueItem = null;
            _currentScenarioResolved = false;
            _score = 0;
            _streak = 0;

            _seenRun.Clear();
            _runLog.Clear();

            _runClockPaused = true;
            _runStarted = false;

            _runClockFrozen = TimeSpan.Zero;
            _runStartedUtc = DateTime.UtcNow;

            if (lvQueue != null)
            {
                lvQueue.BeginUpdate();
                lvQueue.Items.Clear();
                lvQueue.EndUpdate();
            }

            ShowScenario(null);
            ResetResult();
            SetDefaults();
            UpdateButtons();
            UpdateRunInfo();
        }

        private void EnsureTimer()
        {
            if (tmrRun == null)
            {
                return;
            }

            tmrRun.Interval = 250;
            tmrRun.Enabled = true;
        }

        private void UpdateRunInfo()
        {
            if (lblRunInfo == null)
            {
                return;
            }

            TimeSpan elapsed;

            if (!_runStarted)
            {
                elapsed = TimeSpan.Zero;
            }

            else
            {
                elapsed = _runClockPaused ? _runClockFrozen : (DateTime.UtcNow - _runStartedUtc);
            }

            var timeText = _prefs != null && !_prefs.TimerEnabled ? "OFF" : FormatTime(elapsed);
            lblRunInfo.Text = $"SCORE: {_score} | STREAK | {_streak} | TIME: {timeText}";
        }

        private static string FormatTime(TimeSpan value)
        {
            var mins = (int)value.TotalMinutes;
            var secs = value.Seconds;

            return mins.ToString("00") + "." + secs.ToString("00");
        }

        private void ShowScenario(AuthenticationDefenseScenario scenario)
        {
            _currentScenario = scenario;

            if (lblScenarioName != null)
            {
                lblScenarioName.Text = scenario == null ? "-" : (scenario.Title ?? "").ToUpperInvariant();
            }

            if (lblThreatType != null)
            {
                lblThreatType.Text = scenario == null ? "-" : ToUiText(scenario.ThreatType);
            }

            if (lblGoal != null)
            {
                lblGoal.Text = scenario == null ? "-" : ToUiText(scenario.GoalType);
            }

            if (lblDifficulty != null)
            {
                lblDifficulty.Text = scenario == null ? "-" : ToUiText(scenario.Difficulty);
            }

            if (rtbScenarioBody != null)
            {
                rtbScenarioBody.ReadOnly = true;
                rtbScenarioBody.Text = scenario == null ? "" : (scenario.Body ?? "");
                rtbScenarioBody.SelectionStart = 0;
                rtbScenarioBody.SelectionLength = 0;
            }
        }

        private void ResetResult()
        {
            if (lblResultsText != null)
            {
                lblResultsText.Text = "-";
            }

            if (lblResultScoreDelta != null)
            {
                lblResultScoreDelta.Text = "SCORE: +0 | TIME: 0s";
            }

            if (lblResultWhy != null)
            {
                lblResultWhy.Text = "FINDINGS: 0";
            }

            if (lvFindings != null)
            {
                lvFindings.BeginUpdate();
                lvFindings.Items.Clear();
                lvFindings.EndUpdate();
            }
        }

        private void UpdateButtons()
        {
            var hasScenario = _currentScenario != null;

            if (btnViewHints != null)
            {
                btnViewHints.Enabled = hasScenario;
            }

            if (btnRunSimulation != null)
            {
                btnRunSimulation.Enabled = hasScenario && !_currentScenarioResolved;
            }

            if (btnClearBuild != null)
            {
                btnClearBuild.Enabled = hasScenario && !_currentScenarioResolved;
            }

            if (btnNextScenario != null)
            {
                btnNextScenario.Enabled = hasScenario && _currentScenarioResolved;
            }
        }

        private void StartRunClock()
        {
            if (_runStarted)
            {
                return;
            }

            _runStarted = true;
            _runClockPaused = false;

            _runClockFrozen = TimeSpan.Zero;
            _runStartedUtc = DateTime.UtcNow;
        }

        private void PauseRunClock()
        {
            if (!_runStarted || _runClockPaused)
            {
                return;
            }

            _runClockFrozen = DateTime.UtcNow - _runStartedUtc;
            _runClockPaused = true;
        }

        private void ResumeRunClock()
        {
            if (!_runStarted || !_runClockPaused)
            {
                return;
            }

            _runStartedUtc = DateTime.UtcNow - _runClockFrozen;
            _runClockPaused = false;
        }

        private AuthenticationDefenseScenario PickNextScenario()
        {
            var candidates = _allScenarios.Where(x => x != null && !_seenRun.Contains(x.Id ?? "")).ToList();

            if (candidates.Count == 0)
            {
                return null;
            }

            candidates = ApplyPreferenceFilters(candidates);

            if (candidates.Count == 0)
            {
                candidates = _allScenarios.Where(x => x != null && !_seenRun.Contains(x.Id ?? "")).ToList();
            }

            var targetDifficulty = FixTargetDifficulty();
            var weighted = new List<(AuthenticationDefenseScenario scenario, double weight)>();

            foreach (var scenario in candidates)
            {
                double weight = 1.0;

                var weakness = GetScenarioWeakness(scenario);
                weight *= 0.35 + (0.65 * weakness);

                var distance = SharedAdaptiveLearningService.DifficultyDistance(scenario.Difficulty, targetDifficulty);
                weight *= distance == 0 ? 1.0 : distance == 1 ? 0.65 : 0.35;

                weight *= 0.90 + (_rng.NextDouble() * 0.20);

                weighted.Add((scenario, weight));
            }

            return PickWeighted(weighted);
        }

        private List<AuthenticationDefenseScenario> ApplyPreferenceFilters(List<AuthenticationDefenseScenario> candidates)
        {
            if (_prefs == null || candidates == null || candidates.Count == 0)
            {
                return candidates ?? new List<AuthenticationDefenseScenario>();
            }

            var wantedTags = CreateWantedScenarioTags();

            if (wantedTags.Count == 0)
            {
                return candidates;
            }

            var filtered = candidates.Where(ScenarioMatchesWantedTags).ToList();
            return filtered.Count > 0 ? filtered : candidates;

            bool ScenarioMatchesWantedTags(AuthenticationDefenseScenario scenario)
            {
                var tags = scenario?.Tags ?? new List<string>();

                if (tags.Count == 0)
                {
                    return false;
                }

                return tags.Any(t => wantedTags.Contains((t ?? "").Trim(), StringComparer.OrdinalIgnoreCase));
            }
        }

        private List<string> CreateWantedScenarioTags()
        {
            var tags = new List<string>();

            if (_prefs.IncludeStrength)
            {
                tags.Add("credential-stuffing");
                tags.Add("password-reuse");
                tags.Add("rate-limit");
                tags.Add("admin-access");
            }

            if (_prefs.IncludeReuse)
            {
                tags.Add("mfa");
                tags.Add("mfa-fatigue");
                tags.Add("push");
                tags.Add("user-signin");
            }

            if (_prefs.IncludeManager)
            {
                tags.Add("recovery");
                tags.Add("helpdesk");
                tags.Add("social-engineering");
            }

            if (_prefs.IncludePatterns)
            {
                tags.Add("session");
                tags.Add("token");
                tags.Add("high-risk-action");
                tags.Add("legacy-auth");
                tags.Add("bypass");
                tags.Add("remote-access");
            }

            return tags.Distinct(StringComparer.OrdinalIgnoreCase).ToList();
        }

        private AuthenticationDefenseScenario PickWeighted(List<(AuthenticationDefenseScenario scenario, double weight)> items)
        {
            if (items == null || items.Count == 0)
            {
                return null;
            }

            double total = 0.0;

            foreach (var item in items)
            {
                if (item.weight > 0)
                {
                    total += item.weight;
                }
            }

            if (total <= 0)
            {
                return items[_rng.Next(items.Count)].scenario;
            }

            var roll = _rng.NextDouble() * total;

            foreach (var item in items)
            {
                if (item.weight <= 0)
                {
                    continue;
                }

                roll -= item.weight;

                if (roll <= 0)
                {
                    return item.scenario;
                }
            }

            return items[items.Count - 1].scenario;
        }

        private double GetScenarioWeakness(AuthenticationDefenseScenario scenario)
        {
            if (scenario == null)
            {
                return 0.75;
            }

            var topic = _sharedAdaptiveLearningService.MapAuthenticationTopic(scenario);
            var mastery = _sharedAdaptiveLearningService.GetMastery01(_sharedUserModel, topic);

            return 1.0 - mastery;
        }

        private DifficultyBand FixTargetDifficulty()
        {
            var baseline = _prefs != null && _prefs.Difficulty.HasValue ? _prefs.Difficulty.Value : DifficultyBand.Medium;

            var recentAccuracy = _runLog.OrderByDescending(x => x.SubmittedUtc).Take(4).Select(GetAttemptAccuracy01).ToList();

            return _sharedAdaptiveLearningService.ResolveTargetDifficulty(recentAccuracy, baseline);
        }

        private static double GetAttemptAccuracy01(AuthenticationDefenseAttemptRow row)
        {
            if (row == null)
            {
                return 0.0;
            }

            if (row.Accuracy01.HasValue)
            {
                var value = row.Accuracy01.Value;

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

            return row.IsCorrect ? 1.0 : 0.0;
        }
        
        private static List<string> ReadTags(string json)
        {
            try
            {
                return string.IsNullOrWhiteSpace(json) ? new List<string>() : JsonConvert.DeserializeObject<List<string>>(json) ?? new List<string>();
            }

            catch
            {
                return new List<string>();
            }
        }

        private void BeginNextScenario(bool forceNewRun)
        {
            if (_allScenarios == null || _allScenarios.Count == 0)
            {
                LoadData();
            }

            if (_allScenarios == null || _allScenarios.Count == 0)
            {
                MessageBox.Show(this, "No scenarios were found.", "Mondas", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (forceNewRun)
            {
                ResetUi();
            }

            if (_prefs != null && _prefs.RoundCount > 0 && _runLog.Count >= _prefs.RoundCount)
            {
                PauseRunClock();
                MessageBox.Show(this, ShowSummary(), "Mondas", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Close();
                return;
            }

            StartRunClock();
            ResumeRunClock();

            var scenario = PickNextScenario();

            if (scenario == null)
            {
                MessageBox.Show(this, "No more scenarios are available.", "Mondas", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            _currentScenario = scenario;
            _currentScenarioResolved = false;
            _scenarioShownUtc = DateTime.UtcNow;
            _seenRun.Add(scenario.Id ?? "");

            SetDefaults();
            ShowScenario(scenario);
            ResetResult();
            AddScenarioToQueue(scenario);
            UpdateButtons();
            UpdateRunInfo();
        }

        private void AddScenarioToQueue(AuthenticationDefenseScenario scenario)
        {
            if (lvQueue == null || scenario == null)
            {
                return;
            }

            var item = new ListViewItem("LIVE");

            item.SubItems.Add((scenario.Title ?? "").ToUpperInvariant());
            item.SubItems.Add(ToUiText(scenario.Difficulty));
            item.SubItems.Add(DateTime.Now.ToString("HH:mm"));
            item.Tag = new QueueRowTag { Scenario = scenario, IsResolved = false, Result = null };

            lvQueue.BeginUpdate();
            lvQueue.Items.Add(item);
            lvQueue.EndUpdate();

            _currentQueueItem = item;
            item.Selected = true;
            item.Focused = true;
            item.EnsureVisible();
        }

        private AuthenticationDefenseSelection ReadSelection()
        {
            return new AuthenticationDefenseSelection
            {
                AuthMethod = ReadCombo<AuthMethodType>(cmbAuthMethod),
                PasswordPolicy = ReadCombo<PasswordPolicyType>(cmbPasswordPolicy),
                Recovery = ReadCombo<RecoveryType>(cmbRecovery),
                Monitoring = ReadCombo<MonitoringType>(cmbMonitoring),
                RateLimit = ReadCombo<RateLimitType>(cmbRateLimit),
                SessionControl = ReadCombo<SessionControlType>(cmbSession),
                RequireMfa = chkRequireMfa != null && chkRequireMfa.Checked,
                RequirePhishingResistant = chkPhishingResistant != null && chkPhishingResistant.Checked,
                RequireDeviceBinding = chkDeviceBinding != null && chkDeviceBinding.Checked,
                RequireRiskBasedStepUp = chkRiskBasedStepUp != null && chkRiskBasedStepUp.Checked,
                RequireBlockLegacyAuth = chkBlockLegacyAuth != null && chkBlockLegacyAuth.Checked,
                RequireAlertOnSuspicious = chkAlertOnSuspicious != null && chkAlertOnSuspicious.Checked
            };
        }

        private static T ReadCombo<T>(ComboBox cmb) where T : struct, Enum
        {
            if (cmb != null && cmb.SelectedItem is T value)
            {
                return value;
            }

            return default;
        }

        private void ApplyResult(AuthenticationDefenseResult result, double secondsTaken)
        {
            if (result == null)
            {
                return;
            }

            if (UseDeferredFeedback())
            { 
                if (lblResultsText != null)
                {
                    lblResultsText.Text = "DECISION RECORDED";
                }

                if (lblResultScoreDelta != null)
                {
                    lblResultScoreDelta.Text = "DETAILS SHOWN AT END OF ROUND";
                }

                if (lblResultWhy != null)
                {
                    lblResultWhy.Text = "FINDINGS: HIDDEN";
                }

                if (lvFindings != null)
                {
                    lvFindings.BeginUpdate();
                    lvFindings.Items.Clear();
                    lvFindings.EndUpdate();
                }

                return;
            }

            if (lblResultsText != null)
            {
                lblResultsText.Text = string.IsNullOrWhiteSpace(result.Headline) ? "RESULT" : result.Headline;
            }

            if (lblResultScoreDelta != null)
            {
                var scoreText = result.ScoreDelta >= 0 ? "+" + result.ScoreDelta.ToString(CultureInfo.InvariantCulture) : result.ScoreDelta.ToString(CultureInfo.InvariantCulture);
                var timeText = secondsTaken <= 0 ? "0s" : Math.Round(secondsTaken).ToString(CultureInfo.InvariantCulture) + "s";
                lblResultScoreDelta.Text = "SCORE: " + scoreText + " | TIME: " + timeText;
            }

            if (lblResultWhy != null)
            {
                lblResultWhy.Text = "FINDINGS: " + (result.Findings?.Count ?? 0).ToString(CultureInfo.InvariantCulture);
            }

            ShowFindings(result.Findings ?? new List<AuthenticationDefenseFinding>());
        }

        private void ShowFindings(List<AuthenticationDefenseFinding> findings)
        {
            if (lvFindings == null)
            {
                return;
            }

            lvFindings.BeginUpdate();
            lvFindings.Items.Clear();

            foreach (var finding in findings)
            {
                var item = new ListViewItem((finding.Title ?? "").ToUpperInvariant());

                item.SubItems.Add(finding.Detail ?? "");
                item.SubItems.Add((finding.Impact.ToString() ?? "").ToUpperInvariant());

                lvFindings.Items.Add(item);
            }

            lvFindings.EndUpdate();
        }

        private void SaveAttempt(AuthenticationDefenseResult result, double secondsTaken)
        {
            if (_currentScenario == null || result == null)
            {
                return;
            }

            var row = new AuthenticationDefenseAttemptRow
            {
                UserKey = _userKey,
                ScenarioId = _currentScenario.Id ?? "",
                IsCorrect = result.IsCorrect,
                ScoreDelta = result.ScoreDelta,
                SecondsTaken = secondsTaken,
                Accuracy01 = result.Accuracy01,
                SubmittedUtc = DateTime.UtcNow,
                TagsJson = JsonConvert.SerializeObject(_currentScenario.Tags ?? new List<string>()),
                FindingsJson = JsonConvert.SerializeObject(result.Findings ?? new List<AuthenticationDefenseFinding>()),
                ScenarioSnapshotJson = JsonConvert.SerializeObject(_currentScenario)
            };

            _attemptStore.Add(row);
            _history.Insert(0, row);
            _runLog.Add(row);

            var topic = _sharedAdaptiveLearningService.MapAuthenticationTopic(_currentScenario);
            var tags = ReadTags(row.TagsJson);

            _sharedUserModel.UpdateTopicAttempt(topic, row.Accuracy01 ?? (row.IsCorrect ? 1.0 : 0.0), (row.Accuracy01 ?? (row.IsCorrect ? 1.0 : 0.0)) >= 0.999 ? null : tags);
        }

        private void MarkQueueResolved(AuthenticationDefenseResult result)
        {
            if (_currentQueueItem == null || result == null)
            {
                return;
            }

            _currentQueueItem.Text = result.IsCorrect ? "PASS" : "MISS";

            if (_currentQueueItem.Tag is QueueRowTag tag)
            {
                tag.IsResolved = true;
                tag.Result = result;
            }
        }

        private string ShowHints(AuthenticationDefenseScenario scenario)
        {
            if (scenario == null)
            {
                return "No scenario selected.";
            }

            if (_prefs != null && _prefs.HintMode == MiniGameHintMode.Off)
            {
                return "Hints are turned off for this run.";
            }

            var hints = scenario.Hints ?? new List<string>();
            hints = hints.Where(x => !string.IsNullOrWhiteSpace(x)).Select(x => x.Trim()).ToList();

            if (hints.Count == 0)
            {
                return "No hints available for this scenario.";
            }

            if (_prefs != null && _prefs.HintMode == MiniGameHintMode.Basic)
            {
                return "• " + hints[0];
            }

            return string.Join(Environment.NewLine + Environment.NewLine, hints.Select(x => "• " + x));
        }

        private string ShowSummary()
        {
            var total = _runLog.Count;
            var correct = _runLog.Count(x => x.IsCorrect);
            var accuracy = total == 0 ? 0.0 : (correct * 100.0 / total);

            var timed = _runLog.Where(x => x.SecondsTaken > 0).ToList();
            var avg = timed.Count == 0 ? 0.0 : timed.Average(x => x.SecondsTaken);

            TimeSpan elapsed;

            if (!_runStarted)
            {
                elapsed = TimeSpan.Zero;
            }

            else
            {
                elapsed = _runClockPaused ? _runClockFrozen : (DateTime.UtcNow - _runStartedUtc);
            }

            return "Run complete!\n\nCorrect: " + correct + "/" + total + " (" + accuracy.ToString("0", CultureInfo.InvariantCulture) + "%)\nScore: " + _score + "\nTime: " + FormatTime(elapsed) + "\nAvg decision time: " + (avg <= 0 ? "-" : avg.ToString("0.0", CultureInfo.InvariantCulture) + "s");
        }

        private void ShowQueueSelection(ListViewItem item)
        {
            if (item == null || item.Tag is not QueueRowTag tag || tag.Scenario == null)
            {
                return;
            }

            _currentScenario = tag.Scenario;
            _currentScenarioResolved = tag.IsResolved;
            _currentQueueItem = item;

            ShowScenario(tag.Scenario);

            if (tag.Result != null)
            {
                if (UseDeferredFeedback())
                {
                    if (lblResultsText != null)
                    {
                        lblResultsText.Text = "DECISION RECORDED";
                    }

                    if (lblResultScoreDelta != null)
                    {
                        lblResultScoreDelta.Text = "DETAILS SHOWN AT END OF ROUND";
                    }

                    if (lblResultWhy != null)
                    {
                        lblResultWhy.Text = "FINDINGS: HIDDEN";
                    }

                    if (lvFindings != null)
                    {
                        lvFindings.BeginUpdate();
                        lvFindings.Items.Clear();
                        lvFindings.EndUpdate();
                    }
                }

                else
                {
                    ApplyResult(tag.Result, 0.0);
                }
            }

            else
            {
                ResetResult();
            }

            UpdateButtons();
        }

        private bool UseDeferredFeedback()
        {
            return _prefs != null && _prefs.FeedbackMode == MiniGameFeedbackMode.EndOfRound;
        }

        private void AuthenticationControlChanged()
        {
            UpdateButtons();
        }

        private sealed class QueueRowTag
        {
            public AuthenticationDefenseScenario Scenario { get; set; }
            public bool IsResolved { get; set; }
            public AuthenticationDefenseResult Result { get; set; }
        }

        private void lvQueue_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvQueue == null || lvQueue.SelectedItems.Count == 0)
            {
                return;
            }

            ShowQueueSelection(lvQueue.SelectedItems[0]);
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            var start = new Start();
            start.Show();
            Close();
        }

        private void btnViewHints_Click(object sender, EventArgs e)
        {
            MessageBox.Show(this, ShowHints(_currentScenario), "Scenario Hints", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void cmbAuthMethod_SelectedIndexChanged(object sender, EventArgs e)
        {
            AuthenticationControlChanged();
        }

        private void cmbPasswordPolicy_SelectedIndexChanged(object sender, EventArgs e)
        {
            AuthenticationControlChanged();
        }

        private void cmbRecovery_SelectedIndexChanged(object sender, EventArgs e)
        {
            AuthenticationControlChanged();
        }

        private void cmbMonitoring_SelectedIndexChanged(object sender, EventArgs e)
        {
            AuthenticationControlChanged();
        }

        private void cmbRateLimit_SelectedIndexChanged(object sender, EventArgs e)
        {
            AuthenticationControlChanged();
        }

        private void cmbSession_SelectedIndexChanged(object sender, EventArgs e)
        {
            AuthenticationControlChanged();
        }

        private void chkRequireMfa_CheckedChanged(object sender, EventArgs e)
        {
            AuthenticationControlChanged();
        }

        private void chkPhishingResistant_CheckedChanged(object sender, EventArgs e)
        {
            AuthenticationControlChanged();
        }

        private void chkDeviceBinding_CheckedChanged(object sender, EventArgs e)
        {
            AuthenticationControlChanged();
        }

        private void chkRiskBasedStepUp_CheckedChanged(object sender, EventArgs e)
        {
            AuthenticationControlChanged();
        }

        private void chkBlockLegacyAuth_CheckedChanged(object sender, EventArgs e)
        {
            AuthenticationControlChanged();
        }

        private void chkAlertOnSuspicious_CheckedChanged(object sender, EventArgs e)
        {
            AuthenticationControlChanged();
        }

        private void btnRunSimulation_Click(object sender, EventArgs e)
        {
            if (_currentScenario == null)
            {
                MessageBox.Show(this, "Click NEW SCENARIO first.", "Mondas", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (_currentScenarioResolved)
            {
                MessageBox.Show(this, "This scenario has already been resolved. Click 'NEXT SCENARIO' to continue.", "Mondas", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var selection = ReadSelection();
            var secondsTaken = Math.Max(0.0, (DateTime.UtcNow - _scenarioShownUtc).TotalSeconds);
            var result = _scoring.Evaluate(_currentScenario, selection, secondsTaken);

            ApplyResult(result, secondsTaken);
            SaveAttempt(result, secondsTaken);
            MarkQueueResolved(result);

            _currentScenarioResolved = true;
            PauseRunClock();

            _score += result.ScoreDelta;

            if (result.IsCorrect)
            {
                _streak++;
            }

            else
            {
                _streak = 0;
            }

            UpdateButtons();
            UpdateRunInfo();
        }

        private void btnClearBuild_Click(object sender, EventArgs e)
        {
            SetDefaults();
        }

        private void lvFindings_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnNewScenario_Click(object sender, EventArgs e)
        {
            BeginNextScenario(forceNewRun: false);
        }

        private void btnFinishRun_Click(object sender, EventArgs e)
        {
            if (!_runStarted || _runLog.Count == 0)
            {
                Close();
                return;
            }

            var ok = MessageBox.Show(this, "Finish this run and show the summary?", "Mondas", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

            if (ok != DialogResult.OK)
            {
                return;
            }

            PauseRunClock();
            MessageBox.Show(this, ShowSummary(), "Mondas", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Close();
        }

        private void btnResetRun_Click(object sender, EventArgs e)
        {
            var ok = MessageBox.Show(this, "Reset the current run?", "Mondas", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

            if (ok != DialogResult.OK)
            {
                return;
            }

            ResetUi();
        }

        private void btnNextScenario_Click(object sender, EventArgs e)
        {
            if (_currentScenario == null)
            {
                BeginNextScenario(forceNewRun: false);
                return;
            }

            if (!_currentScenarioResolved)
            {
                MessageBox.Show(this, "Run the simulation first.", "Mondas", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            BeginNextScenario(forceNewRun: false);
        }

        private void tmrRun_Tick(object sender, EventArgs e)
        {
            UpdateRunInfo();
        }
    }
}