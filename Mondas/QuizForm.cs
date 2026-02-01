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
        private const string UserKey = "local";

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

        public QuizForm() : this(new QuizPreferences { UseDefaults = true })
        {

        }

        public QuizForm(QuizPreferences prefs)
        {
            InitializeComponent();
            _prefs = prefs ?? new QuizPreferences { UseDefaults = true };

            WireUiDefaults();
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

        private void InitStorage()
        {
            var baseDir = AppDomain.CurrentDomain.BaseDirectory;

            var dbPath = Path.Combine(baseDir, "mondas.db");
            _attemptRepo = new SqliteAttemptRepository(dbPath);

            var questionsPath = Path.Combine(baseDir, "Resources", "questions.json");

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

            var userModel = new UserModel();
            SeedUserModelFromHistory(userModel, _allQuestions);

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

                return q.ToList();
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

        }

        private void btnPrevious_Click(object sender, EventArgs e)
        {

        }

        private void btnNext_Click(object sender, EventArgs e)
        {

        }
    }
}