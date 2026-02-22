namespace Mondas
{
    partial class ReportsAndChartsForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tlpRoot = new System.Windows.Forms.TableLayoutPanel();
            this.pnlTop = new System.Windows.Forms.Panel();
            this.btnLogout = new System.Windows.Forms.Button();
            this.lblUser = new System.Windows.Forms.Label();
            this.lblTitle = new System.Windows.Forms.Label();
            this.tabMain = new System.Windows.Forms.TabControl();
            this.tabCharts = new System.Windows.Forms.TabPage();
            this.tlpChartsRoot = new System.Windows.Forms.TableLayoutPanel();
            this.pnlChartsTop = new System.Windows.Forms.Panel();
            this.tlpKpis = new System.Windows.Forms.TableLayoutPanel();
            this.pnlKpiAttemptsCard = new System.Windows.Forms.Panel();
            this.lblKpiAttemptsValue = new System.Windows.Forms.Label();
            this.lblKpiAttemptTitle = new System.Windows.Forms.Label();
            this.pnlKpiAccuracyCard = new System.Windows.Forms.Panel();
            this.lblKpiAccuracyValue = new System.Windows.Forms.Label();
            this.lblKpiAccuracyTitle = new System.Windows.Forms.Label();
            this.pnlKpiAvgTimeCard = new System.Windows.Forms.Panel();
            this.lblKpiAvgTimeValue = new System.Windows.Forms.Label();
            this.lblKpiAvgTimeTitle = new System.Windows.Forms.Label();
            this.pnlKpiStreakCard = new System.Windows.Forms.Panel();
            this.lblKpiStreakValue = new System.Windows.Forms.Label();
            this.lblKpiStreakTitle = new System.Windows.Forms.Label();
            this.pnlFilters = new System.Windows.Forms.Panel();
            this.cmbGroupBy = new System.Windows.Forms.ComboBox();
            this.cmbXAxis = new System.Windows.Forms.ComboBox();
            this.cmbMetric = new System.Windows.Forms.ComboBox();
            this.btnRefreshCharts = new Syncfusion.WinForms.Controls.SfButton();
            this.cmbDifficulty = new System.Windows.Forms.ComboBox();
            this.cmbTopic = new System.Windows.Forms.ComboBox();
            this.cmbRange = new System.Windows.Forms.ComboBox();
            this.tlpCharts = new System.Windows.Forms.TableLayoutPanel();
            this.pnlChartHeader = new System.Windows.Forms.Panel();
            this.btnResetChart = new Syncfusion.WinForms.Controls.SfButton();
            this.btnExportChartPng = new Syncfusion.WinForms.Controls.SfButton();
            this.lblChartSubtitle = new System.Windows.Forms.Label();
            this.lblChartTitle = new System.Windows.Forms.Label();
            this.pnlChartHost = new System.Windows.Forms.Panel();
            this.chartMain = new Syncfusion.Windows.Forms.Chart.ChartControl();
            this.tabReport = new System.Windows.Forms.TabPage();
            this.lblRange = new System.Windows.Forms.Label();
            this.lblTopic = new System.Windows.Forms.Label();
            this.lblDifficulty = new System.Windows.Forms.Label();
            this.lblMetric = new System.Windows.Forms.Label();
            this.lblXAxis = new System.Windows.Forms.Label();
            this.lblGroupBy = new System.Windows.Forms.Label();
            this.splitReports = new System.Windows.Forms.SplitContainer();
            this.pnlReportLeftTop = new System.Windows.Forms.Panel();
            this.lblReportsTitle = new System.Windows.Forms.Label();
            this.btnGenerateReport = new Syncfusion.WinForms.Controls.SfButton();
            this.lvReports = new System.Windows.Forms.ListView();
            this.clmReport = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clmDate = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.pnlReportRightTop = new System.Windows.Forms.Panel();
            this.tlpReportActions = new System.Windows.Forms.TableLayoutPanel();
            this.lblSelectedReport = new System.Windows.Forms.Label();
            this.btnDownloadPdf = new Syncfusion.WinForms.Controls.SfButton();
            this.btnOpenExternal = new Syncfusion.WinForms.Controls.SfButton();
            this.wPdf = new System.Windows.Forms.WebBrowser();
            this.tlpRoot.SuspendLayout();
            this.pnlTop.SuspendLayout();
            this.tabMain.SuspendLayout();
            this.tabCharts.SuspendLayout();
            this.tlpChartsRoot.SuspendLayout();
            this.pnlChartsTop.SuspendLayout();
            this.tlpKpis.SuspendLayout();
            this.pnlKpiAttemptsCard.SuspendLayout();
            this.pnlKpiAccuracyCard.SuspendLayout();
            this.pnlKpiAvgTimeCard.SuspendLayout();
            this.pnlKpiStreakCard.SuspendLayout();
            this.pnlFilters.SuspendLayout();
            this.tlpCharts.SuspendLayout();
            this.pnlChartHeader.SuspendLayout();
            this.pnlChartHost.SuspendLayout();
            this.tabReport.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitReports)).BeginInit();
            this.splitReports.Panel1.SuspendLayout();
            this.splitReports.Panel2.SuspendLayout();
            this.splitReports.SuspendLayout();
            this.pnlReportLeftTop.SuspendLayout();
            this.pnlReportRightTop.SuspendLayout();
            this.tlpReportActions.SuspendLayout();
            this.SuspendLayout();
            // 
            // tlpRoot
            // 
            this.tlpRoot.ColumnCount = 1;
            this.tlpRoot.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpRoot.Controls.Add(this.pnlTop, 0, 0);
            this.tlpRoot.Controls.Add(this.tabMain, 0, 1);
            this.tlpRoot.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpRoot.Location = new System.Drawing.Point(2, 2);
            this.tlpRoot.Name = "tlpRoot";
            this.tlpRoot.RowCount = 2;
            this.tlpRoot.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 64F));
            this.tlpRoot.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpRoot.Size = new System.Drawing.Size(1180, 657);
            this.tlpRoot.TabIndex = 0;
            // 
            // pnlTop
            // 
            this.pnlTop.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlTop.Controls.Add(this.btnLogout);
            this.pnlTop.Controls.Add(this.lblUser);
            this.pnlTop.Controls.Add(this.lblTitle);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlTop.Location = new System.Drawing.Point(3, 3);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Padding = new System.Windows.Forms.Padding(12, 10, 12, 10);
            this.pnlTop.Size = new System.Drawing.Size(1174, 58);
            this.pnlTop.TabIndex = 0;
            // 
            // btnLogout
            // 
            this.btnLogout.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLogout.BackColor = System.Drawing.Color.White;
            this.btnLogout.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.btnLogout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogout.Font = new System.Drawing.Font("Agency", 9F);
            this.btnLogout.Location = new System.Drawing.Point(1065, 16);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(91, 30);
            this.btnLogout.TabIndex = 5;
            this.btnLogout.Text = "LOG OUT";
            this.btnLogout.UseVisualStyleBackColor = false;
            // 
            // lblUser
            // 
            this.lblUser.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblUser.AutoSize = true;
            this.lblUser.Font = new System.Drawing.Font("Agency", 9F);
            this.lblUser.Location = new System.Drawing.Point(939, 24);
            this.lblUser.Name = "lblUser";
            this.lblUser.Size = new System.Drawing.Size(121, 14);
            this.lblUser.TabIndex = 4;
            this.lblUser.Text = "ARJUN SINGH";
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Muro", 22F);
            this.lblTitle.Location = new System.Drawing.Point(15, 2);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(387, 44);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "REPORTS AND CHARTS";
            // 
            // tabMain
            // 
            this.tabMain.Controls.Add(this.tabCharts);
            this.tabMain.Controls.Add(this.tabReport);
            this.tabMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabMain.Location = new System.Drawing.Point(3, 67);
            this.tabMain.Name = "tabMain";
            this.tabMain.SelectedIndex = 0;
            this.tabMain.Size = new System.Drawing.Size(1174, 587);
            this.tabMain.TabIndex = 1;
            // 
            // tabCharts
            // 
            this.tabCharts.BackColor = System.Drawing.Color.White;
            this.tabCharts.Controls.Add(this.tlpChartsRoot);
            this.tabCharts.Location = new System.Drawing.Point(4, 27);
            this.tabCharts.Name = "tabCharts";
            this.tabCharts.Padding = new System.Windows.Forms.Padding(3);
            this.tabCharts.Size = new System.Drawing.Size(1166, 556);
            this.tabCharts.TabIndex = 0;
            this.tabCharts.Text = "CHARTS";
            // 
            // tlpChartsRoot
            // 
            this.tlpChartsRoot.ColumnCount = 1;
            this.tlpChartsRoot.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpChartsRoot.Controls.Add(this.pnlChartsTop, 0, 0);
            this.tlpChartsRoot.Controls.Add(this.tlpCharts, 0, 1);
            this.tlpChartsRoot.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpChartsRoot.Location = new System.Drawing.Point(3, 3);
            this.tlpChartsRoot.Name = "tlpChartsRoot";
            this.tlpChartsRoot.Padding = new System.Windows.Forms.Padding(10);
            this.tlpChartsRoot.RowCount = 2;
            this.tlpChartsRoot.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 170F));
            this.tlpChartsRoot.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpChartsRoot.Size = new System.Drawing.Size(1160, 550);
            this.tlpChartsRoot.TabIndex = 0;
            // 
            // pnlChartsTop
            // 
            this.pnlChartsTop.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlChartsTop.Controls.Add(this.tlpKpis);
            this.pnlChartsTop.Controls.Add(this.pnlFilters);
            this.pnlChartsTop.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlChartsTop.Location = new System.Drawing.Point(13, 13);
            this.pnlChartsTop.Name = "pnlChartsTop";
            this.pnlChartsTop.Padding = new System.Windows.Forms.Padding(10);
            this.pnlChartsTop.Size = new System.Drawing.Size(1134, 164);
            this.pnlChartsTop.TabIndex = 0;
            // 
            // tlpKpis
            // 
            this.tlpKpis.ColumnCount = 4;
            this.tlpKpis.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpKpis.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpKpis.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpKpis.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpKpis.Controls.Add(this.pnlKpiAttemptsCard, 0, 0);
            this.tlpKpis.Controls.Add(this.pnlKpiAccuracyCard, 1, 0);
            this.tlpKpis.Controls.Add(this.pnlKpiAvgTimeCard, 2, 0);
            this.tlpKpis.Controls.Add(this.pnlKpiStreakCard, 3, 0);
            this.tlpKpis.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpKpis.Location = new System.Drawing.Point(10, 80);
            this.tlpKpis.Margin = new System.Windows.Forms.Padding(0, 8, 0, 0);
            this.tlpKpis.Name = "tlpKpis";
            this.tlpKpis.RowCount = 1;
            this.tlpKpis.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpKpis.Size = new System.Drawing.Size(1112, 72);
            this.tlpKpis.TabIndex = 1;
            // 
            // pnlKpiAttemptsCard
            // 
            this.pnlKpiAttemptsCard.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlKpiAttemptsCard.Controls.Add(this.lblKpiAttemptsValue);
            this.pnlKpiAttemptsCard.Controls.Add(this.lblKpiAttemptTitle);
            this.pnlKpiAttemptsCard.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlKpiAttemptsCard.Location = new System.Drawing.Point(6, 6);
            this.pnlKpiAttemptsCard.Margin = new System.Windows.Forms.Padding(6);
            this.pnlKpiAttemptsCard.Name = "pnlKpiAttemptsCard";
            this.pnlKpiAttemptsCard.Size = new System.Drawing.Size(266, 60);
            this.pnlKpiAttemptsCard.TabIndex = 0;
            // 
            // lblKpiAttemptsValue
            // 
            this.lblKpiAttemptsValue.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblKpiAttemptsValue.AutoSize = true;
            this.lblKpiAttemptsValue.Font = new System.Drawing.Font("Muro", 18F);
            this.lblKpiAttemptsValue.Location = new System.Drawing.Point(202, 4);
            this.lblKpiAttemptsValue.Name = "lblKpiAttemptsValue";
            this.lblKpiAttemptsValue.Padding = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.lblKpiAttemptsValue.Size = new System.Drawing.Size(46, 41);
            this.lblKpiAttemptsValue.TabIndex = 1;
            this.lblKpiAttemptsValue.Text = "12";
            // 
            // lblKpiAttemptTitle
            // 
            this.lblKpiAttemptTitle.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblKpiAttemptTitle.Font = new System.Drawing.Font("Agency", 11F);
            this.lblKpiAttemptTitle.Location = new System.Drawing.Point(12, 24);
            this.lblKpiAttemptTitle.Name = "lblKpiAttemptTitle";
            this.lblKpiAttemptTitle.Size = new System.Drawing.Size(500, 17);
            this.lblKpiAttemptTitle.TabIndex = 0;
            this.lblKpiAttemptTitle.Text = "Attempts: ";
            // 
            // pnlKpiAccuracyCard
            // 
            this.pnlKpiAccuracyCard.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlKpiAccuracyCard.Controls.Add(this.lblKpiAccuracyValue);
            this.pnlKpiAccuracyCard.Controls.Add(this.lblKpiAccuracyTitle);
            this.pnlKpiAccuracyCard.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlKpiAccuracyCard.Location = new System.Drawing.Point(284, 6);
            this.pnlKpiAccuracyCard.Margin = new System.Windows.Forms.Padding(6);
            this.pnlKpiAccuracyCard.Name = "pnlKpiAccuracyCard";
            this.pnlKpiAccuracyCard.Size = new System.Drawing.Size(266, 60);
            this.pnlKpiAccuracyCard.TabIndex = 1;
            // 
            // lblKpiAccuracyValue
            // 
            this.lblKpiAccuracyValue.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblKpiAccuracyValue.AutoSize = true;
            this.lblKpiAccuracyValue.Font = new System.Drawing.Font("Muro", 18F);
            this.lblKpiAccuracyValue.Location = new System.Drawing.Point(171, 9);
            this.lblKpiAccuracyValue.Name = "lblKpiAccuracyValue";
            this.lblKpiAccuracyValue.Size = new System.Drawing.Size(80, 36);
            this.lblKpiAccuracyValue.TabIndex = 1;
            this.lblKpiAccuracyValue.Text = "58%";
            // 
            // lblKpiAccuracyTitle
            // 
            this.lblKpiAccuracyTitle.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblKpiAccuracyTitle.Font = new System.Drawing.Font("Agency", 11F);
            this.lblKpiAccuracyTitle.Location = new System.Drawing.Point(19, 24);
            this.lblKpiAccuracyTitle.Name = "lblKpiAccuracyTitle";
            this.lblKpiAccuracyTitle.Size = new System.Drawing.Size(132, 17);
            this.lblKpiAccuracyTitle.TabIndex = 0;
            this.lblKpiAccuracyTitle.Text = "Accuracy: ";
            // 
            // pnlKpiAvgTimeCard
            // 
            this.pnlKpiAvgTimeCard.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlKpiAvgTimeCard.Controls.Add(this.lblKpiAvgTimeValue);
            this.pnlKpiAvgTimeCard.Controls.Add(this.lblKpiAvgTimeTitle);
            this.pnlKpiAvgTimeCard.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlKpiAvgTimeCard.Location = new System.Drawing.Point(562, 6);
            this.pnlKpiAvgTimeCard.Margin = new System.Windows.Forms.Padding(6);
            this.pnlKpiAvgTimeCard.Name = "pnlKpiAvgTimeCard";
            this.pnlKpiAvgTimeCard.Size = new System.Drawing.Size(266, 60);
            this.pnlKpiAvgTimeCard.TabIndex = 2;
            // 
            // lblKpiAvgTimeValue
            // 
            this.lblKpiAvgTimeValue.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblKpiAvgTimeValue.AutoSize = true;
            this.lblKpiAvgTimeValue.Font = new System.Drawing.Font("Muro", 18F);
            this.lblKpiAvgTimeValue.Location = new System.Drawing.Point(173, 9);
            this.lblKpiAvgTimeValue.Name = "lblKpiAvgTimeValue";
            this.lblKpiAvgTimeValue.Size = new System.Drawing.Size(76, 36);
            this.lblKpiAvgTimeValue.TabIndex = 1;
            this.lblKpiAvgTimeValue.Text = "2.3s";
            // 
            // lblKpiAvgTimeTitle
            // 
            this.lblKpiAvgTimeTitle.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblKpiAvgTimeTitle.Font = new System.Drawing.Font("Agency", 11F);
            this.lblKpiAvgTimeTitle.Location = new System.Drawing.Point(19, 24);
            this.lblKpiAvgTimeTitle.Name = "lblKpiAvgTimeTitle";
            this.lblKpiAvgTimeTitle.Size = new System.Drawing.Size(115, 17);
            this.lblKpiAvgTimeTitle.TabIndex = 0;
            this.lblKpiAvgTimeTitle.Text = "Avg Time: ";
            // 
            // pnlKpiStreakCard
            // 
            this.pnlKpiStreakCard.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlKpiStreakCard.Controls.Add(this.lblKpiStreakValue);
            this.pnlKpiStreakCard.Controls.Add(this.lblKpiStreakTitle);
            this.pnlKpiStreakCard.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlKpiStreakCard.Location = new System.Drawing.Point(840, 6);
            this.pnlKpiStreakCard.Margin = new System.Windows.Forms.Padding(6);
            this.pnlKpiStreakCard.Name = "pnlKpiStreakCard";
            this.pnlKpiStreakCard.Size = new System.Drawing.Size(266, 60);
            this.pnlKpiStreakCard.TabIndex = 3;
            // 
            // lblKpiStreakValue
            // 
            this.lblKpiStreakValue.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblKpiStreakValue.AutoSize = true;
            this.lblKpiStreakValue.Font = new System.Drawing.Font("Muro", 18F);
            this.lblKpiStreakValue.Location = new System.Drawing.Point(209, 9);
            this.lblKpiStreakValue.Name = "lblKpiStreakValue";
            this.lblKpiStreakValue.Size = new System.Drawing.Size(33, 36);
            this.lblKpiStreakValue.TabIndex = 1;
            this.lblKpiStreakValue.Text = "5";
            // 
            // lblKpiStreakTitle
            // 
            this.lblKpiStreakTitle.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblKpiStreakTitle.Font = new System.Drawing.Font("Agency", 11F);
            this.lblKpiStreakTitle.Location = new System.Drawing.Point(25, 24);
            this.lblKpiStreakTitle.Name = "lblKpiStreakTitle";
            this.lblKpiStreakTitle.Size = new System.Drawing.Size(97, 17);
            this.lblKpiStreakTitle.TabIndex = 0;
            this.lblKpiStreakTitle.Text = "Streak: ";
            // 
            // pnlFilters
            // 
            this.pnlFilters.Controls.Add(this.lblGroupBy);
            this.pnlFilters.Controls.Add(this.lblXAxis);
            this.pnlFilters.Controls.Add(this.lblMetric);
            this.pnlFilters.Controls.Add(this.lblDifficulty);
            this.pnlFilters.Controls.Add(this.lblTopic);
            this.pnlFilters.Controls.Add(this.lblRange);
            this.pnlFilters.Controls.Add(this.cmbGroupBy);
            this.pnlFilters.Controls.Add(this.cmbXAxis);
            this.pnlFilters.Controls.Add(this.cmbMetric);
            this.pnlFilters.Controls.Add(this.btnRefreshCharts);
            this.pnlFilters.Controls.Add(this.cmbDifficulty);
            this.pnlFilters.Controls.Add(this.cmbTopic);
            this.pnlFilters.Controls.Add(this.cmbRange);
            this.pnlFilters.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlFilters.Location = new System.Drawing.Point(10, 10);
            this.pnlFilters.Name = "pnlFilters";
            this.pnlFilters.Size = new System.Drawing.Size(1112, 70);
            this.pnlFilters.TabIndex = 0;
            // 
            // cmbGroupBy
            // 
            this.cmbGroupBy.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbGroupBy.FormattingEnabled = true;
            this.cmbGroupBy.Items.AddRange(new object[] {
            "None",
            "By Topic",
            "By Difficulty",
            "By Week"});
            this.cmbGroupBy.Location = new System.Drawing.Point(793, 33);
            this.cmbGroupBy.Name = "cmbGroupBy";
            this.cmbGroupBy.Size = new System.Drawing.Size(121, 26);
            this.cmbGroupBy.TabIndex = 6;
            // 
            // cmbXAxis
            // 
            this.cmbXAxis.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbXAxis.FormattingEnabled = true;
            this.cmbXAxis.Items.AddRange(new object[] {
            "Attempt # (in range)",
            "Date",
            "Question difficulty",
            "Topic"});
            this.cmbXAxis.Location = new System.Drawing.Point(654, 33);
            this.cmbXAxis.Name = "cmbXAxis";
            this.cmbXAxis.Size = new System.Drawing.Size(121, 26);
            this.cmbXAxis.TabIndex = 5;
            // 
            // cmbMetric
            // 
            this.cmbMetric.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMetric.FormattingEnabled = true;
            this.cmbMetric.Items.AddRange(new object[] {
            "Accuracy",
            "Avg Time (s)",
            "Attempts per day",
            "Streak trend",
            "Topic mastery %",
            "Mistakes by tag"});
            this.cmbMetric.Location = new System.Drawing.Point(516, 33);
            this.cmbMetric.Name = "cmbMetric";
            this.cmbMetric.Size = new System.Drawing.Size(121, 26);
            this.cmbMetric.TabIndex = 4;
            // 
            // btnRefreshCharts
            // 
            this.btnRefreshCharts.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRefreshCharts.BackColor = System.Drawing.Color.RoyalBlue;
            this.btnRefreshCharts.Font = new System.Drawing.Font("Muro", 12F);
            this.btnRefreshCharts.ForeColor = System.Drawing.Color.White;
            this.btnRefreshCharts.Location = new System.Drawing.Point(933, 0);
            this.btnRefreshCharts.Name = "btnRefreshCharts";
            this.btnRefreshCharts.Size = new System.Drawing.Size(179, 44);
            this.btnRefreshCharts.Style.BackColor = System.Drawing.Color.RoyalBlue;
            this.btnRefreshCharts.Style.ForeColor = System.Drawing.Color.White;
            this.btnRefreshCharts.TabIndex = 3;
            this.btnRefreshCharts.Text = "REFRESH";
            this.btnRefreshCharts.UseVisualStyleBackColor = false;
            // 
            // cmbDifficulty
            // 
            this.cmbDifficulty.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDifficulty.FormattingEnabled = true;
            this.cmbDifficulty.Items.AddRange(new object[] {
            "ALL",
            "Easy",
            "Medium",
            "Hard"});
            this.cmbDifficulty.Location = new System.Drawing.Point(348, 33);
            this.cmbDifficulty.Name = "cmbDifficulty";
            this.cmbDifficulty.Size = new System.Drawing.Size(150, 26);
            this.cmbDifficulty.TabIndex = 2;
            // 
            // cmbTopic
            // 
            this.cmbTopic.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTopic.FormattingEnabled = true;
            this.cmbTopic.Items.AddRange(new object[] {
            "ALL"});
            this.cmbTopic.Location = new System.Drawing.Point(153, 33);
            this.cmbTopic.Name = "cmbTopic";
            this.cmbTopic.Size = new System.Drawing.Size(180, 26);
            this.cmbTopic.TabIndex = 1;
            // 
            // cmbRange
            // 
            this.cmbRange.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbRange.FormattingEnabled = true;
            this.cmbRange.Items.AddRange(new object[] {
            "7 Days",
            "30 Days",
            "90 Days",
            "ALL"});
            this.cmbRange.Location = new System.Drawing.Point(20, 33);
            this.cmbRange.Name = "cmbRange";
            this.cmbRange.Size = new System.Drawing.Size(120, 26);
            this.cmbRange.TabIndex = 0;
            // 
            // tlpCharts
            // 
            this.tlpCharts.ColumnCount = 1;
            this.tlpCharts.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpCharts.Controls.Add(this.pnlChartHeader, 0, 0);
            this.tlpCharts.Controls.Add(this.pnlChartHost, 0, 1);
            this.tlpCharts.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpCharts.Location = new System.Drawing.Point(10, 180);
            this.tlpCharts.Margin = new System.Windows.Forms.Padding(0);
            this.tlpCharts.Name = "tlpCharts";
            this.tlpCharts.Padding = new System.Windows.Forms.Padding(8);
            this.tlpCharts.RowCount = 2;
            this.tlpCharts.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 44F));
            this.tlpCharts.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpCharts.Size = new System.Drawing.Size(1140, 360);
            this.tlpCharts.TabIndex = 1;
            // 
            // pnlChartHeader
            // 
            this.pnlChartHeader.Controls.Add(this.btnResetChart);
            this.pnlChartHeader.Controls.Add(this.btnExportChartPng);
            this.pnlChartHeader.Controls.Add(this.lblChartSubtitle);
            this.pnlChartHeader.Controls.Add(this.lblChartTitle);
            this.pnlChartHeader.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlChartHeader.Location = new System.Drawing.Point(11, 11);
            this.pnlChartHeader.Name = "pnlChartHeader";
            this.pnlChartHeader.Padding = new System.Windows.Forms.Padding(6);
            this.pnlChartHeader.Size = new System.Drawing.Size(1118, 38);
            this.pnlChartHeader.TabIndex = 0;
            // 
            // btnResetChart
            // 
            this.btnResetChart.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnResetChart.BackColor = System.Drawing.Color.Red;
            this.btnResetChart.Font = new System.Drawing.Font("Muro", 12F);
            this.btnResetChart.ForeColor = System.Drawing.SystemColors.Window;
            this.btnResetChart.Location = new System.Drawing.Point(998, 0);
            this.btnResetChart.Name = "btnResetChart";
            this.btnResetChart.Size = new System.Drawing.Size(120, 38);
            this.btnResetChart.Style.BackColor = System.Drawing.Color.Red;
            this.btnResetChart.Style.ForeColor = System.Drawing.SystemColors.Window;
            this.btnResetChart.TabIndex = 3;
            this.btnResetChart.Text = "RESET";
            this.btnResetChart.UseVisualStyleBackColor = false;
            // 
            // btnExportChartPng
            // 
            this.btnExportChartPng.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExportChartPng.BackColor = System.Drawing.Color.SeaGreen;
            this.btnExportChartPng.Font = new System.Drawing.Font("Muro", 12F);
            this.btnExportChartPng.ForeColor = System.Drawing.Color.White;
            this.btnExportChartPng.Location = new System.Drawing.Point(872, 0);
            this.btnExportChartPng.Name = "btnExportChartPng";
            this.btnExportChartPng.Size = new System.Drawing.Size(120, 38);
            this.btnExportChartPng.Style.BackColor = System.Drawing.Color.SeaGreen;
            this.btnExportChartPng.Style.ForeColor = System.Drawing.Color.White;
            this.btnExportChartPng.TabIndex = 2;
            this.btnExportChartPng.Text = "EXPORT";
            this.btnExportChartPng.UseVisualStyleBackColor = false;
            // 
            // lblChartSubtitle
            // 
            this.lblChartSubtitle.AutoSize = true;
            this.lblChartSubtitle.Location = new System.Drawing.Point(275, 10);
            this.lblChartSubtitle.Name = "lblChartSubtitle";
            this.lblChartSubtitle.Size = new System.Drawing.Size(592, 18);
            this.lblChartSubtitle.TabIndex = 1;
            this.lblChartSubtitle.Text = "Showing last 30 attempts - Grouped by attempt";
            // 
            // lblChartTitle
            // 
            this.lblChartTitle.AutoSize = true;
            this.lblChartTitle.Font = new System.Drawing.Font("Muro", 16F);
            this.lblChartTitle.Location = new System.Drawing.Point(0, 0);
            this.lblChartTitle.Name = "lblChartTitle";
            this.lblChartTitle.Size = new System.Drawing.Size(258, 32);
            this.lblChartTitle.TabIndex = 0;
            this.lblChartTitle.Text = "ACCURACY (TREND)";
            // 
            // pnlChartHost
            // 
            this.pnlChartHost.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlChartHost.Controls.Add(this.chartMain);
            this.pnlChartHost.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlChartHost.Location = new System.Drawing.Point(11, 55);
            this.pnlChartHost.Name = "pnlChartHost";
            this.pnlChartHost.Padding = new System.Windows.Forms.Padding(8);
            this.pnlChartHost.Size = new System.Drawing.Size(1118, 294);
            this.pnlChartHost.TabIndex = 1;
            // 
            // chartMain
            // 
            this.chartMain.ChartArea.CursorLocation = new System.Drawing.Point(0, 0);
            this.chartMain.ChartArea.CursorReDraw = false;
            this.chartMain.DataSourceName = "[none]";
            this.chartMain.Dock = System.Windows.Forms.DockStyle.Fill;
            // 
            // 
            // 
            this.chartMain.Legend.Location = new System.Drawing.Point(967, 87);
            this.chartMain.Location = new System.Drawing.Point(8, 8);
            this.chartMain.Name = "chartMain";
            this.chartMain.PrimaryXAxis.LogLabelsDisplayMode = Syncfusion.Windows.Forms.Chart.LogLabelsDisplayMode.Default;
            this.chartMain.PrimaryXAxis.Margin = true;
            this.chartMain.PrimaryYAxis.LogLabelsDisplayMode = Syncfusion.Windows.Forms.Chart.LogLabelsDisplayMode.Default;
            this.chartMain.PrimaryYAxis.Margin = true;
            this.chartMain.Size = new System.Drawing.Size(1100, 276);
            this.chartMain.TabIndex = 0;
            this.chartMain.Text = "chartControl1";
            // 
            // 
            // 
            this.chartMain.Title.Name = "Default";
            this.chartMain.Titles.Add(this.chartMain.Title);
            // 
            // tabReport
            // 
            this.tabReport.BackColor = System.Drawing.Color.White;
            this.tabReport.Controls.Add(this.splitReports);
            this.tabReport.Location = new System.Drawing.Point(4, 27);
            this.tabReport.Name = "tabReport";
            this.tabReport.Padding = new System.Windows.Forms.Padding(3);
            this.tabReport.Size = new System.Drawing.Size(1166, 556);
            this.tabReport.TabIndex = 1;
            this.tabReport.Text = "REPORTS";
            // 
            // lblRange
            // 
            this.lblRange.AutoSize = true;
            this.lblRange.ForeColor = System.Drawing.Color.DimGray;
            this.lblRange.Location = new System.Drawing.Point(36, 10);
            this.lblRange.Name = "lblRange";
            this.lblRange.Size = new System.Drawing.Size(86, 18);
            this.lblRange.TabIndex = 7;
            this.lblRange.Text = "RANGE";
            // 
            // lblTopic
            // 
            this.lblTopic.AutoSize = true;
            this.lblTopic.ForeColor = System.Drawing.Color.DimGray;
            this.lblTopic.Location = new System.Drawing.Point(202, 10);
            this.lblTopic.Name = "lblTopic";
            this.lblTopic.Size = new System.Drawing.Size(74, 18);
            this.lblTopic.TabIndex = 8;
            this.lblTopic.Text = "TOPIC";
            // 
            // lblDifficulty
            // 
            this.lblDifficulty.AutoSize = true;
            this.lblDifficulty.ForeColor = System.Drawing.Color.DimGray;
            this.lblDifficulty.Location = new System.Drawing.Point(353, 10);
            this.lblDifficulty.Name = "lblDifficulty";
            this.lblDifficulty.Size = new System.Drawing.Size(136, 18);
            this.lblDifficulty.TabIndex = 9;
            this.lblDifficulty.Text = "Difficulty";
            // 
            // lblMetric
            // 
            this.lblMetric.AutoSize = true;
            this.lblMetric.ForeColor = System.Drawing.Color.DimGray;
            this.lblMetric.Location = new System.Drawing.Point(532, 10);
            this.lblMetric.Name = "lblMetric";
            this.lblMetric.Size = new System.Drawing.Size(92, 18);
            this.lblMetric.TabIndex = 10;
            this.lblMetric.Text = "Metric";
            // 
            // lblXAxis
            // 
            this.lblXAxis.AutoSize = true;
            this.lblXAxis.ForeColor = System.Drawing.Color.DimGray;
            this.lblXAxis.Location = new System.Drawing.Point(678, 10);
            this.lblXAxis.Name = "lblXAxis";
            this.lblXAxis.Size = new System.Drawing.Size(79, 18);
            this.lblXAxis.TabIndex = 11;
            this.lblXAxis.Text = "X Axis";
            // 
            // lblGroupBy
            // 
            this.lblGroupBy.AutoSize = true;
            this.lblGroupBy.ForeColor = System.Drawing.Color.DimGray;
            this.lblGroupBy.Location = new System.Drawing.Point(792, 10);
            this.lblGroupBy.Name = "lblGroupBy";
            this.lblGroupBy.Size = new System.Drawing.Size(122, 18);
            this.lblGroupBy.TabIndex = 12;
            this.lblGroupBy.Text = "Group By";
            // 
            // splitReports
            // 
            this.splitReports.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitReports.Location = new System.Drawing.Point(3, 3);
            this.splitReports.Name = "splitReports";
            // 
            // splitReports.Panel1
            // 
            this.splitReports.Panel1.Controls.Add(this.lvReports);
            this.splitReports.Panel1.Controls.Add(this.pnlReportLeftTop);
            this.splitReports.Panel1.Padding = new System.Windows.Forms.Padding(10);
            // 
            // splitReports.Panel2
            // 
            this.splitReports.Panel2.Controls.Add(this.wPdf);
            this.splitReports.Panel2.Controls.Add(this.pnlReportRightTop);
            this.splitReports.Size = new System.Drawing.Size(1160, 550);
            this.splitReports.SplitterDistance = 320;
            this.splitReports.TabIndex = 0;
            // 
            // pnlReportLeftTop
            // 
            this.pnlReportLeftTop.Controls.Add(this.btnGenerateReport);
            this.pnlReportLeftTop.Controls.Add(this.lblReportsTitle);
            this.pnlReportLeftTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlReportLeftTop.Location = new System.Drawing.Point(10, 10);
            this.pnlReportLeftTop.Name = "pnlReportLeftTop";
            this.pnlReportLeftTop.Padding = new System.Windows.Forms.Padding(10);
            this.pnlReportLeftTop.Size = new System.Drawing.Size(300, 120);
            this.pnlReportLeftTop.TabIndex = 0;
            // 
            // lblReportsTitle
            // 
            this.lblReportsTitle.AutoSize = true;
            this.lblReportsTitle.Font = new System.Drawing.Font("Muro", 16F);
            this.lblReportsTitle.Location = new System.Drawing.Point(4, 0);
            this.lblReportsTitle.Name = "lblReportsTitle";
            this.lblReportsTitle.Size = new System.Drawing.Size(120, 32);
            this.lblReportsTitle.TabIndex = 0;
            this.lblReportsTitle.Text = "REPORTS";
            // 
            // btnGenerateReport
            // 
            this.btnGenerateReport.BackColor = System.Drawing.Color.RoyalBlue;
            this.btnGenerateReport.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnGenerateReport.Font = new System.Drawing.Font("Muro", 14F);
            this.btnGenerateReport.ForeColor = System.Drawing.Color.White;
            this.btnGenerateReport.Location = new System.Drawing.Point(10, 66);
            this.btnGenerateReport.Name = "btnGenerateReport";
            this.btnGenerateReport.Size = new System.Drawing.Size(280, 44);
            this.btnGenerateReport.Style.BackColor = System.Drawing.Color.RoyalBlue;
            this.btnGenerateReport.Style.ForeColor = System.Drawing.Color.White;
            this.btnGenerateReport.TabIndex = 1;
            this.btnGenerateReport.Text = "GENERATE NEW REPORT";
            this.btnGenerateReport.UseVisualStyleBackColor = false;
            // 
            // lvReports
            // 
            this.lvReports.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.clmReport,
            this.clmDate});
            this.lvReports.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvReports.FullRowSelect = true;
            this.lvReports.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lvReports.HideSelection = false;
            this.lvReports.Location = new System.Drawing.Point(10, 130);
            this.lvReports.MultiSelect = false;
            this.lvReports.Name = "lvReports";
            this.lvReports.Size = new System.Drawing.Size(300, 410);
            this.lvReports.TabIndex = 2;
            this.lvReports.UseCompatibleStateImageBehavior = false;
            this.lvReports.View = System.Windows.Forms.View.Details;
            // 
            // clmReport
            // 
            this.clmReport.Text = "REPORT";
            this.clmReport.Width = 200;
            // 
            // clmDate
            // 
            this.clmDate.Text = "DATE";
            this.clmDate.Width = 90;
            // 
            // pnlReportRightTop
            // 
            this.pnlReportRightTop.Controls.Add(this.tlpReportActions);
            this.pnlReportRightTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlReportRightTop.Location = new System.Drawing.Point(0, 0);
            this.pnlReportRightTop.Name = "pnlReportRightTop";
            this.pnlReportRightTop.Padding = new System.Windows.Forms.Padding(10);
            this.pnlReportRightTop.Size = new System.Drawing.Size(836, 60);
            this.pnlReportRightTop.TabIndex = 0;
            // 
            // tlpReportActions
            // 
            this.tlpReportActions.ColumnCount = 3;
            this.tlpReportActions.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpReportActions.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 130F));
            this.tlpReportActions.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 130F));
            this.tlpReportActions.Controls.Add(this.lblSelectedReport, 0, 0);
            this.tlpReportActions.Controls.Add(this.btnDownloadPdf, 1, 0);
            this.tlpReportActions.Controls.Add(this.btnOpenExternal, 2, 0);
            this.tlpReportActions.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpReportActions.Location = new System.Drawing.Point(10, 10);
            this.tlpReportActions.Name = "tlpReportActions";
            this.tlpReportActions.RowCount = 1;
            this.tlpReportActions.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpReportActions.Size = new System.Drawing.Size(816, 40);
            this.tlpReportActions.TabIndex = 0;
            // 
            // lblSelectedReport
            // 
            this.lblSelectedReport.AutoSize = true;
            this.lblSelectedReport.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblSelectedReport.Font = new System.Drawing.Font("Agency", 14F, System.Drawing.FontStyle.Bold);
            this.lblSelectedReport.Location = new System.Drawing.Point(3, 0);
            this.lblSelectedReport.Name = "lblSelectedReport";
            this.lblSelectedReport.Size = new System.Drawing.Size(550, 40);
            this.lblSelectedReport.TabIndex = 0;
            this.lblSelectedReport.Text = "No report selected";
            this.lblSelectedReport.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnDownloadPdf
            // 
            this.btnDownloadPdf.BackColor = System.Drawing.Color.ForestGreen;
            this.btnDownloadPdf.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnDownloadPdf.Font = new System.Drawing.Font("Muro", 11F);
            this.btnDownloadPdf.ForeColor = System.Drawing.Color.White;
            this.btnDownloadPdf.Location = new System.Drawing.Point(559, 3);
            this.btnDownloadPdf.Name = "btnDownloadPdf";
            this.btnDownloadPdf.Size = new System.Drawing.Size(124, 34);
            this.btnDownloadPdf.Style.BackColor = System.Drawing.Color.ForestGreen;
            this.btnDownloadPdf.Style.ForeColor = System.Drawing.Color.White;
            this.btnDownloadPdf.TabIndex = 1;
            this.btnDownloadPdf.Text = "DOWNLOAD";
            this.btnDownloadPdf.UseVisualStyleBackColor = false;
            // 
            // btnOpenExternal
            // 
            this.btnOpenExternal.BackColor = System.Drawing.Color.SlateGray;
            this.btnOpenExternal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnOpenExternal.Font = new System.Drawing.Font("Muro", 11F);
            this.btnOpenExternal.ForeColor = System.Drawing.Color.White;
            this.btnOpenExternal.Location = new System.Drawing.Point(689, 3);
            this.btnOpenExternal.Name = "btnOpenExternal";
            this.btnOpenExternal.Size = new System.Drawing.Size(124, 34);
            this.btnOpenExternal.Style.BackColor = System.Drawing.Color.SlateGray;
            this.btnOpenExternal.Style.ForeColor = System.Drawing.Color.White;
            this.btnOpenExternal.TabIndex = 2;
            this.btnOpenExternal.Text = "OPEN";
            this.btnOpenExternal.UseVisualStyleBackColor = false;
            // 
            // wPdf
            // 
            this.wPdf.Dock = System.Windows.Forms.DockStyle.Fill;
            this.wPdf.Location = new System.Drawing.Point(0, 60);
            this.wPdf.MinimumSize = new System.Drawing.Size(20, 20);
            this.wPdf.Name = "wPdf";
            this.wPdf.Size = new System.Drawing.Size(836, 490);
            this.wPdf.TabIndex = 1;
            // 
            // ReportsAndChartsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(15F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1184, 661);
            this.Controls.Add(this.tlpRoot);
            this.Font = new System.Drawing.Font("Agency", 12F);
            this.Margin = new System.Windows.Forms.Padding(5, 3, 5, 3);
            this.MinimumSize = new System.Drawing.Size(1100, 650);
            this.Name = "ReportsAndChartsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Style.MdiChild.IconHorizontalAlignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.Style.MdiChild.IconVerticalAlignment = System.Windows.Forms.VisualStyles.VerticalAlignment.Center;
            this.Text = "Reports & Charts - Mondas";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.ReportsAndChartsForm_Load);
            this.tlpRoot.ResumeLayout(false);
            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            this.tabMain.ResumeLayout(false);
            this.tabCharts.ResumeLayout(false);
            this.tlpChartsRoot.ResumeLayout(false);
            this.pnlChartsTop.ResumeLayout(false);
            this.tlpKpis.ResumeLayout(false);
            this.pnlKpiAttemptsCard.ResumeLayout(false);
            this.pnlKpiAttemptsCard.PerformLayout();
            this.pnlKpiAccuracyCard.ResumeLayout(false);
            this.pnlKpiAccuracyCard.PerformLayout();
            this.pnlKpiAvgTimeCard.ResumeLayout(false);
            this.pnlKpiAvgTimeCard.PerformLayout();
            this.pnlKpiStreakCard.ResumeLayout(false);
            this.pnlKpiStreakCard.PerformLayout();
            this.pnlFilters.ResumeLayout(false);
            this.pnlFilters.PerformLayout();
            this.tlpCharts.ResumeLayout(false);
            this.pnlChartHeader.ResumeLayout(false);
            this.pnlChartHeader.PerformLayout();
            this.pnlChartHost.ResumeLayout(false);
            this.tabReport.ResumeLayout(false);
            this.splitReports.Panel1.ResumeLayout(false);
            this.splitReports.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitReports)).EndInit();
            this.splitReports.ResumeLayout(false);
            this.pnlReportLeftTop.ResumeLayout(false);
            this.pnlReportLeftTop.PerformLayout();
            this.pnlReportRightTop.ResumeLayout(false);
            this.tlpReportActions.ResumeLayout(false);
            this.tlpReportActions.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tlpRoot;
        private System.Windows.Forms.Panel pnlTop;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.Label lblUser;
        private System.Windows.Forms.TabControl tabMain;
        private System.Windows.Forms.TabPage tabCharts;
        private System.Windows.Forms.TabPage tabReport;
        private System.Windows.Forms.TableLayoutPanel tlpChartsRoot;
        private System.Windows.Forms.Panel pnlChartsTop;
        private System.Windows.Forms.TableLayoutPanel tlpKpis;
        private System.Windows.Forms.Panel pnlKpiAttemptsCard;
        private System.Windows.Forms.Label lblKpiAttemptsValue;
        private System.Windows.Forms.Label lblKpiAttemptTitle;
        private System.Windows.Forms.Panel pnlKpiAccuracyCard;
        private System.Windows.Forms.Label lblKpiAccuracyValue;
        private System.Windows.Forms.Label lblKpiAccuracyTitle;
        private System.Windows.Forms.Panel pnlKpiAvgTimeCard;
        private System.Windows.Forms.Label lblKpiAvgTimeValue;
        private System.Windows.Forms.Label lblKpiAvgTimeTitle;
        private System.Windows.Forms.Panel pnlKpiStreakCard;
        private System.Windows.Forms.Label lblKpiStreakValue;
        private System.Windows.Forms.Label lblKpiStreakTitle;
        private System.Windows.Forms.Panel pnlFilters;
        private Syncfusion.WinForms.Controls.SfButton btnRefreshCharts;
        private System.Windows.Forms.ComboBox cmbDifficulty;
        private System.Windows.Forms.ComboBox cmbTopic;
        private System.Windows.Forms.ComboBox cmbRange;
        private System.Windows.Forms.TableLayoutPanel tlpCharts;
        private System.Windows.Forms.Panel pnlChartHeader;
        private System.Windows.Forms.Label lblChartTitle;
        private System.Windows.Forms.Label lblChartSubtitle;
        private Syncfusion.WinForms.Controls.SfButton btnExportChartPng;
        private Syncfusion.WinForms.Controls.SfButton btnResetChart;
        private System.Windows.Forms.Panel pnlChartHost;
        private Syncfusion.Windows.Forms.Chart.ChartControl chartMain;
        private System.Windows.Forms.ComboBox cmbMetric;
        private System.Windows.Forms.ComboBox cmbXAxis;
        private System.Windows.Forms.ComboBox cmbGroupBy;
        private System.Windows.Forms.Label lblRange;
        private System.Windows.Forms.Label lblDifficulty;
        private System.Windows.Forms.Label lblTopic;
        private System.Windows.Forms.Label lblMetric;
        private System.Windows.Forms.Label lblXAxis;
        private System.Windows.Forms.Label lblGroupBy;
        private System.Windows.Forms.SplitContainer splitReports;
        private System.Windows.Forms.Panel pnlReportLeftTop;
        private System.Windows.Forms.Label lblReportsTitle;
        private Syncfusion.WinForms.Controls.SfButton btnGenerateReport;
        private System.Windows.Forms.ListView lvReports;
        private System.Windows.Forms.ColumnHeader clmReport;
        private System.Windows.Forms.ColumnHeader clmDate;
        private System.Windows.Forms.Panel pnlReportRightTop;
        private System.Windows.Forms.TableLayoutPanel tlpReportActions;
        private System.Windows.Forms.Label lblSelectedReport;
        private Syncfusion.WinForms.Controls.SfButton btnDownloadPdf;
        private Syncfusion.WinForms.Controls.SfButton btnOpenExternal;
        private System.Windows.Forms.WebBrowser wPdf;
    }
}