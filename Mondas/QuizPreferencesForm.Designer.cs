namespace Mondas
{
    partial class QuizPreferencesForm
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
            this.tlpPrefsRoot = new System.Windows.Forms.TableLayoutPanel();
            this.pnlPrefsHeader = new System.Windows.Forms.Panel();
            this.lblPrefsTitle = new System.Windows.Forms.Label();
            this.lblPrefsSub = new System.Windows.Forms.Label();
            this.pnlPrefsBody = new System.Windows.Forms.Panel();
            this.tlpPrefsSections = new System.Windows.Forms.TableLayoutPanel();
            this.gbBasics = new System.Windows.Forms.GroupBox();
            this.tlpBasics = new System.Windows.Forms.TableLayoutPanel();
            this.lblCount = new System.Windows.Forms.Label();
            this.cmbQuestionCount = new System.Windows.Forms.ComboBox();
            this.lblTimer = new System.Windows.Forms.Label();
            this.cmbTimer = new System.Windows.Forms.ComboBox();
            this.gbTopics = new System.Windows.Forms.GroupBox();
            this.chkPrioritiseWeak = new System.Windows.Forms.CheckBox();
            this.clbTopics = new System.Windows.Forms.CheckedListBox();
            this.tlpPrefsRoot.SuspendLayout();
            this.pnlPrefsHeader.SuspendLayout();
            this.pnlPrefsBody.SuspendLayout();
            this.tlpPrefsSections.SuspendLayout();
            this.gbBasics.SuspendLayout();
            this.tlpBasics.SuspendLayout();
            this.gbTopics.SuspendLayout();
            this.SuspendLayout();
            // 
            // tlpPrefsRoot
            // 
            this.tlpPrefsRoot.ColumnCount = 1;
            this.tlpPrefsRoot.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpPrefsRoot.Controls.Add(this.pnlPrefsHeader, 0, 0);
            this.tlpPrefsRoot.Controls.Add(this.pnlPrefsBody, 0, 1);
            this.tlpPrefsRoot.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpPrefsRoot.Location = new System.Drawing.Point(2, 2);
            this.tlpPrefsRoot.Name = "tlpPrefsRoot";
            this.tlpPrefsRoot.RowCount = 3;
            this.tlpPrefsRoot.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 70F));
            this.tlpPrefsRoot.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpPrefsRoot.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 70F));
            this.tlpPrefsRoot.Size = new System.Drawing.Size(520, 517);
            this.tlpPrefsRoot.TabIndex = 0;
            // 
            // pnlPrefsHeader
            // 
            this.pnlPrefsHeader.BackColor = System.Drawing.Color.White;
            this.pnlPrefsHeader.Controls.Add(this.lblPrefsSub);
            this.pnlPrefsHeader.Controls.Add(this.lblPrefsTitle);
            this.pnlPrefsHeader.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlPrefsHeader.Location = new System.Drawing.Point(3, 3);
            this.pnlPrefsHeader.Name = "pnlPrefsHeader";
            this.pnlPrefsHeader.Padding = new System.Windows.Forms.Padding(16, 12, 16, 8);
            this.pnlPrefsHeader.Size = new System.Drawing.Size(514, 64);
            this.pnlPrefsHeader.TabIndex = 0;
            // 
            // lblPrefsTitle
            // 
            this.lblPrefsTitle.AutoSize = true;
            this.lblPrefsTitle.Font = new System.Drawing.Font("Muro", 16F);
            this.lblPrefsTitle.Location = new System.Drawing.Point(0, 0);
            this.lblPrefsTitle.Name = "lblPrefsTitle";
            this.lblPrefsTitle.Size = new System.Drawing.Size(240, 32);
            this.lblPrefsTitle.TabIndex = 0;
            this.lblPrefsTitle.Text = "QUIZ PREFERENCES";
            // 
            // lblPrefsSub
            // 
            this.lblPrefsSub.AutoSize = true;
            this.lblPrefsSub.BackColor = System.Drawing.Color.WhiteSmoke;
            this.lblPrefsSub.Font = new System.Drawing.Font("Agency", 8F);
            this.lblPrefsSub.ForeColor = System.Drawing.Color.Black;
            this.lblPrefsSub.Location = new System.Drawing.Point(4, 43);
            this.lblPrefsSub.Name = "lblPrefsSub";
            this.lblPrefsSub.Size = new System.Drawing.Size(491, 13);
            this.lblPrefsSub.TabIndex = 1;
            this.lblPrefsSub.Text = "Use defaults or customise what the quiz should focus on";
            // 
            // pnlPrefsBody
            // 
            this.pnlPrefsBody.AutoScroll = true;
            this.pnlPrefsBody.Controls.Add(this.tlpPrefsSections);
            this.pnlPrefsBody.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlPrefsBody.Location = new System.Drawing.Point(3, 73);
            this.pnlPrefsBody.Name = "pnlPrefsBody";
            this.pnlPrefsBody.Padding = new System.Windows.Forms.Padding(16);
            this.pnlPrefsBody.Size = new System.Drawing.Size(514, 371);
            this.pnlPrefsBody.TabIndex = 1;
            // 
            // tlpPrefsSections
            // 
            this.tlpPrefsSections.AutoSize = true;
            this.tlpPrefsSections.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tlpPrefsSections.ColumnCount = 1;
            this.tlpPrefsSections.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpPrefsSections.Controls.Add(this.gbBasics, 0, 0);
            this.tlpPrefsSections.Controls.Add(this.gbTopics, 0, 1);
            this.tlpPrefsSections.Dock = System.Windows.Forms.DockStyle.Top;
            this.tlpPrefsSections.Location = new System.Drawing.Point(16, 16);
            this.tlpPrefsSections.Name = "tlpPrefsSections";
            this.tlpPrefsSections.RowCount = 2;
            this.tlpPrefsSections.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpPrefsSections.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpPrefsSections.Size = new System.Drawing.Size(456, 364);
            this.tlpPrefsSections.TabIndex = 0;
            // 
            // gbBasics
            // 
            this.gbBasics.BackColor = System.Drawing.Color.White;
            this.gbBasics.Controls.Add(this.tlpBasics);
            this.gbBasics.Dock = System.Windows.Forms.DockStyle.Top;
            this.gbBasics.Font = new System.Drawing.Font("Agency", 11F);
            this.gbBasics.Location = new System.Drawing.Point(0, 0);
            this.gbBasics.Margin = new System.Windows.Forms.Padding(0, 0, 0, 12);
            this.gbBasics.Name = "gbBasics";
            this.gbBasics.Padding = new System.Windows.Forms.Padding(12);
            this.gbBasics.Size = new System.Drawing.Size(456, 140);
            this.gbBasics.TabIndex = 1;
            this.gbBasics.TabStop = false;
            this.gbBasics.Text = "BASICS";
            this.gbBasics.Enter += new System.EventHandler(this.gbBasics_Enter);
            // 
            // tlpBasics
            // 
            this.tlpBasics.ColumnCount = 2;
            this.tlpBasics.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 140F));
            this.tlpBasics.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpBasics.Controls.Add(this.lblCount, 0, 0);
            this.tlpBasics.Controls.Add(this.cmbQuestionCount, 1, 0);
            this.tlpBasics.Controls.Add(this.lblTimer, 0, 1);
            this.tlpBasics.Controls.Add(this.cmbTimer, 1, 1);
            this.tlpBasics.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpBasics.Location = new System.Drawing.Point(12, 35);
            this.tlpBasics.Name = "tlpBasics";
            this.tlpBasics.RowCount = 2;
            this.tlpBasics.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tlpBasics.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tlpBasics.Size = new System.Drawing.Size(432, 93);
            this.tlpBasics.TabIndex = 0;
            // 
            // lblCount
            // 
            this.lblCount.AutoSize = true;
            this.lblCount.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblCount.Font = new System.Drawing.Font("Agency", 10F);
            this.lblCount.Location = new System.Drawing.Point(3, 0);
            this.lblCount.Name = "lblCount";
            this.lblCount.Size = new System.Drawing.Size(134, 40);
            this.lblCount.TabIndex = 0;
            this.lblCount.Text = "Questions";
            this.lblCount.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cmbQuestionCount
            // 
            this.cmbQuestionCount.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.cmbQuestionCount.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbQuestionCount.FormattingEnabled = true;
            this.cmbQuestionCount.Items.AddRange(new object[] {
            "10",
            "15",
            "20",
            "25"});
            this.cmbQuestionCount.Location = new System.Drawing.Point(143, 7);
            this.cmbQuestionCount.Name = "cmbQuestionCount";
            this.cmbQuestionCount.Size = new System.Drawing.Size(140, 25);
            this.cmbQuestionCount.TabIndex = 1;
            // 
            // lblTimer
            // 
            this.lblTimer.AutoSize = true;
            this.lblTimer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTimer.Font = new System.Drawing.Font("Agency", 10F);
            this.lblTimer.Location = new System.Drawing.Point(3, 40);
            this.lblTimer.Name = "lblTimer";
            this.lblTimer.Size = new System.Drawing.Size(134, 53);
            this.lblTimer.TabIndex = 2;
            this.lblTimer.Text = "Timer";
            this.lblTimer.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cmbTimer
            // 
            this.cmbTimer.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.cmbTimer.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTimer.FormattingEnabled = true;
            this.cmbTimer.Items.AddRange(new object[] {
            "Off",
            "15s",
            "30s",
            "60s"});
            this.cmbTimer.Location = new System.Drawing.Point(143, 54);
            this.cmbTimer.Name = "cmbTimer";
            this.cmbTimer.Size = new System.Drawing.Size(140, 25);
            this.cmbTimer.TabIndex = 3;
            // 
            // gbTopics
            // 
            this.gbTopics.BackColor = System.Drawing.Color.White;
            this.gbTopics.Controls.Add(this.clbTopics);
            this.gbTopics.Controls.Add(this.chkPrioritiseWeak);
            this.gbTopics.Dock = System.Windows.Forms.DockStyle.Top;
            this.gbTopics.Font = new System.Drawing.Font("Agency", 11F);
            this.gbTopics.Location = new System.Drawing.Point(0, 152);
            this.gbTopics.Margin = new System.Windows.Forms.Padding(0, 0, 0, 12);
            this.gbTopics.Name = "gbTopics";
            this.gbTopics.Padding = new System.Windows.Forms.Padding(12);
            this.gbTopics.Size = new System.Drawing.Size(456, 200);
            this.gbTopics.TabIndex = 1;
            this.gbTopics.TabStop = false;
            this.gbTopics.Text = "TOPICS";
            // 
            // chkPrioritiseWeak
            // 
            this.chkPrioritiseWeak.Dock = System.Windows.Forms.DockStyle.Top;
            this.chkPrioritiseWeak.Font = new System.Drawing.Font("Agency", 9F);
            this.chkPrioritiseWeak.Location = new System.Drawing.Point(12, 35);
            this.chkPrioritiseWeak.Name = "chkPrioritiseWeak";
            this.chkPrioritiseWeak.Size = new System.Drawing.Size(432, 26);
            this.chkPrioritiseWeak.TabIndex = 0;
            this.chkPrioritiseWeak.Text = "Prioritise weak topics (recommended)";
            this.chkPrioritiseWeak.UseVisualStyleBackColor = true;
            // 
            // clbTopics
            // 
            this.clbTopics.CheckOnClick = true;
            this.clbTopics.Dock = System.Windows.Forms.DockStyle.Fill;
            this.clbTopics.Font = new System.Drawing.Font("Agency", 9F);
            this.clbTopics.FormattingEnabled = true;
            this.clbTopics.Items.AddRange(new object[] {
            "Phishing",
            "Passwords",
            "Device Security",
            "Social Engineering"});
            this.clbTopics.Location = new System.Drawing.Point(12, 61);
            this.clbTopics.Name = "clbTopics";
            this.clbTopics.Size = new System.Drawing.Size(432, 127);
            this.clbTopics.TabIndex = 1;
            // 
            // QuizPreferencesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(144F, 144F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(524, 521);
            this.Controls.Add(this.tlpPrefsRoot);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "QuizPreferencesForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Style.BackColor = System.Drawing.Color.WhiteSmoke;
            this.Style.MdiChild.IconHorizontalAlignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.Style.MdiChild.IconVerticalAlignment = System.Windows.Forms.VisualStyles.VerticalAlignment.Center;
            this.Text = "Quiz Preferences";
            this.Load += new System.EventHandler(this.QuizPreferencesForm_Load);
            this.tlpPrefsRoot.ResumeLayout(false);
            this.pnlPrefsHeader.ResumeLayout(false);
            this.pnlPrefsHeader.PerformLayout();
            this.pnlPrefsBody.ResumeLayout(false);
            this.pnlPrefsBody.PerformLayout();
            this.tlpPrefsSections.ResumeLayout(false);
            this.gbBasics.ResumeLayout(false);
            this.tlpBasics.ResumeLayout(false);
            this.tlpBasics.PerformLayout();
            this.gbTopics.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tlpPrefsRoot;
        private System.Windows.Forms.Panel pnlPrefsHeader;
        private System.Windows.Forms.Label lblPrefsTitle;
        private System.Windows.Forms.Label lblPrefsSub;
        private System.Windows.Forms.Panel pnlPrefsBody;
        private System.Windows.Forms.TableLayoutPanel tlpPrefsSections;
        private System.Windows.Forms.GroupBox gbBasics;
        private System.Windows.Forms.TableLayoutPanel tlpBasics;
        private System.Windows.Forms.Label lblCount;
        private System.Windows.Forms.ComboBox cmbQuestionCount;
        private System.Windows.Forms.Label lblTimer;
        private System.Windows.Forms.ComboBox cmbTimer;
        private System.Windows.Forms.GroupBox gbTopics;
        private System.Windows.Forms.CheckBox chkPrioritiseWeak;
        private System.Windows.Forms.CheckedListBox clbTopics;
    }
}