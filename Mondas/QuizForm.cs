using Mondas.Contracts.Services;
using Mondas.Models;
using Mondas.Services;
using Syncfusion.WinForms.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Windows.Forms;

namespace Mondas
{
    public partial class QuizForm : SfForm
    {
        private readonly string _userKey;

        private readonly QuizPreferences _prefs;

        private SqliteAttemptRepository _attemptRepo;
        private IReadOnlyList<Question> _allQuestions = Array.Empty<Question>();
        private Dictionary<int, Question> _questionById = new Dictionary<int, Question>();

        private QuizSession _session;

        private readonly Stopwatch _questionStopwatch = new Stopwatch();

        private int _maxQuestions = 10;

        private readonly List<HistoryItem> _history = new List<HistoryItem>();
        private int _historyIndex = -1;

        private bool _awaitingAdvanceAfterFeedback;
        private Timer _uiTimer;
        private int _secondsRemaining;
        private bool _started;
        private bool _updateRadioGroup;

        private SharedAdaptiveLearningService _sharedAdaptiveLearningService;

        public QuizForm() : this("local", new QuizPreferences { UseDefaults = true })
        {

        }

        public QuizForm(QuizPreferences prefs) : this("local", prefs)
        {

        }

        public QuizForm(long userId) : this(BuildUserKey(userId), new QuizPreferences { UseDefaults = true })
        {

        }

        public QuizForm(long userId, QuizPreferences prefs) : this(BuildUserKey(userId), prefs)
        {

        }

        public QuizForm(string userKey, QuizPreferences prefs)
        {
            InitializeComponent();
            _prefs = prefs ?? new QuizPreferences { UseDefaults = true };
            _userKey = NormalizeUserKey(userKey);

            WireUiDefaults();
        }

        private static string BuildUserKey(long userId)
        {
            return userId > 0 ? "u:" + userId.ToString() : "local";
        }

        private static string NormalizeUserKey(string userKey)
        {
            return string.IsNullOrWhiteSpace(userKey) ? "local" : userKey.Trim();
        }

        private void WireUiDefaults()
        {
            if (btnNavQuiz != null)
            {
                btnNavQuiz.Enabled = false;
            }

            if (lblFeedback != null)
            {
                lblFeedback.Visible = false;
                lblFeedback.Text = "";
            }

            if (flpOptions != null)
            {
                flpOptions.WrapContents = false;
                flpOptions.FlowDirection = FlowDirection.TopDown;
                flpOptions.AutoScroll = true;
                flpOptions.SizeChanged += (_, __) => FixOptionWidths();
            }

            if (btnPrevious != null)
            {
                btnPrevious.Enabled = false;
            }

            if (pnlTimer != null && lblTimer != null)
            {
                pnlTimer.Visible = false;
                lblTimer.Text = "";
            }

            if (lblReason != null)
            {
                lblReason.Text = "";
            }
        }

        private void QuizFormTemp_Load(object sender, EventArgs e)
        {
            if (LicenseManager.UsageMode == LicenseUsageMode.Designtime)
            {
                return;
            }

            if (_started)
            {
                return;
            }

            _started = true;

            InitStorage();
            StartNewSession();
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            StopUiTimer();
            base.OnFormClosed(e);
        }

        private void InitStorage()
        {
            var baseDir = AppDomain.CurrentDomain.BaseDirectory;

            var dbPath = Path.Combine(baseDir, "mondas.db");
            var questionsPath = FixQuestionsJsonPath(baseDir);

            _attemptRepo = new SqliteAttemptRepository(dbPath);
            _sharedAdaptiveLearningService = new SharedAdaptiveLearningService(dbPath, questionsPath);

            try
            {
                var repo = new JsonQuestionRepository(questionsPath);
                _allQuestions = repo.GetAllQuestions() ?? Array.Empty<Question>();
                _questionById = _allQuestions.ToDictionary(q => q.Id, q => q);
            }

            catch
            {
                _allQuestions = Array.Empty<Question>();
                _questionById = new Dictionary<int, Question>();
            }
        }

