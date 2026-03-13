using Mondas.Models;
using Mondas.Services;
using Syncfusion.WinForms.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Drawing;
using System.Threading.Tasks;

namespace Mondas
{
    public partial class LearningModulesForm : SfForm
    {
        private readonly string _userKey;
        private readonly long _userId;
        private readonly string _dbPath;
        private readonly DashboardStatsService _statsService;
        private readonly LearningModulesService _moduleService;
        private List<LearningModule> _modules = new List<LearningModule>();
        private LearningModuleState _state = new LearningModuleState();
        private DashboardStats _stats = new DashboardStats();
        private LearningModule _selectedModule;
        private bool _busy;
        private int _checkIndex = -1;
        private bool _checkSubmitted;
        private int _checkCorrectCount;
        private DateTime? _questionShownUtc;

        public LearningModulesForm() : this("local")
        {

        }

        public LearningModulesForm(string userKey)
        {
            InitializeComponent();

            _userKey = string.IsNullOrWhiteSpace(userKey) ? "local" : userKey.Trim();
            _userId = ParseUserId(_userKey);
            _dbPath = Path.Combine(AppContext.BaseDirectory, "mondas.db");

            var modulesPath = Path.Combine(AppContext.BaseDirectory, "Resources", "learning_modules.json");

            _statsService = new DashboardStatsService(_dbPath);
            _moduleService = new LearningModulesService(modulesPath, _dbPath);
        }

        private void LearningModulesForm_Load(object sender, EventArgs e)
        {
            if (LicenseManager.UsageMode == LicenseUsageMode.Designtime)
            {
                return;
            }

            InitFilters();
            RefreshModules();
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

            var s = userKey.Substring(2);

            return long.TryParse(s, out var id) ? id : 0;
        }

        private void InitFilters()
        {
            _busy = true;

            if (cmbSource != null && cmbSource.Items.Count == 0)
            {
                cmbSource.Items.AddRange(new object[] { "All", "Quiz", "Phishing Simulator", "Password Workshop" });
            }

            if (cmbSource != null && cmbSource.SelectedIndex < 0 && cmbSource.Items.Count > 0)
            {
                cmbSource.SelectedIndex = 0;
            }

            ApplyTopicFilter();
            ApplyTypeFilter();

            _busy = false;
        }

        private void ApplyTopicFilter()
        {
            if (cmbTopic == null)
            {
                return;
            }

            var selected = (cmbTopic.SelectedItem?.ToString() ?? cmbTopic.Text ?? "").Trim();
            var topics = (_modules.Count == 0 ? _moduleService.LoadModules() : _modules).Select(x => (x.Topic ?? "").Trim()).Where(x => x.Length > 0).Distinct(StringComparer.OrdinalIgnoreCase).OrderBy(x => x, StringComparer.OrdinalIgnoreCase).ToList();

            cmbTopic.BeginUpdate();
            cmbTopic.Items.Clear();
            cmbTopic.Items.Add("All");

            foreach (var topic in topics)
            {
                cmbTopic.Items.Add(topic);
            }

            var idx = cmbTopic.Items.IndexOf(string.IsNullOrWhiteSpace(selected) ? "All" : selected);

            if (idx >= 0)
            {
                cmbTopic.SelectedIndex = idx;
            }

            else if (cmbTopic.Items.Count > 0)
            {
                cmbTopic.SelectedIndex = 0;
            }

            cmbTopic.EndUpdate();
        }

        private void ApplyTypeFilter()
        {
            if (cmbModuleType == null)
            {
                return;
            }

            var selected = (cmbModuleType.SelectedItem?.ToString() ?? cmbModuleType.Text ?? "").Trim();
            var types = (_modules.Count == 0 ? _moduleService.LoadModules() : _modules).Select(x => (x.Type ?? "").Trim()).Where(x => x.Length > 0).Distinct(StringComparer.OrdinalIgnoreCase).OrderBy(x => x, StringComparer.OrdinalIgnoreCase).ToList();

            cmbModuleType.BeginUpdate();
            cmbModuleType.Items.Clear();
            cmbModuleType.Items.Add("All");

            foreach (var type in types)
            {
                cmbModuleType.Items.Add(type);
            }

            var idx = cmbModuleType.Items.IndexOf(string.IsNullOrWhiteSpace(selected) ? "All" : selected);

            if (idx >= 0)
            {
                cmbModuleType.SelectedIndex = idx;
            }

            else if (cmbModuleType.Items.Count > 0)
            {
                cmbModuleType.SelectedIndex = 0;
            }

            cmbModuleType.EndUpdate();
        }

