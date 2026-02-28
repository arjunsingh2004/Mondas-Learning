using Microsoft.Data.Sqlite;
using Mondas.Models;
using Mondas.Services;
using Syncfusion.Windows.Forms.Chart;
using Syncfusion.WinForms.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Mondas
{
    public partial class ReportsAndChartsForm : SfForm
    {
        private readonly string _userKey;
        private readonly long _userId;
        private readonly string _dbPath;

        private readonly DashboardStatsService _statsService;
        private readonly string _reportsDir;
        private string _selectedReportPath;

        public ReportsAndChartsForm() : this("local")
        {

        }

        public ReportsAndChartsForm(string userKey)
        {
            InitializeComponent();

            if (LicenseManager.UsageMode != LicenseUsageMode.Designtime && chartMain != null)
            {
                chartMain.ChartArea.BackInterior = new Syncfusion.Drawing.BrushInfo(Color.Transparent);
            }

            _userKey = string.IsNullOrWhiteSpace(userKey) ? "local" : userKey.Trim();
            _userId = ParseUserId(_userKey);

            _dbPath = Path.Combine(AppContext.BaseDirectory, "mondas.db");
            _statsService = new DashboardStatsService(_dbPath);

            _reportsDir = BuildReportsDirectory(_userKey);
            _selectedReportPath = "";
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

        private static string BuildReportsDirectory(string userKey)
        {
            var safe = (string.IsNullOrWhiteSpace(userKey) ? "local" : userKey.Trim()).Replace(":", "_").Replace("/", "_").Replace("\\", "_");
            var dir = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Mondas", "reports", safe);

            Directory.CreateDirectory(dir);
            return dir;
        }

        private void ReportsAndChartsForm_Load(object sender, EventArgs e)
        {
            if (LicenseManager.UsageMode == LicenseUsageMode.Designtime)
            {
                return;
            }

            WindowState = FormWindowState.Maximized;

            FilterDefaults();
            RefreshAll();
            RefreshReportList();
            ShowNoReportSelected();
        }

        private void FilterDefaults()
        {
            SetDefaultSelection(cmbRange);
            SetDefaultSelection(cmbTopic);
            SetDefaultSelection(cmbDifficulty);
            SetDefaultSelection(cmbMetric);
            SetDefaultSelection(cmbXAxis);
            SetDefaultSelection(cmbGroupBy);
        }

        private static void SetDefaultSelection(ComboBox cmb)
        {
            if (cmb == null)
            {
                return;
            }

            if (cmb.SelectedIndex >= 0)
            {
                return;
            }

            if (cmb.Items != null && cmb.Items.Count > 0)
            {
                cmb.SelectedIndex = 0;
            }
        }

        private void RefreshAll()
        {
            var stats = SafeLoadDashboardStats();
            ApplyHeader(stats);
            RefreshChart();
        }

        private DashboardStats SafeLoadDashboardStats()
        {
            try
            {
                return _statsService.Load(_userId, _userKey);
            }

            catch
            {
                return new DashboardStats { UserId = _userId, UserKey = _userKey, FullName = "USER" };
            }
        }

        private void ApplyHeader(DashboardStats stats)
        {
            var name = (stats.FullName ?? "USER").Trim();

            if (name.Length == 0)
            {
                name = "USER";
            }

            if (lblUser != null)
            {
                lblUser.Text = name.ToUpperInvariant();
            }
        }

        private void ApplyKpis(DashboardStats stats)
        {
            if (lblKpiAttemptsValue != null)
            {
                lblKpiAttemptsValue.Text = stats.TotalAttempts.ToString(CultureInfo.InvariantCulture);
            }

            if (lblKpiAccuracyValue != null)
            {
                lblKpiAccuracyValue.Text = $"{(stats.Accuracy01 * 100.0):0}%";
            }

            if (lblKpiAvgTimeValue != null)
            {
                lblKpiAvgTimeValue.Text = stats.AvgSeconds <= 0 ? "—" : $"{stats.AvgSeconds:0.0}s";
            }

            if (lblKpiStreakValue != null)
            {
                lblKpiStreakValue.Text = stats.CurrentStreak.ToString(CultureInfo.InvariantCulture);
            }
        }

        private void chartControl1_Click(object sender, EventArgs e)
        {

        }

        private void btnRefreshCharts_Click(object sender, EventArgs e)
        {
            FilterDefaults();
            RefreshAll();
        }

        private void btnExportChartPng_Click(object sender, EventArgs e)
        {
            if (chartMain == null)
            {
                return;
            }

            using var sfd = new SaveFileDialog { Title = "Export chart", Filter = "PNG Image (*.png) | *.png", FileName = "mondas_chart.png", AddExtension = true, DefaultExt = "png" };

            if (sfd.ShowDialog(this) != DialogResult.OK)
            {
                return;
            }

            try
            {
                SaveChartPng(chartMain, sfd.FileName);
                MessageBox.Show(this, "Chart exported.", "Mondas", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            catch (Exception ex)
            {
                MessageBox.Show(this, "Export failed:\n\n" + ex.Message, "Mondas", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnResetChart_Click(object sender, EventArgs e)
        {
            ResetCombo(cmbRange);
            ResetCombo(cmbTopic);
            ResetCombo(cmbDifficulty);
            ResetCombo(cmbMetric);
            ResetCombo(cmbXAxis);
            ResetCombo(cmbGroupBy);

            RefreshAll();
        }

        private static void ResetCombo(ComboBox cmb)
        {
            if (cmb == null)
            {
                return;
            }

            if (cmb.Items != null && cmb.Items.Count > 0)
            {
                cmb.SelectedIndex = 0;
            }
        }

        private static void SaveChartPng(Control chart, string path)
        {
            if (chart == null)
            {
                throw new ArgumentNullException(nameof(chart));
            }

            if (string.IsNullOrWhiteSpace(path))
            {
                throw new ArgumentNullException(nameof(path));
            }

            var saveImage = chart.GetType().GetMethod("SaveImage", new[] { typeof(string) });

            if (saveImage != null)
            {
                saveImage.Invoke(chart, new object[] { path });
                return;
            }

            using var bmp = new Bitmap(chart.Width, chart.Height);
            chart.DrawToBitmap(bmp, new Rectangle(0, 0, bmp.Width, bmp.Height));
            bmp.Save(path, System.Drawing.Imaging.ImageFormat.Png);
        }

        private void RefreshChart()
        {
            var filter = ReadChartFilter();
            var attempts = LoadAttemptRows(filter);
            ApplyKpisFromAttempts(attempts);
            var points = LoadChartPoints(filter, attempts);

            if (lblChartTitle != null)
            {
                lblChartTitle.Text = BuildChartTitle(filter);
            }

            if (lblChartSubtitle != null)
            {
                lblChartSubtitle.Text = BuildChartSubtitle(filter, points.Count);
            }

            RenderChart(points, filter);
        }

        private sealed class ChartFilter
        {
            public string RangeText = "";
            public string TopicText = "";
            public string DifficultyText = "";
            public string MetricText = "";
            public string XAxisText = "";
            public string GroupByText = "";

            public int? LastNAttempts;
            public int? LastNDays;

            public Topic? Topic;
            public DifficultyBand? Difficulty;

            public Metric MetricValue;
            public AxisX AxisXValue;
            public Grouping GroupingValue;

            public enum Metric { Accuracy, AvgTime, Attempts, Mistakes, Streak, TopicMastery };
            public enum AxisX { AttemptIndex, Date, Question, Topic };
            public enum Grouping { Attempt, Day, Week };
        }

        private ChartFilter ReadChartFilter()
        {
            var f = new ChartFilter
            {
                RangeText = ReadComboText(cmbRange),
                TopicText = ReadComboText(cmbTopic),
                DifficultyText = ReadComboText(cmbDifficulty),
                MetricText = ReadComboText(cmbMetric),
                XAxisText = ReadComboText(cmbXAxis),
                GroupByText = ReadComboText(cmbGroupBy)
            };

            f.LastNAttempts = TryParseLastN(f.RangeText);
            f.LastNDays = TryParseLastDays(f.RangeText);
            f.Topic = TryParseTopic(f.TopicText);
            f.Difficulty = TryParseDifficulty(f.DifficultyText);
            f.MetricValue = ParseMetric(f.MetricText);
            f.AxisXValue = ParseAxisX(f.XAxisText);
            f.GroupingValue = ParseGrouping(f.GroupByText);

            if (f.GroupingValue != ChartFilter.Grouping.Attempt && f.AxisXValue == ChartFilter.AxisX.AttemptIndex)
            {
                f.AxisXValue = ChartFilter.AxisX.Date;
            }

            if (f.AxisXValue == ChartFilter.AxisX.Topic || f.AxisXValue == ChartFilter.AxisX.Question)
            {
                f.GroupingValue = ChartFilter.Grouping.Attempt;
            }

            if (f.MetricValue == ChartFilter.Metric.TopicMastery)
            {
                f.AxisXValue = ChartFilter.AxisX.Topic;
            }

            if (f.MetricValue == ChartFilter.Metric.Attempts)
            {
                if (f.AxisXValue == ChartFilter.AxisX.AttemptIndex)
                {
                    f.AxisXValue = ChartFilter.AxisX.Date;
                }

                if (f.AxisXValue == ChartFilter.AxisX.Date && f.GroupingValue == ChartFilter.Grouping.Attempt)
                {
                    f.GroupingValue = ChartFilter.Grouping.Day;
                }
            }

            return f;
        }

        private static string ReadComboText(ComboBox cmb)
        {
            if (cmb == null)
            {
                return "";
            }

            var s = cmb.SelectedItem?.ToString();

            if (!string.IsNullOrWhiteSpace(s))
            {
                return s.Trim();
            }

            return (cmb.Text ?? "").Trim();
        }

        private static int? TryParseLastN(string rangeText)
        {
            if (string.IsNullOrWhiteSpace(rangeText))
            {
                return null;
            }

            var t = rangeText.ToUpperInvariant();

            if (t.Contains("ALL"))
            {
                return null;
            }

            if (!t.Contains("LAST"))
            {
                return null;
            }

            var digits = new string(t.Where(char.IsDigit).ToArray());

            if (int.TryParse(digits, out var n) && n > 0)
            {
                return n;
            }

            return null;
        }

        private static int? TryParseLastDays(string rangeText)
        {
            if (string.IsNullOrWhiteSpace(rangeText))
            {
                return null;
            }

            var t = rangeText.ToUpperInvariant();

            if (!t.Contains("DAY"))
            {
                return null;
            }

            var digits = new string(t.Where(char.IsDigit).ToArray());

            if (int.TryParse(digits, out var d) && d > 0)
            {
                return d;
            }

            return null;
        }

        private static Topic? TryParseTopic(string topicText)
        {
            if (string.IsNullOrWhiteSpace(topicText))
            {
                return null;
            }

            var t = topicText.Trim();

            if (t.Equals("ANY", StringComparison.OrdinalIgnoreCase) || t.Equals("ALL", StringComparison.OrdinalIgnoreCase))
            {
                return null;
            }

            var cleaned = t.Replace(" ", "").Replace("_", "");

            foreach (Topic v in Enum.GetValues(typeof(Topic)))
            {
                var name = v.ToString().Replace("_", "");

                if (name.Equals(cleaned, StringComparison.OrdinalIgnoreCase))
                {
                    return v;
                }
            }

            return null;
        }

        private static DifficultyBand? TryParseDifficulty(string difficultyText)
        {
            if (string.IsNullOrWhiteSpace(difficultyText))
            {
                return null;
            }

            var t = difficultyText.Trim();

            if (t.Equals("ANY", StringComparison.OrdinalIgnoreCase) || t.Equals("ALL", StringComparison.OrdinalIgnoreCase))
            {
                return null;
            }

            foreach (DifficultyBand v in Enum.GetValues(typeof(DifficultyBand)))
            {
                if (v.ToString().Equals(t, StringComparison.OrdinalIgnoreCase))
                {
                    return v;
                }
            }

            return null;
        }

        private static ChartFilter.Metric ParseMetric(string metricText)
        {
            var t = (metricText ?? "").ToUpperInvariant();

            if (t.Contains("STREAK"))
            {
                return ChartFilter.Metric.Streak;
            }

            if (t.Contains("MASTERY"))
            {
                return ChartFilter.Metric.TopicMastery;
            }

            if (t.Contains("TIME"))
            {
                return ChartFilter.Metric.AvgTime;
            }

            if (t.Contains("MISTAKE") || t.Contains("INCORRECT"))
            {
                return ChartFilter.Metric.Mistakes;
            }

            if (t.Contains("ATTEMPT"))
            {
                return ChartFilter.Metric.Attempts;
            }

            return ChartFilter.Metric.Accuracy;
        }

        private static ChartFilter.AxisX ParseAxisX(string axisText)
        {
            var t = (axisText ?? "").ToUpperInvariant();

            if (t.Contains("QUESTION"))
            {
                return ChartFilter.AxisX.Question;
            }

            if (t.Contains("TOPIC"))
            {
                return ChartFilter.AxisX.Topic;
            }

            if (t.Contains("DATE") || t.Contains("TIME") || t.Contains("DAY"))
            {
                return ChartFilter.AxisX.Date;
            }

            return ChartFilter.AxisX.AttemptIndex;
        }

        private static ChartFilter.Grouping ParseGrouping(string groupText)
        {
            var t = (groupText ?? "").ToUpperInvariant();

            if (t.Contains("WEEK"))
            {
                return ChartFilter.Grouping.Week;
            }

            if (t.Contains("DAY") || t.Contains("DATE"))
            {
                return ChartFilter.Grouping.Day;
            }

            return ChartFilter.Grouping.Attempt;
        }

        private sealed class AttemptRow
        {
            public DateTime SubmittedUtc;
            public bool IsCorrect;
            public double SecondsTaken;
            public Topic Topic;
            public DifficultyBand Difficulty;
            public long QuestionId;
        }

        private sealed class ChartPointRow
        {
            public DateTime? XDate;
            public double XNumber;
            public double Y;
            public string XLabel;
        }

        private List<AttemptRow> LoadAttemptRows(ChartFilter f)
        {
            var rows = new List<AttemptRow>();

            using var conn = Open();
            using var cmd = conn.CreateCommand();

            var where = new StringBuilder();
            where.Append("WHERE a.UserKey = $uk ");
            cmd.Parameters.AddWithValue("$uk", _userKey);

            if (f.Topic.HasValue)
            {
                where.Append("AND q.Topic = $topic ");
                cmd.Parameters.AddWithValue("$topic", (int)f.Topic.Value);
            }

            if (f.Difficulty.HasValue)
            {
                where.Append("AND q.Difficulty = $diff ");
                cmd.Parameters.AddWithValue("$diff", (int)f.Difficulty.Value);
            }

            if (f.LastNDays.HasValue)
            {
                var fromUtc = DateTime.UtcNow.AddDays(-Math.Max(1, f.LastNDays.Value));
                where.Append("AND a.SubmittedAt >= $from ");
                cmd.Parameters.AddWithValue("$from", fromUtc.ToString("o"));
            }

            var limitSql = "";

            if (f.LastNAttempts.HasValue)
            {
                limitSql = "LIMIT $lim";
                cmd.Parameters.AddWithValue("$lim", Math.Max(1, f.LastNAttempts.Value));
            }

            cmd.CommandText = $@"SELECT a.SubmittedAt, a.IsCorrect, a.SecondsTaken, a.QuestionId, q.Topic, q.Difficulty
                                 FROM Attempts a
                                 JOIN Questions q ON q.Id = a.QuestionId
                                 {where}
                                 ORDER BY a.SubmittedAt DESC
                                 {limitSql};";

            using var r = cmd.ExecuteReader();

            while (r.Read())
            {
                var submitted = DateTime.Parse(r.GetString(0), CultureInfo.InvariantCulture, DateTimeStyles.RoundtripKind).ToUniversalTime();
                var isCorrect = r.GetInt32(1) == 1;
                var seconds = r.IsDBNull(2) ? 0.0 : r.GetDouble(2);

                var qid = r.GetInt64(3);
                var topic = (Topic)r.GetInt32(4);
                var diff = (DifficultyBand)r.GetInt32(5);

                rows.Add(new AttemptRow { SubmittedUtc = submitted, IsCorrect = isCorrect, SecondsTaken = seconds, QuestionId = qid, Topic = topic, Difficulty = diff });
            }

            rows.Reverse();
            return rows;
        }

        private List<ChartPointRow> LoadChartPoints(ChartFilter f, List<AttemptRow> attempts)
        {
            if (attempts == null || attempts.Count == 0)
            {
                return new List<ChartPointRow>();
            }

            if (f.AxisXValue == ChartFilter.AxisX.Topic)
            {
                var grouped = attempts.GroupBy(a => a.Topic).OrderBy(g => g.Key);
                var pts = new List<ChartPointRow>();
                int idx = 0;

                foreach (var g in grouped)
                {
                    idx++;
                    int total = g.Count();
                    int correct = g.Count(x => x.IsCorrect);
                    int mistakes = total - correct;

                    var timed = g.Where(x => x.SecondsTaken > 0).Select(x => x.SecondsTaken).ToList();
                    double avgTime = timed.Count > 0 ? timed.Average() : 0.0;

                    double y = f.MetricValue switch
                    {
                        ChartFilter.Metric.Attempts => total,
                        ChartFilter.Metric.Mistakes => mistakes,
                        ChartFilter.Metric.AvgTime => avgTime,
                        ChartFilter.Metric.TopicMastery => (total == 0 ? 0.0 : (correct * 100.0 / total)),
                        _ => (total == 0 ? 0.0 : (correct * 100.0 / total))
                    };

                    pts.Add(new ChartPointRow { XNumber = idx, Y = y, XLabel = g.Key.ToString() });
                }

                return pts;
            }

            if (f.AxisXValue == ChartFilter.AxisX.Question)
            {
                var grouped = attempts.GroupBy(a => a.QuestionId).OrderBy(g => g.Key);
                var pts = new List<ChartPointRow>();
                int idx = 0;

                foreach (var g in grouped)
                {
                    idx++;
                    int total = g.Count();
                    int correct = g.Count(x => x.IsCorrect);
                    int mistakes = total - correct;

                    var timed = g.Where(x => x.SecondsTaken > 0).Select(x => x.SecondsTaken).ToList();
                    double avgTime = timed.Count > 0 ? timed.Average() : 0.0;

                    double y = f.MetricValue switch { ChartFilter.Metric.Attempts => total, ChartFilter.Metric.Mistakes => mistakes, ChartFilter.Metric.AvgTime => avgTime, _ => (total == 0 ? 0.0 : (correct * 100.0 / total)) };
                    pts.Add(new ChartPointRow { XNumber = idx, Y = y, XLabel = $"Q{g.Key}" });
                }

                return pts;
            }

            if (f.MetricValue == ChartFilter.Metric.TopicMastery)
            {
                return BuildTopicMasteryPoints(attempts);
            }

            if (f.GroupingValue == ChartFilter.Grouping.Attempt)
            {
                return BuildAttemptPoints(attempts, f);
            }

            if (f.GroupingValue == ChartFilter.Grouping.Day)
            {
                return BuildTimeGroupPoints(attempts, f, groupByWeek: false);
            }

            return BuildTimeGroupPoints(attempts, f, groupByWeek: true);
        }

        private static List<ChartPointRow> BuildAttemptPoints(List<AttemptRow> attempts, ChartFilter f)
        {
            var points = new List<ChartPointRow>(attempts.Count);

            int runningTotal = 0;
            int runningCorrect = 0;
            int runningMistakes = 0;
            int streak = 0;

            for (int i = 0; i < attempts.Count; i++)
            {
                var a = attempts[i];

                runningTotal++;

                if (a.IsCorrect)
                {
                    runningCorrect++;
                }

                else
                {
                    runningMistakes++;
                }

                if (f.MetricValue == ChartFilter.Metric.Streak)
                {
                    streak = a.IsCorrect ? (streak + 1) : 0;
                }

                double y = f.MetricValue switch { ChartFilter.Metric.Streak => streak, ChartFilter.Metric.Attempts => 1.0, ChartFilter.Metric.Mistakes => runningMistakes, ChartFilter.Metric.AvgTime => Math.Max(0.0, a.SecondsTaken), _ => runningTotal == 0 ? 0.0 : (runningCorrect * 100.0 / runningTotal) };

                points.Add(new ChartPointRow { XDate = a.SubmittedUtc.ToLocalTime(), XNumber = i + 1, Y = y });
            }

            return points;
        }

        private static List<ChartPointRow> BuildTimeGroupPoints(List<AttemptRow> attempts, ChartFilter f, bool groupByWeek)
        {
            var buckets = new SortedDictionary<string, List<AttemptRow>>(StringComparer.Ordinal);

            foreach (var attempt in attempts)
            {
                var dt = attempt.SubmittedUtc.ToLocalTime();

                string key;

                if (groupByWeek)
                {
                    key = dt.Date.AddDays(-(((int)dt.DayOfWeek + 6) % 7)).ToString("yyyy-MM-dd", CultureInfo.InvariantCulture);
                }

                else
                {
                    key = dt.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture);
                }

                if (!buckets.TryGetValue(key, out var list))
                {
                    list = new List<AttemptRow>();
                    buckets[key] = list;
                }

                list.Add(attempt);
            }

            var points = new List<ChartPointRow>(buckets.Count);
            int idx = 0;

            foreach (var kv in buckets)
            {
                idx++;

                var list = kv.Value;
                int total = list.Count;
                int correct = list.Count(x => x.IsCorrect);
                int mistakes = total - correct;
                double avgTime = 0.0;
                var timed = list.Where(x => x.SecondsTaken > 0).ToList();

                if (timed.Count > 0)
                {
                    avgTime = timed.Average(x => x.SecondsTaken);
                }

                double y = f.MetricValue switch { ChartFilter.Metric.Attempts => total, ChartFilter.Metric.Mistakes => mistakes, ChartFilter.Metric.AvgTime => avgTime, _ => total == 0 ? 0.0 : (correct * 100.0 / total) };

                DateTime? xDate = null;

                if (DateTime.TryParseExact(kv.Key, "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.AssumeUniversal, out var parsed))
                {
                    xDate = DateTime.SpecifyKind(parsed, DateTimeKind.Local);
                }

                points.Add(new ChartPointRow { XDate = xDate, XNumber = idx, Y = y });
            }

            return points;
        }

        private static List<ChartPointRow> BuildTopicMasteryPoints(List<AttemptRow> attempts)
        {
            var grouped = attempts.GroupBy(a => a.Topic).OrderBy(g => g.Key).ToList();
            var points = new List<ChartPointRow>();
            int idx = 0;

            foreach (var g in grouped)
            {
                idx++;

                int total = g.Count();
                int correct = g.Count(x => x.IsCorrect);
                double accuracy = total == 0 ? 0.0 : (correct * 100.0 / total);
                points.Add(new ChartPointRow { XNumber = idx, Y = accuracy });
            }

            return points;
        }

        private static string BuildChartTitle(ChartFilter f)
        {
            return f.MetricValue switch { ChartFilter.Metric.Streak => "STREAK (TREND)", ChartFilter.Metric.TopicMastery => "TOPIC MASTERY", ChartFilter.Metric.AvgTime => "AVG TIME (TREND)", ChartFilter.Metric.Attempts => "ATTEMPTS", ChartFilter.Metric.Mistakes => "MISTAKES", _ => "ACCURACY (TREND)" };
        }

        private static string BuildChartSubtitle(ChartFilter f, int points)
        {
            var range = string.IsNullOrWhiteSpace(f.RangeText) ? "RANGE" : f.RangeText.ToUpperInvariant();
            var group = string.IsNullOrWhiteSpace(f.GroupByText) ? "GROUP" : f.GroupByText.ToUpperInvariant();

            var topic = f.Topic.HasValue ? f.Topic.Value.ToString().ToUpperInvariant() : "ANY TOPIC";
            var diff = f.Difficulty.HasValue ? f.Difficulty.Value.ToString().ToUpperInvariant() : "ANY DIFFICULTY";

            return $"{range} · {group} · {topic} · {diff} · {points} POINTS";
        }

        private void RenderChart(List<ChartPointRow> points, ChartFilter f)
        {
            if (chartMain == null)
            {
                return;
            }

            chartMain.Series.Clear();

            string metricLabel = f.MetricValue switch { ChartFilter.Metric.Accuracy => "ACCURACY", ChartFilter.Metric.AvgTime => "AVG TIME", ChartFilter.Metric.Attempts => "ATTEMPTS", ChartFilter.Metric.Mistakes => "MISTAKES", ChartFilter.Metric.Streak => "STREAK", ChartFilter.Metric.TopicMastery => "TOPIC MASTERY", _ => "METRIC" };
            string xLabel = f.AxisXValue switch { ChartFilter.AxisX.Date => (f.GroupingValue == ChartFilter.Grouping.Week ? "WEEK" : "DATE"), ChartFilter.AxisX.Topic => "TOPIC", ChartFilter.AxisX.Question => "QUESTION", _ => "ATTEMPT" };
            string titleText = $"{metricLabel} vs {xLabel}";

            chartMain.Titles.Clear();

            var title = new ChartTitle { Text = titleText };
            title.Font = new Font("Agency", 10f, FontStyle.Bold);
            chartMain.Titles.Add(title);
            

            var seriesType = PickSeriesType(f.MetricValue);

            if (f.AxisXValue == ChartFilter.AxisX.Topic || f.AxisXValue == ChartFilter.AxisX.Question)
            {
                seriesType = ChartSeriesType.Column;
            }

            var seriesName = (f.MetricText ?? "").Trim();

            if (string.IsNullOrEmpty(seriesName))
            {
                seriesName = BuildChartTitle(f);
            }

            var series = new ChartSeries(seriesName, seriesType);

            series.Style.Border.Width = 3;

            for (int i = 0; i < points.Count; i++)
            {
                var p = points[i];

                if (f.AxisXValue == ChartFilter.AxisX.Date && p.XDate.HasValue)
                {
                    series.Points.Add(p.XDate.Value.ToOADate(), p.Y);
                }

                else
                {
                    series.Points.Add(p.XNumber, p.Y);
                }
            }

            if (chartMain?.PrimaryXAxis != null)
            {
                chartMain.PrimaryXAxis.Labels.Clear();

                if ((f.AxisXValue == ChartFilter.AxisX.Topic || f.AxisXValue == ChartFilter.AxisX.Question) && points.Count > 0 && !string.IsNullOrEmpty(points[0].XLabel))
                {

                    for (int i = 0; i < points.Count; i++)
                    {
                        chartMain.PrimaryXAxis.Labels.Add(new ChartAxisLabel(points[i].XNumber, points[i].XLabel));
                    }
                }
            }

            chartMain.Series.Add(series);

            SetAxisTitles(f);
            TuneAxisFormatting(f);
        }

        private static ChartSeriesType PickSeriesType(ChartFilter.Metric metric)
        {
            return metric switch { ChartFilter.Metric.TopicMastery => ChartSeriesType.Column, _ => ChartSeriesType.Line };
        }

        private void SetAxisTitles(ChartFilter f)
        {
            try
            {
                if (chartMain?.PrimaryXAxis != null)
                {
                    chartMain.PrimaryXAxis.Title = f.AxisXValue switch { ChartFilter.AxisX.Date => "Date", ChartFilter.AxisX.Topic => "Topic", ChartFilter.AxisX.Question => "Question", _ => "Attempt" };
                }

                if (chartMain?.PrimaryYAxis != null)
                {
                    chartMain.PrimaryYAxis.Title = f.MetricValue switch { ChartFilter.Metric.AvgTime => "Seconds", ChartFilter.Metric.Attempts => "Attempts", ChartFilter.Metric.Mistakes => "Mistakes", ChartFilter.Metric.Streak => "Streak", ChartFilter.Metric.TopicMastery => "Accuracy (%)", _ => "Accuracy (%)" };
                }
            }

            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }

        private void TuneAxisFormatting(ChartFilter f)
        {
            try
            {
                if (chartMain?.PrimaryXAxis != null)
                {
                    var ax = chartMain.PrimaryXAxis;
                    var valueTypeProp = ax.GetType().GetProperty("ValueType");

                    if (valueTypeProp != null && valueTypeProp.PropertyType.IsEnum)
                    {
                        var vtName = (f.AxisXValue == ChartFilter.AxisX.Date) ? "DateTime" : "Double";
                        valueTypeProp.SetValue(ax, Enum.Parse(valueTypeProp.PropertyType, vtName));
                    }

                    var dtFmtProp = ax.GetType().GetProperty("DateTimeFormat");

                    if (dtFmtProp != null && dtFmtProp.CanWrite)
                    {
                        dtFmtProp.SetValue(ax, f.AxisXValue == ChartFilter.AxisX.Date ? "dd MMM" : "");
                    }
                }
                
                if (chartMain?.PrimaryYAxis != null)
                {
                    var ay = chartMain.PrimaryYAxis;
                    var fmtProp = ay.GetType().GetProperty("Format");

                    if (fmtProp != null && fmtProp.CanWrite)
                    {
                        fmtProp.SetValue(ay, f.MetricValue == ChartFilter.Metric.AvgTime ? "0.0" : "");
                    }
                }
            }

            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }

        }

        private SqliteConnection Open()
        {
            var conn = new SqliteConnection($"Data Source={_dbPath}");
            conn.Open();

            using var pragma = conn.CreateCommand();
            pragma.CommandText = "PRAGMA foreign_keys = ON;";
            pragma.ExecuteNonQuery();

            return conn;
        }

        private void RefreshReportList()
        {
            if (lvReports == null)
            {
                return;
            }

            lvReports.BeginUpdate();
            lvReports.Items.Clear();

            var files = SafeListReportFiles();

            foreach (var file in files)
            {
                var displayName = Path.GetFileNameWithoutExtension(file);
                var dt = File.GetLastWriteTime(file).ToString("dd MMM yyyy", CultureInfo.InvariantCulture);

                var item = new ListViewItem(displayName);
                item.SubItems.Add(dt);
                item.Tag = file;
                lvReports.Items.Add(item);
            }

            try
            {
                if (lvReports == null || lvReports.Columns.Count < 2)
                {
                    return;
                }

                var total = lvReports.ClientSize.Width;

                if (total <= 0)
                {
                    return;
                }

                var dateWidth = 140;
                lvReports.Columns[1].Width = dateWidth;

                var reportWidth = total - dateWidth - SystemInformation.VerticalScrollBarWidth - 8;

                if (reportWidth < 140)
                {
                    reportWidth = 140;
                }

                lvReports.Columns[0].Width = reportWidth;
            }

            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }

            lvReports.EndUpdate();
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

        private void ShowNoReportSelected()
        {
            _selectedReportPath = "";

            if (lblSelectedReport != null)
            {
                lblSelectedReport.Text = "NO REPORT SELECTED";
            }

            if (btnDownloadPdf != null)
            {
                btnDownloadPdf.Enabled = false;
            }

            if (btnOpenExternal != null)
            {
                btnOpenExternal.Enabled = false;
            }

            if (wPdf != null)
            {
                try
                {
                    wPdf.DocumentText = "<html><body style='font-family:Agency; padding:24px; color:#444;'>" + "<h2>No report selected</h2>" + "<p>Select a report from the list or generate a new one.</p>" + "</body></html>";
                }

                catch (Exception ex)
                {
                    Debug.WriteLine(ex);
                }
            }
        }

        private void SetSelectedReport(string path)
        {
            _selectedReportPath = string.IsNullOrWhiteSpace(path) ? "" : path;

            var has = !string.IsNullOrWhiteSpace(_selectedReportPath) && File.Exists(_selectedReportPath);

            if (lblSelectedReport != null)
            {
                lblSelectedReport.Text = has ? Path.GetFileNameWithoutExtension(_selectedReportPath).ToUpperInvariant() : "NO REPORT SELECTED";
            }

            if (btnDownloadPdf != null)
            {
                btnDownloadPdf.Enabled = has;
            }

            if (btnOpenExternal != null)
            {
                btnOpenExternal.Enabled = has;
            }

            if (wPdf != null)
            {
                try
                {
                    if (has)
                    {
                        wPdf.Navigate(new Uri(_selectedReportPath).AbsoluteUri);
                    }

                    else
                    {
                        ShowNoReportSelected();
                    }
                }

                catch (Exception ex)
                {
                    Debug.WriteLine(ex);
                }
            }
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            var start = new Start();
            start.StartPosition = FormStartPosition.CenterScreen;
            start.Show();
            Close();
        }

        private void btnGenerateReport_Click(object sender, EventArgs e)
        {
            try
            {
                var stats = SafeLoadDashboardStats();
                var stamp = DateTime.UtcNow.ToString("yyyyMMdd_HHmmss", CultureInfo.InvariantCulture);
                var reportPath = Path.Combine(_reportsDir, $"report_{stamp}.html");
                var chartPngPath = Path.Combine(_reportsDir, $"chart_{stamp}.png");

                try
                {
                    if (chartMain != null)
                    {
                        SaveChartPng(chartMain, chartPngPath);
                    }
                }

                catch
                {
                    chartPngPath = "";
                }

                var html = BuildReportHtml(chartPngPath, stats);
                File.WriteAllText(reportPath, html, Encoding.UTF8);

                RefreshReportList();
                SelectReportInList(reportPath);
                SetSelectedReport(reportPath);
            }

            catch (Exception ex)
            {
                MessageBox.Show(this, "Failed to generate the report:\n\n" + ex.Message, "Mondas", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SelectReportInList(string path)
        {
            if (lvReports == null)
            {
                return;
            }

            foreach (ListViewItem item in lvReports.Items)
            {
                if (string.Equals(item.Tag as string, path, StringComparison.OrdinalIgnoreCase))
                {
                    item.Focused = true;
                    item.Selected = true;
                    item.EnsureVisible();
                    break;
                }
            }
        }

        private static string BuildReportHtml(string chartPngPath, DashboardStats stats)
        {
            var name = (stats.FullName ?? "USER").Trim();

            if (name.Length == 0)
            {
                name = "USER";
            }

            var localTimeNow = DateTime.Now.ToString("ddd dd MMM yyyy, HH:mm", CultureInfo.InvariantCulture);
            var sb = new StringBuilder();

            sb.Append("<!doctype html><html><head><meta charset='utf-8'/>");
            sb.Append("<title>Your Mondas Report</title>");
            sb.Append("<style>");
            sb.Append("body{font-family: Muro, Agency; padding: 28px; color: #111;}");
            sb.Append("h1{margin :0 0 6px 0; letter-spacing: 0.5px;}");
            sb.Append(".muted{color:#666;}");
            sb.Append(".row{display: flex; gap: 14px; margin: 18px 0; flex-wrap: wrap;}");
            sb.Append(".card{border: 1px solid #ddd; padding: 14px; border-radius: 10px; min-width :180px;}");
            sb.Append(".k{font-size: 12px; color: #666; text-transform: uppercase; letter-spacing: 0.8px;}");
            sb.Append(".v{font-size: 28px; font-weight: 700; margin-top: 6px;}");
            sb.Append("table{border-collapse: collapse; width: 100%; margin-top: 14px;}");
            sb.Append("th,td{border: 1px solid #ddd; padding: 10px; text-align: left;}");
            sb.Append("th{background: #f6f6f6;}");
            sb.Append("</style></head><body>");

            sb.Append("<h1>Mondas Progress Report</h1>");
            sb.Append($"<div class = 'muted'>User: <b>{Escape(name)}</b> · Generated: {Escape(localTimeNow)}</div>");

            sb.Append("<div class='row'>");
            sb.Append(Card("Attempts", stats.TotalAttempts.ToString(CultureInfo.InvariantCulture)));
            sb.Append(Card("Accuracy", $"{(stats.Accuracy01 * 100.0):0}%"));
            sb.Append(Card("Avg Time", stats.AvgSeconds <= 0 ? "—" : $"{stats.AvgSeconds:0.0}s"));
            sb.Append(Card("Streak", stats.CurrentStreak.ToString(CultureInfo.InvariantCulture)));
            sb.Append("</div>");

            if (!string.IsNullOrEmpty(chartPngPath) && File.Exists(chartPngPath))
            {
                sb.Append("<h2>Chart Snapshot</h2>");
                sb.Append($"<img src='{Escape(new Uri(chartPngPath).AbsoluteUri)}' style = 'max-width: 100%; border: 1px solid #ddd; border-radius: 10px;'/>");
            }

            sb.Append("<h2>Mastery by Topic</h2>");
            sb.Append("<table><tr><th>Topic</th><th>Seen</th><th>Correct</th><th>Accuracy</th></tr>");

            foreach (var row in stats.MasteryByTopic.OrderByDescending(x => x.Seen))
            {
                var accuracy = row.Seen <= 0 ? 0.0 : (row.Correct * 100.0 / row.Seen);

                sb.Append("<tr>");
                sb.Append("<td>" + Escape(row.Topic.ToString()) + "</td>");
                sb.Append("<td>" + row.Seen.ToString(CultureInfo.InvariantCulture) + "</td>");
                sb.Append("<td>" + row.Correct.ToString(CultureInfo.InvariantCulture) + "</td>");
                sb.Append("<td>" + accuracy.ToString("0", CultureInfo.InvariantCulture) + "%</td>");
                sb.Append("</tr>");
            }

            sb.Append("</table>");
            sb.Append("<h2>Top Misconceptions</h2>");

            if (stats.TopMisconceptions.Count == 0)
            {
                sb.Append("<div class = 'muted'>No misconceptions encountered!</div>");
            }

            else
            {
                sb.Append("<table><tr><th>Tag</th><th>Count</th><th>Last Seen</th></tr>");

                foreach (var misconception in stats.TopMisconceptions)
                {
                    sb.Append("<tr>");
                    sb.Append("<td>" + Escape(misconception.Tag) + "</td>");
                    sb.Append("<td>" + misconception.Count.ToString(CultureInfo.InvariantCulture) + "</td>");
                    sb.Append("<td>" + Escape(misconception.LastSeenUtc.ToLocalTime().ToString("dd MMM yyyy", CultureInfo.InvariantCulture)) + "</td>");
                    sb.Append("</tr>");
                }
                sb.Append("</table>");
            }

            sb.Append("</body></html>");
            return sb.ToString();

            static string Escape(string s) => (s ?? "").Replace("&", "&amp;").Replace("<", "&lt;").Replace(">", "&gt;").Replace("\"", "&quot;");
            static string Card(string key, string value) => $"<div class = 'card'><div class = 'k'>{Escape(key)}</div><div class = 'v'>{Escape(value)}</div></div>";
        }

        private void ApplyKpisFromAttempts(List<AttemptRow> attempts)
        {
            int total = attempts.Count;
            int correct = attempts.Count(a => a.IsCorrect);
            double acc01 = total == 0 ? 0.0 : (double)correct / total;

            var timed = attempts.Where(a => a.SecondsTaken > 0).Select(a => a.SecondsTaken).ToList();
            double avg = timed.Count == 0 ? 0.0 : timed.Average();

            int streak = 0;

            for (int i = attempts.Count - 1; i >= 0; i--)
            {
                if (attempts[i].IsCorrect)
                {
                    streak++;
                }

                else
                {
                    break;
                }
            }

            lblKpiAttemptsValue.Text = total.ToString(CultureInfo.InvariantCulture);
            lblKpiAccuracyValue.Text = $"{(acc01 * 100.0):0}%";
            lblKpiAvgTimeValue.Text = avg <= 0 ? "-" : $"{avg:0.0}s";
            lblKpiStreakValue.Text = streak.ToString(CultureInfo.InvariantCulture);
        }

        private void btnDownloadPdf_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(_selectedReportPath) || !File.Exists(_selectedReportPath))
            {
                return;
            }

            using var saveFileDialog = new SaveFileDialog
            {
                Title = "Download report",
                Filter = "HTML file (*.html)|*.html|All files (*.*)|*.*",
                FileName = Path.GetFileName(_selectedReportPath),
                AddExtension = true
            };

            if (saveFileDialog.ShowDialog(this) != DialogResult.OK)
            {
                return;
            }

            try
            {
                File.Copy(_selectedReportPath, saveFileDialog.FileName, overwrite: true);
                MessageBox.Show(this, "Report downloaded.", "Mondas", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            catch (Exception ex)
            {
                MessageBox.Show(this, "Download failed:\n\n" + ex.Message, "Mondas", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnOpenExternal_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(_selectedReportPath) || !File.Exists(_selectedReportPath))
            {
                return;
            }

            try
            {
                Process.Start(new ProcessStartInfo(_selectedReportPath) { UseShellExecute = true });
            }

            catch (Exception ex)
            {
                MessageBox.Show(this, "Open failed:\n\n" + ex.Message, "Mondas", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void lvReports_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvReports == null || lvReports.SelectedItems.Count == 0)
            {
                ShowNoReportSelected();
                return;
            }

            var path = lvReports.SelectedItems[0].Tag as string;
            SetSelectedReport(path);
        }
    }
}