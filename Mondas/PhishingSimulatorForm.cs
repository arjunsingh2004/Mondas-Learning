using Syncfusion.WinForms.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
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

        public PhishingSimulatorForm() : this("local")
        {

        }

        public PhishingSimulatorForm(string userKey)
        {
            InitializeComponent();

            _userKey = string.IsNullOrWhiteSpace(userKey) ? "local" : userKey.Trim();
            _dbPath = Path.Combine(AppContext.BaseDirectory, "mondas.db");
            _emailsJsonPath = ResolveEmailsJsonPath();
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

            _engine = new PhishingEngineV1(focusWeakTags: true, preferredDifficulty: DifficultyBand.Medium, allowDifficultyDrift: true);
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
                _allEmails = _emailsRepo.LoadAll() ?? Array.Empty<PhishingEmail>();
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

            if (lvSignals.Columns.Count == 0)
            {
                lvSignals.Columns.Add("SIGNAL", 260, HorizontalAlignment.Left);
                lvSignals.Columns.Add("DETAIL", 620, HorizontalAlignment.Left);
                lvSignals.Columns.Add("W", 40, HorizontalAlignment.Center);
            }

            else
            {
                lvSignals.Columns[0].Text = "SIGNAL";
                
                if (lvSignals.Columns.Count > 1)
                {
                    lvSignals.Columns[1].Text = "DETAIL";
                }

                if (lvSignals.Columns.Count > 2)
                {
                    lvSignals.Columns[2].Text = "W";
                }
            }

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

            _lastReason = "";
            _lastRules = new List<string>();
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
        }

        private void UpdateRunInfo()
        {
            if (lblRunInfo == null)
            {
                return;
            }

            var elapsed = DateTime.UtcNow - _runStartedUtc;
            var time = FormatTime(elapsed);

            lblRunInfo.Text = $"SCORE: {_score} | STREAK | {_streak} | TIME: {time}";
        }

        private static string FormatTime(TimeSpan timespan)
        {
            var mins = (int)timespan.TotalMinutes;
            var secs = timespan.Seconds;

            return mins.ToString("00") + "." + secs.ToString("00");
        }

        private void btnNewEmail_Click(object sender, EventArgs e)
        {
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

            var rules = _lastRules == null || _lastRules.Count == 0 ? "-" : string.Join(", ", _lastRules);
            var message = "Reason:\n" + (string.IsNullOrWhiteSpace(_lastReason) ? "-" : _lastReason) + "\n\nRules Added:\n" + rules + "\n\nExplanation:\n" + (_currentEmail.Explanation ?? "") + "\n\nTags:\n" + ((_currentEmail.Tags == null || _currentEmail.Tags.Count == 0) ? "-" : string.Join(", ", _currentEmail.Tags));

            MessageBox.Show(this, message, "Decision Details", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

            StartNewEmail(forceNewRun: false);
        }

        private void StartNewEmail(bool forceNewRun)
        {
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
            }

            var pick = _engine.PickNext(allEmails: _allEmails, history: _history ?? new List<PhishingAttemptRow>(), seenThisRun: _seenRun, tagMastery: GetTagMastery);

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
                }

                SetButtonsEnabled(enabled: false);
            }

            else
            {
                _score += decision.ScoreDelta;

                if (btnNextEmail != null)
                {
                    btnNextEmail.Enabled = false;
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
                if (decision.Signals == null || decision.Signals.Count == 0)
                {
                    lblResultWhy.Text = "SIGNALS: -";
                }

                else
                {
                    lblResultWhy.Text = "SIGNALS: " + decision.Signals.Count.ToString();
                }
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
            var his = _history ?? new List<PhishingAttemptRow>();

            int seen = 0;
            int correct = 0;

            for (int i = 0; i < his.Count; i++)
            {
                var row = his[i];

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

                bool match = tags.Any(tag => string.Equals((tag ?? "").Trim(), tag, StringComparison.OrdinalIgnoreCase));

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

        private sealed class InboxRowTag
        {
            public int EmailId { get; set; }
            public PhishingEmail Email { get; set; }
            public bool IsResolved { get; set; }
            public string DisplayType { get; set; }
        }
    }
}