        private void RefreshModules()
        {
            if (_busy)
            {
                return;
            }

            _modules = _moduleService.LoadModules() ?? new List<LearningModule>();
            _state = _moduleService.LoadState(_userKey);
            _stats = LoadStats(ReadStatsSource());

            ApplyHeader();
            ShowRecommended();
            ShowAllModules();
            UpdateStatus();
            RestoreSelectionOrPickDefault();
        }

        private DashboardStats LoadStats(StatsSource source)
        {
            try
            {
                return _statsService.Load(_userId, _userKey, source);
            }

            catch
            {
                return new DashboardStats { UserId = _userId, UserKey = _userKey, FullName = "USER" };
            }
        }

        private void ApplyHeader()
        {
            var name = (_stats.FullName ?? "USER").Trim();

            if (name.Length == 0)
            {
                name = "USER";
            }

            var upper = name.ToUpperInvariant();

            if (lblUser != null)
            {
                lblUser.Text = upper;
            }

            if (lblFooterUser != null)
            {
                lblFooterUser.Text = "USER: " + upper;
            }
        }

        private void ShowRecommended()
        {
            var list = FindAny<ListView>("lvRecommended", "lvRecommendedModules");

            if (list == null)
            {
                return;
            }

            var filtered = GetFilteredModules();
            var rec = _moduleService.BuildRecommendations(filtered, _stats, ReadStatsSource(), 8);

            list.BeginUpdate();
            list.Items.Clear();

            foreach (var row in rec)
            {
                var module = row.Module;
                var item = new ListViewItem(BuildPrefix(module) + module.Title);

                item.SubItems.Add((module.Type ?? "").ToUpperInvariant());
                item.SubItems.Add(row.MatchText);
                item.Tag = module.Id;

                list.Items.Add(item);
            }

            list.EndUpdate();
        }

        private void ShowAllModules()
        {
            var list = FindAny<ListView>("lvAllModules", "lvModules");

            if (list == null)
            {
                return;
            }

            var filtered = GetFilteredModules();

            list.BeginUpdate();
            list.Items.Clear();

            foreach (var module in filtered.OrderBy(x => x.Title, StringComparer.OrdinalIgnoreCase))
            {
                var item = new ListViewItem(BuildPrefix(module) + module.Title);

                item.SubItems.Add((module.Topic ?? "").ToUpperInvariant());
                item.SubItems.Add((module.Type ?? "").ToUpperInvariant());
                item.Tag = module.Id;

                list.Items.Add(item);
            }

            list.EndUpdate();
        }

        private List<LearningModule> GetFilteredModules()
        {
            var source = ReadStatsSource();
            var topic = ReadFilterText(cmbTopic);
            var type = ReadFilterText(cmbModuleType);

            return _modules.Where(x => _moduleService.AppliesToSource(x, source)).Where(x => _moduleService.TopicMatches(x, topic)).Where(x => _moduleService.TypeMatches(x, type)).ToList();
        }
        
        private void RestoreSelectionOrPickDefault()
        {
            var filtered = GetFilteredModules();

            if (_selectedModule != null)
            {
                var keep = filtered.FirstOrDefault(x => string.Equals(x.Id, _selectedModule.Id, StringComparison.OrdinalIgnoreCase));

                if (keep != null)
                {
                    SelectModule(keep);
                    return;
                }
            }

            var rec = _moduleService.BuildRecommendations(filtered, _stats, ReadStatsSource(), 8).FirstOrDefault()?.Module;

            if (rec != null)
            {
                SelectModule(rec);
                return;
            }

            if (filtered.Count > 0)
            {
                SelectModule(filtered[0]);
                return;
            }

            ClearModuleDetail();
        }

        private void SelectModule(LearningModule module)
        {
            _selectedModule = module;
            _checkIndex = 0;
            _checkSubmitted = false;
            _checkCorrectCount = 0;
            SyncListSelections(module?.Id ?? "");
            ShowModuleDetail(module);

            if (IsCheckTabOpen())
            {
                StartCheckTiming();
            }

            else
            {
                ResetCheckTiming();
            }
        }

