using Mondas.Models;
using Mondas.Services;
using Syncfusion.Windows.Forms.Tools.MultiColumnTreeView;
using Syncfusion.Windows.Forms.Tools.Win32API;
using Syncfusion.WinForms.Controls;
using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace Mondas
{
    public partial class DashboardForm : SfForm
    {
        private readonly string _userKey;
        private readonly long _userId;
        private readonly string _dbPath;
        private readonly DashboardStatsService _stats;
        private readonly Font _masteryHeaderFont;
        private readonly Font _masteryCellFont;

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

            _masteryHeaderFont = CreateUiFont(11f, FontStyle.Bold);
            _masteryCellFont = CreateUiFont(12f, FontStyle.Bold);
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            _masteryHeaderFont?.Dispose();
            _masteryCellFont?.Dispose();
            base.OnFormClosed(e);
        }

        private static Font CreateUiFont(float size, FontStyle style)
        {
            string[] families = { "Muro", "Agency FB" };

            foreach (var fam in families)
            {
                try
                {
                    return new Font(fam, size, style, GraphicsUnit.Point);
                }

                catch
                {
                
                }
            }

            return new Font(SystemFonts.DefaultFont.FontFamily, size, style, GraphicsUnit.Point);
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

            RefreshDashboard();
        }

        private void RefreshDashboard()
        {
            DashboardStats s;

            try
            {
                s = _stats.Load(_userId, _userKey);
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
                lblStreak.Text = $"{s.CurrentStreak} STREAK";
            }

            if (lblMistakes != null)
            {
                lblMistakes.Text = $"{s.TotalMistakes} MISTAKES";
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
                var bar = new ProgressBar { Dock = DockStyle.Fill, Minimum = 0, Maximum = 100, Value = ClampToPercent(row.Accuracy01) };
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

        private void RenderMisconceptions (DashboardStats s)
        {
            if (lvMisconA == null)
            {
                return;
            }

            lvMisconA.BeginUpdate();
            lvMisconA.Items.Clear();

            foreach (var m in s.TopMisconceptions)
            {
                var last = m.LastSeenUtc.ToLocalTime().ToString("dd MMM yyyy");
                var item = new ListViewItem(new[] { m.Tag, m.Count.ToString(), last });
                lvMisconA.Items.Add(item);
            }

            lvMisconA.EndUpdate();
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
    }
}