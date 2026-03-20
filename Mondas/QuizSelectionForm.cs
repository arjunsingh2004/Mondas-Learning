using Syncfusion.WinForms.Controls;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Windows.Forms;
using Mondas.Models;
using Mondas.Services;
using System.Globalization;

namespace Mondas
{
    public partial class QuizSelectionForm : SfForm
    {
        private readonly string _userKey;

        private QuizPreferences _adaptivePrefs = new QuizPreferences { UseDefaults = true };

        private QuizPreferences _recommendedPrefs;
        private string _recommendedReason = "";

        private QuizPreferences _recommendedOverride;

        private SqliteAttemptRepository _attemptRepo;
        private IReadOnlyList<Question> _allQuestions = Array.Empty<Question>();
        private Dictionary<int, Question> _questionById = new Dictionary<int, Question>();

        private string _prefsPath;
        private string _adaptiveDescBase = "";

        public QuizSelectionForm()
        {
            InitializeComponent();
            _userKey = "local";
        }

        public QuizSelectionForm(string userKey)
        {
            InitializeComponent();
            _userKey = string.IsNullOrWhiteSpace(userKey) ? "local" : userKey.Trim();
        }

        private void QuizSelectionForm_Load(object sender, EventArgs e)
        {
            _adaptiveDescBase = lblAdaptiveDesc?.Text ?? "";

            if (btnNavQuiz != null)
            {
                btnNavQuiz.Enabled = false;
            }

            InitStorage();
            LoadAdaptivePrefsFromDisk();

            RefreshCards(recomputeRecommended: true);
            LoadRecentPerformance();
            BeginInvoke(new Action(TidyLabels));
            SizeChanged += (s, _) => TidyLabels();
        }

        private void InitStorage()
        {
            var baseDir = AppDomain.CurrentDomain.BaseDirectory;

            var dbPath = Path.Combine(baseDir, "mondas.db");
            var questionsPath = Path.Combine(baseDir, "Resources", "questions.json");

            _attemptRepo = new SqliteAttemptRepository(dbPath);

            try
            {
                var qRepo = new JsonQuestionRepository(questionsPath);
                _allQuestions = qRepo.GetAllQuestions() ?? Array.Empty<Question>();
                _questionById = _allQuestions.ToDictionary(q => q.Id, q => q);
            }
            catch
            {
                _allQuestions = Array.Empty<Question>();
                _questionById = new Dictionary<int, Question>();
            }

            var appDataDir = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "mondas");

            Directory.CreateDirectory(appDataDir);
            var safeKey = (_userKey ?? "local").Replace(":", "_").Replace("\\", "_").Replace("/", "_");
            _prefsPath = Path.Combine(appDataDir, $"quiz_prefs_{safeKey}.json");
        }

        private void LoadAdaptivePrefsFromDisk()
        {
            try
            {
                if (!File.Exists(_prefsPath))
                {
                    _adaptivePrefs = new QuizPreferences { UseDefaults = true };
                    _recommendedOverride = null;
                    return;
                }

                var json = File.ReadAllText(_prefsPath);

                var store = JsonSerializer.Deserialize<PrefsStore>(json);
                if (store != null && store.AdaptivePrefs != null)
                {
                    _adaptivePrefs = Normalise(store.AdaptivePrefs);
                    _recommendedOverride = store.RecommendedOverride == null ? null : Normalise(store.RecommendedOverride);
                    return;
                }

                var legacy = JsonSerializer.Deserialize<QuizPreferences>(json);
                if (legacy != null)
                {
                    _adaptivePrefs = Normalise(legacy);
                    _recommendedOverride = null;
                }
            }
            catch
            {
                _adaptivePrefs = new QuizPreferences { UseDefaults = true };
                _recommendedOverride = null;
            }
        }

        private void SaveAdaptivePrefsToDisk()
        {
            try
            {
                var store = new PrefsStore{ AdaptivePrefs = Normalise(_adaptivePrefs), RecommendedOverride = _recommendedOverride == null ? null : Normalise(_recommendedOverride) };

                var json = JsonSerializer.Serialize(store, new JsonSerializerOptions { WriteIndented = true });
                File.WriteAllText(_prefsPath, json);
            }
            catch
            {
            }
        }

