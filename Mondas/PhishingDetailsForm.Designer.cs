namespace Mondas
{
    partial class PhishingDetailsForm
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
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.lblHdrSub = new System.Windows.Forms.Label();
            this.lblHdrTitle = new System.Windows.Forms.Label();
            this.tlpBody = new System.Windows.Forms.TableLayoutPanel();
            this.gbEmail = new System.Windows.Forms.GroupBox();
            this.tlpEmail = new System.Windows.Forms.TableLayoutPanel();
            this.tlpEmailMeta = new System.Windows.Forms.TableLayoutPanel();
            this.lblMetaAttachmentVal = new System.Windows.Forms.Label();
            this.lblMetaAttachmentKey = new System.Windows.Forms.Label();
            this.lblMetaLinkKey = new System.Windows.Forms.Label();
            this.lblMetaReplyToVal = new System.Windows.Forms.Label();
            this.lblMetaReplyToKey = new System.Windows.Forms.Label();
            this.lblMetaReceivedVal = new System.Windows.Forms.Label();
            this.lblMetaReceivedKey = new System.Windows.Forms.Label();
            this.lblMetaSubjectVal = new System.Windows.Forms.Label();
            this.lblMetaSubjectKey = new System.Windows.Forms.Label();
            this.lblMetaToVal = new System.Windows.Forms.Label();
            this.lblMetaToKey = new System.Windows.Forms.Label();
            this.lblMetaFromKey = new System.Windows.Forms.Label();
            this.lblMetaFromVal = new System.Windows.Forms.Label();
            this.llMetaLinkVal = new System.Windows.Forms.LinkLabel();
            this.rtbEmailBody = new System.Windows.Forms.RichTextBox();
            this.gbDecision = new System.Windows.Forms.GroupBox();
            this.tlpDecision = new System.Windows.Forms.TableLayoutPanel();
            this.pnlDecisionSummary = new System.Windows.Forms.Panel();
            this.lblDecisionScoreTime = new System.Windows.Forms.Label();
            this.lblDecisionOutcome = new System.Windows.Forms.Label();
            this.lblDecisionHeadline = new System.Windows.Forms.Label();
            this.gbWhy = new System.Windows.Forms.GroupBox();
            this.tlpWhy = new System.Windows.Forms.TableLayoutPanel();
            this.txtReason = new System.Windows.Forms.TextBox();
            this.lbRules = new System.Windows.Forms.ListBox();
            this.gbSignals = new System.Windows.Forms.GroupBox();
            this.lvSignalsDetails = new System.Windows.Forms.ListView();
            this.colSignal = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colDetail = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colWeight = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.pnlFooter = new System.Windows.Forms.Panel();
            this.btnClose = new Syncfusion.WinForms.Controls.SfButton();
            this.btnCopyEmail = new Syncfusion.WinForms.Controls.SfButton();
            this.btnCopySummary = new Syncfusion.WinForms.Controls.SfButton();
            this.tlpRoot.SuspendLayout();
            this.pnlHeader.SuspendLayout();
            this.tlpBody.SuspendLayout();
            this.gbEmail.SuspendLayout();
            this.tlpEmail.SuspendLayout();
            this.tlpEmailMeta.SuspendLayout();
            this.gbDecision.SuspendLayout();
            this.tlpDecision.SuspendLayout();
            this.pnlDecisionSummary.SuspendLayout();
            this.gbWhy.SuspendLayout();
            this.tlpWhy.SuspendLayout();
            this.gbSignals.SuspendLayout();
            this.pnlFooter.SuspendLayout();
            this.SuspendLayout();
            // 
            // tlpRoot
            // 
            this.tlpRoot.ColumnCount = 1;
            this.tlpRoot.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpRoot.Controls.Add(this.pnlHeader, 0, 0);
            this.tlpRoot.Controls.Add(this.tlpBody, 0, 1);
            this.tlpRoot.Controls.Add(this.pnlFooter, 0, 2);
            this.tlpRoot.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpRoot.Location = new System.Drawing.Point(2, 2);
            this.tlpRoot.Name = "tlpRoot";
            this.tlpRoot.Padding = new System.Windows.Forms.Padding(14);
            this.tlpRoot.RowCount = 3;
            this.tlpRoot.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 56F));
            this.tlpRoot.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpRoot.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 54F));
            this.tlpRoot.Size = new System.Drawing.Size(960, 637);
            this.tlpRoot.TabIndex = 0;
            // 
            // pnlHeader
            // 
            this.pnlHeader.Controls.Add(this.lblHdrSub);
            this.pnlHeader.Controls.Add(this.lblHdrTitle);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlHeader.Location = new System.Drawing.Point(14, 14);
            this.pnlHeader.Margin = new System.Windows.Forms.Padding(0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(932, 56);
            this.pnlHeader.TabIndex = 0;
            // 
            // lblHdrSub
            // 
            this.lblHdrSub.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblHdrSub.Location = new System.Drawing.Point(0, 28);
            this.lblHdrSub.Name = "lblHdrSub";
            this.lblHdrSub.Size = new System.Drawing.Size(932, 28);
            this.lblHdrSub.TabIndex = 1;
            this.lblHdrSub.Text = "-";
            this.lblHdrSub.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblHdrTitle
            // 
            this.lblHdrTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblHdrTitle.Font = new System.Drawing.Font("Agency", 16F);
            this.lblHdrTitle.Location = new System.Drawing.Point(0, 0);
            this.lblHdrTitle.Name = "lblHdrTitle";
            this.lblHdrTitle.Size = new System.Drawing.Size(932, 28);
            this.lblHdrTitle.TabIndex = 0;
            this.lblHdrTitle.Text = "DECISION DETAILS";
            this.lblHdrTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tlpBody
            // 
            this.tlpBody.ColumnCount = 2;
            this.tlpBody.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 52F));
            this.tlpBody.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 48F));
            this.tlpBody.Controls.Add(this.gbEmail, 0, 0);
            this.tlpBody.Controls.Add(this.gbDecision, 1, 0);
            this.tlpBody.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpBody.Location = new System.Drawing.Point(14, 80);
            this.tlpBody.Margin = new System.Windows.Forms.Padding(0, 10, 0, 10);
            this.tlpBody.Name = "tlpBody";
            this.tlpBody.RowCount = 1;
            this.tlpBody.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpBody.Size = new System.Drawing.Size(932, 479);
            this.tlpBody.TabIndex = 1;
            // 
            // gbEmail
            // 
            this.gbEmail.Controls.Add(this.tlpEmail);
            this.gbEmail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbEmail.Font = new System.Drawing.Font("Agency", 11F);
            this.gbEmail.Location = new System.Drawing.Point(3, 3);
            this.gbEmail.Name = "gbEmail";
            this.gbEmail.Padding = new System.Windows.Forms.Padding(10);
            this.gbEmail.Size = new System.Drawing.Size(478, 473);
            this.gbEmail.TabIndex = 0;
            this.gbEmail.TabStop = false;
            this.gbEmail.Text = "EMAIL SNAPSHOT";
            // 
            // tlpEmail
            // 
            this.tlpEmail.ColumnCount = 1;
            this.tlpEmail.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpEmail.Controls.Add(this.tlpEmailMeta, 0, 0);
            this.tlpEmail.Controls.Add(this.rtbEmailBody, 0, 1);
            this.tlpEmail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpEmail.Location = new System.Drawing.Point(10, 33);
            this.tlpEmail.Name = "tlpEmail";
            this.tlpEmail.RowCount = 2;
            this.tlpEmail.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 172F));
            this.tlpEmail.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpEmail.Size = new System.Drawing.Size(458, 430);
            this.tlpEmail.TabIndex = 0;
            // 
            // tlpEmailMeta
            // 
            this.tlpEmailMeta.ColumnCount = 2;
            this.tlpEmailMeta.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 110F));
            this.tlpEmailMeta.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpEmailMeta.Controls.Add(this.lblMetaAttachmentVal, 1, 6);
            this.tlpEmailMeta.Controls.Add(this.lblMetaAttachmentKey, 0, 6);
            this.tlpEmailMeta.Controls.Add(this.lblMetaLinkKey, 0, 5);
            this.tlpEmailMeta.Controls.Add(this.lblMetaReplyToVal, 1, 4);
            this.tlpEmailMeta.Controls.Add(this.lblMetaReplyToKey, 0, 4);
            this.tlpEmailMeta.Controls.Add(this.lblMetaReceivedVal, 1, 3);
            this.tlpEmailMeta.Controls.Add(this.lblMetaReceivedKey, 0, 3);
            this.tlpEmailMeta.Controls.Add(this.lblMetaSubjectVal, 1, 2);
            this.tlpEmailMeta.Controls.Add(this.lblMetaSubjectKey, 0, 2);
            this.tlpEmailMeta.Controls.Add(this.lblMetaToVal, 1, 1);
            this.tlpEmailMeta.Controls.Add(this.lblMetaToKey, 0, 1);
            this.tlpEmailMeta.Controls.Add(this.lblMetaFromKey, 0, 0);
            this.tlpEmailMeta.Controls.Add(this.lblMetaFromVal, 1, 0);
            this.tlpEmailMeta.Controls.Add(this.llMetaLinkVal, 1, 5);
            this.tlpEmailMeta.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpEmailMeta.Location = new System.Drawing.Point(3, 3);
            this.tlpEmailMeta.Name = "tlpEmailMeta";
            this.tlpEmailMeta.RowCount = 7;
            this.tlpEmailMeta.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 24F));
            this.tlpEmailMeta.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 24F));
            this.tlpEmailMeta.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 24F));
            this.tlpEmailMeta.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 24F));
            this.tlpEmailMeta.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 24F));
            this.tlpEmailMeta.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 24F));
            this.tlpEmailMeta.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 24F));
            this.tlpEmailMeta.Size = new System.Drawing.Size(452, 166);
            this.tlpEmailMeta.TabIndex = 0;
            // 
            // lblMetaAttachmentVal
            // 
            this.lblMetaAttachmentVal.AutoSize = true;
            this.lblMetaAttachmentVal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblMetaAttachmentVal.Font = new System.Drawing.Font("Agency", 10F);
            this.lblMetaAttachmentVal.Location = new System.Drawing.Point(113, 144);
            this.lblMetaAttachmentVal.Name = "lblMetaAttachmentVal";
            this.lblMetaAttachmentVal.Size = new System.Drawing.Size(336, 24);
            this.lblMetaAttachmentVal.TabIndex = 13;
            this.lblMetaAttachmentVal.Text = "-";
            this.lblMetaAttachmentVal.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblMetaAttachmentKey
            // 
            this.lblMetaAttachmentKey.AutoSize = true;
            this.lblMetaAttachmentKey.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblMetaAttachmentKey.Font = new System.Drawing.Font("Agency", 10F);
            this.lblMetaAttachmentKey.Location = new System.Drawing.Point(3, 144);
            this.lblMetaAttachmentKey.Name = "lblMetaAttachmentKey";
            this.lblMetaAttachmentKey.Size = new System.Drawing.Size(104, 24);
            this.lblMetaAttachmentKey.TabIndex = 12;
            this.lblMetaAttachmentKey.Text = "ATTACH";
            this.lblMetaAttachmentKey.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblMetaLinkKey
            // 
            this.lblMetaLinkKey.AutoSize = true;
            this.lblMetaLinkKey.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblMetaLinkKey.Font = new System.Drawing.Font("Agency", 10F);
            this.lblMetaLinkKey.Location = new System.Drawing.Point(3, 120);
            this.lblMetaLinkKey.Name = "lblMetaLinkKey";
            this.lblMetaLinkKey.Size = new System.Drawing.Size(104, 24);
            this.lblMetaLinkKey.TabIndex = 10;
            this.lblMetaLinkKey.Text = "LINK";
            this.lblMetaLinkKey.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblMetaReplyToVal
            // 
            this.lblMetaReplyToVal.AutoSize = true;
            this.lblMetaReplyToVal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblMetaReplyToVal.Font = new System.Drawing.Font("Agency", 10F);
            this.lblMetaReplyToVal.Location = new System.Drawing.Point(113, 96);
            this.lblMetaReplyToVal.Name = "lblMetaReplyToVal";
            this.lblMetaReplyToVal.Size = new System.Drawing.Size(336, 24);
            this.lblMetaReplyToVal.TabIndex = 9;
            this.lblMetaReplyToVal.Text = "-";
            this.lblMetaReplyToVal.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblMetaReplyToKey
            // 
            this.lblMetaReplyToKey.AutoSize = true;
            this.lblMetaReplyToKey.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblMetaReplyToKey.Font = new System.Drawing.Font("Agency", 10F);
            this.lblMetaReplyToKey.Location = new System.Drawing.Point(3, 96);
            this.lblMetaReplyToKey.Name = "lblMetaReplyToKey";
            this.lblMetaReplyToKey.Size = new System.Drawing.Size(104, 24);
            this.lblMetaReplyToKey.TabIndex = 8;
            this.lblMetaReplyToKey.Text = "REPLY TO";
            this.lblMetaReplyToKey.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblMetaReceivedVal
            // 
            this.lblMetaReceivedVal.AutoSize = true;
            this.lblMetaReceivedVal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblMetaReceivedVal.Font = new System.Drawing.Font("Agency", 10F);
            this.lblMetaReceivedVal.Location = new System.Drawing.Point(113, 72);
            this.lblMetaReceivedVal.Name = "lblMetaReceivedVal";
            this.lblMetaReceivedVal.Size = new System.Drawing.Size(336, 24);
            this.lblMetaReceivedVal.TabIndex = 7;
            this.lblMetaReceivedVal.Text = "-";
            this.lblMetaReceivedVal.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblMetaReceivedKey
            // 
            this.lblMetaReceivedKey.AutoSize = true;
            this.lblMetaReceivedKey.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblMetaReceivedKey.Font = new System.Drawing.Font("Agency", 10F);
            this.lblMetaReceivedKey.Location = new System.Drawing.Point(3, 72);
            this.lblMetaReceivedKey.Name = "lblMetaReceivedKey";
            this.lblMetaReceivedKey.Size = new System.Drawing.Size(104, 24);
            this.lblMetaReceivedKey.TabIndex = 6;
            this.lblMetaReceivedKey.Text = "RECEIVED";
            this.lblMetaReceivedKey.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblMetaSubjectVal
            // 
            this.lblMetaSubjectVal.AutoSize = true;
            this.lblMetaSubjectVal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblMetaSubjectVal.Font = new System.Drawing.Font("Agency", 10F);
            this.lblMetaSubjectVal.Location = new System.Drawing.Point(113, 48);
            this.lblMetaSubjectVal.Name = "lblMetaSubjectVal";
            this.lblMetaSubjectVal.Size = new System.Drawing.Size(336, 24);
            this.lblMetaSubjectVal.TabIndex = 5;
            this.lblMetaSubjectVal.Text = "-";
            this.lblMetaSubjectVal.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblMetaSubjectKey
            // 
            this.lblMetaSubjectKey.AutoSize = true;
            this.lblMetaSubjectKey.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblMetaSubjectKey.Font = new System.Drawing.Font("Agency", 10F);
            this.lblMetaSubjectKey.Location = new System.Drawing.Point(3, 48);
            this.lblMetaSubjectKey.Name = "lblMetaSubjectKey";
            this.lblMetaSubjectKey.Size = new System.Drawing.Size(104, 24);
            this.lblMetaSubjectKey.TabIndex = 4;
            this.lblMetaSubjectKey.Text = "SUBJECT";
            this.lblMetaSubjectKey.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblMetaToVal
            // 
            this.lblMetaToVal.AutoSize = true;
            this.lblMetaToVal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblMetaToVal.Font = new System.Drawing.Font("Agency", 10F);
            this.lblMetaToVal.Location = new System.Drawing.Point(113, 24);
            this.lblMetaToVal.Name = "lblMetaToVal";
            this.lblMetaToVal.Size = new System.Drawing.Size(336, 24);
            this.lblMetaToVal.TabIndex = 3;
            this.lblMetaToVal.Text = "-";
            this.lblMetaToVal.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblMetaToKey
            // 
            this.lblMetaToKey.AutoSize = true;
            this.lblMetaToKey.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblMetaToKey.Font = new System.Drawing.Font("Agency", 10F);
            this.lblMetaToKey.Location = new System.Drawing.Point(3, 24);
            this.lblMetaToKey.Name = "lblMetaToKey";
            this.lblMetaToKey.Size = new System.Drawing.Size(104, 24);
            this.lblMetaToKey.TabIndex = 2;
            this.lblMetaToKey.Text = "TO";
            this.lblMetaToKey.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblMetaFromKey
            // 
            this.lblMetaFromKey.AutoSize = true;
            this.lblMetaFromKey.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblMetaFromKey.Font = new System.Drawing.Font("Agency", 10F);
            this.lblMetaFromKey.Location = new System.Drawing.Point(3, 0);
            this.lblMetaFromKey.Name = "lblMetaFromKey";
            this.lblMetaFromKey.Size = new System.Drawing.Size(104, 24);
            this.lblMetaFromKey.TabIndex = 0;
            this.lblMetaFromKey.Text = "FROM";
            this.lblMetaFromKey.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblMetaFromVal
            // 
            this.lblMetaFromVal.AutoSize = true;
            this.lblMetaFromVal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblMetaFromVal.Font = new System.Drawing.Font("Agency", 10F);
            this.lblMetaFromVal.Location = new System.Drawing.Point(113, 0);
            this.lblMetaFromVal.Name = "lblMetaFromVal";
            this.lblMetaFromVal.Size = new System.Drawing.Size(336, 24);
            this.lblMetaFromVal.TabIndex = 1;
            this.lblMetaFromVal.Text = "-";
            this.lblMetaFromVal.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // llMetaLinkVal
            // 
            this.llMetaLinkVal.AutoSize = true;
            this.llMetaLinkVal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.llMetaLinkVal.Font = new System.Drawing.Font("Agency", 10F);
            this.llMetaLinkVal.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
            this.llMetaLinkVal.Location = new System.Drawing.Point(113, 120);
            this.llMetaLinkVal.Name = "llMetaLinkVal";
            this.llMetaLinkVal.Size = new System.Drawing.Size(336, 24);
            this.llMetaLinkVal.TabIndex = 14;
            this.llMetaLinkVal.TabStop = true;
            this.llMetaLinkVal.Text = "-";
            this.llMetaLinkVal.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.llMetaLinkVal.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llMetaLinkVal_LinkClicked);
            // 
            // rtbEmailBody
            // 
            this.rtbEmailBody.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.rtbEmailBody.DetectUrls = false;
            this.rtbEmailBody.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtbEmailBody.Font = new System.Drawing.Font("Agency", 10F);
            this.rtbEmailBody.Location = new System.Drawing.Point(3, 175);
            this.rtbEmailBody.Name = "rtbEmailBody";
            this.rtbEmailBody.ReadOnly = true;
            this.rtbEmailBody.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.rtbEmailBody.Size = new System.Drawing.Size(452, 252);
            this.rtbEmailBody.TabIndex = 1;
            this.rtbEmailBody.Text = "";
            // 
            // gbDecision
            // 
            this.gbDecision.Controls.Add(this.tlpDecision);
            this.gbDecision.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbDecision.Font = new System.Drawing.Font("Agency", 11F);
            this.gbDecision.Location = new System.Drawing.Point(484, 0);
            this.gbDecision.Margin = new System.Windows.Forms.Padding(0);
            this.gbDecision.Name = "gbDecision";
            this.gbDecision.Padding = new System.Windows.Forms.Padding(10);
            this.gbDecision.Size = new System.Drawing.Size(448, 479);
            this.gbDecision.TabIndex = 1;
            this.gbDecision.TabStop = false;
            this.gbDecision.Text = "DECISION + ANALYSIS";
            // 
            // tlpDecision
            // 
            this.tlpDecision.ColumnCount = 1;
            this.tlpDecision.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpDecision.Controls.Add(this.pnlDecisionSummary, 0, 0);
            this.tlpDecision.Controls.Add(this.gbWhy, 0, 1);
            this.tlpDecision.Controls.Add(this.gbSignals, 0, 2);
            this.tlpDecision.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpDecision.Location = new System.Drawing.Point(10, 33);
            this.tlpDecision.Name = "tlpDecision";
            this.tlpDecision.RowCount = 3;
            this.tlpDecision.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.tlpDecision.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this.tlpDecision.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpDecision.Size = new System.Drawing.Size(428, 436);
            this.tlpDecision.TabIndex = 0;
            // 
            // pnlDecisionSummary
            // 
            this.pnlDecisionSummary.Controls.Add(this.lblDecisionScoreTime);
            this.pnlDecisionSummary.Controls.Add(this.lblDecisionOutcome);
            this.pnlDecisionSummary.Controls.Add(this.lblDecisionHeadline);
            this.pnlDecisionSummary.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlDecisionSummary.Location = new System.Drawing.Point(0, 0);
            this.pnlDecisionSummary.Margin = new System.Windows.Forms.Padding(0);
            this.pnlDecisionSummary.Name = "pnlDecisionSummary";
            this.pnlDecisionSummary.Padding = new System.Windows.Forms.Padding(6);
            this.pnlDecisionSummary.Size = new System.Drawing.Size(428, 80);
            this.pnlDecisionSummary.TabIndex = 0;
            // 
            // lblDecisionScoreTime
            // 
            this.lblDecisionScoreTime.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblDecisionScoreTime.Font = new System.Drawing.Font("Agency", 10F);
            this.lblDecisionScoreTime.Location = new System.Drawing.Point(6, 54);
            this.lblDecisionScoreTime.Name = "lblDecisionScoreTime";
            this.lblDecisionScoreTime.Size = new System.Drawing.Size(416, 20);
            this.lblDecisionScoreTime.TabIndex = 2;
            this.lblDecisionScoreTime.Text = "-";
            this.lblDecisionScoreTime.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblDecisionOutcome
            // 
            this.lblDecisionOutcome.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblDecisionOutcome.Font = new System.Drawing.Font("Agency", 10F);
            this.lblDecisionOutcome.Location = new System.Drawing.Point(6, 34);
            this.lblDecisionOutcome.Name = "lblDecisionOutcome";
            this.lblDecisionOutcome.Size = new System.Drawing.Size(416, 20);
            this.lblDecisionOutcome.TabIndex = 1;
            this.lblDecisionOutcome.Text = "-";
            this.lblDecisionOutcome.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblDecisionHeadline
            // 
            this.lblDecisionHeadline.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblDecisionHeadline.Font = new System.Drawing.Font("Agency", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDecisionHeadline.Location = new System.Drawing.Point(6, 6);
            this.lblDecisionHeadline.Name = "lblDecisionHeadline";
            this.lblDecisionHeadline.Size = new System.Drawing.Size(416, 28);
            this.lblDecisionHeadline.TabIndex = 0;
            this.lblDecisionHeadline.Text = "-";
            this.lblDecisionHeadline.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // gbWhy
            // 
            this.gbWhy.Controls.Add(this.tlpWhy);
            this.gbWhy.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbWhy.Font = new System.Drawing.Font("Agency", 10F);
            this.gbWhy.Location = new System.Drawing.Point(0, 85);
            this.gbWhy.Margin = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.gbWhy.Name = "gbWhy";
            this.gbWhy.Padding = new System.Windows.Forms.Padding(10);
            this.gbWhy.Size = new System.Drawing.Size(428, 145);
            this.gbWhy.TabIndex = 0;
            this.gbWhy.TabStop = false;
            this.gbWhy.Text = "WHY (ENGINE)";
            // 
            // tlpWhy
            // 
            this.tlpWhy.ColumnCount = 1;
            this.tlpWhy.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpWhy.Controls.Add(this.txtReason, 0, 0);
            this.tlpWhy.Controls.Add(this.lbRules, 0, 1);
            this.tlpWhy.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpWhy.Location = new System.Drawing.Point(10, 31);
            this.tlpWhy.Name = "tlpWhy";
            this.tlpWhy.RowCount = 2;
            this.tlpWhy.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 55F));
            this.tlpWhy.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 45F));
            this.tlpWhy.Size = new System.Drawing.Size(408, 104);
            this.tlpWhy.TabIndex = 0;
            // 
            // txtReason
            // 
            this.txtReason.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtReason.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtReason.Location = new System.Drawing.Point(3, 3);
            this.txtReason.Multiline = true;
            this.txtReason.Name = "txtReason";
            this.txtReason.ReadOnly = true;
            this.txtReason.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtReason.Size = new System.Drawing.Size(402, 51);
            this.txtReason.TabIndex = 0;
            // 
            // lbRules
            // 
            this.lbRules.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbRules.FormattingEnabled = true;
            this.lbRules.IntegralHeight = false;
            this.lbRules.ItemHeight = 15;
            this.lbRules.Location = new System.Drawing.Point(3, 60);
            this.lbRules.Name = "lbRules";
            this.lbRules.Size = new System.Drawing.Size(402, 41);
            this.lbRules.TabIndex = 1;
            // 
            // gbSignals
            // 
            this.gbSignals.Controls.Add(this.lvSignalsDetails);
            this.gbSignals.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbSignals.Font = new System.Drawing.Font("Agency", 10F);
            this.gbSignals.Location = new System.Drawing.Point(0, 230);
            this.gbSignals.Margin = new System.Windows.Forms.Padding(0);
            this.gbSignals.Name = "gbSignals";
            this.gbSignals.Padding = new System.Windows.Forms.Padding(10);
            this.gbSignals.Size = new System.Drawing.Size(428, 206);
            this.gbSignals.TabIndex = 1;
            this.gbSignals.TabStop = false;
            this.gbSignals.Text = "SIGNALS";
            // 
            // lvSignalsDetails
            // 
            this.lvSignalsDetails.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colSignal,
            this.colDetail,
            this.colWeight});
            this.lvSignalsDetails.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvSignalsDetails.GridLines = true;
            this.lvSignalsDetails.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lvSignalsDetails.HideSelection = false;
            this.lvSignalsDetails.Location = new System.Drawing.Point(10, 31);
            this.lvSignalsDetails.Name = "lvSignalsDetails";
            this.lvSignalsDetails.Size = new System.Drawing.Size(408, 165);
            this.lvSignalsDetails.TabIndex = 0;
            this.lvSignalsDetails.UseCompatibleStateImageBehavior = false;
            this.lvSignalsDetails.View = System.Windows.Forms.View.Details;
            // 
            // colSignal
            // 
            this.colSignal.Text = "SIGNAL";
            this.colSignal.Width = 220;
            // 
            // colDetail
            // 
            this.colDetail.Text = "DETAIL";
            this.colDetail.Width = 400;
            // 
            // colWeight
            // 
            this.colWeight.Text = "Weight";
            this.colWeight.Width = 140;
            // 
            // pnlFooter
            // 
            this.pnlFooter.Controls.Add(this.btnClose);
            this.pnlFooter.Controls.Add(this.btnCopyEmail);
            this.pnlFooter.Controls.Add(this.btnCopySummary);
            this.pnlFooter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlFooter.Location = new System.Drawing.Point(14, 569);
            this.pnlFooter.Margin = new System.Windows.Forms.Padding(0);
            this.pnlFooter.Name = "pnlFooter";
            this.pnlFooter.Size = new System.Drawing.Size(932, 54);
            this.pnlFooter.TabIndex = 2;
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.BackColor = System.Drawing.Color.Crimson;
            this.btnClose.Font = new System.Drawing.Font("Muro", 12F);
            this.btnClose.ForeColor = System.Drawing.Color.White;
            this.btnClose.Location = new System.Drawing.Point(787, 3);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(142, 48);
            this.btnClose.Style.BackColor = System.Drawing.Color.Crimson;
            this.btnClose.Style.ForeColor = System.Drawing.Color.White;
            this.btnClose.TabIndex = 2;
            this.btnClose.Text = "CLOSE";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnCopyEmail
            // 
            this.btnCopyEmail.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCopyEmail.BackColor = System.Drawing.Color.RoyalBlue;
            this.btnCopyEmail.Font = new System.Drawing.Font("Muro", 12F);
            this.btnCopyEmail.ForeColor = System.Drawing.Color.White;
            this.btnCopyEmail.Location = new System.Drawing.Point(623, 3);
            this.btnCopyEmail.Name = "btnCopyEmail";
            this.btnCopyEmail.Size = new System.Drawing.Size(140, 48);
            this.btnCopyEmail.Style.BackColor = System.Drawing.Color.RoyalBlue;
            this.btnCopyEmail.Style.ForeColor = System.Drawing.Color.White;
            this.btnCopyEmail.TabIndex = 1;
            this.btnCopyEmail.Text = "COPY EMAIL";
            this.btnCopyEmail.UseVisualStyleBackColor = false;
            this.btnCopyEmail.Click += new System.EventHandler(this.btnCopyEmail_Click);
            // 
            // btnCopySummary
            // 
            this.btnCopySummary.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCopySummary.BackColor = System.Drawing.Color.RoyalBlue;
            this.btnCopySummary.Font = new System.Drawing.Font("Muro", 12F);
            this.btnCopySummary.ForeColor = System.Drawing.Color.White;
            this.btnCopySummary.Location = new System.Drawing.Point(421, 3);
            this.btnCopySummary.Name = "btnCopySummary";
            this.btnCopySummary.Size = new System.Drawing.Size(178, 48);
            this.btnCopySummary.Style.BackColor = System.Drawing.Color.RoyalBlue;
            this.btnCopySummary.Style.ForeColor = System.Drawing.Color.White;
            this.btnCopySummary.TabIndex = 0;
            this.btnCopySummary.Text = "COPY SUMMARY";
            this.btnCopySummary.UseVisualStyleBackColor = false;
            this.btnCopySummary.Click += new System.EventHandler(this.btnCopySummary_Click);
            // 
            // PhishingDetailsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(964, 641);
            this.Controls.Add(this.tlpRoot);
            this.Font = new System.Drawing.Font("Agency", 10F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(980, 680);
            this.Name = "PhishingDetailsForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Style.MdiChild.IconHorizontalAlignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.Style.MdiChild.IconVerticalAlignment = System.Windows.Forms.VisualStyles.VerticalAlignment.Center;
            this.Text = "Phishing Details";
            this.Load += new System.EventHandler(this.PhishingDetailsForm_Load);
            this.tlpRoot.ResumeLayout(false);
            this.pnlHeader.ResumeLayout(false);
            this.tlpBody.ResumeLayout(false);
            this.gbEmail.ResumeLayout(false);
            this.tlpEmail.ResumeLayout(false);
            this.tlpEmailMeta.ResumeLayout(false);
            this.tlpEmailMeta.PerformLayout();
            this.gbDecision.ResumeLayout(false);
            this.tlpDecision.ResumeLayout(false);
            this.pnlDecisionSummary.ResumeLayout(false);
            this.gbWhy.ResumeLayout(false);
            this.tlpWhy.ResumeLayout(false);
            this.tlpWhy.PerformLayout();
            this.gbSignals.ResumeLayout(false);
            this.pnlFooter.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tlpRoot;
        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblHdrTitle;
        private System.Windows.Forms.Label lblHdrSub;
        private System.Windows.Forms.TableLayoutPanel tlpBody;
        private System.Windows.Forms.GroupBox gbEmail;
        private System.Windows.Forms.TableLayoutPanel tlpEmail;
        private System.Windows.Forms.TableLayoutPanel tlpEmailMeta;
        private System.Windows.Forms.Label lblMetaFromKey;
        private System.Windows.Forms.Label lblMetaFromVal;
        private System.Windows.Forms.Label lblMetaAttachmentVal;
        private System.Windows.Forms.Label lblMetaAttachmentKey;
        private System.Windows.Forms.Label lblMetaLinkKey;
        private System.Windows.Forms.Label lblMetaReplyToVal;
        private System.Windows.Forms.Label lblMetaReplyToKey;
        private System.Windows.Forms.Label lblMetaReceivedVal;
        private System.Windows.Forms.Label lblMetaReceivedKey;
        private System.Windows.Forms.Label lblMetaSubjectVal;
        private System.Windows.Forms.Label lblMetaSubjectKey;
        private System.Windows.Forms.Label lblMetaToVal;
        private System.Windows.Forms.Label lblMetaToKey;
        private System.Windows.Forms.LinkLabel llMetaLinkVal;
        private System.Windows.Forms.RichTextBox rtbEmailBody;
        private System.Windows.Forms.GroupBox gbDecision;
        private System.Windows.Forms.TableLayoutPanel tlpDecision;
        private System.Windows.Forms.Panel pnlDecisionSummary;
        private System.Windows.Forms.Label lblDecisionHeadline;
        private System.Windows.Forms.Label lblDecisionOutcome;
        private System.Windows.Forms.Label lblDecisionScoreTime;
        private System.Windows.Forms.GroupBox gbWhy;
        private System.Windows.Forms.TableLayoutPanel tlpWhy;
        private System.Windows.Forms.TextBox txtReason;
        private System.Windows.Forms.ListBox lbRules;
        private System.Windows.Forms.GroupBox gbSignals;
        private System.Windows.Forms.ListView lvSignalsDetails;
        private System.Windows.Forms.ColumnHeader colSignal;
        private System.Windows.Forms.ColumnHeader colDetail;
        private System.Windows.Forms.ColumnHeader colWeight;
        private System.Windows.Forms.Panel pnlFooter;
        private Syncfusion.WinForms.Controls.SfButton btnClose;
        private Syncfusion.WinForms.Controls.SfButton btnCopyEmail;
        private Syncfusion.WinForms.Controls.SfButton btnCopySummary;
    }
}