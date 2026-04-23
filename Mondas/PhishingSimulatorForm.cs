using Syncfusion.WinForms.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Mondas.Models;
using Mondas.Services;
using Newtonsoft.Json;

namespace Mondas
{
    public partial class PhishingSimulatorForm : SfForm
    {
        private readonly string _emailsJsonPath;
        private readonly string _dbPath;
        private readonly string _userKey;

        private PhishingEmailRepository _emailsRepo;
        private PhishingAttemptStore _attemptStore;

        private PhishingEngineV1 _engine;
        private PhishingScoringV1 _scoring;

        private readonly HashSet<int> _seenRun = new HashSet<int>();
        private readonly HashSet<PhishingAction> _actionsUsedOnEmail = new HashSet<PhishingAction>();
        private readonly List<PhishingAttemptRow> _runLog = new List<PhishingAttemptRow>();

        private PhishingEmail _currentEmail;
        private DateTime _emailStartedUtc;

        private int _score;
        private int _streak;
        private int _shownCount;

        private string _lastReason = "";
        private List<string> _lastRules = new List<string>();
        private Timer _uiTimer;

        private DateTime _runStartedUtc;
        private IReadOnlyList<PhishingEmail> _allEmails = Array.Empty<PhishingEmail>();
        private List<PhishingAttemptRow> _history = new List<PhishingAttemptRow>();
        private ListViewItem _currentInboxItem;
        private bool _currentEmailResolved;

        private bool _runStarted;
        private bool _runClockPaused;
        private TimeSpan _runClockFrozen;

        private readonly MiniGamePreferences _prefs;
        private int _resolvedFinalCount;
        private int _targetEmails;

        private readonly SharedAdaptiveLearningService _sharedAdaptiveLearningService;
        private UserModel _sharedUserModel = new UserModel();

        public PhishingSimulatorForm() : this("local", MiniGamePreferences.CreateDefault(MiniGameType.PhishingSimulator))
        {
        }

        public PhishingSimulatorForm(string userKey) : this(userKey, MiniGamePreferences.CreateDefault(MiniGameType.PhishingSimulator))
        { 
        }

