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
            this.tlpRoot.SuspendLayout();
            this.pnlSidebar.SuspendLayout();
            this.tlpSidebar.SuspendLayout();
            this.pnlPage.SuspendLayout();
            this.tlpPageCenter.SuspendLayout();
            this.pnlCard.SuspendLayout();
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
            this.tlpRoot.Location = new System.Drawing.Point(2, 2);
            this.tlpRoot.Margin = new System.Windows.Forms.Padding(0);
            this.tlpRoot.Name = "tlpRoot";
            this.tlpRoot.RowCount = 1;
            this.tlpRoot.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpRoot.Size = new System.Drawing.Size(980, 607);
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
            this.pnlSidebar.Size = new System.Drawing.Size(441, 607);
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
            this.tlpSidebar.Size = new System.Drawing.Size(441, 607);
            this.tlpSidebar.TabIndex = 0;
            // 
            // lblMondas
            // 
            this.lblMondas.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblMondas.AutoSize = true;
            this.lblMondas.Font = new System.Drawing.Font("Muro", 48F);
            this.lblMondas.ForeColor = System.Drawing.Color.White;
            this.lblMondas.Location = new System.Drawing.Point(51, 52);
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
            this.lblHeroTitle.Location = new System.Drawing.Point(32, 196);
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
            this.lblHeroSubtitle.Location = new System.Drawing.Point(47, 266);
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
            this.lblHeroFooter.Location = new System.Drawing.Point(10, 577);
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
            this.pnlPage.Location = new System.Drawing.Point(441, 0);
            this.pnlPage.Margin = new System.Windows.Forms.Padding(0);
            this.pnlPage.Name = "pnlPage";
            this.pnlPage.Padding = new System.Windows.Forms.Padding(24);
            this.pnlPage.Size = new System.Drawing.Size(539, 607);
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
            this.tlpPageCenter.Location = new System.Drawing.Point(24, 24);
            this.tlpPageCenter.Margin = new System.Windows.Forms.Padding(0);
            this.tlpPageCenter.Name = "tlpPageCenter";
            this.tlpPageCenter.RowCount = 3;
            this.tlpPageCenter.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpPageCenter.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpPageCenter.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpPageCenter.Size = new System.Drawing.Size(491, 559);
            this.tlpPageCenter.TabIndex = 0;
            // 
            // pnlCard
            // 
            this.pnlCard.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pnlCard.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlCard.Controls.Add(this.tlpCard);
            this.pnlCard.Location = new System.Drawing.Point(24, 22);
            this.pnlCard.Margin = new System.Windows.Forms.Padding(0);
            this.pnlCard.Name = "pnlCard";
            this.pnlCard.Padding = new System.Windows.Forms.Padding(24);
            this.pnlCard.Size = new System.Drawing.Size(442, 514);
            this.pnlCard.TabIndex = 0;
            // 
            // tlpCard
            // 
            this.tlpCard.ColumnCount = 1;
            this.tlpCard.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpCard.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpCard.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpCard.Location = new System.Drawing.Point(24, 24);
            this.tlpCard.Margin = new System.Windows.Forms.Padding(0);
            this.tlpCard.Name = "tlpCard";
            this.tlpCard.RowCount = 12;
            this.tlpCard.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpCard.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpCard.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpCard.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpCard.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpCard.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpCard.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpCard.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpCard.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpCard.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpCard.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpCard.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpCard.Size = new System.Drawing.Size(392, 464);
            this.tlpCard.TabIndex = 0;
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
            this.Style.MdiChild.IconHorizontalAlignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.Style.MdiChild.IconVerticalAlignment = System.Windows.Forms.VisualStyles.VerticalAlignment.Center;
            this.Text = "2FA SETUP | Mondas";
            this.Load += new System.EventHandler(this.TotpSetupForm_Load);
            this.tlpRoot.ResumeLayout(false);
            this.pnlSidebar.ResumeLayout(false);
            this.tlpSidebar.ResumeLayout(false);
            this.tlpSidebar.PerformLayout();
            this.pnlPage.ResumeLayout(false);
            this.tlpPageCenter.ResumeLayout(false);
            this.pnlCard.ResumeLayout(false);
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
    }
}