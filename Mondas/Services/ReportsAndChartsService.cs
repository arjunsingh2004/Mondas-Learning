using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Resources;
using Microsoft.Data.Sqlite;
using Mondas.Models;
using Syncfusion.DataSource.Extensions;

namespace Mondas.Services
{
    public sealed class ReportsAndChartsService
    {
        private readonly SqliteAttemptRepository _attemptRepo;
        private readonly Dictionary<int, Question> _questionById;
        private readonly string _dbPath;

        public ReportsAndChartsService(string dbPath, IReadOnlyList<Question> questions)
        {
            _dbPath = dbPath ?? throw new ArgumentNullException(nameof(dbPath));
            _attemptRepo = new SqliteAttemptRepository(dbPath);

            _questionById = questions?.ToDictionary(q => q.Id, q => q) ?? new Dictionary<int, Question>();
        }

        public List<AttemptViewRow> LoadAttempts(string userKey)
        {
            userKey = string.IsNullOrWhiteSpace(userKey) ? "local" : userKey.Trim();
            var raw = _attemptRepo.GetForUser(userKey) ?? new List<AttemptRecord>();
            var rows = new List<AttemptViewRow>(raw.Count);

            foreach (var a in raw)
            {
                if (!_questionById.TryGetValue(a.QuestionId, out var q))
                {
                    continue;
                }

                rows.Add(new AttemptViewRow
                {
                    QuestionId = a.QuestionId,
                    SubmittedAtUtc = a.SubmittedAt.Kind == DateTimeKind.Utc ? a.SubmittedAt : a.SubmittedAt.ToUniversalTime(),
                    IsCorrect = a.IsCorrect,
                    SecondsTaken = a.SecondsTaken,
                    Topic = q.Metadata.Topic,
                    Difficulty = q.Metadata.Difficulty
                });
            }

            return rows;
        }

        public List<AttemptViewRow> ApplyFilters(List<AttemptViewRow> all, ChartFilters filters)
        {
            if (all == null)
            {
                return new List<AttemptViewRow>();
            }

            IEnumerable<AttemptViewRow> q = all;

            if (filters.Topic.HasValue)
            {
                q = q.Where(x => x.Topic == filters.Topic.Value);
            }

            if (filters.Difficulty.HasValue)
            {
                q = q.Where(x => x.Difficulty == filters.Difficulty.Value);
            }

            q = ApplyRange(q, filters.Range);

            return q.OrderBy(x => x.SubmittedAtUtc).ToList();
        }

        private static IEnumerable<AttemptViewRow> ApplyRange(IEnumerable<AttemptViewRow> q, ChartRange range)
        {
            var listDesc = q.OrderByDescending(x => x.SubmittedAtUtc).ToList();

            if (range == ChartRange.AllTime)
            {
                return listDesc;
            }

            if (range == ChartRange.Last30Attempts)
            {
                return listDesc.Take(30);
            }

            if (range == ChartRange.Last100Attempts)
            {
                return listDesc.Take(100);
            }

            var now = DateTime.UtcNow;

            if (range == ChartRange.Last7Days)
            {
                return listDesc.Where(x => x.SubmittedAtUtc >= now.AddDays(-7));
            }

            if (range == ChartRange.Last30Days)
            {
                return listDesc.Where(x => x.SubmittedAtUtc >= now.AddDays(-30));
            }

            return listDesc;
        }
    
        public KpiSnapshot BuildKpis(List<AttemptViewRow> filteredChrono)
        {
            var k = new KpiSnapshot();

            if (filteredChrono == null || filteredChrono.Count == 0)
            {
                return k;
            }

            k.Attempts = filteredChrono.Count;
            k.Correct = filteredChrono.Count(x => x.IsCorrect);

            var times = filteredChrono.Where(x => x.SecondsTaken > 0).Select(x => x.SecondsTaken).ToList();
            k.AvgSeconds = times.Count == 0 ? 0.0 : times.Average();

            int streak = 0;
            
            for (int i = filteredChrono.Count - 1; i >= 0; i--)
            {
                if (!filteredChrono[i].IsCorrect)
                {
                    break;
                }

                streak++;
            }

            k.Streak = streak;

            return k;
        }

