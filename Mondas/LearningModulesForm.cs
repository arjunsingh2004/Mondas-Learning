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
            _moduleService = new LearningModulesService(modulesPath);
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
            SyncListSelections(module?.Id ?? "");
            ShowModuleDetail(module);
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
                overview.Text = module == null ? "" : BuildLessonText(module);
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

            ShowPreview(module);
            ShowKnowledgeCheck(module);
            UpdateButtons();
        }

        private void ClearModuleDetail()
        {
            _selectedModule = null;
            ShowModuleDetail(null);
        }

        private string BuildLessonText(LearningModule module)
        {
            var lines = new List<string>();

            if (module == null)
            {
                return "";
            }

            lines.Add(module.Title);
            lines.Add("");
            lines.Add("TOPIC: " + (module.Topic ?? "").ToUpperInvariant());
            lines.Add("TYPE: " + (module.Type ?? "").ToUpperInvariant());
            lines.Add("ESTIMATED TIME: " + module.EstimatedMinutes.ToString(CultureInfo.InvariantCulture) + " MINS");

            AddSection(lines, "OVERVIEW", module.Overview);
            AddBulletSection(lines, "OBJECTIVES", module.Objectives);
            AddBulletSection(lines, "KEY POINTS", module.KeyPoints);
            AddBulletSection(lines, "RED FLAGS", module.RedFlags);
            AddBulletSection(lines, "CHECKLIST", module.Checklist);
            AddExamplesSection(lines, module.Examples);
            AddBulletSection(lines, "REFLECTION QUESTIONS", module.ReflectionQuestions);

            lines.Add("");
            lines.Add("WHY THIS WAS PICKED");
            lines.Add(_moduleService.BuildMatchReason(module, _stats, ReadStatsSource()));

            return string.Join(Environment.NewLine, lines);
        }

        private static void AddSection(List<string> lines, string heading, string text)
        {
            var value = (text ?? "").Trim();

            if (value.Length == 0)
            {
                return;
            }

            lines.Add("");
            lines.Add(heading);
            lines.Add(value);
        }

        private static void AddBulletSection(List<string> lines, string heading, IEnumerable<string> values)
        {
            var items = (values ?? Enumerable.Empty<string>()).Where(x => !string.IsNullOrWhiteSpace(x)).Select(x => x.Trim()).ToList();
        
            if (items.Count == 0)
            {
                return;
            }

            lines.Add("");
            lines.Add(heading);

            foreach (var item in items)
            {
                lines.Add("• " + item);
            }
        }

        private static void AddExamplesSection(List<string> lines, IEnumerable<LearningExample> examples)
        {
            var items = (examples ?? Enumerable.Empty<LearningExample>()).Where(x => x != null).ToList();

            if (items.Count == 0)
            {
                return;
            }

            lines.Add("");
            lines.Add("EXAMPLES");

            foreach (var example in items)
            {
                lines.Add("");
                lines.Add((example.Title ?? "").Trim());

                if (!string.IsNullOrWhiteSpace(example.Scenario))
                {
                    lines.Add(example.Scenario.Trim());
                }

                if (!string.IsNullOrWhiteSpace(example.Takeaway))
                {
                    lines.Add("Takeaway: " + example.Takeaway.Trim());
                }
            }
        }

        private void ShowKnowledgeCheck(LearningModule module)
        {
            if (lblCheckQuestion == null || flpCheckOptions == null || lblCheckFeedback == null)
            {
                return;
            }

            flpCheckOptions.Controls.Clear();
            lblCheckFeedback.Text = "";

            var questions = module?.CheckQuestions ?? new List<LearningCheckQuestion>();

            if (module == null || questions.Count == 0)
            {
                lblCheckQuestion.Text = "NO KNOWLEDGE CHECK FOR THIS MODULE";
                btnSubmitCheck.Enabled = false;
                btnNextCheck.Enabled = false;

                return;
            }

            if (_checkIndex < 0 || _checkIndex >= questions.Count)
            {
                _checkIndex = 0;
            }

            var question = questions[_checkIndex];
            lblCheckQuestion.Text = $"QUESTION {_checkIndex + 1} OF {questions.Count} · {question.Prompt}";

            foreach (var option in question.Options ?? new List<LearningCheckOption>())
            {
                var radio = new RadioButton { AutoSize = true, Text = option.Text ?? "", Tag = option, Margin = new Padding(0, 0, 0, 10) };
                flpCheckOptions.Controls.Add(radio);
            }

            btnSubmitCheck.Enabled = flpCheckOptions.Controls.Count > 0;
            btnNextCheck.Enabled = questions.Count > 1;
        }

        private void ShowPreview(LearningModule module)
        {
            var preview = FindAny<Control>("wvPreview", "webView2Preview", "webPreview");

            if (preview == null)
            {
                return;
            }

            var url = module == null ? "" : BuildPreviewUrl(module);

            if (string.IsNullOrWhiteSpace(url))
            {
                NavPreviewHtml(preview, "<html><body style='font-family:Agency; padding:24px; color:#444;'><h3>Preview unavailable</h3><p>Select a module with a preview URL or use Open Resource.</p></body></html>");
                return;
            }

            try
            {
                var sourceProp = preview.GetType().GetProperty("Source");

                if (sourceProp != null)
                {
                    sourceProp.SetValue(preview, new Uri(url));
                    return;
                }

                var navigateMethod = preview.GetType().GetMethod("Navigate", new[] { typeof(string) });

                if (navigateMethod != null)
                {
                    navigateMethod.Invoke(preview, new object[] { url });
                    return;
                }
            }

            catch
            {
                NavPreviewHtml(preview, "<html><body style='font-family:Agency; padding:24px; color:#444;'><h3>Preview failed</h3><p>Use Open Resource instead.</p></body></html>");
            }
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

            if (previewUrl.Contains("youtube.com/watch?v=", StringComparison.OrdinalIgnoreCase))
            {
                var id = previewUrl.Split(new[] { "watch?v=" }, StringSplitOptions.None).LastOrDefault() ?? "";
                var amp = id.IndexOf('&');

                if (amp >= 0)
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

            var questions = _selectedModule.CheckQuestions ?? new List<LearningCheckQuestion>();

            if (_checkIndex < 0 || _checkIndex >= questions.Count)
            {
                return;
            }

            var selected = flpCheckOptions.Controls.OfType<RadioButton>().FirstOrDefault(x => x.Checked);
        
            if (selected == null)
            {
                lblCheckFeedback.Text = "Select an answer before continuing.";
                return;
            }

            var option = selected.Tag as LearningCheckOption;

            if (option == null)
            {
                return;
            }

            lblCheckFeedback.Text = option.IsCorrect ? "Correct. " + (option.Feedback ?? "").Trim() : "Not quite. " + (option.Feedback ?? "").Trim();

            if (option.IsCorrect)
            {
                _moduleService.MarkCheckPassed(_userKey, _selectedModule.Id);
                _state = _moduleService.LoadState(_userKey);
                UpdateStatus();
            }
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

            _checkIndex = (_checkIndex + 1) % questions.Count;
            ShowKnowledgeCheck(_selectedModule);
        }
    }
}