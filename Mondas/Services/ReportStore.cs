using Syncfusion.Windows.Forms.Diagram;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Windows.Forms.DataVisualization.Charting;

namespace Mondas.Services
{
    public sealed class ReportStore
    {
        private readonly string _baseDir;

        public ReportStore(string baseDir)
        {
            _baseDir = baseDir ?? throw new ArgumentNullException(nameof(baseDir));
            Directory.CreateDirectory(_baseDir);
        }

        public string GetUserDir(string userKey)
        {
            userKey = string.IsNullOrWhiteSpace(userKey) ? "local" : userKey.Trim();
            var dir = Path.Combine(_baseDir, "reports", userKey);
            Directory.CreateDirectory(dir);
            return dir;
        }

        public List <ReportItem> ListReports(string userKey)
        {
            var dir = GetUserDir(userKey);
            var pdfs = Directory.GetFiles(dir, "*.pdf").OrderByDescending(f => File.GetCreationTimeUtc(f)).ToList();
            var list = new List<ReportItem>();

            foreach (var pdfPath in pdfs)
            {
                var id = Path.GetFileNameWithoutExtension(pdfPath);
                var metaPath = Path.Combine(dir, id + ".json");

                ReportMeta meta = null;

                try
                {
                    if (File.Exists(metaPath))
                    {
                        meta = JsonSerializer.Deserialize<ReportMeta>(File.ReadAllText(metaPath));
                    }
                }
                catch
                {

                }

                meta ??= new ReportMeta { Title = "Progress Report", CreatedUtc = File.GetCreationTimeUtc(pdfPath) };

                list.Add(new ReportItem { Id = id, PdfPath = pdfPath, MetaPath = metaPath, Meta = meta });
            }

            return list;
        }

        public ReportItem Save(string userKey, byte[] pdfBytes, ReportMeta meta)
        {
            var dir = GetUserDir(userKey);

            var id = "report_" + DateTime.UtcNow.ToString("yyyy-MM-dd_HHmmss");
            var pdfPath = Path.Combine(dir, id + ".pdf");
            var metaPath = Path.Combine(dir, id + ".json");

            File.WriteAllBytes(pdfPath, pdfBytes);

            meta ??= new ReportMeta();
            meta.CreatedUtc = DateTime.UtcNow;

            File.WriteAllText(metaPath, JsonSerializer.Serialize(meta, new JsonSerializerOptions { WriteIndented = true }));

            return new ReportItem { Id = id, PdfPath = pdfPath, MetaPath = metaPath, Meta = meta };
        }

        public sealed class ReportMeta
        {
            public string Title { get; set; } = "Progress Report";
            public DateTime CreatedUtc { get; set; } = DateTime.UtcNow;
            public string SummaryLine { get; set; } = "";
        }

        public sealed class ReportItem
        {
            public string Id { get; set; } = "";
            public string PdfPath { get; set; } = "";
            public string MetaPath { get; set; } = "";
            public ReportMeta Meta { get; set; } = new ReportMeta();
        }
    }
}