        public ChartBuildResult BuildChart(List<AttemptViewRow> filteredChrono, ChartFilters filters)
        {
            var result = new ChartBuildResult();

            if (filteredChrono == null || filteredChrono.Count == 0)
            {
                result.Title = "NO DATA";
                result.Subtitle = "Try widening your filters.";
                result.Series = Array.Empty<SeriesData>();
                result.PreferredChartType = "column";
                return result;
            }

            result.PreferredChartType = GuessChartType(filters);
            result.Title = BuildTitle(filters);
            result.Subtitle = BuildSubtitle(filters, filteredChrono.Count);

            var seriesBuckets = new Dictionary<string, Dictionary<string, Bucket>>(StringComparer.OrdinalIgnoreCase);

            for (int i = 0; i < filteredChrono.Count; i++)
            {
                var row = filteredChrono[i];

                string seriesName = ResolveSeriesKey(row, filters.GroupBy);
                string xKey = ResolveXAxisKey(row, filters.XAxis, attemptIndex1Based: i + 1);

                if (!seriesBuckets.TryGetValue(seriesName, out var xBuckets))
                {
                    xBuckets = new Dictionary<string, Bucket>(StringComparer.OrdinalIgnoreCase);
                    seriesBuckets[seriesName] = xBuckets;
                }

                if (!xBuckets.TryGetValue(xKey, out var bucket))
                {
                    bucket = new Bucket();
                    xBuckets[xKey] = bucket;
                }

                bucket.Count++;

                if (row.IsCorrect)
                {
                    bucket.Correct++;
                }

                if (!row.IsCorrect)
                {
                    bucket.Mistakes++;
                }

                if (row.SecondsTaken > 0)
                {
                    bucket.TimeCount++;
                    bucket.TimeSum += row.SecondsTaken;
                }
            }

            var seriesList = new List<SeriesData>();

            foreach (var seriesKvp in seriesBuckets)
            {
                var name = seriesKvp.Key;
                var xBuckets = seriesKvp.Value;

                var points = new List<ChartPointRow>();

                foreach (var xKvp in xBuckets)
                {
                    var xLabel = xKvp.Key;
                    var b = xKvp.Value;

                    double y = ComputeMetric(filters.Metric, b);

                    points.Add(new ChartPointRow { XLabel = xLabel, XValue = TryParseXAxisValue(filters.XAxis, xLabel), YValue = y, Count = b.Count });
                }

                points = OrderPoints(points, filters.XAxis);

                seriesList.Add(new SeriesData { Name = name, Points = points.ToArray() });
            }

            seriesList = seriesList.OrderBy(s => s.Name.Equals("ALL", StringComparison.OrdinalIgnoreCase) ? 0 : 1).ThenBy(s => s.Name, StringComparer.OrdinalIgnoreCase).ToList();
            result.Series = seriesList.ToArray();
            return result;
        }

        public List<MisconceptionRow> LoadTopMisconceptions(string userKey, ChartRange range, int limit = 6)
        {
            userKey = string.IsNullOrWhiteSpace(userKey) ? "local" : userKey.Trim();

            using var conn = new SqliteConnection($"Data Source={_dbPath}");
            conn.Open();

            DateTime? sinceUtc = RangeToSinceUtc(range);

            using var cmd = conn.CreateCommand();

            cmd.CommandText = @"
                SELECT mt.Tag, COUNT(1) AS Cnt, MAX(a.SubmittedAt) AS LastUtc
                FROM Attempts a
                JOIN QuestionMisconceptionTags qmt ON qmt.QuestionId = a.QuestionId
                JOIN MisconceptionTags mt ON mt.Id = qmt.TagId
                WHERE a.UserKey = $uk AND a.IsCorrect = 0" + (sinceUtc.HasValue ? " AND a.SubmiittedAt >= $since " : "") + @"
                GROUP BY mt.Tag
                ORDER BY Cnt DESC
                LIMIT $limit;";

            cmd.Parameters.AddWithValue("$uk", userKey);
            cmd.Parameters.AddWithValue("$limit", Math.Max(1, limit));

            if (sinceUtc.HasValue)
            {
                cmd.Parameters.AddWithValue("$since", sinceUtc.Value.ToString("o", CultureInfo.InvariantCulture));
            }

            var list = new List<MisconceptionRow>();

            using var r = cmd.ExecuteReader();

            while (r.Read())
            {
                var tag = r.IsDBNull(0) ? "" : r.GetString(0);
                int count = Convert.ToInt32(r.GetInt64(1));

                DateTime lastUtc = DateTime.UtcNow;

                if (!r.IsDBNull(2))
                {
                    lastUtc = DateTime.Parse(r.GetString(2), CultureInfo.InvariantCulture, DateTimeStyles.RoundtripKind).ToUniversalTime();
                }

                list.Add(new MisconceptionRow { Tag = tag, Count = count, LastSeenUtc = lastUtc });
            }

            return list;
        }

        private static DateTime? RangeToSinceUtc(ChartRange range)
        {
            var now = DateTime.UtcNow;

            return range switch { ChartRange.Last7Days => now.AddDays(-7), ChartRange.Last30Days => now.AddDays(-30), _ => null };
        }

        private static string GuessChartType(ChartFilters f)
        {
            if (f.XAxis == ChartXAxis.Date || f.XAxis == ChartXAxis.AttemptIndex)
            {
                return "Line";
            }

            return "Column";            
        }

