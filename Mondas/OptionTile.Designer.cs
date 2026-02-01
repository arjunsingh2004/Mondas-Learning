namespace Mondas
{
    partial class OptionTile
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tlpFile = new System.Windows.Forms.TableLayoutPanel();
            this.pnlSelector = new System.Windows.Forms.Panel();
            this.cbChoice = new Syncfusion.Windows.Forms.Tools.CheckBoxAdv();
            this.rbChoice = new Syncfusion.Windows.Forms.Tools.RadioButtonAdv();
            this.lblOptionText = new System.Windows.Forms.Label();
            this.tlpFile.SuspendLayout();
            this.pnlSelector.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cbChoice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rbChoice)).BeginInit();
            this.SuspendLayout();
            // 
            // tlpFile
            // 
            this.tlpFile.ColumnCount = 2;
            this.tlpFile.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tlpFile.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpFile.Controls.Add(this.pnlSelector, 0, 0);
            this.tlpFile.Controls.Add(this.lblOptionText, 1, 0);
            this.tlpFile.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpFile.Location = new System.Drawing.Point(16, 10);
            this.tlpFile.Margin = new System.Windows.Forms.Padding(0);
            this.tlpFile.Name = "tlpFile";
            this.tlpFile.RowCount = 1;
            this.tlpFile.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpFile.Size = new System.Drawing.Size(838, 40);
            this.tlpFile.TabIndex = 0;
            // 
            // pnlSelector
            // 
            this.pnlSelector.Controls.Add(this.cbChoice);
            this.pnlSelector.Controls.Add(this.rbChoice);
            this.pnlSelector.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlSelector.Location = new System.Drawing.Point(3, 3);
            this.pnlSelector.Name = "pnlSelector";
            this.pnlSelector.Size = new System.Drawing.Size(44, 34);
            this.pnlSelector.TabIndex = 0;
            // 
            // cbChoice
            // 
            this.cbChoice.AccessibilityEnabled = true;
            this.cbChoice.AutoSize = true;
            this.cbChoice.BeforeTouchSize = new System.Drawing.Size(23, 22);
            this.cbChoice.ImageCheckBoxSize = new System.Drawing.Size(19, 19);
            this.cbChoice.Location = new System.Drawing.Point(10, 5);
            this.cbChoice.Name = "cbChoice";
            this.cbChoice.Size = new System.Drawing.Size(23, 22);
            this.cbChoice.TabIndex = 1;
            this.cbChoice.Visible = false;
            // 
            // rbChoice
            // 
            this.rbChoice.AccessibilityEnabled = true;
            this.rbChoice.AutoSize = true;
            this.rbChoice.BeforeTouchSize = new System.Drawing.Size(23, 22);
            this.rbChoice.ImageCheckBoxSize = new System.Drawing.Size(19, 19);
            this.rbChoice.Location = new System.Drawing.Point(10, 5);
            this.rbChoice.MetroColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(89)))), ((int)(((byte)(91)))));
            this.rbChoice.Name = "rbChoice";
            this.rbChoice.Size = new System.Drawing.Size(23, 22);
            this.rbChoice.TabIndex = 0;
            // 
            // lblOptionText
            // 
            this.lblOptionText.AutoSize = true;
            this.lblOptionText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblOptionText.Font = new System.Drawing.Font("Agency", 26F);
            this.lblOptionText.Location = new System.Drawing.Point(50, 0);
            this.lblOptionText.Margin = new System.Windows.Forms.Padding(0);
            this.lblOptionText.Name = "lblOptionText";
            this.lblOptionText.Size = new System.Drawing.Size(788, 40);
            this.lblOptionText.TabIndex = 1;
            this.lblOptionText.Text = "OPTION TEXT";
            this.lblOptionText.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // OptionTile
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.tlpFile);
            this.Margin = new System.Windows.Forms.Padding(0, 0, 0, 12);
            this.Name = "OptionTile";
            this.Padding = new System.Windows.Forms.Padding(16, 10, 16, 10);
            this.Size = new System.Drawing.Size(870, 60);
            this.Load += new System.EventHandler(this.OptionTile_Load);
            this.tlpFile.ResumeLayout(false);
            this.tlpFile.PerformLayout();
            this.pnlSelector.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cbChoice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rbChoice)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tlpFile;
        private System.Windows.Forms.Panel pnlSelector;
        private Syncfusion.Windows.Forms.Tools.RadioButtonAdv rbChoice;
        private Syncfusion.Windows.Forms.Tools.CheckBoxAdv cbChoice;
        private System.Windows.Forms.Label lblOptionText;
    }
}
