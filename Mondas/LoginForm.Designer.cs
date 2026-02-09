namespace Mondas
{
    partial class LoginForm
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
            System.Windows.Forms.TableLayoutPanel tlpRoot;
            this.pnlSidebar = new System.Windows.Forms.Panel();
            this.tlpSidebar = new System.Windows.Forms.TableLayoutPanel();
            this.lblMondas = new System.Windows.Forms.Label();
            this.lblHeroTitle = new System.Windows.Forms.Label();
            this.lblHeroSubtitle = new System.Windows.Forms.Label();
            this.lblFooter = new System.Windows.Forms.Label();
            this.pnlPage = new System.Windows.Forms.Panel();
            this.tlpPageCenter = new System.Windows.Forms.TableLayoutPanel();
            this.pnlCard = new System.Windows.Forms.Panel();
            this.tlpLogin = new System.Windows.Forms.TableLayoutPanel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblSubtitle = new System.Windows.Forms.Label();
            this.pnlEmail = new System.Windows.Forms.Panel();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.pnlPassword = new System.Windows.Forms.Panel();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.tlpRememberRow = new System.Windows.Forms.TableLayoutPanel();
            this.chkRemember = new System.Windows.Forms.CheckBox();
            this.lnkForgot = new System.Windows.Forms.LinkLabel();
            this.btnSignIn = new Syncfusion.WinForms.Controls.SfButton();
            this.tlpTwoFa = new System.Windows.Forms.TableLayoutPanel();
            this.pnlTwoFaCode = new System.Windows.Forms.Panel();
            this.txtTwoFaCode = new System.Windows.Forms.TextBox();
            this.btnVerifyCode = new Syncfusion.WinForms.Controls.SfButton();
            this.pnlBottom = new System.Windows.Forms.Panel();
            this.lnkSignUp = new System.Windows.Forms.LinkLabel();
            this.lblStatus = new System.Windows.Forms.Label();
            tlpRoot = new System.Windows.Forms.TableLayoutPanel();
            tlpRoot.SuspendLayout();
            this.pnlSidebar.SuspendLayout();
            this.tlpSidebar.SuspendLayout();
            this.pnlPage.SuspendLayout();
            this.tlpPageCenter.SuspendLayout();
            this.pnlCard.SuspendLayout();
            this.tlpLogin.SuspendLayout();
            this.pnlEmail.SuspendLayout();
            this.pnlPassword.SuspendLayout();
            this.tlpRememberRow.SuspendLayout();
            this.tlpTwoFa.SuspendLayout();
            this.pnlTwoFaCode.SuspendLayout();
            this.pnlBottom.SuspendLayout();
            this.SuspendLayout();
            // 
            // tlpRoot
            // 
            tlpRoot.ColumnCount = 2;
            tlpRoot.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 44F));
            tlpRoot.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 56F));
            tlpRoot.Controls.Add(this.pnlSidebar, 0, 0);
            tlpRoot.Controls.Add(this.pnlPage, 1, 0);
            tlpRoot.Dock = System.Windows.Forms.DockStyle.Fill;
            tlpRoot.Location = new System.Drawing.Point(2, 2);
            tlpRoot.Name = "tlpRoot";
            tlpRoot.RowCount = 1;
            tlpRoot.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            tlpRoot.Size = new System.Drawing.Size(1180, 707);
            tlpRoot.TabIndex = 0;
            // 
            // pnlSidebar
            // 
            this.pnlSidebar.BackColor = System.Drawing.Color.RoyalBlue;
            this.pnlSidebar.Controls.Add(this.tlpSidebar);
            this.pnlSidebar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlSidebar.Location = new System.Drawing.Point(3, 3);
            this.pnlSidebar.Name = "pnlSidebar";
            this.pnlSidebar.Padding = new System.Windows.Forms.Padding(48, 48, 32, 32);
            this.pnlSidebar.Size = new System.Drawing.Size(513, 701);
            this.pnlSidebar.TabIndex = 0;
            // 
            // tlpSidebar
            // 
            this.tlpSidebar.BackColor = System.Drawing.Color.Transparent;
            this.tlpSidebar.ColumnCount = 1;
            this.tlpSidebar.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpSidebar.Controls.Add(this.lblMondas, 0, 0);
            this.tlpSidebar.Controls.Add(this.lblHeroTitle, 0, 2);
            this.tlpSidebar.Controls.Add(this.lblHeroSubtitle, 0, 4);
            this.tlpSidebar.Controls.Add(this.lblFooter, 0, 5);
            this.tlpSidebar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpSidebar.GrowStyle = System.Windows.Forms.TableLayoutPanelGrowStyle.FixedSize;
            this.tlpSidebar.Location = new System.Drawing.Point(48, 48);
            this.tlpSidebar.Margin = new System.Windows.Forms.Padding(0);
            this.tlpSidebar.Name = "tlpSidebar";
            this.tlpSidebar.RowCount = 6;
            this.tlpSidebar.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tlpSidebar.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tlpSidebar.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpSidebar.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.tlpSidebar.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpSidebar.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpSidebar.Size = new System.Drawing.Size(433, 621);
            this.tlpSidebar.TabIndex = 0;
            this.tlpSidebar.Paint += new System.Windows.Forms.PaintEventHandler(this.tlpSidebar_Paint);
            // 
            // lblMondas
            // 
            this.lblMondas.AutoSize = true;
            this.lblMondas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblMondas.Font = new System.Drawing.Font("Muro", 46F);
            this.lblMondas.ForeColor = System.Drawing.Color.White;
            this.lblMondas.Location = new System.Drawing.Point(0, 0);
            this.lblMondas.Margin = new System.Windows.Forms.Padding(0);
            this.lblMondas.Name = "lblMondas";
            this.lblMondas.Size = new System.Drawing.Size(433, 100);
            this.lblMondas.TabIndex = 0;
            this.lblMondas.Text = "MONDAS";
            this.lblMondas.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblHeroTitle
            // 
            this.lblHeroTitle.AutoSize = true;
            this.lblHeroTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblHeroTitle.Font = new System.Drawing.Font("Muro", 22F);
            this.lblHeroTitle.ForeColor = System.Drawing.Color.White;
            this.lblHeroTitle.Location = new System.Drawing.Point(0, 158);
            this.lblHeroTitle.Margin = new System.Windows.Forms.Padding(0, 18, 0, 6);
            this.lblHeroTitle.Name = "lblHeroTitle";
            this.lblHeroTitle.Size = new System.Drawing.Size(433, 44);
            this.lblHeroTitle.TabIndex = 0;
            this.lblHeroTitle.Text = "Welcome to Mondas";
            this.lblHeroTitle.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblHeroSubtitle
            // 
            this.lblHeroSubtitle.AutoSize = true;
            this.lblHeroSubtitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblHeroSubtitle.Font = new System.Drawing.Font("Agency", 14F);
            this.lblHeroSubtitle.ForeColor = System.Drawing.Color.White;
            this.lblHeroSubtitle.Location = new System.Drawing.Point(0, 288);
            this.lblHeroSubtitle.Margin = new System.Windows.Forms.Padding(0);
            this.lblHeroSubtitle.Name = "lblHeroSubtitle";
            this.lblHeroSubtitle.Size = new System.Drawing.Size(433, 21);
            this.lblHeroSubtitle.TabIndex = 2;
            this.lblHeroSubtitle.Text = "Sign in to continue";
            this.lblHeroSubtitle.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblFooter
            // 
            this.lblFooter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblFooter.AutoSize = true;
            this.lblFooter.Font = new System.Drawing.Font("Agency FB", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFooter.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.lblFooter.Location = new System.Drawing.Point(3, 601);
            this.lblFooter.Name = "lblFooter";
            this.lblFooter.Size = new System.Drawing.Size(120, 20);
            this.lblFooter.TabIndex = 3;
            this.lblFooter.Text = "© 2026 Mondas Learning";
            this.lblFooter.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // pnlPage
            // 
            this.pnlPage.Controls.Add(this.tlpPageCenter);
            this.pnlPage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlPage.Location = new System.Drawing.Point(522, 3);
            this.pnlPage.Name = "pnlPage";
            this.pnlPage.Padding = new System.Windows.Forms.Padding(32);
            this.pnlPage.Size = new System.Drawing.Size(655, 701);
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
            this.tlpPageCenter.Location = new System.Drawing.Point(32, 32);
            this.tlpPageCenter.Name = "tlpPageCenter";
            this.tlpPageCenter.RowCount = 3;
            this.tlpPageCenter.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpPageCenter.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpPageCenter.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpPageCenter.Size = new System.Drawing.Size(591, 637);
            this.tlpPageCenter.TabIndex = 0;
            // 
            // pnlCard
            // 
            this.pnlCard.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pnlCard.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlCard.Controls.Add(this.tlpLogin);
            this.pnlCard.Location = new System.Drawing.Point(35, 38);
            this.pnlCard.Margin = new System.Windows.Forms.Padding(0);
            this.pnlCard.Name = "pnlCard";
            this.pnlCard.Padding = new System.Windows.Forms.Padding(28);
            this.pnlCard.Size = new System.Drawing.Size(520, 560);
            this.pnlCard.TabIndex = 0;
            // 
            // tlpLogin
            // 
            this.tlpLogin.AutoSize = true;
            this.tlpLogin.ColumnCount = 1;
            this.tlpLogin.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpLogin.Controls.Add(this.lblTitle, 0, 0);
            this.tlpLogin.Controls.Add(this.lblSubtitle, 0, 1);
            this.tlpLogin.Controls.Add(this.pnlEmail, 0, 3);
            this.tlpLogin.Controls.Add(this.pnlPassword, 0, 4);
            this.tlpLogin.Controls.Add(this.tlpRememberRow, 0, 5);
            this.tlpLogin.Controls.Add(this.btnSignIn, 0, 7);
            this.tlpLogin.Controls.Add(this.tlpTwoFa, 0, 8);
            this.tlpLogin.Controls.Add(this.pnlBottom, 0, 9);
            this.tlpLogin.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpLogin.Location = new System.Drawing.Point(28, 28);
            this.tlpLogin.Margin = new System.Windows.Forms.Padding(0);
            this.tlpLogin.Name = "tlpLogin";
            this.tlpLogin.RowCount = 10;
            this.tlpLogin.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpLogin.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpLogin.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 16F));
            this.tlpLogin.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tlpLogin.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tlpLogin.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpLogin.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 16F));
            this.tlpLogin.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 56F));
            this.tlpLogin.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 56F));
            this.tlpLogin.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpLogin.Size = new System.Drawing.Size(462, 502);
            this.tlpLogin.TabIndex = 0;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTitle.Font = new System.Drawing.Font("Muro", 26F);
            this.lblTitle.Location = new System.Drawing.Point(3, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Padding = new System.Windows.Forms.Padding(0, 0, 0, 20);
            this.lblTitle.Size = new System.Drawing.Size(456, 72);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Sign In";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblSubtitle
            // 
            this.lblSubtitle.AutoSize = true;
            this.lblSubtitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblSubtitle.Font = new System.Drawing.Font("Agency", 10F);
            this.lblSubtitle.ForeColor = System.Drawing.Color.DimGray;
            this.lblSubtitle.Location = new System.Drawing.Point(0, 72);
            this.lblSubtitle.Margin = new System.Windows.Forms.Padding(0);
            this.lblSubtitle.Name = "lblSubtitle";
            this.lblSubtitle.Size = new System.Drawing.Size(462, 15);
            this.lblSubtitle.TabIndex = 1;
            this.lblSubtitle.Text = "Use your Mondas account to continue.";
            this.lblSubtitle.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // pnlEmail
            // 
            this.pnlEmail.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlEmail.Controls.Add(this.txtEmail);
            this.pnlEmail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlEmail.Location = new System.Drawing.Point(0, 103);
            this.pnlEmail.Margin = new System.Windows.Forms.Padding(0);
            this.pnlEmail.Name = "pnlEmail";
            this.pnlEmail.Padding = new System.Windows.Forms.Padding(12);
            this.pnlEmail.Size = new System.Drawing.Size(462, 50);
            this.pnlEmail.TabIndex = 2;
            // 
            // txtEmail
            // 
            this.txtEmail.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtEmail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtEmail.Font = new System.Drawing.Font("Agency", 14F);
            this.txtEmail.ForeColor = System.Drawing.Color.Black;
            this.txtEmail.Location = new System.Drawing.Point(12, 12);
            this.txtEmail.Margin = new System.Windows.Forms.Padding(0);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(436, 29);
            this.txtEmail.TabIndex = 0;
            this.txtEmail.Text = "Email Address";
            // 
            // pnlPassword
            // 
            this.pnlPassword.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlPassword.Controls.Add(this.txtPassword);
            this.pnlPassword.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlPassword.Location = new System.Drawing.Point(0, 165);
            this.pnlPassword.Margin = new System.Windows.Forms.Padding(0, 12, 0, 0);
            this.pnlPassword.Name = "pnlPassword";
            this.pnlPassword.Padding = new System.Windows.Forms.Padding(10);
            this.pnlPassword.Size = new System.Drawing.Size(462, 48);
            this.pnlPassword.TabIndex = 3;
            // 
            // txtPassword
            // 
            this.txtPassword.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtPassword.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtPassword.Font = new System.Drawing.Font("Agency", 14F);
            this.txtPassword.ForeColor = System.Drawing.Color.Black;
            this.txtPassword.Location = new System.Drawing.Point(10, 10);
            this.txtPassword.Margin = new System.Windows.Forms.Padding(0);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(440, 29);
            this.txtPassword.TabIndex = 0;
            this.txtPassword.Text = "Password";
            this.txtPassword.UseSystemPasswordChar = true;
            // 
            // tlpRememberRow
            // 
            this.tlpRememberRow.ColumnCount = 2;
            this.tlpRememberRow.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpRememberRow.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpRememberRow.Controls.Add(this.chkRemember, 0, 0);
            this.tlpRememberRow.Controls.Add(this.lnkForgot, 1, 0);
            this.tlpRememberRow.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpRememberRow.Location = new System.Drawing.Point(0, 223);
            this.tlpRememberRow.Margin = new System.Windows.Forms.Padding(0, 10, 0, 0);
            this.tlpRememberRow.Name = "tlpRememberRow";
            this.tlpRememberRow.RowCount = 1;
            this.tlpRememberRow.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpRememberRow.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpRememberRow.Size = new System.Drawing.Size(462, 63);
            this.tlpRememberRow.TabIndex = 4;
            // 
            // chkRemember
            // 
            this.chkRemember.AutoSize = true;
            this.chkRemember.Dock = System.Windows.Forms.DockStyle.Left;
            this.chkRemember.Font = new System.Drawing.Font("Agency", 12F);
            this.chkRemember.Location = new System.Drawing.Point(0, 0);
            this.chkRemember.Margin = new System.Windows.Forms.Padding(0);
            this.chkRemember.Name = "chkRemember";
            this.chkRemember.Size = new System.Drawing.Size(201, 63);
            this.chkRemember.TabIndex = 0;
            this.chkRemember.Text = "Remember Me";
            this.chkRemember.UseVisualStyleBackColor = true;
            // 
            // lnkForgot
            // 
            this.lnkForgot.AutoSize = true;
            this.lnkForgot.Dock = System.Windows.Forms.DockStyle.Right;
            this.lnkForgot.Font = new System.Drawing.Font("Agency", 10F);
            this.lnkForgot.LinkColor = System.Drawing.Color.RoyalBlue;
            this.lnkForgot.Location = new System.Drawing.Point(263, 0);
            this.lnkForgot.Margin = new System.Windows.Forms.Padding(0);
            this.lnkForgot.Name = "lnkForgot";
            this.lnkForgot.Size = new System.Drawing.Size(199, 63);
            this.lnkForgot.TabIndex = 1;
            this.lnkForgot.TabStop = true;
            this.lnkForgot.Text = "Forgot Password";
            this.lnkForgot.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnSignIn
            // 
            this.btnSignIn.BackColor = System.Drawing.Color.RoyalBlue;
            this.btnSignIn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnSignIn.Font = new System.Drawing.Font("Muro", 20F);
            this.btnSignIn.ForeColor = System.Drawing.Color.White;
            this.btnSignIn.Location = new System.Drawing.Point(0, 302);
            this.btnSignIn.Margin = new System.Windows.Forms.Padding(0);
            this.btnSignIn.Name = "btnSignIn";
            this.btnSignIn.Size = new System.Drawing.Size(462, 56);
            this.btnSignIn.Style.BackColor = System.Drawing.Color.RoyalBlue;
            this.btnSignIn.Style.ForeColor = System.Drawing.Color.White;
            this.btnSignIn.TabIndex = 5;
            this.btnSignIn.Text = "SIGN IN";
            this.btnSignIn.UseVisualStyleBackColor = false;
            this.btnSignIn.Click += new System.EventHandler(this.btnSignIn_Click);
            // 
            // tlpTwoFa
            // 
            this.tlpTwoFa.ColumnCount = 2;
            this.tlpTwoFa.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.tlpTwoFa.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tlpTwoFa.Controls.Add(this.pnlTwoFaCode, 0, 0);
            this.tlpTwoFa.Controls.Add(this.btnVerifyCode, 1, 0);
            this.tlpTwoFa.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpTwoFa.Location = new System.Drawing.Point(0, 368);
            this.tlpTwoFa.Margin = new System.Windows.Forms.Padding(0, 10, 0, 0);
            this.tlpTwoFa.Name = "tlpTwoFa";
            this.tlpTwoFa.RowCount = 1;
            this.tlpTwoFa.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpTwoFa.Size = new System.Drawing.Size(462, 46);
            this.tlpTwoFa.TabIndex = 6;
            // 
            // pnlTwoFaCode
            // 
            this.pnlTwoFaCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlTwoFaCode.Controls.Add(this.txtTwoFaCode);
            this.pnlTwoFaCode.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlTwoFaCode.Location = new System.Drawing.Point(0, 0);
            this.pnlTwoFaCode.Margin = new System.Windows.Forms.Padding(0);
            this.pnlTwoFaCode.Name = "pnlTwoFaCode";
            this.pnlTwoFaCode.Padding = new System.Windows.Forms.Padding(10, 5, 10, 10);
            this.pnlTwoFaCode.Size = new System.Drawing.Size(277, 46);
            this.pnlTwoFaCode.TabIndex = 0;
            // 
            // txtTwoFaCode
            // 
            this.txtTwoFaCode.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtTwoFaCode.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtTwoFaCode.Font = new System.Drawing.Font("Muro", 14F);
            this.txtTwoFaCode.Location = new System.Drawing.Point(10, 5);
            this.txtTwoFaCode.Margin = new System.Windows.Forms.Padding(0);
            this.txtTwoFaCode.Name = "txtTwoFaCode";
            this.txtTwoFaCode.Size = new System.Drawing.Size(255, 28);
            this.txtTwoFaCode.TabIndex = 0;
            this.txtTwoFaCode.Text = "2FA Code";
            // 
            // btnVerifyCode
            // 
            this.btnVerifyCode.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnVerifyCode.Font = new System.Drawing.Font("Agency", 12F);
            this.btnVerifyCode.Location = new System.Drawing.Point(287, 0);
            this.btnVerifyCode.Margin = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btnVerifyCode.Name = "btnVerifyCode";
            this.btnVerifyCode.Size = new System.Drawing.Size(175, 46);
            this.btnVerifyCode.TabIndex = 1;
            this.btnVerifyCode.Text = "VERIFY CODE";
            this.btnVerifyCode.Click += new System.EventHandler(this.btnVerifyCode_Click);
            // 
            // pnlBottom
            // 
            this.pnlBottom.Controls.Add(this.lnkSignUp);
            this.pnlBottom.Controls.Add(this.lblStatus);
            this.pnlBottom.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlBottom.Location = new System.Drawing.Point(0, 428);
            this.pnlBottom.Margin = new System.Windows.Forms.Padding(0, 14, 0, 0);
            this.pnlBottom.Name = "pnlBottom";
            this.pnlBottom.Size = new System.Drawing.Size(462, 74);
            this.pnlBottom.TabIndex = 7;
            // 
            // lnkSignUp
            // 
            this.lnkSignUp.AutoSize = true;
            this.lnkSignUp.Font = new System.Drawing.Font("Agency FB", 11F);
            this.lnkSignUp.LinkColor = System.Drawing.Color.RoyalBlue;
            this.lnkSignUp.Location = new System.Drawing.Point(0, 17);
            this.lnkSignUp.Name = "lnkSignUp";
            this.lnkSignUp.Padding = new System.Windows.Forms.Padding(0, 10, 0, 0);
            this.lnkSignUp.Size = new System.Drawing.Size(218, 36);
            this.lnkSignUp.TabIndex = 1;
            this.lnkSignUp.TabStop = true;
            this.lnkSignUp.Text = "Don\'t have an account? Sign up";
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblStatus.Font = new System.Drawing.Font("Agency", 11F);
            this.lblStatus.ForeColor = System.Drawing.Color.DimGray;
            this.lblStatus.Location = new System.Drawing.Point(0, 0);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(0, 17);
            this.lblStatus.TabIndex = 0;
            // 
            // LoginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(144F, 144F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(1184, 711);
            this.Controls.Add(tlpRoot);
            this.MinimumSize = new System.Drawing.Size(1200, 750);
            this.Name = "LoginForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Style.MdiChild.IconHorizontalAlignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.Style.MdiChild.IconVerticalAlignment = System.Windows.Forms.VisualStyles.VerticalAlignment.Center;
            this.Text = "LOGIN | Mondas";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.LoginForm_Load);
            tlpRoot.ResumeLayout(false);
            this.pnlSidebar.ResumeLayout(false);
            this.tlpSidebar.ResumeLayout(false);
            this.tlpSidebar.PerformLayout();
            this.pnlPage.ResumeLayout(false);
            this.tlpPageCenter.ResumeLayout(false);
            this.pnlCard.ResumeLayout(false);
            this.pnlCard.PerformLayout();
            this.tlpLogin.ResumeLayout(false);
            this.tlpLogin.PerformLayout();
            this.pnlEmail.ResumeLayout(false);
            this.pnlEmail.PerformLayout();
            this.pnlPassword.ResumeLayout(false);
            this.pnlPassword.PerformLayout();
            this.tlpRememberRow.ResumeLayout(false);
            this.tlpRememberRow.PerformLayout();
            this.tlpTwoFa.ResumeLayout(false);
            this.pnlTwoFaCode.ResumeLayout(false);
            this.pnlTwoFaCode.PerformLayout();
            this.pnlBottom.ResumeLayout(false);
            this.pnlBottom.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlSidebar;
        private System.Windows.Forms.TableLayoutPanel tlpSidebar;
        private System.Windows.Forms.Label lblMondas;
        private System.Windows.Forms.Label lblHeroTitle;
        private System.Windows.Forms.Label lblHeroSubtitle;
        private System.Windows.Forms.Label lblFooter;
        private System.Windows.Forms.Panel pnlPage;
        private System.Windows.Forms.TableLayoutPanel tlpPageCenter;
        private System.Windows.Forms.Panel pnlCard;
        private System.Windows.Forms.TableLayoutPanel tlpLogin;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblSubtitle;
        private System.Windows.Forms.Panel pnlEmail;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Panel pnlPassword;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.TableLayoutPanel tlpRememberRow;
        private System.Windows.Forms.CheckBox chkRemember;
        private System.Windows.Forms.LinkLabel lnkForgot;
        private Syncfusion.WinForms.Controls.SfButton btnSignIn;
        private System.Windows.Forms.TableLayoutPanel tlpTwoFa;
        private System.Windows.Forms.Panel pnlTwoFaCode;
        private System.Windows.Forms.TextBox txtTwoFaCode;
        private Syncfusion.WinForms.Controls.SfButton btnVerifyCode;
        private System.Windows.Forms.Panel pnlBottom;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.LinkLabel lnkSignUp;
    }
}