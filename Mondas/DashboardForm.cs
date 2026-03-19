using Mondas.Models;
using Mondas.Services;
using Syncfusion.WinForms.Controls;
using Syncfusion.Windows.Forms.Tools;
using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;

namespace Mondas
{
    public partial class DashboardForm : SfForm
    {
        private readonly string _userKey;
        private readonly string _dbPath;
        private readonly long _userId;
        private readonly string _reportsDir;
        private readonly DashboardStatsService _stats;
        private readonly Font _masteryHeaderFont;
        private readonly Font _masteryCellFont;
        private ToolTip _adaptiveTip;

        public DashboardForm() : this("local")
        {

        }

        public DashboardForm(long userId) : this(userId > 0 ? "u:" + userId.ToString() : "local")
        {
            _userId = userId;
        }

        public DashboardForm(string userKey)
        {
            InitializeComponent();

            _userKey = string.IsNullOrWhiteSpace(userKey) ? "local" : userKey.Trim();
            _userId = ParseUserId(_userKey);

            _dbPath = Path.Combine(AppContext.BaseDirectory, "mondas.db");
            _stats = new DashboardStatsService(_dbPath);
            _reportsDir = BuildReportsDirectory(_userKey);

            _masteryHeaderFont = CreateUiFont(14f);
            _masteryCellFont = CreateUiFont(12f);

            InitAdaptiveQuizHoverTip();

            if (btnViewReports != null)
            {
                btnViewReports.Click += btnNavReports_Click;
            }

            if (lvRecentReports != null)
            {
                lvRecentReports.DoubleClick += (_, __) => OpenSelectedRecentReport();
            }
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            _masteryHeaderFont?.Dispose();
            _masteryCellFont?.Dispose();
            base.OnFormClosed(e);
        }