        private void SyncListSelections(string moduleId)
        {
            _busy = true;

            try
            {
                SyncOneListSelection(FindAny<ListView>("lvRecommended", "lvRecommendedModules"), moduleId);
                SyncOneListSelection(FindAny<ListView>("lvAllModules", "lvModules"), moduleId);
            }

            finally
            {
                _busy = false;
            }
        }

        private static void SyncOneListSelection(ListView list, string moduleId)
        {
            if (list == null)
            {
                return;
            }

            list.SelectedItems.Clear();

            foreach (ListViewItem item in list.Items)
            {
                var id = item.Tag as string;

                if (string.Equals(id, moduleId, StringComparison.OrdinalIgnoreCase))
                {
                    item.Selected = true;
                    item.Focused = true;
                    item.EnsureVisible();
                    break;
                }
            }
        }

        private void ShowModuleDetail(LearningModule module)
        {
            var title = lblModuleTitle;
            var meta = lblModuleMeta;
            var hint = lblModuleReason;
            var overview = rtbOverview;
            var resources = lvResources;

            if (title != null)
            {
                title.Text = module == null ? "SELECT A MODULE" : (module.Title ?? "").ToUpperInvariant();
            }

            if (meta != null)
            {
                meta.Text = module == null ? "TOPIC · TYPE · ESTIMATED TIME" : $"{(module.Topic ?? "").ToUpperInvariant()} · {(module.Type ?? "").ToUpperInvariant()} · {module.EstimatedMinutes} MINS";
            }

            if (hint != null)
            {
                hint.Text = module == null ? "Recommended modules will appear here based on your weak areas and misconceptions." : _moduleService.BuildMatchReason(module, _stats, ReadStatsSource());
            }

            if (overview != null)
            {
                ShowOverview(module);
            }

            if (resources != null)
            {
                resources.BeginUpdate();
                resources.Items.Clear();

                if (module != null)
                {
                    foreach (var row in module.Resources ?? new List<LearningResource>())
                    {
                        var item = new ListViewItem(row.Title ?? "");
                        item.SubItems.Add((row.Type ?? "").ToUpperInvariant());
                        item.SubItems.Add(row.Source ?? "");
                        item.Tag = row.Url ?? "";

                        resources.Items.Add(item);
                    }
                }

                resources.EndUpdate();
            }

            _ = ShowPreview(module);
            ShowKnowledgeCheck(module);
            UpdateButtons();
        }

        private void ShowOverview(LearningModule module)
        {
            if (rtbOverview == null)
            {
                return;
            }

            rtbOverview.Clear();
            rtbOverview.ReadOnly = false;
            rtbOverview.BackColor = Color.White;
            rtbOverview.ForeColor = Color.Black;

            if (module == null)
            {
                rtbOverview.ReadOnly = true;
                return;
            }

            AddOverviewLine((module.Title ?? "").ToUpperInvariant(), true);
            AddOverviewLine($"{(module.Topic ?? "").ToUpperInvariant()} · {(module.Type ?? "").ToUpperInvariant()} · {module.EstimatedMinutes} MINS", true);

            AddOverviewSection("OVERVIEW", module.Overview);
            AddOverviewBulletSection("OBJECTIVES", module.Objectives);
            AddOverviewBulletSection("KEY POINTS", module.KeyPoints);
            AddOverviewBulletSection("RED FLAGS", module.RedFlags);
            AddOverviewBulletSection("CHECKLIST", module.Checklist);
            AddOverviewExamples(module.Examples);
            AddOverviewBulletSection("REFLECTION QUESTIONS", module.ReflectionQuestions);
            AddOverviewSection("WHY THIS WAS PICKED", _moduleService.BuildMatchReason(module, _stats, ReadStatsSource()));

            rtbOverview.SelectionStart = 0;
            rtbOverview.SelectionLength = 0;
            rtbOverview.ReadOnly = true;
        }

        private void AddOverviewSection(string heading, string text)
        {
            var value = (text ?? "").Trim();

            if (value.Length == 0)
            {
                return;
            }

            AddOverviewLine("", false);
            AddOverviewLine(heading, false);
            AddOverviewLine(value, true);
        }

