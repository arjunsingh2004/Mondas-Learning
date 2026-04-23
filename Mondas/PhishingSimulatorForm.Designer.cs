namespace Mondas
{
    partial class PhishingSimulatorForm
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
            this.tlpPhishRoot = new System.Windows.Forms.TableLayoutPanel();
            this.pnlPhishHeader = new System.Windows.Forms.Panel();
            this.lblRunInfo = new System.Windows.Forms.Label();
            this.btnLogout = new System.Windows.Forms.Button();
            this.lblUser = new System.Windows.Forms.Label();
            this.lblPhishSubtitle = new System.Windows.Forms.Label();
            this.lblPhishTitle = new System.Windows.Forms.Label();
            this.tlpPhishMain = new System.Windows.Forms.TableLayoutPanel();
            this.gbInbox = new System.Windows.Forms.GroupBox();
            this.tlpInboxHost = new System.Windows.Forms.TableLayoutPanel();
            this.lvInbox = new System.Windows.Forms.ListView();
            this.colInboxStatus = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colInboxSender = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colInboxSubject = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colInboxTime = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.pnlInboxFooter = new System.Windows.Forms.Panel();
            this.btnResetRun = new Syncfusion.WinForms.Controls.SfButton();
            this.btnNewEmail = new Syncfusion.WinForms.Controls.SfButton();
            this.tlpMessageArea = new System.Windows.Forms.TableLayoutPanel();
            this.gbMessage = new System.Windows.Forms.GroupBox();
            this.pnlMessageBody = new System.Windows.Forms.Panel();
            this.rtbMessageBody = new System.Windows.Forms.RichTextBox();
            this.tlpMsgMeta = new System.Windows.Forms.TableLayoutPanel();
            this.lblCapFrom = new System.Windows.Forms.Label();
            this.lblFrom = new System.Windows.Forms.Label();
            this.lblCapTo = new System.Windows.Forms.Label();
            this.lblTo = new System.Windows.Forms.Label();
            this.lblCapSubject = new System.Windows.Forms.Label();
            this.lblSubject = new System.Windows.Forms.Label();
            this.lblCapReceived = new System.Windows.Forms.Label();
            this.lblReceived = new System.Windows.Forms.Label();
            this.btnViewDetails = new Syncfusion.WinForms.Controls.SfButton();
            this.gbActions = new System.Windows.Forms.GroupBox();
            this.tlpActions = new System.Windows.Forms.TableLayoutPanel();
            this.lblActionPrompt = new System.Windows.Forms.Label();
            this.btnTrust = new Syncfusion.WinForms.Controls.SfButton();
            this.btnReportPhish = new Syncfusion.WinForms.Controls.SfButton();
            this.btnOpenLink = new Syncfusion.WinForms.Controls.SfButton();
            this.btnOpenAtt = new Syncfusion.WinForms.Controls.SfButton();
            this.pnlResult = new System.Windows.Forms.Panel();
            this.btnNextEmail = new Syncfusion.WinForms.Controls.SfButton();
            this.lblResultWhy = new System.Windows.Forms.Label();
            this.lblResultScoreDelta = new System.Windows.Forms.Label();
            this.lblResultText = new System.Windows.Forms.Label();
            this.lblResultTitle = new System.Windows.Forms.Label();
            this.lvSignals = new System.Windows.Forms.ListView();
            this.signalCol = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tmrRun = new System.Windows.Forms.Timer(this.components);
            this.detailCol = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.wCol = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tlpInboxFooter = new System.Windows.Forms.TableLayoutPanel();
            this.btnFinishRun = new Syncfusion.WinForms.Controls.SfButton();
            this.tlpPhishRoot.SuspendLayout();
            this.pnlPhishHeader.SuspendLayout();
            this.tlpPhishMain.SuspendLayout();
            this.gbInbox.SuspendLayout();
            this.tlpInboxHost.SuspendLayout();
            this.pnlInboxFooter.SuspendLayout();
            this.tlpMessageArea.SuspendLayout();
            this.gbMessage.SuspendLayout();
            this.pnlMessageBody.SuspendLayout();
            this.tlpMsgMeta.SuspendLayout();
            this.gbActions.SuspendLayout();
            this.tlpActions.SuspendLayout();
            this.pnlResult.SuspendLayout();
            this.tlpInboxFooter.SuspendLayout();
            this.SuspendLayout();
            // 
            // tlpPhishRoot
            // 
            this.tlpPhishRoot.ColumnCount = 1;
            this.tlpPhishRoot.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpPhishRoot.Controls.Add(this.pnlPhishHeader, 0, 0);
            this.tlpPhishRoot.Controls.Add(this.tlpPhishMain, 0, 1);
            this.tlpPhishRoot.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpPhishRoot.Location = new System.Drawing.Point(2, 2);
            this.tlpPhishRoot.Name = "tlpPhishRoot";
            this.tlpPhishRoot.Padding = new System.Windows.Forms.Padding(10);
            this.tlpPhishRoot.RowCount = 3;
            this.tlpPhishRoot.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 70F));
            this.tlpPhishRoot.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpPhishRoot.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 56F));
            this.tlpPhishRoot.Size = new System.Drawing.Size(1180, 657);
            this.tlpPhishRoot.TabIndex = 0;
            // 
            // pnlPhishHeader
            // 
            this.pnlPhishHeader.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlPhishHeader.Controls.Add(this.lblRunInfo);
            this.pnlPhishHeader.Controls.Add(this.btnLogout);
            this.pnlPhishHeader.Controls.Add(this.lblUser);
            this.pnlPhishHeader.Controls.Add(this.lblPhishSubtitle);
            this.pnlPhishHeader.Controls.Add(this.lblPhishTitle);
            this.pnlPhishHeader.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlPhishHeader.Location = new System.Drawing.Point(13, 13);
            this.pnlPhishHeader.Name = "pnlPhishHeader";
            this.pnlPhishHeader.Padding = new System.Windows.Forms.Padding(16, 10, 16, 10);
            this.pnlPhishHeader.Size = new System.Drawing.Size(1154, 64);
            this.pnlPhishHeader.TabIndex = 0;
            // 
            // lblRunInfo
            // 
            this.lblRunInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblRunInfo.AutoSize = true;
            this.lblRunInfo.Font = new System.Drawing.Font("Muro", 11F);
            this.lblRunInfo.Location = new System.Drawing.Point(458, 14);
            this.lblRunInfo.Name = "lblRunInfo";
            this.lblRunInfo.Size = new System.Drawing.Size(306, 22);
            this.lblRunInfo.TabIndex = 6;
            this.lblRunInfo.Text = "SCORE: 0 | STREAK | 0 | TIME: 00.00";
            this.lblRunInfo.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnLogout
            // 
            this.btnLogout.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLogout.BackColor = System.Drawing.Color.White;
            this.btnLogout.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.btnLogout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogout.Font = new System.Drawing.Font("Agency", 9F);
            this.btnLogout.Location = new System.Drawing.Point(1042, 15);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(91, 30);
            this.btnLogout.TabIndex = 5;
            this.btnLogout.Text = "LOG OUT";
            this.btnLogout.UseVisualStyleBackColor = false;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // lblUser
            // 
            this.lblUser.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblUser.AutoSize = true;
            this.lblUser.Font = new System.Drawing.Font("Agency", 9F);
            this.lblUser.Location = new System.Drawing.Point(915, 23);
            this.lblUser.Name = "lblUser";
            this.lblUser.Size = new System.Drawing.Size(121, 14);
            this.lblUser.TabIndex = 4;
            this.lblUser.Text = "ARJUN SINGH";
            // 
            // lblPhishSubtitle
            // 
            this.lblPhishSubtitle.AutoSize = true;
            this.lblPhishSubtitle.Font = new System.Drawing.Font("Agency", 10F);
            this.lblPhishSubtitle.Location = new System.Drawing.Point(8, 42);
            this.lblPhishSubtitle.Name = "lblPhishSubtitle";
            this.lblPhishSubtitle.Size = new System.Drawing.Size(139, 15);
            this.lblPhishSubtitle.TabIndex = 1;
            this.lblPhishSubtitle.Text = "INBOX TRIAGE";
            // 
            // lblPhishTitle
            // 
            this.lblPhishTitle.AutoSize = true;
            this.lblPhishTitle.Font = new System.Drawing.Font("Muro", 22F);
            this.lblPhishTitle.Location = new System.Drawing.Point(3, -8);
            this.lblPhishTitle.Name = "lblPhishTitle";
            this.lblPhishTitle.Size = new System.Drawing.Size(366, 44);
            this.lblPhishTitle.TabIndex = 0;
            this.lblPhishTitle.Text = "PHISHING SIMULATOR";
            // 
            // tlpPhishMain
            // 
            this.tlpPhishMain.ColumnCount = 2;
            this.tlpPhishMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 38F));
            this.tlpPhishMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 62F));
            this.tlpPhishMain.Controls.Add(this.gbInbox, 0, 0);
            this.tlpPhishMain.Controls.Add(this.tlpMessageArea, 1, 0);
            this.tlpPhishMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpPhishMain.Location = new System.Drawing.Point(10, 80);
            this.tlpPhishMain.Margin = new System.Windows.Forms.Padding(0);
            this.tlpPhishMain.Name = "tlpPhishMain";
            this.tlpPhishMain.RowCount = 1;
            this.tlpPhishMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpPhishMain.Size = new System.Drawing.Size(1160, 511);
            this.tlpPhishMain.TabIndex = 1;
            // 
            // gbInbox
            // 
            this.gbInbox.Controls.Add(this.tlpInboxHost);
            this.gbInbox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbInbox.Font = new System.Drawing.Font("Muro", 11F);
            this.gbInbox.Location = new System.Drawing.Point(0, 0);
            this.gbInbox.Margin = new System.Windows.Forms.Padding(0, 0, 10, 0);
            this.gbInbox.Name = "gbInbox";
            this.gbInbox.Padding = new System.Windows.Forms.Padding(10);
            this.gbInbox.Size = new System.Drawing.Size(430, 511);
            this.gbInbox.TabIndex = 0;
            this.gbInbox.TabStop = false;
            this.gbInbox.Text = "INBOX";
            // 
            // tlpInboxHost
            // 
            this.tlpInboxHost.ColumnCount = 1;
            this.tlpInboxHost.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpInboxHost.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpInboxHost.Controls.Add(this.lvInbox, 0, 0);
            this.tlpInboxHost.Controls.Add(this.pnlInboxFooter, 0, 1);
            this.tlpInboxHost.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpInboxHost.Location = new System.Drawing.Point(10, 32);
            this.tlpInboxHost.Margin = new System.Windows.Forms.Padding(0);
            this.tlpInboxHost.Name = "tlpInboxHost";
            this.tlpInboxHost.RowCount = 2;
            this.tlpInboxHost.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpInboxHost.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 44F));
            this.tlpInboxHost.Size = new System.Drawing.Size(410, 469);
            this.tlpInboxHost.TabIndex = 1;
            // 
            // lvInbox
            // 
            this.lvInbox.Activation = System.Windows.Forms.ItemActivation.OneClick;
            this.lvInbox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lvInbox.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colInboxStatus,
            this.colInboxSender,
            this.colInboxSubject,
            this.colInboxTime});
            this.lvInbox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvInbox.Font = new System.Drawing.Font("Muro", 10F);
            this.lvInbox.FullRowSelect = true;
            this.lvInbox.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lvInbox.HideSelection = false;
            this.lvInbox.Location = new System.Drawing.Point(3, 3);
            this.lvInbox.MultiSelect = false;
            this.lvInbox.Name = "lvInbox";
            this.lvInbox.Size = new System.Drawing.Size(404, 419);
            this.lvInbox.TabIndex = 0;
            this.lvInbox.UseCompatibleStateImageBehavior = false;
            this.lvInbox.View = System.Windows.Forms.View.Details;
            // 
            // colInboxStatus
            // 
            this.colInboxStatus.Text = "TYPE";
            this.colInboxStatus.Width = 70;
            // 
            // colInboxSender
            // 
            this.colInboxSender.Text = "SENDER";
            this.colInboxSender.Width = 230;
            // 
            // colInboxSubject
            // 
            this.colInboxSubject.Text = "SUBJECT";
            this.colInboxSubject.Width = 260;
            // 
            // colInboxTime
            // 
            this.colInboxTime.Text = "TIME";
            this.colInboxTime.Width = 90;
            // 
            // pnlInboxFooter
            // 
            this.pnlInboxFooter.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlInboxFooter.Controls.Add(this.tlpInboxFooter);
            this.pnlInboxFooter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlInboxFooter.Location = new System.Drawing.Point(0, 425);
            this.pnlInboxFooter.Margin = new System.Windows.Forms.Padding(0);
            this.pnlInboxFooter.Name = "pnlInboxFooter";
            this.pnlInboxFooter.Padding = new System.Windows.Forms.Padding(6);
            this.pnlInboxFooter.Size = new System.Drawing.Size(410, 44);
            this.pnlInboxFooter.TabIndex = 1;
            // 
            // btnResetRun
            // 
            this.btnResetRun.BackColor = System.Drawing.Color.Crimson;
            this.btnResetRun.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnResetRun.Font = new System.Drawing.Font("Muro", 11F);
            this.btnResetRun.ForeColor = System.Drawing.Color.White;
            this.btnResetRun.Location = new System.Drawing.Point(265, 3);
            this.btnResetRun.Name = "btnResetRun";
            this.btnResetRun.Size = new System.Drawing.Size(128, 24);
            this.btnResetRun.Style.BackColor = System.Drawing.Color.Crimson;
            this.btnResetRun.Style.ForeColor = System.Drawing.Color.White;
            this.btnResetRun.TabIndex = 1;
            this.btnResetRun.Text = "RESET RUN";
            this.btnResetRun.UseVisualStyleBackColor = false;
            this.btnResetRun.Click += new System.EventHandler(this.btnResetRun_Click);
            // 
            // btnNewEmail
            // 
            this.btnNewEmail.BackColor = System.Drawing.Color.SeaGreen;
            this.btnNewEmail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnNewEmail.Font = new System.Drawing.Font("Muro", 11F);
            this.btnNewEmail.ForeColor = System.Drawing.Color.White;
            this.btnNewEmail.Location = new System.Drawing.Point(3, 3);
            this.btnNewEmail.Name = "btnNewEmail";
            this.btnNewEmail.Size = new System.Drawing.Size(125, 24);
            this.btnNewEmail.Style.BackColor = System.Drawing.Color.SeaGreen;
            this.btnNewEmail.Style.ForeColor = System.Drawing.Color.White;
            this.btnNewEmail.TabIndex = 0;
            this.btnNewEmail.Text = "NEW EMAIL";
            this.btnNewEmail.UseVisualStyleBackColor = false;
            this.btnNewEmail.Click += new System.EventHandler(this.btnNewEmail_Click);
            // 
            // tlpMessageArea
            // 
            this.tlpMessageArea.ColumnCount = 1;
            this.tlpMessageArea.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpMessageArea.Controls.Add(this.gbMessage, 0, 0);
            this.tlpMessageArea.Controls.Add(this.gbActions, 0, 1);
            this.tlpMessageArea.Controls.Add(this.pnlResult, 0, 2);
            this.tlpMessageArea.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpMessageArea.Location = new System.Drawing.Point(440, 0);
            this.tlpMessageArea.Margin = new System.Windows.Forms.Padding(0);
            this.tlpMessageArea.Name = "tlpMessageArea";
            this.tlpMessageArea.RowCount = 3;
            this.tlpMessageArea.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 350F));
            this.tlpMessageArea.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 140F));
            this.tlpMessageArea.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpMessageArea.Size = new System.Drawing.Size(720, 511);
            this.tlpMessageArea.TabIndex = 1;
            // 
            // gbMessage
            // 
            this.gbMessage.Controls.Add(this.pnlMessageBody);
            this.gbMessage.Controls.Add(this.tlpMsgMeta);
            this.gbMessage.Controls.Add(this.btnViewDetails);
            this.gbMessage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbMessage.Font = new System.Drawing.Font("Muro", 11F);
            this.gbMessage.Location = new System.Drawing.Point(0, 0);
            this.gbMessage.Margin = new System.Windows.Forms.Padding(0);
            this.gbMessage.Name = "gbMessage";
            this.gbMessage.Padding = new System.Windows.Forms.Padding(10);
            this.gbMessage.Size = new System.Drawing.Size(720, 350);
            this.gbMessage.TabIndex = 0;
            this.gbMessage.TabStop = false;
            this.gbMessage.Text = "MESSAGE";
            // 
            // pnlMessageBody
            // 
            this.pnlMessageBody.Controls.Add(this.rtbMessageBody);
            this.pnlMessageBody.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMessageBody.Location = new System.Drawing.Point(10, 78);
            this.pnlMessageBody.Name = "pnlMessageBody";
            this.pnlMessageBody.Padding = new System.Windows.Forms.Padding(8);
            this.pnlMessageBody.Size = new System.Drawing.Size(700, 262);
            this.pnlMessageBody.TabIndex = 3;
            // 
            // rtbMessageBody
            // 
            this.rtbMessageBody.BackColor = System.Drawing.Color.White;
            this.rtbMessageBody.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rtbMessageBody.DetectUrls = false;
            this.rtbMessageBody.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtbMessageBody.Location = new System.Drawing.Point(8, 8);
            this.rtbMessageBody.Name = "rtbMessageBody";
            this.rtbMessageBody.ReadOnly = true;
            this.rtbMessageBody.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.rtbMessageBody.Size = new System.Drawing.Size(684, 246);
            this.rtbMessageBody.TabIndex = 2;
            this.rtbMessageBody.TabStop = false;
            this.rtbMessageBody.Text = "";
            // 
            // tlpMsgMeta
            // 
            this.tlpMsgMeta.AutoSize = true;
            this.tlpMsgMeta.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tlpMsgMeta.ColumnCount = 4;
            this.tlpMsgMeta.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 90F));
            this.tlpMsgMeta.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpMsgMeta.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 90F));
            this.tlpMsgMeta.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpMsgMeta.Controls.Add(this.lblCapFrom, 0, 0);
            this.tlpMsgMeta.Controls.Add(this.lblFrom, 1, 0);
            this.tlpMsgMeta.Controls.Add(this.lblCapTo, 2, 0);
            this.tlpMsgMeta.Controls.Add(this.lblTo, 3, 0);
            this.tlpMsgMeta.Controls.Add(this.lblCapSubject, 0, 1);
            this.tlpMsgMeta.Controls.Add(this.lblSubject, 1, 1);
            this.tlpMsgMeta.Controls.Add(this.lblCapReceived, 2, 1);
            this.tlpMsgMeta.Controls.Add(this.lblReceived, 3, 1);
            this.tlpMsgMeta.Dock = System.Windows.Forms.DockStyle.Top;
            this.tlpMsgMeta.Location = new System.Drawing.Point(10, 32);
            this.tlpMsgMeta.Margin = new System.Windows.Forms.Padding(0);
            this.tlpMsgMeta.Name = "tlpMsgMeta";
            this.tlpMsgMeta.RowCount = 2;
            this.tlpMsgMeta.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpMsgMeta.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpMsgMeta.Size = new System.Drawing.Size(700, 46);
            this.tlpMsgMeta.TabIndex = 0;
            // 
            // lblCapFrom
            // 
            this.lblCapFrom.AutoEllipsis = true;
            this.lblCapFrom.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblCapFrom.Font = new System.Drawing.Font("Muro", 10F);
            this.lblCapFrom.Location = new System.Drawing.Point(0, 0);
            this.lblCapFrom.Margin = new System.Windows.Forms.Padding(0);
            this.lblCapFrom.Name = "lblCapFrom";
            this.lblCapFrom.Size = new System.Drawing.Size(90, 23);
            this.lblCapFrom.TabIndex = 0;
            this.lblCapFrom.Text = "FROM:";
            this.lblCapFrom.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblFrom
            // 
            this.lblFrom.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblFrom.Font = new System.Drawing.Font("Muro", 10F);
            this.lblFrom.Location = new System.Drawing.Point(90, 0);
            this.lblFrom.Margin = new System.Windows.Forms.Padding(0);
            this.lblFrom.Name = "lblFrom";
            this.lblFrom.Size = new System.Drawing.Size(260, 23);
            this.lblFrom.TabIndex = 1;
            this.lblFrom.Text = "-";
            this.lblFrom.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblCapTo
            // 
            this.lblCapTo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblCapTo.Font = new System.Drawing.Font("Muro", 10F);
            this.lblCapTo.Location = new System.Drawing.Point(350, 0);
            this.lblCapTo.Margin = new System.Windows.Forms.Padding(0);
            this.lblCapTo.Name = "lblCapTo";
            this.lblCapTo.Size = new System.Drawing.Size(90, 23);
            this.lblCapTo.TabIndex = 2;
            this.lblCapTo.Text = "TO:";
            this.lblCapTo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblTo
            // 
            this.lblTo.AutoEllipsis = true;
            this.lblTo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTo.Font = new System.Drawing.Font("Muro", 10F);
            this.lblTo.Location = new System.Drawing.Point(440, 0);
            this.lblTo.Margin = new System.Windows.Forms.Padding(0);
            this.lblTo.Name = "lblTo";
            this.lblTo.Size = new System.Drawing.Size(260, 23);
            this.lblTo.TabIndex = 3;
            this.lblTo.Text = "-";
            this.lblTo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblCapSubject
            // 
            this.lblCapSubject.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblCapSubject.Font = new System.Drawing.Font("Muro", 10F);
            this.lblCapSubject.Location = new System.Drawing.Point(0, 23);
            this.lblCapSubject.Margin = new System.Windows.Forms.Padding(0);
            this.lblCapSubject.Name = "lblCapSubject";
            this.lblCapSubject.Size = new System.Drawing.Size(90, 23);
            this.lblCapSubject.TabIndex = 4;
            this.lblCapSubject.Text = "SUBJECT:";
            this.lblCapSubject.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblSubject
            // 
            this.lblSubject.AutoEllipsis = true;
            this.lblSubject.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblSubject.Font = new System.Drawing.Font("Muro", 10F);
            this.lblSubject.Location = new System.Drawing.Point(90, 23);
            this.lblSubject.Margin = new System.Windows.Forms.Padding(0);
            this.lblSubject.Name = "lblSubject";
            this.lblSubject.Size = new System.Drawing.Size(260, 23);
            this.lblSubject.TabIndex = 5;
            this.lblSubject.Text = "-";
            this.lblSubject.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblCapReceived
            // 
            this.lblCapReceived.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblCapReceived.Font = new System.Drawing.Font("Muro", 10F);
            this.lblCapReceived.Location = new System.Drawing.Point(350, 23);
            this.lblCapReceived.Margin = new System.Windows.Forms.Padding(0);
            this.lblCapReceived.Name = "lblCapReceived";
            this.lblCapReceived.Size = new System.Drawing.Size(90, 23);
            this.lblCapReceived.TabIndex = 6;
            this.lblCapReceived.Text = "RECEIVED:";
            this.lblCapReceived.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblReceived
            // 
            this.lblReceived.AutoEllipsis = true;
            this.lblReceived.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblReceived.Font = new System.Drawing.Font("Muro", 10F);
            this.lblReceived.Location = new System.Drawing.Point(440, 23);
            this.lblReceived.Margin = new System.Windows.Forms.Padding(0);
            this.lblReceived.Name = "lblReceived";
            this.lblReceived.Size = new System.Drawing.Size(260, 23);
            this.lblReceived.TabIndex = 7;
            this.lblReceived.Text = "-";
            this.lblReceived.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnViewDetails
            // 
            this.btnViewDetails.BackColor = System.Drawing.Color.RoyalBlue;
            this.btnViewDetails.Font = new System.Drawing.Font("Muro", 9F);
            this.btnViewDetails.ForeColor = System.Drawing.Color.White;
            this.btnViewDetails.Location = new System.Drawing.Point(584, 1);
            this.btnViewDetails.Name = "btnViewDetails";
            this.btnViewDetails.Size = new System.Drawing.Size(120, 28);
            this.btnViewDetails.Style.BackColor = System.Drawing.Color.RoyalBlue;
            this.btnViewDetails.Style.ForeColor = System.Drawing.Color.White;
            this.btnViewDetails.TabIndex = 1;
            this.btnViewDetails.Text = "VIEW DETAILS";
            this.btnViewDetails.UseVisualStyleBackColor = false;
            this.btnViewDetails.Click += new System.EventHandler(this.btnViewDetails_Click);
            // 
            // gbActions
            // 
            this.gbActions.Controls.Add(this.tlpActions);
            this.gbActions.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbActions.Font = new System.Drawing.Font("Muro", 11F);
            this.gbActions.Location = new System.Drawing.Point(0, 350);
            this.gbActions.Margin = new System.Windows.Forms.Padding(0);
            this.gbActions.Name = "gbActions";
            this.gbActions.Padding = new System.Windows.Forms.Padding(10);
            this.gbActions.Size = new System.Drawing.Size(720, 140);
            this.gbActions.TabIndex = 1;
            this.gbActions.TabStop = false;
            this.gbActions.Text = "ACTIONS";
            // 
            // tlpActions
            // 
            this.tlpActions.ColumnCount = 4;
            this.tlpActions.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpActions.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpActions.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpActions.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpActions.Controls.Add(this.lblActionPrompt, 0, 0);
            this.tlpActions.Controls.Add(this.btnTrust, 0, 1);
            this.tlpActions.Controls.Add(this.btnReportPhish, 1, 1);
            this.tlpActions.Controls.Add(this.btnOpenLink, 2, 1);
            this.tlpActions.Controls.Add(this.btnOpenAtt, 3, 1);
            this.tlpActions.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpActions.Location = new System.Drawing.Point(10, 32);
            this.tlpActions.Name = "tlpActions";
            this.tlpActions.RowCount = 2;
            this.tlpActions.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.tlpActions.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpActions.Size = new System.Drawing.Size(700, 98);
            this.tlpActions.TabIndex = 0;
            // 
            // lblActionPrompt
            // 
            this.lblActionPrompt.AutoSize = true;
            this.tlpActions.SetColumnSpan(this.lblActionPrompt, 4);
            this.lblActionPrompt.Location = new System.Drawing.Point(3, 0);
            this.lblActionPrompt.Name = "lblActionPrompt";
            this.lblActionPrompt.Size = new System.Drawing.Size(166, 22);
            this.lblActionPrompt.TabIndex = 0;
            this.lblActionPrompt.Text = "WHAT DO YOU DO?";
            this.lblActionPrompt.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnTrust
            // 
            this.btnTrust.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnTrust.Font = new System.Drawing.Font("Muro", 10F);
            this.btnTrust.Location = new System.Drawing.Point(3, 31);
            this.btnTrust.Name = "btnTrust";
            this.btnTrust.Size = new System.Drawing.Size(169, 64);
            this.btnTrust.TabIndex = 1;
            this.btnTrust.Text = "TRUST/KEEP";
            this.btnTrust.Click += new System.EventHandler(this.btnTrust_Click);
            // 
            // btnReportPhish
            // 
            this.btnReportPhish.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnReportPhish.Font = new System.Drawing.Font("Muro", 10F);
            this.btnReportPhish.Location = new System.Drawing.Point(178, 31);
            this.btnReportPhish.Name = "btnReportPhish";
            this.btnReportPhish.Size = new System.Drawing.Size(169, 64);
            this.btnReportPhish.TabIndex = 2;
            this.btnReportPhish.Text = "REPORT PHISHING";
            this.btnReportPhish.Click += new System.EventHandler(this.btnReportPhish_Click);
            // 
            // btnOpenLink
            // 
            this.btnOpenLink.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnOpenLink.Enabled = false;
            this.btnOpenLink.Font = new System.Drawing.Font("Muro", 10F);
            this.btnOpenLink.Location = new System.Drawing.Point(353, 31);
            this.btnOpenLink.Name = "btnOpenLink";
            this.btnOpenLink.Size = new System.Drawing.Size(169, 64);
            this.btnOpenLink.TabIndex = 3;
            this.btnOpenLink.Text = "OPEN LINK";
            this.btnOpenLink.Click += new System.EventHandler(this.btnOpenLink_Click);
            // 
            // btnOpenAtt
            // 
            this.btnOpenAtt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnOpenAtt.Enabled = false;
            this.btnOpenAtt.Font = new System.Drawing.Font("Muro", 10F);
            this.btnOpenAtt.Location = new System.Drawing.Point(528, 31);
            this.btnOpenAtt.Name = "btnOpenAtt";
            this.btnOpenAtt.Size = new System.Drawing.Size(169, 64);
            this.btnOpenAtt.TabIndex = 4;
            this.btnOpenAtt.Text = "OPEN ATTACHMENT";
            this.btnOpenAtt.Click += new System.EventHandler(this.btnOpenAtt_Click);
            // 
            // pnlResult
            // 
            this.pnlResult.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlResult.Controls.Add(this.lvSignals);
            this.pnlResult.Controls.Add(this.btnNextEmail);
            this.pnlResult.Controls.Add(this.lblResultWhy);
            this.pnlResult.Controls.Add(this.lblResultScoreDelta);
            this.pnlResult.Controls.Add(this.lblResultText);
            this.pnlResult.Controls.Add(this.lblResultTitle);
            this.pnlResult.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlResult.Location = new System.Drawing.Point(0, 490);
            this.pnlResult.Margin = new System.Windows.Forms.Padding(0);
            this.pnlResult.Name = "pnlResult";
            this.pnlResult.Padding = new System.Windows.Forms.Padding(10);
            this.pnlResult.Size = new System.Drawing.Size(720, 21);
            this.pnlResult.TabIndex = 2;
            this.pnlResult.Visible = false;
            // 
            // btnNextEmail
            // 
            this.btnNextEmail.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNextEmail.BackColor = System.Drawing.Color.RoyalBlue;
            this.btnNextEmail.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNextEmail.Font = new System.Drawing.Font("Muro", 12F);
            this.btnNextEmail.ForeColor = System.Drawing.Color.White;
            this.btnNextEmail.Location = new System.Drawing.Point(538, 48);
            this.btnNextEmail.Name = "btnNextEmail";
            this.btnNextEmail.Size = new System.Drawing.Size(170, 38);
            this.btnNextEmail.Style.BackColor = System.Drawing.Color.RoyalBlue;
            this.btnNextEmail.Style.ForeColor = System.Drawing.Color.White;
            this.btnNextEmail.TabIndex = 1;
            this.btnNextEmail.Text = "NEXT EMAIL";
            this.btnNextEmail.UseVisualStyleBackColor = false;
            this.btnNextEmail.Click += new System.EventHandler(this.btnNextEmail_Click);
            // 
            // lblResultWhy
            // 
            this.lblResultWhy.Font = new System.Drawing.Font("Agency", 11F);
            this.lblResultWhy.ForeColor = System.Drawing.Color.DimGray;
            this.lblResultWhy.Location = new System.Drawing.Point(10, 128);
            this.lblResultWhy.Margin = new System.Windows.Forms.Padding(0);
            this.lblResultWhy.Name = "lblResultWhy";
            this.lblResultWhy.Padding = new System.Windows.Forms.Padding(0, 4, 0, 0);
            this.lblResultWhy.Size = new System.Drawing.Size(720, 30);
            this.lblResultWhy.TabIndex = 4;
            this.lblResultWhy.Text = "Signals: -";
            this.lblResultWhy.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblResultScoreDelta
            // 
            this.lblResultScoreDelta.Font = new System.Drawing.Font("Muro", 11F);
            this.lblResultScoreDelta.Location = new System.Drawing.Point(10, 94);
            this.lblResultScoreDelta.Margin = new System.Windows.Forms.Padding(0);
            this.lblResultScoreDelta.Name = "lblResultScoreDelta";
            this.lblResultScoreDelta.Size = new System.Drawing.Size(720, 34);
            this.lblResultScoreDelta.TabIndex = 3;
            this.lblResultScoreDelta.Text = "+0 SCORE | +0s";
            this.lblResultScoreDelta.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblResultText
            // 
            this.lblResultText.Font = new System.Drawing.Font("Agency", 12F);
            this.lblResultText.Location = new System.Drawing.Point(10, 42);
            this.lblResultText.Margin = new System.Windows.Forms.Padding(0);
            this.lblResultText.Name = "lblResultText";
            this.lblResultText.Padding = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.lblResultText.Size = new System.Drawing.Size(720, 52);
            this.lblResultText.TabIndex = 2;
            this.lblResultText.Text = "-";
            // 
            // lblResultTitle
            // 
            this.lblResultTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblResultTitle.Font = new System.Drawing.Font("Muro", 14F);
            this.lblResultTitle.Location = new System.Drawing.Point(10, 10);
            this.lblResultTitle.Margin = new System.Windows.Forms.Padding(0);
            this.lblResultTitle.Name = "lblResultTitle";
            this.lblResultTitle.Size = new System.Drawing.Size(698, 32);
            this.lblResultTitle.TabIndex = 0;
            this.lblResultTitle.Text = "RESULT";
            this.lblResultTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lvSignals
            // 
            this.lvSignals.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lvSignals.BackColor = System.Drawing.Color.White;
            this.lvSignals.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lvSignals.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.signalCol,
            this.detailCol,
            this.wCol});
            this.lvSignals.FullRowSelect = true;
            this.lvSignals.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.lvSignals.HideSelection = false;
            this.lvSignals.Location = new System.Drawing.Point(0, 170);
            this.lvSignals.MultiSelect = false;
            this.lvSignals.Name = "lvSignals";
            this.lvSignals.Size = new System.Drawing.Size(700, 187);
            this.lvSignals.TabIndex = 5;
            this.lvSignals.UseCompatibleStateImageBehavior = false;
            this.lvSignals.View = System.Windows.Forms.View.Details;
            // 
            // signalCol
            // 
            this.signalCol.Text = "";
            this.signalCol.Width = 180;
            // 
            // detailCol
            // 
            this.detailCol.Width = 400;
            // 
            // wCol
            // 
            this.wCol.Width = 120;
            // 
            // tlpInboxFooter
            // 
            this.tlpInboxFooter.ColumnCount = 3;
            this.tlpInboxFooter.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tlpInboxFooter.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tlpInboxFooter.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tlpInboxFooter.Controls.Add(this.btnResetRun, 2, 0);
            this.tlpInboxFooter.Controls.Add(this.btnFinishRun, 1, 0);
            this.tlpInboxFooter.Controls.Add(this.btnNewEmail, 0, 0);
            this.tlpInboxFooter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpInboxFooter.Location = new System.Drawing.Point(6, 6);
            this.tlpInboxFooter.Name = "tlpInboxFooter";
            this.tlpInboxFooter.RowCount = 1;
            this.tlpInboxFooter.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpInboxFooter.Size = new System.Drawing.Size(396, 30);
            this.tlpInboxFooter.TabIndex = 2;
            // 
            // btnFinishRun
            // 
            this.btnFinishRun.BackColor = System.Drawing.Color.RoyalBlue;
            this.btnFinishRun.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnFinishRun.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFinishRun.Font = new System.Drawing.Font("Muro", 11F);
            this.btnFinishRun.ForeColor = System.Drawing.Color.White;
            this.btnFinishRun.Location = new System.Drawing.Point(134, 3);
            this.btnFinishRun.Name = "btnFinishRun";
            this.btnFinishRun.Size = new System.Drawing.Size(125, 24);
            this.btnFinishRun.Style.BackColor = System.Drawing.Color.RoyalBlue;
            this.btnFinishRun.Style.ForeColor = System.Drawing.Color.White;
            this.btnFinishRun.TabIndex = 0;
            this.btnFinishRun.Text = "FINISH RUN";
            this.btnFinishRun.UseVisualStyleBackColor = false;
            this.btnFinishRun.Click += new System.EventHandler(this.btnFinishRun_Click);
            // 
            // PhishingSimulatorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1184, 661);
            this.Controls.Add(this.tlpPhishRoot);
            this.Font = new System.Drawing.Font("Muro", 10F);
            this.MinimumSize = new System.Drawing.Size(1200, 700);
            this.Name = "PhishingSimulatorForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Style.MdiChild.IconHorizontalAlignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.Style.MdiChild.IconVerticalAlignment = System.Windows.Forms.VisualStyles.VerticalAlignment.Center;
            this.Text = "Phishing Simulator - Mondas";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.PhishingSimulatorForm_Load);
            this.tlpPhishRoot.ResumeLayout(false);
            this.pnlPhishHeader.ResumeLayout(false);
            this.pnlPhishHeader.PerformLayout();
            this.tlpPhishMain.ResumeLayout(false);
            this.gbInbox.ResumeLayout(false);
            this.tlpInboxHost.ResumeLayout(false);
            this.pnlInboxFooter.ResumeLayout(false);
            this.tlpMessageArea.ResumeLayout(false);
            this.gbMessage.ResumeLayout(false);
            this.gbMessage.PerformLayout();
            this.pnlMessageBody.ResumeLayout(false);
            this.tlpMsgMeta.ResumeLayout(false);
            this.gbActions.ResumeLayout(false);
            this.tlpActions.ResumeLayout(false);
            this.tlpActions.PerformLayout();
            this.pnlResult.ResumeLayout(false);
            this.tlpInboxFooter.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tlpPhishRoot;
        private System.Windows.Forms.Panel pnlPhishHeader;
        private System.Windows.Forms.Label lblPhishTitle;
        private System.Windows.Forms.Label lblPhishSubtitle;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.Label lblUser;
        private System.Windows.Forms.Label lblRunInfo;
        private System.Windows.Forms.TableLayoutPanel tlpPhishMain;
        private System.Windows.Forms.GroupBox gbInbox;
        private System.Windows.Forms.ListView lvInbox;
        private System.Windows.Forms.ColumnHeader colInboxStatus;
        private System.Windows.Forms.ColumnHeader colInboxSender;
        private System.Windows.Forms.ColumnHeader colInboxSubject;
        private System.Windows.Forms.ColumnHeader colInboxTime;
        private System.Windows.Forms.TableLayoutPanel tlpMessageArea;
        private System.Windows.Forms.GroupBox gbMessage;
        private System.Windows.Forms.TableLayoutPanel tlpMsgMeta;
        private System.Windows.Forms.Label lblCapFrom;
        private System.Windows.Forms.Label lblFrom;
        private System.Windows.Forms.Label lblCapTo;
        private System.Windows.Forms.Label lblTo;
        private System.Windows.Forms.Label lblCapSubject;
        private System.Windows.Forms.Label lblSubject;
        private System.Windows.Forms.Label lblCapReceived;
        private System.Windows.Forms.Label lblReceived;
        private Syncfusion.WinForms.Controls.SfButton btnViewDetails;
        private System.Windows.Forms.TableLayoutPanel tlpInboxHost;
        private System.Windows.Forms.Panel pnlInboxFooter;
        private Syncfusion.WinForms.Controls.SfButton btnNewEmail;
        private Syncfusion.WinForms.Controls.SfButton btnResetRun;
        private System.Windows.Forms.GroupBox gbActions;
        private System.Windows.Forms.TableLayoutPanel tlpActions;
        private System.Windows.Forms.Label lblActionPrompt;
        private Syncfusion.WinForms.Controls.SfButton btnTrust;
        private Syncfusion.WinForms.Controls.SfButton btnReportPhish;
        private Syncfusion.WinForms.Controls.SfButton btnOpenLink;
        private Syncfusion.WinForms.Controls.SfButton btnOpenAtt;
        private System.Windows.Forms.Panel pnlResult;
        private System.Windows.Forms.Label lblResultTitle;
        private Syncfusion.WinForms.Controls.SfButton btnNextEmail;
        private System.Windows.Forms.Label lblResultText;
        private System.Windows.Forms.Label lblResultScoreDelta;
        private System.Windows.Forms.Label lblResultWhy;
        private System.Windows.Forms.Timer tmrRun;
        private System.Windows.Forms.RichTextBox rtbMessageBody;
        private System.Windows.Forms.ListView lvSignals;
        private System.Windows.Forms.ColumnHeader signalCol;
        private System.Windows.Forms.Panel pnlMessageBody;
        private System.Windows.Forms.ColumnHeader detailCol;
        private System.Windows.Forms.ColumnHeader wCol;
        private System.Windows.Forms.TableLayoutPanel tlpInboxFooter;
        private Syncfusion.WinForms.Controls.SfButton btnFinishRun;
    }
}