        private void RefreshCards(bool recomputeRecommended)
        {
            if (recomputeRecommended || _recommendedPrefs == null)
            {
                var algo = BuildRecommendedPreferences(out var algoReason);

                if (_recommendedOverride != null && !_recommendedOverride.UseDefaults)
                {
                    _recommendedPrefs = _recommendedOverride;
                    _recommendedReason = "Using your custom recommended settings.";
                }
                else
                {
                    _recommendedPrefs = algo;
                    _recommendedReason = algoReason;
                }
            }
            else
            {
                if (_recommendedOverride != null && !_recommendedOverride.UseDefaults)
                {
                    _recommendedPrefs = _recommendedOverride;
                    _recommendedReason = "Using your custom recommended settings.";
                }
            }

            UpdateRecommendedCard();
            UpdateAdaptiveCard();
            LoadRecentPerformance();
        }

        private void LoadRecentPerformance()
        {
            if (lvRecentPerformance == null || _attemptRepo == null)
            {
                return;
            }

            List<AttemptRecord> history;

            try
            {
                history = _attemptRepo.GetForUser(_userKey)?.OrderByDescending(x => x.SubmittedAt).Take(20).ToList() ?? new List<AttemptRecord>();
            }

            catch
            {
                history = new List<AttemptRecord>();
            }

            lvRecentPerformance.BeginUpdate();
            lvRecentPerformance.Items.Clear();

            foreach (var rec in history)
            {
                _questionById.TryGetValue(rec.QuestionId, out var question);

                var topic = GetTopicText(question);
                var result = rec.IsCorrect ? "CORRECT" : "INCORRECT";
                var difficulty = GetDifficultyText(question);
                var date = rec.SubmittedAt.ToLocalTime().ToString("dd MMM yyyy : HH:mm", CultureInfo.InvariantCulture);

                var item = new ListViewItem(topic);
                item.SubItems.Add(result);
                item.SubItems.Add(difficulty);
                item.SubItems.Add(date);

                lvRecentPerformance.Items.Add(item);
            }

            lvRecentPerformance.EndUpdate();
        }

        private static string GetTopicText(Question question)
        {
            if (question == null)
            {
                return "UNKNOWN";
            }

            return question.Metadata.Topic.ToString().Replace("_", " ").ToUpperInvariant();
        }

        private static string GetDifficultyText(Question question)
        {
            if (question == null)
            {
                return "-";
            }

            return question.Metadata.Difficulty.ToString().ToUpperInvariant();
        }

        private void UpdateRecommendedCard()
        {
            if (lblRecSummary == null || lblRecReason == null || btnStartRecommended == null)
            {
                return;
            }

            if (_recommendedPrefs == null)
            {
                lblRecSummary.Text = DefaultRecommendedSummary();
                lblRecReason.Text = "Complete a quiz to generate a personalised recommendation.";
                btnStartRecommended.Enabled = true;
                return;
            }

            if (_recommendedPrefs.UseDefaults)
            {
                lblRecSummary.Text = DefaultRecommendedSummary();
                lblRecReason.Text = string.IsNullOrWhiteSpace(_recommendedReason) ? "Complete a quiz to generate a personalised recommendation." : _recommendedReason;
                btnStartRecommended.Enabled = true;
                return;
            }

            lblRecSummary.Text = FormatRecommendedLine(_recommendedPrefs);
            lblRecReason.Text = _recommendedReason ?? "";
            btnStartRecommended.Enabled = true;
        }

        private void UpdateAdaptiveCard()
        {
            if (lblAdaptiveDesc == null)
            {
                return;
            }

            if (_adaptivePrefs == null || _adaptivePrefs.UseDefaults)
            {
                lblAdaptiveDesc.Text = _adaptiveDescBase;
                return;
            }

            lblAdaptiveDesc.Text = _adaptiveDescBase + Environment.NewLine + "CURRENT PREFERENCES: " + FormatShortPrefs(_adaptivePrefs);
        }

        private void OpenPreferencesPopup()
        {
            using (var dlg = new QuizPreferencesForm(_adaptivePrefs))
            {
                dlg.StartPosition = FormStartPosition.CenterParent;

                if (dlg.ShowDialog(this) == DialogResult.OK)
                {
                    _adaptivePrefs = dlg.Preferences ?? new QuizPreferences { UseDefaults = true };
                    _adaptivePrefs = Normalise(_adaptivePrefs);

                    SaveAdaptivePrefsToDisk();
                    RefreshCards(recomputeRecommended: false);
                    BeginInvoke(new Action(TidyLabels));
                }
            }
        }

