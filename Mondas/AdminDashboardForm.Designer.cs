namespace Mondas
{
    partial class AdminDashboardForm
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
            System.Windows.Forms.Panel pnlToolbar;
            this.tlpToolbar = new System.Windows.Forms.TableLayoutPanel();
            this.lblRange = new System.Windows.Forms.Label();
            this.cmbRange = new System.Windows.Forms.ComboBox();
            this.lblContentType = new System.Windows.Forms.Label();
            this.cmbContentType = new System.Windows.Forms.ComboBox();
            this.lblSearch = new System.Windows.Forms.Label();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.btnRefresh = new Syncfusion.WinForms.Controls.SfButton();
            this.btnExportCsv = new Syncfusion.WinForms.Controls.SfButton();
            this.pnlSidebar = new System.Windows.Forms.Panel();
            this.pnlSidebarSpacer = new System.Windows.Forms.Panel();
            this.lblAdminBadge = new System.Windows.Forms.Label();
            this.lblMondas = new System.Windows.Forms.Label();
            this.pnlContent = new System.Windows.Forms.Panel();
            this.tlpPage = new System.Windows.Forms.TableLayoutPanel();
            this.pnlFooter = new System.Windows.Forms.Panel();
            this.lblFooterUser = new System.Windows.Forms.Label();
            this.lblFooterLeft = new System.Windows.Forms.Label();
            this.tlpStats = new System.Windows.Forms.TableLayoutPanel();
            this.pnlTotalUsers = new System.Windows.Forms.Panel();
            this.lblTotalUsersValue = new System.Windows.Forms.Label();
            this.lblTotalUsersTitle = new System.Windows.Forms.Label();
            this.pnlActiveToday = new System.Windows.Forms.Panel();
            this.lblActiveTodayValue = new System.Windows.Forms.Label();
            this.lblActiveTodayTitle = new System.Windows.Forms.Label();
            this.pnlAvgAccuracy = new System.Windows.Forms.Panel();
            this.lblAvgAccuracyValue = new System.Windows.Forms.Label();
            this.lblAvgAccuracyTitle = new System.Windows.Forms.Label();
            this.pnlAtRiskUsers = new System.Windows.Forms.Panel();
            this.lblAtRiskUsersValue = new System.Windows.Forms.Label();
            this.lblAtRiskUsersTitle = new System.Windows.Forms.Label();
            this.pnlTotalContent = new System.Windows.Forms.Panel();
            this.lblTotalContentValue = new System.Windows.Forms.Label();
            this.lblTotalContentTitle = new System.Windows.Forms.Label();
            this.tlpHeader = new System.Windows.Forms.TableLayoutPanel();
            this.pnlHeaderRight = new System.Windows.Forms.Panel();
            this.btnLogout = new System.Windows.Forms.Button();
            this.lblAdminUser = new System.Windows.Forms.Label();
            this.pnlHeaderLeft = new System.Windows.Forms.Panel();
            this.lblSub = new System.Windows.Forms.Label();
            this.lblWelcome = new System.Windows.Forms.Label();
            this.tlpMain = new System.Windows.Forms.TableLayoutPanel();
            this.tlpLeft = new System.Windows.Forms.TableLayoutPanel();
            this.gbUsersOverview = new System.Windows.Forms.GroupBox();
            this.dgvUsers = new System.Windows.Forms.DataGridView();
            this.colUserName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAttempts = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAccuracy = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAvgTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colWeakestTopic = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colLastActive = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gbTopMisconceptions = new System.Windows.Forms.GroupBox();
            this.dgvMisconceptions = new System.Windows.Forms.DataGridView();
            this.colMisTag = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMisCount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMisLastSeen = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gbRecentActivity = new System.Windows.Forms.GroupBox();
            this.dgvRecentActivity = new System.Windows.Forms.DataGridView();
            this.colActivityUser = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colActivityMode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colActivityResult = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colActivityWhen = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gbContentBank = new System.Windows.Forms.GroupBox();
            this.tlpContentBank = new System.Windows.Forms.TableLayoutPanel();
            this.tlpBankToolbar = new System.Windows.Forms.TableLayoutPanel();
            this.lblBankTopic = new System.Windows.Forms.Label();
            this.cmbBankTopic = new System.Windows.Forms.ComboBox();
            this.lblBankDifficulty = new System.Windows.Forms.Label();
            this.cmbBankDifficulty = new System.Windows.Forms.ComboBox();
            this.btnNewItem = new Syncfusion.WinForms.Controls.SfButton();
            this.btnDuplicateItem = new Syncfusion.WinForms.Controls.SfButton();
            this.btnDeleteItem = new Syncfusion.WinForms.Controls.SfButton();
            this.splitBank = new System.Windows.Forms.SplitContainer();
            this.dgvBankItems = new System.Windows.Forms.DataGridView();
            this.colBankKey = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colBankTitle = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colBankType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabEditor = new System.Windows.Forms.TabControl();
            this.tabQuizQuestion = new System.Windows.Forms.TabPage();
            this.tlpQuizEditor = new System.Windows.Forms.TableLayoutPanel();
            this.pnlQuizEditorLeft = new System.Windows.Forms.Panel();
            this.rtbQuizExplanation = new System.Windows.Forms.RichTextBox();
            this.lblQuizExplanation = new System.Windows.Forms.Label();
            this.dgvQuizOptions = new System.Windows.Forms.DataGridView();
            this.colOptionText = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colOptionCorrect = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.lblQuizOptions = new System.Windows.Forms.Label();
            this.rtbQuizQuestionText = new System.Windows.Forms.RichTextBox();
            this.lblQuizQuestionText = new System.Windows.Forms.Label();
            this.pnlQuizEditorRight = new System.Windows.Forms.Panel();
            this.txtMisTags = new System.Windows.Forms.TextBox();
            this.lblMisTags = new System.Windows.Forms.Label();
            this.cmbQuizType = new System.Windows.Forms.ComboBox();
            this.lblQuizType = new System.Windows.Forms.Label();
            this.cmbQuizDifficulty = new System.Windows.Forms.ComboBox();
            this.lblQuizDifficulty = new System.Windows.Forms.Label();
            this.cmbQuizTopic = new System.Windows.Forms.ComboBox();
            this.lblQuizTopic = new System.Windows.Forms.Label();
            this.tabPhishingEmail = new System.Windows.Forms.TabPage();
            this.tlpPhishEditor = new System.Windows.Forms.TableLayoutPanel();
            this.pnlPhishLeft = new System.Windows.Forms.Panel();
            this.rtbPhishExplanation = new System.Windows.Forms.RichTextBox();
            this.lblPhishExplanation = new System.Windows.Forms.Label();
            this.rtbPhishBody = new System.Windows.Forms.RichTextBox();
            this.lblPhishBody = new System.Windows.Forms.Label();
            this.pnlPhishRight = new System.Windows.Forms.Panel();
            this.txtPhishTags = new System.Windows.Forms.TextBox();
            this.lblPhishTags = new System.Windows.Forms.Label();
            this.txtLinkDisplayText = new System.Windows.Forms.TextBox();
            this.lblLinkDisplayText = new System.Windows.Forms.Label();
            this.txtAttachmentName = new System.Windows.Forms.TextBox();
            this.txtLinkUrl = new System.Windows.Forms.TextBox();
            this.chkHasAttachment = new System.Windows.Forms.CheckBox();
            this.chkHasLink = new System.Windows.Forms.CheckBox();
            this.chkIsPhishing = new System.Windows.Forms.CheckBox();
            this.cmbPhishDifficulty = new System.Windows.Forms.ComboBox();
            this.lblPhishDifficulty = new System.Windows.Forms.Label();
            this.txtPhishSubject = new System.Windows.Forms.TextBox();
            this.lblSubject = new System.Windows.Forms.Label();
            this.txtToEmail = new System.Windows.Forms.TextBox();
            this.lblToEmail = new System.Windows.Forms.Label();
            this.txtReplyTo = new System.Windows.Forms.TextBox();
            this.lblReplyTo = new System.Windows.Forms.Label();
            this.txtSenderEmail = new System.Windows.Forms.TextBox();
            this.lblSenderEmail = new System.Windows.Forms.Label();
            this.txtSenderName = new System.Windows.Forms.TextBox();
            this.lblSenderName = new System.Windows.Forms.Label();
            this.tabAuthScenario = new System.Windows.Forms.TabPage();
            this.tlpAuthEditor = new System.Windows.Forms.TableLayoutPanel();
            this.pnlAuthLeft = new System.Windows.Forms.Panel();
            this.txtScenarioTags = new System.Windows.Forms.TextBox();
            this.lblScenarioTags = new System.Windows.Forms.Label();
            this.rtbScenarioHints = new System.Windows.Forms.RichTextBox();
            this.lblScenarioHints = new System.Windows.Forms.Label();
            this.rtbScenarioBody = new System.Windows.Forms.RichTextBox();
            this.lblScenarioBody = new System.Windows.Forms.Label();
            this.txtScenarioTitle = new System.Windows.Forms.TextBox();
            this.lblScenarioTitle = new System.Windows.Forms.Label();
            this.pnlAuthRight = new System.Windows.Forms.Panel();
            this.gbAuthRequirements = new System.Windows.Forms.GroupBox();
            this.chkReqAlertOnSuspicious = new System.Windows.Forms.CheckBox();
            this.chkReqDeviceBinding = new System.Windows.Forms.CheckBox();
            this.chkReqLegacyBlock = new System.Windows.Forms.CheckBox();
            this.chkReqStepUp = new System.Windows.Forms.CheckBox();
            this.chkReqPhishResistant = new System.Windows.Forms.CheckBox();
            this.chkReqMfa = new System.Windows.Forms.CheckBox();
            this.cmbRecRecovery = new System.Windows.Forms.ComboBox();
            this.cmbRecAuthMethod = new System.Windows.Forms.ComboBox();
            this.cmbAuthDifficulty = new System.Windows.Forms.ComboBox();
            this.cmbGoalType = new System.Windows.Forms.ComboBox();
            this.cmbThreatType = new System.Windows.Forms.ComboBox();
            this.cmbRecSession = new System.Windows.Forms.ComboBox();
            this.lblRecSession = new System.Windows.Forms.Label();
            this.lblRecRecovery = new System.Windows.Forms.Label();
            this.lblRecAuthMethod = new System.Windows.Forms.Label();
            this.lblAuthDifficulty = new System.Windows.Forms.Label();
            this.lblGoalType = new System.Windows.Forms.Label();
            this.lblThreatType = new System.Windows.Forms.Label();
            this.tlpBankActions = new System.Windows.Forms.TableLayoutPanel();
            this.btnRevertChanges = new Syncfusion.WinForms.Controls.SfButton();
            this.btnSaveAll = new Syncfusion.WinForms.Controls.SfButton();
            this.btnSaveItem = new Syncfusion.WinForms.Controls.SfButton();
            this.btnLoadSelected = new Syncfusion.WinForms.Controls.SfButton();
            pnlToolbar = new System.Windows.Forms.Panel();
            pnlToolbar.SuspendLayout();
            this.tlpToolbar.SuspendLayout();
            this.pnlSidebar.SuspendLayout();
            this.pnlContent.SuspendLayout();
            this.tlpPage.SuspendLayout();
            this.pnlFooter.SuspendLayout();
            this.tlpStats.SuspendLayout();
            this.pnlTotalUsers.SuspendLayout();
            this.pnlActiveToday.SuspendLayout();
            this.pnlAvgAccuracy.SuspendLayout();
            this.pnlAtRiskUsers.SuspendLayout();
            this.pnlTotalContent.SuspendLayout();
            this.tlpHeader.SuspendLayout();
            this.pnlHeaderRight.SuspendLayout();
            this.pnlHeaderLeft.SuspendLayout();
            this.tlpMain.SuspendLayout();
            this.tlpLeft.SuspendLayout();
            this.gbUsersOverview.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsers)).BeginInit();
            this.gbTopMisconceptions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMisconceptions)).BeginInit();
            this.gbRecentActivity.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRecentActivity)).BeginInit();
            this.gbContentBank.SuspendLayout();
            this.tlpContentBank.SuspendLayout();
            this.tlpBankToolbar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitBank)).BeginInit();
            this.splitBank.Panel1.SuspendLayout();
            this.splitBank.Panel2.SuspendLayout();
            this.splitBank.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBankItems)).BeginInit();
            this.tabEditor.SuspendLayout();
            this.tabQuizQuestion.SuspendLayout();
            this.tlpQuizEditor.SuspendLayout();
            this.pnlQuizEditorLeft.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvQuizOptions)).BeginInit();
            this.pnlQuizEditorRight.SuspendLayout();
            this.tabPhishingEmail.SuspendLayout();
            this.tlpPhishEditor.SuspendLayout();
            this.pnlPhishLeft.SuspendLayout();
            this.pnlPhishRight.SuspendLayout();
            this.tabAuthScenario.SuspendLayout();
            this.tlpAuthEditor.SuspendLayout();
            this.pnlAuthLeft.SuspendLayout();
            this.pnlAuthRight.SuspendLayout();
            this.gbAuthRequirements.SuspendLayout();
            this.tlpBankActions.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlToolbar
            // 
            pnlToolbar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            pnlToolbar.Controls.Add(this.tlpToolbar);
            pnlToolbar.Dock = System.Windows.Forms.DockStyle.Fill;
            pnlToolbar.Location = new System.Drawing.Point(0, 198);
            pnlToolbar.Margin = new System.Windows.Forms.Padding(0, 0, 0, 10);
            pnlToolbar.Name = "pnlToolbar";
            pnlToolbar.Padding = new System.Windows.Forms.Padding(8, 6, 8, 6);
            pnlToolbar.Size = new System.Drawing.Size(1673, 48);
            pnlToolbar.TabIndex = 3;
            // 
            // tlpToolbar
            // 
            this.tlpToolbar.CausesValidation = false;
            this.tlpToolbar.ColumnCount = 8;
            this.tlpToolbar.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 141F));
            this.tlpToolbar.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 157F));
            this.tlpToolbar.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 67F));
            this.tlpToolbar.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 156F));
            this.tlpToolbar.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 96F));
            this.tlpToolbar.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpToolbar.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 126F));
            this.tlpToolbar.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 120F));
            this.tlpToolbar.Controls.Add(this.lblRange, 0, 0);
            this.tlpToolbar.Controls.Add(this.cmbRange, 1, 0);
            this.tlpToolbar.Controls.Add(this.lblContentType, 2, 0);
            this.tlpToolbar.Controls.Add(this.cmbContentType, 3, 0);
            this.tlpToolbar.Controls.Add(this.lblSearch, 4, 0);
            this.tlpToolbar.Controls.Add(this.txtSearch, 5, 0);
            this.tlpToolbar.Controls.Add(this.btnRefresh, 6, 0);
            this.tlpToolbar.Controls.Add(this.btnExportCsv, 7, 0);
            this.tlpToolbar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpToolbar.Location = new System.Drawing.Point(8, 6);
            this.tlpToolbar.Margin = new System.Windows.Forms.Padding(0);
            this.tlpToolbar.Name = "tlpToolbar";
            this.tlpToolbar.RowCount = 1;
            this.tlpToolbar.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpToolbar.Size = new System.Drawing.Size(1655, 34);
            this.tlpToolbar.TabIndex = 0;
            // 
            // lblRange
            // 
            this.lblRange.AutoSize = true;
            this.lblRange.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblRange.Font = new System.Drawing.Font("Agency", 10.5F);
            this.lblRange.Location = new System.Drawing.Point(3, 0);
            this.lblRange.Name = "lblRange";
            this.lblRange.Size = new System.Drawing.Size(135, 34);
            this.lblRange.TabIndex = 0;
            this.lblRange.Text = "DATE RANGE";
            this.lblRange.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cmbRange
            // 
            this.cmbRange.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmbRange.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbRange.Font = new System.Drawing.Font("Agency", 10F);
            this.cmbRange.FormattingEnabled = true;
            this.cmbRange.Items.AddRange(new object[] {
            "All Time",
            "Today",
            "Last 7 Days",
            "Last 30 Days"});
            this.cmbRange.Location = new System.Drawing.Point(141, 4);
            this.cmbRange.Margin = new System.Windows.Forms.Padding(0, 4, 10, 4);
            this.cmbRange.Name = "cmbRange";
            this.cmbRange.Size = new System.Drawing.Size(147, 23);
            this.cmbRange.TabIndex = 1;
            this.cmbRange.SelectedIndexChanged += new System.EventHandler(this.cmbRange_SelectedIndexChanged);
            // 
            // lblContentType
            // 
            this.lblContentType.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblContentType.AutoSize = true;
            this.lblContentType.Font = new System.Drawing.Font("Agency", 10.5F);
            this.lblContentType.Location = new System.Drawing.Point(301, 9);
            this.lblContentType.Name = "lblContentType";
            this.lblContentType.Size = new System.Drawing.Size(56, 16);
            this.lblContentType.TabIndex = 2;
            this.lblContentType.Text = "TYPE";
            // 
            // cmbContentType
            // 
            this.cmbContentType.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmbContentType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbContentType.Font = new System.Drawing.Font("Agency", 10F);
            this.cmbContentType.FormattingEnabled = true;
            this.cmbContentType.Items.AddRange(new object[] {
            "All",
            "Quiz Question",
            "Phishing Email",
            "Auth Scenario"});
            this.cmbContentType.Location = new System.Drawing.Point(365, 4);
            this.cmbContentType.Margin = new System.Windows.Forms.Padding(0, 4, 10, 4);
            this.cmbContentType.Name = "cmbContentType";
            this.cmbContentType.Size = new System.Drawing.Size(146, 23);
            this.cmbContentType.TabIndex = 3;
            this.cmbContentType.SelectedIndexChanged += new System.EventHandler(this.cmbContentType_SelectedIndexChanged);
            // 
            // lblSearch
            // 
            this.lblSearch.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblSearch.AutoSize = true;
            this.lblSearch.Font = new System.Drawing.Font("Agency", 10.5F);
            this.lblSearch.Location = new System.Drawing.Point(524, 9);
            this.lblSearch.Name = "lblSearch";
            this.lblSearch.Size = new System.Drawing.Size(87, 16);
            this.lblSearch.TabIndex = 4;
            this.lblSearch.Text = "SEARCH";
            this.lblSearch.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtSearch
            // 
            this.txtSearch.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtSearch.Location = new System.Drawing.Point(617, 2);
            this.txtSearch.Margin = new System.Windows.Forms.Padding(0, 2, 10, 4);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(782, 32);
            this.txtSearch.TabIndex = 5;
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            // 
            // btnRefresh
            // 
            this.btnRefresh.BackColor = System.Drawing.Color.RoyalBlue;
            this.btnRefresh.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnRefresh.Font = new System.Drawing.Font("Muro", 12F);
            this.btnRefresh.ForeColor = System.Drawing.Color.White;
            this.btnRefresh.Location = new System.Drawing.Point(1409, 2);
            this.btnRefresh.Margin = new System.Windows.Forms.Padding(0, 2, 8, 2);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(118, 30);
            this.btnRefresh.Style.BackColor = System.Drawing.Color.RoyalBlue;
            this.btnRefresh.Style.ForeColor = System.Drawing.Color.White;
            this.btnRefresh.TabIndex = 6;
            this.btnRefresh.Text = "REFRESH";
            this.btnRefresh.UseVisualStyleBackColor = false;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnExportCsv
            // 
            this.btnExportCsv.BackColor = System.Drawing.Color.SeaGreen;
            this.btnExportCsv.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnExportCsv.Font = new System.Drawing.Font("Muro", 12F);
            this.btnExportCsv.ForeColor = System.Drawing.Color.White;
            this.btnExportCsv.Location = new System.Drawing.Point(1535, 2);
            this.btnExportCsv.Margin = new System.Windows.Forms.Padding(0, 2, 0, 2);
            this.btnExportCsv.Name = "btnExportCsv";
            this.btnExportCsv.Size = new System.Drawing.Size(120, 30);
            this.btnExportCsv.Style.BackColor = System.Drawing.Color.SeaGreen;
            this.btnExportCsv.Style.ForeColor = System.Drawing.Color.White;
            this.btnExportCsv.TabIndex = 7;
            this.btnExportCsv.Text = "EXPORT";
            this.btnExportCsv.UseVisualStyleBackColor = false;
            this.btnExportCsv.Click += new System.EventHandler(this.btnExportCsv_Click);
            // 
            // pnlSidebar
            // 
            this.pnlSidebar.BackColor = System.Drawing.Color.RoyalBlue;
            this.pnlSidebar.Controls.Add(this.pnlSidebarSpacer);
            this.pnlSidebar.Controls.Add(this.lblAdminBadge);
            this.pnlSidebar.Controls.Add(this.lblMondas);
            this.pnlSidebar.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlSidebar.Location = new System.Drawing.Point(2, 2);
            this.pnlSidebar.Margin = new System.Windows.Forms.Padding(0);
            this.pnlSidebar.Name = "pnlSidebar";
            this.pnlSidebar.Size = new System.Drawing.Size(220, 773);
            this.pnlSidebar.TabIndex = 0;
            // 
            // pnlSidebarSpacer
            // 
            this.pnlSidebarSpacer.BackColor = System.Drawing.Color.Transparent;
            this.pnlSidebarSpacer.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlSidebarSpacer.Location = new System.Drawing.Point(0, 148);
            this.pnlSidebarSpacer.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pnlSidebarSpacer.Name = "pnlSidebarSpacer";
            this.pnlSidebarSpacer.Size = new System.Drawing.Size(220, 18);
            this.pnlSidebarSpacer.TabIndex = 2;
            // 
            // lblAdminBadge
            // 
            this.lblAdminBadge.AutoSize = true;
            this.lblAdminBadge.BackColor = System.Drawing.Color.Transparent;
            this.lblAdminBadge.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblAdminBadge.Font = new System.Drawing.Font("Agency", 16F);
            this.lblAdminBadge.ForeColor = System.Drawing.Color.White;
            this.lblAdminBadge.Location = new System.Drawing.Point(0, 74);
            this.lblAdminBadge.Margin = new System.Windows.Forms.Padding(0);
            this.lblAdminBadge.Name = "lblAdminBadge";
            this.lblAdminBadge.Padding = new System.Windows.Forms.Padding(6, 50, 0, 0);
            this.lblAdminBadge.Size = new System.Drawing.Size(215, 74);
            this.lblAdminBadge.TabIndex = 1;
            this.lblAdminBadge.Text = "ADMIN PANEL";
            this.lblAdminBadge.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblMondas
            // 
            this.lblMondas.AutoSize = true;
            this.lblMondas.BackColor = System.Drawing.Color.Transparent;
            this.lblMondas.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblMondas.Font = new System.Drawing.Font("Muro", 32F);
            this.lblMondas.ForeColor = System.Drawing.Color.White;
            this.lblMondas.Location = new System.Drawing.Point(0, 0);
            this.lblMondas.Margin = new System.Windows.Forms.Padding(0);
            this.lblMondas.Name = "lblMondas";
            this.lblMondas.Padding = new System.Windows.Forms.Padding(0, 10, 0, 0);
            this.lblMondas.Size = new System.Drawing.Size(224, 74);
            this.lblMondas.TabIndex = 0;
            this.lblMondas.Text = "MONDAS";
            this.lblMondas.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlContent
            // 
            this.pnlContent.Controls.Add(this.tlpPage);
            this.pnlContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlContent.Location = new System.Drawing.Point(222, 2);
            this.pnlContent.Margin = new System.Windows.Forms.Padding(0);
            this.pnlContent.Name = "pnlContent";
            this.pnlContent.Padding = new System.Windows.Forms.Padding(16, 16, 16, 10);
            this.pnlContent.Size = new System.Drawing.Size(1705, 773);
            this.pnlContent.TabIndex = 1;
            // 
            // tlpPage
            // 
            this.tlpPage.BackColor = System.Drawing.Color.Transparent;
            this.tlpPage.ColumnCount = 1;
            this.tlpPage.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpPage.Controls.Add(this.pnlFooter, 0, 4);
            this.tlpPage.Controls.Add(this.tlpStats, 0, 1);
            this.tlpPage.Controls.Add(this.tlpHeader, 0, 0);
            this.tlpPage.Controls.Add(pnlToolbar, 0, 2);
            this.tlpPage.Controls.Add(this.tlpMain, 0, 3);
            this.tlpPage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpPage.Location = new System.Drawing.Point(16, 16);
            this.tlpPage.Margin = new System.Windows.Forms.Padding(0);
            this.tlpPage.Name = "tlpPage";
            this.tlpPage.RowCount = 5;
            this.tlpPage.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 106F));
            this.tlpPage.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 92F));
            this.tlpPage.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 58F));
            this.tlpPage.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpPage.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.tlpPage.Size = new System.Drawing.Size(1673, 747);
            this.tlpPage.TabIndex = 0;
            // 
            // pnlFooter
            // 
            this.pnlFooter.Controls.Add(this.lblFooterUser);
            this.pnlFooter.Controls.Add(this.lblFooterLeft);
            this.pnlFooter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlFooter.Location = new System.Drawing.Point(3, 722);
            this.pnlFooter.Name = "pnlFooter";
            this.pnlFooter.Size = new System.Drawing.Size(1667, 22);
            this.pnlFooter.TabIndex = 5;
            // 
            // lblFooterUser
            // 
            this.lblFooterUser.Dock = System.Windows.Forms.DockStyle.Right;
            this.lblFooterUser.Font = new System.Drawing.Font("Agency", 10F);
            this.lblFooterUser.ForeColor = System.Drawing.Color.Gray;
            this.lblFooterUser.Location = new System.Drawing.Point(1466, 0);
            this.lblFooterUser.Name = "lblFooterUser";
            this.lblFooterUser.Size = new System.Drawing.Size(201, 22);
            this.lblFooterUser.TabIndex = 1;
            this.lblFooterUser.Text = "ROLE: ADMIN";
            this.lblFooterUser.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblFooterLeft
            // 
            this.lblFooterLeft.AutoSize = true;
            this.lblFooterLeft.Font = new System.Drawing.Font("Muro", 9F);
            this.lblFooterLeft.ForeColor = System.Drawing.Color.Gray;
            this.lblFooterLeft.Location = new System.Drawing.Point(0, 0);
            this.lblFooterLeft.Name = "lblFooterLeft";
            this.lblFooterLeft.Size = new System.Drawing.Size(195, 18);
            this.lblFooterLeft.TabIndex = 0;
            this.lblFooterLeft.Text = "© 2026 Mondas Learning";
            this.lblFooterLeft.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tlpStats
            // 
            this.tlpStats.ColumnCount = 5;
            this.tlpStats.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tlpStats.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tlpStats.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tlpStats.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tlpStats.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tlpStats.Controls.Add(this.pnlTotalUsers, 0, 0);
            this.tlpStats.Controls.Add(this.pnlActiveToday, 1, 0);
            this.tlpStats.Controls.Add(this.pnlAvgAccuracy, 2, 0);
            this.tlpStats.Controls.Add(this.pnlAtRiskUsers, 3, 0);
            this.tlpStats.Controls.Add(this.pnlTotalContent, 4, 0);
            this.tlpStats.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpStats.Location = new System.Drawing.Point(3, 108);
            this.tlpStats.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tlpStats.Name = "tlpStats";
            this.tlpStats.RowCount = 1;
            this.tlpStats.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpStats.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 88F));
            this.tlpStats.Size = new System.Drawing.Size(1667, 88);
            this.tlpStats.TabIndex = 2;
            // 
            // pnlTotalUsers
            // 
            this.pnlTotalUsers.BackColor = System.Drawing.Color.White;
            this.pnlTotalUsers.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlTotalUsers.Controls.Add(this.lblTotalUsersValue);
            this.pnlTotalUsers.Controls.Add(this.lblTotalUsersTitle);
            this.pnlTotalUsers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlTotalUsers.Location = new System.Drawing.Point(6, 6);
            this.pnlTotalUsers.Margin = new System.Windows.Forms.Padding(6);
            this.pnlTotalUsers.Name = "pnlTotalUsers";
            this.pnlTotalUsers.Padding = new System.Windows.Forms.Padding(8);
            this.pnlTotalUsers.Size = new System.Drawing.Size(321, 76);
            this.pnlTotalUsers.TabIndex = 0;
            // 
            // lblTotalUsersValue
            // 
            this.lblTotalUsersValue.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblTotalUsersValue.Font = new System.Drawing.Font("Muro", 16F);
            this.lblTotalUsersValue.ForeColor = System.Drawing.Color.Black;
            this.lblTotalUsersValue.Location = new System.Drawing.Point(8, 26);
            this.lblTotalUsersValue.Name = "lblTotalUsersValue";
            this.lblTotalUsersValue.Size = new System.Drawing.Size(303, 40);
            this.lblTotalUsersValue.TabIndex = 1;
            this.lblTotalUsersValue.Text = "40";
            this.lblTotalUsersValue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblTotalUsersTitle
            // 
            this.lblTotalUsersTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTotalUsersTitle.Font = new System.Drawing.Font("Agency", 9F);
            this.lblTotalUsersTitle.ForeColor = System.Drawing.Color.Black;
            this.lblTotalUsersTitle.Location = new System.Drawing.Point(8, 8);
            this.lblTotalUsersTitle.Name = "lblTotalUsersTitle";
            this.lblTotalUsersTitle.Size = new System.Drawing.Size(303, 24);
            this.lblTotalUsersTitle.TabIndex = 0;
            this.lblTotalUsersTitle.Text = "TOTAL USERS";
            this.lblTotalUsersTitle.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // pnlActiveToday
            // 
            this.pnlActiveToday.BackColor = System.Drawing.Color.White;
            this.pnlActiveToday.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlActiveToday.Controls.Add(this.lblActiveTodayValue);
            this.pnlActiveToday.Controls.Add(this.lblActiveTodayTitle);
            this.pnlActiveToday.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlActiveToday.Location = new System.Drawing.Point(339, 6);
            this.pnlActiveToday.Margin = new System.Windows.Forms.Padding(6);
            this.pnlActiveToday.Name = "pnlActiveToday";
            this.pnlActiveToday.Padding = new System.Windows.Forms.Padding(8);
            this.pnlActiveToday.Size = new System.Drawing.Size(321, 76);
            this.pnlActiveToday.TabIndex = 1;
            // 
            // lblActiveTodayValue
            // 
            this.lblActiveTodayValue.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblActiveTodayValue.Font = new System.Drawing.Font("Muro", 16F);
            this.lblActiveTodayValue.ForeColor = System.Drawing.Color.Black;
            this.lblActiveTodayValue.Location = new System.Drawing.Point(8, 26);
            this.lblActiveTodayValue.Name = "lblActiveTodayValue";
            this.lblActiveTodayValue.Size = new System.Drawing.Size(303, 40);
            this.lblActiveTodayValue.TabIndex = 2;
            this.lblActiveTodayValue.Text = "19";
            this.lblActiveTodayValue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblActiveTodayTitle
            // 
            this.lblActiveTodayTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblActiveTodayTitle.Font = new System.Drawing.Font("Agency", 9F);
            this.lblActiveTodayTitle.ForeColor = System.Drawing.Color.Black;
            this.lblActiveTodayTitle.Location = new System.Drawing.Point(8, 8);
            this.lblActiveTodayTitle.Name = "lblActiveTodayTitle";
            this.lblActiveTodayTitle.Size = new System.Drawing.Size(303, 24);
            this.lblActiveTodayTitle.TabIndex = 1;
            this.lblActiveTodayTitle.Text = "ACTIVE TODAY";
            this.lblActiveTodayTitle.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // pnlAvgAccuracy
            // 
            this.pnlAvgAccuracy.BackColor = System.Drawing.Color.White;
            this.pnlAvgAccuracy.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlAvgAccuracy.Controls.Add(this.lblAvgAccuracyValue);
            this.pnlAvgAccuracy.Controls.Add(this.lblAvgAccuracyTitle);
            this.pnlAvgAccuracy.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlAvgAccuracy.Location = new System.Drawing.Point(672, 6);
            this.pnlAvgAccuracy.Margin = new System.Windows.Forms.Padding(6);
            this.pnlAvgAccuracy.Name = "pnlAvgAccuracy";
            this.pnlAvgAccuracy.Padding = new System.Windows.Forms.Padding(8);
            this.pnlAvgAccuracy.Size = new System.Drawing.Size(321, 76);
            this.pnlAvgAccuracy.TabIndex = 2;
            this.pnlAvgAccuracy.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlAvgAccuracy_Paint);
            // 
            // lblAvgAccuracyValue
            // 
            this.lblAvgAccuracyValue.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblAvgAccuracyValue.Font = new System.Drawing.Font("Muro", 16F);
            this.lblAvgAccuracyValue.ForeColor = System.Drawing.Color.Black;
            this.lblAvgAccuracyValue.Location = new System.Drawing.Point(8, 26);
            this.lblAvgAccuracyValue.Name = "lblAvgAccuracyValue";
            this.lblAvgAccuracyValue.Size = new System.Drawing.Size(303, 40);
            this.lblAvgAccuracyValue.TabIndex = 3;
            this.lblAvgAccuracyValue.Text = "54%";
            this.lblAvgAccuracyValue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblAvgAccuracyTitle
            // 
            this.lblAvgAccuracyTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblAvgAccuracyTitle.Font = new System.Drawing.Font("Agency", 9F);
            this.lblAvgAccuracyTitle.ForeColor = System.Drawing.Color.Black;
            this.lblAvgAccuracyTitle.Location = new System.Drawing.Point(8, 8);
            this.lblAvgAccuracyTitle.Name = "lblAvgAccuracyTitle";
            this.lblAvgAccuracyTitle.Size = new System.Drawing.Size(303, 24);
            this.lblAvgAccuracyTitle.TabIndex = 2;
            this.lblAvgAccuracyTitle.Text = "AVG ACCURACY";
            this.lblAvgAccuracyTitle.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // pnlAtRiskUsers
            // 
            this.pnlAtRiskUsers.BackColor = System.Drawing.Color.White;
            this.pnlAtRiskUsers.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlAtRiskUsers.Controls.Add(this.lblAtRiskUsersValue);
            this.pnlAtRiskUsers.Controls.Add(this.lblAtRiskUsersTitle);
            this.pnlAtRiskUsers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlAtRiskUsers.Location = new System.Drawing.Point(1005, 6);
            this.pnlAtRiskUsers.Margin = new System.Windows.Forms.Padding(6);
            this.pnlAtRiskUsers.Name = "pnlAtRiskUsers";
            this.pnlAtRiskUsers.Padding = new System.Windows.Forms.Padding(8);
            this.pnlAtRiskUsers.Size = new System.Drawing.Size(321, 76);
            this.pnlAtRiskUsers.TabIndex = 3;
            // 
            // lblAtRiskUsersValue
            // 
            this.lblAtRiskUsersValue.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblAtRiskUsersValue.Font = new System.Drawing.Font("Muro", 16F);
            this.lblAtRiskUsersValue.ForeColor = System.Drawing.Color.Black;
            this.lblAtRiskUsersValue.Location = new System.Drawing.Point(8, 26);
            this.lblAtRiskUsersValue.Name = "lblAtRiskUsersValue";
            this.lblAtRiskUsersValue.Size = new System.Drawing.Size(303, 40);
            this.lblAtRiskUsersValue.TabIndex = 4;
            this.lblAtRiskUsersValue.Text = "10";
            this.lblAtRiskUsersValue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblAtRiskUsersTitle
            // 
            this.lblAtRiskUsersTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblAtRiskUsersTitle.Font = new System.Drawing.Font("Agency", 9F);
            this.lblAtRiskUsersTitle.ForeColor = System.Drawing.Color.Black;
            this.lblAtRiskUsersTitle.Location = new System.Drawing.Point(8, 8);
            this.lblAtRiskUsersTitle.Name = "lblAtRiskUsersTitle";
            this.lblAtRiskUsersTitle.Size = new System.Drawing.Size(303, 24);
            this.lblAtRiskUsersTitle.TabIndex = 2;
            this.lblAtRiskUsersTitle.Text = "AT-RISK USERS";
            this.lblAtRiskUsersTitle.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // pnlTotalContent
            // 
            this.pnlTotalContent.BackColor = System.Drawing.Color.White;
            this.pnlTotalContent.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlTotalContent.Controls.Add(this.lblTotalContentValue);
            this.pnlTotalContent.Controls.Add(this.lblTotalContentTitle);
            this.pnlTotalContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlTotalContent.Location = new System.Drawing.Point(1338, 6);
            this.pnlTotalContent.Margin = new System.Windows.Forms.Padding(6);
            this.pnlTotalContent.Name = "pnlTotalContent";
            this.pnlTotalContent.Padding = new System.Windows.Forms.Padding(8);
            this.pnlTotalContent.Size = new System.Drawing.Size(323, 76);
            this.pnlTotalContent.TabIndex = 4;
            // 
            // lblTotalContentValue
            // 
            this.lblTotalContentValue.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblTotalContentValue.Font = new System.Drawing.Font("Muro", 16F);
            this.lblTotalContentValue.ForeColor = System.Drawing.Color.Black;
            this.lblTotalContentValue.Location = new System.Drawing.Point(8, 26);
            this.lblTotalContentValue.Name = "lblTotalContentValue";
            this.lblTotalContentValue.Size = new System.Drawing.Size(305, 40);
            this.lblTotalContentValue.TabIndex = 5;
            this.lblTotalContentValue.Text = "125";
            this.lblTotalContentValue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblTotalContentTitle
            // 
            this.lblTotalContentTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTotalContentTitle.Font = new System.Drawing.Font("Agency", 8.5F);
            this.lblTotalContentTitle.ForeColor = System.Drawing.Color.Black;
            this.lblTotalContentTitle.Location = new System.Drawing.Point(8, 8);
            this.lblTotalContentTitle.Name = "lblTotalContentTitle";
            this.lblTotalContentTitle.Size = new System.Drawing.Size(305, 24);
            this.lblTotalContentTitle.TabIndex = 3;
            this.lblTotalContentTitle.Text = "TOTAL CONTENT";
            this.lblTotalContentTitle.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // tlpHeader
            // 
            this.tlpHeader.ColumnCount = 2;
            this.tlpHeader.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 72F));
            this.tlpHeader.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 28F));
            this.tlpHeader.Controls.Add(this.pnlHeaderRight, 1, 0);
            this.tlpHeader.Controls.Add(this.pnlHeaderLeft, 0, 0);
            this.tlpHeader.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpHeader.Location = new System.Drawing.Point(0, 0);
            this.tlpHeader.Margin = new System.Windows.Forms.Padding(0, 0, 0, 10);
            this.tlpHeader.Name = "tlpHeader";
            this.tlpHeader.RowCount = 1;
            this.tlpHeader.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpHeader.Size = new System.Drawing.Size(1673, 96);
            this.tlpHeader.TabIndex = 0;
            // 
            // pnlHeaderRight
            // 
            this.pnlHeaderRight.Controls.Add(this.btnLogout);
            this.pnlHeaderRight.Controls.Add(this.lblAdminUser);
            this.pnlHeaderRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlHeaderRight.Location = new System.Drawing.Point(1207, 2);
            this.pnlHeaderRight.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pnlHeaderRight.Name = "pnlHeaderRight";
            this.pnlHeaderRight.Size = new System.Drawing.Size(463, 92);
            this.pnlHeaderRight.TabIndex = 2;
            // 
            // btnLogout
            // 
            this.btnLogout.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLogout.AutoSize = true;
            this.btnLogout.BackColor = System.Drawing.Color.White;
            this.btnLogout.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.btnLogout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogout.Font = new System.Drawing.Font("Agency", 12F);
            this.btnLogout.Location = new System.Drawing.Point(268, 31);
            this.btnLogout.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(118, 30);
            this.btnLogout.TabIndex = 1;
            this.btnLogout.Text = "LOG OUT";
            this.btnLogout.UseVisualStyleBackColor = false;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // lblAdminUser
            // 
            this.lblAdminUser.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblAdminUser.AutoSize = true;
            this.lblAdminUser.Font = new System.Drawing.Font("Agency", 12F);
            this.lblAdminUser.Location = new System.Drawing.Point(105, 37);
            this.lblAdminUser.Name = "lblAdminUser";
            this.lblAdminUser.Size = new System.Drawing.Size(151, 18);
            this.lblAdminUser.TabIndex = 0;
            this.lblAdminUser.Text = "ADMIN NAME";
            this.lblAdminUser.Click += new System.EventHandler(this.lblAdminUser_Click);
            // 
            // pnlHeaderLeft
            // 
            this.pnlHeaderLeft.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlHeaderLeft.Controls.Add(this.lblSub);
            this.pnlHeaderLeft.Controls.Add(this.lblWelcome);
            this.pnlHeaderLeft.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlHeaderLeft.Location = new System.Drawing.Point(0, 0);
            this.pnlHeaderLeft.Margin = new System.Windows.Forms.Padding(0, 0, 10, 0);
            this.pnlHeaderLeft.Name = "pnlHeaderLeft";
            this.pnlHeaderLeft.Padding = new System.Windows.Forms.Padding(18, 12, 18, 10);
            this.pnlHeaderLeft.Size = new System.Drawing.Size(1194, 96);
            this.pnlHeaderLeft.TabIndex = 0;
            // 
            // lblSub
            // 
            this.lblSub.AutoSize = true;
            this.lblSub.Location = new System.Drawing.Point(7, 65);
            this.lblSub.Name = "lblSub";
            this.lblSub.Size = new System.Drawing.Size(624, 18);
            this.lblSub.TabIndex = 1;
            this.lblSub.Text = "MONITOR USERS, REVIEW DATA, AND MANAGE CONTENT";
            this.lblSub.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblWelcome
            // 
            this.lblWelcome.AutoSize = true;
            this.lblWelcome.Font = new System.Drawing.Font("Muro", 28F);
            this.lblWelcome.Location = new System.Drawing.Point(0, 0);
            this.lblWelcome.Name = "lblWelcome";
            this.lblWelcome.Size = new System.Drawing.Size(419, 56);
            this.lblWelcome.TabIndex = 0;
            this.lblWelcome.Text = "ADMIN DASHBOARD";
            this.lblWelcome.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tlpMain
            // 
            this.tlpMain.ColumnCount = 2;
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 38F));
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 62F));
            this.tlpMain.Controls.Add(this.tlpLeft, 0, 0);
            this.tlpMain.Controls.Add(this.gbContentBank, 1, 0);
            this.tlpMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpMain.Location = new System.Drawing.Point(0, 256);
            this.tlpMain.Margin = new System.Windows.Forms.Padding(0);
            this.tlpMain.Name = "tlpMain";
            this.tlpMain.RowCount = 1;
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpMain.Size = new System.Drawing.Size(1673, 463);
            this.tlpMain.TabIndex = 4;
            // 
            // tlpLeft
            // 
            this.tlpLeft.ColumnCount = 1;
            this.tlpLeft.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpLeft.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpLeft.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpLeft.Controls.Add(this.gbUsersOverview, 0, 0);
            this.tlpLeft.Controls.Add(this.gbTopMisconceptions, 0, 1);
            this.tlpLeft.Controls.Add(this.gbRecentActivity, 0, 2);
            this.tlpLeft.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpLeft.Location = new System.Drawing.Point(0, 0);
            this.tlpLeft.Margin = new System.Windows.Forms.Padding(0, 0, 10, 0);
            this.tlpLeft.Name = "tlpLeft";
            this.tlpLeft.RowCount = 3;
            this.tlpLeft.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 46F));
            this.tlpLeft.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 24F));
            this.tlpLeft.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tlpLeft.Size = new System.Drawing.Size(625, 463);
            this.tlpLeft.TabIndex = 0;
            // 
            // gbUsersOverview
            // 
            this.gbUsersOverview.Controls.Add(this.dgvUsers);
            this.gbUsersOverview.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbUsersOverview.Location = new System.Drawing.Point(0, 0);
            this.gbUsersOverview.Margin = new System.Windows.Forms.Padding(0, 0, 0, 10);
            this.gbUsersOverview.Name = "gbUsersOverview";
            this.gbUsersOverview.Padding = new System.Windows.Forms.Padding(8);
            this.gbUsersOverview.Size = new System.Drawing.Size(625, 202);
            this.gbUsersOverview.TabIndex = 0;
            this.gbUsersOverview.TabStop = false;
            this.gbUsersOverview.Text = "USERS OVERVIEW";
            // 
            // dgvUsers
            // 
            this.dgvUsers.AllowUserToAddRows = false;
            this.dgvUsers.AllowUserToDeleteRows = false;
            this.dgvUsers.AllowUserToResizeRows = false;
            this.dgvUsers.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvUsers.BackgroundColor = System.Drawing.Color.White;
            this.dgvUsers.ColumnHeadersHeight = 34;
            this.dgvUsers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvUsers.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colUserName,
            this.colAttempts,
            this.colAccuracy,
            this.colAvgTime,
            this.colWeakestTopic,
            this.colLastActive});
            this.dgvUsers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvUsers.Location = new System.Drawing.Point(8, 33);
            this.dgvUsers.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dgvUsers.MultiSelect = false;
            this.dgvUsers.Name = "dgvUsers";
            this.dgvUsers.ReadOnly = true;
            this.dgvUsers.RowHeadersVisible = false;
            this.dgvUsers.RowHeadersWidth = 62;
            this.dgvUsers.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Agency", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvUsers.RowTemplate.Height = 28;
            this.dgvUsers.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvUsers.Size = new System.Drawing.Size(609, 161);
            this.dgvUsers.TabIndex = 0;
            // 
            // colUserName
            // 
            this.colUserName.HeaderText = "User Name";
            this.colUserName.MinimumWidth = 8;
            this.colUserName.Name = "colUserName";
            this.colUserName.ReadOnly = true;
            // 
            // colAttempts
            // 
            this.colAttempts.HeaderText = "Attempts";
            this.colAttempts.MinimumWidth = 8;
            this.colAttempts.Name = "colAttempts";
            this.colAttempts.ReadOnly = true;
            // 
            // colAccuracy
            // 
            this.colAccuracy.HeaderText = "Accuracy";
            this.colAccuracy.MinimumWidth = 8;
            this.colAccuracy.Name = "colAccuracy";
            this.colAccuracy.ReadOnly = true;
            // 
            // colAvgTime
            // 
            this.colAvgTime.HeaderText = "Avg Time";
            this.colAvgTime.MinimumWidth = 8;
            this.colAvgTime.Name = "colAvgTime";
            this.colAvgTime.ReadOnly = true;
            // 
            // colWeakestTopic
            // 
            this.colWeakestTopic.HeaderText = "Weakest Topic";
            this.colWeakestTopic.MinimumWidth = 8;
            this.colWeakestTopic.Name = "colWeakestTopic";
            this.colWeakestTopic.ReadOnly = true;
            // 
            // colLastActive
            // 
            this.colLastActive.HeaderText = "Last Active";
            this.colLastActive.MinimumWidth = 8;
            this.colLastActive.Name = "colLastActive";
            this.colLastActive.ReadOnly = true;
            // 
            // gbTopMisconceptions
            // 
            this.gbTopMisconceptions.Controls.Add(this.dgvMisconceptions);
            this.gbTopMisconceptions.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbTopMisconceptions.Location = new System.Drawing.Point(0, 212);
            this.gbTopMisconceptions.Margin = new System.Windows.Forms.Padding(0, 0, 0, 10);
            this.gbTopMisconceptions.Name = "gbTopMisconceptions";
            this.gbTopMisconceptions.Padding = new System.Windows.Forms.Padding(8);
            this.gbTopMisconceptions.Size = new System.Drawing.Size(625, 101);
            this.gbTopMisconceptions.TabIndex = 1;
            this.gbTopMisconceptions.TabStop = false;
            this.gbTopMisconceptions.Text = "TOP MISCONCEPTIONS";
            // 
            // dgvMisconceptions
            // 
            this.dgvMisconceptions.AllowUserToAddRows = false;
            this.dgvMisconceptions.AllowUserToDeleteRows = false;
            this.dgvMisconceptions.AllowUserToResizeRows = false;
            this.dgvMisconceptions.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvMisconceptions.BackgroundColor = System.Drawing.Color.White;
            this.dgvMisconceptions.ColumnHeadersHeight = 34;
            this.dgvMisconceptions.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvMisconceptions.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colMisTag,
            this.colMisCount,
            this.colMisLastSeen});
            this.dgvMisconceptions.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvMisconceptions.Location = new System.Drawing.Point(8, 33);
            this.dgvMisconceptions.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dgvMisconceptions.MultiSelect = false;
            this.dgvMisconceptions.Name = "dgvMisconceptions";
            this.dgvMisconceptions.ReadOnly = true;
            this.dgvMisconceptions.RowHeadersVisible = false;
            this.dgvMisconceptions.RowHeadersWidth = 62;
            this.dgvMisconceptions.RowTemplate.Height = 28;
            this.dgvMisconceptions.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvMisconceptions.Size = new System.Drawing.Size(609, 60);
            this.dgvMisconceptions.TabIndex = 1;
            // 
            // colMisTag
            // 
            this.colMisTag.HeaderText = "Tag";
            this.colMisTag.MinimumWidth = 8;
            this.colMisTag.Name = "colMisTag";
            this.colMisTag.ReadOnly = true;
            // 
            // colMisCount
            // 
            this.colMisCount.HeaderText = "Count";
            this.colMisCount.MinimumWidth = 8;
            this.colMisCount.Name = "colMisCount";
            this.colMisCount.ReadOnly = true;
            // 
            // colMisLastSeen
            // 
            this.colMisLastSeen.HeaderText = "Last Seen";
            this.colMisLastSeen.MinimumWidth = 8;
            this.colMisLastSeen.Name = "colMisLastSeen";
            this.colMisLastSeen.ReadOnly = true;
            // 
            // gbRecentActivity
            // 
            this.gbRecentActivity.Controls.Add(this.dgvRecentActivity);
            this.gbRecentActivity.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbRecentActivity.Location = new System.Drawing.Point(0, 323);
            this.gbRecentActivity.Margin = new System.Windows.Forms.Padding(0);
            this.gbRecentActivity.Name = "gbRecentActivity";
            this.gbRecentActivity.Padding = new System.Windows.Forms.Padding(8);
            this.gbRecentActivity.Size = new System.Drawing.Size(625, 140);
            this.gbRecentActivity.TabIndex = 2;
            this.gbRecentActivity.TabStop = false;
            this.gbRecentActivity.Text = "RECENT ACTIVITY";
            // 
            // dgvRecentActivity
            // 
            this.dgvRecentActivity.AllowUserToAddRows = false;
            this.dgvRecentActivity.AllowUserToDeleteRows = false;
            this.dgvRecentActivity.AllowUserToResizeRows = false;
            this.dgvRecentActivity.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvRecentActivity.BackgroundColor = System.Drawing.Color.White;
            this.dgvRecentActivity.ColumnHeadersHeight = 34;
            this.dgvRecentActivity.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvRecentActivity.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colActivityUser,
            this.colActivityMode,
            this.colActivityResult,
            this.colActivityWhen});
            this.dgvRecentActivity.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvRecentActivity.Location = new System.Drawing.Point(8, 33);
            this.dgvRecentActivity.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dgvRecentActivity.MultiSelect = false;
            this.dgvRecentActivity.Name = "dgvRecentActivity";
            this.dgvRecentActivity.ReadOnly = true;
            this.dgvRecentActivity.RowHeadersVisible = false;
            this.dgvRecentActivity.RowHeadersWidth = 62;
            this.dgvRecentActivity.RowTemplate.Height = 28;
            this.dgvRecentActivity.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvRecentActivity.Size = new System.Drawing.Size(609, 99);
            this.dgvRecentActivity.TabIndex = 2;
            // 
            // colActivityUser
            // 
            this.colActivityUser.HeaderText = "User";
            this.colActivityUser.MinimumWidth = 8;
            this.colActivityUser.Name = "colActivityUser";
            this.colActivityUser.ReadOnly = true;
            // 
            // colActivityMode
            // 
            this.colActivityMode.HeaderText = "Mode";
            this.colActivityMode.MinimumWidth = 8;
            this.colActivityMode.Name = "colActivityMode";
            this.colActivityMode.ReadOnly = true;
            // 
            // colActivityResult
            // 
            this.colActivityResult.HeaderText = "Result";
            this.colActivityResult.MinimumWidth = 8;
            this.colActivityResult.Name = "colActivityResult";
            this.colActivityResult.ReadOnly = true;
            // 
            // colActivityWhen
            // 
            this.colActivityWhen.HeaderText = "When";
            this.colActivityWhen.MinimumWidth = 8;
            this.colActivityWhen.Name = "colActivityWhen";
            this.colActivityWhen.ReadOnly = true;
            // 
            // gbContentBank
            // 
            this.gbContentBank.Controls.Add(this.tlpContentBank);
            this.gbContentBank.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbContentBank.Location = new System.Drawing.Point(635, 0);
            this.gbContentBank.Margin = new System.Windows.Forms.Padding(0);
            this.gbContentBank.Name = "gbContentBank";
            this.gbContentBank.Padding = new System.Windows.Forms.Padding(8);
            this.gbContentBank.Size = new System.Drawing.Size(1038, 463);
            this.gbContentBank.TabIndex = 1;
            this.gbContentBank.TabStop = false;
            this.gbContentBank.Text = "Content Bank Editor";
            // 
            // tlpContentBank
            // 
            this.tlpContentBank.ColumnCount = 1;
            this.tlpContentBank.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpContentBank.Controls.Add(this.tlpBankToolbar, 0, 0);
            this.tlpContentBank.Controls.Add(this.splitBank, 0, 1);
            this.tlpContentBank.Controls.Add(this.tlpBankActions, 0, 2);
            this.tlpContentBank.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpContentBank.Location = new System.Drawing.Point(8, 33);
            this.tlpContentBank.Margin = new System.Windows.Forms.Padding(0);
            this.tlpContentBank.Name = "tlpContentBank";
            this.tlpContentBank.RowCount = 3;
            this.tlpContentBank.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 44F));
            this.tlpContentBank.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpContentBank.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 46F));
            this.tlpContentBank.Size = new System.Drawing.Size(1022, 422);
            this.tlpContentBank.TabIndex = 0;
            // 
            // tlpBankToolbar
            // 
            this.tlpBankToolbar.ColumnCount = 7;
            this.tlpBankToolbar.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 70F));
            this.tlpBankToolbar.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 291F));
            this.tlpBankToolbar.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 124F));
            this.tlpBankToolbar.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 198F));
            this.tlpBankToolbar.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 98F));
            this.tlpBankToolbar.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 134F));
            this.tlpBankToolbar.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 107F));
            this.tlpBankToolbar.Controls.Add(this.lblBankTopic, 0, 0);
            this.tlpBankToolbar.Controls.Add(this.cmbBankTopic, 1, 0);
            this.tlpBankToolbar.Controls.Add(this.lblBankDifficulty, 2, 0);
            this.tlpBankToolbar.Controls.Add(this.cmbBankDifficulty, 3, 0);
            this.tlpBankToolbar.Controls.Add(this.btnNewItem, 4, 0);
            this.tlpBankToolbar.Controls.Add(this.btnDuplicateItem, 5, 0);
            this.tlpBankToolbar.Controls.Add(this.btnDeleteItem, 6, 0);
            this.tlpBankToolbar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpBankToolbar.Location = new System.Drawing.Point(0, 0);
            this.tlpBankToolbar.Margin = new System.Windows.Forms.Padding(0);
            this.tlpBankToolbar.Name = "tlpBankToolbar";
            this.tlpBankToolbar.RowCount = 1;
            this.tlpBankToolbar.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpBankToolbar.Size = new System.Drawing.Size(1022, 44);
            this.tlpBankToolbar.TabIndex = 0;
            // 
            // lblBankTopic
            // 
            this.lblBankTopic.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblBankTopic.AutoSize = true;
            this.lblBankTopic.Font = new System.Drawing.Font("Agency", 10.5F);
            this.lblBankTopic.Location = new System.Drawing.Point(3, 14);
            this.lblBankTopic.Name = "lblBankTopic";
            this.lblBankTopic.Size = new System.Drawing.Size(64, 16);
            this.lblBankTopic.TabIndex = 0;
            this.lblBankTopic.Text = "TOPIC";
            this.lblBankTopic.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cmbBankTopic
            // 
            this.cmbBankTopic.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.cmbBankTopic.Font = new System.Drawing.Font("Agency", 10.5F);
            this.cmbBankTopic.FormattingEnabled = true;
            this.cmbBankTopic.Items.AddRange(new object[] {
            "All",
            "Phishing",
            "Passwords",
            "Device Security",
            "Social Engineering"});
            this.cmbBankTopic.Location = new System.Drawing.Point(70, 10);
            this.cmbBankTopic.Margin = new System.Windows.Forms.Padding(0, 4, 10, 4);
            this.cmbBankTopic.Name = "cmbBankTopic";
            this.cmbBankTopic.Size = new System.Drawing.Size(281, 24);
            this.cmbBankTopic.TabIndex = 1;
            this.cmbBankTopic.SelectedIndexChanged += new System.EventHandler(this.cmbBankTopic_SelectedIndexChanged);
            // 
            // lblBankDifficulty
            // 
            this.lblBankDifficulty.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblBankDifficulty.AutoSize = true;
            this.lblBankDifficulty.Font = new System.Drawing.Font("Agency", 10.5F);
            this.lblBankDifficulty.Location = new System.Drawing.Point(364, 14);
            this.lblBankDifficulty.Name = "lblBankDifficulty";
            this.lblBankDifficulty.Size = new System.Drawing.Size(118, 16);
            this.lblBankDifficulty.TabIndex = 2;
            this.lblBankDifficulty.Text = "DIFFICULTY";
            this.lblBankDifficulty.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cmbBankDifficulty
            // 
            this.cmbBankDifficulty.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.cmbBankDifficulty.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbBankDifficulty.Font = new System.Drawing.Font("Agency", 10.5F);
            this.cmbBankDifficulty.FormattingEnabled = true;
            this.cmbBankDifficulty.Items.AddRange(new object[] {
            "All",
            "Easy",
            "Medium",
            "Hard"});
            this.cmbBankDifficulty.Location = new System.Drawing.Point(485, 10);
            this.cmbBankDifficulty.Margin = new System.Windows.Forms.Padding(0, 4, 10, 4);
            this.cmbBankDifficulty.Name = "cmbBankDifficulty";
            this.cmbBankDifficulty.Size = new System.Drawing.Size(188, 24);
            this.cmbBankDifficulty.TabIndex = 3;
            this.cmbBankDifficulty.SelectedIndexChanged += new System.EventHandler(this.cmbBankDifficulty_SelectedIndexChanged);
            // 
            // btnNewItem
            // 
            this.btnNewItem.BackColor = System.Drawing.Color.RoyalBlue;
            this.btnNewItem.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnNewItem.Font = new System.Drawing.Font("Muro", 12F);
            this.btnNewItem.ForeColor = System.Drawing.Color.White;
            this.btnNewItem.Location = new System.Drawing.Point(683, 2);
            this.btnNewItem.Margin = new System.Windows.Forms.Padding(0, 2, 8, 2);
            this.btnNewItem.Name = "btnNewItem";
            this.btnNewItem.Size = new System.Drawing.Size(90, 40);
            this.btnNewItem.Style.BackColor = System.Drawing.Color.RoyalBlue;
            this.btnNewItem.Style.ForeColor = System.Drawing.Color.White;
            this.btnNewItem.TabIndex = 4;
            this.btnNewItem.Text = "NEW";
            this.btnNewItem.UseVisualStyleBackColor = false;
            this.btnNewItem.Click += new System.EventHandler(this.btnNewItem_Click);
            // 
            // btnDuplicateItem
            // 
            this.btnDuplicateItem.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnDuplicateItem.Font = new System.Drawing.Font("Muro", 12F);
            this.btnDuplicateItem.Location = new System.Drawing.Point(781, 2);
            this.btnDuplicateItem.Margin = new System.Windows.Forms.Padding(0, 2, 8, 2);
            this.btnDuplicateItem.Name = "btnDuplicateItem";
            this.btnDuplicateItem.Size = new System.Drawing.Size(126, 40);
            this.btnDuplicateItem.TabIndex = 5;
            this.btnDuplicateItem.Text = "DUPLICATE";
            this.btnDuplicateItem.Click += new System.EventHandler(this.btnDuplicateItem_Click);
            // 
            // btnDeleteItem
            // 
            this.btnDeleteItem.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnDeleteItem.Font = new System.Drawing.Font("Muro", 12F);
            this.btnDeleteItem.Location = new System.Drawing.Point(915, 2);
            this.btnDeleteItem.Margin = new System.Windows.Forms.Padding(0, 2, 0, 2);
            this.btnDeleteItem.Name = "btnDeleteItem";
            this.btnDeleteItem.Size = new System.Drawing.Size(107, 40);
            this.btnDeleteItem.TabIndex = 6;
            this.btnDeleteItem.Text = "DELETE";
            this.btnDeleteItem.Click += new System.EventHandler(this.btnDeleteItem_Click);
            // 
            // splitBank
            // 
            this.splitBank.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.splitBank.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitBank.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitBank.Location = new System.Drawing.Point(0, 52);
            this.splitBank.Margin = new System.Windows.Forms.Padding(0, 8, 0, 8);
            this.splitBank.Name = "splitBank";
            // 
            // splitBank.Panel1
            // 
            this.splitBank.Panel1.Controls.Add(this.dgvBankItems);
            // 
            // splitBank.Panel2
            // 
            this.splitBank.Panel2.Controls.Add(this.tabEditor);
            this.splitBank.Size = new System.Drawing.Size(1022, 316);
            this.splitBank.SplitterDistance = 280;
            this.splitBank.TabIndex = 1;
            // 
            // dgvBankItems
            // 
            this.dgvBankItems.AllowUserToAddRows = false;
            this.dgvBankItems.AllowUserToDeleteRows = false;
            this.dgvBankItems.AllowUserToResizeRows = false;
            this.dgvBankItems.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvBankItems.BackgroundColor = System.Drawing.Color.White;
            this.dgvBankItems.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvBankItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvBankItems.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colBankKey,
            this.colBankTitle,
            this.colBankType});
            this.dgvBankItems.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvBankItems.Location = new System.Drawing.Point(0, 0);
            this.dgvBankItems.MultiSelect = false;
            this.dgvBankItems.Name = "dgvBankItems";
            this.dgvBankItems.ReadOnly = true;
            this.dgvBankItems.RowHeadersVisible = false;
            this.dgvBankItems.RowHeadersWidth = 62;
            this.dgvBankItems.RowTemplate.Height = 28;
            this.dgvBankItems.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvBankItems.Size = new System.Drawing.Size(278, 314);
            this.dgvBankItems.TabIndex = 0;
            this.dgvBankItems.SelectionChanged += new System.EventHandler(this.dgvBankItems_SelectionChanged);
            // 
            // colBankKey
            // 
            this.colBankKey.HeaderText = "Key";
            this.colBankKey.MinimumWidth = 8;
            this.colBankKey.Name = "colBankKey";
            this.colBankKey.ReadOnly = true;
            // 
            // colBankTitle
            // 
            this.colBankTitle.HeaderText = "Title";
            this.colBankTitle.MinimumWidth = 8;
            this.colBankTitle.Name = "colBankTitle";
            this.colBankTitle.ReadOnly = true;
            // 
            // colBankType
            // 
            this.colBankType.HeaderText = "Type";
            this.colBankType.MinimumWidth = 8;
            this.colBankType.Name = "colBankType";
            this.colBankType.ReadOnly = true;
            // 
            // tabEditor
            // 
            this.tabEditor.Controls.Add(this.tabQuizQuestion);
            this.tabEditor.Controls.Add(this.tabPhishingEmail);
            this.tabEditor.Controls.Add(this.tabAuthScenario);
            this.tabEditor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabEditor.Font = new System.Drawing.Font("Agency", 10F);
            this.tabEditor.ItemSize = new System.Drawing.Size(160, 28);
            this.tabEditor.Location = new System.Drawing.Point(0, 0);
            this.tabEditor.Name = "tabEditor";
            this.tabEditor.SelectedIndex = 0;
            this.tabEditor.Size = new System.Drawing.Size(736, 314);
            this.tabEditor.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.tabEditor.TabIndex = 0;
            this.tabEditor.SelectedIndexChanged += new System.EventHandler(this.tabEditor_SelectedIndexChanged);
            // 
            // tabQuizQuestion
            // 
            this.tabQuizQuestion.Controls.Add(this.tlpQuizEditor);
            this.tabQuizQuestion.Location = new System.Drawing.Point(4, 32);
            this.tabQuizQuestion.Name = "tabQuizQuestion";
            this.tabQuizQuestion.Padding = new System.Windows.Forms.Padding(3);
            this.tabQuizQuestion.Size = new System.Drawing.Size(728, 278);
            this.tabQuizQuestion.TabIndex = 0;
            this.tabQuizQuestion.Text = "Quiz Question";
            this.tabQuizQuestion.UseVisualStyleBackColor = true;
            // 
            // tlpQuizEditor
            // 
            this.tlpQuizEditor.ColumnCount = 2;
            this.tlpQuizEditor.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 56.2323F));
            this.tlpQuizEditor.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 43.7677F));
            this.tlpQuizEditor.Controls.Add(this.pnlQuizEditorLeft, 0, 0);
            this.tlpQuizEditor.Controls.Add(this.pnlQuizEditorRight, 1, 0);
            this.tlpQuizEditor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpQuizEditor.Location = new System.Drawing.Point(3, 3);
            this.tlpQuizEditor.Margin = new System.Windows.Forms.Padding(0);
            this.tlpQuizEditor.Name = "tlpQuizEditor";
            this.tlpQuizEditor.Padding = new System.Windows.Forms.Padding(8);
            this.tlpQuizEditor.RowCount = 1;
            this.tlpQuizEditor.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpQuizEditor.Size = new System.Drawing.Size(722, 272);
            this.tlpQuizEditor.TabIndex = 0;
            // 
            // pnlQuizEditorLeft
            // 
            this.pnlQuizEditorLeft.Controls.Add(this.rtbQuizExplanation);
            this.pnlQuizEditorLeft.Controls.Add(this.lblQuizExplanation);
            this.pnlQuizEditorLeft.Controls.Add(this.dgvQuizOptions);
            this.pnlQuizEditorLeft.Controls.Add(this.lblQuizOptions);
            this.pnlQuizEditorLeft.Controls.Add(this.rtbQuizQuestionText);
            this.pnlQuizEditorLeft.Controls.Add(this.lblQuizQuestionText);
            this.pnlQuizEditorLeft.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlQuizEditorLeft.Location = new System.Drawing.Point(8, 8);
            this.pnlQuizEditorLeft.Margin = new System.Windows.Forms.Padding(0);
            this.pnlQuizEditorLeft.Name = "pnlQuizEditorLeft";
            this.pnlQuizEditorLeft.Size = new System.Drawing.Size(397, 256);
            this.pnlQuizEditorLeft.TabIndex = 0;
            // 
            // rtbQuizExplanation
            // 
            this.rtbQuizExplanation.Font = new System.Drawing.Font("Agency", 10F);
            this.rtbQuizExplanation.Location = new System.Drawing.Point(1, 112);
            this.rtbQuizExplanation.Name = "rtbQuizExplanation";
            this.rtbQuizExplanation.Size = new System.Drawing.Size(394, 59);
            this.rtbQuizExplanation.TabIndex = 5;
            this.rtbQuizExplanation.Text = "";
            // 
            // lblQuizExplanation
            // 
            this.lblQuizExplanation.AutoSize = true;
            this.lblQuizExplanation.Font = new System.Drawing.Font("Agency", 12F);
            this.lblQuizExplanation.Location = new System.Drawing.Point(1, 86);
            this.lblQuizExplanation.Name = "lblQuizExplanation";
            this.lblQuizExplanation.Size = new System.Drawing.Size(164, 18);
            this.lblQuizExplanation.TabIndex = 4;
            this.lblQuizExplanation.Text = "Explanation";
            // 
            // dgvQuizOptions
            // 
            this.dgvQuizOptions.AllowUserToResizeRows = false;
            this.dgvQuizOptions.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.dgvQuizOptions.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvQuizOptions.BackgroundColor = System.Drawing.Color.White;
            this.dgvQuizOptions.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvQuizOptions.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvQuizOptions.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colOptionText,
            this.colOptionCorrect});
            this.dgvQuizOptions.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dgvQuizOptions.Location = new System.Drawing.Point(0, 197);
            this.dgvQuizOptions.MultiSelect = false;
            this.dgvQuizOptions.Name = "dgvQuizOptions";
            this.dgvQuizOptions.RowHeadersVisible = false;
            this.dgvQuizOptions.RowHeadersWidth = 62;
            this.dgvQuizOptions.RowTemplate.Height = 28;
            this.dgvQuizOptions.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgvQuizOptions.Size = new System.Drawing.Size(394, 144);
            this.dgvQuizOptions.TabIndex = 3;
            // 
            // colOptionText
            // 
            this.colOptionText.HeaderText = "Text";
            this.colOptionText.MinimumWidth = 8;
            this.colOptionText.Name = "colOptionText";
            // 
            // colOptionCorrect
            // 
            this.colOptionCorrect.HeaderText = "Correct";
            this.colOptionCorrect.MinimumWidth = 8;
            this.colOptionCorrect.Name = "colOptionCorrect";
            this.colOptionCorrect.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colOptionCorrect.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // lblQuizOptions
            // 
            this.lblQuizOptions.AutoSize = true;
            this.lblQuizOptions.Font = new System.Drawing.Font("Agency", 12F);
            this.lblQuizOptions.Location = new System.Drawing.Point(0, 173);
            this.lblQuizOptions.Name = "lblQuizOptions";
            this.lblQuizOptions.Size = new System.Drawing.Size(105, 18);
            this.lblQuizOptions.TabIndex = 2;
            this.lblQuizOptions.Text = "OPTIONS";
            // 
            // rtbQuizQuestionText
            // 
            this.rtbQuizQuestionText.Font = new System.Drawing.Font("Agency", 10F);
            this.rtbQuizQuestionText.Location = new System.Drawing.Point(0, 26);
            this.rtbQuizQuestionText.Name = "rtbQuizQuestionText";
            this.rtbQuizQuestionText.Size = new System.Drawing.Size(394, 59);
            this.rtbQuizQuestionText.TabIndex = 1;
            this.rtbQuizQuestionText.Text = "";
            // 
            // lblQuizQuestionText
            // 
            this.lblQuizQuestionText.AutoSize = true;
            this.lblQuizQuestionText.Font = new System.Drawing.Font("Agency", 12F);
            this.lblQuizQuestionText.Location = new System.Drawing.Point(0, 0);
            this.lblQuizQuestionText.Name = "lblQuizQuestionText";
            this.lblQuizQuestionText.Size = new System.Drawing.Size(182, 18);
            this.lblQuizQuestionText.TabIndex = 0;
            this.lblQuizQuestionText.Text = "QUESTION TEXT";
            // 
            // pnlQuizEditorRight
            // 
            this.pnlQuizEditorRight.Controls.Add(this.txtMisTags);
            this.pnlQuizEditorRight.Controls.Add(this.lblMisTags);
            this.pnlQuizEditorRight.Controls.Add(this.cmbQuizType);
            this.pnlQuizEditorRight.Controls.Add(this.lblQuizType);
            this.pnlQuizEditorRight.Controls.Add(this.cmbQuizDifficulty);
            this.pnlQuizEditorRight.Controls.Add(this.lblQuizDifficulty);
            this.pnlQuizEditorRight.Controls.Add(this.cmbQuizTopic);
            this.pnlQuizEditorRight.Controls.Add(this.lblQuizTopic);
            this.pnlQuizEditorRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlQuizEditorRight.Location = new System.Drawing.Point(415, 8);
            this.pnlQuizEditorRight.Margin = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.pnlQuizEditorRight.Name = "pnlQuizEditorRight";
            this.pnlQuizEditorRight.Size = new System.Drawing.Size(299, 256);
            this.pnlQuizEditorRight.TabIndex = 1;
            // 
            // txtMisTags
            // 
            this.txtMisTags.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtMisTags.Location = new System.Drawing.Point(0, 197);
            this.txtMisTags.Multiline = true;
            this.txtMisTags.Name = "txtMisTags";
            this.txtMisTags.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtMisTags.Size = new System.Drawing.Size(299, 59);
            this.txtMisTags.TabIndex = 9;
            // 
            // lblMisTags
            // 
            this.lblMisTags.AutoSize = true;
            this.lblMisTags.Font = new System.Drawing.Font("Agency", 11F);
            this.lblMisTags.Location = new System.Drawing.Point(0, 167);
            this.lblMisTags.Name = "lblMisTags";
            this.lblMisTags.Size = new System.Drawing.Size(242, 17);
            this.lblMisTags.TabIndex = 8;
            this.lblMisTags.Text = "Misconception Tags";
            // 
            // cmbQuizType
            // 
            this.cmbQuizType.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbQuizType.FormattingEnabled = true;
            this.cmbQuizType.Location = new System.Drawing.Point(130, 83);
            this.cmbQuizType.Name = "cmbQuizType";
            this.cmbQuizType.Size = new System.Drawing.Size(169, 23);
            this.cmbQuizType.TabIndex = 5;
            // 
            // lblQuizType
            // 
            this.lblQuizType.AutoSize = true;
            this.lblQuizType.Font = new System.Drawing.Font("Agency", 11F);
            this.lblQuizType.Location = new System.Drawing.Point(0, 84);
            this.lblQuizType.Name = "lblQuizType";
            this.lblQuizType.Size = new System.Drawing.Size(60, 17);
            this.lblQuizType.TabIndex = 4;
            this.lblQuizType.Text = "Type";
            this.lblQuizType.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cmbQuizDifficulty
            // 
            this.cmbQuizDifficulty.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbQuizDifficulty.FormattingEnabled = true;
            this.cmbQuizDifficulty.Location = new System.Drawing.Point(130, 41);
            this.cmbQuizDifficulty.Name = "cmbQuizDifficulty";
            this.cmbQuizDifficulty.Size = new System.Drawing.Size(169, 23);
            this.cmbQuizDifficulty.TabIndex = 3;
            // 
            // lblQuizDifficulty
            // 
            this.lblQuizDifficulty.AutoSize = true;
            this.lblQuizDifficulty.Font = new System.Drawing.Font("Agency", 11F);
            this.lblQuizDifficulty.Location = new System.Drawing.Point(0, 42);
            this.lblQuizDifficulty.Name = "lblQuizDifficulty";
            this.lblQuizDifficulty.Size = new System.Drawing.Size(127, 17);
            this.lblQuizDifficulty.TabIndex = 2;
            this.lblQuizDifficulty.Text = "Difficulty";
            this.lblQuizDifficulty.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cmbQuizTopic
            // 
            this.cmbQuizTopic.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbQuizTopic.FormattingEnabled = true;
            this.cmbQuizTopic.Location = new System.Drawing.Point(130, 0);
            this.cmbQuizTopic.Name = "cmbQuizTopic";
            this.cmbQuizTopic.Size = new System.Drawing.Size(169, 23);
            this.cmbQuizTopic.TabIndex = 1;
            // 
            // lblQuizTopic
            // 
            this.lblQuizTopic.AutoSize = true;
            this.lblQuizTopic.Font = new System.Drawing.Font("Agency", 11F);
            this.lblQuizTopic.Location = new System.Drawing.Point(0, 5);
            this.lblQuizTopic.Name = "lblQuizTopic";
            this.lblQuizTopic.Size = new System.Drawing.Size(71, 17);
            this.lblQuizTopic.TabIndex = 0;
            this.lblQuizTopic.Text = "Topic";
            this.lblQuizTopic.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tabPhishingEmail
            // 
            this.tabPhishingEmail.Controls.Add(this.tlpPhishEditor);
            this.tabPhishingEmail.Location = new System.Drawing.Point(4, 32);
            this.tabPhishingEmail.Name = "tabPhishingEmail";
            this.tabPhishingEmail.Padding = new System.Windows.Forms.Padding(3);
            this.tabPhishingEmail.Size = new System.Drawing.Size(728, 278);
            this.tabPhishingEmail.TabIndex = 1;
            this.tabPhishingEmail.Text = "Phishing Email";
            this.tabPhishingEmail.UseVisualStyleBackColor = true;
            // 
            // tlpPhishEditor
            // 
            this.tlpPhishEditor.ColumnCount = 2;
            this.tlpPhishEditor.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 58F));
            this.tlpPhishEditor.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 42F));
            this.tlpPhishEditor.Controls.Add(this.pnlPhishLeft, 0, 0);
            this.tlpPhishEditor.Controls.Add(this.pnlPhishRight, 1, 0);
            this.tlpPhishEditor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpPhishEditor.Location = new System.Drawing.Point(3, 3);
            this.tlpPhishEditor.Name = "tlpPhishEditor";
            this.tlpPhishEditor.Padding = new System.Windows.Forms.Padding(8);
            this.tlpPhishEditor.RowCount = 1;
            this.tlpPhishEditor.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpPhishEditor.Size = new System.Drawing.Size(722, 272);
            this.tlpPhishEditor.TabIndex = 0;
            // 
            // pnlPhishLeft
            // 
            this.pnlPhishLeft.Controls.Add(this.rtbPhishExplanation);
            this.pnlPhishLeft.Controls.Add(this.lblPhishExplanation);
            this.pnlPhishLeft.Controls.Add(this.rtbPhishBody);
            this.pnlPhishLeft.Controls.Add(this.lblPhishBody);
            this.pnlPhishLeft.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlPhishLeft.Location = new System.Drawing.Point(8, 8);
            this.pnlPhishLeft.Margin = new System.Windows.Forms.Padding(0);
            this.pnlPhishLeft.Name = "pnlPhishLeft";
            this.pnlPhishLeft.Padding = new System.Windows.Forms.Padding(0, 0, 10, 0);
            this.pnlPhishLeft.Size = new System.Drawing.Size(409, 256);
            this.pnlPhishLeft.TabIndex = 0;
            // 
            // rtbPhishExplanation
            // 
            this.rtbPhishExplanation.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rtbPhishExplanation.Location = new System.Drawing.Point(0, 153);
            this.rtbPhishExplanation.Name = "rtbPhishExplanation";
            this.rtbPhishExplanation.Size = new System.Drawing.Size(409, 100);
            this.rtbPhishExplanation.TabIndex = 3;
            this.rtbPhishExplanation.Text = "";
            // 
            // lblPhishExplanation
            // 
            this.lblPhishExplanation.AutoSize = true;
            this.lblPhishExplanation.Font = new System.Drawing.Font("Agency", 12F);
            this.lblPhishExplanation.Location = new System.Drawing.Point(3, 132);
            this.lblPhishExplanation.Name = "lblPhishExplanation";
            this.lblPhishExplanation.Size = new System.Drawing.Size(164, 18);
            this.lblPhishExplanation.TabIndex = 2;
            this.lblPhishExplanation.Text = "EXPLANATION";
            // 
            // rtbPhishBody
            // 
            this.rtbPhishBody.Location = new System.Drawing.Point(0, 26);
            this.rtbPhishBody.Name = "rtbPhishBody";
            this.rtbPhishBody.Size = new System.Drawing.Size(409, 100);
            this.rtbPhishBody.TabIndex = 1;
            this.rtbPhishBody.Text = "";
            // 
            // lblPhishBody
            // 
            this.lblPhishBody.AutoSize = true;
            this.lblPhishBody.Font = new System.Drawing.Font("Agency", 12F);
            this.lblPhishBody.Location = new System.Drawing.Point(0, 0);
            this.lblPhishBody.Name = "lblPhishBody";
            this.lblPhishBody.Size = new System.Drawing.Size(142, 18);
            this.lblPhishBody.TabIndex = 0;
            this.lblPhishBody.Text = "EMAIL BODY";
            // 
            // pnlPhishRight
            // 
            this.pnlPhishRight.Controls.Add(this.txtPhishTags);
            this.pnlPhishRight.Controls.Add(this.lblPhishTags);
            this.pnlPhishRight.Controls.Add(this.txtLinkDisplayText);
            this.pnlPhishRight.Controls.Add(this.lblLinkDisplayText);
            this.pnlPhishRight.Controls.Add(this.txtAttachmentName);
            this.pnlPhishRight.Controls.Add(this.txtLinkUrl);
            this.pnlPhishRight.Controls.Add(this.chkHasAttachment);
            this.pnlPhishRight.Controls.Add(this.chkHasLink);
            this.pnlPhishRight.Controls.Add(this.chkIsPhishing);
            this.pnlPhishRight.Controls.Add(this.cmbPhishDifficulty);
            this.pnlPhishRight.Controls.Add(this.lblPhishDifficulty);
            this.pnlPhishRight.Controls.Add(this.txtPhishSubject);
            this.pnlPhishRight.Controls.Add(this.lblSubject);
            this.pnlPhishRight.Controls.Add(this.txtToEmail);
            this.pnlPhishRight.Controls.Add(this.lblToEmail);
            this.pnlPhishRight.Controls.Add(this.txtReplyTo);
            this.pnlPhishRight.Controls.Add(this.lblReplyTo);
            this.pnlPhishRight.Controls.Add(this.txtSenderEmail);
            this.pnlPhishRight.Controls.Add(this.lblSenderEmail);
            this.pnlPhishRight.Controls.Add(this.txtSenderName);
            this.pnlPhishRight.Controls.Add(this.lblSenderName);
            this.pnlPhishRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlPhishRight.Location = new System.Drawing.Point(417, 8);
            this.pnlPhishRight.Margin = new System.Windows.Forms.Padding(0);
            this.pnlPhishRight.Name = "pnlPhishRight";
            this.pnlPhishRight.Size = new System.Drawing.Size(297, 256);
            this.pnlPhishRight.TabIndex = 1;
            // 
            // txtPhishTags
            // 
            this.txtPhishTags.Location = new System.Drawing.Point(110, 290);
            this.txtPhishTags.Multiline = true;
            this.txtPhishTags.Name = "txtPhishTags";
            this.txtPhishTags.Size = new System.Drawing.Size(100, 26);
            this.txtPhishTags.TabIndex = 20;
            // 
            // lblPhishTags
            // 
            this.lblPhishTags.AutoSize = true;
            this.lblPhishTags.Font = new System.Drawing.Font("Agency", 8F);
            this.lblPhishTags.Location = new System.Drawing.Point(0, 290);
            this.lblPhishTags.Name = "lblPhishTags";
            this.lblPhishTags.Size = new System.Drawing.Size(46, 13);
            this.lblPhishTags.TabIndex = 19;
            this.lblPhishTags.Text = "TAGS";
            // 
            // txtLinkDisplayText
            // 
            this.txtLinkDisplayText.Location = new System.Drawing.Point(110, 260);
            this.txtLinkDisplayText.Name = "txtLinkDisplayText";
            this.txtLinkDisplayText.Size = new System.Drawing.Size(100, 28);
            this.txtLinkDisplayText.TabIndex = 18;
            // 
            // lblLinkDisplayText
            // 
            this.lblLinkDisplayText.AutoSize = true;
            this.lblLinkDisplayText.Font = new System.Drawing.Font("Agency", 8F);
            this.lblLinkDisplayText.Location = new System.Drawing.Point(0, 260);
            this.lblLinkDisplayText.Name = "lblLinkDisplayText";
            this.lblLinkDisplayText.Size = new System.Drawing.Size(80, 13);
            this.lblLinkDisplayText.TabIndex = 17;
            this.lblLinkDisplayText.Text = "LINK TEXT";
            // 
            // txtAttachmentName
            // 
            this.txtAttachmentName.Font = new System.Drawing.Font("Agency", 8F);
            this.txtAttachmentName.Location = new System.Drawing.Point(165, 234);
            this.txtAttachmentName.Name = "txtAttachmentName";
            this.txtAttachmentName.Size = new System.Drawing.Size(132, 24);
            this.txtAttachmentName.TabIndex = 16;
            this.txtAttachmentName.Visible = false;
            // 
            // txtLinkUrl
            // 
            this.txtLinkUrl.Font = new System.Drawing.Font("Agency", 8F);
            this.txtLinkUrl.Location = new System.Drawing.Point(123, 205);
            this.txtLinkUrl.Name = "txtLinkUrl";
            this.txtLinkUrl.Size = new System.Drawing.Size(174, 24);
            this.txtLinkUrl.TabIndex = 15;
            this.txtLinkUrl.Visible = false;
            this.txtLinkUrl.TextChanged += new System.EventHandler(this.txtLinkUrl_TextChanged);
            // 
            // chkHasAttachment
            // 
            this.chkHasAttachment.AutoSize = true;
            this.chkHasAttachment.Font = new System.Drawing.Font("Agency", 8F);
            this.chkHasAttachment.Location = new System.Drawing.Point(0, 235);
            this.chkHasAttachment.Name = "chkHasAttachment";
            this.chkHasAttachment.Size = new System.Drawing.Size(168, 21);
            this.chkHasAttachment.TabIndex = 14;
            this.chkHasAttachment.Text = "Has Attachment";
            this.chkHasAttachment.UseVisualStyleBackColor = true;
            this.chkHasAttachment.CheckedChanged += new System.EventHandler(this.chkHasAttachment_CheckedChanged);
            // 
            // chkHasLink
            // 
            this.chkHasLink.AutoSize = true;
            this.chkHasLink.Font = new System.Drawing.Font("Agency", 8F);
            this.chkHasLink.Location = new System.Drawing.Point(0, 210);
            this.chkHasLink.Name = "chkHasLink";
            this.chkHasLink.Size = new System.Drawing.Size(101, 21);
            this.chkHasLink.TabIndex = 13;
            this.chkHasLink.Text = "Has Link";
            this.chkHasLink.UseVisualStyleBackColor = true;
            this.chkHasLink.CheckedChanged += new System.EventHandler(this.chkHasLink_CheckedChanged);
            // 
            // chkIsPhishing
            // 
            this.chkIsPhishing.AutoSize = true;
            this.chkIsPhishing.Font = new System.Drawing.Font("Agency", 8F);
            this.chkIsPhishing.Location = new System.Drawing.Point(0, 185);
            this.chkIsPhishing.Name = "chkIsPhishing";
            this.chkIsPhishing.Size = new System.Drawing.Size(122, 21);
            this.chkIsPhishing.TabIndex = 12;
            this.chkIsPhishing.Text = "Is Phishing";
            this.chkIsPhishing.UseVisualStyleBackColor = true;
            // 
            // cmbPhishDifficulty
            // 
            this.cmbPhishDifficulty.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPhishDifficulty.Font = new System.Drawing.Font("Agency", 9F);
            this.cmbPhishDifficulty.FormattingEnabled = true;
            this.cmbPhishDifficulty.Location = new System.Drawing.Point(145, 160);
            this.cmbPhishDifficulty.Margin = new System.Windows.Forms.Padding(0, 4, 10, 4);
            this.cmbPhishDifficulty.Name = "cmbPhishDifficulty";
            this.cmbPhishDifficulty.Size = new System.Drawing.Size(152, 22);
            this.cmbPhishDifficulty.TabIndex = 11;
            // 
            // lblPhishDifficulty
            // 
            this.lblPhishDifficulty.AutoSize = true;
            this.lblPhishDifficulty.Font = new System.Drawing.Font("Agency", 9F);
            this.lblPhishDifficulty.Location = new System.Drawing.Point(0, 163);
            this.lblPhishDifficulty.Name = "lblPhishDifficulty";
            this.lblPhishDifficulty.Size = new System.Drawing.Size(104, 14);
            this.lblPhishDifficulty.TabIndex = 10;
            this.lblPhishDifficulty.Text = "Difficulty";
            // 
            // txtPhishSubject
            // 
            this.txtPhishSubject.Font = new System.Drawing.Font("Agency", 9F);
            this.txtPhishSubject.Location = new System.Drawing.Point(145, 127);
            this.txtPhishSubject.Name = "txtPhishSubject";
            this.txtPhishSubject.Size = new System.Drawing.Size(152, 26);
            this.txtPhishSubject.TabIndex = 9;
            // 
            // lblSubject
            // 
            this.lblSubject.AutoSize = true;
            this.lblSubject.Font = new System.Drawing.Font("Agency", 9F);
            this.lblSubject.Location = new System.Drawing.Point(0, 132);
            this.lblSubject.Name = "lblSubject";
            this.lblSubject.Size = new System.Drawing.Size(81, 14);
            this.lblSubject.TabIndex = 8;
            this.lblSubject.Text = "Subject";
            // 
            // txtToEmail
            // 
            this.txtToEmail.Font = new System.Drawing.Font("Agency", 9F);
            this.txtToEmail.Location = new System.Drawing.Point(145, 95);
            this.txtToEmail.Name = "txtToEmail";
            this.txtToEmail.Size = new System.Drawing.Size(152, 26);
            this.txtToEmail.TabIndex = 7;
            // 
            // lblToEmail
            // 
            this.lblToEmail.AutoSize = true;
            this.lblToEmail.Font = new System.Drawing.Font("Agency", 9F);
            this.lblToEmail.Location = new System.Drawing.Point(-2, 98);
            this.lblToEmail.Name = "lblToEmail";
            this.lblToEmail.Size = new System.Drawing.Size(85, 14);
            this.lblToEmail.TabIndex = 6;
            this.lblToEmail.Text = "To Email";
            // 
            // txtReplyTo
            // 
            this.txtReplyTo.Font = new System.Drawing.Font("Agency", 9F);
            this.txtReplyTo.Location = new System.Drawing.Point(145, 63);
            this.txtReplyTo.Name = "txtReplyTo";
            this.txtReplyTo.Size = new System.Drawing.Size(152, 26);
            this.txtReplyTo.TabIndex = 5;
            // 
            // lblReplyTo
            // 
            this.lblReplyTo.AutoSize = true;
            this.lblReplyTo.Font = new System.Drawing.Font("Agency", 9F);
            this.lblReplyTo.Location = new System.Drawing.Point(-2, 66);
            this.lblReplyTo.Name = "lblReplyTo";
            this.lblReplyTo.Size = new System.Drawing.Size(87, 14);
            this.lblReplyTo.TabIndex = 4;
            this.lblReplyTo.Text = "Reply To";
            // 
            // txtSenderEmail
            // 
            this.txtSenderEmail.Font = new System.Drawing.Font("Agency", 9F);
            this.txtSenderEmail.Location = new System.Drawing.Point(145, 31);
            this.txtSenderEmail.Name = "txtSenderEmail";
            this.txtSenderEmail.Size = new System.Drawing.Size(152, 26);
            this.txtSenderEmail.TabIndex = 3;
            // 
            // lblSenderEmail
            // 
            this.lblSenderEmail.AutoSize = true;
            this.lblSenderEmail.Font = new System.Drawing.Font("Agency", 9F);
            this.lblSenderEmail.Location = new System.Drawing.Point(-2, 34);
            this.lblSenderEmail.Name = "lblSenderEmail";
            this.lblSenderEmail.Size = new System.Drawing.Size(131, 14);
            this.lblSenderEmail.TabIndex = 2;
            this.lblSenderEmail.Text = "Sender Email";
            // 
            // txtSenderName
            // 
            this.txtSenderName.Font = new System.Drawing.Font("Agency", 9F);
            this.txtSenderName.Location = new System.Drawing.Point(145, 0);
            this.txtSenderName.Name = "txtSenderName";
            this.txtSenderName.Size = new System.Drawing.Size(152, 26);
            this.txtSenderName.TabIndex = 1;
            // 
            // lblSenderName
            // 
            this.lblSenderName.AutoSize = true;
            this.lblSenderName.Font = new System.Drawing.Font("Agency", 9F);
            this.lblSenderName.Location = new System.Drawing.Point(0, 5);
            this.lblSenderName.Name = "lblSenderName";
            this.lblSenderName.Size = new System.Drawing.Size(129, 14);
            this.lblSenderName.TabIndex = 0;
            this.lblSenderName.Text = "Sender Name";
            // 
            // tabAuthScenario
            // 
            this.tabAuthScenario.Controls.Add(this.tlpAuthEditor);
            this.tabAuthScenario.Location = new System.Drawing.Point(4, 32);
            this.tabAuthScenario.Name = "tabAuthScenario";
            this.tabAuthScenario.Size = new System.Drawing.Size(728, 278);
            this.tabAuthScenario.TabIndex = 2;
            this.tabAuthScenario.Text = "Auth Scenario";
            this.tabAuthScenario.UseVisualStyleBackColor = true;
            // 
            // tlpAuthEditor
            // 
            this.tlpAuthEditor.ColumnCount = 2;
            this.tlpAuthEditor.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 55F));
            this.tlpAuthEditor.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 45F));
            this.tlpAuthEditor.Controls.Add(this.pnlAuthLeft, 0, 0);
            this.tlpAuthEditor.Controls.Add(this.pnlAuthRight, 1, 0);
            this.tlpAuthEditor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpAuthEditor.Location = new System.Drawing.Point(0, 0);
            this.tlpAuthEditor.Margin = new System.Windows.Forms.Padding(0);
            this.tlpAuthEditor.Name = "tlpAuthEditor";
            this.tlpAuthEditor.Padding = new System.Windows.Forms.Padding(8);
            this.tlpAuthEditor.RowCount = 1;
            this.tlpAuthEditor.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpAuthEditor.Size = new System.Drawing.Size(728, 278);
            this.tlpAuthEditor.TabIndex = 0;
            // 
            // pnlAuthLeft
            // 
            this.pnlAuthLeft.Controls.Add(this.txtScenarioTags);
            this.pnlAuthLeft.Controls.Add(this.lblScenarioTags);
            this.pnlAuthLeft.Controls.Add(this.rtbScenarioHints);
            this.pnlAuthLeft.Controls.Add(this.lblScenarioHints);
            this.pnlAuthLeft.Controls.Add(this.rtbScenarioBody);
            this.pnlAuthLeft.Controls.Add(this.lblScenarioBody);
            this.pnlAuthLeft.Controls.Add(this.txtScenarioTitle);
            this.pnlAuthLeft.Controls.Add(this.lblScenarioTitle);
            this.pnlAuthLeft.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlAuthLeft.Location = new System.Drawing.Point(8, 8);
            this.pnlAuthLeft.Margin = new System.Windows.Forms.Padding(0);
            this.pnlAuthLeft.Name = "pnlAuthLeft";
            this.pnlAuthLeft.Padding = new System.Windows.Forms.Padding(0, 0, 10, 0);
            this.pnlAuthLeft.Size = new System.Drawing.Size(391, 262);
            this.pnlAuthLeft.TabIndex = 0;
            // 
            // txtScenarioTags
            // 
            this.txtScenarioTags.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.txtScenarioTags.Location = new System.Drawing.Point(-3, 255);
            this.txtScenarioTags.Multiline = true;
            this.txtScenarioTags.Name = "txtScenarioTags";
            this.txtScenarioTags.Size = new System.Drawing.Size(391, 48);
            this.txtScenarioTags.TabIndex = 7;
            // 
            // lblScenarioTags
            // 
            this.lblScenarioTags.AutoSize = true;
            this.lblScenarioTags.Font = new System.Drawing.Font("Agency", 11F);
            this.lblScenarioTags.Location = new System.Drawing.Point(-3, 234);
            this.lblScenarioTags.Name = "lblScenarioTags";
            this.lblScenarioTags.Size = new System.Drawing.Size(64, 17);
            this.lblScenarioTags.TabIndex = 6;
            this.lblScenarioTags.Text = "TAGS";
            // 
            // rtbScenarioHints
            // 
            this.rtbScenarioHints.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rtbScenarioHints.Location = new System.Drawing.Point(0, 167);
            this.rtbScenarioHints.Name = "rtbScenarioHints";
            this.rtbScenarioHints.Size = new System.Drawing.Size(391, 64);
            this.rtbScenarioHints.TabIndex = 5;
            this.rtbScenarioHints.Text = "";
            // 
            // lblScenarioHints
            // 
            this.lblScenarioHints.AutoSize = true;
            this.lblScenarioHints.Font = new System.Drawing.Font("Agency", 11F);
            this.lblScenarioHints.Location = new System.Drawing.Point(0, 147);
            this.lblScenarioHints.Name = "lblScenarioHints";
            this.lblScenarioHints.Size = new System.Drawing.Size(69, 17);
            this.lblScenarioHints.TabIndex = 4;
            this.lblScenarioHints.Text = "HINTS";
            // 
            // rtbScenarioBody
            // 
            this.rtbScenarioBody.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rtbScenarioBody.Location = new System.Drawing.Point(0, 96);
            this.rtbScenarioBody.Name = "rtbScenarioBody";
            this.rtbScenarioBody.Size = new System.Drawing.Size(391, 48);
            this.rtbScenarioBody.TabIndex = 3;
            this.rtbScenarioBody.Text = "";
            // 
            // lblScenarioBody
            // 
            this.lblScenarioBody.AutoSize = true;
            this.lblScenarioBody.Font = new System.Drawing.Font("Agency", 11F);
            this.lblScenarioBody.Location = new System.Drawing.Point(0, 76);
            this.lblScenarioBody.Name = "lblScenarioBody";
            this.lblScenarioBody.Size = new System.Drawing.Size(180, 17);
            this.lblScenarioBody.TabIndex = 2;
            this.lblScenarioBody.Text = "SCENARIO BODY";
            // 
            // txtScenarioTitle
            // 
            this.txtScenarioTitle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtScenarioTitle.Location = new System.Drawing.Point(0, 20);
            this.txtScenarioTitle.Multiline = true;
            this.txtScenarioTitle.Name = "txtScenarioTitle";
            this.txtScenarioTitle.Size = new System.Drawing.Size(391, 48);
            this.txtScenarioTitle.TabIndex = 1;
            // 
            // lblScenarioTitle
            // 
            this.lblScenarioTitle.AutoSize = true;
            this.lblScenarioTitle.Font = new System.Drawing.Font("Agency", 11F);
            this.lblScenarioTitle.Location = new System.Drawing.Point(0, 0);
            this.lblScenarioTitle.Name = "lblScenarioTitle";
            this.lblScenarioTitle.Size = new System.Drawing.Size(174, 17);
            this.lblScenarioTitle.TabIndex = 0;
            this.lblScenarioTitle.Text = "SCENARIO TITLE";
            // 
            // pnlAuthRight
            // 
            this.pnlAuthRight.Controls.Add(this.gbAuthRequirements);
            this.pnlAuthRight.Controls.Add(this.cmbRecRecovery);
            this.pnlAuthRight.Controls.Add(this.cmbRecAuthMethod);
            this.pnlAuthRight.Controls.Add(this.cmbAuthDifficulty);
            this.pnlAuthRight.Controls.Add(this.cmbGoalType);
            this.pnlAuthRight.Controls.Add(this.cmbThreatType);
            this.pnlAuthRight.Controls.Add(this.cmbRecSession);
            this.pnlAuthRight.Controls.Add(this.lblRecSession);
            this.pnlAuthRight.Controls.Add(this.lblRecRecovery);
            this.pnlAuthRight.Controls.Add(this.lblRecAuthMethod);
            this.pnlAuthRight.Controls.Add(this.lblAuthDifficulty);
            this.pnlAuthRight.Controls.Add(this.lblGoalType);
            this.pnlAuthRight.Controls.Add(this.lblThreatType);
            this.pnlAuthRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlAuthRight.Location = new System.Drawing.Point(399, 8);
            this.pnlAuthRight.Margin = new System.Windows.Forms.Padding(0);
            this.pnlAuthRight.Name = "pnlAuthRight";
            this.pnlAuthRight.Size = new System.Drawing.Size(321, 262);
            this.pnlAuthRight.TabIndex = 1;
            // 
            // gbAuthRequirements
            // 
            this.gbAuthRequirements.Controls.Add(this.chkReqAlertOnSuspicious);
            this.gbAuthRequirements.Controls.Add(this.chkReqDeviceBinding);
            this.gbAuthRequirements.Controls.Add(this.chkReqLegacyBlock);
            this.gbAuthRequirements.Controls.Add(this.chkReqStepUp);
            this.gbAuthRequirements.Controls.Add(this.chkReqPhishResistant);
            this.gbAuthRequirements.Controls.Add(this.chkReqMfa);
            this.gbAuthRequirements.Font = new System.Drawing.Font("Agency", 8F);
            this.gbAuthRequirements.Location = new System.Drawing.Point(0, 197);
            this.gbAuthRequirements.Name = "gbAuthRequirements";
            this.gbAuthRequirements.Size = new System.Drawing.Size(318, 130);
            this.gbAuthRequirements.TabIndex = 29;
            this.gbAuthRequirements.TabStop = false;
            this.gbAuthRequirements.Text = "REQUIRED CONTROLS";
            // 
            // chkReqAlertOnSuspicious
            // 
            this.chkReqAlertOnSuspicious.AutoSize = true;
            this.chkReqAlertOnSuspicious.Font = new System.Drawing.Font("Agency", 8F);
            this.chkReqAlertOnSuspicious.Location = new System.Drawing.Point(8, 96);
            this.chkReqAlertOnSuspicious.Name = "chkReqAlertOnSuspicious";
            this.chkReqAlertOnSuspicious.Size = new System.Drawing.Size(197, 21);
            this.chkReqAlertOnSuspicious.TabIndex = 5;
            this.chkReqAlertOnSuspicious.Text = "ALERT ON SUSPICIOUS";
            this.chkReqAlertOnSuspicious.UseVisualStyleBackColor = true;
            // 
            // chkReqDeviceBinding
            // 
            this.chkReqDeviceBinding.AutoSize = true;
            this.chkReqDeviceBinding.Font = new System.Drawing.Font("Agency", 8F);
            this.chkReqDeviceBinding.Location = new System.Drawing.Point(8, 72);
            this.chkReqDeviceBinding.Name = "chkReqDeviceBinding";
            this.chkReqDeviceBinding.Size = new System.Drawing.Size(155, 21);
            this.chkReqDeviceBinding.TabIndex = 4;
            this.chkReqDeviceBinding.Text = "DEVICE BINDING";
            this.chkReqDeviceBinding.UseVisualStyleBackColor = true;
            // 
            // chkReqLegacyBlock
            // 
            this.chkReqLegacyBlock.AutoSize = true;
            this.chkReqLegacyBlock.Location = new System.Drawing.Point(107, 46);
            this.chkReqLegacyBlock.Name = "chkReqLegacyBlock";
            this.chkReqLegacyBlock.Size = new System.Drawing.Size(145, 21);
            this.chkReqLegacyBlock.TabIndex = 3;
            this.chkReqLegacyBlock.Text = "Block Legacy";
            this.chkReqLegacyBlock.UseVisualStyleBackColor = true;
            // 
            // chkReqStepUp
            // 
            this.chkReqStepUp.AutoSize = true;
            this.chkReqStepUp.Location = new System.Drawing.Point(8, 46);
            this.chkReqStepUp.Name = "chkReqStepUp";
            this.chkReqStepUp.Size = new System.Drawing.Size(93, 21);
            this.chkReqStepUp.TabIndex = 2;
            this.chkReqStepUp.Text = "Step-Up";
            this.chkReqStepUp.UseVisualStyleBackColor = true;
            // 
            // chkReqPhishResistant
            // 
            this.chkReqPhishResistant.AutoSize = true;
            this.chkReqPhishResistant.Location = new System.Drawing.Point(80, 22);
            this.chkReqPhishResistant.Name = "chkReqPhishResistant";
            this.chkReqPhishResistant.Size = new System.Drawing.Size(190, 21);
            this.chkReqPhishResistant.TabIndex = 1;
            this.chkReqPhishResistant.Text = "Phishing-Resistant";
            this.chkReqPhishResistant.UseVisualStyleBackColor = true;
            // 
            // chkReqMfa
            // 
            this.chkReqMfa.AutoSize = true;
            this.chkReqMfa.Location = new System.Drawing.Point(8, 22);
            this.chkReqMfa.Name = "chkReqMfa";
            this.chkReqMfa.Size = new System.Drawing.Size(66, 21);
            this.chkReqMfa.TabIndex = 0;
            this.chkReqMfa.Text = "MFA";
            this.chkReqMfa.UseVisualStyleBackColor = true;
            // 
            // cmbRecRecovery
            // 
            this.cmbRecRecovery.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbRecRecovery.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbRecRecovery.Font = new System.Drawing.Font("Agency", 9F);
            this.cmbRecRecovery.FormattingEnabled = true;
            this.cmbRecRecovery.Location = new System.Drawing.Point(156, 130);
            this.cmbRecRecovery.Margin = new System.Windows.Forms.Padding(0, 4, 10, 4);
            this.cmbRecRecovery.Name = "cmbRecRecovery";
            this.cmbRecRecovery.Size = new System.Drawing.Size(152, 22);
            this.cmbRecRecovery.TabIndex = 28;
            // 
            // cmbRecAuthMethod
            // 
            this.cmbRecAuthMethod.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbRecAuthMethod.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbRecAuthMethod.Font = new System.Drawing.Font("Agency", 9F);
            this.cmbRecAuthMethod.FormattingEnabled = true;
            this.cmbRecAuthMethod.Location = new System.Drawing.Point(156, 97);
            this.cmbRecAuthMethod.Margin = new System.Windows.Forms.Padding(0, 4, 10, 4);
            this.cmbRecAuthMethod.Name = "cmbRecAuthMethod";
            this.cmbRecAuthMethod.Size = new System.Drawing.Size(152, 22);
            this.cmbRecAuthMethod.TabIndex = 27;
            // 
            // cmbAuthDifficulty
            // 
            this.cmbAuthDifficulty.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbAuthDifficulty.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbAuthDifficulty.Font = new System.Drawing.Font("Agency", 9F);
            this.cmbAuthDifficulty.FormattingEnabled = true;
            this.cmbAuthDifficulty.Location = new System.Drawing.Point(156, 64);
            this.cmbAuthDifficulty.Margin = new System.Windows.Forms.Padding(0, 4, 10, 4);
            this.cmbAuthDifficulty.Name = "cmbAuthDifficulty";
            this.cmbAuthDifficulty.Size = new System.Drawing.Size(152, 22);
            this.cmbAuthDifficulty.TabIndex = 26;
            // 
            // cmbGoalType
            // 
            this.cmbGoalType.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbGoalType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbGoalType.Font = new System.Drawing.Font("Agency", 9F);
            this.cmbGoalType.FormattingEnabled = true;
            this.cmbGoalType.Location = new System.Drawing.Point(156, 34);
            this.cmbGoalType.Margin = new System.Windows.Forms.Padding(0, 4, 10, 4);
            this.cmbGoalType.Name = "cmbGoalType";
            this.cmbGoalType.Size = new System.Drawing.Size(152, 22);
            this.cmbGoalType.TabIndex = 25;
            // 
            // cmbThreatType
            // 
            this.cmbThreatType.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbThreatType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbThreatType.Font = new System.Drawing.Font("Agency", 9F);
            this.cmbThreatType.FormattingEnabled = true;
            this.cmbThreatType.Location = new System.Drawing.Point(156, 5);
            this.cmbThreatType.Margin = new System.Windows.Forms.Padding(0, 4, 10, 4);
            this.cmbThreatType.Name = "cmbThreatType";
            this.cmbThreatType.Size = new System.Drawing.Size(152, 22);
            this.cmbThreatType.TabIndex = 24;
            // 
            // cmbRecSession
            // 
            this.cmbRecSession.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbRecSession.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbRecSession.Font = new System.Drawing.Font("Agency", 9F);
            this.cmbRecSession.FormattingEnabled = true;
            this.cmbRecSession.Location = new System.Drawing.Point(156, 163);
            this.cmbRecSession.Margin = new System.Windows.Forms.Padding(0, 4, 10, 4);
            this.cmbRecSession.Name = "cmbRecSession";
            this.cmbRecSession.Size = new System.Drawing.Size(152, 22);
            this.cmbRecSession.TabIndex = 23;
            // 
            // lblRecSession
            // 
            this.lblRecSession.Font = new System.Drawing.Font("Agency", 9F);
            this.lblRecSession.Location = new System.Drawing.Point(9, 166);
            this.lblRecSession.Name = "lblRecSession";
            this.lblRecSession.Size = new System.Drawing.Size(142, 14);
            this.lblRecSession.TabIndex = 22;
            this.lblRecSession.Text = "Rec. Session";
            // 
            // lblRecRecovery
            // 
            this.lblRecRecovery.Font = new System.Drawing.Font("Agency", 9F);
            this.lblRecRecovery.Location = new System.Drawing.Point(9, 133);
            this.lblRecRecovery.Name = "lblRecRecovery";
            this.lblRecRecovery.Size = new System.Drawing.Size(153, 14);
            this.lblRecRecovery.TabIndex = 20;
            this.lblRecRecovery.Text = "Rec. Recovery";
            // 
            // lblRecAuthMethod
            // 
            this.lblRecAuthMethod.Font = new System.Drawing.Font("Agency", 9F);
            this.lblRecAuthMethod.Location = new System.Drawing.Point(9, 101);
            this.lblRecAuthMethod.Name = "lblRecAuthMethod";
            this.lblRecAuthMethod.Size = new System.Drawing.Size(175, 14);
            this.lblRecAuthMethod.TabIndex = 18;
            this.lblRecAuthMethod.Text = "Rec. Method";
            // 
            // lblAuthDifficulty
            // 
            this.lblAuthDifficulty.AutoSize = true;
            this.lblAuthDifficulty.Font = new System.Drawing.Font("Agency", 9F);
            this.lblAuthDifficulty.Location = new System.Drawing.Point(9, 69);
            this.lblAuthDifficulty.Name = "lblAuthDifficulty";
            this.lblAuthDifficulty.Size = new System.Drawing.Size(104, 14);
            this.lblAuthDifficulty.TabIndex = 16;
            this.lblAuthDifficulty.Text = "Difficulty";
            // 
            // lblGoalType
            // 
            this.lblGoalType.AutoSize = true;
            this.lblGoalType.Font = new System.Drawing.Font("Agency", 9F);
            this.lblGoalType.Location = new System.Drawing.Point(9, 37);
            this.lblGoalType.Name = "lblGoalType";
            this.lblGoalType.Size = new System.Drawing.Size(100, 14);
            this.lblGoalType.TabIndex = 14;
            this.lblGoalType.Text = "Goal Type";
            // 
            // lblThreatType
            // 
            this.lblThreatType.AutoSize = true;
            this.lblThreatType.Font = new System.Drawing.Font("Agency", 9F);
            this.lblThreatType.Location = new System.Drawing.Point(9, 8);
            this.lblThreatType.Name = "lblThreatType";
            this.lblThreatType.Size = new System.Drawing.Size(119, 14);
            this.lblThreatType.TabIndex = 12;
            this.lblThreatType.Text = "Threat Type";
            // 
            // tlpBankActions
            // 
            this.tlpBankActions.ColumnCount = 4;
            this.tlpBankActions.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpBankActions.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpBankActions.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpBankActions.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpBankActions.Controls.Add(this.btnRevertChanges, 3, 0);
            this.tlpBankActions.Controls.Add(this.btnSaveAll, 2, 0);
            this.tlpBankActions.Controls.Add(this.btnSaveItem, 1, 0);
            this.tlpBankActions.Controls.Add(this.btnLoadSelected, 0, 0);
            this.tlpBankActions.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpBankActions.Location = new System.Drawing.Point(0, 376);
            this.tlpBankActions.Margin = new System.Windows.Forms.Padding(0);
            this.tlpBankActions.Name = "tlpBankActions";
            this.tlpBankActions.RowCount = 1;
            this.tlpBankActions.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpBankActions.Size = new System.Drawing.Size(1022, 46);
            this.tlpBankActions.TabIndex = 2;
            // 
            // btnRevertChanges
            // 
            this.btnRevertChanges.BackColor = System.Drawing.Color.RoyalBlue;
            this.btnRevertChanges.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnRevertChanges.Font = new System.Drawing.Font("Muro", 15F);
            this.btnRevertChanges.ForeColor = System.Drawing.Color.White;
            this.btnRevertChanges.Location = new System.Drawing.Point(768, 3);
            this.btnRevertChanges.Name = "btnRevertChanges";
            this.btnRevertChanges.Size = new System.Drawing.Size(251, 40);
            this.btnRevertChanges.Style.BackColor = System.Drawing.Color.RoyalBlue;
            this.btnRevertChanges.Style.ForeColor = System.Drawing.Color.White;
            this.btnRevertChanges.TabIndex = 3;
            this.btnRevertChanges.Text = "Revert Changes";
            this.btnRevertChanges.UseVisualStyleBackColor = false;
            this.btnRevertChanges.Click += new System.EventHandler(this.btnRevertChanges_Click);
            // 
            // btnSaveAll
            // 
            this.btnSaveAll.BackColor = System.Drawing.Color.RoyalBlue;
            this.btnSaveAll.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnSaveAll.Font = new System.Drawing.Font("Muro", 15F);
            this.btnSaveAll.ForeColor = System.Drawing.Color.White;
            this.btnSaveAll.Location = new System.Drawing.Point(513, 3);
            this.btnSaveAll.Name = "btnSaveAll";
            this.btnSaveAll.Size = new System.Drawing.Size(249, 40);
            this.btnSaveAll.Style.BackColor = System.Drawing.Color.RoyalBlue;
            this.btnSaveAll.Style.ForeColor = System.Drawing.Color.White;
            this.btnSaveAll.TabIndex = 2;
            this.btnSaveAll.Text = "Save All";
            this.btnSaveAll.UseVisualStyleBackColor = false;
            this.btnSaveAll.Click += new System.EventHandler(this.btnSaveAll_Click);
            // 
            // btnSaveItem
            // 
            this.btnSaveItem.BackColor = System.Drawing.Color.RoyalBlue;
            this.btnSaveItem.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnSaveItem.Font = new System.Drawing.Font("Muro", 15F);
            this.btnSaveItem.ForeColor = System.Drawing.Color.White;
            this.btnSaveItem.Location = new System.Drawing.Point(258, 3);
            this.btnSaveItem.Name = "btnSaveItem";
            this.btnSaveItem.Size = new System.Drawing.Size(249, 40);
            this.btnSaveItem.Style.BackColor = System.Drawing.Color.RoyalBlue;
            this.btnSaveItem.Style.ForeColor = System.Drawing.Color.White;
            this.btnSaveItem.TabIndex = 1;
            this.btnSaveItem.Text = "Save Item";
            this.btnSaveItem.UseVisualStyleBackColor = false;
            this.btnSaveItem.Click += new System.EventHandler(this.btnSaveItem_Click);
            // 
            // btnLoadSelected
            // 
            this.btnLoadSelected.BackColor = System.Drawing.Color.RoyalBlue;
            this.btnLoadSelected.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnLoadSelected.Font = new System.Drawing.Font("Muro", 15F);
            this.btnLoadSelected.ForeColor = System.Drawing.Color.White;
            this.btnLoadSelected.Location = new System.Drawing.Point(3, 3);
            this.btnLoadSelected.Name = "btnLoadSelected";
            this.btnLoadSelected.Size = new System.Drawing.Size(249, 40);
            this.btnLoadSelected.Style.BackColor = System.Drawing.Color.RoyalBlue;
            this.btnLoadSelected.Style.ForeColor = System.Drawing.Color.White;
            this.btnLoadSelected.TabIndex = 0;
            this.btnLoadSelected.Text = "Load Selected";
            this.btnLoadSelected.UseVisualStyleBackColor = false;
            this.btnLoadSelected.Click += new System.EventHandler(this.btnLoadSelected_Click);
            // 
            // AdminDashboardForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(15F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gainsboro;
            this.ClientSize = new System.Drawing.Size(1929, 777);
            this.Controls.Add(this.pnlContent);
            this.Controls.Add(this.pnlSidebar);
            this.Font = new System.Drawing.Font("Agency", 12F);
            this.Margin = new System.Windows.Forms.Padding(5, 2, 5, 2);
            this.MinimumSize = new System.Drawing.Size(1918, 816);
            this.Name = "AdminDashboardForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Style.BackColor = System.Drawing.Color.Gainsboro;
            this.Style.MdiChild.IconHorizontalAlignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.Style.MdiChild.IconVerticalAlignment = System.Windows.Forms.VisualStyles.VerticalAlignment.Center;
            this.Text = "Admin Dashboard - Mondas";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.AdminDashboardForm_Load);
            pnlToolbar.ResumeLayout(false);
            this.tlpToolbar.ResumeLayout(false);
            this.tlpToolbar.PerformLayout();
            this.pnlSidebar.ResumeLayout(false);
            this.pnlSidebar.PerformLayout();
            this.pnlContent.ResumeLayout(false);
            this.tlpPage.ResumeLayout(false);
            this.pnlFooter.ResumeLayout(false);
            this.pnlFooter.PerformLayout();
            this.tlpStats.ResumeLayout(false);
            this.pnlTotalUsers.ResumeLayout(false);
            this.pnlActiveToday.ResumeLayout(false);
            this.pnlAvgAccuracy.ResumeLayout(false);
            this.pnlAtRiskUsers.ResumeLayout(false);
            this.pnlTotalContent.ResumeLayout(false);
            this.tlpHeader.ResumeLayout(false);
            this.pnlHeaderRight.ResumeLayout(false);
            this.pnlHeaderRight.PerformLayout();
            this.pnlHeaderLeft.ResumeLayout(false);
            this.pnlHeaderLeft.PerformLayout();
            this.tlpMain.ResumeLayout(false);
            this.tlpLeft.ResumeLayout(false);
            this.gbUsersOverview.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsers)).EndInit();
            this.gbTopMisconceptions.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMisconceptions)).EndInit();
            this.gbRecentActivity.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvRecentActivity)).EndInit();
            this.gbContentBank.ResumeLayout(false);
            this.tlpContentBank.ResumeLayout(false);
            this.tlpBankToolbar.ResumeLayout(false);
            this.tlpBankToolbar.PerformLayout();
            this.splitBank.Panel1.ResumeLayout(false);
            this.splitBank.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitBank)).EndInit();
            this.splitBank.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvBankItems)).EndInit();
            this.tabEditor.ResumeLayout(false);
            this.tabQuizQuestion.ResumeLayout(false);
            this.tlpQuizEditor.ResumeLayout(false);
            this.pnlQuizEditorLeft.ResumeLayout(false);
            this.pnlQuizEditorLeft.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvQuizOptions)).EndInit();
            this.pnlQuizEditorRight.ResumeLayout(false);
            this.pnlQuizEditorRight.PerformLayout();
            this.tabPhishingEmail.ResumeLayout(false);
            this.tlpPhishEditor.ResumeLayout(false);
            this.pnlPhishLeft.ResumeLayout(false);
            this.pnlPhishLeft.PerformLayout();
            this.pnlPhishRight.ResumeLayout(false);
            this.pnlPhishRight.PerformLayout();
            this.tabAuthScenario.ResumeLayout(false);
            this.tlpAuthEditor.ResumeLayout(false);
            this.pnlAuthLeft.ResumeLayout(false);
            this.pnlAuthLeft.PerformLayout();
            this.pnlAuthRight.ResumeLayout(false);
            this.pnlAuthRight.PerformLayout();
            this.gbAuthRequirements.ResumeLayout(false);
            this.gbAuthRequirements.PerformLayout();
            this.tlpBankActions.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlSidebar;
        private System.Windows.Forms.Panel pnlContent;
        private System.Windows.Forms.Label lblMondas;
        private System.Windows.Forms.Label lblAdminBadge;
        private System.Windows.Forms.Panel pnlSidebarSpacer;
        private System.Windows.Forms.TableLayoutPanel tlpPage;
        private System.Windows.Forms.TableLayoutPanel tlpHeader;
        private System.Windows.Forms.Panel pnlHeaderLeft;
        private System.Windows.Forms.Panel pnlHeaderRight;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.Label lblAdminUser;
        private System.Windows.Forms.Label lblWelcome;
        private System.Windows.Forms.Label lblSub;
        private System.Windows.Forms.TableLayoutPanel tlpStats;
        private System.Windows.Forms.Panel pnlTotalUsers;
        private System.Windows.Forms.Label lblTotalUsersValue;
        private System.Windows.Forms.Label lblTotalUsersTitle;
        private System.Windows.Forms.Panel pnlActiveToday;
        private System.Windows.Forms.Label lblActiveTodayValue;
        private System.Windows.Forms.Label lblActiveTodayTitle;
        private System.Windows.Forms.Panel pnlAvgAccuracy;
        private System.Windows.Forms.Label lblAvgAccuracyValue;
        private System.Windows.Forms.Label lblAvgAccuracyTitle;
        private System.Windows.Forms.Panel pnlAtRiskUsers;
        private System.Windows.Forms.Label lblAtRiskUsersValue;
        private System.Windows.Forms.Label lblAtRiskUsersTitle;
        private System.Windows.Forms.Panel pnlTotalContent;
        private System.Windows.Forms.Label lblTotalContentValue;
        private System.Windows.Forms.Label lblTotalContentTitle;
        private System.Windows.Forms.TableLayoutPanel tlpToolbar;
        private System.Windows.Forms.Label lblRange;
        private System.Windows.Forms.ComboBox cmbRange;
        private System.Windows.Forms.Label lblContentType;
        private System.Windows.Forms.ComboBox cmbContentType;
        private System.Windows.Forms.Label lblSearch;
        private System.Windows.Forms.TextBox txtSearch;
        private Syncfusion.WinForms.Controls.SfButton btnRefresh;
        private Syncfusion.WinForms.Controls.SfButton btnExportCsv;
        private System.Windows.Forms.TableLayoutPanel tlpMain;
        private System.Windows.Forms.TableLayoutPanel tlpLeft;
        private System.Windows.Forms.GroupBox gbUsersOverview;
        private System.Windows.Forms.DataGridView dgvUsers;
        private System.Windows.Forms.DataGridViewTextBoxColumn colUserName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAttempts;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAccuracy;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAvgTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn colWeakestTopic;
        private System.Windows.Forms.DataGridViewTextBoxColumn colLastActive;
        private System.Windows.Forms.GroupBox gbTopMisconceptions;
        private System.Windows.Forms.DataGridView dgvMisconceptions;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMisTag;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMisCount;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMisLastSeen;
        private System.Windows.Forms.GroupBox gbRecentActivity;
        private System.Windows.Forms.DataGridView dgvRecentActivity;
        private System.Windows.Forms.DataGridViewTextBoxColumn colActivityUser;
        private System.Windows.Forms.DataGridViewTextBoxColumn colActivityMode;
        private System.Windows.Forms.DataGridViewTextBoxColumn colActivityResult;
        private System.Windows.Forms.DataGridViewTextBoxColumn colActivityWhen;
        private System.Windows.Forms.GroupBox gbContentBank;
        private System.Windows.Forms.TableLayoutPanel tlpContentBank;
        private System.Windows.Forms.TableLayoutPanel tlpBankToolbar;
        private System.Windows.Forms.Label lblBankTopic;
        private System.Windows.Forms.ComboBox cmbBankTopic;
        private System.Windows.Forms.Label lblBankDifficulty;
        private System.Windows.Forms.ComboBox cmbBankDifficulty;
        private Syncfusion.WinForms.Controls.SfButton btnNewItem;
        private Syncfusion.WinForms.Controls.SfButton btnDuplicateItem;
        private Syncfusion.WinForms.Controls.SfButton btnDeleteItem;
        private System.Windows.Forms.SplitContainer splitBank;
        private System.Windows.Forms.DataGridView dgvBankItems;
        private System.Windows.Forms.DataGridViewTextBoxColumn colBankKey;
        private System.Windows.Forms.DataGridViewTextBoxColumn colBankTitle;
        private System.Windows.Forms.DataGridViewTextBoxColumn colBankType;
        private System.Windows.Forms.TabControl tabEditor;
        private System.Windows.Forms.TabPage tabQuizQuestion;
        private System.Windows.Forms.TabPage tabPhishingEmail;
        private System.Windows.Forms.TabPage tabAuthScenario;
        private System.Windows.Forms.TableLayoutPanel tlpQuizEditor;
        private System.Windows.Forms.Panel pnlQuizEditorLeft;
        private System.Windows.Forms.Label lblQuizQuestionText;
        private System.Windows.Forms.RichTextBox rtbQuizQuestionText;
        private System.Windows.Forms.Label lblQuizOptions;
        private System.Windows.Forms.DataGridView dgvQuizOptions;
        private System.Windows.Forms.Panel pnlQuizEditorRight;
        private System.Windows.Forms.Label lblQuizTopic;
        private System.Windows.Forms.ComboBox cmbQuizTopic;
        private System.Windows.Forms.Label lblQuizDifficulty;
        private System.Windows.Forms.ComboBox cmbQuizDifficulty;
        private System.Windows.Forms.ComboBox cmbQuizType;
        private System.Windows.Forms.Label lblQuizType;
        private System.Windows.Forms.Label lblMisTags;
        private System.Windows.Forms.TextBox txtMisTags;
        private System.Windows.Forms.TableLayoutPanel tlpPhishEditor;
        private System.Windows.Forms.Panel pnlPhishLeft;
        private System.Windows.Forms.Label lblPhishBody;
        private System.Windows.Forms.RichTextBox rtbPhishBody;
        private System.Windows.Forms.RichTextBox rtbPhishExplanation;
        private System.Windows.Forms.Label lblPhishExplanation;
        private System.Windows.Forms.Panel pnlPhishRight;
        private System.Windows.Forms.Label lblSenderName;
        private System.Windows.Forms.TextBox txtSenderEmail;
        private System.Windows.Forms.Label lblSenderEmail;
        private System.Windows.Forms.TextBox txtSenderName;
        private System.Windows.Forms.TextBox txtReplyTo;
        private System.Windows.Forms.Label lblReplyTo;
        private System.Windows.Forms.TextBox txtPhishSubject;
        private System.Windows.Forms.Label lblSubject;
        private System.Windows.Forms.TextBox txtToEmail;
        private System.Windows.Forms.Label lblToEmail;
        private System.Windows.Forms.Label lblPhishDifficulty;
        private System.Windows.Forms.ComboBox cmbPhishDifficulty;
        private System.Windows.Forms.CheckBox chkHasLink;
        private System.Windows.Forms.CheckBox chkIsPhishing;
        private System.Windows.Forms.CheckBox chkHasAttachment;
        private System.Windows.Forms.TextBox txtAttachmentName;
        private System.Windows.Forms.TextBox txtLinkUrl;
        private System.Windows.Forms.TableLayoutPanel tlpAuthEditor;
        private System.Windows.Forms.Panel pnlAuthLeft;
        private System.Windows.Forms.Label lblScenarioTitle;
        private System.Windows.Forms.TextBox txtScenarioTitle;
        private System.Windows.Forms.Label lblScenarioBody;
        private System.Windows.Forms.RichTextBox rtbScenarioBody;
        private System.Windows.Forms.Label lblScenarioHints;
        private System.Windows.Forms.RichTextBox rtbScenarioHints;
        private System.Windows.Forms.Label lblScenarioTags;
        private System.Windows.Forms.TextBox txtScenarioTags;
        private System.Windows.Forms.Panel pnlAuthRight;
        private System.Windows.Forms.ComboBox cmbRecSession;
        private System.Windows.Forms.Label lblRecSession;
        private System.Windows.Forms.Label lblRecRecovery;
        private System.Windows.Forms.Label lblRecAuthMethod;
        private System.Windows.Forms.Label lblAuthDifficulty;
        private System.Windows.Forms.Label lblGoalType;
        private System.Windows.Forms.Label lblThreatType;
        private System.Windows.Forms.ComboBox cmbRecRecovery;
        private System.Windows.Forms.ComboBox cmbRecAuthMethod;
        private System.Windows.Forms.ComboBox cmbAuthDifficulty;
        private System.Windows.Forms.ComboBox cmbGoalType;
        private System.Windows.Forms.ComboBox cmbThreatType;
        private System.Windows.Forms.GroupBox gbAuthRequirements;
        private System.Windows.Forms.CheckBox chkReqMfa;
        private System.Windows.Forms.CheckBox chkReqPhishResistant;
        private System.Windows.Forms.CheckBox chkReqLegacyBlock;
        private System.Windows.Forms.CheckBox chkReqStepUp;
        private System.Windows.Forms.TableLayoutPanel tlpBankActions;
        private Syncfusion.WinForms.Controls.SfButton btnRevertChanges;
        private Syncfusion.WinForms.Controls.SfButton btnSaveAll;
        private Syncfusion.WinForms.Controls.SfButton btnSaveItem;
        private Syncfusion.WinForms.Controls.SfButton btnLoadSelected;
        private System.Windows.Forms.Panel pnlFooter;
        private System.Windows.Forms.Label lblFooterUser;
        private System.Windows.Forms.Label lblFooterLeft;
        private System.Windows.Forms.DataGridViewTextBoxColumn colOptionText;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colOptionCorrect;
        private System.Windows.Forms.RichTextBox rtbQuizExplanation;
        private System.Windows.Forms.Label lblQuizExplanation;
        private System.Windows.Forms.Label lblLinkDisplayText;
        private System.Windows.Forms.TextBox txtLinkDisplayText;
        private System.Windows.Forms.Label lblPhishTags;
        private System.Windows.Forms.TextBox txtPhishTags;
        private System.Windows.Forms.CheckBox chkReqDeviceBinding;
        private System.Windows.Forms.CheckBox chkReqAlertOnSuspicious;
    }
}