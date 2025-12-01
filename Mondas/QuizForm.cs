using System;
using System.Diagnostics;
using System.Linq;
using System.Windows.Forms;
using Mondas.Contracts.Services;
using Mondas.Models;
using Mondas.Services;
using Syncfusion.WinForms.Controls;

namespace Mondas
{
    public partial class QuizForm : SfForm
    {
        TableLayoutPanel root;
        Panel card;
        Label lblHeader;
        Label lblQuestion;
        Label lblReason;
        Label lblProgress;
        FlowLayoutPanel optionsPanel;
        Button btnSubmit;
        Button btnClose;

        QuizSession session;
        SelectionResult currentSelection;
        Question currentQuestion;
        Stopwatch stopwatch = new Stopwatch();
        int questionsAsked = 0;
        int maxQuestions = 10;

        public QuizForm()
        {
            InitializeComponent();
            ConfigureForm();
            BuildUI();
            InitSession();
        }

        void ConfigureForm()
        {
            AutoScaleMode = AutoScaleMode.Dpi;
            StartPosition = FormStartPosition.CenterScreen;
            MinimumSize = new System.Drawing.Size(800, 500);
            Text = "Quiz | Mondas";
        }

        void BuildUI()
        {
            Controls.Clear();

            root = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                ColumnCount = 1,
                RowCount = 1,
                BackColor = System.Drawing.Color.FromArgb(245, 247, 252)
            };
            root.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100f));
            Controls.Add(root);

            card = new Panel
            {
                Dock = DockStyle.Fill,
                Padding = new Padding(24),
                BackColor = System.Drawing.Color.White
            };
            root.Controls.Add(card, 0, 0);

            var grid = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                ColumnCount = 1,
                RowCount = 5
            };
            grid.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            grid.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            grid.RowStyles.Add(new RowStyle(SizeType.Percent, 100f));
            grid.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            grid.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            card.Controls.Add(grid);

            lblHeader = new Label
            {
                Text = "Cyber Awareness Quiz",
                Font = new System.Drawing.Font("Segoe UI Semibold", 20f),
                AutoSize = true
            };
            grid.Controls.Add(lblHeader, 0, 0);

            lblProgress = new Label
            {
                Text = "Question 0 of 0",
                Font = new System.Drawing.Font("Segoe UI", 10f),
                ForeColor = System.Drawing.Color.Gray,
                AutoSize = true,
                Margin = new Padding(0, 4, 0, 12)
            };
            grid.Controls.Add(lblProgress, 0, 1);

            lblQuestion = new Label
            {
                Text = "Question text...",
                Font = new System.Drawing.Font("Segoe UI", 12.5f),
                AutoSize = false,
                Dock = DockStyle.Top,
                Height = 80
            };
            grid.Controls.Add(lblQuestion, 0, 2);

            optionsPanel = new FlowLayoutPanel
            {
                Dock = DockStyle.Fill,
                FlowDirection = FlowDirection.TopDown,
                WrapContents = false,
                AutoScroll = true,
                Margin = new Padding(0, 8, 0, 8)
            };
            grid.Controls.Add(optionsPanel, 0, 3);

            lblReason = new Label
            {
                Text = "Why this question: ",
                Font = new System.Drawing.Font("Segoe UI", 9f),
                ForeColor = System.Drawing.Color.Gray,
                AutoSize = true,
                Margin = new Padding(0, 4, 0, 4)
            };
            grid.Controls.Add(lblReason, 0, 4);

            var buttonRow = new FlowLayoutPanel
            {
                Dock = DockStyle.Bottom,
                FlowDirection = FlowDirection.RightToLeft,
                Height = 48
            };
            card.Controls.Add(buttonRow);

            btnSubmit = new Button
            {
                Text = "Submit",
                Font = new System.Drawing.Font("Segoe UI Semibold", 10.5f),
                AutoSize = true,
                Margin = new Padding(6)
            };
            btnSubmit.Click += BtnSubmit_Click;
            buttonRow.Controls.Add(btnSubmit);

            btnClose = new Button
            {
                Text = "Close",
                Font = new System.Drawing.Font("Segoe UI", 10f),
                AutoSize = true,
                Margin = new Padding(6)
            };
            btnClose.Click += (s, e) => Close();
            buttonRow.Controls.Add(btnClose);

            AcceptButton = btnSubmit;
        }

        void InitSession()
        {
            var baseDir = AppDomain.CurrentDomain.BaseDirectory;
            var path = System.IO.Path.Combine(baseDir, "Resources", "questions.json");

            var repo = new JsonQuestionRepository(path);
            var questions = repo.GetAllQuestions();

            if (questions.Count == 0)
            {
                MessageBox.Show(this, "No questions found. Check questions.json.", "Mondas",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                Close();
                return;
            }

            var userModel = new UserModel();
            IRuleEngine ruleEngine = new RuleEngineV1();
            session = new QuizSession(questions, ruleEngine, userModel);

            lblProgress.Text = $"Question 0 of {maxQuestions}";
            LoadNextQuestion();
        }

        void LoadNextQuestion()
        {
            if (questionsAsked >= maxQuestions)
            {
                ShowSummaryAndClose();
                return;
            }

            currentSelection = session.GetNextQuestion();
            currentQuestion = currentSelection.SelectedQuestion;
            questionsAsked++;

            lblQuestion.Text = currentQuestion.Text;
            lblProgress.Text = $"Question {questionsAsked} of {maxQuestions}";
            lblReason.Text = "Why this question: " + currentSelection.ReasonString;

            optionsPanel.Controls.Clear();

            bool singleChoice = currentQuestion.Metadata.QuestionType == QuestionType.SingleChoice
                                || currentQuestion.Metadata.QuestionType == QuestionType.TrueFalse;

            if (singleChoice)
            {
                foreach (var opt in currentQuestion.Options)
                {
                    var rb = new RadioButton
                    {
                        Text = opt.Text,
                        Tag = opt.Id,
                        AutoSize = true,
                        Font = new System.Drawing.Font("Segoe UI", 10.5f),
                        Margin = new Padding(0, 4, 0, 4)
                    };
                    optionsPanel.Controls.Add(rb);
                }
            }
            else
            {
                foreach (var opt in currentQuestion.Options)
                {
                    var cb = new CheckBox
                    {
                        Text = opt.Text,
                        Tag = opt.Id,
                        AutoSize = true,
                        Font = new System.Drawing.Font("Segoe UI", 10.5f),
                        Margin = new Padding(0, 4, 0, 4)
                    };
                    optionsPanel.Controls.Add(cb);
                }
            }

            stopwatch.Restart();
        }

        void BtnSubmit_Click(object sender, EventArgs e)
        {
            if (currentQuestion == null) return;

            bool singleChoice = currentQuestion.Metadata.QuestionType == QuestionType.SingleChoice
                                || currentQuestion.Metadata.QuestionType == QuestionType.TrueFalse;

            var selectedIds = singleChoice
                ? optionsPanel.Controls.OfType<RadioButton>()
                    .Where(rb => rb.Checked)
                    .Select(rb => (int)rb.Tag)
                    .ToList()
                : optionsPanel.Controls.OfType<CheckBox>()
                    .Where(cb => cb.Checked)
                    .Select(cb => (int)cb.Tag)
                    .ToList();

            if (!selectedIds.Any())
            {
                MessageBox.Show(this, "Please select an answer.", "Mondas",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            stopwatch.Stop();

            var correctIds = currentQuestion.Options
                .Where(o => o.IsCorrect)
                .Select(o => o.Id)
                .OrderBy(id => id)
                .ToList();

            var chosenSorted = selectedIds.OrderBy(id => id).ToList();
            bool isCorrect = correctIds.SequenceEqual(chosenSorted);

            var attempt = new QuestionAttempt
            {
                QuestionId = currentQuestion.Id,
                StartedAt = DateTime.UtcNow - stopwatch.Elapsed,
                SubmittedAt = DateTime.UtcNow,
                IsCorrect = isCorrect,
                SelectedOptionIds = selectedIds,
                ReasonString = currentSelection.ReasonString,
                RulesFired = currentSelection.RulesFired
            };

            session.RecordAttempt(currentQuestion, attempt);

            MessageBox.Show(this,
                isCorrect ? "Correct ✅" : "Incorrect ❌",
                "Mondas",
                MessageBoxButtons.OK,
                isCorrect ? MessageBoxIcon.Information : MessageBoxIcon.Warning);

            LoadNextQuestion();
        }

        void ShowSummaryAndClose()
        {
            var attempts = session.Attempts;
            int total = attempts.Count;
            int correct = attempts.Count(a => a.IsCorrect);
            double percent = total == 0 ? 0 : correct * 100.0 / total;

            MessageBox.Show(this,
                $"Quiz complete!\n\nCorrect: {correct}/{total} ({percent:0}%)",
                "Mondas",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);

            Close();
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Name = "QuizForm";
            this.Style.MdiChild.IconHorizontalAlignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.Style.MdiChild.IconVerticalAlignment = System.Windows.Forms.VisualStyles.VerticalAlignment.Center;
            this.Load += new System.EventHandler(this.QuizForm_Load);
            this.ResumeLayout(false);

        }

        private void QuizForm_Load(object sender, EventArgs e)
        {

        }
    }
}