        private void OpenRecommendedPreferencesPopup()
        {
            var seed = _recommendedOverride;

            if (seed == null || seed.UseDefaults)
            {
                seed = _recommendedPrefs ?? BuildRecommendedPreferences(out _);
            }

            using (var dlg = new QuizPreferencesForm(seed))
            {
                dlg.StartPosition = FormStartPosition.CenterParent;

                if (dlg.ShowDialog(this) == DialogResult.OK)
                {
                    var picked = dlg.Preferences ?? new QuizPreferences { UseDefaults = true };
                    picked = Normalise(picked);

                    _recommendedOverride = picked.UseDefaults ? null : picked;

                    SaveAdaptivePrefsToDisk();
                    RefreshCards(recomputeRecommended: true);
                    BeginInvoke(new Action(TidyLabels));
                }
            }
        }

        private void StartQuiz(QuizPreferences prefsToUse)
        {
            prefsToUse ??= new QuizPreferences { UseDefaults = true };
            prefsToUse = Normalise(prefsToUse);

            using (var quiz = new QuizForm(_userKey, prefsToUse))
            {
                quiz.StartPosition = FormStartPosition.CenterParent;
                quiz.ShowDialog(this);
            }

            RefreshCards(recomputeRecommended: true);
            BeginInvoke(new Action(TidyLabels));
        }