        private static string FixQuestionsJsonPath(string baseDir)
        {
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

        private UserModel SharedUserModel()
        {
            if (_sharedAdaptiveLearningService != null)
            {
                try
                {
                    return _sharedAdaptiveLearningService.BuildUserModel(_userKey) ?? new UserModel();
                }
                catch
                {
                }
            }

            var fallback = new UserModel();
            SeedUserModelFromHistory(fallback, _allQuestions);
            return fallback;
        }

        private void StartNewSession()
        {
            if (_allQuestions == null || _allQuestions.Count == 0)
            {
                MessageBox.Show(this, "No questions found. Check questions.json", "Mondas", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Close();
                return;
            }

            var pool = BuildQuestionPool(_allQuestions, _prefs);
            if (pool.Count == 0)
            {
                MessageBox.Show(this, "No questions match your preferences. Continue by adjusting the filters.", "Mondas", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Close();
                return;
            }

            var requested = _prefs.UseDefaults ? 10 : Math.Max(1, _prefs.QuestionCount);
            _maxQuestions = Math.Min(requested, pool.Count);

            var userModel = SharedUserModel();

            bool focusWeak = _prefs.UseDefaults ? true : _prefs.PrioritiseWeakTopics;
            DifficultyBand? prefDiff = _prefs.UseDefaults ? DifficultyBand.Medium : _prefs.Difficulty;

            IRuleEngine ruleEngine = new RuleEngineV1(focusWeakTopic: focusWeak, preferredDifficulty: prefDiff);
            _session = new QuizSession(pool, ruleEngine, userModel);

            _history.Clear();
            _historyIndex = -1;
            _awaitingAdvanceAfterFeedback = false;

            if (btnPrevious != null)
            {
                btnPrevious.Enabled = false;
            }

            if (lblFeedback != null)
            {
                lblFeedback.Visible = false;
                lblFeedback.Text = "";
            }

            SetupTimer();
            LoadNewQuestion();
        }

        private void SetupTimer()
        {
            if (pnlTimer == null || lblTimer == null)
            {
                return;
            }

            if (!_prefs.TimerEnabled)
            {
                pnlTimer.Visible = false;
                StopUiTimer();
                return;
            }

            pnlTimer.Visible = true;

            _secondsRemaining = _maxQuestions * 36;
            lblTimer.Text = FormatMmSs(_secondsRemaining);

            if (_uiTimer == null)
            {
                _uiTimer = new Timer();
                _uiTimer.Interval = 1000;
                _uiTimer.Tick += UiTimer_Tick;
            }

            _uiTimer.Start();
        }

        private void UiTimer_Tick(object sender, EventArgs e)
        {
            if (!_started)
            {
                return;
            }

            _secondsRemaining = Math.Max(0, _secondsRemaining - 1);

            if (lblTimer != null)
            {
                lblTimer.Text = FormatMmSs(_secondsRemaining);
            }

            if (_secondsRemaining <= 0)
            {
                StopUiTimer();
                ShowSummaryAndClose();
            }
        }

        private void StopUiTimer()
        {
            if (_uiTimer != null)
            {
                _uiTimer.Stop();
            }
        }

        private List<Question> BuildQuestionPool(IReadOnlyList<Question> all, QuizPreferences prefs)
        {
            IEnumerable<Question> q = all;

            if (!prefs.UseDefaults)
            {
                if (prefs.Topics != null && prefs.Topics.Count > 0)
                {
                    q = q.Where(x => prefs.Topics.Contains(x.Metadata.Topic));
                }

                if (prefs.QuestionTypes != null && prefs.QuestionTypes.Count > 0)
                {
                    q = q.Where(x => prefs.QuestionTypes.Contains(x.Metadata.QuestionType));
                }

                if (prefs.Difficulty.HasValue)
                {
                    q = q.Where(x => x.Metadata.Difficulty == prefs.Difficulty.Value);
                }

                if (prefs.BloomLevel.HasValue)
                {
                    q = q.Where(x => x.Metadata.BloomLevel == prefs.BloomLevel.Value);
                }

                if (!string.IsNullOrWhiteSpace(prefs.ThreatVector))
                {
                    q = q.Where(x => string.Equals(x.Metadata.ThreatVector, prefs.ThreatVector, StringComparison.OrdinalIgnoreCase));
                }
            }

            return q.ToList();
        }

        private void SeedUserModelFromHistory(UserModel userModel, IReadOnlyList<Question> allQuestions)
        {
            if (_attemptRepo == null)
            {
                return;
            }

            Dictionary<int, Question> byId;
            try
            {
                byId = allQuestions.ToDictionary(x => x.Id, x => x);
            }

            catch
            {
                return;
            }

            List<AttemptRecord> history;

            try
            {
                history = _attemptRepo.GetForUser(_userKey)?.OrderBy(x => x.SubmittedAt).ToList() ?? new List<AttemptRecord>();
            }

            catch
            {
                history = new List<AttemptRecord>();
            }

            foreach (var r in history)
            {
                if (!byId.TryGetValue(r.QuestionId, out var q))
                {
                    continue;
                }

                var attempt = new QuestionAttempt { QuestionId = r.QuestionId, StartedAt = r.SubmittedAt.AddSeconds(-r.SecondsTaken).ToUniversalTime(), SubmittedAt = r.SubmittedAt.ToUniversalTime(), IsCorrect = r.IsCorrect, SelectedOptionIds = SafeReadIds(r.SelectedOptionIdsJson), ReasonString = r.ReasonString ?? "", RulesFired = SafeReadRules(r.RulesFiredJson) };

                userModel.UpdateFromAttempt(q, attempt);
            }
        }

        private void LoadNewQuestion()
        {
            if (_history.Count >= _maxQuestions)
            {
                ShowSummaryAndClose();
                return;
            }

            var selection = _session.GetNextQuestion();
            if (selection == null || selection.SelectedQuestion == null)
            {
                ShowSummaryAndClose();
                return;
            }

            var item = new HistoryItem { Number = _history.Count + 1, Question = selection.SelectedQuestion, Selection = selection };

            _history.Add(item);
            _historyIndex = _history.Count - 1;

            RenderHistoryItem(item, allowEditing: true);

            _awaitingAdvanceAfterFeedback = false;

            if (btnPrevious != null)
            {
                btnPrevious.Enabled = _historyIndex > 0;
            }

            UpdateNextButtonText();
        }

        private void RenderHistoryItem(HistoryItem item, bool allowEditing)
        {
            if (lblQuizTopicTitle != null)
            {
                lblQuizTopicTitle.Text = ToHeaderText(item.Question.Metadata.Topic);
            }

            if (lblQuizProgress != null)
            {
                lblQuizProgress.Text = $"QUESTION {item.Number} OF {_maxQuestions}";
            }

            if (lblQuestion != null)
            {
                lblQuestion.Text = item.Question.Text;
            }

            if (lblReason != null)
            {
                var reason = item.Selection?.ReasonString ?? "";
                lblReason.Text = string.IsNullOrWhiteSpace(reason) ? "" : "Reason: " + reason;
            }

            if (lblFeedback != null)
            {
                lblFeedback.Visible = item.IsScored;
                lblFeedback.Text = item.IsScored ? (item.FeedbackText ?? "") : "";
            }

            PopulateOptions(item, allowEditing);

            if (btnPrevious != null)
            {
                btnPrevious.Enabled = _historyIndex > 0;
            }

            if (allowEditing && !item.IsScored)
            {
                _questionStopwatch.Restart();
            }

            UpdateNextButtonText();            
        }

        private void PopulateOptions(HistoryItem item, bool allowEditing)
        {
            if (flpOptions == null)
            {
                return;
            }

            flpOptions.SuspendLayout();
            flpOptions.Controls.Clear();

            bool singleChoice = IsSingleChoice(item.Question.Metadata.QuestionType);

            foreach (var opt in item.Question.Options)
            {
                var row = CreateOptionRow(opt.Text, opt.Id, singleChoice);

                if (item.SelectedOptionIds != null && item.SelectedOptionIds.Contains(opt.Id))
                {
                    var rb = FindFirstChild<RadioButton>(row);
                    
                    if (rb != null)
                    {
                        rb.Checked = true;
                    }

                    var cb = FindFirstChild<CheckBox>(row);

                    if (cb != null)
                    {
                        cb.Checked = true;
                    }
                }

                row.Enabled = allowEditing && !item.IsScored;

                flpOptions.Controls.Add(row);
            }

            flpOptions.ResumeLayout();
            FixOptionWidths();
        }

        private Control CreateOptionRow(string text, int optionId, bool singleChoice)
        {
            var tile = TryCreateOptionTile(text, optionId, singleChoice);

            if (tile != null)
            {
                return tile;
            }

            var row = new Panel { BorderStyle = BorderStyle.FixedSingle, Padding = new Padding(12), Margin = new Padding(0, 0, 0, 10), Tag = optionId, Cursor = Cursors.Hand };

            var layout = new TableLayoutPanel { Dock = DockStyle.Fill, ColumnCount = 2, RowCount = 1, Margin = new Padding(0) };

            layout.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize));
            layout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100f));

