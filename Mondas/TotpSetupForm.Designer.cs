namespace Mondas
{
    partial class TotpSetupForm
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
            this.pnlSidebar = new System.Windows.Forms.Panel();
            this.tlpSidebar = new System.Windows.Forms.TableLayoutPanel();
            this.lblMondas = new System.Windows.Forms.Label();
            this.lblHeroTitle = new System.Windows.Forms.Label();
            this.lblHeroSubtitle = new System.Windows.Forms.Label();
            this.lblHeroFooter = new System.Windows.Forms.Label();
            this.pnlPage = new System.Windows.Forms.Panel();
            this.tlpPageCenter = new System.Windows.Forms.TableLayoutPanel();
            this.pnlCard = new System.Windows.Forms.Panel();
            this.tlpCard = new System.Windows.Forms.TableLayoutPanel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblSubtitle = new System.Windows.Forms.Label();
            this.lblStepScan = new System.Windows.Forms.Label();
            this.pnlQr = new System.Windows.Forms.Panel();
            this.picQr = new System.Windows.Forms.PictureBox();
            this.lblManualKey = new System.Windows.Forms.Label();
            this.pnlSecret = new System.Windows.Forms.Panel();
            this.txtSecret = new System.Windows.Forms.TextBox();
            this.lblStepCode = new System.Windows.Forms.Label();
            this.tlpVerifyRow = new System.Windows.Forms.TableLayoutPanel();
            this.pnlCode = new System.Windows.Forms.Panel();
            this.txtCode = new System.Windows.Forms.TextBox();
            this.tlpFooter = new System.Windows.Forms.TableLayoutPanel();
            this.pnlFooterLeft = new System.Windows.Forms.Panel();
            this.lblStatus = new System.Windows.Forms.Label();
            this.pnlFooterRight = new System.Windows.Forms.Panel();
            this.btnVerify = new System.Windows.Forms.Button();
            this.btnContinue = new System.Windows.Forms.Button();
            this.tlpRoot.SuspendLayout();
            this.pnlSidebar.SuspendLayout();
            this.tlpSidebar.SuspendLayout();
            this.pnlPage.SuspendLayout();
            this.tlpPageCenter.SuspendLayout();
            this.pnlCard.SuspendLayout();
            this.tlpCard.SuspendLayout();
            this.pnlQr.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picQr)).BeginInit();
            this.pnlSecret.SuspendLayout();
            this.tlpVerifyRow.SuspendLayout();
            this.pnlCode.SuspendLayout();
            this.tlpFooter.SuspendLayout();
            this.pnlFooterLeft.SuspendLayout();
            this.pnlFooterRight.SuspendLayout();
            this.SuspendLayout();
            // 
            // tlpRoot
            // 
            this.tlpRoot.ColumnCount = 2;
            this.tlpRoot.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 45F));
            this.tlpRoot.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 55F));
            this.tlpRoot.Controls.Add(this.pnlSidebar, 0, 0);
            this.tlpRoot.Controls.Add(this.pnlPage, 1, 0);
            this.tlpRoot.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpRoot.Location = new System.Drawing.Point(0, 0);
            this.tlpRoot.Margin = new System.Windows.Forms.Padding(0);
            this.tlpRoot.Name = "tlpRoot";
            this.tlpRoot.RowCount = 1;
            this.tlpRoot.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpRoot.Size = new System.Drawing.Size(984, 611);
            this.tlpRoot.TabIndex = 0;
            // 
            // pnlSidebar
            // 
            this.pnlSidebar.BackColor = System.Drawing.Color.RoyalBlue;
            this.pnlSidebar.Controls.Add(this.tlpSidebar);
            this.pnlSidebar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlSidebar.Location = new System.Drawing.Point(0, 0);
            this.pnlSidebar.Margin = new System.Windows.Forms.Padding(0);
            this.pnlSidebar.Name = "pnlSidebar";
            this.pnlSidebar.Size = new System.Drawing.Size(442, 611);
            this.pnlSidebar.TabIndex = 0;
            // 
            // tlpSidebar
            // 
            this.tlpSidebar.ColumnCount = 1;
            this.tlpSidebar.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpSidebar.Controls.Add(this.lblMondas, 0, 1);
            this.tlpSidebar.Controls.Add(this.lblHeroTitle, 0, 2);
            this.tlpSidebar.Controls.Add(this.lblHeroSubtitle, 0, 3);
            this.tlpSidebar.Controls.Add(this.lblHeroFooter, 0, 5);
            this.tlpSidebar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpSidebar.Location = new System.Drawing.Point(0, 0);
            this.tlpSidebar.Margin = new System.Windows.Forms.Padding(0);
            this.tlpSidebar.Name = "tlpSidebar";
            this.tlpSidebar.RowCount = 6;
            this.tlpSidebar.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 18F));
            this.tlpSidebar.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpSidebar.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tlpSidebar.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 64F));
            this.tlpSidebar.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tlpSidebar.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 18F));
            this.tlpSidebar.Size = new System.Drawing.Size(442, 611);
            this.tlpSidebar.TabIndex = 0;
            // 
            // lblMondas
            // 
            this.lblMondas.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblMondas.AutoSize = true;
            this.lblMondas.Font = new System.Drawing.Font("Muro", 48F);
            this.lblMondas.ForeColor = System.Drawing.Color.White;
            this.lblMondas.Location = new System.Drawing.Point(52, 53);
            this.lblMondas.Margin = new System.Windows.Forms.Padding(0, 0, 0, 18);
            this.lblMondas.Name = "lblMondas";
            this.lblMondas.Size = new System.Drawing.Size(338, 96);
            this.lblMondas.TabIndex = 0;
            this.lblMondas.Text = "MONDAS";
            this.lblMondas.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblHeroTitle
            // 
            this.lblHeroTitle.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblHeroTitle.AutoSize = true;
            this.lblHeroTitle.Font = new System.Drawing.Font("Agency", 20F);
            this.lblHeroTitle.ForeColor = System.Drawing.Color.White;
            this.lblHeroTitle.Location = new System.Drawing.Point(33, 197);
            this.lblHeroTitle.Margin = new System.Windows.Forms.Padding(0, 0, 0, 10);
            this.lblHeroTitle.Name = "lblHeroTitle";
            this.lblHeroTitle.Size = new System.Drawing.Size(376, 29);
            this.lblHeroTitle.TabIndex = 1;
            this.lblHeroTitle.Text = "TWO-FACTOR AUTH";
            this.lblHeroTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblHeroSubtitle
            // 
            this.lblHeroSubtitle.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblHeroSubtitle.AutoSize = true;
            this.lblHeroSubtitle.Font = new System.Drawing.Font("Agency", 11F);
            this.lblHeroSubtitle.ForeColor = System.Drawing.Color.White;
            this.lblHeroSubtitle.Location = new System.Drawing.Point(48, 267);
            this.lblHeroSubtitle.Margin = new System.Windows.Forms.Padding(40, 0, 40, 0);
            this.lblHeroSubtitle.Name = "lblHeroSubtitle";
            this.lblHeroSubtitle.Size = new System.Drawing.Size(346, 34);
            this.lblHeroSubtitle.TabIndex = 2;
            this.lblHeroSubtitle.Text = "Scan the QR code to connect an authenticator app.";
            this.lblHeroSubtitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblHeroFooter
            // 
            this.lblHeroFooter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblHeroFooter.AutoSize = true;
            this.lblHeroFooter.Font = new System.Drawing.Font("Agency FB", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHeroFooter.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.lblHeroFooter.Location = new System.Drawing.Point(10, 581);
            this.lblHeroFooter.Margin = new System.Windows.Forms.Padding(10, 0, 0, 10);
            this.lblHeroFooter.Name = "lblHeroFooter";
            this.lblHeroFooter.Size = new System.Drawing.Size(120, 20);
            this.lblHeroFooter.TabIndex = 5;
            this.lblHeroFooter.Text = "© 2026 Mondas Learning";
            this.lblHeroFooter.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // pnlPage
            // 
            this.pnlPage.Controls.Add(this.tlpPageCenter);
            this.pnlPage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlPage.Location = new System.Drawing.Point(442, 0);
            this.pnlPage.Margin = new System.Windows.Forms.Padding(0);
            this.pnlPage.Name = "pnlPage";
            this.pnlPage.Padding = new System.Windows.Forms.Padding(12);
            this.pnlPage.Size = new System.Drawing.Size(542, 611);
            this.pnlPage.TabIndex = 1;
            // 
            // tlpPageCenter
            // 
            this.tlpPageCenter.ColumnCount = 3;
            this.tlpPageCenter.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpPageCenter.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tlpPageCenter.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpPageCenter.Controls.Add(this.pnlCard, 1, 1);
            this.tlpPageCenter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpPageCenter.Location = new System.Drawing.Point(12, 12);
            this.tlpPageCenter.Margin = new System.Windows.Forms.Padding(0);
            this.tlpPageCenter.Name = "tlpPageCenter";
            this.tlpPageCenter.RowCount = 3;
            this.tlpPageCenter.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpPageCenter.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpPageCenter.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpPageCenter.Size = new System.Drawing.Size(518, 587);
            this.tlpPageCenter.TabIndex = 0;
            // 
            // pnlCard
            // 
            this.pnlCard.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pnlCard.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlCard.Controls.Add(this.tlpCard);
            this.pnlCard.Location = new System.Drawing.Point(31, 32);
            this.pnlCard.Margin = new System.Windows.Forms.Padding(0);
            this.pnlCard.Name = "pnlCard";
            this.pnlCard.Padding = new System.Windows.Forms.Padding(12, 6, 12, 12);
            this.pnlCard.Size = new System.Drawing.Size(455, 522);
            this.pnlCard.TabIndex = 0;
            // 
            // tlpCard
            // 
            this.tlpCard.ColumnCount = 1;
            this.tlpCard.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpCard.Controls.Add(this.lblTitle, 0, 0);
            this.tlpCard.Controls.Add(this.lblSubtitle, 0, 1);
            this.tlpCard.Controls.Add(this.lblStepScan, 0, 3);
            this.tlpCard.Controls.Add(this.pnlQr, 0, 4);
            this.tlpCard.Controls.Add(this.lblManualKey, 0, 6);
            this.tlpCard.Controls.Add(this.pnlSecret, 0, 7);
            this.tlpCard.Controls.Add(this.lblStepCode, 0, 9);
            this.tlpCard.Controls.Add(this.tlpVerifyRow, 0, 10);
            this.tlpCard.Controls.Add(this.tlpFooter, 0, 11);
            this.tlpCard.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpCard.Location = new System.Drawing.Point(12, 6);
            this.tlpCard.Margin = new System.Windows.Forms.Padding(0);
            this.tlpCard.Name = "tlpCard";
            this.tlpCard.RowCount = 12;
            this.tlpCard.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpCard.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpCard.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 14F));
            this.tlpCard.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpCard.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 200F));
            this.tlpCard.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 10F));
            this.tlpCard.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpCard.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpCard.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 8F));
            this.tlpCard.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpCard.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpCard.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpCard.Size = new System.Drawing.Size(429, 502);
            this.tlpCard.TabIndex = 0;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTitle.Font = new System.Drawing.Font("Muro", 19.5F);
            this.lblTitle.Location = new System.Drawing.Point(0, 0);
            this.lblTitle.Margin = new System.Windows.Forms.Padding(0, 0, 0, 8);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(429, 39);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "SET UP TWO-FACTOR AUTH";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblSubtitle
            // 
            this.lblSubtitle.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblSubtitle.AutoSize = true;
            this.lblSubtitle.Font = new System.Drawing.Font("Agency", 10F);
            this.lblSubtitle.ForeColor = System.Drawing.Color.DimGray;
            this.lblSubtitle.Location = new System.Drawing.Point(35, 47);
            this.lblSubtitle.Margin = new System.Windows.Forms.Padding(0);
            this.lblSubtitle.Name = "lblSubtitle";
            this.lblSubtitle.Size = new System.Drawing.Size(358, 30);
            this.lblSubtitle.TabIndex = 1;
            this.lblSubtitle.Text = "Scan the QR code in Microsoft or Google Authenticator";
            this.lblSubtitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblStepScan
            // 
            this.lblStepScan.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblStepScan.AutoSize = true;
            this.lblStepScan.Font = new System.Drawing.Font("Agency", 11F, System.Drawing.FontStyle.Bold);
            this.lblStepScan.Location = new System.Drawing.Point(91, 91);
            this.lblStepScan.Margin = new System.Windows.Forms.Padding(0, 0, 0, 8);
            this.lblStepScan.Name = "lblStepScan";
            this.lblStepScan.Size = new System.Drawing.Size(246, 17);
            this.lblStepScan.TabIndex = 2;
            this.lblStepScan.Text = "1) Scan the QR code";
            // 
            // pnlQr
            // 
            this.pnlQr.BackColor = System.Drawing.Color.WhiteSmoke;
            this.pnlQr.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlQr.Controls.Add(this.picQr);
            this.pnlQr.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlQr.Location = new System.Drawing.Point(0, 116);
            this.pnlQr.Margin = new System.Windows.Forms.Padding(0);
            this.pnlQr.Name = "pnlQr";
            this.pnlQr.Padding = new System.Windows.Forms.Padding(12);
            this.pnlQr.Size = new System.Drawing.Size(429, 200);
            this.pnlQr.TabIndex = 3;
            // 
            // picQr
            // 
            this.picQr.BackColor = System.Drawing.Color.White;
            this.picQr.Dock = System.Windows.Forms.DockStyle.Fill;
            this.picQr.Location = new System.Drawing.Point(12, 12);
            this.picQr.Name = "picQr";
            this.picQr.Size = new System.Drawing.Size(403, 174);
            this.picQr.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picQr.TabIndex = 0;
            this.picQr.TabStop = false;
            // 
            // lblManualKey
            // 
            this.lblManualKey.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblManualKey.AutoSize = true;
            this.lblManualKey.Font = new System.Drawing.Font("Agency", 10F);
            this.lblManualKey.Location = new System.Drawing.Point(54, 326);
            this.lblManualKey.Margin = new System.Windows.Forms.Padding(0, 0, 0, 3);
            this.lblManualKey.Name = "lblManualKey";
            this.lblManualKey.Size = new System.Drawing.Size(321, 15);
            this.lblManualKey.TabIndex = 4;
            this.lblManualKey.Text = "Manual key (if unable to scan)";
            // 
            // pnlSecret
            // 
            this.pnlSecret.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlSecret.Controls.Add(this.txtSecret);
            this.pnlSecret.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlSecret.Location = new System.Drawing.Point(0, 344);
            this.pnlSecret.Margin = new System.Windows.Forms.Padding(0);
            this.pnlSecret.Name = "pnlSecret";
            this.pnlSecret.Padding = new System.Windows.Forms.Padding(12);
            this.pnlSecret.Size = new System.Drawing.Size(429, 40);
            this.pnlSecret.TabIndex = 5;
            // 
            // txtSecret
            // 
            this.txtSecret.BackColor = System.Drawing.Color.White;
            this.txtSecret.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtSecret.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtSecret.Font = new System.Drawing.Font("Agency", 12F);
            this.txtSecret.Location = new System.Drawing.Point(12, 12);
            this.txtSecret.Margin = new System.Windows.Forms.Padding(0);
            this.txtSecret.Name = "txtSecret";
            this.txtSecret.ReadOnly = true;
            this.txtSecret.Size = new System.Drawing.Size(403, 25);
            this.txtSecret.TabIndex = 0;
            // 
            // lblStepCode
            // 
            this.lblStepCode.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblStepCode.AutoSize = true;
            this.lblStepCode.Font = new System.Drawing.Font("Agency", 11F, System.Drawing.FontStyle.Bold);
            this.lblStepCode.Location = new System.Drawing.Point(64, 392);
            this.lblStepCode.Margin = new System.Windows.Forms.Padding(0, 0, 0, 8);
            this.lblStepCode.Name = "lblStepCode";
            this.lblStepCode.Size = new System.Drawing.Size(300, 17);
            this.lblStepCode.TabIndex = 6;
            this.lblStepCode.Text = "2) Enter the 6-digit code";
            // 
            // tlpVerifyRow
            // 
            this.tlpVerifyRow.ColumnCount = 2;
            this.tlpVerifyRow.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 65F));
            this.tlpVerifyRow.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 35F));
            this.tlpVerifyRow.Controls.Add(this.pnlCode, 0, 0);
            this.tlpVerifyRow.Controls.Add(this.btnVerify, 1, 0);
            this.tlpVerifyRow.Dock = System.Windows.Forms.DockStyle.Top;
            this.tlpVerifyRow.Location = new System.Drawing.Point(0, 417);
            this.tlpVerifyRow.Margin = new System.Windows.Forms.Padding(0);
            this.tlpVerifyRow.Name = "tlpVerifyRow";
            this.tlpVerifyRow.RowCount = 1;
            this.tlpVerifyRow.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpVerifyRow.Size = new System.Drawing.Size(429, 40);
            this.tlpVerifyRow.TabIndex = 7;
            // 
            // pnlCode
            // 
            this.pnlCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlCode.Controls.Add(this.txtCode);
            this.pnlCode.Location = new System.Drawing.Point(0, 0);
            this.pnlCode.Margin = new System.Windows.Forms.Padding(0, 0, 12, 0);
            this.pnlCode.Name = "pnlCode";
            this.pnlCode.Padding = new System.Windows.Forms.Padding(12);
            this.pnlCode.Size = new System.Drawing.Size(266, 40);
            this.pnlCode.TabIndex = 0;
            // 
            // txtCode
            // 
            this.txtCode.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtCode.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtCode.Font = new System.Drawing.Font("Agency", 14F);
            this.txtCode.Location = new System.Drawing.Point(12, 12);
            this.txtCode.Margin = new System.Windows.Forms.Padding(0);
            this.txtCode.MaxLength = 6;
            this.txtCode.Name = "txtCode";
            this.txtCode.Size = new System.Drawing.Size(240, 29);
            this.txtCode.TabIndex = 0;
            // 
            // tlpFooter
            // 
            this.tlpFooter.AutoSize = true;
            this.tlpFooter.ColumnCount = 2;
            this.tlpFooter.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 65F));
            this.tlpFooter.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 35F));
            this.tlpFooter.Controls.Add(this.pnlFooterLeft, 0, 0);
            this.tlpFooter.Controls.Add(this.pnlFooterRight, 1, 0);
            this.tlpFooter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpFooter.Location = new System.Drawing.Point(0, 457);
            this.tlpFooter.Margin = new System.Windows.Forms.Padding(0);
            this.tlpFooter.Name = "tlpFooter";
            this.tlpFooter.Padding = new System.Windows.Forms.Padding(6, 6, 2, 6);
            this.tlpFooter.RowCount = 1;
            this.tlpFooter.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpFooter.Size = new System.Drawing.Size(429, 45);
            this.tlpFooter.TabIndex = 8;
            // 
            // pnlFooterLeft
            // 
            this.pnlFooterLeft.AutoSize = true;
            this.pnlFooterLeft.Controls.Add(this.lblStatus);
            this.pnlFooterLeft.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlFooterLeft.Location = new System.Drawing.Point(6, 6);
            this.pnlFooterLeft.Margin = new System.Windows.Forms.Padding(0, 0, 12, 0);
            this.pnlFooterLeft.Name = "pnlFooterLeft";
            this.pnlFooterLeft.Size = new System.Drawing.Size(261, 33);
            this.pnlFooterLeft.TabIndex = 0;
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblStatus.Location = new System.Drawing.Point(0, 0);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(0, 20);
            this.lblStatus.TabIndex = 0;
            this.lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pnlFooterRight
            // 
            this.pnlFooterRight.AutoSize = true;
            this.pnlFooterRight.Controls.Add(this.btnContinue);
            this.pnlFooterRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlFooterRight.Location = new System.Drawing.Point(279, 6);
            this.pnlFooterRight.Margin = new System.Windows.Forms.Padding(0);
            this.pnlFooterRight.Name = "pnlFooterRight";
            this.pnlFooterRight.Size = new System.Drawing.Size(148, 33);
            this.pnlFooterRight.TabIndex = 1;
            // 
            // btnVerify
            // 
            this.btnVerify.BackColor = System.Drawing.Color.LightGray;
            this.btnVerify.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnVerify.Font = new System.Drawing.Font("Muro", 12F);
            this.btnVerify.ForeColor = System.Drawing.Color.Black;
            this.btnVerify.Location = new System.Drawing.Point(278, 0);
            this.btnVerify.Margin = new System.Windows.Forms.Padding(0);
            this.btnVerify.Name = "btnVerify";
            this.btnVerify.Size = new System.Drawing.Size(151, 40);
            this.btnVerify.TabIndex = 1;
            this.btnVerify.Text = "Verify";
            this.btnVerify.UseVisualStyleBackColor = false;
            this.btnVerify.Click += new System.EventHandler(this.btnVerify_Click);
            // 
            // btnContinue
            // 
            this.btnContinue.BackColor = System.Drawing.Color.LightGray;
            this.btnContinue.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnContinue.Font = new System.Drawing.Font("Muro", 12F);
            this.btnContinue.ForeColor = System.Drawing.Color.Black;
            this.btnContinue.Location = new System.Drawing.Point(0, 0);
            this.btnContinue.Margin = new System.Windows.Forms.Padding(0);
            this.btnContinue.Name = "btnContinue";
            this.btnContinue.Size = new System.Drawing.Size(148, 33);
            this.btnContinue.TabIndex = 0;
            this.btnContinue.Text = "Continue";
            this.btnContinue.UseVisualStyleBackColor = false;
            this.btnContinue.Click += new System.EventHandler(this.btnContinue_Click);
            // 
            // TotpSetupForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(144F, 144F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(984, 611);
            this.Controls.Add(this.tlpRoot);
            this.MinimumSize = new System.Drawing.Size(1000, 650);
            this.Name = "TotpSetupForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "2FA SETUP | Mondas";
            this.Load += new System.EventHandler(this.TotpSetupForm_Load);
            this.tlpRoot.ResumeLayout(false);
            this.pnlSidebar.ResumeLayout(false);
            this.tlpSidebar.ResumeLayout(false);
            this.tlpSidebar.PerformLayout();
            this.pnlPage.ResumeLayout(false);
            this.tlpPageCenter.ResumeLayout(false);
            this.pnlCard.ResumeLayout(false);
            this.tlpCard.ResumeLayout(false);
            this.tlpCard.PerformLayout();
            this.pnlQr.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picQr)).EndInit();
            this.pnlSecret.ResumeLayout(false);
            this.pnlSecret.PerformLayout();
            this.tlpVerifyRow.ResumeLayout(false);
            this.pnlCode.ResumeLayout(false);
            this.pnlCode.PerformLayout();
            this.tlpFooter.ResumeLayout(false);
            this.tlpFooter.PerformLayout();
            this.pnlFooterLeft.ResumeLayout(false);
            this.pnlFooterLeft.PerformLayout();
            this.pnlFooterRight.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tlpRoot;
        private System.Windows.Forms.Panel pnlSidebar;
        private System.Windows.Forms.TableLayoutPanel tlpSidebar;
        private System.Windows.Forms.Label lblMondas;
        private System.Windows.Forms.Label lblHeroTitle;
        private System.Windows.Forms.Label lblHeroSubtitle;
        private System.Windows.Forms.Label lblHeroFooter;
        private System.Windows.Forms.Panel pnlPage;
        private System.Windows.Forms.TableLayoutPanel tlpPageCenter;
        private System.Windows.Forms.Panel pnlCard;
        private System.Windows.Forms.TableLayoutPanel tlpCard;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblSubtitle;
        private System.Windows.Forms.Label lblStepScan;
        private System.Windows.Forms.Panel pnlQr;
        private System.Windows.Forms.PictureBox picQr;
        private System.Windows.Forms.Label lblManualKey;
        private System.Windows.Forms.Panel pnlSecret;
        private System.Windows.Forms.TextBox txtSecret;
        private System.Windows.Forms.Label lblStepCode;
        private System.Windows.Forms.TableLayoutPanel tlpVerifyRow;
        private System.Windows.Forms.Panel pnlCode;
        private System.Windows.Forms.TextBox txtCode;
        private System.Windows.Forms.TableLayoutPanel tlpFooter;
        private System.Windows.Forms.Panel pnlFooterLeft;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Panel pnlFooterRight;
        private System.Windows.Forms.Button btnVerify;
        private System.Windows.Forms.Button btnContinue;
    }
}