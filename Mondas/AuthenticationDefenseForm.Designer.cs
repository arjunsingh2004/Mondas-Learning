namespace Mondas
{
    partial class AuthenticationDefenseForm
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
            this.components = new System.ComponentModel.Container();
            this.tlpAuthRoot = new System.Windows.Forms.TableLayoutPanel();
            this.pnlAuthHeader = new System.Windows.Forms.Panel();
            this.tlpAuthHeader = new System.Windows.Forms.TableLayoutPanel();
            this.pnlHeaderLeft = new System.Windows.Forms.Panel();
            this.lblAuthSubtitle = new System.Windows.Forms.Label();
            this.lblAuthTitle = new System.Windows.Forms.Label();
            this.lblRunInfo = new System.Windows.Forms.Label();
            this.pnlHeaderRight = new System.Windows.Forms.Panel();
            this.btnLogout = new System.Windows.Forms.Button();
            this.lblUser = new System.Windows.Forms.Label();
            this.tlpAuthMain = new System.Windows.Forms.TableLayoutPanel();
            this.gbScenarioQueue = new System.Windows.Forms.GroupBox();
            this.tlpQueueHost = new System.Windows.Forms.TableLayoutPanel();
            this.lvQueue = new System.Windows.Forms.ListView();
            this.colQueueStatus = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colQueueScenario = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colQueueRisk = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colQueueTime = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.pnlQueueFooter = new System.Windows.Forms.Panel();
            this.tlpQueueFooter = new System.Windows.Forms.TableLayoutPanel();
            this.btnNewScenario = new Syncfusion.WinForms.Controls.SfButton();
            this.btnFinishRun = new Syncfusion.WinForms.Controls.SfButton();
            this.btnResetRun = new Syncfusion.WinForms.Controls.SfButton();
            this.tlpWorkArea = new System.Windows.Forms.TableLayoutPanel();
            this.gbScenario = new System.Windows.Forms.GroupBox();
            this.tlpScenario = new System.Windows.Forms.TableLayoutPanel();
            this.tlpScenarioMeta = new System.Windows.Forms.TableLayoutPanel();
            this.lblDifficulty = new System.Windows.Forms.Label();
            this.lblCapDifficulty = new System.Windows.Forms.Label();
            this.lblGoal = new System.Windows.Forms.Label();
            this.lblCapGoal = new System.Windows.Forms.Label();
            this.lblThreatType = new System.Windows.Forms.Label();
            this.lblCapThreat = new System.Windows.Forms.Label();
            this.lblScenarioName = new System.Windows.Forms.Label();
            this.lblCapScenario = new System.Windows.Forms.Label();
            this.btnViewHints = new Syncfusion.WinForms.Controls.SfButton();
            this.pnlScenarioBody = new System.Windows.Forms.Panel();
            this.rtbScenarioBody = new System.Windows.Forms.RichTextBox();
            this.gbDefenseBuilder = new System.Windows.Forms.GroupBox();
            this.tlpDefenseBuilder = new System.Windows.Forms.TableLayoutPanel();
            this.cmbSession = new System.Windows.Forms.ComboBox();
            this.lblCapSession = new System.Windows.Forms.Label();
            this.cmbRateLimit = new System.Windows.Forms.ComboBox();
            this.lblCapRateLimit = new System.Windows.Forms.Label();
            this.cmbMonitoring = new System.Windows.Forms.ComboBox();
            this.lblCapMonitoring = new System.Windows.Forms.Label();
            this.cmbRecovery = new System.Windows.Forms.ComboBox();
            this.lblCapRecovery = new System.Windows.Forms.Label();
            this.lblActionPrompt = new System.Windows.Forms.Label();
            this.lblCapAuthMethod = new System.Windows.Forms.Label();
            this.cmbAuthMethod = new System.Windows.Forms.ComboBox();
            this.lblCapPasswordPolicy = new System.Windows.Forms.Label();
            this.cmbPasswordPolicy = new System.Windows.Forms.ComboBox();
            this.flpDefenseToggles = new System.Windows.Forms.FlowLayoutPanel();
            this.chkRequireMfa = new System.Windows.Forms.CheckBox();
            this.chkPhishingResistant = new System.Windows.Forms.CheckBox();
            this.chkDeviceBinding = new System.Windows.Forms.CheckBox();
            this.chkRiskBasedStepUp = new System.Windows.Forms.CheckBox();
            this.chkBlockLegacyAuth = new System.Windows.Forms.CheckBox();
            this.chkAlertOnSuspicious = new System.Windows.Forms.CheckBox();
            this.tlpDefenseButtons = new System.Windows.Forms.TableLayoutPanel();
            this.btnClearBuild = new Syncfusion.WinForms.Controls.SfButton();
            this.btnRunSimulation = new Syncfusion.WinForms.Controls.SfButton();
            this.gbResult = new System.Windows.Forms.GroupBox();
            this.tlpResult = new System.Windows.Forms.TableLayoutPanel();
            this.pnlResultTop = new System.Windows.Forms.Panel();
            this.lblResultWhy = new System.Windows.Forms.Label();
            this.lblResultScoreDelta = new System.Windows.Forms.Label();
            this.lblResultsText = new System.Windows.Forms.Label();
            this.lvFindings = new System.Windows.Forms.ListView();
            this.colFinding = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colDetail = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colImpact = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.pnlResultBottom = new System.Windows.Forms.Panel();
            this.btnNextScenario = new Syncfusion.WinForms.Controls.SfButton();
            this.tmrRun = new System.Windows.Forms.Timer(this.components);
            this.tlpAuthRoot.SuspendLayout();
            this.pnlAuthHeader.SuspendLayout();
            this.tlpAuthHeader.SuspendLayout();
            this.pnlHeaderLeft.SuspendLayout();
            this.pnlHeaderRight.SuspendLayout();
            this.tlpAuthMain.SuspendLayout();
            this.gbScenarioQueue.SuspendLayout();
            this.tlpQueueHost.SuspendLayout();
            this.pnlQueueFooter.SuspendLayout();
            this.tlpQueueFooter.SuspendLayout();
            this.tlpWorkArea.SuspendLayout();
            this.gbScenario.SuspendLayout();
            this.tlpScenario.SuspendLayout();
            this.tlpScenarioMeta.SuspendLayout();
            this.pnlScenarioBody.SuspendLayout();
            this.gbDefenseBuilder.SuspendLayout();
            this.tlpDefenseBuilder.SuspendLayout();
            this.flpDefenseToggles.SuspendLayout();
            this.tlpDefenseButtons.SuspendLayout();
            this.gbResult.SuspendLayout();
            this.tlpResult.SuspendLayout();
            this.pnlResultTop.SuspendLayout();
            this.pnlResultBottom.SuspendLayout();
            this.SuspendLayout();
            // 
            // tlpAuthRoot
            // 
            this.tlpAuthRoot.ColumnCount = 1;
            this.tlpAuthRoot.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpAuthRoot.Controls.Add(this.pnlAuthHeader, 0, 0);
            this.tlpAuthRoot.Controls.Add(this.tlpAuthMain, 0, 1);
            this.tlpAuthRoot.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpAuthRoot.Location = new System.Drawing.Point(2, 2);
            this.tlpAuthRoot.Margin = new System.Windows.Forms.Padding(0);
            this.tlpAuthRoot.Name = "tlpAuthRoot";
            this.tlpAuthRoot.Padding = new System.Windows.Forms.Padding(12);
            this.tlpAuthRoot.RowCount = 2;
            this.tlpAuthRoot.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 92F));
            this.tlpAuthRoot.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpAuthRoot.Size = new System.Drawing.Size(1926, 728);
            this.tlpAuthRoot.TabIndex = 0;
            // 
            // pnlAuthHeader
            // 
            this.pnlAuthHeader.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlAuthHeader.Controls.Add(this.tlpAuthHeader);
            this.pnlAuthHeader.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlAuthHeader.Location = new System.Drawing.Point(12, 12);
            this.pnlAuthHeader.Margin = new System.Windows.Forms.Padding(0, 0, 0, 10);
            this.pnlAuthHeader.Name = "pnlAuthHeader";
            this.pnlAuthHeader.Size = new System.Drawing.Size(1902, 82);
            this.pnlAuthHeader.TabIndex = 0;
            // 
            // tlpAuthHeader
            // 
            this.tlpAuthHeader.ColumnCount = 3;
            this.tlpAuthHeader.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 38F));
            this.tlpAuthHeader.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 37F));
            this.tlpAuthHeader.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpAuthHeader.Controls.Add(this.pnlHeaderLeft, 0, 0);
            this.tlpAuthHeader.Controls.Add(this.lblRunInfo, 1, 0);
            this.tlpAuthHeader.Controls.Add(this.pnlHeaderRight, 2, 0);
            this.tlpAuthHeader.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpAuthHeader.Location = new System.Drawing.Point(0, 0);
            this.tlpAuthHeader.Margin = new System.Windows.Forms.Padding(0);
            this.tlpAuthHeader.Name = "tlpAuthHeader";
            this.tlpAuthHeader.Padding = new System.Windows.Forms.Padding(10, 6, 10, 6);
            this.tlpAuthHeader.RowCount = 1;
            this.tlpAuthHeader.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpAuthHeader.Size = new System.Drawing.Size(1900, 80);
            this.tlpAuthHeader.TabIndex = 0;
            // 
            // pnlHeaderLeft
            // 
            this.pnlHeaderLeft.Controls.Add(this.lblAuthSubtitle);
            this.pnlHeaderLeft.Controls.Add(this.lblAuthTitle);
            this.pnlHeaderLeft.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlHeaderLeft.Location = new System.Drawing.Point(10, 6);
            this.pnlHeaderLeft.Margin = new System.Windows.Forms.Padding(0);
            this.pnlHeaderLeft.Name = "pnlHeaderLeft";
            this.pnlHeaderLeft.Size = new System.Drawing.Size(714, 68);
            this.pnlHeaderLeft.TabIndex = 0;
            // 
            // lblAuthSubtitle
            // 
            this.lblAuthSubtitle.AutoSize = true;
            this.lblAuthSubtitle.Font = new System.Drawing.Font("Agency", 10F);
            this.lblAuthSubtitle.Location = new System.Drawing.Point(8, 45);
            this.lblAuthSubtitle.Name = "lblAuthSubtitle";
            this.lblAuthSubtitle.Size = new System.Drawing.Size(460, 15);
            this.lblAuthSubtitle.TabIndex = 3;
            this.lblAuthSubtitle.Text = "BUILD THE CORRECT DEFENCE FOR EACH ATTACK";
            // 
            // lblAuthTitle
            // 
            this.lblAuthTitle.AutoSize = true;
            this.lblAuthTitle.Font = new System.Drawing.Font("Muro", 24F);
            this.lblAuthTitle.Location = new System.Drawing.Point(3, -10);
            this.lblAuthTitle.Name = "lblAuthTitle";
            this.lblAuthTitle.Size = new System.Drawing.Size(495, 48);
            this.lblAuthTitle.TabIndex = 2;
            this.lblAuthTitle.Text = "AUTHENTICATION DEFENCE";
            // 
            // lblRunInfo
            // 
            this.lblRunInfo.AutoSize = true;
            this.lblRunInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblRunInfo.Font = new System.Drawing.Font("Muro", 16F);
            this.lblRunInfo.Location = new System.Drawing.Point(727, 6);
            this.lblRunInfo.Name = "lblRunInfo";
            this.lblRunInfo.Size = new System.Drawing.Size(689, 68);
            this.lblRunInfo.TabIndex = 7;
            this.lblRunInfo.Text = "SCORE: 0 | STREAK | 0 | TIME: 00.00";
            this.lblRunInfo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlHeaderRight
            // 
            this.pnlHeaderRight.Controls.Add(this.btnLogout);
            this.pnlHeaderRight.Controls.Add(this.lblUser);
            this.pnlHeaderRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlHeaderRight.Location = new System.Drawing.Point(1419, 6);
            this.pnlHeaderRight.Margin = new System.Windows.Forms.Padding(0);
            this.pnlHeaderRight.Name = "pnlHeaderRight";
            this.pnlHeaderRight.Size = new System.Drawing.Size(471, 68);
            this.pnlHeaderRight.TabIndex = 8;
            // 
            // btnLogout
            // 
            this.btnLogout.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnLogout.AutoSize = true;
            this.btnLogout.BackColor = System.Drawing.Color.White;
            this.btnLogout.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.btnLogout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogout.Font = new System.Drawing.Font("Agency", 14F);
            this.btnLogout.Location = new System.Drawing.Point(313, 22);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(136, 33);
            this.btnLogout.TabIndex = 7;
            this.btnLogout.Text = "LOG OUT";
            this.btnLogout.UseVisualStyleBackColor = false;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // lblUser
            // 
            this.lblUser.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblUser.AutoSize = true;
            this.lblUser.Font = new System.Drawing.Font("Agency", 16F);
            this.lblUser.Location = new System.Drawing.Point(25, 27);
            this.lblUser.Name = "lblUser";
            this.lblUser.Size = new System.Drawing.Size(206, 24);
            this.lblUser.TabIndex = 6;
            this.lblUser.Text = "ARJUN SINGH";
            this.lblUser.Click += new System.EventHandler(this.lblUser_Click);
            // 
            // tlpAuthMain
            // 
            this.tlpAuthMain.ColumnCount = 2;
            this.tlpAuthMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 36F));
            this.tlpAuthMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 64F));
            this.tlpAuthMain.Controls.Add(this.gbScenarioQueue, 0, 0);
            this.tlpAuthMain.Controls.Add(this.tlpWorkArea, 1, 0);
            this.tlpAuthMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpAuthMain.Location = new System.Drawing.Point(12, 104);
            this.tlpAuthMain.Margin = new System.Windows.Forms.Padding(0);
            this.tlpAuthMain.Name = "tlpAuthMain";
            this.tlpAuthMain.RowCount = 1;
            this.tlpAuthMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpAuthMain.Size = new System.Drawing.Size(1902, 612);
            this.tlpAuthMain.TabIndex = 1;
            // 
            // gbScenarioQueue
            // 
            this.gbScenarioQueue.Controls.Add(this.tlpQueueHost);
            this.gbScenarioQueue.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbScenarioQueue.Font = new System.Drawing.Font("Muro", 15F);
            this.gbScenarioQueue.Location = new System.Drawing.Point(0, 0);
            this.gbScenarioQueue.Margin = new System.Windows.Forms.Padding(0, 0, 10, 0);
            this.gbScenarioQueue.Name = "gbScenarioQueue";
            this.gbScenarioQueue.Size = new System.Drawing.Size(674, 612);
            this.gbScenarioQueue.TabIndex = 0;
            this.gbScenarioQueue.TabStop = false;
            this.gbScenarioQueue.Text = "SCENARIO QUEUE";
            // 
            // tlpQueueHost
            // 
            this.tlpQueueHost.ColumnCount = 1;
            this.tlpQueueHost.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpQueueHost.Controls.Add(this.lvQueue, 0, 0);
            this.tlpQueueHost.Controls.Add(this.pnlQueueFooter, 0, 1);
            this.tlpQueueHost.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpQueueHost.Location = new System.Drawing.Point(3, 33);
            this.tlpQueueHost.Margin = new System.Windows.Forms.Padding(0);
            this.tlpQueueHost.Name = "tlpQueueHost";
            this.tlpQueueHost.Padding = new System.Windows.Forms.Padding(6);
            this.tlpQueueHost.RowCount = 2;
            this.tlpQueueHost.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpQueueHost.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 48F));
            this.tlpQueueHost.Size = new System.Drawing.Size(668, 576);
            this.tlpQueueHost.TabIndex = 0;
            // 
            // lvQueue
            // 
            this.lvQueue.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colQueueStatus,
            this.colQueueScenario,
            this.colQueueRisk,
            this.colQueueTime});
            this.lvQueue.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvQueue.Font = new System.Drawing.Font("Agency", 13F);
            this.lvQueue.FullRowSelect = true;
            this.lvQueue.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lvQueue.HideSelection = false;
            this.lvQueue.Location = new System.Drawing.Point(9, 9);
            this.lvQueue.MultiSelect = false;
            this.lvQueue.Name = "lvQueue";
            this.lvQueue.Size = new System.Drawing.Size(650, 510);
            this.lvQueue.TabIndex = 0;
            this.lvQueue.UseCompatibleStateImageBehavior = false;
            this.lvQueue.View = System.Windows.Forms.View.Details;
            this.lvQueue.SelectedIndexChanged += new System.EventHandler(this.lvQueue_SelectedIndexChanged);
            // 
            // colQueueStatus
            // 
            this.colQueueStatus.Text = "STATUS";
            this.colQueueStatus.Width = 110;
            // 
            // colQueueScenario
            // 
            this.colQueueScenario.Text = "SCENARIO";
            this.colQueueScenario.Width = 280;
            // 
            // colQueueRisk
            // 
            this.colQueueRisk.Text = "DIFFICULTY";
            this.colQueueRisk.Width = 150;
            // 
            // colQueueTime
            // 
            this.colQueueTime.Text = "TIME";
            this.colQueueTime.Width = 100;
            // 
            // pnlQueueFooter
            // 
            this.pnlQueueFooter.Controls.Add(this.tlpQueueFooter);
            this.pnlQueueFooter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlQueueFooter.Location = new System.Drawing.Point(6, 522);
            this.pnlQueueFooter.Margin = new System.Windows.Forms.Padding(0);
            this.pnlQueueFooter.Name = "pnlQueueFooter";
            this.pnlQueueFooter.Size = new System.Drawing.Size(656, 48);
            this.pnlQueueFooter.TabIndex = 1;
            // 
            // tlpQueueFooter
            // 
            this.tlpQueueFooter.ColumnCount = 3;
            this.tlpQueueFooter.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 34F));
            this.tlpQueueFooter.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33F));
            this.tlpQueueFooter.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33F));
            this.tlpQueueFooter.Controls.Add(this.btnNewScenario, 0, 0);
            this.tlpQueueFooter.Controls.Add(this.btnFinishRun, 1, 0);
            this.tlpQueueFooter.Controls.Add(this.btnResetRun, 2, 0);
            this.tlpQueueFooter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpQueueFooter.Location = new System.Drawing.Point(0, 0);
            this.tlpQueueFooter.Margin = new System.Windows.Forms.Padding(0);
            this.tlpQueueFooter.Name = "tlpQueueFooter";
            this.tlpQueueFooter.RowCount = 1;
            this.tlpQueueFooter.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpQueueFooter.Size = new System.Drawing.Size(656, 48);
            this.tlpQueueFooter.TabIndex = 0;
            // 
            // btnNewScenario
            // 
            this.btnNewScenario.BackColor = System.Drawing.Color.SeaGreen;
            this.btnNewScenario.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnNewScenario.Font = new System.Drawing.Font("Muro", 14F);
            this.btnNewScenario.ForeColor = System.Drawing.Color.White;
            this.btnNewScenario.Location = new System.Drawing.Point(0, 0);
            this.btnNewScenario.Margin = new System.Windows.Forms.Padding(0, 0, 6, 0);
            this.btnNewScenario.Name = "btnNewScenario";
            this.btnNewScenario.Size = new System.Drawing.Size(217, 48);
            this.btnNewScenario.Style.BackColor = System.Drawing.Color.SeaGreen;
            this.btnNewScenario.Style.ForeColor = System.Drawing.Color.White;
            this.btnNewScenario.TabIndex = 0;
            this.btnNewScenario.Text = "NEW SCENARIO";
            this.btnNewScenario.UseVisualStyleBackColor = false;
            this.btnNewScenario.Click += new System.EventHandler(this.btnNewScenario_Click);
            // 
            // btnFinishRun
            // 
            this.btnFinishRun.BackColor = System.Drawing.Color.RoyalBlue;
            this.btnFinishRun.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnFinishRun.Font = new System.Drawing.Font("Muro", 14F);
            this.btnFinishRun.ForeColor = System.Drawing.Color.White;
            this.btnFinishRun.Location = new System.Drawing.Point(223, 0);
            this.btnFinishRun.Margin = new System.Windows.Forms.Padding(0, 0, 6, 0);
            this.btnFinishRun.Name = "btnFinishRun";
            this.btnFinishRun.Size = new System.Drawing.Size(210, 48);
            this.btnFinishRun.Style.BackColor = System.Drawing.Color.RoyalBlue;
            this.btnFinishRun.Style.ForeColor = System.Drawing.Color.White;
            this.btnFinishRun.TabIndex = 1;
            this.btnFinishRun.Text = "FINISH RUN";
            this.btnFinishRun.UseVisualStyleBackColor = false;
            this.btnFinishRun.Click += new System.EventHandler(this.btnFinishRun_Click);
            // 
            // btnResetRun
            // 
            this.btnResetRun.BackColor = System.Drawing.Color.Crimson;
            this.btnResetRun.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnResetRun.Font = new System.Drawing.Font("Muro", 14F);
            this.btnResetRun.ForeColor = System.Drawing.Color.White;
            this.btnResetRun.Location = new System.Drawing.Point(439, 0);
            this.btnResetRun.Margin = new System.Windows.Forms.Padding(0);
            this.btnResetRun.Name = "btnResetRun";
            this.btnResetRun.Size = new System.Drawing.Size(217, 48);
            this.btnResetRun.Style.BackColor = System.Drawing.Color.Crimson;
            this.btnResetRun.Style.ForeColor = System.Drawing.Color.White;
            this.btnResetRun.TabIndex = 2;
            this.btnResetRun.Text = "RESET RUN";
            this.btnResetRun.UseVisualStyleBackColor = false;
            this.btnResetRun.Click += new System.EventHandler(this.btnResetRun_Click);
            // 
            // tlpWorkArea
            // 
            this.tlpWorkArea.ColumnCount = 1;
            this.tlpWorkArea.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpWorkArea.Controls.Add(this.gbScenario, 0, 0);
            this.tlpWorkArea.Controls.Add(this.gbDefenseBuilder, 0, 1);
            this.tlpWorkArea.Controls.Add(this.gbResult, 0, 2);
            this.tlpWorkArea.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpWorkArea.Location = new System.Drawing.Point(694, 0);
            this.tlpWorkArea.Margin = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.tlpWorkArea.Name = "tlpWorkArea";
            this.tlpWorkArea.RowCount = 3;
            this.tlpWorkArea.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 35F));
            this.tlpWorkArea.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tlpWorkArea.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpWorkArea.Size = new System.Drawing.Size(1208, 612);
            this.tlpWorkArea.TabIndex = 1;
            // 
            // gbScenario
            // 
            this.gbScenario.Controls.Add(this.tlpScenario);
            this.gbScenario.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbScenario.Font = new System.Drawing.Font("Muro", 15F);
            this.gbScenario.Location = new System.Drawing.Point(0, 0);
            this.gbScenario.Margin = new System.Windows.Forms.Padding(0, 0, 0, 10);
            this.gbScenario.Name = "gbScenario";
            this.gbScenario.Size = new System.Drawing.Size(1208, 204);
            this.gbScenario.TabIndex = 0;
            this.gbScenario.TabStop = false;
            this.gbScenario.Text = "ATTACK SCENARIO";
            // 
            // tlpScenario
            // 
            this.tlpScenario.ColumnCount = 1;
            this.tlpScenario.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpScenario.Controls.Add(this.tlpScenarioMeta, 0, 0);
            this.tlpScenario.Controls.Add(this.pnlScenarioBody, 0, 1);
            this.tlpScenario.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpScenario.Location = new System.Drawing.Point(3, 33);
            this.tlpScenario.Margin = new System.Windows.Forms.Padding(0);
            this.tlpScenario.Name = "tlpScenario";
            this.tlpScenario.Padding = new System.Windows.Forms.Padding(6, 6, 6, 2);
            this.tlpScenario.RowCount = 2;
            this.tlpScenario.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tlpScenario.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpScenario.Size = new System.Drawing.Size(1202, 168);
            this.tlpScenario.TabIndex = 0;
            // 
            // tlpScenarioMeta
            // 
            this.tlpScenarioMeta.ColumnCount = 5;
            this.tlpScenarioMeta.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 167F));
            this.tlpScenarioMeta.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpScenarioMeta.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 177F));
            this.tlpScenarioMeta.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpScenarioMeta.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 180F));
            this.tlpScenarioMeta.Controls.Add(this.lblDifficulty, 3, 1);
            this.tlpScenarioMeta.Controls.Add(this.lblCapDifficulty, 2, 1);
            this.tlpScenarioMeta.Controls.Add(this.lblGoal, 1, 1);
            this.tlpScenarioMeta.Controls.Add(this.lblCapGoal, 0, 1);
            this.tlpScenarioMeta.Controls.Add(this.lblThreatType, 3, 0);
            this.tlpScenarioMeta.Controls.Add(this.lblCapThreat, 2, 0);
            this.tlpScenarioMeta.Controls.Add(this.lblScenarioName, 1, 0);
            this.tlpScenarioMeta.Controls.Add(this.lblCapScenario, 0, 0);
            this.tlpScenarioMeta.Controls.Add(this.btnViewHints, 4, 1);
            this.tlpScenarioMeta.Font = new System.Drawing.Font("Muro", 10F);
            this.tlpScenarioMeta.Location = new System.Drawing.Point(6, 6);
            this.tlpScenarioMeta.Margin = new System.Windows.Forms.Padding(0);
            this.tlpScenarioMeta.Name = "tlpScenarioMeta";
            this.tlpScenarioMeta.RowCount = 2;
            this.tlpScenarioMeta.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpScenarioMeta.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpScenarioMeta.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpScenarioMeta.Size = new System.Drawing.Size(1188, 50);
            this.tlpScenarioMeta.TabIndex = 0;
            // 
            // lblDifficulty
            // 
            this.lblDifficulty.AutoSize = true;
            this.lblDifficulty.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblDifficulty.Font = new System.Drawing.Font("Agency", 13F);
            this.lblDifficulty.Location = new System.Drawing.Point(679, 25);
            this.lblDifficulty.Name = "lblDifficulty";
            this.lblDifficulty.Size = new System.Drawing.Size(326, 25);
            this.lblDifficulty.TabIndex = 8;
            this.lblDifficulty.Text = "-";
            this.lblDifficulty.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblCapDifficulty
            // 
            this.lblCapDifficulty.AutoSize = true;
            this.lblCapDifficulty.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblCapDifficulty.Font = new System.Drawing.Font("Agency", 13F);
            this.lblCapDifficulty.Location = new System.Drawing.Point(502, 25);
            this.lblCapDifficulty.Name = "lblCapDifficulty";
            this.lblCapDifficulty.Size = new System.Drawing.Size(171, 25);
            this.lblCapDifficulty.TabIndex = 7;
            this.lblCapDifficulty.Text = "DIFFICULTY:";
            this.lblCapDifficulty.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblGoal
            // 
            this.lblGoal.AutoSize = true;
            this.lblGoal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblGoal.Font = new System.Drawing.Font("Agency", 13F);
            this.lblGoal.Location = new System.Drawing.Point(170, 25);
            this.lblGoal.Name = "lblGoal";
            this.lblGoal.Size = new System.Drawing.Size(326, 25);
            this.lblGoal.TabIndex = 6;
            this.lblGoal.Text = "-";
            this.lblGoal.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblCapGoal
            // 
            this.lblCapGoal.AutoSize = true;
            this.lblCapGoal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblCapGoal.Font = new System.Drawing.Font("Agency", 13F);
            this.lblCapGoal.Location = new System.Drawing.Point(3, 25);
            this.lblCapGoal.Name = "lblCapGoal";
            this.lblCapGoal.Size = new System.Drawing.Size(161, 25);
            this.lblCapGoal.TabIndex = 5;
            this.lblCapGoal.Text = "GOAL:";
            this.lblCapGoal.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblThreatType
            // 
            this.lblThreatType.AutoSize = true;
            this.lblThreatType.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblThreatType.Font = new System.Drawing.Font("Agency", 13F);
            this.lblThreatType.Location = new System.Drawing.Point(679, 0);
            this.lblThreatType.Name = "lblThreatType";
            this.lblThreatType.Size = new System.Drawing.Size(326, 25);
            this.lblThreatType.TabIndex = 3;
            this.lblThreatType.Text = "-";
            this.lblThreatType.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblCapThreat
            // 
            this.lblCapThreat.AutoSize = true;
            this.lblCapThreat.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblCapThreat.Font = new System.Drawing.Font("Agency", 13F);
            this.lblCapThreat.Location = new System.Drawing.Point(502, 0);
            this.lblCapThreat.Name = "lblCapThreat";
            this.lblCapThreat.Size = new System.Drawing.Size(171, 25);
            this.lblCapThreat.TabIndex = 2;
            this.lblCapThreat.Text = "THREAT:";
            this.lblCapThreat.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblScenarioName
            // 
            this.lblScenarioName.AutoSize = true;
            this.lblScenarioName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblScenarioName.Font = new System.Drawing.Font("Agency", 13F);
            this.lblScenarioName.Location = new System.Drawing.Point(170, 0);
            this.lblScenarioName.Name = "lblScenarioName";
            this.lblScenarioName.Size = new System.Drawing.Size(326, 25);
            this.lblScenarioName.TabIndex = 1;
            this.lblScenarioName.Text = "-";
            this.lblScenarioName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblCapScenario
            // 
            this.lblCapScenario.AutoSize = true;
            this.lblCapScenario.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblCapScenario.Font = new System.Drawing.Font("Agency", 13F);
            this.lblCapScenario.Location = new System.Drawing.Point(3, 0);
            this.lblCapScenario.Name = "lblCapScenario";
            this.lblCapScenario.Size = new System.Drawing.Size(161, 25);
            this.lblCapScenario.TabIndex = 0;
            this.lblCapScenario.Text = "SCENARIO:";
            this.lblCapScenario.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnViewHints
            // 
            this.btnViewHints.BackColor = System.Drawing.Color.RoyalBlue;
            this.btnViewHints.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnViewHints.Font = new System.Drawing.Font("Muro", 13F);
            this.btnViewHints.ForeColor = System.Drawing.Color.White;
            this.btnViewHints.Location = new System.Drawing.Point(1023, 25);
            this.btnViewHints.Margin = new System.Windows.Forms.Padding(0);
            this.btnViewHints.Name = "btnViewHints";
            this.btnViewHints.Size = new System.Drawing.Size(165, 25);
            this.btnViewHints.Style.BackColor = System.Drawing.Color.RoyalBlue;
            this.btnViewHints.Style.ForeColor = System.Drawing.Color.White;
            this.btnViewHints.TabIndex = 9;
            this.btnViewHints.Text = "VIEW HINTS";
            this.btnViewHints.UseVisualStyleBackColor = false;
            this.btnViewHints.Click += new System.EventHandler(this.btnViewHints_Click);
            // 
            // pnlScenarioBody
            // 
            this.pnlScenarioBody.Controls.Add(this.rtbScenarioBody);
            this.pnlScenarioBody.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlScenarioBody.Location = new System.Drawing.Point(6, 56);
            this.pnlScenarioBody.Margin = new System.Windows.Forms.Padding(0);
            this.pnlScenarioBody.Name = "pnlScenarioBody";
            this.pnlScenarioBody.Size = new System.Drawing.Size(1190, 110);
            this.pnlScenarioBody.TabIndex = 1;
            // 
            // rtbScenarioBody
            // 
            this.rtbScenarioBody.BackColor = System.Drawing.Color.White;
            this.rtbScenarioBody.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.rtbScenarioBody.DetectUrls = false;
            this.rtbScenarioBody.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtbScenarioBody.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtbScenarioBody.HideSelection = false;
            this.rtbScenarioBody.Location = new System.Drawing.Point(0, 0);
            this.rtbScenarioBody.Name = "rtbScenarioBody";
            this.rtbScenarioBody.ReadOnly = true;
            this.rtbScenarioBody.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.rtbScenarioBody.Size = new System.Drawing.Size(1190, 110);
            this.rtbScenarioBody.TabIndex = 0;
            this.rtbScenarioBody.Text = "";
            // 
            // gbDefenseBuilder
            // 
            this.gbDefenseBuilder.Controls.Add(this.tlpDefenseBuilder);
            this.gbDefenseBuilder.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbDefenseBuilder.Font = new System.Drawing.Font("Muro", 15F);
            this.gbDefenseBuilder.Location = new System.Drawing.Point(0, 214);
            this.gbDefenseBuilder.Margin = new System.Windows.Forms.Padding(0, 0, 0, 5);
            this.gbDefenseBuilder.Name = "gbDefenseBuilder";
            this.gbDefenseBuilder.Size = new System.Drawing.Size(1208, 239);
            this.gbDefenseBuilder.TabIndex = 1;
            this.gbDefenseBuilder.TabStop = false;
            this.gbDefenseBuilder.Text = "DEFENCE BUILDER";
            // 
            // tlpDefenseBuilder
            // 
            this.tlpDefenseBuilder.ColumnCount = 4;
            this.tlpDefenseBuilder.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this.tlpDefenseBuilder.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpDefenseBuilder.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 194F));
            this.tlpDefenseBuilder.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpDefenseBuilder.Controls.Add(this.cmbSession, 3, 3);
            this.tlpDefenseBuilder.Controls.Add(this.lblCapSession, 2, 3);
            this.tlpDefenseBuilder.Controls.Add(this.cmbRateLimit, 1, 3);
            this.tlpDefenseBuilder.Controls.Add(this.lblCapRateLimit, 0, 3);
            this.tlpDefenseBuilder.Controls.Add(this.cmbMonitoring, 3, 2);
            this.tlpDefenseBuilder.Controls.Add(this.lblCapMonitoring, 2, 2);
            this.tlpDefenseBuilder.Controls.Add(this.cmbRecovery, 1, 2);
            this.tlpDefenseBuilder.Controls.Add(this.lblCapRecovery, 0, 2);
            this.tlpDefenseBuilder.Controls.Add(this.lblActionPrompt, 0, 0);
            this.tlpDefenseBuilder.Controls.Add(this.lblCapAuthMethod, 0, 1);
            this.tlpDefenseBuilder.Controls.Add(this.cmbAuthMethod, 1, 1);
            this.tlpDefenseBuilder.Controls.Add(this.lblCapPasswordPolicy, 2, 1);
            this.tlpDefenseBuilder.Controls.Add(this.cmbPasswordPolicy, 3, 1);
            this.tlpDefenseBuilder.Controls.Add(this.flpDefenseToggles, 0, 4);
            this.tlpDefenseBuilder.Controls.Add(this.tlpDefenseButtons, 0, 5);
            this.tlpDefenseBuilder.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpDefenseBuilder.Location = new System.Drawing.Point(3, 33);
            this.tlpDefenseBuilder.Margin = new System.Windows.Forms.Padding(0);
            this.tlpDefenseBuilder.Name = "tlpDefenseBuilder";
            this.tlpDefenseBuilder.Padding = new System.Windows.Forms.Padding(6);
            this.tlpDefenseBuilder.RowCount = 6;
            this.tlpDefenseBuilder.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.tlpDefenseBuilder.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 34F));
            this.tlpDefenseBuilder.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 34F));
            this.tlpDefenseBuilder.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 34F));
            this.tlpDefenseBuilder.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpDefenseBuilder.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tlpDefenseBuilder.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpDefenseBuilder.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpDefenseBuilder.Size = new System.Drawing.Size(1202, 203);
            this.tlpDefenseBuilder.TabIndex = 0;
            // 
            // cmbSession
            // 
            this.cmbSession.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmbSession.Font = new System.Drawing.Font("Agency", 10F);
            this.cmbSession.FormattingEnabled = true;
            this.cmbSession.Location = new System.Drawing.Point(773, 108);
            this.cmbSession.Margin = new System.Windows.Forms.Padding(0, 6, 0, 0);
            this.cmbSession.Name = "cmbSession";
            this.cmbSession.Size = new System.Drawing.Size(423, 23);
            this.cmbSession.TabIndex = 12;
            this.cmbSession.SelectedIndexChanged += new System.EventHandler(this.cmbSession_SelectedIndexChanged);
            // 
            // lblCapSession
            // 
            this.lblCapSession.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblCapSession.AutoSize = true;
            this.lblCapSession.Font = new System.Drawing.Font("Agency", 10F);
            this.lblCapSession.Location = new System.Drawing.Point(582, 111);
            this.lblCapSession.Name = "lblCapSession";
            this.lblCapSession.Size = new System.Drawing.Size(179, 15);
            this.lblCapSession.TabIndex = 11;
            this.lblCapSession.Text = "SESSION CONTROL";
            this.lblCapSession.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cmbRateLimit
            // 
            this.cmbRateLimit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmbRateLimit.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbRateLimit.Font = new System.Drawing.Font("Agency", 10F);
            this.cmbRateLimit.FormattingEnabled = true;
            this.cmbRateLimit.Location = new System.Drawing.Point(156, 108);
            this.cmbRateLimit.Margin = new System.Windows.Forms.Padding(0, 6, 0, 0);
            this.cmbRateLimit.Name = "cmbRateLimit";
            this.cmbRateLimit.Size = new System.Drawing.Size(423, 23);
            this.cmbRateLimit.TabIndex = 10;
            this.cmbRateLimit.SelectedIndexChanged += new System.EventHandler(this.cmbRateLimit_SelectedIndexChanged);
            // 
            // lblCapRateLimit
            // 
            this.lblCapRateLimit.AutoSize = true;
            this.lblCapRateLimit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblCapRateLimit.Font = new System.Drawing.Font("Agency", 10F);
            this.lblCapRateLimit.Location = new System.Drawing.Point(9, 102);
            this.lblCapRateLimit.Name = "lblCapRateLimit";
            this.lblCapRateLimit.Size = new System.Drawing.Size(144, 34);
            this.lblCapRateLimit.TabIndex = 9;
            this.lblCapRateLimit.Text = "RATE LIMIT";
            this.lblCapRateLimit.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cmbMonitoring
            // 
            this.cmbMonitoring.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmbMonitoring.Font = new System.Drawing.Font("Agency", 10F);
            this.cmbMonitoring.FormattingEnabled = true;
            this.cmbMonitoring.Location = new System.Drawing.Point(773, 74);
            this.cmbMonitoring.Margin = new System.Windows.Forms.Padding(0, 6, 0, 0);
            this.cmbMonitoring.Name = "cmbMonitoring";
            this.cmbMonitoring.Size = new System.Drawing.Size(423, 23);
            this.cmbMonitoring.TabIndex = 8;
            this.cmbMonitoring.SelectedIndexChanged += new System.EventHandler(this.cmbMonitoring_SelectedIndexChanged);
            // 
            // lblCapMonitoring
            // 
            this.lblCapMonitoring.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblCapMonitoring.AutoSize = true;
            this.lblCapMonitoring.Font = new System.Drawing.Font("Agency", 10F);
            this.lblCapMonitoring.Location = new System.Drawing.Point(582, 77);
            this.lblCapMonitoring.Name = "lblCapMonitoring";
            this.lblCapMonitoring.Size = new System.Drawing.Size(128, 15);
            this.lblCapMonitoring.TabIndex = 7;
            this.lblCapMonitoring.Text = "MONITORING";
            this.lblCapMonitoring.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cmbRecovery
            // 
            this.cmbRecovery.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmbRecovery.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbRecovery.Font = new System.Drawing.Font("Agency", 10F);
            this.cmbRecovery.FormattingEnabled = true;
            this.cmbRecovery.Location = new System.Drawing.Point(156, 74);
            this.cmbRecovery.Margin = new System.Windows.Forms.Padding(0, 6, 0, 0);
            this.cmbRecovery.Name = "cmbRecovery";
            this.cmbRecovery.Size = new System.Drawing.Size(423, 23);
            this.cmbRecovery.TabIndex = 6;
            this.cmbRecovery.SelectedIndexChanged += new System.EventHandler(this.cmbRecovery_SelectedIndexChanged);
            // 
            // lblCapRecovery
            // 
            this.lblCapRecovery.AutoSize = true;
            this.lblCapRecovery.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblCapRecovery.Font = new System.Drawing.Font("Agency", 10F);
            this.lblCapRecovery.Location = new System.Drawing.Point(9, 68);
            this.lblCapRecovery.Name = "lblCapRecovery";
            this.lblCapRecovery.Size = new System.Drawing.Size(144, 34);
            this.lblCapRecovery.TabIndex = 5;
            this.lblCapRecovery.Text = "RECOVERY";
            this.lblCapRecovery.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblActionPrompt
            // 
            this.lblActionPrompt.AutoSize = true;
            this.tlpDefenseBuilder.SetColumnSpan(this.lblActionPrompt, 4);
            this.lblActionPrompt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblActionPrompt.Font = new System.Drawing.Font("Agency", 15F);
            this.lblActionPrompt.Location = new System.Drawing.Point(9, 6);
            this.lblActionPrompt.Name = "lblActionPrompt";
            this.lblActionPrompt.Size = new System.Drawing.Size(1184, 28);
            this.lblActionPrompt.TabIndex = 0;
            this.lblActionPrompt.Text = "CHOOSE THE BEST DEFENSIVE SETUP FOR THIS SCENARIO";
            // 
            // lblCapAuthMethod
            // 
            this.lblCapAuthMethod.AutoSize = true;
            this.lblCapAuthMethod.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblCapAuthMethod.Font = new System.Drawing.Font("Agency", 10F);
            this.lblCapAuthMethod.Location = new System.Drawing.Point(9, 34);
            this.lblCapAuthMethod.Name = "lblCapAuthMethod";
            this.lblCapAuthMethod.Size = new System.Drawing.Size(144, 34);
            this.lblCapAuthMethod.TabIndex = 1;
            this.lblCapAuthMethod.Text = "AUTH METHOD";
            this.lblCapAuthMethod.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cmbAuthMethod
            // 
            this.cmbAuthMethod.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmbAuthMethod.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbAuthMethod.Font = new System.Drawing.Font("Agency", 10F);
            this.cmbAuthMethod.FormattingEnabled = true;
            this.cmbAuthMethod.Location = new System.Drawing.Point(156, 40);
            this.cmbAuthMethod.Margin = new System.Windows.Forms.Padding(0, 6, 0, 0);
            this.cmbAuthMethod.Name = "cmbAuthMethod";
            this.cmbAuthMethod.Size = new System.Drawing.Size(423, 23);
            this.cmbAuthMethod.TabIndex = 2;
            this.cmbAuthMethod.SelectedIndexChanged += new System.EventHandler(this.cmbAuthMethod_SelectedIndexChanged);
            // 
            // lblCapPasswordPolicy
            // 
            this.lblCapPasswordPolicy.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblCapPasswordPolicy.AutoSize = true;
            this.lblCapPasswordPolicy.Font = new System.Drawing.Font("Agency", 10F);
            this.lblCapPasswordPolicy.Location = new System.Drawing.Point(582, 43);
            this.lblCapPasswordPolicy.Name = "lblCapPasswordPolicy";
            this.lblCapPasswordPolicy.Size = new System.Drawing.Size(187, 15);
            this.lblCapPasswordPolicy.TabIndex = 3;
            this.lblCapPasswordPolicy.Text = "PASSWORD POLICY";
            this.lblCapPasswordPolicy.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cmbPasswordPolicy
            // 
            this.cmbPasswordPolicy.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmbPasswordPolicy.Font = new System.Drawing.Font("Agency", 10F);
            this.cmbPasswordPolicy.FormattingEnabled = true;
            this.cmbPasswordPolicy.Location = new System.Drawing.Point(773, 40);
            this.cmbPasswordPolicy.Margin = new System.Windows.Forms.Padding(0, 6, 0, 0);
            this.cmbPasswordPolicy.Name = "cmbPasswordPolicy";
            this.cmbPasswordPolicy.Size = new System.Drawing.Size(423, 23);
            this.cmbPasswordPolicy.TabIndex = 4;
            this.cmbPasswordPolicy.SelectedIndexChanged += new System.EventHandler(this.cmbPasswordPolicy_SelectedIndexChanged);
            // 
            // flpDefenseToggles
            // 
            this.tlpDefenseBuilder.SetColumnSpan(this.flpDefenseToggles, 4);
            this.flpDefenseToggles.Controls.Add(this.chkRequireMfa);
            this.flpDefenseToggles.Controls.Add(this.chkPhishingResistant);
            this.flpDefenseToggles.Controls.Add(this.chkDeviceBinding);
            this.flpDefenseToggles.Controls.Add(this.chkRiskBasedStepUp);
            this.flpDefenseToggles.Controls.Add(this.chkBlockLegacyAuth);
            this.flpDefenseToggles.Controls.Add(this.chkAlertOnSuspicious);
            this.flpDefenseToggles.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flpDefenseToggles.Location = new System.Drawing.Point(6, 136);
            this.flpDefenseToggles.Margin = new System.Windows.Forms.Padding(0);
            this.flpDefenseToggles.Name = "flpDefenseToggles";
            this.flpDefenseToggles.Size = new System.Drawing.Size(1190, 26);
            this.flpDefenseToggles.TabIndex = 13;
            // 
            // chkRequireMfa
            // 
            this.chkRequireMfa.AutoSize = true;
            this.chkRequireMfa.Font = new System.Drawing.Font("Agency", 8F);
            this.chkRequireMfa.Location = new System.Drawing.Point(3, 3);
            this.chkRequireMfa.Name = "chkRequireMfa";
            this.chkRequireMfa.Size = new System.Drawing.Size(137, 21);
            this.chkRequireMfa.TabIndex = 0;
            this.chkRequireMfa.Text = "REQUIRE MFA";
            this.chkRequireMfa.UseVisualStyleBackColor = true;
            this.chkRequireMfa.CheckedChanged += new System.EventHandler(this.chkRequireMfa_CheckedChanged);
            // 
            // chkPhishingResistant
            // 
            this.chkPhishingResistant.AutoSize = true;
            this.chkPhishingResistant.Font = new System.Drawing.Font("Agency", 8F);
            this.chkPhishingResistant.Location = new System.Drawing.Point(146, 3);
            this.chkPhishingResistant.Name = "chkPhishingResistant";
            this.chkPhishingResistant.Size = new System.Drawing.Size(226, 21);
            this.chkPhishingResistant.TabIndex = 1;
            this.chkPhishingResistant.Text = "PHISHING-RESISTANT MFA";
            this.chkPhishingResistant.UseVisualStyleBackColor = true;
            this.chkPhishingResistant.CheckedChanged += new System.EventHandler(this.chkPhishingResistant_CheckedChanged);
            // 
            // chkDeviceBinding
            // 
            this.chkDeviceBinding.AutoSize = true;
            this.chkDeviceBinding.Font = new System.Drawing.Font("Agency", 8F);
            this.chkDeviceBinding.Location = new System.Drawing.Point(378, 3);
            this.chkDeviceBinding.Name = "chkDeviceBinding";
            this.chkDeviceBinding.Size = new System.Drawing.Size(155, 21);
            this.chkDeviceBinding.TabIndex = 2;
            this.chkDeviceBinding.Text = "DEVICE BINDING";
            this.chkDeviceBinding.UseVisualStyleBackColor = true;
            this.chkDeviceBinding.CheckedChanged += new System.EventHandler(this.chkDeviceBinding_CheckedChanged);
            // 
            // chkRiskBasedStepUp
            // 
            this.chkRiskBasedStepUp.AutoSize = true;
            this.chkRiskBasedStepUp.Font = new System.Drawing.Font("Agency", 8F);
            this.chkRiskBasedStepUp.Location = new System.Drawing.Point(539, 3);
            this.chkRiskBasedStepUp.Name = "chkRiskBasedStepUp";
            this.chkRiskBasedStepUp.Size = new System.Drawing.Size(184, 21);
            this.chkRiskBasedStepUp.TabIndex = 3;
            this.chkRiskBasedStepUp.Text = "RISK-BASED STEP-UP";
            this.chkRiskBasedStepUp.UseVisualStyleBackColor = true;
            this.chkRiskBasedStepUp.CheckedChanged += new System.EventHandler(this.chkRiskBasedStepUp_CheckedChanged);
            // 
            // chkBlockLegacyAuth
            // 
            this.chkBlockLegacyAuth.AutoSize = true;
            this.chkBlockLegacyAuth.Font = new System.Drawing.Font("Agency", 8F);
            this.chkBlockLegacyAuth.Location = new System.Drawing.Point(729, 3);
            this.chkBlockLegacyAuth.Name = "chkBlockLegacyAuth";
            this.chkBlockLegacyAuth.Size = new System.Drawing.Size(187, 21);
            this.chkBlockLegacyAuth.TabIndex = 4;
            this.chkBlockLegacyAuth.Text = "BLOCK LEGACY PATH";
            this.chkBlockLegacyAuth.UseVisualStyleBackColor = true;
            this.chkBlockLegacyAuth.CheckedChanged += new System.EventHandler(this.chkBlockLegacyAuth_CheckedChanged);
            // 
            // chkAlertOnSuspicious
            // 
            this.chkAlertOnSuspicious.AutoSize = true;
            this.chkAlertOnSuspicious.Font = new System.Drawing.Font("Agency", 8F);
            this.chkAlertOnSuspicious.Location = new System.Drawing.Point(922, 3);
            this.chkAlertOnSuspicious.Name = "chkAlertOnSuspicious";
            this.chkAlertOnSuspicious.Size = new System.Drawing.Size(246, 21);
            this.chkAlertOnSuspicious.TabIndex = 5;
            this.chkAlertOnSuspicious.Text = "ALERT ON SUSPICIOUS LOGIN";
            this.chkAlertOnSuspicious.UseVisualStyleBackColor = true;
            this.chkAlertOnSuspicious.CheckedChanged += new System.EventHandler(this.chkAlertOnSuspicious_CheckedChanged);
            // 
            // tlpDefenseButtons
            // 
            this.tlpDefenseButtons.ColumnCount = 3;
            this.tlpDefenseBuilder.SetColumnSpan(this.tlpDefenseButtons, 4);
            this.tlpDefenseButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 170F));
            this.tlpDefenseButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpDefenseButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 190F));
            this.tlpDefenseButtons.Controls.Add(this.btnClearBuild, 0, 0);
            this.tlpDefenseButtons.Controls.Add(this.btnRunSimulation, 2, 0);
            this.tlpDefenseButtons.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpDefenseButtons.Location = new System.Drawing.Point(6, 162);
            this.tlpDefenseButtons.Margin = new System.Windows.Forms.Padding(0);
            this.tlpDefenseButtons.Name = "tlpDefenseButtons";
            this.tlpDefenseButtons.RowCount = 1;
            this.tlpDefenseButtons.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpDefenseButtons.Size = new System.Drawing.Size(1190, 35);
            this.tlpDefenseButtons.TabIndex = 14;
            // 
            // btnClearBuild
            // 
            this.btnClearBuild.BackColor = System.Drawing.Color.Crimson;
            this.btnClearBuild.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnClearBuild.Font = new System.Drawing.Font("Muro", 12F);
            this.btnClearBuild.ForeColor = System.Drawing.Color.White;
            this.btnClearBuild.Location = new System.Drawing.Point(0, 0);
            this.btnClearBuild.Margin = new System.Windows.Forms.Padding(0);
            this.btnClearBuild.Name = "btnClearBuild";
            this.btnClearBuild.Size = new System.Drawing.Size(170, 35);
            this.btnClearBuild.Style.BackColor = System.Drawing.Color.Crimson;
            this.btnClearBuild.Style.ForeColor = System.Drawing.Color.White;
            this.btnClearBuild.TabIndex = 0;
            this.btnClearBuild.Text = "CLEAR BUILD";
            this.btnClearBuild.UseVisualStyleBackColor = false;
            this.btnClearBuild.Click += new System.EventHandler(this.btnClearBuild_Click);
            // 
            // btnRunSimulation
            // 
            this.btnRunSimulation.BackColor = System.Drawing.Color.SeaGreen;
            this.btnRunSimulation.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnRunSimulation.Font = new System.Drawing.Font("Muro", 12F);
            this.btnRunSimulation.ForeColor = System.Drawing.Color.White;
            this.btnRunSimulation.Location = new System.Drawing.Point(1000, 0);
            this.btnRunSimulation.Margin = new System.Windows.Forms.Padding(0);
            this.btnRunSimulation.Name = "btnRunSimulation";
            this.btnRunSimulation.Size = new System.Drawing.Size(190, 35);
            this.btnRunSimulation.Style.BackColor = System.Drawing.Color.SeaGreen;
            this.btnRunSimulation.Style.ForeColor = System.Drawing.Color.White;
            this.btnRunSimulation.TabIndex = 1;
            this.btnRunSimulation.Text = "SIMULATE ATTACK";
            this.btnRunSimulation.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRunSimulation.UseVisualStyleBackColor = false;
            this.btnRunSimulation.Click += new System.EventHandler(this.btnRunSimulation_Click);
            // 
            // gbResult
            // 
            this.gbResult.Controls.Add(this.tlpResult);
            this.gbResult.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbResult.Font = new System.Drawing.Font("Muro", 15F);
            this.gbResult.Location = new System.Drawing.Point(0, 458);
            this.gbResult.Margin = new System.Windows.Forms.Padding(0);
            this.gbResult.Name = "gbResult";
            this.gbResult.Size = new System.Drawing.Size(1208, 154);
            this.gbResult.TabIndex = 2;
            this.gbResult.TabStop = false;
            this.gbResult.Text = "RESULT";
            // 
            // tlpResult
            // 
            this.tlpResult.ColumnCount = 1;
            this.tlpResult.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpResult.Controls.Add(this.pnlResultTop, 0, 0);
            this.tlpResult.Controls.Add(this.lvFindings, 0, 1);
            this.tlpResult.Controls.Add(this.pnlResultBottom, 0, 2);
            this.tlpResult.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpResult.Location = new System.Drawing.Point(3, 33);
            this.tlpResult.Margin = new System.Windows.Forms.Padding(0);
            this.tlpResult.Name = "tlpResult";
            this.tlpResult.Padding = new System.Windows.Forms.Padding(6);
            this.tlpResult.RowCount = 3;
            this.tlpResult.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 44F));
            this.tlpResult.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpResult.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tlpResult.Size = new System.Drawing.Size(1202, 118);
            this.tlpResult.TabIndex = 0;
            // 
            // pnlResultTop
            // 
            this.pnlResultTop.Controls.Add(this.lblResultWhy);
            this.pnlResultTop.Controls.Add(this.lblResultScoreDelta);
            this.pnlResultTop.Controls.Add(this.lblResultsText);
            this.pnlResultTop.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlResultTop.Location = new System.Drawing.Point(9, 9);
            this.pnlResultTop.Name = "pnlResultTop";
            this.pnlResultTop.Size = new System.Drawing.Size(1184, 38);
            this.pnlResultTop.TabIndex = 0;
            // 
            // lblResultWhy
            // 
            this.lblResultWhy.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblResultWhy.AutoSize = true;
            this.lblResultWhy.Font = new System.Drawing.Font("Agency", 10F);
            this.lblResultWhy.Location = new System.Drawing.Point(563, 3);
            this.lblResultWhy.Name = "lblResultWhy";
            this.lblResultWhy.Size = new System.Drawing.Size(108, 15);
            this.lblResultWhy.TabIndex = 3;
            this.lblResultWhy.Text = "FINDINGS: -";
            // 
            // lblResultScoreDelta
            // 
            this.lblResultScoreDelta.AutoSize = true;
            this.lblResultScoreDelta.Font = new System.Drawing.Font("Agency", 10F);
            this.lblResultScoreDelta.Location = new System.Drawing.Point(1, 23);
            this.lblResultScoreDelta.Name = "lblResultScoreDelta";
            this.lblResultScoreDelta.Size = new System.Drawing.Size(133, 15);
            this.lblResultScoreDelta.TabIndex = 2;
            this.lblResultScoreDelta.Text = "+0 SCORE | +0s";
            // 
            // lblResultsText
            // 
            this.lblResultsText.AutoSize = true;
            this.lblResultsText.Font = new System.Drawing.Font("Agency", 10F);
            this.lblResultsText.Location = new System.Drawing.Point(4, 3);
            this.lblResultsText.Name = "lblResultsText";
            this.lblResultsText.Size = new System.Drawing.Size(12, 15);
            this.lblResultsText.TabIndex = 1;
            this.lblResultsText.Text = "-";
            // 
            // lvFindings
            // 
            this.lvFindings.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colFinding,
            this.colDetail,
            this.colImpact});
            this.lvFindings.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvFindings.Font = new System.Drawing.Font("Agency", 10F);
            this.lvFindings.FullRowSelect = true;
            this.lvFindings.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lvFindings.HideSelection = false;
            this.lvFindings.Location = new System.Drawing.Point(9, 53);
            this.lvFindings.MultiSelect = false;
            this.lvFindings.Name = "lvFindings";
            this.lvFindings.Size = new System.Drawing.Size(1184, 26);
            this.lvFindings.TabIndex = 1;
            this.lvFindings.UseCompatibleStateImageBehavior = false;
            this.lvFindings.View = System.Windows.Forms.View.Details;
            this.lvFindings.SelectedIndexChanged += new System.EventHandler(this.lvFindings_SelectedIndexChanged);
            // 
            // colFinding
            // 
            this.colFinding.Text = "FINDING";
            this.colFinding.Width = 220;
            // 
            // colDetail
            // 
            this.colDetail.Text = "DETAIL";
            this.colDetail.Width = 760;
            // 
            // colImpact
            // 
            this.colImpact.Text = "IMPACT";
            this.colImpact.Width = 110;
            // 
            // pnlResultBottom
            // 
            this.pnlResultBottom.Controls.Add(this.btnNextScenario);
            this.pnlResultBottom.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlResultBottom.Location = new System.Drawing.Point(9, 85);
            this.pnlResultBottom.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.pnlResultBottom.Name = "pnlResultBottom";
            this.pnlResultBottom.Size = new System.Drawing.Size(1184, 27);
            this.pnlResultBottom.TabIndex = 2;
            // 
            // btnNextScenario
            // 
            this.btnNextScenario.BackColor = System.Drawing.Color.RoyalBlue;
            this.btnNextScenario.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnNextScenario.Font = new System.Drawing.Font("Muro", 10F);
            this.btnNextScenario.ForeColor = System.Drawing.Color.White;
            this.btnNextScenario.Location = new System.Drawing.Point(1004, 0);
            this.btnNextScenario.Margin = new System.Windows.Forms.Padding(0);
            this.btnNextScenario.Name = "btnNextScenario";
            this.btnNextScenario.Size = new System.Drawing.Size(180, 27);
            this.btnNextScenario.Style.BackColor = System.Drawing.Color.RoyalBlue;
            this.btnNextScenario.Style.ForeColor = System.Drawing.Color.White;
            this.btnNextScenario.TabIndex = 0;
            this.btnNextScenario.Text = "NEXT SCENARIO";
            this.btnNextScenario.UseVisualStyleBackColor = false;
            this.btnNextScenario.Click += new System.EventHandler(this.btnNextScenario_Click);
            // 
            // tmrRun
            // 
            this.tmrRun.Interval = 250;
            this.tmrRun.Tick += new System.EventHandler(this.tmrRun_Tick);
            // 
            // AuthenticationDefenseForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(15F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(1930, 732);
            this.Controls.Add(this.tlpAuthRoot);
            this.Font = new System.Drawing.Font("Agency", 12F);
            this.Margin = new System.Windows.Forms.Padding(5, 3, 5, 3);
            this.MinimumSize = new System.Drawing.Size(1918, 771);
            this.Name = "AuthenticationDefenseForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Style.BackColor = System.Drawing.Color.WhiteSmoke;
            this.Style.MdiChild.IconHorizontalAlignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.Style.MdiChild.IconVerticalAlignment = System.Windows.Forms.VisualStyles.VerticalAlignment.Center;
            this.Text = "Authentication Defence - Mondas";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.AuthenticationDefenseForm_Load);
            this.tlpAuthRoot.ResumeLayout(false);
            this.pnlAuthHeader.ResumeLayout(false);
            this.tlpAuthHeader.ResumeLayout(false);
            this.tlpAuthHeader.PerformLayout();
            this.pnlHeaderLeft.ResumeLayout(false);
            this.pnlHeaderLeft.PerformLayout();
            this.pnlHeaderRight.ResumeLayout(false);
            this.pnlHeaderRight.PerformLayout();
            this.tlpAuthMain.ResumeLayout(false);
            this.gbScenarioQueue.ResumeLayout(false);
            this.tlpQueueHost.ResumeLayout(false);
            this.pnlQueueFooter.ResumeLayout(false);
            this.tlpQueueFooter.ResumeLayout(false);
            this.tlpWorkArea.ResumeLayout(false);
            this.gbScenario.ResumeLayout(false);
            this.tlpScenario.ResumeLayout(false);
            this.tlpScenarioMeta.ResumeLayout(false);
            this.tlpScenarioMeta.PerformLayout();
            this.pnlScenarioBody.ResumeLayout(false);
            this.gbDefenseBuilder.ResumeLayout(false);
            this.tlpDefenseBuilder.ResumeLayout(false);
            this.tlpDefenseBuilder.PerformLayout();
            this.flpDefenseToggles.ResumeLayout(false);
            this.flpDefenseToggles.PerformLayout();
            this.tlpDefenseButtons.ResumeLayout(false);
            this.gbResult.ResumeLayout(false);
            this.tlpResult.ResumeLayout(false);
            this.pnlResultTop.ResumeLayout(false);
            this.pnlResultTop.PerformLayout();
            this.pnlResultBottom.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tlpAuthRoot;
        private System.Windows.Forms.Panel pnlAuthHeader;
        private System.Windows.Forms.TableLayoutPanel tlpAuthHeader;
        private System.Windows.Forms.Panel pnlHeaderLeft;
        private System.Windows.Forms.Label lblAuthSubtitle;
        private System.Windows.Forms.Label lblAuthTitle;
        private System.Windows.Forms.Label lblRunInfo;
        private System.Windows.Forms.Panel pnlHeaderRight;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.Label lblUser;
        private System.Windows.Forms.TableLayoutPanel tlpAuthMain;
        private System.Windows.Forms.GroupBox gbScenarioQueue;
        private System.Windows.Forms.TableLayoutPanel tlpQueueHost;
        private System.Windows.Forms.ListView lvQueue;
        private System.Windows.Forms.ColumnHeader colQueueStatus;
        private System.Windows.Forms.ColumnHeader colQueueScenario;
        private System.Windows.Forms.ColumnHeader colQueueRisk;
        private System.Windows.Forms.ColumnHeader colQueueTime;
        private System.Windows.Forms.Panel pnlQueueFooter;
        private System.Windows.Forms.TableLayoutPanel tlpQueueFooter;
        private Syncfusion.WinForms.Controls.SfButton btnNewScenario;
        private Syncfusion.WinForms.Controls.SfButton btnFinishRun;
        private Syncfusion.WinForms.Controls.SfButton btnResetRun;
        private System.Windows.Forms.TableLayoutPanel tlpWorkArea;
        private System.Windows.Forms.GroupBox gbScenario;
        private System.Windows.Forms.TableLayoutPanel tlpScenario;
        private System.Windows.Forms.TableLayoutPanel tlpScenarioMeta;
        private System.Windows.Forms.Label lblCapScenario;
        private System.Windows.Forms.Label lblDifficulty;
        private System.Windows.Forms.Label lblCapDifficulty;
        private System.Windows.Forms.Label lblGoal;
        private System.Windows.Forms.Label lblCapGoal;
        private System.Windows.Forms.Label lblThreatType;
        private System.Windows.Forms.Label lblCapThreat;
        private System.Windows.Forms.Label lblScenarioName;
        private Syncfusion.WinForms.Controls.SfButton btnViewHints;
        private System.Windows.Forms.Panel pnlScenarioBody;
        private System.Windows.Forms.RichTextBox rtbScenarioBody;
        private System.Windows.Forms.GroupBox gbDefenseBuilder;
        private System.Windows.Forms.TableLayoutPanel tlpDefenseBuilder;
        private System.Windows.Forms.Label lblActionPrompt;
        private System.Windows.Forms.Label lblCapAuthMethod;
        private System.Windows.Forms.ComboBox cmbAuthMethod;
        private System.Windows.Forms.Label lblCapPasswordPolicy;
        private System.Windows.Forms.ComboBox cmbPasswordPolicy;
        private System.Windows.Forms.ComboBox cmbMonitoring;
        private System.Windows.Forms.Label lblCapMonitoring;
        private System.Windows.Forms.ComboBox cmbRecovery;
        private System.Windows.Forms.Label lblCapRecovery;
        private System.Windows.Forms.ComboBox cmbSession;
        private System.Windows.Forms.Label lblCapSession;
        private System.Windows.Forms.ComboBox cmbRateLimit;
        private System.Windows.Forms.Label lblCapRateLimit;
        private System.Windows.Forms.FlowLayoutPanel flpDefenseToggles;
        private System.Windows.Forms.CheckBox chkRequireMfa;
        private System.Windows.Forms.CheckBox chkPhishingResistant;
        private System.Windows.Forms.CheckBox chkDeviceBinding;
        private System.Windows.Forms.CheckBox chkRiskBasedStepUp;
        private System.Windows.Forms.CheckBox chkBlockLegacyAuth;
        private System.Windows.Forms.CheckBox chkAlertOnSuspicious;
        private System.Windows.Forms.TableLayoutPanel tlpDefenseButtons;
        private Syncfusion.WinForms.Controls.SfButton btnClearBuild;
        private Syncfusion.WinForms.Controls.SfButton btnRunSimulation;
        private System.Windows.Forms.GroupBox gbResult;
        private System.Windows.Forms.TableLayoutPanel tlpResult;
        private System.Windows.Forms.Panel pnlResultTop;
        private System.Windows.Forms.Label lblResultScoreDelta;
        private System.Windows.Forms.Label lblResultsText;
        private System.Windows.Forms.Label lblResultWhy;
        private System.Windows.Forms.ListView lvFindings;
        private System.Windows.Forms.ColumnHeader colFinding;
        private System.Windows.Forms.ColumnHeader colDetail;
        private System.Windows.Forms.ColumnHeader colImpact;
        private System.Windows.Forms.Panel pnlResultBottom;
        private Syncfusion.WinForms.Controls.SfButton btnNextScenario;
        private System.Windows.Forms.Timer tmrRun;
    }
}