            var rb = new RadioButton { AutoSize = true, Visible = singleChoice, Tag = optionId, Margin = new Padding(0, 2, 10, 0) };
            var cb = new CheckBox { AutoSize = true, Visible = !singleChoice, Tag = optionId, Margin = new Padding(0, 2, 10, 0) };

            var lbl = new Label { Text = text, Dock = DockStyle.Fill, TextAlign = System.Drawing.ContentAlignment.MiddleLeft };

            layout.Controls.Add(singleChoice ? (Control)rb : cb, 0, 0);
            layout.Controls.Add(lbl, 1, 0);

            row.Controls.Add(layout);

            if (singleChoice)
            {
                rb.CheckedChanged += (_, __) =>
                {
                    if (!rb.Checked)
                    {
                        return;
                    }

                    EnforceSingleChoice(rb);
                    ClearFeedbackIfEditing();
                };

                row.Click += (_, __) => rb.Checked = true;
                lbl.Click += (_, __) => rb.Checked = true;
            }

            else
            {
                cb.CheckedChanged += (_, __) => ClearFeedbackIfEditing();
                row.Click += (_, __) => cb.Checked = !cb.Checked;
                lbl.Click += (_, __) => cb.Checked = !cb.Checked;
            }

            return row;
        }

        private Control TryCreateOptionTile(string text, int optionId, bool singleChoice)
        {
            Type tileType = null;

            foreach (var asm in AppDomain.CurrentDomain.GetAssemblies())
            {
                try
                {
                    tileType = asm.GetTypes().FirstOrDefault(t => t.Name == "OptionTile");

                    if (tileType != null)
                    {
                        break;
                    }
                }

                catch
                {

                }
            }

            if (tileType == null)
            {
                return null;
            }

            object instance;
            
            try
            {
                instance = Activator.CreateInstance(tileType);
            }

            catch
            {
                return null;
            }

            if (instance is not Control tile)
            {
                return null;
            }

            tile.Tag = optionId;
            tile.Margin = new Padding(0, 0, 0, 10);
            tile.Cursor = Cursors.Hand;

            var rb = FindFirstChild<RadioButton>(tile);
            var cb = FindFirstChild<CheckBox>(tile);
            var lbl = FindFirstChild<Label>(tile);

            if (lbl != null)
            {
                lbl.Text = text;
            }

            if (rb != null)
            {
                rb.Tag = optionId;
                rb.Visible = singleChoice;
            }

            if (cb != null)
            {
                cb.Tag = optionId;
                cb.Visible = !singleChoice;
            }

            if (singleChoice)
            {
                if (rb == null)
                {
                    return null;
                }

                rb.CheckedChanged += (_, __) =>
                {
                    if (!rb.Checked)
                    {
                        return;
                    }

                    EnforceSingleChoice(rb);
                    ClearFeedbackIfEditing();
                };

                tile.Click += (_, __) => rb.Checked = true;

                if (lbl != null)
                {
                    lbl.Click += (_, __) => rb.Checked = true;
                }
            }

            else
            {
                if (cb == null)
                {
                    return null;
                }

                cb.CheckedChanged += (_, __) => ClearFeedbackIfEditing();

                tile.Click += (_, __) => cb.Checked = !cb.Checked;

                if (lbl != null)
                {
                    lbl.Click += (_, __) => cb.Checked = !cb.Checked;
                }
            }

            return tile;
        }