        public PhishingSimulatorForm(string userKey, MiniGamePreferences prefs)
        {
            InitializeComponent();

            _userKey = string.IsNullOrWhiteSpace(userKey) ? "local" : userKey.Trim();
            _dbPath = Path.Combine(AppContext.BaseDirectory, "mondas.db");
            _emailsJsonPath = ResolveEmailsJsonPath();
            _prefs = MiniGamePreferences.Normalise(prefs);
            _targetEmails = Math.Max(1, _prefs.PhishingEmailCount > 0 ? _prefs.PhishingEmailCount : _prefs.RoundCount);
            _sharedAdaptiveLearningService = new SharedAdaptiveLearningService(_dbPath, FindQuestionsPath());
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

        private string ResolveEmailsJsonPath()
        {
            var baseDir = AppContext.BaseDirectory;

            var p1 = Path.Combine(baseDir, "phishing_emails.json");

            if (File.Exists(p1))
            {
                return p1;
            }

            var p2 = Path.Combine(baseDir, "Resources", "phishing_emails.json");

            if (File.Exists(p2))
            {
                return p2;
            }

            var p3 = Path.Combine(baseDir, "Data", "phishing_emails.json");

            if (File.Exists(p3))
            {
                return p3;
            }

            return p1;
        }

        private void PhishingSimulatorForm_Load(object sender, EventArgs e)
        {
            if (LicenseManager.UsageMode == LicenseUsageMode.Designtime)
            {
                return;
            }

            WindowState = FormWindowState.Maximized;

            _emailsRepo = new PhishingEmailRepository(_emailsJsonPath);
            _attemptStore = new PhishingAttemptStore(_dbPath);

            _engine = new PhishingEngineV1(focusWeakTags: true, preferredDifficulty: _prefs.Difficulty ?? DifficultyBand.Medium, allowDifficultyDrift: true);
            _scoring = new PhishingScoringV1();

            CreateInboxList();
            CreateSignalsList();
            LoadData();
            SetDefaultUi();
            EnsureTimer();
        }

        private void LoadData()
        {
            try
            {
                var raw = _emailsRepo.LoadAll() ?? Array.Empty<PhishingEmail>();
                var filtered = raw.Where(MatchesPreferences).ToList();
                _allEmails = filtered.Count > 0 ? filtered : raw;
            }

            catch
            {
                _allEmails = Array.Empty<PhishingEmail>();
            }

            try
            {
                _history = _attemptStore.GetForUser(_userKey, limit: 5000) ?? new List<PhishingAttemptRow>();
            }

            catch
            {
                _history = new List<PhishingAttemptRow>();
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

        private IReadOnlyList<PhishingEmail> AdaptiveEmailPool()
        {
            if (_allEmails == null || _allEmails.Count == 0)
            {
                return Array.Empty<PhishingEmail>();
            }

            var unseen = _allEmails.Where(x => x != null && !_seenRun.Contains(x.Id)).ToList();

            if (unseen.Count == 0)
            {
                return _allEmails;
            }

            var availableTopics = unseen.Select(x => _sharedAdaptiveLearningService.MapPhishingTopic(x)).Distinct().ToList();

            var weakestTopic = _sharedAdaptiveLearningService.GetWeakestTopic(_sharedUserModel, availableTopics);

            if (!weakestTopic.HasValue)
            {
                return unseen;
            }

            var focused = unseen.Where(x => _sharedAdaptiveLearningService.MapPhishingTopic(x) == weakestTopic.Value).ToList();

            return focused.Count > 0 ? focused : unseen;
        }

        private bool MatchesPreferences(PhishingEmail email)
        {
            if (email == null)
            {
                return false;
            }

            if (_prefs.Difficulty.HasValue && email.Difficulty != _prefs.Difficulty.Value)
            {
                return false;
            }

            if (!_prefs.IncludeLinks && email.HasLink)
            {
                return false;
            }

            if (!_prefs.IncludeAttachments && email.HasAttachment)
            {
                return false;
            }

            if (!_prefs.IncludeUrgency && LooksUrgent(email))
            {
                return false;
            }

            return true;
        }

        private static bool LooksUrgent(PhishingEmail email)
        {
            var subject = (email?.Subject ?? "").ToUpperInvariant();
            var body = (email?.Body ?? "").ToUpperInvariant();

            return subject.Contains("URGENT") || subject.Contains("IMMEDIATE") || subject.Contains("ACTION REQUIRED") || body.Contains("URGENT") || body.Contains("IMMEDIATE") || body.Contains("ACTION REQUIRED") || body.Contains("SUSPEND") || body.Contains("LOCK");
        }

        private void EnsureTimer()
        {
            if (_uiTimer != null)
            {
                return;
            }

            _uiTimer = new Timer { Interval = 250 };
            _uiTimer.Tick += (_, __) =>
            {
                try
                {
                    UpdateRunInfo();
                }

                catch
                {

                }
            };

            _uiTimer.Start();
        }

        private void CreateInboxList()
        {
            if (lvInbox == null)
            {
                return;
            }

            lvInbox.BeginUpdate();
            
            lvInbox.View = View.Details;
            lvInbox.FullRowSelect = true;
            lvInbox.MultiSelect = false;
            lvInbox.HeaderStyle = ColumnHeaderStyle.Nonclickable;

            if (lvInbox.Columns.Count == 0)
            {
                lvInbox.Columns.Add("TYPE", 90, HorizontalAlignment.Left);
                lvInbox.Columns.Add("SENDER", 210, HorizontalAlignment.Left);
                lvInbox.Columns.Add("SUBJECT", 320, HorizontalAlignment.Left);
                lvInbox.Columns.Add("TIME", 90, HorizontalAlignment.Center);
            }

            else
            {
                lvInbox.Columns[0].Text = "TYPE";
                lvInbox.Columns[1].Text = "SENDER";
                lvInbox.Columns[2].Text = "SUBJECT";
                lvInbox.Columns[3].Text = "TIME";
            }

            lvInbox.Items.Clear();

            lvInbox.SelectedIndexChanged += (_, __) =>
            {
                try
                {
                    InboxSelectionChanged();
                }

                catch
                {

                }
            };

            lvInbox.EndUpdate();
        }

        private void CreateSignalsList()
        {
            if (lvSignals == null)
            {
                return;
            }

            lvSignals.BeginUpdate();
            lvSignals.View = View.Details;
            lvSignals.FullRowSelect = true;
            lvSignals.MultiSelect = false;
            lvSignals.HeaderStyle = ColumnHeaderStyle.Nonclickable;
            lvSignals.Scrollable = true;

            while (lvSignals.Columns.Count < 3)
            {
                lvSignals.Columns.Add("", 100, HorizontalAlignment.Left);
            }

            lvSignals.Columns[0].Text = "SIGNAL";
            lvSignals.Columns[1].Text = "DETAIL";
            lvSignals.Columns[2].Text = "Weight";

            lvSignals.Columns[0].TextAlign = HorizontalAlignment.Left;
            lvSignals.Columns[1].TextAlign = HorizontalAlignment.Left;
            lvSignals.Columns[2].TextAlign = HorizontalAlignment.Center;

            var total = lvSignals.ClientSize.Width;

            lvSignals.Columns[0].Width = 220;
            lvSignals.Columns[1].Width = 800;
            lvSignals.Columns[2].Width = 70;

            lvSignals.Items.Clear();
            lvSignals.EndUpdate();
        }

        private void SetDefaultUi()
        {
            _currentEmail = null;
            _currentInboxItem = null;
            _currentEmailResolved = false;
            _actionsUsedOnEmail.Clear();
            _seenRun.Clear();
            _runLog.Clear();

            _score = 0;
            _streak = 0;
            _shownCount = 0;
            _resolvedFinalCount = 0;

            _lastReason = "";
            _lastRules = new List<string>();
            _targetEmails = Math.Max(1, _prefs.PhishingEmailCount > 0 ? _prefs.PhishingEmailCount : _prefs.RoundCount);

            _runStarted = false;
            _runClockPaused = true;
            _runClockFrozen = TimeSpan.Zero;
            _runStartedUtc = DateTime.UtcNow;

            if (lblFrom != null)
            {
                lblFrom.Text = "-";
            }

            if (lblTo != null)
            {
                lblTo.Text = "-";
            }

            if (lblSubject != null)
            {
                lblSubject.Text = "-";
            }

            if (lblReceived != null)
            {
                lblReceived.Text = "-";
            }

            if (rtbMessageBody != null)
            {
                rtbMessageBody.ReadOnly = true;
                rtbMessageBody.Text = "";
            }

            if (lvInbox != null)
            {
                lvInbox.BeginUpdate();
                lvInbox.Items.Clear();
                lvInbox.EndUpdate();
            }

            if (btnViewDetails != null)
            {
                btnViewDetails.Enabled = false;
            }

            if (btnTrust != null)
            {
                btnTrust.Enabled = false;
            }

            if (btnReportPhish != null)
            {
                btnReportPhish.Enabled = false;
            }

            if (btnOpenLink != null)
            {
                btnOpenLink.Enabled = false;
            }

            if (btnOpenAtt != null)
            {
                btnOpenAtt.Enabled = false;
            }

            if (btnNextEmail != null)
            {
                btnNextEmail.Enabled = false;
                btnNextEmail.Text = "NEXT EMAIL";
            }

            if (lblResultTitle != null)
            {
                lblResultTitle.Text = "RESULT";
            }

            if (lblResultText != null)
            {
                lblResultText.Text = "-";
            }

            if (lblResultScoreDelta != null)
            {
                lblResultScoreDelta.Text = "+0 SCORE | +0s";
            }

            if (lblResultWhy != null)
            {
                lblResultWhy.Text = "SIGNALS: -";
            }

            if (lvSignals != null)
            {
                lvSignals.BeginUpdate();
                lvSignals.Items.Clear();
                lvSignals.EndUpdate();
            }

            UpdateRunInfo();

            if (pnlResult != null)
            {
                pnlResult.Visible = false;
            }
        }

        private void UpdateRunInfo()
        {
            if (lblRunInfo == null)
            {
                return;
            }

            var progress = $"{_resolvedFinalCount}/{_targetEmails}";

            if (!_prefs.TimerEnabled)
            {
                lblRunInfo.Text = $"SCORE: {_score} | STREAK: {_streak} | EMAILS: {progress}";
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

            lblRunInfo.Text = $"SCORE: {_score} | STREAK: {_streak} | EMAILS: {progress} | TIME: {FormatTime(elapsed)}";
        }

        private static string FormatTime(TimeSpan timespan)
        {
            var mins = (int)timespan.TotalMinutes;
            var secs = timespan.Seconds;

            return mins.ToString("00") + "." + secs.ToString("00");
        }

        private bool UseDeferredFeedback()
        {
            return _prefs != null && _prefs.FeedbackMode == MiniGameFeedbackMode.EndOfRound;
        }

        private void btnNewEmail_Click(object sender, EventArgs e)
        {
            if (_resolvedFinalCount >= _targetEmails)
            {
                btnFinishRun_Click(sender, e);
                return;
            }

            StartNewEmail(forceNewRun: false);
        }

        private void btnResetRun_Click(object sender, EventArgs e)
        {
            var ok = MessageBox.Show(this, "Are you sure you want to reset this run?", "Mondas", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

            if (ok != DialogResult.OK)
            {
                return;
            }

            SetDefaultUi();
            StartNewEmail(forceNewRun: true);
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnViewDetails_Click(object sender, EventArgs e)
        {
            if (_currentEmail == null)
            {
                return;
            }

            if (UseDeferredFeedback() && _currentEmailResolved && _resolvedFinalCount < _targetEmails)
            {
                MessageBox.Show(this, "Detailed feedback is hidden until the run ends.", "Mondas", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            PhishingDecisionResult decision = null;

            if (_currentEmailResolved)
            {
                try
                {
                    var last = _runLog.LastOrDefault(x => x != null && x.EmailId == _currentEmail.Id.ToString(CultureInfo.InvariantCulture));

                    if (last != null && !string.IsNullOrWhiteSpace(last.SignalsJson))
                    {
                        decision = new PhishingDecisionResult
                        {
                            Action = (PhishingAction)last.Action,
                            IsCorrect = last.IsCorrect,
                            ScoreDelta = last.ScoreDelta,
                            TimePenaltySeconds = 0.0,
                            Headline = last.IsCorrect ? "FINAL DECISION" : "FINAL DECISION",
                            Explanation = _currentEmail.Explanation ?? "",
                            Signals = JsonConvert.DeserializeObject<List<PhishingSignal>>(last.SignalsJson) ?? new List<PhishingSignal>(),
                            RulesFired = _lastRules ?? new List<string>(),
                            ReasonString = _lastReason ?? ""};
                    }
                }

                catch
                {
                    decision = null;
                }
            }

            if (decision == null)
            {
                decision = new PhishingDecisionResult
                {
                    Action = PhishingAction.TrustKeep,
                    IsCorrect = false,
                    ScoreDelta = 0,
                    TimePenaltySeconds = 0.0,
                    Headline = "NOT SUBMITTED",
                    Explanation = _currentEmail.Explanation ?? "",
                    Signals = new List<PhishingSignal>(),
                    RulesFired = _lastRules ?? new List<string>(),
                    ReasonString = _lastReason ?? ""};
            }

            using var dlg = new PhishingDetailsForm();
            dlg.Bind(email: _currentEmail, decision: decision, engineReason: _lastReason ?? "", rules: _lastRules ?? new List<string>(), received: DateTime.Now);
            dlg.ShowDialog(this);
        }

        private void btnTrust_Click(object sender, EventArgs e)
        {
            ButtonClicked(PhishingAction.TrustKeep);
        }

        private void btnReportPhish_Click(object sender, EventArgs e)
        {
            ButtonClicked(PhishingAction.ReportPhishing);
        }

        private void btnOpenLink_Click(object sender, EventArgs e)
        {
            ButtonClicked(PhishingAction.OpenLink);
        }

        private void btnOpenAtt_Click(object sender, EventArgs e)
        {
            ButtonClicked(PhishingAction.OpenAttachment);
        }

        private void btnNextEmail_Click(object sender, EventArgs e)
        {
            if (_currentEmail == null)
            {
                StartNewEmail(forceNewRun: false);
                return;
            }

            if (!_currentEmailResolved)
            {
                MessageBox.Show(this, "Make a final decision first (Trust/Keep or Report Phishing),", "Mondas", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (_resolvedFinalCount >= _targetEmails)
            {
                btnFinishRun_Click(sender, e);
                return;
            }

            StartNewEmail(forceNewRun: false);
        }

        private void StartNewEmail(bool forceNewRun)
        {
            StartRunClock();
            ResumeRunClock();

            if (_allEmails == null || _allEmails.Count == 0)
            {
                LoadData();
            }

            if (_allEmails == null || _allEmails.Count == 0)
            {
                MessageBox.Show(this, "Unable to find any phishing emails.\n\nCheck phishing_emails.json.", "Mondas", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (forceNewRun)
            {
                _seenRun.Clear();
                _runLog.Clear();

                _shownCount = 0;
                _runStartedUtc = DateTime.UtcNow;

                if (lvInbox != null)
                {
                    lvInbox.BeginUpdate();
                    lvInbox.Items.Clear();
                    lvInbox.EndUpdate();
                }

                _runStarted = true;
                _runClockPaused = false;
                _runClockFrozen = TimeSpan.Zero;
                _runStartedUtc = DateTime.UtcNow;
            }

            ResumeRunClock();

            var adaptivePool = AdaptiveEmailPool();

            var pick = _engine.PickNext(allEmails: adaptivePool, history: _history ?? new List<PhishingAttemptRow>(), seenThisRun: _seenRun, tagMastery: GetTagMastery);

            if (pick.email ==  null)
            {
                MessageBox.Show(this, pick.reason ?? "No more emails to see.", "Mondas", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            _currentEmail = pick.email;
            _lastReason = pick.reason ?? "";
            _lastRules = pick.rulesFired ?? new List<string>();
            _emailStartedUtc = DateTime.UtcNow;

            _actionsUsedOnEmail.Clear();
            _currentEmailResolved = false;

            _seenRun.Add(_currentEmail.Id);
            _shownCount++;

            AddEmailToInbox(_currentEmail);
            ShowCurrentEmail();

            ResetResult();

            if (btnViewDetails != null)
            {
                btnViewDetails.Enabled = true;
            }

            SetButtonsEnabled(enabled: true);
            ApplyActionToEmail(_currentEmail);

            if (btnNextEmail != null)
            {
                btnNextEmail.Enabled = false;
                btnNextEmail.Text = "NEXT EMAIL";
            }

            UpdateRunInfo();
        }

        private void AddEmailToInbox(PhishingEmail email)
        {
            if (lvInbox == null || email == null)
            {
                return;
            }

            var timeText = DateTime.Now.ToString("HH:mm");
            var typeText = "?";
            var senderText = BuildSenderDisplay(email);
            var subjectText = (email.Subject ?? "").Trim();
            var item = new ListViewItem(typeText);

            item.SubItems.Add(senderText);
            item.SubItems.Add(subjectText);
            item.SubItems.Add(timeText);

            item.Tag = new InboxRowTag { EmailId = email.Id, Email = email, IsResolved = false, DisplayType = typeText };

            lvInbox.BeginUpdate();
            lvInbox.Items.Add(item);
            lvInbox.EndUpdate();
            _currentInboxItem = item;

            try
            {
                item.Selected = true;
                item.Focused = true;
                item.EnsureVisible();
            }

            catch
            {

            }
        }

        private static string BuildSenderDisplay(PhishingEmail email)
        {
            var name = (email.SenderName ?? "").Trim();
            var emailAddress = (email.SenderEmail ?? "").Trim();

            if (name.Length == 0 && emailAddress.Length == 0)
            {
                return "-";
            }

            if (name.Length == 0)
            {
                return emailAddress;
            }

            if (emailAddress.Length == 0)
            {
                return name;
            }

            return name + " <" + emailAddress + ">";
        }

        private void ShowCurrentEmail()
        {
            if (_currentEmail == null)
            {
                return;
            }

            if (lblFrom != null)
            {
                lblFrom.Text = BuildSenderDisplay(_currentEmail);
            }

            if (lblTo != null)
            {
                var to = (_currentEmail.ToEmail ?? "").Trim();
                lblTo.Text = to.Length == 0 ? "-" : to;
            }

            if (lblSubject != null)
            {
                var subj = (_currentEmail.Subject ?? "").Trim();
                lblSubject.Text = subj.Length == 0 ? "-" : subj;
            }

            if (lblReceived != null)
            {
                lblReceived.Text = DateTime.Now.ToString("dd MMM yyyy HH:mm");
            }

            if (rtbMessageBody != null)
            {
                rtbMessageBody.Text = (_currentEmail.Body ?? "").Replace("\r\n", "\n");
                rtbMessageBody.SelectionStart = 0;
                rtbMessageBody.SelectionLength = 0;
            }
        }

        private void ResetResult()
        {
            if (lblResultTitle != null)
            {
                lblResultTitle.Text = "RESULT";
            }

            if (lblResultText != null)
            {
                lblResultText.Text = "-";
            }

            if (lblResultScoreDelta != null)
            {
                lblResultScoreDelta.Text = "+0 SCORE | +0s";
            }

            if (lblResultWhy != null)
            {
                lblResultWhy.Text = "SIGNALS: -";
            }

            if (lvSignals != null)
            {
                lvSignals.BeginUpdate();
                lvSignals.Items.Clear();
                lvSignals.EndUpdate();
            }

            if (pnlResult != null)
            {
                pnlResult.Visible = false;
            }
        }

        private void ButtonClicked(PhishingAction action)
        {
            if (_currentEmail == null)
            {
                MessageBox.Show(this, "Click 'NEW EMAIL' first.", "Mondas", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (_currentEmailResolved)
            {
                MessageBox.Show(this, "Email has already been resolved. Click 'NEXT EMAIL' to continue.", "Mondas", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (_actionsUsedOnEmail.Contains(action))
            {
                MessageBox.Show(this, "Action has already been used on email.", "Mondas", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (action == PhishingAction.OpenLink && !_currentEmail.HasLink)
            {
                ShowResult("Nothing to open", "No link found in email.", 0, 0.0, null);
                _actionsUsedOnEmail.Add(action);
                return;
            }

            if (action == PhishingAction.OpenAttachment && !_currentEmail.HasAttachment)
            {
                ShowResult("Nothing to open", "No attachment found in this email.", 0, 0.0, null);
                _actionsUsedOnEmail.Add(action);
                return;
            }

            var secondsTaken = (DateTime.UtcNow - _emailStartedUtc).TotalSeconds;

            var decision = _scoring.Evaluate(email: _currentEmail, action: action, secondsTaken: secondsTaken, reasonString: _lastReason ?? "", rulesFired: _lastRules ?? new List<string>());

            _actionsUsedOnEmail.Add(action);

            var isFinal = action == PhishingAction.TrustKeep || action == PhishingAction.ReportPhishing;

            ApplyDecision(decision, secondsTaken);

            SaveAttemptRow(decision, secondsTaken);

            if (isFinal)
            {
                _currentEmailResolved = true;
                _resolvedFinalCount++;

                UpdateModelFromFinalDecision(decision);

                PauseRunClock();

                if (decision.IsCorrect)
                {
                    _streak++;
                }

                else
                {
                    _streak = 0;
                }

                _score += decision.ScoreDelta;

                MarkInboxRowResolved(decision);

                if (btnNextEmail != null)
                {
                    btnNextEmail.Enabled = true;
                    btnNextEmail.Text = _resolvedFinalCount >= _targetEmails ? "FINISH RUN" : "NEXT EMAIL";
                }

                SetButtonsEnabled(enabled: false);
            }

            else
            {
                _score += decision.ScoreDelta;

                if (btnNextEmail != null)
                {
                    btnNextEmail.Enabled = false;
                    btnNextEmail.Text = "NEXT EMAIL";
                }

                ApplyActionToEmail(_currentEmail);
            }

            UpdateRunInfo();
        }

        private void ApplyDecision(PhishingDecisionResult decision, double secondsTaken)
        {
            if (decision == null)
            {
                return;
            }

            if (pnlResult != null)
            {
                pnlResult.Visible = true;
            }

            if (UseDeferredFeedback())
            {
                if (lblResultTitle != null)
                {
                    lblResultTitle.Text = "DECISION RECORDED";
                }

                if (lblResultText != null)
                {
                    lblResultText.Text = "Detailed feedback will be shown at the end of the run.";
                }

                if (lblResultScoreDelta != null)
                {
                    lblResultScoreDelta.Text = "DETAILS HIDDEN";
                }

                if (lblResultWhy != null)
                {
                    lblResultWhy.Text = "SIGNALS: HIDDEN";
                }

                if (lvSignals != null)
                {
                    lvSignals.BeginUpdate();
                    lvSignals.Items.Clear();
                    lvSignals.EndUpdate();
                }

                return;
            }

            if (lblResultTitle != null)
            {
                lblResultTitle.Text = string.IsNullOrWhiteSpace(decision.Headline) ? "RESULT" : decision.Headline;
            }

            if (lblResultText != null)
            {
                lblResultText.Text = string.IsNullOrWhiteSpace(decision.Explanation) ? "-" : decision.Explanation;
            }

            if (lblResultScoreDelta != null)
            {
                var s = decision.ScoreDelta >= 0 ? "+" + decision.ScoreDelta.ToString() : decision.ScoreDelta.ToString();
                var t = decision.TimePenaltySeconds <= 0 ? "+0s" : ("+" + Math.Round(decision.TimePenaltySeconds).ToString(CultureInfo.InvariantCulture) + "s");
                
                lblResultScoreDelta.Text = s + " SCORE | " + t;
            }

            if (lblResultWhy != null)
            {
                lblResultWhy.Text = decision.Signals == null || decision.Signals.Count == 0 ? "SIGNALS: =" : "SIGNALS: " + decision.Signals.Count.ToString();
            }

            RenderSignals(decision.Signals);
        }

        private void RenderSignals(List<PhishingSignal> signals)
        {
            if (lvSignals == null)
            {
                return;
            }

            lvSignals.BeginUpdate();
            lvSignals.Items.Clear();

            if (signals != null)
            {
                for (int i = 0; i < signals.Count; i++)
                {
                    var signal = signals[i];
                    var item = new ListViewItem((signal.Title ?? "").Trim());

                    item.SubItems.Add((signal.Detail ?? "").Trim());
                    item.SubItems.Add(signal.Weight.ToString());
                    lvSignals.Items.Add(item);
                }
            }

            lvSignals.EndUpdate();
        }

        private void ShowResult(string title, string text, int scoreDelta, double timePenaltySeconds, List<PhishingSignal> signals)
        {
            if (pnlResult != null)
            {
                pnlResult.Visible = true;
            }

            if (lblResultTitle != null)
            {
                lblResultTitle.Text = string.IsNullOrWhiteSpace(title) ? "RESULT" : title;
            }

            if (lblResultText != null)
            {
                lblResultText.Text = string.IsNullOrWhiteSpace(text) ? "-" : text;
            }

            if (lblResultScoreDelta != null)
            {
                var s = scoreDelta >= 0 ? "+" + scoreDelta.ToString() : scoreDelta.ToString();
                var t = timePenaltySeconds <= 0 ? "+0s" : ("+" + Math.Round(timePenaltySeconds).ToString(CultureInfo.InvariantCulture) + "s");
                
                lblResultScoreDelta.Text = s + " SCORE | " + t;
            }

            if (lblResultWhy != null)
            {
                lblResultWhy.Text = "SIGNALS: -";
            }

            RenderSignals(signals ?? new List<PhishingSignal>());
        }

        private void SaveAttemptRow(PhishingDecisionResult decision, double secondsTaken)
        {
            if (_attemptStore == null || _currentEmail == null || decision == null)
            {
                return;
            }

            var signalsJson = "[]";

            try
            {
                signalsJson = JsonConvert.SerializeObject(decision.Signals ?? new List<PhishingSignal>());
            }

            catch
            {
                signalsJson = "[]";
            }

            var snapJson = "{}";

            try
            {
                snapJson = JsonConvert.SerializeObject(_currentEmail);
            }

            catch
            {
                snapJson = "{}";
            }

            var row = new PhishingAttemptRow { UserKey = _userKey, EmailId = _currentEmail.Id.ToString(CultureInfo.InvariantCulture), Action = (int)decision.Action, IsCorrect = decision.IsCorrect, ScoreDelta = decision.ScoreDelta, SecondsTaken = secondsTaken, SubmittedUtc = DateTime.UtcNow, ReasonString = _lastReason ?? "", SignalsJson = signalsJson, EmailSnapshotJson = snapJson };
            
            try
            {
                _attemptStore.Add(row);
            }

            catch
            {

            }

            _runLog.Add(row);

            try
            {
                _history.Insert(0, row);
            }

            catch
            {

            }
        }

        private void MarkInboxRowResolved(PhishingDecisionResult decision)
        {
            if (_currentInboxItem == null)
            {
                return;
            }

            var type = decision.IsCorrect ? "OK" : "MISS";

            if (decision.Action == PhishingAction.TrustKeep)
            {
                type = decision.IsCorrect ? "SAFE" : "RISK";
            }

            else if (decision.Action == PhishingAction.ReportPhishing)
            {
                type = decision.IsCorrect ? "CATCH" : "FALSE";
            }

            _currentInboxItem.Text = type;

            if (_currentInboxItem.Tag is InboxRowTag tag && tag != null)
            {
                tag.IsResolved = true;
                tag.DisplayType = type;
            }
        }

        private void SetButtonsEnabled(bool enabled)
        {
            if (btnTrust != null)
            {
                btnTrust.Enabled = enabled;
            }

            if (btnReportPhish != null)
            {
                btnReportPhish.Enabled = enabled;
            }

            if (btnOpenLink != null)
            {
                btnOpenLink.Enabled = enabled;
            }

            if (btnOpenAtt != null)
            {
                btnOpenAtt.Enabled = enabled;
            }
        }

        private void ApplyActionToEmail(PhishingEmail email)
        {
            if (email == null)
            {   
                return;
            }

            if (btnOpenLink != null)
            {
                btnOpenLink.Enabled = email.HasLink && !_actionsUsedOnEmail.Contains(PhishingAction.OpenLink) && !_currentEmailResolved;
            }

            if (btnOpenAtt != null)
            {
                btnOpenAtt.Enabled = email.HasAttachment && !_actionsUsedOnEmail.Contains(PhishingAction.OpenAttachment) && !_currentEmailResolved;
            }

            if (btnTrust != null)
            {
                btnTrust.Enabled = !_actionsUsedOnEmail.Contains(PhishingAction.TrustKeep) && !_currentEmailResolved;
            }

            if (btnReportPhish != null)
            {
                btnReportPhish.Enabled = !_actionsUsedOnEmail.Contains(PhishingAction.ReportPhishing) && !_currentEmailResolved;
            }
        }

        private void InboxSelectionChanged()
        {
            if (lvInbox == null || lvInbox.SelectedItems.Count == 0)
            {
                return;
            }

            var item = lvInbox.SelectedItems[0];

            if (item?.Tag is not InboxRowTag tag || tag == null)
            {
                return;
            }

            if (tag.Email == null)
            {
                return;
            }

            _currentEmail = tag.Email;
            _currentInboxItem = item;

            ShowCurrentEmail();

            if (btnViewDetails != null)
            {
                btnViewDetails.Enabled = true;
            }
        }

        private double GetTagMastery(string tag)
        {
            if (string.IsNullOrWhiteSpace(tag))
            {
                tag = "general";
            }

            tag = tag.Trim();
            var history = _history ?? new List<PhishingAttemptRow>();

            int seen = 0;
            int correct = 0;

            for (int i = 0; i < history.Count; i++)
            {
                var row = history[i];

                if (row == null)
                {
                    continue;
                }

                var snap = ReadEmailSnap(row.EmailSnapshotJson);

                if (snap == null)
                {
                    continue;
                }

                var tags = snap.Tags ?? new List<string>();

                if (tags.Count == 0)
                {
                    tags = new List<string> { "general" };
                }

                bool match = tags.Any(existingTag => string.Equals((existingTag ?? "").Trim(), tag, StringComparison.OrdinalIgnoreCase));

                if (!match)
                {
                    continue;
                }

                var isFinal = row.Action == (int)PhishingAction.TrustKeep || row.Action == (int)PhishingAction.ReportPhishing;

                if (!isFinal)
                {
                    continue;
                }

                seen++;

                if (row.IsCorrect)
                {
                    correct++;
                }
            }

            if (seen <= 0)
            {
                return 0.0;
            }

            return (double)correct / seen;
        }

        private void UpdateModelFromFinalDecision(PhishingDecisionResult decision)
        {
            if (_currentEmail == null || decision == null)
            {
                return;
            }

            var topic = _sharedAdaptiveLearningService.MapPhishingTopic(_currentEmail);
            var tags = _currentEmail.Tags ?? new List<string>();

            if (tags.Count == 0)
            {
                tags = new List<string> { "phishing-general" };
            }

            _sharedUserModel.UpdateTopicAttempt(topic, decision.IsCorrect ? 1.0 : 0.0, decision.IsCorrect ? null : tags);
        }

        private static PhishingEmail ReadEmailSnap(string json)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(json))
                {
                    return null;
                }

                return JsonConvert.DeserializeObject<PhishingEmail>(json);
            }

            catch
            {
                return null;
            }
        }

        private void PauseRunClock()
        {
            if (_runClockPaused)
            {
                return;
            }

            if (!_runStarted)
            {
                return;
            }

            _runClockFrozen = DateTime.UtcNow - _runStartedUtc;
            _runClockPaused = true;
        }

        private void ResumeRunClock()
        {
            if (!_runClockPaused)
            {
                return;
            }

            if (!_runStarted)
            {
                return;
            }

            _runStartedUtc = DateTime.UtcNow - _runClockFrozen;
            _runClockPaused = false;
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

        private string RunSummary()
        {
            int total = 0;
            int correct = 0;
            double totalSeconds = 0.0;
            int timed = 0;

            for (int i = 0; i < _runLog.Count; i++)
            {
                var row = _runLog[i];

                if (row == null)
                {
                    continue;
                }

                var isFinal = row.Action == (int)PhishingAction.TrustKeep || row.Action == (int)PhishingAction.ReportPhishing;

                if (!isFinal)
                {
                    continue;
                }

                total++;

                if (row.IsCorrect)
                {
                    correct++;
                }

                if (row.SecondsTaken > 0)
                {
                    totalSeconds += row.SecondsTaken;
                    timed++;
                }
            }

            var percent = total == 0 ? 0.0 : (correct * 100.0 / total);
            var avg = timed == 0 ? 0.0 : (totalSeconds / timed);

            TimeSpan elapsed;

            if (!_runStarted)
            {
                elapsed = TimeSpan.Zero;
            }
            else
            {
                elapsed = _runClockPaused ? _runClockFrozen : (DateTime.UtcNow - _runStartedUtc);
            }

            var time = FormatTime(elapsed);
            var avgText = avg <= 0 ? "—" : $"{avg:0.0}s";

            return $"Run complete!\n\nCorrect: {correct}/{total} ({percent:0}%)\nScore: {_score}\nTime: {time}\nAvg decision time: {avgText}";
        }

        private sealed class InboxRowTag
        {
            public int EmailId { get; set; }
            public PhishingEmail Email { get; set; }
            public bool IsResolved { get; set; }
            public string DisplayType { get; set; }
        }

        private void btnFinishRun_Click(object sender, EventArgs e)
        {
            if (!_runStarted || _seenRun.Count == 0)
            {
                Close();
                return;
            }

            var ok = MessageBox.Show(this, "Finish this run and show your summary?", "Mondas", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

            if (ok != DialogResult.OK)
            {
                return;
            }

            PauseRunClock();
            var summary = RunSummary();
            MessageBox.Show(this, summary, "Mondas", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Close();
        }
    }
}