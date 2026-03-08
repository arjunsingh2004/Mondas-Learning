using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mondas.Models
{
    public enum ChartRange
    {
        Last30Attempts,
        Last100Attempts,
        Last7Days,
        Last30Days,
        AllTime
    }

    public enum ChartMetric
    {
        AccuracyPercent,
        Attempts,
        Mistakes,
        AvgSeconds
    }

    public enum ChartXAxis
    {
        AttemptIndex,
        Date,
        Topic,
        Difficulty
    }

    public enum ChartGroupBy
    {         
        None,
        Topic,
        Difficulty
    }

    public enum StatsSource
    {
        All,
        Quiz,
        PhishingSimulator,
        PasswordWorkshop
    }

    public sealed class ChartFilters
    {
        public ChartRange Range { get; set; } = ChartRange.Last30Attempts;
        public Topic? Topic { get; set; }
        public DifficultyBand? Difficulty { get; set; }
        public ChartMetric Metric { get; set; } = ChartMetric.AccuracyPercent;
        public ChartXAxis XAxis { get; set; } = ChartXAxis.AttemptIndex;
        public ChartGroupBy GroupBy { get; set; } = ChartGroupBy.None;
    }

    public sealed class KpiSnapshot
    {
        public int Attempts { get; set; }
        public int Correct { get; set; }
        public int Streak { get; set; }
        public double Accuracy01 => Attempts <= 0 ? 0.0 : (double)Correct / Attempts;
        public double AvgSeconds { get; set; }
    }

    public sealed class ChartPointRow
    {
        public string XLabel { get; set; } = "";
        public double XValue { get; set; }
        public double YValue { get; set; }
        public int Count { get; set; }
    }

    public sealed class SeriesData
    {
        public string Name { get; set; } = "";
        public ChartPointRow[] Points { get; set; } = Array.Empty<ChartPointRow>();
    }

    public sealed class ChartBuildResult
    {
        public string Title { get; set; } = "";
        public string Subtitle { get; set; } = "";
        public SeriesData[] Series { get; set; } = Array.Empty<SeriesData>();
        public string PreferredChartType { get; set; } = "Line";
    }
}