        private static string BuildTitle(ChartFilters f)
        {
            string metric = f.Metric switch
            {
                ChartMetric.AccuracyPercent => "ACCURACY (TREND)",
                ChartMetric.Attempts => "ATTEMPTS (VOLUME)",
                ChartMetric.Mistakes => "MISTAKES (COUNT)",
                ChartMetric.AvgSeconds => "AVG TIME (SECONDS)",
                _ => "CHART"
            };

            return metric;
        }

        private static string BuildSubtitle(ChartFilters f, int n)
        {
            string range = f.Range switch
            {
                ChartRange.Last30Attempts => "SHOWING LAST 30 ATTEMPTS",
                ChartRange.Last100Attempts => "SHOWING LAST 100 ATTEMPTS",
                ChartRange.Last7Days => "SHOWING LAST 7 DAYS",
                ChartRange.Last30Days => "SHOWING LAST 30 DAYS",
                ChartRange.AllTime => "SHOWING ALL TIME",
                _ => $"SHOWING {n}"
            };

            string grouped = f.GroupBy == ChartGroupBy.None ? "GROUPED BY: NONE" : $"GROUPED BY: {f.GroupBy.ToString().ToUpperInvariant()}";
            string x = $"X AXIS: {f.XAxis.ToString().ToUpperInvariant()}";

            string topic = f.Topic.HasValue ? $"TOPIC: {f.Topic.Value.ToString().ToUpperInvariant()}" : "TOPIC: ANY";
            string diff = f.Difficulty.HasValue ? $"DIFFICULTY: {f.Difficulty.Value.ToString().ToUpperInvariant()}" : "DIFFICULTY: ANY";

            return $"{range} · {topic} · {diff} · {x} · {grouped}";
        }

        private static string ResolveSeriesKey(AttemptViewRow row, ChartGroupBy groupBy)
        {
            return groupBy switch
            {
                ChartGroupBy.Topic => row.Topic.ToString(),
                ChartGroupBy.Difficulty => row.Difficulty.ToString(),
                _ => "All"
            };
        }

        private static string ResolveXAxisKey(AttemptViewRow row, ChartXAxis xAxis, int attemptIndex1Based)
        {
            return xAxis switch
            {
                ChartXAxis.AttemptIndex => attemptIndex1Based.ToString(CultureInfo.InvariantCulture),
                ChartXAxis.Date => row.SubmittedAtUtc.ToLocalTime().ToString("dd MMM", CultureInfo.InvariantCulture),
                ChartXAxis.Topic => row.Topic.ToString(),
                ChartXAxis.Difficulty => row.Difficulty.ToString(),
                _ => attemptIndex1Based.ToString(CultureInfo.InvariantCulture)
            };
        }

        private static double ComputeMetric(ChartMetric metric, Bucket b)
        {
            return metric switch
            {
                ChartMetric.Attempts => b.Count,
                ChartMetric.Mistakes => b.Mistakes,
                ChartMetric.AvgSeconds => b.TimeCount <= 0 ? 0.0 : b.TimeSum / b.TimeCount,
                ChartMetric.AccuracyPercent => b.Count <= 0 ? 0.0 : (100.0 * b.Correct / b.Count),
                _ => 0.0
            };
        }

        private static double TryParseXAxisValue(ChartXAxis xAxis, string label)
        {
            if (xAxis == ChartXAxis.AttemptIndex && double.TryParse(label, NumberStyles.Any, CultureInfo.InvariantCulture, out var v))
            {
                return v;
            }

            return 0.0;
        }

        private static List<ChartPointRow> OrderPoints(List<ChartPointRow> points, ChartXAxis xAxis)
        {
            if (xAxis == ChartXAxis.AttemptIndex)
            {
                return points.OrderBy(p => p.XValue).ToList();
            }

            if (xAxis == ChartXAxis.Date)
            {
                return points;
            }

            return points.OrderBy(p => p.XLabel, StringComparer.OrdinalIgnoreCase).ToList();
        }

        private sealed class Bucket
        {
            public int Count;
            public int Correct;
            public int Mistakes;
            public int TimeCount;
            public double TimeSum;
        }

        public sealed class AttemptViewRow
        {
            public int QuestionId { get; set; }
            public bool IsCorrect { get; set; }
            public DateTime SubmittedAtUtc { get; set; }
            public double SecondsTaken { get; set; }
            public Topic Topic { get; set; }
            public DifficultyBand Difficulty { get; set; }
        }

        public sealed class MisconceptionRow
        {
            public string Tag { get; set; } = "";
            public int Count { get; set; }
            public DateTime LastSeenUtc { get; set; }
        }
    }
}