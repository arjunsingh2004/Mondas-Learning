using Mondas.Models;
using Mondas.Services;
using Syncfusion.WinForms.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Windows.Forms;

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
            InitLists();
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

            if (cmbSource != null && cmbSource.SelectedIndex < 0 &&  cmbSource.Items.Count > 0)
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
            var topics = _moduleService.LoadModules().Select(x => (x.Topic ?? "").Trim()) .Where(x => x.Length > 0).Distinct(StringComparer.OrdinalIgnoreCase).OrderBy(x => x, StringComparer.OrdinalIgnoreCase).ToList();

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

        private void btnOpenResource_Click(object sender, EventArgs e)
        {

        }

        private void btnMarkComplete_Click(object sender, EventArgs e)
        {

        }

        private void btnBookmark_Click(object sender, EventArgs e)
        {

        }

        private void btnRefreshModules_Click(object sender, EventArgs e)
        {

        }

        private void cmbSource_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cmbTopic_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cmbModuleType_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnLogout_Click(object sender, EventArgs e)
        {

        }
    }
}