        private void AddOverviewBulletSection(string heading, IEnumerable<string> values)
        {
            var items = (values ?? Enumerable.Empty<string>()).Where(x => !string.IsNullOrWhiteSpace(x)).Select(x => x.Trim()).ToList();
        
            if (items.Count == 0)
            {
                return;
            }

            AddOverviewLine("", false);
            AddOverviewLine(heading, false);

            foreach (var item in items)
            {
                AddOverviewLine("• " + item, false);
            }

            AddOverviewLine("", false);
        }

        private void AddOverviewExamples(IEnumerable<LearningExample> examples)
        {
            var items = (examples ?? Enumerable.Empty<LearningExample>()).Where(x => x != null).ToList();

            if (items.Count == 0)
            {
                return;
            }

            AddOverviewLine("", false);
            AddOverviewLine("EXAMPLES", false);

            foreach (var item in items)
            {
                if (!string.IsNullOrWhiteSpace(item.Title))
                {
                    AddOverviewLine(item.Title.Trim(), false);
                }

                if (!string.IsNullOrWhiteSpace(item.Scenario))
                {
                    AddOverviewLine(item.Scenario.Trim(), false);
                }

                if (!string.IsNullOrWhiteSpace(item.Takeaway))
                {
                    AddOverviewLine("Takeaway: " + item.Takeaway.Trim(), false);
                }

                AddOverviewLine("", false);
            }
        }

        private void AddOverviewLine(string text,bool addGapAfter)
        {
            rtbOverview.AppendText(text + Environment.NewLine);

            if (addGapAfter)
            {
                rtbOverview.AppendText(Environment.NewLine);
            }
        }

        private void ClearModuleDetail()
        {
            _selectedModule = null;
            ShowModuleDetail(null);
        }

        private void ShowKnowledgeCheck(LearningModule module)
        {
            if (lblCheckQuestion == null || flpCheckOptions == null || lblCheckFeedback == null)
            {
                return;
            }

            flpCheckOptions.SuspendLayout();
            flpCheckOptions.Controls.Clear();
            lblCheckFeedback.Text = "";
            lblCheckFeedback.ForeColor = Color.FromArgb(80, 80, 80);

            var questions = module?.CheckQuestions ?? new List<LearningCheckQuestion>();

            if (module == null || questions.Count == 0)
            {
                lblCheckQuestion.Text = "NO KNOWLEDGE CHECK FOR THIS MODULE";
                btnSubmitCheck.Enabled = false;
                btnNextCheck.Enabled = false;
                btnNextCheck.Text = "NEXT QUESTION";
                flpCheckOptions.ResumeLayout();

                return;
            }

            if (_checkIndex < 0 || _checkIndex >= questions.Count)
            {
                _checkIndex = 0;
            }

            var question = questions[_checkIndex];
            lblCheckQuestion.Text = $"QUESTION {_checkIndex + 1} OF {questions.Count}{Environment.NewLine}{question.Prompt}";

            foreach (var option in question.Options ?? new List<LearningCheckOption>())
            {
                var radio = new RadioButton { AutoSize = false, Width = Math.Max(320, flpCheckOptions.ClientSize.Width - 28), Height = 42, Text = option.Text ?? "", Tag = option, Margin = new Padding(0, 0, 0, 18), TextAlign = ContentAlignment.MiddleLeft, UseVisualStyleBackColor = true};
                flpCheckOptions.Controls.Add(radio);
            }

            _checkSubmitted = false;
            btnSubmitCheck.Enabled = flpCheckOptions.Controls.Count > 0;
            btnNextCheck.Enabled = false;
            btnNextCheck.Text = _checkIndex == questions.Count - 1 ? "FINISH CHECK" : "NEXT QUESTION";

            flpCheckOptions.ResumeLayout();
        }

        private static TabControl FindTabControl(Control parent)
        {
            if (parent == null)
            {
                return null;
            }

            foreach (Control child in parent.Controls)
            {
                if (child is TabControl tabs)
                {
                    return tabs;
                }

                var nested = FindTabControl(child);

                if (nested != null)
                {
                    return nested;
                }
            }

            return null;
        }

