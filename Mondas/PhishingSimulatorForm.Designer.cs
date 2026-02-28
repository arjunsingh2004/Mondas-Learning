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
            this.tlpPhishRoot = new System.Windows.Forms.TableLayoutPanel();
            this.pnlPhishHeader = new System.Windows.Forms.Panel();
            this.lblPhishTitle = new System.Windows.Forms.Label();
            this.lblPhishSubtitle = new System.Windows.Forms.Label();
            this.btnLogout = new System.Windows.Forms.Button();
            this.lblUser = new System.Windows.Forms.Label();
            this.lblRunInfo = new System.Windows.Forms.Label();
            this.tlpPhishMain = new System.Windows.Forms.TableLayoutPanel();
            this.gbInbox = new System.Windows.Forms.GroupBox();
            this.lvInbox = new System.Windows.Forms.ListView();
            this.colInboxStatus = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colInboxSender = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colInboxSubject = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colInboxTime = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tlpMessageArea = new System.Windows.Forms.TableLayoutPanel();
            this.gbMessage = new System.Windows.Forms.GroupBox();
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
            this.tlpInboxHost = new System.Windows.Forms.TableLayoutPanel();
            this.pnlInboxFooter = new System.Windows.Forms.Panel();
            this.btnNewEmail = new Syncfusion.WinForms.Controls.SfButton();
            this.tlpPhishRoot.SuspendLayout();
            this.pnlPhishHeader.SuspendLayout();
            this.tlpPhishMain.SuspendLayout();
            this.gbInbox.SuspendLayout();
            this.tlpMessageArea.SuspendLayout();
            this.gbMessage.SuspendLayout();
            this.tlpMsgMeta.SuspendLayout();
            this.tlpInboxHost.SuspendLayout();
            this.pnlInboxFooter.SuspendLayout();
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
            this.tlpPhishRoot.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 86F));
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
            this.tlpPhishMain.Size = new System.Drawing.Size(1160, 481);
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
            this.gbInbox.Size = new System.Drawing.Size(430, 481);
            this.gbInbox.TabIndex = 0;
            this.gbInbox.TabStop = false;
            this.gbInbox.Text = "INBOX";
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
            this.lvInbox.Size = new System.Drawing.Size(404, 389);
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
            this.colInboxSender.Width = 160;
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
            // tlpMessageArea
            // 
            this.tlpMessageArea.ColumnCount = 1;
            this.tlpMessageArea.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpMessageArea.Controls.Add(this.gbMessage, 0, 0);
            this.tlpMessageArea.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpMessageArea.Location = new System.Drawing.Point(440, 0);
            this.tlpMessageArea.Margin = new System.Windows.Forms.Padding(0);
            this.tlpMessageArea.Name = "tlpMessageArea";
            this.tlpMessageArea.RowCount = 3;
            this.tlpMessageArea.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 140F));
            this.tlpMessageArea.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpMessageArea.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 220F));
            this.tlpMessageArea.Size = new System.Drawing.Size(720, 481);
            this.tlpMessageArea.TabIndex = 1;
            // 
            // gbMessage
            // 
            this.gbMessage.Controls.Add(this.btnViewDetails);
            this.gbMessage.Controls.Add(this.tlpMsgMeta);
            this.gbMessage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbMessage.Font = new System.Drawing.Font("Muro", 11F);
            this.gbMessage.Location = new System.Drawing.Point(3, 3);
            this.gbMessage.Name = "gbMessage";
            this.gbMessage.Padding = new System.Windows.Forms.Padding(10);
            this.gbMessage.Size = new System.Drawing.Size(714, 134);
            this.gbMessage.TabIndex = 0;
            this.gbMessage.TabStop = false;
            this.gbMessage.Text = "MESSAGE";
            // 
            // tlpMsgMeta
            // 
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
            this.tlpMsgMeta.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpMsgMeta.Location = new System.Drawing.Point(10, 32);
            this.tlpMsgMeta.Margin = new System.Windows.Forms.Padding(0);
            this.tlpMsgMeta.Name = "tlpMsgMeta";
            this.tlpMsgMeta.RowCount = 4;
            this.tlpMsgMeta.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 23F));
            this.tlpMsgMeta.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 23F));
            this.tlpMsgMeta.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 23F));
            this.tlpMsgMeta.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 23F));
            this.tlpMsgMeta.Size = new System.Drawing.Size(694, 92);
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
            this.lblFrom.Size = new System.Drawing.Size(257, 23);
            this.lblFrom.TabIndex = 1;
            this.lblFrom.Text = "-";
            this.lblFrom.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblCapTo
            // 
            this.lblCapTo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblCapTo.Font = new System.Drawing.Font("Muro", 10F);
            this.lblCapTo.Location = new System.Drawing.Point(347, 0);
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
            this.lblTo.Location = new System.Drawing.Point(437, 0);
            this.lblTo.Margin = new System.Windows.Forms.Padding(0);
            this.lblTo.Name = "lblTo";
            this.lblTo.Size = new System.Drawing.Size(257, 23);
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
            this.lblSubject.Size = new System.Drawing.Size(257, 23);
            this.lblSubject.TabIndex = 5;
            this.lblSubject.Text = "-";
            this.lblSubject.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblCapReceived
            // 
            this.lblCapReceived.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblCapReceived.Font = new System.Drawing.Font("Muro", 10F);
            this.lblCapReceived.Location = new System.Drawing.Point(347, 23);
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
            this.lblReceived.Location = new System.Drawing.Point(437, 23);
            this.lblReceived.Margin = new System.Windows.Forms.Padding(0);
            this.lblReceived.Name = "lblReceived";
            this.lblReceived.Size = new System.Drawing.Size(257, 23);
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
            this.tlpInboxHost.Size = new System.Drawing.Size(410, 439);
            this.tlpInboxHost.TabIndex = 1;
            // 
            // pnlInboxFooter
            // 
            this.pnlInboxFooter.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlInboxFooter.Controls.Add(this.btnNewEmail);
            this.pnlInboxFooter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlInboxFooter.Location = new System.Drawing.Point(0, 395);
            this.pnlInboxFooter.Margin = new System.Windows.Forms.Padding(0);
            this.pnlInboxFooter.Name = "pnlInboxFooter";
            this.pnlInboxFooter.Padding = new System.Windows.Forms.Padding(6);
            this.pnlInboxFooter.Size = new System.Drawing.Size(410, 44);
            this.pnlInboxFooter.TabIndex = 1;
            // 
            // btnNewEmail
            // 
            this.btnNewEmail.BackColor = System.Drawing.Color.SeaGreen;
            this.btnNewEmail.Font = new System.Drawing.Font("Muro", 11F);
            this.btnNewEmail.ForeColor = System.Drawing.Color.White;
            this.btnNewEmail.Location = new System.Drawing.Point(6, 6);
            this.btnNewEmail.Name = "btnNewEmail";
            this.btnNewEmail.Size = new System.Drawing.Size(140, 30);
            this.btnNewEmail.Style.BackColor = System.Drawing.Color.SeaGreen;
            this.btnNewEmail.Style.ForeColor = System.Drawing.Color.White;
            this.btnNewEmail.TabIndex = 0;
            this.btnNewEmail.Text = "NEW EMAIL";
            this.btnNewEmail.UseVisualStyleBackColor = false;
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
            this.tlpMessageArea.ResumeLayout(false);
            this.gbMessage.ResumeLayout(false);
            this.tlpMsgMeta.ResumeLayout(false);
            this.tlpInboxHost.ResumeLayout(false);
            this.pnlInboxFooter.ResumeLayout(false);
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
    }
}