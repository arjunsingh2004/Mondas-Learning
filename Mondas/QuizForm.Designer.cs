namespace Mondas
{
    partial class QuizForm
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
            this.btnPrevious = new Syncfusion.WinForms.Controls.SfButton();
            this.lblFeedback = new System.Windows.Forms.Label();
            this.flpQuizButtons = new System.Windows.Forms.FlowLayoutPanel();
            this.btnNext = new Syncfusion.WinForms.Controls.SfButton();
            this.lblQuestion = new System.Windows.Forms.Label();
            this.lblReason = new System.Windows.Forms.Label();
            this.flpOptions = new System.Windows.Forms.FlowLayoutPanel();
            this.tlpQuestionBlock = new System.Windows.Forms.TableLayoutPanel();
            this.tlpQuizBody = new System.Windows.Forms.TableLayoutPanel();
            this.pnlQuizCard = new System.Windows.Forms.Panel();
            this.btnLogout = new System.Windows.Forms.Button();
            this.lblUser = new System.Windows.Forms.Label();
            this.lblTimer = new System.Windows.Forms.Label();
            this.pnlTimer = new System.Windows.Forms.Panel();
            this.pnlHeaderRight = new System.Windows.Forms.Panel();
            this.lblQuizProgress = new System.Windows.Forms.Label();
            this.lblQuizTopicTitle = new System.Windows.Forms.Label();
            this.tlpHeader = new System.Windows.Forms.TableLayoutPanel();
            this.pnlHeaderLeft = new System.Windows.Forms.Panel();
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.tlpQuizPage = new System.Windows.Forms.TableLayoutPanel();
            this.pnlContent = new System.Windows.Forms.Panel();
            this.btnNavDashboard = new System.Windows.Forms.Button();
            this.btnNavQuiz = new System.Windows.Forms.Button();
            this.btnNavMiniGames = new System.Windows.Forms.Button();
            this.btnNavReports = new System.Windows.Forms.Button();
            this.btnNavLeaderboard = new System.Windows.Forms.Button();
            this.btnNavCommunity = new System.Windows.Forms.Button();
            this.btnNavSettings = new System.Windows.Forms.Button();
            this.lblMondas = new System.Windows.Forms.Label();
            this.flpNav = new System.Windows.Forms.FlowLayoutPanel();
            this.pnlSidebar = new System.Windows.Forms.Panel();
            this.flpQuizButtons.SuspendLayout();
            this.tlpQuestionBlock.SuspendLayout();
            this.tlpQuizBody.SuspendLayout();
            this.pnlQuizCard.SuspendLayout();
            this.pnlTimer.SuspendLayout();
            this.pnlHeaderRight.SuspendLayout();
            this.tlpHeader.SuspendLayout();
            this.pnlHeaderLeft.SuspendLayout();
            this.pnlHeader.SuspendLayout();
            this.tlpQuizPage.SuspendLayout();
            this.pnlContent.SuspendLayout();
            this.flpNav.SuspendLayout();
            this.pnlSidebar.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnPrevious
            // 
            this.btnPrevious.Font = new System.Drawing.Font("Muro", 20F);
            this.btnPrevious.Location = new System.Drawing.Point(466, 0);
            this.btnPrevious.Margin = new System.Windows.Forms.Padding(0, 0, 20, 0);
            this.btnPrevious.Name = "btnPrevious";
            this.btnPrevious.Size = new System.Drawing.Size(192, 70);
            this.btnPrevious.TabIndex = 1;
            this.btnPrevious.Text = "PREVIOUS";
            this.btnPrevious.Click += new System.EventHandler(this.btnPrevious_Click);
            // 
            // lblFeedback
            // 
            this.lblFeedback.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblFeedback.Font = new System.Drawing.Font("Agency", 10F);
            this.lblFeedback.ForeColor = System.Drawing.Color.DimGray;
            this.lblFeedback.Location = new System.Drawing.Point(0, 431);
            this.lblFeedback.Margin = new System.Windows.Forms.Padding(0, 8, 0, 8);
            this.lblFeedback.Name = "lblFeedback";
            this.lblFeedback.Size = new System.Drawing.Size(870, 26);
            this.lblFeedback.TabIndex = 3;
            this.lblFeedback.Text = "Feedback will show here.";
            this.lblFeedback.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblFeedback.Visible = false;
            // 
            // flpQuizButtons
            // 
            this.flpQuizButtons.Controls.Add(this.btnNext);
            this.flpQuizButtons.Controls.Add(this.btnPrevious);
            this.flpQuizButtons.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flpQuizButtons.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flpQuizButtons.Location = new System.Drawing.Point(0, 477);
            this.flpQuizButtons.Margin = new System.Windows.Forms.Padding(0, 12, 0, 0);
            this.flpQuizButtons.Name = "flpQuizButtons";
            this.flpQuizButtons.Size = new System.Drawing.Size(870, 70);
            this.flpQuizButtons.TabIndex = 4;
            this.flpQuizButtons.WrapContents = false;
            // 
            // btnNext
            // 
            this.btnNext.Font = new System.Drawing.Font("Muro", 20F);
            this.btnNext.Location = new System.Drawing.Point(678, 0);
            this.btnNext.Margin = new System.Windows.Forms.Padding(0);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(192, 70);
            this.btnNext.TabIndex = 0;
            this.btnNext.Text = "NEXT";
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // lblQuestion
            // 
            this.lblQuestion.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblQuestion.Font = new System.Drawing.Font("Agency", 17F);
            this.lblQuestion.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblQuestion.Location = new System.Drawing.Point(0, 0);
            this.lblQuestion.Margin = new System.Windows.Forms.Padding(0, 0, 0, 6);
            this.lblQuestion.Name = "lblQuestion";
            this.lblQuestion.Size = new System.Drawing.Size(870, 52);
            this.lblQuestion.TabIndex = 1;
            this.lblQuestion.Text = "WHICH OF THE FOLLOWING IS A COMMON SIGN OF A PHISHING EMAIL?";
            this.lblQuestion.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblReason
            // 
            this.lblReason.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblReason.Font = new System.Drawing.Font("Agency", 8F);
            this.lblReason.ForeColor = System.Drawing.Color.DimGray;
            this.lblReason.Location = new System.Drawing.Point(0, 58);
            this.lblReason.Margin = new System.Windows.Forms.Padding(0, 0, 0, 12);
            this.lblReason.Name = "lblReason";
            this.lblReason.Size = new System.Drawing.Size(870, 20);
            this.lblReason.TabIndex = 2;
            this.lblReason.Text = "Reason: (Enter reason here)";
            this.lblReason.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // flpOptions
            // 
            this.flpOptions.AutoScroll = true;
            this.flpOptions.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flpOptions.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flpOptions.Font = new System.Drawing.Font("Agency", 22F);
            this.flpOptions.Location = new System.Drawing.Point(0, 90);
            this.flpOptions.Margin = new System.Windows.Forms.Padding(0);
            this.flpOptions.Name = "flpOptions";
            this.flpOptions.Size = new System.Drawing.Size(870, 333);
            this.flpOptions.TabIndex = 1;
            this.flpOptions.WrapContents = false;
            // 
            // tlpQuestionBlock
            // 
            this.tlpQuestionBlock.ColumnCount = 1;
            this.tlpQuestionBlock.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpQuestionBlock.Controls.Add(this.lblQuestion, 0, 0);
            this.tlpQuestionBlock.Controls.Add(this.lblReason, 0, 1);
            this.tlpQuestionBlock.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpQuestionBlock.Location = new System.Drawing.Point(0, 0);
            this.tlpQuestionBlock.Margin = new System.Windows.Forms.Padding(0);
            this.tlpQuestionBlock.Name = "tlpQuestionBlock";
            this.tlpQuestionBlock.RowCount = 2;
            this.tlpQuestionBlock.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 65F));
            this.tlpQuestionBlock.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 35F));
            this.tlpQuestionBlock.Size = new System.Drawing.Size(870, 90);
            this.tlpQuestionBlock.TabIndex = 2;
            // 
            // tlpQuizBody
            // 
            this.tlpQuizBody.ColumnCount = 1;
            this.tlpQuizBody.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpQuizBody.Controls.Add(this.flpOptions, 0, 1);
            this.tlpQuizBody.Controls.Add(this.tlpQuestionBlock, 0, 0);
            this.tlpQuizBody.Controls.Add(this.lblFeedback, 0, 2);
            this.tlpQuizBody.Controls.Add(this.flpQuizButtons, 0, 3);
            this.tlpQuizBody.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpQuizBody.Location = new System.Drawing.Point(18, 18);
            this.tlpQuizBody.Margin = new System.Windows.Forms.Padding(0);
            this.tlpQuizBody.Name = "tlpQuizBody";
            this.tlpQuizBody.RowCount = 4;
            this.tlpQuizBody.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpQuizBody.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpQuizBody.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpQuizBody.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpQuizBody.Size = new System.Drawing.Size(870, 547);
            this.tlpQuizBody.TabIndex = 0;
            // 
            // pnlQuizCard
            // 
            this.pnlQuizCard.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlQuizCard.Controls.Add(this.tlpQuizBody);
            this.pnlQuizCard.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlQuizCard.Location = new System.Drawing.Point(0, 90);
            this.pnlQuizCard.Margin = new System.Windows.Forms.Padding(0);
            this.pnlQuizCard.Name = "pnlQuizCard";
            this.pnlQuizCard.Padding = new System.Windows.Forms.Padding(18);
            this.pnlQuizCard.Size = new System.Drawing.Size(908, 585);
            this.pnlQuizCard.TabIndex = 1;
            // 
            // btnLogout
            // 
            this.btnLogout.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLogout.BackColor = System.Drawing.Color.White;
            this.btnLogout.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.btnLogout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogout.Font = new System.Drawing.Font("Agency", 9F);
            this.btnLogout.Location = new System.Drawing.Point(150, 4);
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
            this.lblUser.Location = new System.Drawing.Point(23, 12);
            this.lblUser.Name = "lblUser";
            this.lblUser.Size = new System.Drawing.Size(121, 14);
            this.lblUser.TabIndex = 4;
            this.lblUser.Text = "ARJUN SINGH";
            // 
            // lblTimer
            // 
            this.lblTimer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTimer.Font = new System.Drawing.Font("Muro", 19F);
            this.lblTimer.Location = new System.Drawing.Point(0, 0);
            this.lblTimer.Name = "lblTimer";
            this.lblTimer.Size = new System.Drawing.Size(263, 43);
            this.lblTimer.TabIndex = 0;
            this.lblTimer.Text = "05:58";
            this.lblTimer.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // pnlTimer
            // 
            this.pnlTimer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlTimer.Controls.Add(this.lblTimer);
            this.pnlTimer.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlTimer.Location = new System.Drawing.Point(0, 33);
            this.pnlTimer.Name = "pnlTimer";
            this.pnlTimer.Size = new System.Drawing.Size(265, 45);
            this.pnlTimer.TabIndex = 6;
            // 
            // pnlHeaderRight
            // 
            this.pnlHeaderRight.Controls.Add(this.pnlTimer);
            this.pnlHeaderRight.Controls.Add(this.btnLogout);
            this.pnlHeaderRight.Controls.Add(this.lblUser);
            this.pnlHeaderRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlHeaderRight.Location = new System.Drawing.Point(634, 3);
            this.pnlHeaderRight.Name = "pnlHeaderRight";
            this.pnlHeaderRight.Size = new System.Drawing.Size(265, 78);
            this.pnlHeaderRight.TabIndex = 1;
            // 
            // lblQuizProgress
            // 
            this.lblQuizProgress.AutoSize = true;
            this.lblQuizProgress.BackColor = System.Drawing.Color.White;
            this.lblQuizProgress.Font = new System.Drawing.Font("Agency", 12F);
            this.lblQuizProgress.Location = new System.Drawing.Point(5, 55);
            this.lblQuizProgress.Name = "lblQuizProgress";
            this.lblQuizProgress.Size = new System.Drawing.Size(198, 18);
            this.lblQuizProgress.TabIndex = 1;
            this.lblQuizProgress.Text = "QUESTION 1 OF 10";
            // 
            // lblQuizTopicTitle
            // 
            this.lblQuizTopicTitle.AutoSize = true;
            this.lblQuizTopicTitle.Font = new System.Drawing.Font("Muro", 24F);
            this.lblQuizTopicTitle.Location = new System.Drawing.Point(0, 0);
            this.lblQuizTopicTitle.Name = "lblQuizTopicTitle";
            this.lblQuizTopicTitle.Size = new System.Drawing.Size(367, 48);
            this.lblQuizTopicTitle.TabIndex = 0;
            this.lblQuizTopicTitle.Text = "PHISHING ATTACKS";
            // 
            // tlpHeader
            // 
            this.tlpHeader.ColumnCount = 2;
            this.tlpHeader.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 70F));
            this.tlpHeader.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tlpHeader.Controls.Add(this.pnlHeaderLeft, 0, 0);
            this.tlpHeader.Controls.Add(this.pnlHeaderRight, 1, 0);
            this.tlpHeader.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpHeader.Location = new System.Drawing.Point(0, 0);
            this.tlpHeader.Name = "tlpHeader";
            this.tlpHeader.RowCount = 1;
            this.tlpHeader.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpHeader.Size = new System.Drawing.Size(902, 84);
            this.tlpHeader.TabIndex = 0;
            // 
            // pnlHeaderLeft
            // 
            this.pnlHeaderLeft.Controls.Add(this.lblQuizProgress);
            this.pnlHeaderLeft.Controls.Add(this.lblQuizTopicTitle);
            this.pnlHeaderLeft.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlHeaderLeft.Location = new System.Drawing.Point(3, 3);
            this.pnlHeaderLeft.Name = "pnlHeaderLeft";
            this.pnlHeaderLeft.Size = new System.Drawing.Size(625, 78);
            this.pnlHeaderLeft.TabIndex = 0;
            // 
            // pnlHeader
            // 
            this.pnlHeader.Controls.Add(this.tlpHeader);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlHeader.Location = new System.Drawing.Point(3, 3);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(902, 84);
            this.pnlHeader.TabIndex = 0;
            // 
            // tlpQuizPage
            // 
            this.tlpQuizPage.ColumnCount = 1;
            this.tlpQuizPage.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpQuizPage.Controls.Add(this.pnlHeader, 0, 0);
            this.tlpQuizPage.Controls.Add(this.pnlQuizCard, 0, 1);
            this.tlpQuizPage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpQuizPage.Location = new System.Drawing.Point(16, 16);
            this.tlpQuizPage.Margin = new System.Windows.Forms.Padding(0);
            this.tlpQuizPage.Name = "tlpQuizPage";
            this.tlpQuizPage.RowCount = 3;
            this.tlpQuizPage.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpQuizPage.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpQuizPage.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpQuizPage.Size = new System.Drawing.Size(908, 675);
            this.tlpQuizPage.TabIndex = 0;
            // 
            // pnlContent
            // 
            this.pnlContent.Controls.Add(this.tlpQuizPage);
            this.pnlContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlContent.Location = new System.Drawing.Point(242, 2);
            this.pnlContent.Name = "pnlContent";
            this.pnlContent.Padding = new System.Windows.Forms.Padding(16);
            this.pnlContent.Size = new System.Drawing.Size(940, 707);
            this.pnlContent.TabIndex = 5;
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
            this.btnNavQuiz.Click += new System.EventHandler(this.btnNavQuiz_Click);
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
            this.btnNavMiniGames.Click += new System.EventHandler(this.btnNavMiniGames_Click);
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
            this.btnNavReports.Click += new System.EventHandler(this.btnNavReports_Click);
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
            this.btnNavLeaderboard.Click += new System.EventHandler(this.btnNavLeaderboard_Click);
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
            this.btnNavCommunity.Click += new System.EventHandler(this.btnNavCommunity_Click);
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
            this.btnNavSettings.Click += new System.EventHandler(this.btnNavSettings_Click);
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
            this.flpNav.Size = new System.Drawing.Size(240, 707);
            this.flpNav.TabIndex = 1;
            this.flpNav.WrapContents = false;
            // 
            // pnlSidebar
            // 
            this.pnlSidebar.BackColor = System.Drawing.Color.RoyalBlue;
            this.pnlSidebar.Controls.Add(this.lblMondas);
            this.pnlSidebar.Controls.Add(this.flpNav);
            this.pnlSidebar.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlSidebar.Location = new System.Drawing.Point(2, 2);
            this.pnlSidebar.Name = "pnlSidebar";
            this.pnlSidebar.Size = new System.Drawing.Size(240, 707);
            this.pnlSidebar.TabIndex = 4;
            // 
            // QuizForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1184, 711);
            this.Controls.Add(this.pnlContent);
            this.Controls.Add(this.pnlSidebar);
            this.MinimumSize = new System.Drawing.Size(1200, 750);
            this.Name = "QuizForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Style.MdiChild.IconHorizontalAlignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.Style.MdiChild.IconVerticalAlignment = System.Windows.Forms.VisualStyles.VerticalAlignment.Center;
            this.Text = "QUIZ | Mondas";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.QuizFormTemp_Load);
            this.flpQuizButtons.ResumeLayout(false);
            this.tlpQuestionBlock.ResumeLayout(false);
            this.tlpQuizBody.ResumeLayout(false);
            this.pnlQuizCard.ResumeLayout(false);
            this.pnlTimer.ResumeLayout(false);
            this.pnlHeaderRight.ResumeLayout(false);
            this.pnlHeaderRight.PerformLayout();
            this.tlpHeader.ResumeLayout(false);
            this.pnlHeaderLeft.ResumeLayout(false);
            this.pnlHeaderLeft.PerformLayout();
            this.pnlHeader.ResumeLayout(false);
            this.tlpQuizPage.ResumeLayout(false);
            this.pnlContent.ResumeLayout(false);
            this.flpNav.ResumeLayout(false);
            this.pnlSidebar.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Syncfusion.WinForms.Controls.SfButton btnPrevious;
        private System.Windows.Forms.Label lblFeedback;
        private System.Windows.Forms.FlowLayoutPanel flpQuizButtons;
        private Syncfusion.WinForms.Controls.SfButton btnNext;
        private System.Windows.Forms.Label lblQuestion;
        private System.Windows.Forms.Label lblReason;
        private System.Windows.Forms.FlowLayoutPanel flpOptions;
        private System.Windows.Forms.TableLayoutPanel tlpQuestionBlock;
        private System.Windows.Forms.TableLayoutPanel tlpQuizBody;
        private System.Windows.Forms.Panel pnlQuizCard;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.Label lblUser;
        private System.Windows.Forms.Label lblTimer;
        private System.Windows.Forms.Panel pnlTimer;
        private System.Windows.Forms.Panel pnlHeaderRight;
        private System.Windows.Forms.Label lblQuizProgress;
        private System.Windows.Forms.Label lblQuizTopicTitle;
        private System.Windows.Forms.TableLayoutPanel tlpHeader;
        private System.Windows.Forms.Panel pnlHeaderLeft;
        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.TableLayoutPanel tlpQuizPage;
        private System.Windows.Forms.Panel pnlContent;
        private System.Windows.Forms.Button btnNavDashboard;
        private System.Windows.Forms.Button btnNavQuiz;
        private System.Windows.Forms.Button btnNavMiniGames;
        private System.Windows.Forms.Button btnNavReports;
        private System.Windows.Forms.Button btnNavLeaderboard;
        private System.Windows.Forms.Button btnNavCommunity;
        private System.Windows.Forms.Button btnNavSettings;
        private System.Windows.Forms.Label lblMondas;
        private System.Windows.Forms.FlowLayoutPanel flpNav;
        private System.Windows.Forms.Panel pnlSidebar;
    }
}