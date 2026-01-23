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
            this.lblPrefsSub = new System.Windows.Forms.Label();
            this.lblPrefsTitle = new System.Windows.Forms.Label();
            this.pnlPrefsBody = new System.Windows.Forms.Panel();
            this.tlpPrefsSections = new System.Windows.Forms.TableLayoutPanel();
            this.gbBasics = new System.Windows.Forms.GroupBox();
            this.tlpBasics = new System.Windows.Forms.TableLayoutPanel();
            this.lblCount = new System.Windows.Forms.Label();
            this.cmbQuestionCount = new System.Windows.Forms.ComboBox();
            this.lblTimer = new System.Windows.Forms.Label();
            this.cmbTimer = new System.Windows.Forms.ComboBox();
            this.gbTopics = new System.Windows.Forms.GroupBox();
            this.clbTopics = new System.Windows.Forms.CheckedListBox();
            this.chkPrioritiseWeak = new System.Windows.Forms.CheckBox();
            this.gbDifficulty = new System.Windows.Forms.GroupBox();
            this.tlpDifficulty = new System.Windows.Forms.TableLayoutPanel();
            this.lblDifficulty = new System.Windows.Forms.Label();
            this.cmbDifficulty = new System.Windows.Forms.ComboBox();
            this.gbTypes = new System.Windows.Forms.GroupBox();
            this.clbQuestionTypes = new System.Windows.Forms.CheckedListBox();
            this.gbAdvanced = new System.Windows.Forms.GroupBox();
            this.tlpAdvanced = new System.Windows.Forms.TableLayoutPanel();
            this.lblBloom = new System.Windows.Forms.Label();
            this.cmbBloom = new System.Windows.Forms.ComboBox();
            this.lblThreatVector = new System.Windows.Forms.Label();
            this.cmbThreatVector = new System.Windows.Forms.ComboBox();
            this.pnlPrefsButtons = new System.Windows.Forms.Panel();
            this.flpButtonsRight = new System.Windows.Forms.FlowLayoutPanel();
            this.btnUseDefaults = new Syncfusion.WinForms.Controls.SfButton();
            this.btnCancel = new Syncfusion.WinForms.Controls.SfButton();
            this.btnApply = new Syncfusion.WinForms.Controls.SfButton();
            this.gbMode = new System.Windows.Forms.GroupBox();
            this.pnlMode = new System.Windows.Forms.Panel();
            this.rbDefault = new System.Windows.Forms.RadioButton();
            this.rbCustom = new System.Windows.Forms.RadioButton();
            this.tlpPrefsRoot.SuspendLayout();
            this.pnlPrefsHeader.SuspendLayout();
            this.pnlPrefsBody.SuspendLayout();
            this.tlpPrefsSections.SuspendLayout();
            this.gbBasics.SuspendLayout();
            this.tlpBasics.SuspendLayout();
            this.gbTopics.SuspendLayout();
            this.gbDifficulty.SuspendLayout();
            this.tlpDifficulty.SuspendLayout();
            this.gbTypes.SuspendLayout();
            this.gbAdvanced.SuspendLayout();
            this.tlpAdvanced.SuspendLayout();
            this.pnlPrefsButtons.SuspendLayout();
            this.flpButtonsRight.SuspendLayout();
            this.gbMode.SuspendLayout();
            this.pnlMode.SuspendLayout();
            this.SuspendLayout();
            // 
            // tlpPrefsRoot
            // 
            this.tlpPrefsRoot.ColumnCount = 1;
            this.tlpPrefsRoot.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpPrefsRoot.Controls.Add(this.pnlPrefsHeader, 0, 0);
            this.tlpPrefsRoot.Controls.Add(this.pnlPrefsBody, 0, 1);
            this.tlpPrefsRoot.Controls.Add(this.pnlPrefsButtons, 0, 2);
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
            // lblPrefsSub
            // 
            this.lblPrefsSub.AutoSize = true;
            this.lblPrefsSub.BackColor = System.Drawing.Color.White;
            this.lblPrefsSub.Font = new System.Drawing.Font("Agency", 8F);
            this.lblPrefsSub.ForeColor = System.Drawing.Color.Black;
            this.lblPrefsSub.Location = new System.Drawing.Point(4, 43);
            this.lblPrefsSub.Name = "lblPrefsSub";
            this.lblPrefsSub.Size = new System.Drawing.Size(491, 13);
            this.lblPrefsSub.TabIndex = 1;
            this.lblPrefsSub.Text = "Use defaults or customise what the quiz should focus on";
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
            this.tlpPrefsSections.Controls.Add(this.gbMode, 0, 0);
            this.tlpPrefsSections.Controls.Add(this.gbBasics, 0, 1);
            this.tlpPrefsSections.Controls.Add(this.gbTopics, 0, 2);
            this.tlpPrefsSections.Controls.Add(this.gbDifficulty, 0, 3);
            this.tlpPrefsSections.Controls.Add(this.gbTypes, 0, 4);
            this.tlpPrefsSections.Controls.Add(this.gbAdvanced, 0, 5);
            this.tlpPrefsSections.Dock = System.Windows.Forms.DockStyle.Top;
            this.tlpPrefsSections.Location = new System.Drawing.Point(16, 16);
            this.tlpPrefsSections.Name = "tlpPrefsSections";
            this.tlpPrefsSections.RowCount = 6;
            this.tlpPrefsSections.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpPrefsSections.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpPrefsSections.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpPrefsSections.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpPrefsSections.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpPrefsSections.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpPrefsSections.Size = new System.Drawing.Size(456, 914);
            this.tlpPrefsSections.TabIndex = 0;
            // 
            // gbBasics
            // 
            this.gbBasics.BackColor = System.Drawing.Color.White;
            this.gbBasics.Controls.Add(this.tlpBasics);
            this.gbBasics.Dock = System.Windows.Forms.DockStyle.Top;
            this.gbBasics.Font = new System.Drawing.Font("Agency", 11F);
            this.gbBasics.Location = new System.Drawing.Point(0, 114);
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
            this.cmbQuestionCount.Font = new System.Drawing.Font("Muro", 9F);
            this.cmbQuestionCount.FormattingEnabled = true;
            this.cmbQuestionCount.Items.AddRange(new object[] {
            "10",
            "15",
            "20",
            "25"});
            this.cmbQuestionCount.Location = new System.Drawing.Point(143, 7);
            this.cmbQuestionCount.Name = "cmbQuestionCount";
            this.cmbQuestionCount.Size = new System.Drawing.Size(180, 26);
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
            this.cmbTimer.Font = new System.Drawing.Font("Muro", 9F);
            this.cmbTimer.FormattingEnabled = true;
            this.cmbTimer.Items.AddRange(new object[] {
            "Off",
            "15s",
            "30s",
            "60s"});
            this.cmbTimer.Location = new System.Drawing.Point(143, 53);
            this.cmbTimer.Name = "cmbTimer";
            this.cmbTimer.Size = new System.Drawing.Size(180, 26);
            this.cmbTimer.TabIndex = 3;
            // 
            // gbTopics
            // 
            this.gbTopics.BackColor = System.Drawing.Color.White;
            this.gbTopics.Controls.Add(this.clbTopics);
            this.gbTopics.Controls.Add(this.chkPrioritiseWeak);
            this.gbTopics.Dock = System.Windows.Forms.DockStyle.Top;
            this.gbTopics.Font = new System.Drawing.Font("Agency", 11F);
            this.gbTopics.Location = new System.Drawing.Point(0, 266);
            this.gbTopics.Margin = new System.Windows.Forms.Padding(0, 0, 0, 12);
            this.gbTopics.Name = "gbTopics";
            this.gbTopics.Padding = new System.Windows.Forms.Padding(12);
            this.gbTopics.Size = new System.Drawing.Size(456, 200);
            this.gbTopics.TabIndex = 1;
            this.gbTopics.TabStop = false;
            this.gbTopics.Text = "TOPICS";
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
            // gbDifficulty
            // 
            this.gbDifficulty.BackColor = System.Drawing.Color.White;
            this.gbDifficulty.Controls.Add(this.tlpDifficulty);
            this.gbDifficulty.Dock = System.Windows.Forms.DockStyle.Top;
            this.gbDifficulty.Font = new System.Drawing.Font("Agency", 11F);
            this.gbDifficulty.Location = new System.Drawing.Point(0, 478);
            this.gbDifficulty.Margin = new System.Windows.Forms.Padding(0, 0, 0, 12);
            this.gbDifficulty.Name = "gbDifficulty";
            this.gbDifficulty.Padding = new System.Windows.Forms.Padding(12);
            this.gbDifficulty.Size = new System.Drawing.Size(456, 95);
            this.gbDifficulty.TabIndex = 2;
            this.gbDifficulty.TabStop = false;
            this.gbDifficulty.Text = "DIFFICULTY";
            // 
            // tlpDifficulty
            // 
            this.tlpDifficulty.ColumnCount = 2;
            this.tlpDifficulty.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 140F));
            this.tlpDifficulty.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpDifficulty.Controls.Add(this.lblDifficulty, 0, 0);
            this.tlpDifficulty.Controls.Add(this.cmbDifficulty, 1, 0);
            this.tlpDifficulty.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpDifficulty.Location = new System.Drawing.Point(12, 35);
            this.tlpDifficulty.Name = "tlpDifficulty";
            this.tlpDifficulty.RowCount = 1;
            this.tlpDifficulty.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tlpDifficulty.Size = new System.Drawing.Size(432, 48);
            this.tlpDifficulty.TabIndex = 0;
            // 
            // lblDifficulty
            // 
            this.lblDifficulty.AutoSize = true;
            this.lblDifficulty.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblDifficulty.Font = new System.Drawing.Font("Agency", 7.5F);
            this.lblDifficulty.Location = new System.Drawing.Point(3, 0);
            this.lblDifficulty.Name = "lblDifficulty";
            this.lblDifficulty.Size = new System.Drawing.Size(134, 48);
            this.lblDifficulty.TabIndex = 0;
            this.lblDifficulty.Text = "Difficulty Band";
            this.lblDifficulty.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cmbDifficulty
            // 
            this.cmbDifficulty.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.cmbDifficulty.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDifficulty.Font = new System.Drawing.Font("Muro", 9F);
            this.cmbDifficulty.FormattingEnabled = true;
            this.cmbDifficulty.Items.AddRange(new object[] {
            "Any",
            "Easy",
            "Medium",
            "Hard"});
            this.cmbDifficulty.Location = new System.Drawing.Point(143, 11);
            this.cmbDifficulty.Name = "cmbDifficulty";
            this.cmbDifficulty.Size = new System.Drawing.Size(180, 26);
            this.cmbDifficulty.TabIndex = 1;
            // 
            // gbTypes
            // 
            this.gbTypes.BackColor = System.Drawing.Color.White;
            this.gbTypes.Controls.Add(this.clbQuestionTypes);
            this.gbTypes.Dock = System.Windows.Forms.DockStyle.Top;
            this.gbTypes.Font = new System.Drawing.Font("Agency", 11F);
            this.gbTypes.Location = new System.Drawing.Point(0, 585);
            this.gbTypes.Margin = new System.Windows.Forms.Padding(0, 0, 0, 12);
            this.gbTypes.Name = "gbTypes";
            this.gbTypes.Padding = new System.Windows.Forms.Padding(12);
            this.gbTypes.Size = new System.Drawing.Size(456, 160);
            this.gbTypes.TabIndex = 3;
            this.gbTypes.TabStop = false;
            this.gbTypes.Text = "QUESTION TYPES";
            // 
            // clbQuestionTypes
            // 
            this.clbQuestionTypes.CheckOnClick = true;
            this.clbQuestionTypes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.clbQuestionTypes.Font = new System.Drawing.Font("Agency", 9F);
            this.clbQuestionTypes.FormattingEnabled = true;
            this.clbQuestionTypes.Items.AddRange(new object[] {
            "Single Choice",
            "Multiple Choice",
            "True / False",
            "Scenario"});
            this.clbQuestionTypes.Location = new System.Drawing.Point(12, 35);
            this.clbQuestionTypes.Name = "clbQuestionTypes";
            this.clbQuestionTypes.Size = new System.Drawing.Size(432, 113);
            this.clbQuestionTypes.TabIndex = 0;
            // 
            // gbAdvanced
            // 
            this.gbAdvanced.BackColor = System.Drawing.Color.White;
            this.gbAdvanced.Controls.Add(this.tlpAdvanced);
            this.gbAdvanced.Dock = System.Windows.Forms.DockStyle.Top;
            this.gbAdvanced.Font = new System.Drawing.Font("Agency", 11F);
            this.gbAdvanced.Location = new System.Drawing.Point(0, 757);
            this.gbAdvanced.Margin = new System.Windows.Forms.Padding(0, 0, 0, 12);
            this.gbAdvanced.Name = "gbAdvanced";
            this.gbAdvanced.Padding = new System.Windows.Forms.Padding(12);
            this.gbAdvanced.Size = new System.Drawing.Size(456, 145);
            this.gbAdvanced.TabIndex = 4;
            this.gbAdvanced.TabStop = false;
            this.gbAdvanced.Text = "ADVANCED (OPTIONAL)";
            // 
            // tlpAdvanced
            // 
            this.tlpAdvanced.ColumnCount = 2;
            this.tlpAdvanced.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 140F));
            this.tlpAdvanced.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpAdvanced.Controls.Add(this.lblBloom, 0, 0);
            this.tlpAdvanced.Controls.Add(this.cmbBloom, 1, 0);
            this.tlpAdvanced.Controls.Add(this.lblThreatVector, 0, 1);
            this.tlpAdvanced.Controls.Add(this.cmbThreatVector, 1, 1);
            this.tlpAdvanced.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpAdvanced.Location = new System.Drawing.Point(12, 35);
            this.tlpAdvanced.Name = "tlpAdvanced";
            this.tlpAdvanced.RowCount = 2;
            this.tlpAdvanced.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tlpAdvanced.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tlpAdvanced.Size = new System.Drawing.Size(432, 98);
            this.tlpAdvanced.TabIndex = 0;
            // 
            // lblBloom
            // 
            this.lblBloom.AutoSize = true;
            this.lblBloom.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblBloom.Font = new System.Drawing.Font("Agency", 9.5F);
            this.lblBloom.Location = new System.Drawing.Point(3, 0);
            this.lblBloom.Name = "lblBloom";
            this.lblBloom.Size = new System.Drawing.Size(134, 40);
            this.lblBloom.TabIndex = 0;
            this.lblBloom.Text = "Bloom Level";
            this.lblBloom.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cmbBloom
            // 
            this.cmbBloom.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.cmbBloom.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbBloom.Font = new System.Drawing.Font("Muro", 9F);
            this.cmbBloom.FormattingEnabled = true;
            this.cmbBloom.Items.AddRange(new object[] {
            "Any",
            "Remember",
            "Understand",
            "Apply",
            "Analyse"});
            this.cmbBloom.Location = new System.Drawing.Point(143, 7);
            this.cmbBloom.Name = "cmbBloom";
            this.cmbBloom.Size = new System.Drawing.Size(180, 26);
            this.cmbBloom.TabIndex = 1;
            // 
            // lblThreatVector
            // 
            this.lblThreatVector.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblThreatVector.AutoSize = true;
            this.lblThreatVector.Font = new System.Drawing.Font("Agency", 8F);
            this.lblThreatVector.Location = new System.Drawing.Point(3, 62);
            this.lblThreatVector.Name = "lblThreatVector";
            this.lblThreatVector.Size = new System.Drawing.Size(128, 13);
            this.lblThreatVector.TabIndex = 2;
            this.lblThreatVector.Text = "Threat Vector";
            this.lblThreatVector.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cmbThreatVector
            // 
            this.cmbThreatVector.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.cmbThreatVector.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbThreatVector.Font = new System.Drawing.Font("Muro", 9F);
            this.cmbThreatVector.FormattingEnabled = true;
            this.cmbThreatVector.Items.AddRange(new object[] {
            "Any"});
            this.cmbThreatVector.Location = new System.Drawing.Point(143, 56);
            this.cmbThreatVector.Name = "cmbThreatVector";
            this.cmbThreatVector.Size = new System.Drawing.Size(180, 26);
            this.cmbThreatVector.TabIndex = 3;
            // 
            // pnlPrefsButtons
            // 
            this.pnlPrefsButtons.BackColor = System.Drawing.Color.White;
            this.pnlPrefsButtons.Controls.Add(this.btnUseDefaults);
            this.pnlPrefsButtons.Controls.Add(this.flpButtonsRight);
            this.pnlPrefsButtons.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlPrefsButtons.Location = new System.Drawing.Point(3, 450);
            this.pnlPrefsButtons.Name = "pnlPrefsButtons";
            this.pnlPrefsButtons.Padding = new System.Windows.Forms.Padding(16, 10, 16, 10);
            this.pnlPrefsButtons.Size = new System.Drawing.Size(514, 64);
            this.pnlPrefsButtons.TabIndex = 2;
            // 
            // flpButtonsRight
            // 
            this.flpButtonsRight.AutoSize = true;
            this.flpButtonsRight.Controls.Add(this.btnApply);
            this.flpButtonsRight.Controls.Add(this.btnCancel);
            this.flpButtonsRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.flpButtonsRight.Location = new System.Drawing.Point(266, 10);
            this.flpButtonsRight.Margin = new System.Windows.Forms.Padding(0);
            this.flpButtonsRight.Name = "flpButtonsRight";
            this.flpButtonsRight.Size = new System.Drawing.Size(232, 44);
            this.flpButtonsRight.TabIndex = 0;
            this.flpButtonsRight.WrapContents = false;
            // 
            // btnUseDefaults
            // 
            this.btnUseDefaults.BackColor = System.Drawing.Color.Gainsboro;
            this.btnUseDefaults.Font = new System.Drawing.Font("Muro", 10F);
            this.btnUseDefaults.Location = new System.Drawing.Point(6, 14);
            this.btnUseDefaults.Name = "btnUseDefaults";
            this.btnUseDefaults.Size = new System.Drawing.Size(140, 40);
            this.btnUseDefaults.Style.BackColor = System.Drawing.Color.Gainsboro;
            this.btnUseDefaults.TabIndex = 1;
            this.btnUseDefaults.Text = "USE DEFAULTS";
            this.btnUseDefaults.UseVisualStyleBackColor = false;
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.Gainsboro;
            this.btnCancel.Font = new System.Drawing.Font("Muro", 10F);
            this.btnCancel.Location = new System.Drawing.Point(119, 3);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(110, 40);
            this.btnCancel.Style.BackColor = System.Drawing.Color.Gainsboro;
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "CANCEL";
            this.btnCancel.UseVisualStyleBackColor = false;
            // 
            // btnApply
            // 
            this.btnApply.BackColor = System.Drawing.Color.RoyalBlue;
            this.btnApply.Font = new System.Drawing.Font("Muro", 10F);
            this.btnApply.ForeColor = System.Drawing.Color.White;
            this.btnApply.Location = new System.Drawing.Point(3, 3);
            this.btnApply.Name = "btnApply";
            this.btnApply.Size = new System.Drawing.Size(110, 40);
            this.btnApply.Style.BackColor = System.Drawing.Color.RoyalBlue;
            this.btnApply.Style.ForeColor = System.Drawing.Color.White;
            this.btnApply.TabIndex = 3;
            this.btnApply.Text = "APPLY";
            this.btnApply.UseVisualStyleBackColor = false;
            // 
            // gbMode
            // 
            this.gbMode.AutoSize = true;
            this.gbMode.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.gbMode.BackColor = System.Drawing.Color.White;
            this.gbMode.Controls.Add(this.pnlMode);
            this.gbMode.Dock = System.Windows.Forms.DockStyle.Top;
            this.gbMode.Font = new System.Drawing.Font("Agency", 11F);
            this.gbMode.Location = new System.Drawing.Point(0, 0);
            this.gbMode.Margin = new System.Windows.Forms.Padding(0, 0, 0, 12);
            this.gbMode.Name = "gbMode";
            this.gbMode.Padding = new System.Windows.Forms.Padding(12);
            this.gbMode.Size = new System.Drawing.Size(456, 102);
            this.gbMode.TabIndex = 0;
            this.gbMode.TabStop = false;
            this.gbMode.Text = "MODE";
            // 
            // pnlMode
            // 
            this.pnlMode.Controls.Add(this.rbCustom);
            this.pnlMode.Controls.Add(this.rbDefault);
            this.pnlMode.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlMode.Location = new System.Drawing.Point(12, 35);
            this.pnlMode.Margin = new System.Windows.Forms.Padding(0);
            this.pnlMode.Name = "pnlMode";
            this.pnlMode.Size = new System.Drawing.Size(432, 55);
            this.pnlMode.TabIndex = 0;
            // 
            // rbDefault
            // 
            this.rbDefault.AutoSize = true;
            this.rbDefault.Checked = true;
            this.rbDefault.Font = new System.Drawing.Font("Agency", 8F);
            this.rbDefault.Location = new System.Drawing.Point(12, 4);
            this.rbDefault.Name = "rbDefault";
            this.rbDefault.Size = new System.Drawing.Size(262, 20);
            this.rbDefault.TabIndex = 0;
            this.rbDefault.TabStop = true;
            this.rbDefault.Text = "Use recommended defaults";
            this.rbDefault.UseVisualStyleBackColor = true;
            // 
            // rbCustom
            // 
            this.rbCustom.AutoSize = true;
            this.rbCustom.Font = new System.Drawing.Font("Agency", 8F);
            this.rbCustom.Location = new System.Drawing.Point(12, 32);
            this.rbCustom.Name = "rbCustom";
            this.rbCustom.Size = new System.Drawing.Size(205, 20);
            this.rbCustom.TabIndex = 1;
            this.rbCustom.TabStop = true;
            this.rbCustom.Text = "Custom preferences";
            this.rbCustom.UseVisualStyleBackColor = true;
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
            this.tlpPrefsSections.PerformLayout();
            this.gbBasics.ResumeLayout(false);
            this.tlpBasics.ResumeLayout(false);
            this.tlpBasics.PerformLayout();
            this.gbTopics.ResumeLayout(false);
            this.gbDifficulty.ResumeLayout(false);
            this.tlpDifficulty.ResumeLayout(false);
            this.tlpDifficulty.PerformLayout();
            this.gbTypes.ResumeLayout(false);
            this.gbAdvanced.ResumeLayout(false);
            this.tlpAdvanced.ResumeLayout(false);
            this.tlpAdvanced.PerformLayout();
            this.pnlPrefsButtons.ResumeLayout(false);
            this.pnlPrefsButtons.PerformLayout();
            this.flpButtonsRight.ResumeLayout(false);
            this.gbMode.ResumeLayout(false);
            this.pnlMode.ResumeLayout(false);
            this.pnlMode.PerformLayout();
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
        private System.Windows.Forms.GroupBox gbDifficulty;
        private System.Windows.Forms.TableLayoutPanel tlpDifficulty;
        private System.Windows.Forms.Label lblDifficulty;
        private System.Windows.Forms.ComboBox cmbDifficulty;
        private System.Windows.Forms.GroupBox gbTypes;
        private System.Windows.Forms.CheckedListBox clbQuestionTypes;
        private System.Windows.Forms.GroupBox gbAdvanced;
        private System.Windows.Forms.TableLayoutPanel tlpAdvanced;
        private System.Windows.Forms.Label lblBloom;
        private System.Windows.Forms.ComboBox cmbBloom;
        private System.Windows.Forms.Label lblThreatVector;
        private System.Windows.Forms.ComboBox cmbThreatVector;
        private System.Windows.Forms.Panel pnlPrefsButtons;
        private System.Windows.Forms.FlowLayoutPanel flpButtonsRight;
        private Syncfusion.WinForms.Controls.SfButton btnUseDefaults;
        private Syncfusion.WinForms.Controls.SfButton btnCancel;
        private Syncfusion.WinForms.Controls.SfButton btnApply;
        private System.Windows.Forms.GroupBox gbMode;
        private System.Windows.Forms.Panel pnlMode;
        private System.Windows.Forms.RadioButton rbCustom;
        private System.Windows.Forms.RadioButton rbDefault;
    }
}