        private QuizPreferences BuildRecommendedPreferences(out string reason)
        {
            reason = "";

            if (_attemptRepo == null || _allQuestions == null || _allQuestions.Count == 0)
            {
                reason = "Questions not loaded yet.";
                return new QuizPreferences { UseDefaults = true };
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

            if (history.Count == 0)
            {
                reason = "No attempts logged yet. Complete a quiz to generate a recommendation.";
                return new QuizPreferences { UseDefaults = true };
            }

            var userModel = new UserModel();

            foreach (var rec in history)
            {
                if (!_questionById.TryGetValue(rec.QuestionId, out var q))
                {
                    continue;
                }

                var attempt = new QuestionAttempt { QuestionId = rec.QuestionId, StartedAt = rec.SubmittedAt.AddSeconds(-rec.SecondsTaken).ToUniversalTime(), SubmittedAt = rec.SubmittedAt.ToUniversalTime(), IsCorrect = rec.IsCorrect, SelectedOptionIds = SafeReadIds(rec.SelectedOptionIdsJson), ReasonString = rec.ReasonString ?? "", RulesFired = SafeReadRules(rec.RulesFiredJson) };
                userModel.UpdateFromAttempt(q, attempt);
            }

            var topicsAvailable = _allQuestions.Select(q => q.Metadata.Topic).Where(t => t != Mondas.Models.Topic.Other).Distinct().ToList();

            Topic? weakest = null;
            double weakestMastery = double.MaxValue;

            foreach (var topic in topicsAvailable)
            {
                userModel.TopicStats.TryGetValue(topic, out var stats);

                var mastery = stats == null ? 0.0 : stats.Mastery;
                if (mastery > 1.0)
                {
                    mastery /= 100.0;
                }

                mastery = Math.Max(0.0, Math.Min(1.0, mastery));

                if (mastery < weakestMastery)
                {
                    weakestMastery = mastery;
                    weakest = topic;
                }
            }

            if (weakest == null)
            {
                reason = "Not enough topic data yet. Answer a few more questions.";
                return new QuizPreferences { UseDefaults = true };
            }

            reason = $"Recommended because your mastery in {weakest.Value} is currently lowest ({weakestMastery:P0}).";

            return new QuizPreferences { UseDefaults = false, QuestionCount = 10, TimerEnabled = false, PrioritiseWeakTopics = true, Topics = new List<Topic> { weakest.Value }, Difficulty = DifficultyBand.Medium, QuestionTypes = new List<QuestionType>(), BloomLevel = null, ThreatVector = "" };
        }

        private static string DefaultRecommendedSummary()
        {
            return "FOCUS: ADAPTIVE · DIFFICULTY: MEDIUM · LENGTH: 10 · TIMER: OFF";
        }

        private static string FormatRecommendedLine(QuizPreferences p)
        {
            var focus = (p.Topics != null && p.Topics.Count > 0) ? string.Join(", ", p.Topics).ToUpperInvariant() : "ANY";

            var difficulty = p.Difficulty.HasValue ? p.Difficulty.Value.ToString().ToUpperInvariant() : "ANY";

            var length = p.QuestionCount > 0 ? p.QuestionCount.ToString() : "10";
            var timer = p.TimerEnabled ? "ON" : "OFF";

            var header = $"FOCUS: {focus} · DIFFICULTY: {difficulty} · LENGTH: {length} · TIMER: {timer}";
            var extras = FormatExtras(p);

            return string.IsNullOrWhiteSpace(extras) ? header : header + Environment.NewLine + extras;
        }

        private static string FormatShortPrefs(QuizPreferences p)
        {
            var headerParts = new List<string>();

            if (p.Topics != null && p.Topics.Count > 0)
            {
                headerParts.Add(string.Join(", ", p.Topics).ToUpperInvariant());
            }
            else
            {
                headerParts.Add("ANY TOPIC");
            }

            if (p.Difficulty.HasValue)
            {
                headerParts.Add(p.Difficulty.Value.ToString().ToUpperInvariant());
            }
            else
            {
                headerParts.Add("ANY DIFFICULTY");
            }

            headerParts.Add($"{Math.Max(1, p.QuestionCount)} QUESTIONS");
            headerParts.Add(p.TimerEnabled ? "TIMER ON" : "TIMER OFF");

            var header = string.Join(" · ", headerParts);
            var extras = FormatExtras(p);

            return string.IsNullOrWhiteSpace(extras) ? header : header + Environment.NewLine + extras;
        }

        private static string FormatExtras(QuizPreferences p)
        {
            var parts = new List<string>();

            if (p.QuestionTypes != null && p.QuestionTypes.Count > 0)
            {
                parts.Add("TYPES: " + string.Join(", ", p.QuestionTypes).ToUpperInvariant());
            }     
            else
            {
                parts.Add("TYPES: ANY");
            }

            if (p.BloomLevel.HasValue)
            {
                parts.Add("BLOOM: " + p.BloomLevel.Value.ToString().ToUpperInvariant());
            }

            if (!string.IsNullOrWhiteSpace(p.ThreatVector))
            {
                parts.Add("VECTOR: " + p.ThreatVector.Trim().ToUpperInvariant());
            }

            return string.Join(" · ", parts);
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

        private static QuizPreferences Normalise(QuizPreferences p)
        {
            p ??= new QuizPreferences { UseDefaults = true };

            if (p.QuestionCount <= 0)
            {
                p.QuestionCount = 10;
            }

            p.Topics ??= new List<Topic>();
            p.QuestionTypes ??= new List<QuestionType>();
            p.ThreatVector ??= "";

            return p;
        }

        private void TidyLabels()
        {
            WrapLabel(lblRecSummary);
            WrapLabel(lblRecReason);
            WrapLabel(lblAdaptiveDesc);
        }

        private void WrapLabel(Label label)
        {
            if (label == null)
            {
                return;
            }
            var parentWidth = label.Parent?.ClientSize.Width ?? label.Width;
            var wrapWidth = Math.Max(200, parentWidth - 10);

            label.AutoSize = true;
            label.MaximumSize = new System.Drawing.Size(wrapWidth, 0);
            label.MinimumSize = new System.Drawing.Size(wrapWidth, 0);
        }

        private void btnNavDashboard_Click(object sender, EventArgs e)
        {
            var dash = new DashboardForm(_userKey);
            dash.StartPosition = FormStartPosition.CenterScreen;
            dash.Show();
            Close();
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

        private void btnStartRecommended_Click(object sender, EventArgs e)
        {
            if (_recommendedPrefs == null)
            {
                RefreshCards(recomputeRecommended: true);
            }

            StartQuiz(_recommendedPrefs);
        }

        private void lnkChangePreferences_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            OpenRecommendedPreferencesPopup();
        }

        private void btnStartAdaptive_Click(object sender, EventArgs e)
        {
            StartQuiz(_adaptivePrefs);
        }

        private void sfButton1_Click(object sender, EventArgs e)
        {
            OpenPreferencesPopup();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            var start = new Start();
            start.StartPosition = FormStartPosition.CenterScreen;
            start.Show();
            Close();
        }

        private sealed class PrefsStore
        {
            public QuizPreferences AdaptivePrefs { get; set; }
            public QuizPreferences RecommendedOverride { get; set; }
        }
    }
}