        private static Font CreateUiFont(float size)
        {
            string[] families = { "Muro", "Agency FB" };

            foreach (var fam in families)
            {
                try
                {
                    return new Font(fam, size, GraphicsUnit.Point);
                }

                catch
                {
                
                }
            }

            return new Font(SystemFonts.DefaultFont.FontFamily, size, GraphicsUnit.Point);
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

        private void DashboardForm_Load(object sender, EventArgs e)
        {
            if (LicenseManager.UsageMode == LicenseUsageMode.Designtime)
            {
                return;
            }

            if (cmbStatsSource != null && cmbStatsSource.SelectedIndex < 0 && cmbStatsSource.Items.Count > 0)
            {
                cmbStatsSource.SelectedIndex = 0;
            }

            RefreshDashboard();
        }

        private void RefreshDashboard()
        {
            DashboardStats s;

            try
            {
                s = _stats.Load(_userId, _userKey, ReadStatsSource(), minTopicAttempts: 3, misconceptionLimit: 20);

            }

            catch (Exception ex)
            {
                if (lblWelcome != null)
                {
                    lblWelcome.Text = "WELCOME";
                }

                if (lblUser != null)
                {
                    lblUser.Text = "";
                }

                if (lblFooterUser != null)
                {
                    lblFooterUser.Text = "";
                }

                MessageBox.Show(this, "Failed to load dashboard stats:\n\n" + ex.Message, "Mondas", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            ApplyHeader(s);
            ApplyTiles(s);
            ApplyReportsBox(s);
            RenderMasteryByTopic(s);
            RenderMisconceptions(s);
        }

        private void ApplyHeader(DashboardStats s)
        {
            var name = (s.FullName ?? "USER").Trim();
            var upper = name.ToUpperInvariant();

            var first = name.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).FirstOrDefault() ?? name;
            var firstUpper = first.ToUpperInvariant();

            if (lblWelcome != null)
            {
                lblWelcome.Text = $"WELCOME BACK, {firstUpper}!";
            }

            if (lblUser != null)
            {
                lblUser.Text = upper;
            }

            if (lblFooterUser != null)
            {
                lblFooterUser.Text = "USER: " + upper;
            }
        }

        private void ApplyTiles(DashboardStats s)
        {
            if (lblAttemptsValue != null)
            {
                lblAttemptsValue.Text = s.TotalAttempts.ToString();
            }

            if (lblAccuracyValue != null)
            {
                lblAccuracyValue.Text = $"{(s.Accuracy01 * 100.0):0}%";
            }

            if (lblAvgTimeValue != null)
            {
                lblAvgTimeValue.Text = s.AvgSeconds <= 0 ? "—" : $"{s.AvgSeconds:0.0}s";
            }

            if (lblWeakestValue != null)
            {
                lblWeakestValue.Text = s.WeakestTopic.HasValue ? ToTileTopic(s.WeakestTopic.Value) : "—";
            }

            if (lblStrongestValue != null)
            {
                lblStrongestValue.Text = s.StrongestTopic.HasValue ? ToTileTopic(s.StrongestTopic.Value) : "—";
            }
        }

        private void ApplyReportsBox(DashboardStats s)
        {
            if (lblStreak != null)
            {
                lblStreak.Text = s.CurrentStreak.ToString(CultureInfo.InvariantCulture);
            }

            if (lblMistakes != null)
            {
                lblMistakes.Text = s.TotalMistakes.ToString(CultureInfo.InvariantCulture);
            }

            var files = SafeListReportFiles();

            if (lblReportsCount != null)
            {
                lblReportsCount.Text = files.Count.ToString(CultureInfo.InvariantCulture);
            }

            if (lblLastReport != null)
            {
                lblLastReport.Text = files.Count == 0 ? "—" : File.GetLastWriteTime(files[0]).ToString("dd MMM yyyy", CultureInfo.InvariantCulture);
            }

            if (lvRecentReports == null)
            {
                return;
            }

            lvRecentReports.BeginUpdate();

            try
            {
                lvRecentReports.Items.Clear();

                var take = Math.Min(5, files.Count);

                for (int i = 0; i < take; i++)
                {
                    var file = files[i];
                    var name = Path.GetFileNameWithoutExtension(file);
                    var dt = File.GetLastWriteTime(file).ToString("dd MMM yyyy", CultureInfo.InvariantCulture);

                    var item = new ListViewItem(name);
                    item.SubItems.Add(dt);
                    item.Tag = file;

                    lvRecentReports.Items.Add(item);
                }

                if (lvRecentReports.Columns.Count >= 2)
                {
                    var total = lvRecentReports.ClientSize.Width;

                    var dateWidth = 120;
                    lvRecentReports.Columns[1].Width = dateWidth;

                    var reportWidth = total - dateWidth - SystemInformation.VerticalScrollBarWidth - 8;

                    if (reportWidth < 140)
                    {
                        reportWidth = 140;
                    }

                    lvRecentReports.Columns[0].Width = reportWidth;
                }
            }

            finally
            {
                lvRecentReports.EndUpdate();
            }
        }

        private StatsSource ReadStatsSource()
        {
            var text = (cmbStatsSource?.SelectedItem?.ToString() ?? cmbStatsSource?.Text ?? "").Trim().ToUpperInvariant();
        
            if (text.Contains("PHISH"))
            {
                return StatsSource.PhishingSimulator;
            }

            if (text.Contains("AUTHENTICATION"))
            {
                return StatsSource.AuthenticationDefense;
            }

            if (text.Contains("LEARNING"))
            {
                return StatsSource.LearningModules;
            }

            if (text.Contains("QUIZ"))
            {
                return StatsSource.Quiz;
            }

            return StatsSource.All;
        }

        private static string BuildReportsDirectory(string userKey)
        {
            var safe = (string.IsNullOrWhiteSpace(userKey) ? "local" : userKey.Trim()).Replace(":", "_").Replace("/", "_").Replace("\\", "_");

            var dir = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Mondas", "reports", safe);

            Directory.CreateDirectory(dir);
            return dir;
        }

        private List<string> SafeListReportFiles()
        {
            try
            {
                if (string.IsNullOrWhiteSpace(_reportsDir) || !Directory.Exists(_reportsDir))
                {
                    return new List<string>();
                }

                return Directory.GetFiles(_reportsDir, "*.html").OrderByDescending(File.GetLastWriteTimeUtc).ToList();
            }

            catch
            {
                return new List<string>();
            }
        }

        private void OpenSelectedRecentReport()
        {
            if (lvRecentReports == null || lvRecentReports.SelectedItems.Count == 0)
            {
                return;
            }

            var path = lvRecentReports.SelectedItems[0].Tag as string;

            if (string.IsNullOrWhiteSpace(path) || !File.Exists(path))
            {
                return;
            }

            try
            {
                Process.Start(new ProcessStartInfo(path) { UseShellExecute = true });
            }

            catch
            {

            }
        }

        private static string ToTileTopic(Topic topic)
        => topic.ToString().Replace('_', ' ').ToUpperInvariant();

        private void RenderMasteryByTopic(DashboardStats s)
        {
            if (tlpMastery == null)
            {
                return;
            }

            tlpMastery.SuspendLayout();
            tlpMastery.Controls.Clear();
            tlpMastery.ColumnStyles.Clear();
            tlpMastery.RowStyles.Clear();

            tlpMastery.ColumnCount = 4;
            tlpMastery.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 35f));
            tlpMastery.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 35f));
            tlpMastery.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 15f));
            tlpMastery.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 15f));

            tlpMastery.RowCount = 1;
            tlpMastery.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            AddMasteryHeader(0);

            var rows = s.MasteryByTopic.OrderByDescending(x => x.Seen).ToList();

            if (rows.Count == 0)
            {
                tlpMastery.RowCount = 2;
                tlpMastery.RowStyles.Add(new RowStyle(SizeType.AutoSize));
                var empty = new Label { Text = "No attempts yet. Start a quiz to generate stats.", AutoSize = true, Dock = DockStyle.Fill };
                tlpMastery.Controls.Add(empty, 0, 1);
                tlpMastery.SetColumnSpan(empty, 4);
                tlpMastery.ResumeLayout();
                return;
            }

            int r = 1;

            foreach (var row in rows)
            {
                tlpMastery.RowCount++;
                tlpMastery.RowStyles.Add(new RowStyle(SizeType.AutoSize));

                var topicLbl = new Label { Text = row.Topic.ToString().Replace('_', ' '), AutoSize = true, Dock = DockStyle.Fill, TextAlign = ContentAlignment.MiddleLeft, Font = _masteryCellFont };
                var bar = CreateMasteryBar(row.Accuracy01);
                var seenLbl = new Label { Text = row.Seen.ToString(), AutoSize = true, Dock = DockStyle.Fill, TextAlign = ContentAlignment.MiddleCenter, Font = _masteryCellFont };
                var pctLbl = new Label { Text = $"{row.Accuracy01 * 100.0:0}%", AutoSize = true, Dock = DockStyle.Fill, TextAlign = ContentAlignment.MiddleCenter, Font = _masteryCellFont };

                tlpMastery.Controls.Add(topicLbl, 0, r);
                tlpMastery.Controls.Add(bar, 1, r);
                tlpMastery.Controls.Add(seenLbl, 2, r);
                tlpMastery.Controls.Add(pctLbl, 3, r);

                r++;
            }

            tlpMastery.ResumeLayout();
        }

        private void AddMasteryHeader(int row)
        {
            var h1 = HeaderLabel("TOPIC", ContentAlignment.MiddleLeft);
            var h2 = HeaderLabel("MASTERY", ContentAlignment.MiddleLeft);
            var h3 = HeaderLabel("SEEN", ContentAlignment.MiddleCenter);
            var h4 = HeaderLabel("%", ContentAlignment.MiddleCenter);

            tlpMastery.Controls.Add(h1, 0, row);
            tlpMastery.Controls.Add(h2, 1, row);
            tlpMastery.Controls.Add(h3, 2, row);
            tlpMastery.Controls.Add(h4, 3, row);
        }

        private Label HeaderLabel(string text, ContentAlignment align)
        {
            return new Label { Text = text, AutoSize = true, Dock = DockStyle.Fill, Font = _masteryHeaderFont, TextAlign = align };
        }

        private static int ClampToPercent(double accuracy01)
        {
            var v = (int)Math.Round(accuracy01 * 100.0);

            if (v < 0)
            {
                v = 0;
            }

            if (v > 100)
            {
                v = 100;
            }

            return v;
        }

        private ProgressBarAdv CreateMasteryBar(double accuracy01)
        {
            var v = ClampToPercent(accuracy01);

            var bar = new ProgressBarAdv
            {
                Dock = DockStyle.Fill,

                Minimum = 0,
                Maximum = 100,
                Value = v,

                ProgressStyle = ProgressBarStyles.Constant,
                ProgressOrientation = Orientation.Horizontal,

                TextVisible = true,
                TextStyle = ProgressBarTextStyles.Percentage,
                TextAlignment = TextAlignment.Center,
                TextShadow = true,

                BackTubeStartColor = Color.LightGray,
                BackTubeEndColor = Color.White,

                TubeStartColor = Color.RoyalBlue,
                TubeEndColor = Color.RoyalBlue,

                ForeSegments = false,
                SegmentWidth = 12,

                Font = _masteryCellFont,
                FontColor = Color.White,

                Border3DStyle = Border3DStyle.Sunken,
                BorderColor = Color.Black,
                BorderSingle = ButtonBorderStyle.Solid,
                BorderStyle = BorderStyle.Fixed3D,
                ForeColor = Color.RoyalBlue
            };

            return bar;
        }

        private void RenderMisconceptions (DashboardStats s)
        {
            if (lvMisconA == null)
            {
                return;
            }

            lvMisconA.BeginUpdate();

            lvMisconA.View = View.Details;
            lvMisconA.FullRowSelect = true;
            lvMisconA.MultiSelect = false;
            lvMisconA.Scrollable = true;
            lvMisconA.Sorting = SortOrder.None;
            lvMisconA.HeaderStyle = ColumnHeaderStyle.Nonclickable;

            if (lvMisconA.Columns.Count == 0)
            {
                lvMisconA.Columns.Add("MISCONCEPTION TAG", 300, HorizontalAlignment.Left);
                lvMisconA.Columns.Add("COUNT", 100, HorizontalAlignment.Center);
                lvMisconA.Columns.Add("LAST SEEN", 140, HorizontalAlignment.Center);
            }

            else
            {
                lvMisconA.Columns[0].Text = "MISCONCEPTION TAG";
                lvMisconA.Columns[1].Text = "COUNT";
                lvMisconA.Columns[2].Text = "LAST SEEN";
            }

            lvMisconA.Items.Clear();

            foreach (var m in s.TopMisconceptions.Take(20))
            {
                var last = m.LastSeenUtc.ToLocalTime().ToString("dd MMM yyyy");

                var item = new ListViewItem(m.Tag ?? "");
                item.SubItems.Add(m.Count.ToString());
                item.SubItems.Add(last);

                lvMisconA.Items.Add(item);
            }

            if (lvMisconA.Columns.Count >= 3)
            {
                lvMisconA.Columns[1].Width = 100;
                lvMisconA.Columns[2].Width = 140;

                var total = lvMisconA.ClientSize.Width;
                var first = total - lvMisconA.Columns[1].Width - lvMisconA.Columns[2].Width - SystemInformation.VerticalScrollBarWidth - 8;

                if (first < 180)
                {
                    first = 180;
                }

                lvMisconA.Columns[0].Width = first;
            }

            lvMisconA.EndUpdate();
        }

        private void InitAdaptiveQuizHoverTip()
        {
            if (btnStartQuiz == null)
            {
                return;
            }

            if (_adaptiveTip == null)
            {
                _adaptiveTip = new ToolTip { ShowAlways = true, InitialDelay = 0, ReshowDelay = 0, AutoPopDelay = 20000 };
            }

            const string msg = "Starts an adaptive quiz using default preferences.\n" + "For custom preferences, use the Quiz button in the sidebar.";

            bool showing = false;

            btnStartQuiz.MouseEnter += (_, __) =>
            {
                showing = true;

                var pos = btnStartQuiz.PointToClient(Cursor.Position);
                _adaptiveTip.Show(msg, btnStartQuiz, pos.X + 14, pos.Y + 18);
            };

            btnStartQuiz.MouseMove += (_, __) =>
            {
                if (!showing)
                {
                    return;
                }

                var pos = btnStartQuiz.PointToClient(Cursor.Position);

                if (!btnStartQuiz.ClientRectangle.Contains(pos))
                {
                    _adaptiveTip.Hide(btnStartQuiz);
                    showing = false;
                    return;
                }

                _adaptiveTip.Show(msg, btnStartQuiz, pos.X + 14, pos.Y + 18);
            };

            btnStartQuiz.MouseLeave += (_, __) =>
            {
                _adaptiveTip.Hide(btnStartQuiz);
                showing = false;
            };

            btnStartQuiz.MouseDown += (_, __) =>
            {
                _adaptiveTip.Hide(btnStartQuiz);
                showing = false;
            };
        }

        private void btnNavDashboard_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnStartQuiz_Click(object sender, EventArgs e)
        {
            var quiz = new QuizForm(_userKey, new QuizPreferences { UseDefaults = true });
            quiz.FormClosed += (_, __) =>
            {
                try
                {
                    Show();
                    RefreshDashboard();
                }

                catch
                {

                }
            };

            quiz.Show();
            Hide();
        }

        private void btnNavQuiz_Click(object sender, EventArgs e)
        {
            var f = new QuizSelectionForm(_userKey);

            f.FormClosed += (_, __) =>
            {
                try
                {
                    Show();
                    RefreshDashboard();
                }

                catch
                {

                }
            };

            f.Show();
            Hide();
        }

        private void btnNavReports_Click(object sender, EventArgs e)
        {
            var f = new ReportsAndChartsForm(_userKey);

            f.FormClosed += (_, __) =>
            {
                try
                {
                    Show();
                    RefreshDashboard();
                }

                catch
                {

                }
            };

            f.Show();
            Hide();
        }

        private void lblTilePhishTitle_Click(object sender, EventArgs e)
        {
            var f = new PhishingSimulatorForm(_userKey);

            f.FormClosed += (_, __) =>
            {
                try
                {
                    Show();
                    RefreshDashboard();
                }

                catch
                {

                }
            };

            f.Show();
            Hide();
        }

        private void cmbStatsSource_SelectedIndexChanged(object sender, EventArgs e)
        {
            RefreshDashboard();
        }

        private void btnNavModules_Click(object sender, EventArgs e)
        {
            var f = new LearningModulesForm(_userKey);

            f.FormClosed += (_, __) =>
            {
                try
                {
                    Show();
                    RefreshDashboard();
                }

                catch
                {

                }
            };

            f.Show();
            Hide();
        }

        private void btnNavMiniGames_Click(object sender, EventArgs e)
        {
            var f = new MiniGameSelectionForm(_userKey);
            f.Show();
            Hide();

        }

        private void lblTileAuthTitle_Click(object sender, EventArgs e)
        {
            var f = new AuthenticationDefenseForm(_userKey);

            f.FormClosed += (_, __) =>
            {
                try
                {
                    Show();
                    RefreshDashboard();
                }

                catch
                {

                }
            };

            f.Show();
            Hide();
        }
    }
}