        private void EnforceSingleChoice(RadioButton justChecked)
        {
            if (_updateRadioGroup || flpOptions == null)
            {
                return;
            }

            try
            {
                _updateRadioGroup = true;

                foreach (Control row in flpOptions.Controls)
                {
                    var rb = FindFirstChild<RadioButton>(row);

                    if (rb != null && !ReferenceEquals(rb, justChecked))
                    {
                        rb.Checked = false;
                    }

                    var cb = FindFirstChild<CheckBox>(row);

                    if (cb != null)
                    {
                        cb.Checked = false;
                    }
                }
            }

            finally
            {
                _updateRadioGroup = false;
            }
        }

        private void ClearFeedbackIfEditing()
        {
            if (_historyIndex < 0 || _historyIndex >= _history.Count)
            {
                return;
            }

            var item = _history[_historyIndex];
            bool editingThis = (_historyIndex == _history.Count - 1) && !item.IsScored;

            if (!editingThis)
            {
                return;
            }

            if (lblFeedback != null)
            {
                lblFeedback.Visible = false;
                lblFeedback.Text = "";
            }
        }

        private void FixOptionWidths()
        {
            if (flpOptions == null)
            {
                return;
            }

            int width = flpOptions.ClientSize.Width - SystemInformation.VerticalScrollBarWidth - 2;

            if (width <= 0)
            {
                return;
            }

            foreach (Control c in flpOptions.Controls)
            {
                c.Width = width;
            }
        }



