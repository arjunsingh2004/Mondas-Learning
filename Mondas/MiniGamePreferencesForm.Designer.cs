namespace Mondas
{
    partial class MiniGamePreferencesForm
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
            this.gbGame = new System.Windows.Forms.GroupBox();
            this.pnlGame = new System.Windows.Forms.Panel();
            this.cmbMiniGameType = new System.Windows.Forms.ComboBox();
            this.lblGameType = new System.Windows.Forms.Label();
            this.gbMode = new System.Windows.Forms.GroupBox();
            this.pnlMode = new System.Windows.Forms.Panel();
            this.rbCustom = new System.Windows.Forms.RadioButton();
            this.rbDefault = new System.Windows.Forms.RadioButton();
            this.gbBasics = new System.Windows.Forms.GroupBox();
            this.tlpBasics = new System.Windows.Forms.TableLayoutPanel();
            this.lblRoundCount = new System.Windows.Forms.Label();
            this.lblTimer = new System.Windows.Forms.Label();
            this.cmbTimer = new System.Windows.Forms.ComboBox();
            this.lblDifficulty = new System.Windows.Forms.Label();
            this.cmbRoundCount = new System.Windows.Forms.ComboBox();
            this.cmbDifficulty = new System.Windows.Forms.ComboBox();
            this.gbPhishing = new System.Windows.Forms.GroupBox();
            this.tlpPhishing = new System.Windows.Forms.TableLayoutPanel();
            this.lblEmailCount = new System.Windows.Forms.Label();
            this.cmbEmailCount = new System.Windows.Forms.ComboBox();
            this.chkIncludeAttachments = new System.Windows.Forms.CheckBox();
            this.chkIncludeLinks = new System.Windows.Forms.CheckBox();
            this.chkIncludeUrgency = new System.Windows.Forms.CheckBox();
            this.gbAuthentication = new System.Windows.Forms.GroupBox();
            this.tlpAuthentication = new System.Windows.Forms.TableLayoutPanel();
            this.chkIncludeCredentialAttacks = new System.Windows.Forms.CheckBox();
            this.chkIncludeMfaScenarios = new System.Windows.Forms.CheckBox();
            this.chkIncludeRecoveryScenarios = new System.Windows.Forms.CheckBox();
            this.chkIncludeSessionScenarios = new System.Windows.Forms.CheckBox();
            this.gbAdvanced = new System.Windows.Forms.GroupBox();
            this.tlpAdvanced = new System.Windows.Forms.TableLayoutPanel();
            this.lblHints = new System.Windows.Forms.Label();
            this.cmbHints = new System.Windows.Forms.ComboBox();
            this.lblFeedbackMode = new System.Windows.Forms.Label();
            this.cmbFeedbackMode = new System.Windows.Forms.ComboBox();
            this.gbSummary = new System.Windows.Forms.GroupBox();
            this.lblSummary = new System.Windows.Forms.Label();
            this.tlpPrefsButtons = new System.Windows.Forms.TableLayoutPanel();
            this.btnCancel = new Syncfusion.WinForms.Controls.SfButton();
            this.btnUseDefaults = new Syncfusion.WinForms.Controls.SfButton();
            this.btnApply = new Syncfusion.WinForms.Controls.SfButton();
            this.tlpPrefsRoot.SuspendLayout();
            this.pnlPrefsHeader.SuspendLayout();
            this.pnlPrefsBody.SuspendLayout();
            this.tlpPrefsSections.SuspendLayout();
            this.gbGame.SuspendLayout();
            this.pnlGame.SuspendLayout();
            this.gbMode.SuspendLayout();
            this.pnlMode.SuspendLayout();
            this.gbBasics.SuspendLayout();
            this.tlpBasics.SuspendLayout();
            this.gbPhishing.SuspendLayout();
            this.tlpPhishing.SuspendLayout();
            this.gbAuthentication.SuspendLayout();
            this.tlpAuthentication.SuspendLayout();
            this.gbAdvanced.SuspendLayout();
            this.tlpAdvanced.SuspendLayout();
            this.gbSummary.SuspendLayout();
            this.tlpPrefsButtons.SuspendLayout();
            this.SuspendLayout();
            // 
            // tlpPrefsRoot
            // 
            this.tlpPrefsRoot.AutoSize = true;
            this.tlpPrefsRoot.ColumnCount = 1;
            this.tlpPrefsRoot.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpPrefsRoot.Controls.Add(this.pnlPrefsHeader, 0, 0);
            this.tlpPrefsRoot.Controls.Add(this.pnlPrefsBody, 0, 1);
            this.tlpPrefsRoot.Controls.Add(this.tlpPrefsButtons, 0, 2);
            this.tlpPrefsRoot.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpPrefsRoot.Location = new System.Drawing.Point(2, 2);
            this.tlpPrefsRoot.Margin = new System.Windows.Forms.Padding(0);
            this.tlpPrefsRoot.Name = "tlpPrefsRoot";
            this.tlpPrefsRoot.Padding = new System.Windows.Forms.Padding(12);
            this.tlpPrefsRoot.RowCount = 3;
            this.tlpPrefsRoot.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 78F));
            this.tlpPrefsRoot.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpPrefsRoot.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 64F));
            this.tlpPrefsRoot.Size = new System.Drawing.Size(600, 717);
            this.tlpPrefsRoot.TabIndex = 0;
            // 
            // pnlPrefsHeader
            // 
            this.pnlPrefsHeader.BackColor = System.Drawing.Color.White;
            this.pnlPrefsHeader.Controls.Add(this.lblPrefsSub);
            this.pnlPrefsHeader.Controls.Add(this.lblPrefsTitle);
            this.pnlPrefsHeader.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlPrefsHeader.Location = new System.Drawing.Point(15, 15);
            this.pnlPrefsHeader.Name = "pnlPrefsHeader";
            this.pnlPrefsHeader.Size = new System.Drawing.Size(570, 72);
            this.pnlPrefsHeader.TabIndex = 0;
            // 
            // lblPrefsSub
            // 
            this.lblPrefsSub.AutoSize = true;
            this.lblPrefsSub.Font = new System.Drawing.Font("Agency", 11F);
            this.lblPrefsSub.Location = new System.Drawing.Point(9, 48);
            this.lblPrefsSub.Name = "lblPrefsSub";
            this.lblPrefsSub.Size = new System.Drawing.Size(438, 17);
            this.lblPrefsSub.TabIndex = 5;
            this.lblPrefsSub.Text = "SET UP HOW THE MINI GAME SHOULD RUN";
            // 
            // lblPrefsTitle
            // 
            this.lblPrefsTitle.AutoSize = true;
            this.lblPrefsTitle.Font = new System.Drawing.Font("Muro", 26F);
            this.lblPrefsTitle.Location = new System.Drawing.Point(3, -10);
            this.lblPrefsTitle.Name = "lblPrefsTitle";
            this.lblPrefsTitle.Size = new System.Drawing.Size(491, 52);
            this.lblPrefsTitle.TabIndex = 4;
            this.lblPrefsTitle.Text = "MINI GAME PREFERENCES";
            // 
            // pnlPrefsBody
            // 
            this.pnlPrefsBody.AutoScroll = true;
            this.pnlPrefsBody.BackColor = System.Drawing.Color.Transparent;
            this.pnlPrefsBody.Controls.Add(this.tlpPrefsSections);
            this.pnlPrefsBody.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlPrefsBody.Location = new System.Drawing.Point(15, 93);
            this.pnlPrefsBody.Name = "pnlPrefsBody";
            this.pnlPrefsBody.Size = new System.Drawing.Size(570, 545);
            this.pnlPrefsBody.TabIndex = 1;
            // 
            // tlpPrefsSections
            // 
            this.tlpPrefsSections.AutoSize = true;
            this.tlpPrefsSections.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tlpPrefsSections.ColumnCount = 1;
            this.tlpPrefsSections.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpPrefsSections.Controls.Add(this.gbGame, 0, 0);
            this.tlpPrefsSections.Controls.Add(this.gbMode, 0, 1);
            this.tlpPrefsSections.Controls.Add(this.gbBasics, 0, 2);
            this.tlpPrefsSections.Controls.Add(this.gbPhishing, 0, 3);
            this.tlpPrefsSections.Controls.Add(this.gbAuthentication, 0, 4);
            this.tlpPrefsSections.Controls.Add(this.gbAdvanced, 0, 5);
            this.tlpPrefsSections.Controls.Add(this.gbSummary, 0, 6);
            this.tlpPrefsSections.Dock = System.Windows.Forms.DockStyle.Top;
            this.tlpPrefsSections.Location = new System.Drawing.Point(0, 0);
            this.tlpPrefsSections.Margin = new System.Windows.Forms.Padding(0);
            this.tlpPrefsSections.Name = "tlpPrefsSections";
            this.tlpPrefsSections.Padding = new System.Windows.Forms.Padding(12);
            this.tlpPrefsSections.RowCount = 7;
            this.tlpPrefsSections.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpPrefsSections.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpPrefsSections.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpPrefsSections.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpPrefsSections.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpPrefsSections.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpPrefsSections.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpPrefsSections.Size = new System.Drawing.Size(544, 887);
            this.tlpPrefsSections.TabIndex = 0;
            // 
            // gbGame
            // 
            this.gbGame.AutoSize = true;
            this.gbGame.BackColor = System.Drawing.Color.White;
            this.gbGame.Controls.Add(this.pnlGame);
            this.gbGame.Dock = System.Windows.Forms.DockStyle.Top;
            this.gbGame.Font = new System.Drawing.Font("Agency", 11F);
            this.gbGame.Location = new System.Drawing.Point(15, 15);
            this.gbGame.Name = "gbGame";
            this.gbGame.Size = new System.Drawing.Size(514, 79);
            this.gbGame.TabIndex = 0;
            this.gbGame.TabStop = false;
            this.gbGame.Text = "GAME";
            // 
            // pnlGame
            // 
            this.pnlGame.Controls.Add(this.cmbMiniGameType);
            this.pnlGame.Controls.Add(this.lblGameType);
            this.pnlGame.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlGame.Location = new System.Drawing.Point(3, 26);
            this.pnlGame.Name = "pnlGame";
            this.pnlGame.Size = new System.Drawing.Size(508, 50);
            this.pnlGame.TabIndex = 0;
            // 
            // cmbMiniGameType
            // 
            this.cmbMiniGameType.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.cmbMiniGameType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMiniGameType.FormattingEnabled = true;
            this.cmbMiniGameType.Location = new System.Drawing.Point(137, 14);
            this.cmbMiniGameType.Name = "cmbMiniGameType";
            this.cmbMiniGameType.Size = new System.Drawing.Size(220, 25);
            this.cmbMiniGameType.TabIndex = 1;
            this.cmbMiniGameType.SelectedIndexChanged += new System.EventHandler(this.cmbMiniGameType_SelectedIndexChanged);
            // 
            // lblGameType
            // 
            this.lblGameType.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblGameType.AutoSize = true;
            this.lblGameType.Location = new System.Drawing.Point(3, 17);
            this.lblGameType.Name = "lblGameType";
            this.lblGameType.Size = new System.Drawing.Size(119, 17);
            this.lblGameType.TabIndex = 0;
            this.lblGameType.Text = "MINI GAME";
            // 
            // gbMode
            // 
            this.gbMode.AutoSize = true;
            this.gbMode.BackColor = System.Drawing.Color.White;
            this.gbMode.Controls.Add(this.pnlMode);
            this.gbMode.Dock = System.Windows.Forms.DockStyle.Top;
            this.gbMode.Font = new System.Drawing.Font("Agency", 11F);
            this.gbMode.Location = new System.Drawing.Point(15, 100);
            this.gbMode.Name = "gbMode";
            this.gbMode.Size = new System.Drawing.Size(514, 109);
            this.gbMode.TabIndex = 1;
            this.gbMode.TabStop = false;
            this.gbMode.Text = "MODE";
            // 
            // pnlMode
            // 
            this.pnlMode.Controls.Add(this.rbCustom);
            this.pnlMode.Controls.Add(this.rbDefault);
            this.pnlMode.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlMode.Location = new System.Drawing.Point(3, 26);
            this.pnlMode.Name = "pnlMode";
            this.pnlMode.Size = new System.Drawing.Size(508, 80);
            this.pnlMode.TabIndex = 0;
            // 
            // rbCustom
            // 
            this.rbCustom.AutoSize = true;
            this.rbCustom.Location = new System.Drawing.Point(6, 45);
            this.rbCustom.Name = "rbCustom";
            this.rbCustom.Size = new System.Drawing.Size(278, 21);
            this.rbCustom.TabIndex = 1;
            this.rbCustom.TabStop = true;
            this.rbCustom.Text = "CUSTOM PREFERENCES";
            this.rbCustom.UseVisualStyleBackColor = true;
            this.rbCustom.CheckedChanged += new System.EventHandler(this.rbCustom_CheckedChanged);
            // 
            // rbDefault
            // 
            this.rbDefault.AutoSize = true;
            this.rbDefault.Location = new System.Drawing.Point(6, 14);
            this.rbDefault.Name = "rbDefault";
            this.rbDefault.Size = new System.Drawing.Size(357, 21);
            this.rbDefault.TabIndex = 0;
            this.rbDefault.TabStop = true;
            this.rbDefault.Text = "USE RECOMMENDED DEFAULTS";
            this.rbDefault.UseVisualStyleBackColor = true;
            this.rbDefault.CheckedChanged += new System.EventHandler(this.rbDefault_CheckedChanged);
            // 
            // gbBasics
            // 
            this.gbBasics.AutoSize = true;
            this.gbBasics.BackColor = System.Drawing.Color.White;
            this.gbBasics.Controls.Add(this.tlpBasics);
            this.gbBasics.Dock = System.Windows.Forms.DockStyle.Top;
            this.gbBasics.Font = new System.Drawing.Font("Agency", 11F);
            this.gbBasics.Location = new System.Drawing.Point(15, 215);
            this.gbBasics.Name = "gbBasics";
            this.gbBasics.Size = new System.Drawing.Size(514, 141);
            this.gbBasics.TabIndex = 2;
            this.gbBasics.TabStop = false;
            this.gbBasics.Text = "BASICS";
            // 
            // tlpBasics
            // 
            this.tlpBasics.AutoSize = true;
            this.tlpBasics.ColumnCount = 2;
            this.tlpBasics.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this.tlpBasics.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpBasics.Controls.Add(this.lblRoundCount, 0, 0);
            this.tlpBasics.Controls.Add(this.lblTimer, 0, 1);
            this.tlpBasics.Controls.Add(this.cmbTimer, 1, 1);
            this.tlpBasics.Controls.Add(this.lblDifficulty, 0, 2);
            this.tlpBasics.Controls.Add(this.cmbRoundCount, 1, 0);
            this.tlpBasics.Controls.Add(this.cmbDifficulty, 1, 2);
            this.tlpBasics.Dock = System.Windows.Forms.DockStyle.Top;
            this.tlpBasics.Location = new System.Drawing.Point(3, 26);
            this.tlpBasics.Name = "tlpBasics";
            this.tlpBasics.Padding = new System.Windows.Forms.Padding(8);
            this.tlpBasics.RowCount = 3;
            this.tlpBasics.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpBasics.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpBasics.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpBasics.Size = new System.Drawing.Size(508, 112);
            this.tlpBasics.TabIndex = 0;
            // 
            // lblRoundCount
            // 
            this.lblRoundCount.AutoSize = true;
            this.lblRoundCount.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblRoundCount.Location = new System.Drawing.Point(11, 8);
            this.lblRoundCount.Name = "lblRoundCount";
            this.lblRoundCount.Size = new System.Drawing.Size(144, 31);
            this.lblRoundCount.TabIndex = 0;
            this.lblRoundCount.Text = "ROUNDS";
            this.lblRoundCount.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblTimer
            // 
            this.lblTimer.AutoSize = true;
            this.lblTimer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTimer.Location = new System.Drawing.Point(11, 39);
            this.lblTimer.Name = "lblTimer";
            this.lblTimer.Size = new System.Drawing.Size(144, 31);
            this.lblTimer.TabIndex = 2;
            this.lblTimer.Text = "TIMER";
            this.lblTimer.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cmbTimer
            // 
            this.cmbTimer.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.cmbTimer.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTimer.FormattingEnabled = true;
            this.cmbTimer.Location = new System.Drawing.Point(161, 42);
            this.cmbTimer.Name = "cmbTimer";
            this.cmbTimer.Size = new System.Drawing.Size(121, 25);
            this.cmbTimer.TabIndex = 3;
            this.cmbTimer.SelectedIndexChanged += new System.EventHandler(this.cmbTimer_SelectedIndexChanged);
            // 
            // lblDifficulty
            // 
            this.lblDifficulty.AutoSize = true;
            this.lblDifficulty.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblDifficulty.Location = new System.Drawing.Point(11, 70);
            this.lblDifficulty.Name = "lblDifficulty";
            this.lblDifficulty.Size = new System.Drawing.Size(144, 34);
            this.lblDifficulty.TabIndex = 4;
            this.lblDifficulty.Text = "DIFFICULTY BAND";
            this.lblDifficulty.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cmbRoundCount
            // 
            this.cmbRoundCount.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.cmbRoundCount.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbRoundCount.FormattingEnabled = true;
            this.cmbRoundCount.Items.AddRange(new object[] {
            "5",
            "10",
            "15",
            "20"});
            this.cmbRoundCount.Location = new System.Drawing.Point(161, 11);
            this.cmbRoundCount.Name = "cmbRoundCount";
            this.cmbRoundCount.Size = new System.Drawing.Size(121, 25);
            this.cmbRoundCount.TabIndex = 1;
            this.cmbRoundCount.SelectedIndexChanged += new System.EventHandler(this.cmbRoundCount_SelectedIndexChanged);
            // 
            // cmbDifficulty
            // 
            this.cmbDifficulty.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.cmbDifficulty.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDifficulty.FormattingEnabled = true;
            this.cmbDifficulty.Location = new System.Drawing.Point(161, 73);
            this.cmbDifficulty.Name = "cmbDifficulty";
            this.cmbDifficulty.Size = new System.Drawing.Size(121, 25);
            this.cmbDifficulty.TabIndex = 5;
            this.cmbDifficulty.SelectedIndexChanged += new System.EventHandler(this.cmbDifficulty_SelectedIndexChanged);
            // 
            // gbPhishing
            // 
            this.gbPhishing.AutoSize = true;
            this.gbPhishing.BackColor = System.Drawing.Color.White;
            this.gbPhishing.Controls.Add(this.tlpPhishing);
            this.gbPhishing.Dock = System.Windows.Forms.DockStyle.Top;
            this.gbPhishing.Font = new System.Drawing.Font("Agency", 11F);
            this.gbPhishing.Location = new System.Drawing.Point(15, 362);
            this.gbPhishing.Name = "gbPhishing";
            this.gbPhishing.Size = new System.Drawing.Size(514, 157);
            this.gbPhishing.TabIndex = 3;
            this.gbPhishing.TabStop = false;
            this.gbPhishing.Text = "PHISHING SIMULATOR";
            // 
            // tlpPhishing
            // 
            this.tlpPhishing.AutoSize = true;
            this.tlpPhishing.ColumnCount = 2;
            this.tlpPhishing.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 180F));
            this.tlpPhishing.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpPhishing.Controls.Add(this.lblEmailCount, 0, 0);
            this.tlpPhishing.Controls.Add(this.cmbEmailCount, 1, 0);
            this.tlpPhishing.Controls.Add(this.chkIncludeAttachments, 0, 1);
            this.tlpPhishing.Controls.Add(this.chkIncludeLinks, 0, 2);
            this.tlpPhishing.Controls.Add(this.chkIncludeUrgency, 0, 3);
            this.tlpPhishing.Dock = System.Windows.Forms.DockStyle.Top;
            this.tlpPhishing.Location = new System.Drawing.Point(3, 26);
            this.tlpPhishing.Name = "tlpPhishing";
            this.tlpPhishing.Padding = new System.Windows.Forms.Padding(8);
            this.tlpPhishing.RowCount = 4;
            this.tlpPhishing.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpPhishing.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpPhishing.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpPhishing.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpPhishing.Size = new System.Drawing.Size(508, 128);
            this.tlpPhishing.TabIndex = 0;
            // 
            // lblEmailCount
            // 
            this.lblEmailCount.AutoSize = true;
            this.lblEmailCount.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblEmailCount.Location = new System.Drawing.Point(11, 8);
            this.lblEmailCount.Name = "lblEmailCount";
            this.lblEmailCount.Size = new System.Drawing.Size(174, 31);
            this.lblEmailCount.TabIndex = 0;
            this.lblEmailCount.Text = "EMAIL COUNT";
            this.lblEmailCount.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cmbEmailCount
            // 
            this.cmbEmailCount.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.cmbEmailCount.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbEmailCount.FormattingEnabled = true;
            this.cmbEmailCount.Location = new System.Drawing.Point(191, 11);
            this.cmbEmailCount.Name = "cmbEmailCount";
            this.cmbEmailCount.Size = new System.Drawing.Size(121, 25);
            this.cmbEmailCount.TabIndex = 1;
            this.cmbEmailCount.SelectedIndexChanged += new System.EventHandler(this.cmbEmailCount_SelectedIndexChanged);
            // 
            // chkIncludeAttachments
            // 
            this.chkIncludeAttachments.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.chkIncludeAttachments.AutoSize = true;
            this.tlpPhishing.SetColumnSpan(this.chkIncludeAttachments, 2);
            this.chkIncludeAttachments.Location = new System.Drawing.Point(11, 42);
            this.chkIncludeAttachments.Name = "chkIncludeAttachments";
            this.chkIncludeAttachments.Size = new System.Drawing.Size(342, 21);
            this.chkIncludeAttachments.TabIndex = 2;
            this.chkIncludeAttachments.Text = "INCLUDE ATTACHMENT TRAPS";
            this.chkIncludeAttachments.UseVisualStyleBackColor = true;
            this.chkIncludeAttachments.CheckedChanged += new System.EventHandler(this.chkIncludeAttachments_CheckedChanged);
            // 
            // chkIncludeLinks
            // 
            this.chkIncludeLinks.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.chkIncludeLinks.AutoSize = true;
            this.tlpPhishing.SetColumnSpan(this.chkIncludeLinks, 2);
            this.chkIncludeLinks.Location = new System.Drawing.Point(11, 69);
            this.chkIncludeLinks.Name = "chkIncludeLinks";
            this.chkIncludeLinks.Size = new System.Drawing.Size(318, 21);
            this.chkIncludeLinks.TabIndex = 3;
            this.chkIncludeLinks.Text = "INCLUDE SUSPICIOUS LINKS";
            this.chkIncludeLinks.UseVisualStyleBackColor = true;
            this.chkIncludeLinks.CheckedChanged += new System.EventHandler(this.chkIncludeLinks_CheckedChanged);
            // 
            // chkIncludeUrgency
            // 
            this.chkIncludeUrgency.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.chkIncludeUrgency.AutoSize = true;
            this.tlpPhishing.SetColumnSpan(this.chkIncludeUrgency, 2);
            this.chkIncludeUrgency.Location = new System.Drawing.Point(11, 96);
            this.chkIncludeUrgency.Name = "chkIncludeUrgency";
            this.chkIncludeUrgency.Size = new System.Drawing.Size(444, 21);
            this.chkIncludeUrgency.TabIndex = 4;
            this.chkIncludeUrgency.Text = "INCLUDE URGENCY / PRESSURE TACTICS";
            this.chkIncludeUrgency.UseVisualStyleBackColor = true;
            this.chkIncludeUrgency.CheckedChanged += new System.EventHandler(this.chkIncludeUrgency_CheckedChanged);
            // 
            // gbAuthentication
            // 
            this.gbAuthentication.AutoSize = true;
            this.gbAuthentication.BackColor = System.Drawing.Color.White;
            this.gbAuthentication.Controls.Add(this.tlpAuthentication);
            this.gbAuthentication.Dock = System.Windows.Forms.DockStyle.Top;
            this.gbAuthentication.Font = new System.Drawing.Font("Agency", 11F);
            this.gbAuthentication.Location = new System.Drawing.Point(15, 525);
            this.gbAuthentication.Name = "gbAuthentication";
            this.gbAuthentication.Size = new System.Drawing.Size(514, 153);
            this.gbAuthentication.TabIndex = 4;
            this.gbAuthentication.TabStop = false;
            this.gbAuthentication.Text = "AUTHENTICATION DEFENSE";
            // 
            // tlpAuthentication
            // 
            this.tlpAuthentication.AutoSize = true;
            this.tlpAuthentication.ColumnCount = 1;
            this.tlpAuthentication.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpAuthentication.Controls.Add(this.chkIncludeCredentialAttacks, 0, 0);
            this.tlpAuthentication.Controls.Add(this.chkIncludeMfaScenarios, 0, 1);
            this.tlpAuthentication.Controls.Add(this.chkIncludeRecoveryScenarios, 0, 2);
            this.tlpAuthentication.Controls.Add(this.chkIncludeSessionScenarios, 0, 3);
            this.tlpAuthentication.Dock = System.Windows.Forms.DockStyle.Top;
            this.tlpAuthentication.Location = new System.Drawing.Point(3, 26);
            this.tlpAuthentication.Name = "tlpAuthentication";
            this.tlpAuthentication.Padding = new System.Windows.Forms.Padding(8);
            this.tlpAuthentication.RowCount = 4;
            this.tlpAuthentication.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpAuthentication.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpAuthentication.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpAuthentication.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpAuthentication.Size = new System.Drawing.Size(508, 124);
            this.tlpAuthentication.TabIndex = 0;
            // 
            // chkIncludeCredentialAttacks
            // 
            this.chkIncludeCredentialAttacks.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.chkIncludeCredentialAttacks.AutoSize = true;
            this.chkIncludeCredentialAttacks.Location = new System.Drawing.Point(11, 11);
            this.chkIncludeCredentialAttacks.Name = "chkIncludeCredentialAttacks";
            this.chkIncludeCredentialAttacks.Size = new System.Drawing.Size(467, 21);
            this.chkIncludeCredentialAttacks.TabIndex = 0;
            this.chkIncludeCredentialAttacks.Text = "INCLUDE CREDENTIAL ATTACK SCENARIOS";
            this.chkIncludeCredentialAttacks.UseVisualStyleBackColor = true;
            this.chkIncludeCredentialAttacks.CheckedChanged += new System.EventHandler(this.chkIncludeStrength_CheckedChanged);
            // 
            // chkIncludeMfaScenarios
            // 
            this.chkIncludeMfaScenarios.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.chkIncludeMfaScenarios.AutoSize = true;
            this.chkIncludeMfaScenarios.Location = new System.Drawing.Point(11, 38);
            this.chkIncludeMfaScenarios.Name = "chkIncludeMfaScenarios";
            this.chkIncludeMfaScenarios.Size = new System.Drawing.Size(398, 21);
            this.chkIncludeMfaScenarios.TabIndex = 1;
            this.chkIncludeMfaScenarios.Text = "INCLUDE MFA / STEP-UP SCENARIOS";
            this.chkIncludeMfaScenarios.UseVisualStyleBackColor = true;
            this.chkIncludeMfaScenarios.CheckedChanged += new System.EventHandler(this.chkIncludeReuse_CheckedChanged);
            // 
            // chkIncludeRecoveryScenarios
            // 
            this.chkIncludeRecoveryScenarios.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.chkIncludeRecoveryScenarios.AutoSize = true;
            this.chkIncludeRecoveryScenarios.Font = new System.Drawing.Font("Agency", 10.5F);
            this.chkIncludeRecoveryScenarios.Location = new System.Drawing.Point(11, 65);
            this.chkIncludeRecoveryScenarios.Name = "chkIncludeRecoveryScenarios";
            this.chkIncludeRecoveryScenarios.Size = new System.Drawing.Size(458, 21);
            this.chkIncludeRecoveryScenarios.TabIndex = 2;
            this.chkIncludeRecoveryScenarios.Text = "INCLUDE RECOVERY / HELPDESK SCENARIOS";
            this.chkIncludeRecoveryScenarios.UseVisualStyleBackColor = true;
            this.chkIncludeRecoveryScenarios.CheckedChanged += new System.EventHandler(this.chkIncludeManager_CheckedChanged);
            // 
            // chkIncludeSessionScenarios
            // 
            this.chkIncludeSessionScenarios.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.chkIncludeSessionScenarios.AutoSize = true;
            this.chkIncludeSessionScenarios.Font = new System.Drawing.Font("Agency", 10.5F);
            this.chkIncludeSessionScenarios.Location = new System.Drawing.Point(11, 92);
            this.chkIncludeSessionScenarios.Name = "chkIncludeSessionScenarios";
            this.chkIncludeSessionScenarios.Size = new System.Drawing.Size(470, 21);
            this.chkIncludeSessionScenarios.TabIndex = 3;
            this.chkIncludeSessionScenarios.Text = "INCLUDE SESSION / LEGACY AUTH SCENARIOS";
            this.chkIncludeSessionScenarios.UseVisualStyleBackColor = true;
            this.chkIncludeSessionScenarios.CheckedChanged += new System.EventHandler(this.chkIncludePatterns_CheckedChanged);
            // 
            // gbAdvanced
            // 
            this.gbAdvanced.AutoSize = true;
            this.gbAdvanced.BackColor = System.Drawing.Color.White;
            this.gbAdvanced.Controls.Add(this.tlpAdvanced);
            this.gbAdvanced.Dock = System.Windows.Forms.DockStyle.Top;
            this.gbAdvanced.Font = new System.Drawing.Font("Agency", 11F);
            this.gbAdvanced.Location = new System.Drawing.Point(15, 684);
            this.gbAdvanced.Name = "gbAdvanced";
            this.gbAdvanced.Size = new System.Drawing.Size(514, 113);
            this.gbAdvanced.TabIndex = 5;
            this.gbAdvanced.TabStop = false;
            this.gbAdvanced.Text = "ADVANCED (OPTIONAL)";
            // 
            // tlpAdvanced
            // 
            this.tlpAdvanced.AutoSize = true;
            this.tlpAdvanced.ColumnCount = 2;
            this.tlpAdvanced.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this.tlpAdvanced.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpAdvanced.Controls.Add(this.lblHints, 0, 0);
            this.tlpAdvanced.Controls.Add(this.cmbHints, 1, 0);
            this.tlpAdvanced.Controls.Add(this.lblFeedbackMode, 0, 1);
            this.tlpAdvanced.Controls.Add(this.cmbFeedbackMode, 1, 1);
            this.tlpAdvanced.Dock = System.Windows.Forms.DockStyle.Top;
            this.tlpAdvanced.Location = new System.Drawing.Point(3, 26);
            this.tlpAdvanced.Name = "tlpAdvanced";
            this.tlpAdvanced.Padding = new System.Windows.Forms.Padding(8);
            this.tlpAdvanced.RowCount = 2;
            this.tlpAdvanced.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpAdvanced.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpAdvanced.Size = new System.Drawing.Size(508, 84);
            this.tlpAdvanced.TabIndex = 0;
            // 
            // lblHints
            // 
            this.lblHints.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblHints.AutoSize = true;
            this.lblHints.Location = new System.Drawing.Point(48, 16);
            this.lblHints.Name = "lblHints";
            this.lblHints.Size = new System.Drawing.Size(69, 17);
            this.lblHints.TabIndex = 0;
            this.lblHints.Text = "HINTS";
            this.lblHints.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cmbHints
            // 
            this.cmbHints.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.cmbHints.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbHints.FormattingEnabled = true;
            this.cmbHints.Location = new System.Drawing.Point(161, 12);
            this.cmbHints.Name = "cmbHints";
            this.cmbHints.Size = new System.Drawing.Size(121, 25);
            this.cmbHints.TabIndex = 1;
            this.cmbHints.SelectedIndexChanged += new System.EventHandler(this.cmbHints_SelectedIndexChanged);
            // 
            // lblFeedbackMode
            // 
            this.lblFeedbackMode.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblFeedbackMode.AutoSize = true;
            this.lblFeedbackMode.Location = new System.Drawing.Point(23, 50);
            this.lblFeedbackMode.Name = "lblFeedbackMode";
            this.lblFeedbackMode.Size = new System.Drawing.Size(119, 17);
            this.lblFeedbackMode.TabIndex = 2;
            this.lblFeedbackMode.Text = "FEEDBACK";
            this.lblFeedbackMode.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cmbFeedbackMode
            // 
            this.cmbFeedbackMode.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.cmbFeedbackMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFeedbackMode.FormattingEnabled = true;
            this.cmbFeedbackMode.Location = new System.Drawing.Point(161, 45);
            this.cmbFeedbackMode.Name = "cmbFeedbackMode";
            this.cmbFeedbackMode.Size = new System.Drawing.Size(121, 25);
            this.cmbFeedbackMode.TabIndex = 3;
            this.cmbFeedbackMode.SelectedIndexChanged += new System.EventHandler(this.cmbFeedbackMode_SelectedIndexChanged);
            // 
            // gbSummary
            // 
            this.gbSummary.AutoSize = true;
            this.gbSummary.BackColor = System.Drawing.Color.White;
            this.gbSummary.Controls.Add(this.lblSummary);
            this.gbSummary.Dock = System.Windows.Forms.DockStyle.Top;
            this.gbSummary.Font = new System.Drawing.Font("Agency", 11F);
            this.gbSummary.Location = new System.Drawing.Point(15, 803);
            this.gbSummary.Name = "gbSummary";
            this.gbSummary.Size = new System.Drawing.Size(514, 69);
            this.gbSummary.TabIndex = 6;
            this.gbSummary.TabStop = false;
            this.gbSummary.Text = "SUMMARY";
            // 
            // lblSummary
            // 
            this.lblSummary.AutoSize = true;
            this.lblSummary.Location = new System.Drawing.Point(6, 26);
            this.lblSummary.MaximumSize = new System.Drawing.Size(540, 0);
            this.lblSummary.Name = "lblSummary";
            this.lblSummary.Size = new System.Drawing.Size(500, 17);
            this.lblSummary.TabIndex = 0;
            this.lblSummary.Text = "CURRENT SETUP SUMMARY WILL APPEAR HERE.";
            // 
            // tlpPrefsButtons
            // 
            this.tlpPrefsButtons.BackColor = System.Drawing.Color.White;
            this.tlpPrefsButtons.ColumnCount = 3;
            this.tlpPrefsButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 38.0597F));
            this.tlpPrefsButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 61.9403F));
            this.tlpPrefsButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 131F));
            this.tlpPrefsButtons.Controls.Add(this.btnCancel, 2, 0);
            this.tlpPrefsButtons.Controls.Add(this.btnUseDefaults, 0, 0);
            this.tlpPrefsButtons.Controls.Add(this.btnApply, 1, 0);
            this.tlpPrefsButtons.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpPrefsButtons.Location = new System.Drawing.Point(15, 644);
            this.tlpPrefsButtons.Name = "tlpPrefsButtons";
            this.tlpPrefsButtons.RowCount = 1;
            this.tlpPrefsButtons.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpPrefsButtons.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpPrefsButtons.Size = new System.Drawing.Size(570, 58);
            this.tlpPrefsButtons.TabIndex = 2;
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnCancel.AutoSize = true;
            this.btnCancel.BackColor = System.Drawing.Color.Crimson;
            this.btnCancel.Font = new System.Drawing.Font("Muro", 10F);
            this.btnCancel.ForeColor = System.Drawing.Color.White;
            this.btnCancel.Location = new System.Drawing.Point(441, 9);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Padding = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.btnCancel.Size = new System.Drawing.Size(91, 40);
            this.btnCancel.Style.BackColor = System.Drawing.Color.Crimson;
            this.btnCancel.Style.ForeColor = System.Drawing.Color.White;
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "CANCEL";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnUseDefaults
            // 
            this.btnUseDefaults.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnUseDefaults.AutoSize = true;
            this.btnUseDefaults.BackColor = System.Drawing.Color.RoyalBlue;
            this.btnUseDefaults.Font = new System.Drawing.Font("Muro", 10F);
            this.btnUseDefaults.ForeColor = System.Drawing.Color.White;
            this.btnUseDefaults.Location = new System.Drawing.Point(3, 9);
            this.btnUseDefaults.Name = "btnUseDefaults";
            this.btnUseDefaults.Padding = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.btnUseDefaults.Size = new System.Drawing.Size(142, 40);
            this.btnUseDefaults.Style.BackColor = System.Drawing.Color.RoyalBlue;
            this.btnUseDefaults.Style.ForeColor = System.Drawing.Color.White;
            this.btnUseDefaults.TabIndex = 0;
            this.btnUseDefaults.Text = "USE DEFAULTS";
            this.btnUseDefaults.UseVisualStyleBackColor = false;
            this.btnUseDefaults.Click += new System.EventHandler(this.btnUseDefaults_Click);
            // 
            // btnApply
            // 
            this.btnApply.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnApply.AutoSize = true;
            this.btnApply.BackColor = System.Drawing.Color.SeaGreen;
            this.btnApply.Font = new System.Drawing.Font("Muro", 10F);
            this.btnApply.ForeColor = System.Drawing.Color.White;
            this.btnApply.Location = new System.Drawing.Point(354, 9);
            this.btnApply.Name = "btnApply";
            this.btnApply.Padding = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.btnApply.Size = new System.Drawing.Size(81, 40);
            this.btnApply.Style.BackColor = System.Drawing.Color.SeaGreen;
            this.btnApply.Style.ForeColor = System.Drawing.Color.White;
            this.btnApply.TabIndex = 1;
            this.btnApply.Text = "APPLY";
            this.btnApply.UseVisualStyleBackColor = false;
            this.btnApply.Click += new System.EventHandler(this.btnApply_Click);
            // 
            // MiniGamePreferencesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gainsboro;
            this.ClientSize = new System.Drawing.Size(604, 721);
            this.Controls.Add(this.tlpPrefsRoot);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(620, 760);
            this.Name = "MiniGamePreferencesForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Style.BackColor = System.Drawing.Color.Gainsboro;
            this.Style.MdiChild.IconHorizontalAlignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.Style.MdiChild.IconVerticalAlignment = System.Windows.Forms.VisualStyles.VerticalAlignment.Center;
            this.Text = "Mini Game Preferences";
            this.Load += new System.EventHandler(this.MiniGamePreferencesForm_Load);
            this.tlpPrefsRoot.ResumeLayout(false);
            this.pnlPrefsHeader.ResumeLayout(false);
            this.pnlPrefsHeader.PerformLayout();
            this.pnlPrefsBody.ResumeLayout(false);
            this.pnlPrefsBody.PerformLayout();
            this.tlpPrefsSections.ResumeLayout(false);
            this.tlpPrefsSections.PerformLayout();
            this.gbGame.ResumeLayout(false);
            this.pnlGame.ResumeLayout(false);
            this.pnlGame.PerformLayout();
            this.gbMode.ResumeLayout(false);
            this.pnlMode.ResumeLayout(false);
            this.pnlMode.PerformLayout();
            this.gbBasics.ResumeLayout(false);
            this.gbBasics.PerformLayout();
            this.tlpBasics.ResumeLayout(false);
            this.tlpBasics.PerformLayout();
            this.gbPhishing.ResumeLayout(false);
            this.gbPhishing.PerformLayout();
            this.tlpPhishing.ResumeLayout(false);
            this.tlpPhishing.PerformLayout();
            this.gbAuthentication.ResumeLayout(false);
            this.gbAuthentication.PerformLayout();
            this.tlpAuthentication.ResumeLayout(false);
            this.tlpAuthentication.PerformLayout();
            this.gbAdvanced.ResumeLayout(false);
            this.gbAdvanced.PerformLayout();
            this.tlpAdvanced.ResumeLayout(false);
            this.tlpAdvanced.PerformLayout();
            this.gbSummary.ResumeLayout(false);
            this.gbSummary.PerformLayout();
            this.tlpPrefsButtons.ResumeLayout(false);
            this.tlpPrefsButtons.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tlpPrefsRoot;
        private System.Windows.Forms.Panel pnlPrefsHeader;
        private System.Windows.Forms.Label lblPrefsSub;
        private System.Windows.Forms.Label lblPrefsTitle;
        private System.Windows.Forms.Panel pnlPrefsBody;
        private System.Windows.Forms.TableLayoutPanel tlpPrefsSections;
        private System.Windows.Forms.GroupBox gbGame;
        private System.Windows.Forms.Panel pnlGame;
        private System.Windows.Forms.ComboBox cmbMiniGameType;
        private System.Windows.Forms.Label lblGameType;
        private System.Windows.Forms.GroupBox gbMode;
        private System.Windows.Forms.Panel pnlMode;
        private System.Windows.Forms.RadioButton rbDefault;
        private System.Windows.Forms.RadioButton rbCustom;
        private System.Windows.Forms.GroupBox gbBasics;
        private System.Windows.Forms.TableLayoutPanel tlpBasics;
        private System.Windows.Forms.Label lblRoundCount;
        private System.Windows.Forms.ComboBox cmbRoundCount;
        private System.Windows.Forms.Label lblTimer;
        private System.Windows.Forms.ComboBox cmbTimer;
        private System.Windows.Forms.Label lblDifficulty;
        private System.Windows.Forms.ComboBox cmbDifficulty;
        private System.Windows.Forms.GroupBox gbPhishing;
        private System.Windows.Forms.TableLayoutPanel tlpPhishing;
        private System.Windows.Forms.Label lblEmailCount;
        private System.Windows.Forms.ComboBox cmbEmailCount;
        private System.Windows.Forms.CheckBox chkIncludeAttachments;
        private System.Windows.Forms.CheckBox chkIncludeLinks;
        private System.Windows.Forms.CheckBox chkIncludeUrgency;
        private System.Windows.Forms.GroupBox gbAuthentication;
        private System.Windows.Forms.TableLayoutPanel tlpAuthentication;
        private System.Windows.Forms.CheckBox chkIncludeCredentialAttacks;
        private System.Windows.Forms.CheckBox chkIncludeMfaScenarios;
        private System.Windows.Forms.CheckBox chkIncludeRecoveryScenarios;
        private System.Windows.Forms.CheckBox chkIncludeSessionScenarios;
        private System.Windows.Forms.GroupBox gbAdvanced;
        private System.Windows.Forms.TableLayoutPanel tlpAdvanced;
        private System.Windows.Forms.Label lblHints;
        private System.Windows.Forms.ComboBox cmbHints;
        private System.Windows.Forms.Label lblFeedbackMode;
        private System.Windows.Forms.ComboBox cmbFeedbackMode;
        private System.Windows.Forms.GroupBox gbSummary;
        private System.Windows.Forms.Label lblSummary;
        private Syncfusion.WinForms.Controls.SfButton btnUseDefaults;
        private System.Windows.Forms.TableLayoutPanel tlpPrefsButtons;
        private Syncfusion.WinForms.Controls.SfButton btnApply;
        private Syncfusion.WinForms.Controls.SfButton btnCancel;
    }
}