        private bool IsCheckTabOpen()
        {
            var tabs = FindTabControl(this);

            if (tabs?.SelectedTab == null)
            {
                return false;
            }

            return tabs.SelectedTab.Text.IndexOf("CHECK", StringComparison.OrdinalIgnoreCase) >= 0;
        }

        private void StartCheckTiming()
        {
            if (_selectedModule == null)
            {
                return;
            }

            if (_checkSubmitted)
            {
                return;
            }

            _questionShownUtc = DateTime.UtcNow;
        }

        private void ResetCheckTiming()
        {
            _questionShownUtc = null;

            if (_checkSubmitted)
            {
                return;
            }

            lblCheckFeedback.Text = "";

            foreach (var radio in flpCheckOptions.Controls.OfType<RadioButton>())
            {
                radio.Checked = false;
            }

            btnSubmitCheck.Enabled = flpCheckOptions.Controls.OfType<RadioButton>().Any();
            btnNextCheck.Enabled = false;
        }

        private async Task ShowPreview(LearningModule module)
        {
            if (wvPreview == null)
            {
                return;
            }

            try
            {
                await wvPreview.EnsureCoreWebView2Async(null);
            }

            catch
            {
                return;
            }

            var url = module == null ? "" : BuildPreviewUrl(module);

            if (string.IsNullOrWhiteSpace(url))
            {
                wvPreview.NavigateToString(BuildPreviewHtml("No video available for this module.", "Use Open Resource to open the full lesson."));
                return;
            }

            try
            {
                wvPreview.Source = new Uri(url);
            }

            catch
            {
                wvPreview.NavigateToString(BuildPreviewHtml("Preview unavailable.", "Use Open Resource to view the content."));
            }
        }

        private static string BuildPreviewHtml(string title, string text)
        {
            return "<html><body style='font-family:Agency; padding:24px; color:#222;'>" + $"<h2 style='margin-top:0;'>{title}</h2>" + $"<p>{text}</p>" + "</body></html>";
        }

        private static void NavPreviewHtml(Control preview, string html)
        {
            try
            {
                var method = preview.GetType().GetMethod("NavigateToString", new[] { typeof(string) });
                
                if (method != null)
                {
                    method.Invoke(preview, new object[] { html });
                }
            }

            catch
            {

            }
        }

        private static string BuildPreviewUrl(LearningModule module)
        {
            if (module == null)
            {
                return "";
            }

            var previewUrl = (module.PreviewUrl ?? "").Trim();

            if (previewUrl.Length == 0)
            {
                return "";
            }

            if (previewUrl.Contains("youtube.com/embed/", StringComparison.OrdinalIgnoreCase))
            {
                return previewUrl;
            }

            if (previewUrl.Contains("youtube.com/watch?v=", StringComparison.OrdinalIgnoreCase))
            {
                var id = previewUrl.Split(new[] { "watch?v=" }, StringSplitOptions.None).LastOrDefault() ?? "";
                var amp = id.IndexOf('&');

                if (amp  >= 0)
                {
                    id = id.Substring(0, amp);
                }

                if (id.Length > 0)
                {
                    return "https://www.youtube.com/embed/" + id;
                }
            }

            if (previewUrl.Contains("youtu.be/", StringComparison.OrdinalIgnoreCase))
            {
                var id = previewUrl.Split('/').LastOrDefault() ?? "";
                var q = id.IndexOf('?');

                if (q >= 0)
                {
                    id = id.Substring(0, q);
                }

                if (id.Length > 0)
                {
                    return "https://www.youtube.com/embed/" + id;
                }
            }

            return previewUrl;
        }

        private void UpdateButtons()
        {
            if (btnOpenResource != null)
            {
                btnOpenResource.Enabled = _selectedModule != null;
            }

            if (btnMarkComplete != null)
            {
                btnMarkComplete.Enabled = _selectedModule != null;
                btnMarkComplete.Text = IsCompleted(_selectedModule) ? "MARK INCOMPLETE" : "MARK COMPLETE";
            }

            if (btnBookmark != null)
            {
                btnBookmark.Enabled = _selectedModule != null;
                btnBookmark.Text = IsBookmarked(_selectedModule) ? "REMOVE BOOKMARK" : "BOOKMARK";
            }
        }