        private void btnNavDashboard_Click(object sender, EventArgs e)
        {

        }

        private void btnNavQuiz_Click(object sender, EventArgs e)
        {

        }

        private void btnNavMiniGames_Click(object sender, EventArgs e)
        {

        }

        private void btnNavReports_Click(object sender, EventArgs e)
        {

        }

        private void btnNavLeaderboard_Click(object sender, EventArgs e)
        {

        }

        private void btnNavCommunity_Click(object sender, EventArgs e)
        {

        }

        private void btnNavSettings_Click(object sender, EventArgs e)
        {

        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnPrevious_Click(object sender, EventArgs e)
        {
            if (_historyIndex <= 0)
            {
                return;
            }

            _historyIndex--;
            _awaitingAdvanceAfterFeedback = false;

            var item = _history[_historyIndex];
            RenderHistoryItem(item, allowEditing: false);

            UpdateNextButtonText();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (_history.Count == 0)
            {
                LoadNewQuestion();
                return;
            }

            if (_historyIndex < 0 || _historyIndex >= _history.Count)
            {
                return;
            }

            if (_historyIndex < _history.Count - 1)
            {
                _historyIndex++;
                var next = _history[_historyIndex];
                bool allowEditing = (_historyIndex == _history.Count - 1) && !next.IsScored;
                RenderHistoryItem(next, allowEditing);
                UpdateNextButtonText();
                return;
            }

            var current = _history[_historyIndex];

            if (!current.IsScored)
            {
                if (!TryScoreCurrent())
                {
                    return;
                }

                _awaitingAdvanceAfterFeedback = true;
                UpdateNextButtonText();
                return;
            }

            if (_history.Count >= _maxQuestions)
            {
                ShowSummaryAndClose();
                return;
            }

            LoadNewQuestion();
        }

        private bool TryScoreCurrent()
        {
            if (_historyIndex < 0 || _historyIndex >= _history.Count)
            {
                return false;
            }

            var item = _history[_historyIndex];

            if (item == null || item.Question == null)
            {
                return false;
            }

            var selectedIds = ReadSelectedOptionIdsFromUi();
            
            if (selectedIds.Count == 0)
            {
                MessageBox.Show(this, "Please select an answer.", "Mondas", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }

            _questionStopwatch.Stop();

            var correctIds = item.Question.Options.Where(o => o.IsCorrect).Select(o => o.Id).OrderBy(id => id).ToList();
            var chosenSorted = selectedIds.OrderBy(id => id).ToList();
            bool isCorrect = correctIds.SequenceEqual(chosenSorted);

            item.SelectedOptionIds = selectedIds;
            item.IsScored = true;
            item.IsCorrect = isCorrect;

            var feedback = isCorrect ? "Correct!" : "Incorrect.";

            if (!isCorrect && correctIds.Count > 0)
            {
                var correctText = string.Join(", ", item.Question.Options.Where(o => correctIds.Contains(o.Id)).Select(o => o.Text));
                feedback += "Correct answer: " + correctText;
            }

            item.FeedbackText = feedback;
            item.SecondsTaken = _questionStopwatch.Elapsed.TotalSeconds;

            if (lblFeedback != null)
            {
                lblFeedback.Text = feedback;
                lblFeedback.Visible = true;
            }

            var attempt = new QuestionAttempt { QuestionId = item.Question.Id, StartedAt = DateTime.UtcNow.AddSeconds(-Math.Max(0, item.SecondsTaken)), SubmittedAt = DateTime.UtcNow, IsCorrect = isCorrect, SelectedOptionIds = selectedIds, ReasonString = item.Selection?.ReasonString ?? "", RulesFired = item.Selection?.RulesFired ?? new List<string>() };

            _session.RecordAttempt(item.Question, attempt);

            if (_attemptRepo != null)
            {
                var record = new AttemptRecord { UserKey = _userKey, QuestionId = item.Question.Id, SelectedOptionIdsJson = JsonSerializer.Serialize(selectedIds), IsCorrect = isCorrect, SecondsTaken = item.SecondsTaken, SubmittedAt = DateTime.UtcNow, ReasonString = item.Selection?.ReasonString ?? "", RulesFiredJson = JsonSerializer.Serialize(item.Selection?.RulesFired ??new List<string>()) };

                _attemptRepo.Add(record);
            }

            UpdateNextButtonText();
            return true;
        }

        private List<int> ReadSelectedOptionIdsFromUi()
        {
            var ids = new List<int>();

            if (flpOptions == null)
            {
                return ids;
            }

            foreach (Control row in flpOptions.Controls)
            {
                var rb = FindFirstChild<RadioButton>(row);

                if (rb != null && rb.Checked && rb.Visible)
                {
                    if (rb.Tag is int id)
                    {
                        ids.Add(id);
                    }

                    else if (row.Tag is int rowId)
                    {
                        ids.Add(rowId);
                    }

                    return ids;
                }
            }
            foreach (Control row in flpOptions.Controls)
            {
                var cb = FindFirstChild<CheckBox>(row);

                if (cb != null && cb.Checked && cb.Visible)
                {
                    if (cb.Tag is int id)
                    {
                        ids.Add(id);
                    }

                    else if (row.Tag is int rowId)
                    {
                        ids.Add(rowId);
                    }
                }
            }

            return ids;
        }
        
        private void UpdateNextButtonText()
        {
            if (btnNext == null || _historyIndex < 0 || _historyIndex >= _history.Count)
            {
                return;
            }

            var current = _history[_historyIndex];

            bool reviewingOldQuestion = _historyIndex < _history.Count - 1;
            bool onNewestQuestion = !reviewingOldQuestion;
            bool lastQuestionInQuiz = onNewestQuestion && (_history.Count >= _maxQuestions);

            if (reviewingOldQuestion)
            {
                btnNext.Text = "NEXT";
                return;
            }

            if (!current.IsScored)
            {
                btnNext.Text = "SUBMIT";
                return;
            }

            btnNext.Text = lastQuestionInQuiz ? "FINISH" : "NEXT";
        }

        private void ShowSummaryAndClose()
        {
            StopUiTimer();

            if (_session == null)
            {
                Close();
                return;
            }

            var attempts = _session.Attempts ?? new List<QuestionAttempt>();
            int total = attempts.Count;
            int correct = attempts.Count(a => a.IsCorrect);
            double percent = total == 0 ? 0 : correct * 100.0 / total;

            MessageBox.Show(this, $"Quiz complete!\n\nCorrect: {correct}/{total} ({percent: 0}%)", "Mondas", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Close();
        }

        private static bool IsSingleChoice(QuestionType type)
        {
            return type == QuestionType.SingleChoice || type == QuestionType.TrueFalse;
        }

        private static string ToHeaderText (Topic topic)
        {
            return topic.ToString().Replace('_', ' ').ToUpperInvariant();
        }

        private static string FormatMmSs(int seconds)
        {
            int mins = seconds / 60;
            int secs = seconds % 60;
            return mins.ToString("00") + ":" + secs.ToString("00");
        }

        private static List<int> SafeReadIds(string json)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(json))
                {
                    return new List<int>();
                }

                return JsonSerializer.Deserialize<List<int>>(json) ?? new List<int>();
            }

            catch
            {
                return new List<int>();
            }
        }

        private static List<string> SafeReadRules(string json)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(json))
                {
                    return new List<string>();
                }

                return JsonSerializer.Deserialize<List<string>>(json) ?? new List<string>();
            }

            catch
            {
                return new List<string>();
            }

        }

        private static T FindFirstChild<T>(Control root) where T : Control
        {
            if (root == null)
            {
                return null;
            }

            if (root is T match)
            {
                return match;
            }

            foreach (Control child in root.Controls)
            {
                var found = FindFirstChild<T>(child);

                if (found != null)
                {
                    return found;
                }
            }

            return null;
        }

        private sealed class HistoryItem
        { 
            public int Number { get; set; }
            public Question Question { get; set; }
            public SelectionResult Selection { get; set; }
            public List<int> SelectedOptionIds { get; set; } = new List<int>();
            public bool IsScored { get; set; }
            public bool IsCorrect { get; set; }
            public string FeedbackText { get; set; }
            public double SecondsTaken { get; set; }
        }
    }
}