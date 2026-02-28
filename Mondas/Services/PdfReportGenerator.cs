using System;
using System.Collections.Generic;
using System.IO;
using Mondas.Models;
using Syncfusion.Pdf;
using Syncfusion.Pdf.Graphics;
using System.Drawing;

namespace Mondas.Services
{
    public sealed class PdfReportGenerator
    {
        public byte[] Generate(string userDisplayName, ChartFilters filters, KpiSnapshot kpis, List<(Topic topic, int seen, int correct)> topicBreakdown, List<MisconceptionRow> misconceptions, byte[] chartPngOrNull)
        {
            using var doc = new PdfDocument();

            var page = doc.Pages.Add();
            var g = page.Graphics;

            var titleFont = new PdfStandardFont(PdfFontFamily.Helvetica, 24f, PdfFontStyle.Bold);
            var hFont = new PdfStandardFont(PdfFontFamily.Helvetica, 14f, PdfFontStyle.Bold);
            var bodyFont = new PdfStandardFont(PdfFontFamily.Helvetica, 11f);

            float x = 40;
            float y = 40;

            g.DrawString("Mondas Report", titleFont, PdfBrushes.Black, new System.Drawing.PointF(x, y));
            y += 40;

            g.DrawString($"User: {userDisplayName}", bodyFont, PdfBrushes.Black, new System.Drawing.PointF(x, y));
            y += 18;

            g.DrawString($"Generated: {DateTime.Now:dd MMM yyyy HH:mm}", bodyFont, PdfBrushes.Black, new System.Drawing.PointF(x, y));
            y += 18;

            g.DrawString($"Filters: {filters.Range} · {filters.Metric} · X = {filters.XAxis} · GroupBy = {filters.GroupBy}", bodyFont, PdfBrushes.Black, new System.Drawing.PointF(x, y));
            y += 26;

            g.DrawString("Summary", hFont, PdfBrushes.Black, new System.Drawing.PointF(x, y));
            y += 18;

            var kpiText = $"Attempts: {kpis.Attempts}\n" + $"Accuracy: {(kpis.Accuracy01 * 100.0):0}%\n" + $"Avg Time: {kpis.AvgSeconds:0.0}s\n" + $"Current Streak: {kpis.Streak}";

            g.DrawString(kpiText, bodyFont, PdfBrushes.Black, new System.Drawing.RectangleF(x, y, page.GetClientSize().Width - 80, 80));
            y += 90;

            if (chartPngOrNull != null && chartPngOrNull.Length > 9)
            {
                g.DrawString("Chart Snapshot", hFont, PdfBrushes.Black, new System.Drawing.PointF(x, y));
                y += 18;

                using var ms = new MemoryStream(chartPngOrNull);
                var bmp = new PdfBitmap(ms);

                float maxWidth = page.GetClientSize().Width - 80;
                float drawWidth = Math.Min(maxWidth, 520);
                float drawHeight = drawWidth * 0.55f;

                g.DrawImage(bmp, new System.Drawing.RectangleF(x, y, drawWidth, drawHeight));
                y += drawHeight + 20;
            }

            var page2 = doc.Pages.Add();
            var g2 = page2.Graphics;

            float y2 = 40;
            g2.DrawString("Mastery by Topic", hFont, PdfBrushes.Black, new System.Drawing.PointF(x, y2));
            y2 += 20;

            foreach (var row in topicBreakdown)
            {
                var acc = row.seen <= 0 ? 0.0 : (100.0 * row.correct / row.seen);
                g2.DrawString($"{row.topic,-10} Seen: {row.seen,3} Accuracy: {acc: 0}%", bodyFont, PdfBrushes.Black, new System.Drawing.PointF(x, y2));
                y2 += 16;
            }

            y2 += 14;
            g2.DrawString("Top Misconceptions", hFont, PdfBrushes.Black, new System.Drawing.PointF(x, y2));
            y2 += 20;

            if (misconceptions == null || misconceptions.Count == 0)
            {
                g2.DrawString("No misconceptions recorded in this range.", bodyFont, PdfBrushes.Black, new System.Drawing.PointF(x, y2));
            }

            else
            {
                foreach (var row in misconceptions)
                {
                    g2.DrawString($"• {row.Tag} (x{row.Count}, last {row.LastSeenUtc.ToLocalTime():dd MMM})", bodyFont, PdfBrushes.Black, new System.Drawing.PointF(x, y2));
                    y2 += 16;
                }
            }
        
            using var outMemoryStream = new MemoryStream();
            doc.Save(outMemoryStream);
            return outMemoryStream.ToArray();
        }
    }
}