        private void UpdateStatus()
        {
            if (lblProgressInfo == null)
            {
                return;
            }

            var completed = _state.CompletedModuleIds.Count;
            var bookmarked = _state.BookmarkedModuleIds.Count;
            var passed = _state.PassedCheckModuleIds.Count;

            lblProgressInfo.Text = $"{completed} COMPLETED · {bookmarked} BOOKMARKED · {passed} CHECKS PASSED";
        }

        private bool IsCompleted(LearningModule module)
        {
            if (module == null)
            {
                return false;
            }

            return _state.CompletedModuleIds.Any(x => string.Equals(x, module.Id, StringComparison.OrdinalIgnoreCase));
        }

        private bool IsBookmarked(LearningModule module)
        {
            if (module == null)
            {
                return false;
            }

            return _state.BookmarkedModuleIds.Any(x => string.Equals(x, module.Id, StringComparison.OrdinalIgnoreCase));
        }

        private string BuildPrefix(LearningModule module)
        {
            var completed = IsCompleted(module);
            var bookmarked = IsBookmarked(module);

            if (completed && bookmarked)
            {
                return "✔️ 🔖 ";
            }

            else if (completed)
            {
                return "✔️ ";
            }

            else if (bookmarked)
            {
                return "🔖 ";
            }

            return "";
        }

        private StatsSource ReadStatsSource()
        {
            var text = ReadFilterText(cmbSource).ToUpperInvariant();

            if (text.Contains("PHISH"))
            {
                return StatsSource.PhishingSimulator;
            }

            if (text.Contains("PASSWORD"))
            {
                return StatsSource.PasswordWorkshop;
            }

            if (text.Contains("QUIZ"))
            {
                return StatsSource.Quiz;
            }

            return StatsSource.All;
        }

        private static string ReadFilterText(ComboBox combo)
        {
            return (combo?.SelectedItem?.ToString() ?? combo?.Text ?? "").Trim();
        }

        private T FindAny<T>(params string[] names) where T : Control
        {
            foreach(var name in names)
            {
                var found = Controls.Find(name, true);

                if (found != null && found.Length > 0 && found[0] is T hit)
                {
                    return hit;
                }
            }

            return null;
        }

        private void btnOpenResource_Click(object sender, EventArgs e)
        {
            if (_selectedModule == null)
            {
                return;
            }

            var resources = FindAny<ListView>("lvResources", "lvModuleResources");
            string url = "";

            if (resources != null && resources.SelectedItems.Count > 0)
            {
                url = resources.SelectedItems[0].Tag as string ?? "";
            }

            if (string.IsNullOrWhiteSpace(url))
            {
                url = (_selectedModule.OpenUrl ?? "").Trim();
            }

            if (string.IsNullOrWhiteSpace(url))
            {
                return;
            }

            Process.Start(new ProcessStartInfo(url) { UseShellExecute = true });
        }

        private void btnMarkComplete_Click(object sender, EventArgs e)
        {
            if (_selectedModule == null)
            {
                return;
            }

            _moduleService.ToggleComplete(_userKey, _selectedModule.Id);
            _state = _moduleService.LoadState(_userKey);

            ShowRecommended();
            ShowAllModules();
            SelectModule(_selectedModule);
            UpdateStatus();
        }

        private void btnBookmark_Click(object sender, EventArgs e)
        {
            if (_selectedModule == null)
            {
                return;
            }

            _moduleService.ToggleBookmark(_userKey, _selectedModule.Id);
            _state = _moduleService.LoadState(_userKey);

            ShowRecommended();
            ShowAllModules();
            SelectModule(_selectedModule);
            UpdateStatus();
        }

        private void btnRefreshModules_Click(object sender, EventArgs e)
        {
            RefreshModules();
        }

        private void cmbSource_SelectedIndexChanged(object sender, EventArgs e)
        {
            RefreshModules();
        }

        private void cmbTopic_SelectedIndexChanged(object sender, EventArgs e)
        {
            RefreshModules();
        }

        private void cmbModuleType_SelectedIndexChanged(object sender, EventArgs e)
        {
            RefreshModules();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            var start = new Start();
            start.Show();
            Close();
        }

        private void lvRecommended_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_busy)
            {
                return;
            }

