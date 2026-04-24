namespace Mondas
{
    partial class Start
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }

            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.lblTagline = new System.Windows.Forms.Label();
            this.lblMondas = new System.Windows.Forms.Label();
            this.btnStart = new Syncfusion.WinForms.Controls.SfButton();
            this.SuspendLayout();
            // 
            // lblTagline
            // 
            this.lblTagline.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblTagline.AutoSize = true;
            this.lblTagline.Font = new System.Drawing.Font("Agency", 15F);
            this.lblTagline.ForeColor = System.Drawing.Color.White;
            this.lblTagline.Location = new System.Drawing.Point(200, 295);
            this.lblTagline.Name = "lblTagline";
            this.lblTagline.Size = new System.Drawing.Size(584, 22);
            this.lblTagline.TabIndex = 3;
            this.lblTagline.Text = "Adaptive cyber-awareness training";
            this.lblTagline.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblMondas
            // 
            this.lblMondas.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblMondas.AutoSize = true;
            this.lblMondas.Font = new System.Drawing.Font("Muro", 48F);
            this.lblMondas.ForeColor = System.Drawing.Color.White;
            this.lblMondas.Location = new System.Drawing.Point(334, 144);
            this.lblMondas.Name = "lblMondas";
            this.lblMondas.Size = new System.Drawing.Size(338, 96);
            this.lblMondas.TabIndex = 2;
            this.lblMondas.Text = "MONDAS";
            this.lblMondas.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnStart
            // 
            this.btnStart.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnStart.AutoSize = true;
            this.btnStart.BackColor = System.Drawing.Color.White;
            this.btnStart.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStart.Font = new System.Drawing.Font("Muro", 20F);
            this.btnStart.ForeColor = System.Drawing.Color.RoyalBlue;
            this.btnStart.Location = new System.Drawing.Point(416, 373);
            this.btnStart.Name = "btnStart";
            this.btnStart.Padding = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.btnStart.Size = new System.Drawing.Size(171, 57);
            this.btnStart.Style.BackColor = System.Drawing.Color.White;
            this.btnStart.Style.ForeColor = System.Drawing.Color.RoyalBlue;
            this.btnStart.TabIndex = 4;
            this.btnStart.Text = "START";
            this.btnStart.UseVisualStyleBackColor = false;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // Start
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.RoyalBlue;
            this.ClientSize = new System.Drawing.Size(984, 611);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.lblTagline);
            this.Controls.Add(this.lblMondas);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(900, 560);
            this.Name = "Start";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Style.BackColor = System.Drawing.Color.RoyalBlue;
            this.Style.MdiChild.IconHorizontalAlignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.Style.MdiChild.IconVerticalAlignment = System.Windows.Forms.VisualStyles.VerticalAlignment.Center;
            this.Text = "Mondas";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblTagline;
        private System.Windows.Forms.Label lblMondas;
        private Syncfusion.WinForms.Controls.SfButton btnStart;
    }
}