using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Mondas.Models;
using Mondas.Services;
using Syncfusion.WinForms.Controls;

namespace Mondas
{
    public partial class DashboardForm : SfForm
    {
        readonly Color Blue = Color.FromArgb(30, 110, 230);
        readonly Color LightBg = Color.FromArgb(235, 237, 240);
        readonly Color CardBg = Color.White;
        readonly Color Border = Color.FromArgb(210, 210, 210);

        readonly string userKey = "local";
        readonly string userName = "ARJUN SINGH";

        Panel sidebar;
        Panel topBar;
        Panel content;

        TableLayoutPanel pageLayout;

        Label lblWelcome;
        Label lblSub;
        Label lblUser;
        Button btnLogout;

        Panel statsRow;
        Label vAttempts, vAccuracy, vAvgTime, vWeakest, vStrongest;

        SfButton btnStartQuiz;

        GroupBox gbMastery;
        TableLayoutPanel masteryTable;

        GroupBox gbReports;
        Panel reportsPreview;
        Label lblStreak;
        Label lblMistakes;
        SfButton btnViewReports;

        GroupBox gbMisconA;
        ListView lvMisconA;

        GroupBox gbMisconB;
        ListView lvMisconB;

        Panel miniTiles;
        Panel tilePhish;
        Panel tilePass;

        Label lblFooterUser;
        LinkLabel lnkReset;

        SqliteAttemptRepository attemptRepo;
        List<Question> questions = new List<Question>();
        Dictionary<int, Question> qById = new Dictionary<int, Question>();

        string dbPath = "";
        string jsonPath = "";

        public DashboardForm()
        {
            InitializeComponent();
            SetupWindow();
            BuildUi();
            InitStorage();
            RefreshDashboard();
        }

        void SetupWindow()
        {
            AutoScaleMode = AutoScaleMode.Dpi;
            StartPosition = FormStartPosition.CenterScreen;
            MinimumSize = new Size(1200, 720);
            Size = new Size(1400, 820);
            Text = "Dashboard - Mondas";

            BackColor = LightBg;
            Style.TitleBar.BackColor = Blue;
            Style.TitleBar.ForeColor = Color.White;
            Style.TitleBar.TextHorizontalAlignment = HorizontalAlignment.Center;
            ShowIcon = false;
        }

        void BuildUi()
        {
            Controls.Clear();

            sidebar = new Panel
            {
                Dock = DockStyle.Left,
                Width = 240,
                BackColor = Blue
            };
            Controls.Add(sidebar);

            var brand = new Label
            {
                Text = "MONDAS",
                ForeColor = Color.White,
                Font = new Font("Segoe UI Black", 26f, FontStyle.Bold),
                AutoSize = false,
                Height = 90,
                Dock = DockStyle.Top,
                TextAlign = ContentAlignment.MiddleCenter
            };
            sidebar.Controls.Add(brand);

            var nav = new FlowLayoutPanel
            {
                Dock = DockStyle.Fill,
                FlowDirection = FlowDirection.TopDown,
                WrapContents = false,
                Padding = new Padding(0, 10, 0, 10)
            };
            sidebar.Controls.Add(nav);

            nav.Controls.Add(MakeNavItem("DASHBOARD", true, () => { }));
            nav.Controls.Add(MakeNavItem("QUIZ", false, () => OpenQuiz()));
            nav.Controls.Add(MakeNavItem("MINI GAMES", false, () => MessageBox.Show(this, "Mini games coming soon.", "Mondas")));
            nav.Controls.Add(MakeNavItem("REPORTS", false, () => MessageBox.Show(this, "Reports page coming soon.", "Mondas")));
            nav.Controls.Add(MakeNavItem("LEADERBOARD", false, () => MessageBox.Show(this, "Leaderboard coming soon.", "Mondas")));
            nav.Controls.Add(MakeNavItem("COMMUNITY", false, () => MessageBox.Show(this, "Community coming soon.", "Mondas")));
            nav.Controls.Add(MakeNavItem("SETTINGS", false, () => MessageBox.Show(this, "Settings coming soon.", "Mondas")));

            var footer = new Label
            {
                Text = "©2025 MONDAS LEARNING",
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 8f, FontStyle.Italic),
                Dock = DockStyle.Bottom,
                Height = 26,
                TextAlign = ContentAlignment.MiddleCenter
            };
            sidebar.Controls.Add(footer);