            var list = sender as ListView;

            if (list == null || list.SelectedItems.Count == 0)
            {
                return;
            }

            var id = list.SelectedItems[0].Tag as string;
            var module = _modules.FirstOrDefault(x => string.Equals(x.Id, id, StringComparison.OrdinalIgnoreCase));

            if (module != null)
            {
                SelectModule(module);
            }
        }

        private void lvModules_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_busy)
            {
                return;
            }

            var list = sender as ListView;

            if (list == null || list.SelectedItems.Count == 0)
            {
                return;
            }

            var id = list.SelectedItems[0].Tag as string;
            var module = _modules.FirstOrDefault(x => string.Equals(x.Id, id, StringComparison.OrdinalIgnoreCase));

            if (module != null)
            {
                SelectModule(module);
            }
        }

        private void btnSubmitCheck_Click(object sender, EventArgs e)
        {
            if (_selectedModule == null)
            {
                return;
            }

            if (_checkSubmitted)
            {
                return;
            }

            var questions = _selectedModule.CheckQuestions ?? new List<LearningCheckQuestion>();

            if (_checkIndex < 0 || _checkIndex >= questions.Count)
            {
                return;
            }

            var selected = flpCheckOptions.Controls.OfType<RadioButton>().FirstOrDefault(x => x.Checked);
        
            if (selected == null)
            {
                lblCheckFeedback.ForeColor = Color.Firebrick;
                lblCheckFeedback.Text = "Select an answer before continuing.";
                return;
            }

            var option = selected.Tag as LearningCheckOption;

            if (option == null)
            {
                return;
            }

            var secondsTaken = _questionShownUtc.HasValue ? Math.Max(0.0, (DateTime.UtcNow - _questionShownUtc.Value).TotalSeconds) : 0.0; 

            _moduleService.SaveCheckAttempt(_userKey, _selectedModule, _checkIndex, option.IsCorrect, secondsTaken);

            if (option.IsCorrect)
            {
                _checkCorrectCount++;
                lblCheckFeedback.ForeColor = Color.DarkGreen;
                lblCheckFeedback.Text = "Correct! " + (option.Feedback ?? "").Trim();
            }

            else
            {
                lblCheckFeedback.ForeColor = Color.Firebrick;
                lblCheckFeedback.Text = "Not quite. " + (option.Feedback ?? "").Trim();
            }

            foreach (var radio in flpCheckOptions.Controls.OfType<RadioButton>())
            {
                radio.Enabled = false;
            }

            _checkSubmitted = true;
            btnSubmitCheck.Enabled = false;
            btnNextCheck.Enabled = true;
            _questionShownUtc = null;
        }

        private void btnNextCheck_Click(object sender, EventArgs e)
        {
            if (_selectedModule == null)
            {
                return;
            }

            var questions = _selectedModule.CheckQuestions ?? new List<LearningCheckQuestion>();
        
            if (questions.Count == 0)
            {
                return;
            }

            if (!_checkSubmitted)
            {
                lblCheckFeedback.ForeColor = Color.Firebrick;
                lblCheckFeedback.Text = "Submit an answer before continuing.";

                return;
            }

            if (_checkIndex == questions.Count - 1)
            {
                var passMark = Math.Max(1, (int)Math.Ceiling(questions.Count * 0.7));
                var passed = _checkCorrectCount >= passMark;

                if (passed)
                {
                    _moduleService.MarkCheckPassed(_userKey, _selectedModule.Id);
                }

                _state = _moduleService.LoadState(_userKey);
                UpdateStatus();
                ShowRecommended();
                ShowAllModules();

                MessageBox.Show(this, passed ? $"Checked passed. Score: {_checkCorrectCount}/{questions.Count}" : $"Check finished. Score, {_checkCorrectCount}/{questions.Count}", "Mondas", MessageBoxButtons.OK, passed ? MessageBoxIcon.Information : MessageBoxIcon.Warning);
                SelectModule(_selectedModule);
                return;
            }

            _checkIndex++;
            ShowKnowledgeCheck(_selectedModule);
            StartCheckTiming();
        }

        private void tabLearning_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (IsCheckTabOpen())
            {
                StartCheckTiming();
            }

            else
            {
                ResetCheckTiming();
            }
        }
    }
}