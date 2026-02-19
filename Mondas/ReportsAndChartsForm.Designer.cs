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
            this.pnlKpiStreakCard = new System.Windows.Forms.Panel();
            this.pnlFilters = new System.Windows.Forms.Panel();
            this.btnRefreshCharts = new Syncfusion.WinForms.Controls.SfButton();
            this.cmdDifficulty = new System.Windows.Forms.ComboBox();
            this.cmbTopic = new System.Windows.Forms.ComboBox();
            this.cmbRange = new System.Windows.Forms.ComboBox();
            this.tabReport = new System.Windows.Forms.TabPage();
            this.lblKpiAvgTimeTitle = new System.Windows.Forms.Label();
            this.lblKpiAvgTimeValue = new System.Windows.Forms.Label();
            this.lblKpiStreakTitle = new System.Windows.Forms.Label();
            this.lblKpiStreakValue = new System.Windows.Forms.Label();
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
            this.btnLogout.BackColor = System.Drawing.Color.White;
            this.btnLogout.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.btnLogout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogout.Font = new System.Drawing.Font("Agency", 9F);
            this.btnLogout.Location = new System.Drawing.Point(1064, 16);
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
            this.tlpChartsRoot.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpChartsRoot.Location = new System.Drawing.Point(3, 3);
            this.tlpChartsRoot.Name = "tlpChartsRoot";
            this.tlpChartsRoot.Padding = new System.Windows.Forms.Padding(10);
            this.tlpChartsRoot.RowCount = 2;
            this.tlpChartsRoot.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 140F));
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
            this.pnlChartsTop.Size = new System.Drawing.Size(1134, 134);
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
            this.tlpKpis.Location = new System.Drawing.Point(10, 54);
            this.tlpKpis.Margin = new System.Windows.Forms.Padding(0, 8, 0, 0);
            this.tlpKpis.Name = "tlpKpis";
            this.tlpKpis.RowCount = 1;
            this.tlpKpis.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpKpis.Size = new System.Drawing.Size(1112, 68);
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
            this.pnlKpiAttemptsCard.Size = new System.Drawing.Size(266, 56);
            this.pnlKpiAttemptsCard.TabIndex = 0;
            // 
            // lblKpiAttemptsValue
            // 
            this.lblKpiAttemptsValue.AutoSize = true;
            this.lblKpiAttemptsValue.Font = new System.Drawing.Font("Muro", 18F);
            this.lblKpiAttemptsValue.Location = new System.Drawing.Point(192, 0);
            this.lblKpiAttemptsValue.Name = "lblKpiAttemptsValue";
            this.lblKpiAttemptsValue.Padding = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.lblKpiAttemptsValue.Size = new System.Drawing.Size(46, 41);
            this.lblKpiAttemptsValue.TabIndex = 1;
            this.lblKpiAttemptsValue.Text = "12";
            // 
            // lblKpiAttemptTitle
            // 
            this.lblKpiAttemptTitle.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblKpiAttemptTitle.AutoSize = true;
            this.lblKpiAttemptTitle.Font = new System.Drawing.Font("Agency", 11F);
            this.lblKpiAttemptTitle.Location = new System.Drawing.Point(19, 20);
            this.lblKpiAttemptTitle.Name = "lblKpiAttemptTitle";
            this.lblKpiAttemptTitle.Size = new System.Drawing.Size(125, 17);
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
            this.pnlKpiAccuracyCard.Size = new System.Drawing.Size(266, 56);
            this.pnlKpiAccuracyCard.TabIndex = 1;
            // 
            // lblKpiAccuracyValue
            // 
            this.lblKpiAccuracyValue.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblKpiAccuracyValue.AutoSize = true;
            this.lblKpiAccuracyValue.Font = new System.Drawing.Font("Muro", 18F);
            this.lblKpiAccuracyValue.Location = new System.Drawing.Point(172, 5);
            this.lblKpiAccuracyValue.Name = "lblKpiAccuracyValue";
            this.lblKpiAccuracyValue.Size = new System.Drawing.Size(80, 36);
            this.lblKpiAccuracyValue.TabIndex = 1;
            this.lblKpiAccuracyValue.Text = "58%";
            // 
            // lblKpiAccuracyTitle
            // 
            this.lblKpiAccuracyTitle.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblKpiAccuracyTitle.AutoSize = true;
            this.lblKpiAccuracyTitle.Font = new System.Drawing.Font("Agency", 11F);
            this.lblKpiAccuracyTitle.Location = new System.Drawing.Point(19, 20);
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
            this.pnlKpiAvgTimeCard.Size = new System.Drawing.Size(266, 56);
            this.pnlKpiAvgTimeCard.TabIndex = 2;
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
            this.pnlKpiStreakCard.Size = new System.Drawing.Size(266, 56);
            this.pnlKpiStreakCard.TabIndex = 3;
            // 
            // pnlFilters
            // 
            this.pnlFilters.Controls.Add(this.btnRefreshCharts);
            this.pnlFilters.Controls.Add(this.cmdDifficulty);
            this.pnlFilters.Controls.Add(this.cmbTopic);
            this.pnlFilters.Controls.Add(this.cmbRange);
            this.pnlFilters.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlFilters.Location = new System.Drawing.Point(10, 10);
            this.pnlFilters.Name = "pnlFilters";
            this.pnlFilters.Size = new System.Drawing.Size(1112, 44);
            this.pnlFilters.TabIndex = 0;
            // 
            // btnRefreshCharts
            // 
            this.btnRefreshCharts.BackColor = System.Drawing.Color.RoyalBlue;
            this.btnRefreshCharts.Dock = System.Windows.Forms.DockStyle.Right;
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
            // cmdDifficulty
            // 
            this.cmdDifficulty.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmdDifficulty.FormattingEnabled = true;
            this.cmdDifficulty.Items.AddRange(new object[] {
            "ALL",
            "Easy",
            "Medium",
            "Hard"});
            this.cmdDifficulty.Location = new System.Drawing.Point(330, 8);
            this.cmdDifficulty.Name = "cmdDifficulty";
            this.cmdDifficulty.Size = new System.Drawing.Size(150, 26);
            this.cmdDifficulty.TabIndex = 2;
            // 
            // cmbTopic
            // 
            this.cmbTopic.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTopic.FormattingEnabled = true;
            this.cmbTopic.Items.AddRange(new object[] {
            "ALL"});
            this.cmbTopic.Location = new System.Drawing.Point(130, 8);
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
            this.cmbRange.Location = new System.Drawing.Point(0, 8);
            this.cmbRange.Name = "cmbRange";
            this.cmbRange.Size = new System.Drawing.Size(120, 26);
            this.cmbRange.TabIndex = 0;
            // 
            // tabReport
            // 
            this.tabReport.BackColor = System.Drawing.Color.White;
            this.tabReport.Location = new System.Drawing.Point(4, 27);
            this.tabReport.Name = "tabReport";
            this.tabReport.Padding = new System.Windows.Forms.Padding(3);
            this.tabReport.Size = new System.Drawing.Size(1166, 556);
            this.tabReport.TabIndex = 1;
            this.tabReport.Text = "REPORTS";
            // 
            // lblKpiAvgTimeTitle
            // 
            this.lblKpiAvgTimeTitle.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblKpiAvgTimeTitle.AutoSize = true;
            this.lblKpiAvgTimeTitle.Font = new System.Drawing.Font("Agency", 11F);
            this.lblKpiAvgTimeTitle.Location = new System.Drawing.Point(19, 20);
            this.lblKpiAvgTimeTitle.Name = "lblKpiAvgTimeTitle";
            this.lblKpiAvgTimeTitle.Size = new System.Drawing.Size(115, 17);
            this.lblKpiAvgTimeTitle.TabIndex = 0;
            this.lblKpiAvgTimeTitle.Text = "Avg Time: ";
            // 
            // lblKpiAvgTimeValue
            // 
            this.lblKpiAvgTimeValue.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblKpiAvgTimeValue.AutoSize = true;
            this.lblKpiAvgTimeValue.Font = new System.Drawing.Font("Muro", 18F);
            this.lblKpiAvgTimeValue.Location = new System.Drawing.Point(173, 5);
            this.lblKpiAvgTimeValue.Name = "lblKpiAvgTimeValue";
            this.lblKpiAvgTimeValue.Size = new System.Drawing.Size(76, 36);
            this.lblKpiAvgTimeValue.TabIndex = 1;
            this.lblKpiAvgTimeValue.Text = "2.3s";
            // 
            // lblKpiStreakTitle
            // 
            this.lblKpiStreakTitle.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblKpiStreakTitle.AutoSize = true;
            this.lblKpiStreakTitle.Font = new System.Drawing.Font("Agency", 11F);
            this.lblKpiStreakTitle.Location = new System.Drawing.Point(19, 20);
            this.lblKpiStreakTitle.Name = "lblKpiStreakTitle";
            this.lblKpiStreakTitle.Size = new System.Drawing.Size(97, 17);
            this.lblKpiStreakTitle.TabIndex = 0;
            this.lblKpiStreakTitle.Text = "Streak: ";
            // 
            // lblKpiStreakValue
            // 
            this.lblKpiStreakValue.AutoSize = true;
            this.lblKpiStreakValue.Font = new System.Drawing.Font("Muro", 18F);
            this.lblKpiStreakValue.Location = new System.Drawing.Point(192, 5);
            this.lblKpiStreakValue.Name = "lblKpiStreakValue";
            this.lblKpiStreakValue.Size = new System.Drawing.Size(33, 36);
            this.lblKpiStreakValue.TabIndex = 1;
            this.lblKpiStreakValue.Text = "5";
            // 
            // ReportsAndChartsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(15F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1184, 661);
            this.Controls.Add(this.tlpRoot);
            this.Font = new System.Drawing.Font("Agency", 12F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(5, 3, 5, 3);
            this.MaximizeBox = false;
            this.MinimumSize = new System.Drawing.Size(1100, 650);
            this.Name = "ReportsAndChartsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Style.MdiChild.IconHorizontalAlignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.Style.MdiChild.IconVerticalAlignment = System.Windows.Forms.VisualStyles.VerticalAlignment.Center;
            this.Text = "Reports & Charts - Mondas";
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
        private System.Windows.Forms.Panel pnlFilters;
        private System.Windows.Forms.ComboBox cmbRange;
        private System.Windows.Forms.ComboBox cmbTopic;
        private System.Windows.Forms.ComboBox cmdDifficulty;
        private Syncfusion.WinForms.Controls.SfButton btnRefreshCharts;
        private System.Windows.Forms.TableLayoutPanel tlpKpis;
        private System.Windows.Forms.Panel pnlKpiAttemptsCard;
        private System.Windows.Forms.Panel pnlKpiAccuracyCard;
        private System.Windows.Forms.Panel pnlKpiAvgTimeCard;
        private System.Windows.Forms.Panel pnlKpiStreakCard;
        private System.Windows.Forms.Label lblKpiAttemptTitle;
        private System.Windows.Forms.Label lblKpiAttemptsValue;
        private System.Windows.Forms.Label lblKpiAccuracyValue;
        private System.Windows.Forms.Label lblKpiAccuracyTitle;
        private System.Windows.Forms.Label lblKpiAvgTimeTitle;
        private System.Windows.Forms.Label lblKpiAvgTimeValue;
        private System.Windows.Forms.Label lblKpiStreakTitle;
        private System.Windows.Forms.Label lblKpiStreakValue;
    }
}