            topBar = new Panel
            {
                Dock = DockStyle.Top,
                Height = 46,
                BackColor = Blue
            };
            Controls.Add(topBar);

            var topTitle = new Label
            {
                Text = "DASHBOARD - MONDAS",
                ForeColor = Color.White,
                Font = new Font("Segoe UI Semibold", 14f, FontStyle.Italic),
                Dock = DockStyle.Fill,
                TextAlign = ContentAlignment.MiddleCenter
            };
            topBar.Controls.Add(topTitle);

            content = new Panel
            {
                Dock = DockStyle.Fill,
                BackColor = LightBg,
                Padding = new Padding(18)
            };
            Controls.Add(content);

            pageLayout = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                ColumnCount = 1,
                RowCount = 4,
                BackColor = LightBg
            };
            pageLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 92));
            pageLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 92));
            pageLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 100f));
            pageLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 26));

            content.Controls.Add(pageLayout);

            var header = BuildHeaderArea();
            var stats = BuildStatsRow();
            var main = BuildMainGrid();
            var footerBar = BuildBottomRow();

            pageLayout.Controls.Add(header, 0, 0);
            pageLayout.Controls.Add(stats, 0, 1);
            pageLayout.Controls.Add(main, 0, 2);
            pageLayout.Controls.Add(footerBar, 0, 3);
        }

        Control MakeNavItem(string text, bool active, Action onClick)
        {
            var btn = new Button
            {
                Text = text,
                ForeColor = Color.White,
                BackColor = active ? Color.FromArgb(20, 90, 200) : Blue,
                FlatStyle = FlatStyle.Flat,
                Width = 240,
                Height = 52,
                TextAlign = ContentAlignment.MiddleLeft,
                Font = new Font("Segoe UI Semibold", 11f),
                Padding = new Padding(18, 0, 0, 0)
            };
            btn.FlatAppearance.BorderSize = 0;
            btn.Click += (s, e) => onClick();
            return btn;
        }

        Panel BuildHeaderArea()
        {
            var header = new Panel
            {
                Dock = DockStyle.Fill,
                Height = 92,
                BackColor = LightBg
            };

            lblWelcome = new Label
            {
                Text = "WELCOME BACK, ARJUN!",
                Font = new Font("Segoe UI Black", 34f, FontStyle.Bold),
                ForeColor = Color.FromArgb(55, 60, 70),
                AutoSize = true,
                Location = new Point(6, 8)
            };
            header.Controls.Add(lblWelcome);

            lblSub = new Label
            {
                Text = "HERE'S YOUR CYBER AWARENESS TRAINING PROGRESS",
                Font = new Font("Segoe UI Semibold", 12f),
                ForeColor = Color.FromArgb(110, 110, 110),
                AutoSize = true,
                Location = new Point(10, 62)
            };
            header.Controls.Add(lblSub);

            lblUser = new Label
            {
                Text = userName,
                Font = new Font("Segoe UI Semibold", 12f),
                ForeColor = Color.FromArgb(55, 60, 70),
                AutoSize = true
            };
            header.Controls.Add(lblUser);

            btnLogout = new Button
            {
                Text = "LOG OUT",
                Font = new Font("Segoe UI Semibold", 10f),
                BackColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Width = 90,
                Height = 30
            };

            btnLogout.FlatAppearance.BorderColor = Border;
            btnLogout.Click += (s, e) => Close();
            header.Controls.Add(btnLogout);

            header.Resize += (s, e) =>
            {
                btnLogout.Location = new Point(header.Width - btnLogout.Width - 8, 14);
                lblUser.Location = new Point(btnLogout.Left - lblUser.Width - 14, 17);
            };

            return header;
        }

        Panel BuildStatsRow()
        {
            statsRow = new Panel
            {
                Dock = DockStyle.Fill,
                Height = 92,
                Padding = new Padding(6, 0, 6, 0),
                BackColor = LightBg
            };

            var strip = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                ColumnCount = 5,
                RowCount = 1
            };
            strip.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20f));
            strip.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20f));
            strip.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20f));
            strip.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20f));
            strip.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20f));
            statsRow.Controls.Add(strip);

            strip.Controls.Add(MakeStatBox("ATTEMPTS", out vAttempts), 0, 0);
            strip.Controls.Add(MakeStatBox("ACCURACY", out vAccuracy), 1, 0);
            strip.Controls.Add(MakeStatBox("AVG TIME", out vAvgTime), 2, 0);
            strip.Controls.Add(MakeStatBox("WEAKEST TOPIC", out vWeakest), 3, 0);
            strip.Controls.Add(MakeStatBox("STRONGEST TOPIC", out vStrongest), 4, 0);

            return statsRow;
        }

        Control MakeStatBox(string title, out Label valueLabel)
        {
            var box = new Panel
            {
                Dock = DockStyle.Fill,
                BackColor = CardBg,
                Margin = new Padding(6),
                Padding = new Padding(14)
            };
            box.Paint += (s, e) =>
            {
                var r = box.ClientRectangle;
                r.Width -= 1;
                r.Height -= 1;
                using var pen = new Pen(Border);
                e.Graphics.DrawRectangle(pen, r);
            };

            var lblTitle = new Label
            {
                Text = title,
                Font = new Font("Segoe UI Semibold", 11f),
                ForeColor = Color.FromArgb(60, 60, 60),
                AutoSize = true,
                Location = new Point(14, 10)
            };
            box.Controls.Add(lblTitle);

            valueLabel = new Label
            {
                Text = "—",
                Font = new Font("Segoe UI Black", 28f, FontStyle.Bold),
                ForeColor = Color.FromArgb(45, 50, 60),
                AutoSize = true,
                Location = new Point(14, 34)
            };
            box.Controls.Add(valueLabel);

            return box;
        }

        Panel BuildMainGrid()
        {
            var mid = new Panel
            {
                Dock = DockStyle.Fill,
                BackColor = LightBg,
                Padding = new Padding(6, 10, 6, 6)
            };

            btnStartQuiz = new SfButton
            {
                Text = "START ADAPTIVE QUIZ   ▶",
                Font = new Font("Segoe UI Semibold", 14f),
                Size = new Size(420, 54),
                BackColor = Color.FromArgb(20, 90, 200),
                ForeColor = Color.White
            };

            btnStartQuiz.FlatStyle = FlatStyle.Flat;
            btnStartQuiz.Click += (s, e) => OpenQuiz();

            var quizRow = new Panel
            {
                Dock = DockStyle.Top,
                Height = 80
            };

            mid.Controls.Add(quizRow);
            quizRow.Controls.Add(btnStartQuiz);
            quizRow.Resize += (s, e) =>
            {
                btnStartQuiz.Location = new Point((quizRow.Width - btnStartQuiz.Width) / 2, 12);
            };

            var grid = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                ColumnCount = 2,
                RowCount = 2
            };

            grid.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 66f));
            grid.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 34f));
            grid.RowStyles.Add(new RowStyle(SizeType.Percent, 62f));
            grid.RowStyles.Add(new RowStyle(SizeType.Percent, 38f));
            mid.Controls.Add(grid);

            gbMastery = new GroupBox
            {
                Text = "MASTERY BY TOPIC",
                Dock = DockStyle.Fill,
                Font = new Font("Segoe UI Black", 15f, FontStyle.Bold),
                ForeColor = Color.FromArgb(55, 60, 70),
                BackColor = CardBg,
                Padding = new Padding(12)
            };

            grid.Controls.Add(gbMastery, 0, 0);

            masteryTable = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                ColumnCount = 4,
                RowCount = 1,
                AutoScroll = true
            };

            masteryTable.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 30f));
            masteryTable.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 16f));
            masteryTable.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 16f));
            masteryTable.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 38f));
            gbMastery.Controls.Add(masteryTable);

            gbReports = new GroupBox
            {
                Text = "REPORTS & CHARTS",
                Dock = DockStyle.Fill,
                Font = new Font("Segoe UI Black", 15f, FontStyle.Bold),
                ForeColor = Color.FromArgb(55, 60, 70),
                BackColor = CardBg,
                Padding = new Padding(12)
            };
            grid.Controls.Add(gbReports, 1, 0);

            reportsPreview = new Panel
            {
                Dock = DockStyle.Top,
                Height = 190,
                BackColor = Color.White
            };
            reportsPreview.Paint += ReportsPreview_Paint;
            gbReports.Controls.Add(reportsPreview);

            lblStreak = new Label
            {
                Text = "10  Streak",
                Font = new Font("Segoe UI Black", 14f),
                ForeColor = Color.FromArgb(55, 60, 70),
                AutoSize = true,
                Location = new Point(240, 62)
            };
            reportsPreview.Controls.Add(lblStreak);

            lblMistakes = new Label
            {
                Text = "7  Mistakes",
                Font = new Font("Segoe UI Black", 14f),
                ForeColor = Color.FromArgb(55, 60, 70),
                AutoSize = true,
                Location = new Point(240, 106)
            };
            reportsPreview.Controls.Add(lblMistakes);

            btnViewReports = new SfButton
            {
                Text = "VIEW REPORTS",
                Dock = DockStyle.Bottom,
                Height = 54,
                Font = new Font("Segoe UI Semibold", 13f),
                BackColor = Color.FromArgb(20, 90, 200),
                ForeColor = Color.White
            };
            btnViewReports.FlatStyle = FlatStyle.Flat;
            btnViewReports.Click += (s, e) => MessageBox.Show(this, "Reports page coming soon.", "Mondas");
            gbReports.Controls.Add(btnViewReports);

            gbMisconA = new GroupBox
            {
                Text = "RECENT MISCONCEPTIONS",
                Dock = DockStyle.Fill,
                Font = new Font("Segoe UI Black", 13f, FontStyle.Bold),
                ForeColor = Color.FromArgb(55, 60, 70),
                BackColor = CardBg,
                Padding = new Padding(12)
            };
            grid.Controls.Add(gbMisconA, 0, 1);

            lvMisconA = MakeMisconList();
            gbMisconA.Controls.Add(lvMisconA);

            var rightBottom = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                ColumnCount = 1,
                RowCount = 2
            };
            rightBottom.RowStyles.Add(new RowStyle(SizeType.Percent, 60f));
            rightBottom.RowStyles.Add(new RowStyle(SizeType.Percent, 40f));
            grid.Controls.Add(rightBottom, 1, 1);

            gbMisconB = new GroupBox
            {
                Text = "RECENT MISCONCEPTIONS",
                Dock = DockStyle.Fill,
                Font = new Font("Segoe UI Black", 13f, FontStyle.Bold),
                ForeColor = Color.FromArgb(55, 60, 70),
                BackColor = CardBg,
                Padding = new Padding(12)
            };
            rightBottom.Controls.Add(gbMisconB, 0, 0);

            lvMisconB = MakeMisconList();
            gbMisconB.Controls.Add(lvMisconB);

            miniTiles = new Panel
            {
                Dock = DockStyle.Fill,
                BackColor = LightBg,
                Padding = new Padding(0, 8, 0, 0)
            };
            rightBottom.Controls.Add(miniTiles, 0, 1);

            var miniGrid = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                ColumnCount = 2,
                RowCount = 1
            };
            miniGrid.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50f));
            miniGrid.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50f));
            miniTiles.Controls.Add(miniGrid);

            tilePhish = MakeMiniTile("PHISHING\nSIMULATOR");
            tilePass = MakeMiniTile("PASSWORD\nWORKSHOP");

            miniGrid.Controls.Add(tilePhish, 0, 0);
            miniGrid.Controls.Add(tilePass, 1, 0);
            
            return mid;
        }

        ListView MakeMisconList()
        {
            var lv = new ListView
            {
                Dock = DockStyle.Fill,
                View = View.Details,
                FullRowSelect = true,
                HeaderStyle = ColumnHeaderStyle.None,
                Font = new Font("Segoe UI", 11f)
            };
            lv.Columns.Add("Tag", 220);
            lv.Columns.Add("Count", 60, HorizontalAlignment.Right);
            lv.Columns.Add("", 30, HorizontalAlignment.Right);
            return lv;
        }

        Panel MakeMiniTile(string title)
        {
            var p = new Panel
            {
                Dock = DockStyle.Fill,
                BackColor = CardBg,
                Margin = new Padding(6),
                Padding = new Padding(14)
            };
            p.Paint += (s, e) =>
            {
                var r = p.ClientRectangle;
                r.Width -= 1;
                r.Height -= 1;
                using var pen = new Pen(Border);
                e.Graphics.DrawRectangle(pen, r);
            };

            var lbl = new Label
            {
                Text = title,
                Font = new Font("Segoe UI Black", 13f),
                ForeColor = Color.FromArgb(55, 60, 70),
                AutoSize = false,
                Dock = DockStyle.Top,
                Height = 56
            };
            p.Controls.Add(lbl);

            var sub = new Label
            {
                Text = "COMING SOON",
                Font = new Font("Segoe UI Semibold", 10f),
                ForeColor = Color.FromArgb(150, 150, 150),
                Dock = DockStyle.Bottom,
                Height = 22,
                TextAlign = ContentAlignment.MiddleCenter
            };
            p.Controls.Add(sub);

            p.Cursor = Cursors.Hand;
            EventHandler onClick = (s, e) => MessageBox.Show(this, "Mini game coming soon.", "Mondas");
            p.Click += onClick;

            return p;
        }

        Panel BuildBottomRow()
        {
            var bottom = new Panel
            {
                Dock = DockStyle.Bottom,
                Height = 26,
                BackColor = LightBg
            };

            lblFooterUser = new Label
            {
                Text = "User: Arjun Singh",
                Font = new Font("Segoe UI", 10f),
                ForeColor = Color.FromArgb(80, 80, 80),
                AutoSize = true,
                Location = new Point(8, 4)
            };
            bottom.Controls.Add(lblFooterUser);

            lnkReset = new LinkLabel
            {
                Text = "Reset Progress",
                Font = new Font("Segoe UI", 10f),
                AutoSize = true
            };
            lnkReset.LinkColor = Color.FromArgb(80, 80, 80);
            lnkReset.ActiveLinkColor = Blue;
            lnkReset.Click += (s, e) =>
            {
                attemptRepo.ClearUser(userKey);
                RefreshDashboard();
            };
            bottom.Controls.Add(lnkReset);

            bottom.Resize += (s, e) =>
            {
                lnkReset.Location = new Point(bottom.Width - lnkReset.Width - 8, 4);
            };

            return bottom;
        }

        void InitStorage()
        {
            var baseDir = AppDomain.CurrentDomain.BaseDirectory;
            dbPath = System.IO.Path.Combine(baseDir, "mondas.db");
            jsonPath = System.IO.Path.Combine(baseDir, "Resources", "questions.json");

            var init = new SqliteDatabaseInitializer(dbPath, jsonPath);
            init.Initialize();

            attemptRepo = new SqliteAttemptRepository(dbPath);

            var qRepo = new JsonQuestionRepository(jsonPath);
            questions = qRepo.GetAllQuestions().ToList();

            qById = questions.ToDictionary(q => q.Id, q => q);
        }

        void RefreshDashboard()
        {
            var attempts = attemptRepo.GetForUser(userKey);

            var total = attempts.Count;
            var correct = attempts.Count(a => a.IsCorrect);
            var accuracy = total == 0 ? 0 : (double)correct / total;

            vAttempts.Text = total.ToString();
            vAccuracy.Text = total == 0 ? "—" : $"{accuracy * 100:0}%";

            if (total == 0)
                vAvgTime.Text = "—";
            else
            {
                var avg = attempts.Average(a => a.SecondsTaken);
                vAvgTime.Text = $"{avg:0.0}s";
            }

            var topicStats = new Dictionary<Topic, (int seen, int correct)>();
            foreach (var a in attempts)
            {
                if (!qById.TryGetValue(a.QuestionId, out var q))
                    continue;

                var t = q.Metadata.Topic;
                if (!topicStats.ContainsKey(t))
                    topicStats[t] = (0, 0);

                var cur = topicStats[t];
                cur.seen++;
                if (a.IsCorrect) cur.correct++;
                topicStats[t] = cur;
            }

            string weakest = "—";
            string strongest = "—";

            if (topicStats.Count > 0)
            {
                var scored = topicStats
                    .Select(k =>
                    {
                        var seen = k.Value.seen;
                        var corr = k.Value.correct;
                        var mastery = seen == 0 ? 0 : (double)corr / seen;
                        return new { topic = k.Key, seen, corr, mastery };
                    })
                    .ToList();

                weakest = scored.OrderBy(x => x.mastery).First().topic.ToString().ToUpperInvariant();
                strongest = scored.OrderByDescending(x => x.mastery).First().topic.ToString().ToUpperInvariant();
            }

            vWeakest.Text = weakest;
            vStrongest.Text = strongest;

            BuildMasteryTable(topicStats);
            BuildMisconceptions(attempts);

            var streak = CalcStreak(attempts);
            var mistakes = attempts.Count(a => !a.IsCorrect);

            lblStreak.Text = $"{streak}  Streak";
            lblMistakes.Text = $"{mistakes}  Mistakes";

            reportsPreview.Invalidate();
        }

        int CalcStreak(List<AttemptRecord> attempts)
        {
            var streak = 0;
            foreach (var a in attempts)
            {
                if (!a.IsCorrect) break;
                streak++;
            }
            return streak;
        }

        void BuildMasteryTable(Dictionary<Topic, (int seen, int correct)> topicStats)
        {
            masteryTable.SuspendLayout();
            masteryTable.Controls.Clear();
            masteryTable.RowStyles.Clear();
            masteryTable.RowCount = 1;

            AddMasteryHeader();

            var orderedTopics = Enum.GetValues(typeof(Topic)).Cast<Topic>()
                .Where(t => t != Topic.Other)
                .ToList();

            foreach (var t in orderedTopics)
            {
                int seen = 0;
                int corr = 0;

                if (topicStats.TryGetValue(t, out var s))
                {
                    seen = s.seen;
                    corr = s.correct;
                }

                var mastery = seen == 0 ? 0 : (double)corr / seen;
                AddMasteryRow(t.ToString(), seen, corr, mastery);
            }

            masteryTable.ResumeLayout();
        }

        void AddMasteryHeader()
        {
            masteryTable.RowStyles.Add(new RowStyle(SizeType.Absolute, 34));

            var h1 = HeaderCell("TOPIC");
            var h2 = HeaderCell("SEEN");
            var h3 = HeaderCell("CORRECT");
            var h4 = HeaderCell("MASTERY");

            masteryTable.Controls.Add(h1, 0, 0);
            masteryTable.Controls.Add(h2, 1, 0);
            masteryTable.Controls.Add(h3, 2, 0);
            masteryTable.Controls.Add(h4, 3, 0);
        }

        Label HeaderCell(string text)
        {
            return new Label
            {
                Text = text,
                Font = new Font("Segoe UI Semibold", 10f),
                ForeColor = Color.FromArgb(100, 100, 100),
                Dock = DockStyle.Fill,
                TextAlign = ContentAlignment.MiddleLeft
            };
        }

        void AddMasteryRow(string topic, int seen, int correct, double mastery)
        {
            var row = masteryTable.RowCount;
            masteryTable.RowCount++;
            masteryTable.RowStyles.Add(new RowStyle(SizeType.Absolute, 42));

            var cTopic = new Label
            {
                Text = topic,
                Font = new Font("Segoe UI", 11f),
                ForeColor = Color.FromArgb(55, 60, 70),
                Dock = DockStyle.Fill,
                TextAlign = ContentAlignment.MiddleLeft
            };

            var cSeen = new Label
            {
                Text = seen.ToString(),
                Font = new Font("Segoe UI Semibold", 11f),
                ForeColor = Color.FromArgb(55, 60, 70),
                Dock = DockStyle.Fill,
                TextAlign = ContentAlignment.MiddleLeft
            };

            var cCorrect = new Label
            {
                Text = correct.ToString(),
                Font = new Font("Segoe UI Semibold", 11f),
                ForeColor = Color.FromArgb(55, 60, 70),
                Dock = DockStyle.Fill,
                TextAlign = ContentAlignment.MiddleLeft
            };

            var barHost = new Panel { Dock = DockStyle.Fill, Padding = new Padding(0, 10, 14, 10) };

            var bar = new ProgressBar
            {
                Dock = DockStyle.Fill,
                Maximum = 100,
                Value = Math.Max(0, Math.Min(100, (int)Math.Round(mastery * 100)))
            };

            var pct = new Label
            {
                Text = $"{mastery * 100:0}%",
                Font = new Font("Segoe UI Semibold", 11f),
                ForeColor = Color.FromArgb(90, 90, 90),
                AutoSize = true,
                Dock = DockStyle.Right,
                TextAlign = ContentAlignment.MiddleRight
            };

            barHost.Controls.Add(bar);
            barHost.Controls.Add(pct);

            masteryTable.Controls.Add(cTopic, 0, row);
            masteryTable.Controls.Add(cSeen, 1, row);
            masteryTable.Controls.Add(cCorrect, 2, row);
            masteryTable.Controls.Add(barHost, 3, row);
        }

        void BuildMisconceptions(List<AttemptRecord> attempts)
        {
            var counts = new Dictionary<string, int>(StringComparer.OrdinalIgnoreCase);

            foreach (var a in attempts)
            {
                if (a.IsCorrect)
                    continue;

                if (!qById.TryGetValue(a.QuestionId, out var q))
                    continue;

                var tags = q.Metadata.MisconceptionTags ?? new List<string>();
                foreach (var tag in tags)
                {
                    if (string.IsNullOrWhiteSpace(tag))
                        continue;

                    if (!counts.ContainsKey(tag))
                        counts[tag] = 0;

                    counts[tag]++;
                }
            }

            var top = counts.OrderByDescending(k => k.Value).Take(6).ToList();
            var left = top.Take(3).ToList();
            var right = top.Skip(3).Take(3).ToList();

            FillMisconList(lvMisconA, left);
            FillMisconList(lvMisconB, right);
        }

        private void DashboardForm_Load(object sender, EventArgs e)
        {

        }

        void FillMisconList(ListView lv, List<KeyValuePair<string, int>> items)
        {
            lv.BeginUpdate();
            lv.Items.Clear();

            foreach (var it in items)
            {
                var pretty = PrettyTag(it.Key);
                var lvi = new ListViewItem(pretty);
                lvi.SubItems.Add(it.Value.ToString());
                lvi.SubItems.Add("›");
                lv.Items.Add(lvi);
            }

            lv.EndUpdate();
        }

        string PrettyTag(string raw)
        {
            raw = raw.Replace("_", " ").Trim();
            if (raw.Length == 0) return raw;
            return char.ToUpper(raw[0]) + raw.Substring(1);
        }

        void OpenQuiz()
        {
            using var quiz = new QuizForm();
            quiz.ShowDialog(this);
            RefreshDashboard();
        }

        void ReportsPreview_Paint(object sender, PaintEventArgs e)
        {
            var g = e.Graphics;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            var r = reportsPreview.ClientRectangle;
            r.Inflate(-12, -12);

            var chartArea = new Rectangle(r.Left + 8, r.Top + 18, 200, r.Height - 36);
            using (var pen = new Pen(Border))
                g.DrawRectangle(pen, chartArea);

            var bars = new[] { 0.9f, 0.7f, 0.55f, 0.3f, 0.4f };
            var barW = 18;
            var gap = 10;
            var baseY = chartArea.Bottom - 8;

            for (int i = 0; i < bars.Length; i++)
            {
                var h = (int)((chartArea.Height - 18) * bars[i]);
                var x = chartArea.Left + 14 + i * (barW + gap);
                var rect = new Rectangle(x, baseY - h, barW, h);
                using var br = new SolidBrush(Color.FromArgb(70 + i * 20, 120 + i * 10, 220));
                g.FillRectangle(br, rect);
            }

            var mini1 = new Rectangle(chartArea.Left + 8, chartArea.Bottom + 10, 62, 34);
            var mini2 = new Rectangle(chartArea.Left + 78, chartArea.Bottom + 10, 62, 34);
            var mini3 = new Rectangle(chartArea.Left + 148, chartArea.Bottom + 10, 62, 34);

            using (var pen = new Pen(Border))
            {
                g.DrawRectangle(pen, mini1);
                g.DrawRectangle(pen, mini2);
                g.DrawRectangle(pen, mini3);
            }
        } 
    }
}