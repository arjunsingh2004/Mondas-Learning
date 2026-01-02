namespace Mondas
{
    partial class DashboardForm
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
            this.pnlSidebar = new System.Windows.Forms.Panel();
            this.pnlContent = new System.Windows.Forms.Panel();
            this.lblMondas = new System.Windows.Forms.Label();
            this.flpNav = new System.Windows.Forms.FlowLayoutPanel();
            this.btnNavDashboard = new System.Windows.Forms.Button();
            this.btnNavQuiz = new System.Windows.Forms.Button();
            this.btnNavMiniGames = new System.Windows.Forms.Button();
            this.btnNavReports = new System.Windows.Forms.Button();
            this.btnNavLeaderboard = new System.Windows.Forms.Button();
            this.btnNavCommunity = new System.Windows.Forms.Button();
            this.btnNavSettings = new System.Windows.Forms.Button();
            this.pnlSidebar.SuspendLayout();
            this.flpNav.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlSidebar
            // 
            this.pnlSidebar.BackColor = System.Drawing.Color.RoyalBlue;
            this.pnlSidebar.Controls.Add(this.lblMondas);
            this.pnlSidebar.Controls.Add(this.flpNav);
            this.pnlSidebar.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlSidebar.Location = new System.Drawing.Point(2, 2);
            this.pnlSidebar.Name = "pnlSidebar";
            this.pnlSidebar.Size = new System.Drawing.Size(240, 610);
            this.pnlSidebar.TabIndex = 0;
            // 
            // pnlContent
            // 
            this.pnlContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlContent.Location = new System.Drawing.Point(242, 2);
            this.pnlContent.Name = "pnlContent";
            this.pnlContent.Padding = new System.Windows.Forms.Padding(16);
            this.pnlContent.Size = new System.Drawing.Size(940, 610);
            this.pnlContent.TabIndex = 1;
            // 
            // lblMondas
            // 
            this.lblMondas.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblMondas.Font = new System.Drawing.Font("Muro", 26F);
            this.lblMondas.ForeColor = System.Drawing.Color.White;
            this.lblMondas.Location = new System.Drawing.Point(0, 0);
            this.lblMondas.Margin = new System.Windows.Forms.Padding(0);
            this.lblMondas.Name = "lblMondas";
            this.lblMondas.Size = new System.Drawing.Size(240, 90);
            this.lblMondas.TabIndex = 0;
            this.lblMondas.Text = "MONDAS";
            this.lblMondas.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // flpNav
            // 
            this.flpNav.AutoScroll = true;
            this.flpNav.Controls.Add(this.btnNavDashboard);
            this.flpNav.Controls.Add(this.btnNavQuiz);
            this.flpNav.Controls.Add(this.btnNavMiniGames);
            this.flpNav.Controls.Add(this.btnNavReports);
            this.flpNav.Controls.Add(this.btnNavLeaderboard);
            this.flpNav.Controls.Add(this.btnNavCommunity);
            this.flpNav.Controls.Add(this.btnNavSettings);
            this.flpNav.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flpNav.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flpNav.Location = new System.Drawing.Point(0, 0);
            this.flpNav.Name = "flpNav";
            this.flpNav.Padding = new System.Windows.Forms.Padding(0, 100, 0, 0);
            this.flpNav.Size = new System.Drawing.Size(240, 610);
            this.flpNav.TabIndex = 1;
            this.flpNav.WrapContents = false;
            // 
            // btnNavDashboard
            // 
            this.btnNavDashboard.FlatAppearance.BorderSize = 0;
            this.btnNavDashboard.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNavDashboard.Font = new System.Drawing.Font("Agency", 10F);
            this.btnNavDashboard.ForeColor = System.Drawing.Color.White;
            this.btnNavDashboard.Location = new System.Drawing.Point(0, 100);
            this.btnNavDashboard.Margin = new System.Windows.Forms.Padding(0);
            this.btnNavDashboard.Name = "btnNavDashboard";
            this.btnNavDashboard.Size = new System.Drawing.Size(240, 52);
            this.btnNavDashboard.TabIndex = 0;
            this.btnNavDashboard.Text = "DASHBOARD";
            this.btnNavDashboard.UseVisualStyleBackColor = false;
            this.btnNavDashboard.Click += new System.EventHandler(this.btnNavDashboard_Click);
            // 
            // btnNavQuiz
            // 
            this.btnNavQuiz.FlatAppearance.BorderSize = 0;
            this.btnNavQuiz.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNavQuiz.Font = new System.Drawing.Font("Agency", 10F);
            this.btnNavQuiz.ForeColor = System.Drawing.Color.White;
            this.btnNavQuiz.Location = new System.Drawing.Point(0, 152);
            this.btnNavQuiz.Margin = new System.Windows.Forms.Padding(0);
            this.btnNavQuiz.Name = "btnNavQuiz";
            this.btnNavQuiz.Size = new System.Drawing.Size(240, 52);
            this.btnNavQuiz.TabIndex = 1;
            this.btnNavQuiz.Text = "QUIZ";
            this.btnNavQuiz.UseVisualStyleBackColor = false;
            // 
            // btnNavMiniGames
            // 
            this.btnNavMiniGames.FlatAppearance.BorderSize = 0;
            this.btnNavMiniGames.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNavMiniGames.Font = new System.Drawing.Font("Agency", 10F);
            this.btnNavMiniGames.ForeColor = System.Drawing.Color.White;
            this.btnNavMiniGames.Location = new System.Drawing.Point(0, 204);
            this.btnNavMiniGames.Margin = new System.Windows.Forms.Padding(0);
            this.btnNavMiniGames.Name = "btnNavMiniGames";
            this.btnNavMiniGames.Size = new System.Drawing.Size(240, 52);
            this.btnNavMiniGames.TabIndex = 2;
            this.btnNavMiniGames.Text = "MINI GAMES";
            this.btnNavMiniGames.UseVisualStyleBackColor = false;
            // 
            // btnNavReports
            // 
            this.btnNavReports.FlatAppearance.BorderSize = 0;
            this.btnNavReports.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNavReports.Font = new System.Drawing.Font("Agency", 10F);
            this.btnNavReports.ForeColor = System.Drawing.Color.White;
            this.btnNavReports.Location = new System.Drawing.Point(0, 256);
            this.btnNavReports.Margin = new System.Windows.Forms.Padding(0);
            this.btnNavReports.Name = "btnNavReports";
            this.btnNavReports.Size = new System.Drawing.Size(240, 52);
            this.btnNavReports.TabIndex = 3;
            this.btnNavReports.Text = "REPORTS";
            this.btnNavReports.UseVisualStyleBackColor = false;
            // 
            // btnNavLeaderboard
            // 
            this.btnNavLeaderboard.FlatAppearance.BorderSize = 0;
            this.btnNavLeaderboard.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNavLeaderboard.Font = new System.Drawing.Font("Agency", 10F);
            this.btnNavLeaderboard.ForeColor = System.Drawing.Color.White;
            this.btnNavLeaderboard.Location = new System.Drawing.Point(0, 308);
            this.btnNavLeaderboard.Margin = new System.Windows.Forms.Padding(0);
            this.btnNavLeaderboard.Name = "btnNavLeaderboard";
            this.btnNavLeaderboard.Size = new System.Drawing.Size(240, 52);
            this.btnNavLeaderboard.TabIndex = 4;
            this.btnNavLeaderboard.Text = "LEADERBOARD";
            this.btnNavLeaderboard.UseVisualStyleBackColor = false;
            // 
            // btnNavCommunity
            // 
            this.btnNavCommunity.FlatAppearance.BorderSize = 0;
            this.btnNavCommunity.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNavCommunity.Font = new System.Drawing.Font("Agency", 10F);
            this.btnNavCommunity.ForeColor = System.Drawing.Color.White;
            this.btnNavCommunity.Location = new System.Drawing.Point(0, 360);
            this.btnNavCommunity.Margin = new System.Windows.Forms.Padding(0);
            this.btnNavCommunity.Name = "btnNavCommunity";
            this.btnNavCommunity.Size = new System.Drawing.Size(240, 52);
            this.btnNavCommunity.TabIndex = 5;
            this.btnNavCommunity.Text = "COMMUNITY";
            this.btnNavCommunity.UseVisualStyleBackColor = false;
            // 
            // btnNavSettings
            // 
            this.btnNavSettings.FlatAppearance.BorderSize = 0;
            this.btnNavSettings.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNavSettings.Font = new System.Drawing.Font("Agency", 10F);
            this.btnNavSettings.ForeColor = System.Drawing.Color.White;
            this.btnNavSettings.Location = new System.Drawing.Point(0, 412);
            this.btnNavSettings.Margin = new System.Windows.Forms.Padding(0);
            this.btnNavSettings.Name = "btnNavSettings";
            this.btnNavSettings.Size = new System.Drawing.Size(240, 52);
            this.btnNavSettings.TabIndex = 6;
            this.btnNavSettings.Text = "SETTINGS";
            this.btnNavSettings.UseVisualStyleBackColor = false;
            // 
            // DashboardForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(1184, 614);
            this.Controls.Add(this.pnlContent);
            this.Controls.Add(this.pnlSidebar);
            this.Font = new System.Drawing.Font("Muro", 9F);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MinimumSize = new System.Drawing.Size(1200, 653);
            this.Name = "DashboardForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Style.BackColor = System.Drawing.Color.WhiteSmoke;
            this.Style.MdiChild.IconHorizontalAlignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.Style.MdiChild.IconVerticalAlignment = System.Windows.Forms.VisualStyles.VerticalAlignment.Center;
            this.Text = "Dashboard - Mondas";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.DashboardForm_Load);
            this.pnlSidebar.ResumeLayout(false);
            this.flpNav.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlSidebar;
        private System.Windows.Forms.Panel pnlContent;
        private System.Windows.Forms.Label lblMondas;
        private System.Windows.Forms.FlowLayoutPanel flpNav;
        private System.Windows.Forms.Button btnNavDashboard;
        private System.Windows.Forms.Button btnNavQuiz;
        private System.Windows.Forms.Button btnNavMiniGames;
        private System.Windows.Forms.Button btnNavReports;
        private System.Windows.Forms.Button btnNavLeaderboard;
        private System.Windows.Forms.Button btnNavCommunity;
        private System.Windows.Forms.Button btnNavSettings;
    }
}