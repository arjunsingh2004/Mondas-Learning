using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using Syncfusion.WinForms.Controls;

namespace Mondas
{
    public partial class Start : SfForm
    {
        TableLayoutPanel root;
        Panel leftPane;
        Panel rightPane;
        TableLayoutPanel formGrid;

        Label title;
        Label subtitle;
        Label footer;

        TextBox txtEmail;
        TextBox txtPassword;
        CheckBox chkRemember;

        Button btnSignIn;
        Button btnGoogle;
        Button btnSignUp;
        Button btnForgot;

        public Start()
        {
            InitializeComponent();
            ConfigureForm();
            BuildUI();
            Wire();
        }

        void ConfigureForm()
        {
            AutoScaleMode = AutoScaleMode.Dpi;
            DoubleBuffered = true;
            StartPosition = FormStartPosition.CenterScreen;
            MinimumSize = new Size(980, 600);
            Size = new Size(1180, 720);
            Text = "Welcome | Mondas";
            BackColor = Color.White;
            Style.TitleBar.BackColor = Color.FromArgb(42, 101, 255);
            Style.TitleBar.ForeColor = Color.White;
            Style.TitleBar.TextHorizontalAlignment = HorizontalAlignment.Center;
            ShowIcon = false;
        }

        void BuildUI()
        {
            Controls.Clear();

            root = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                ColumnCount = 2,
                RowCount = 1,
                BackColor = Color.White
            };
            root.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 44f));
            root.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 56f));
            Controls.Add(root);

            leftPane = new Panel { Dock = DockStyle.Fill, Padding = new Padding(48, 48, 24, 24) };
            leftPane.Paint += LeftPane_Paint;
            root.Controls.Add(leftPane, 0, 0);

            var leftStack = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                ColumnCount = 1,
                RowCount = 3,
                BackColor = Color.Transparent,
                Padding = new Padding(0, 0, 0, 0)
            };
            leftStack.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100f));
            leftStack.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            leftStack.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            leftStack.RowStyles.Add(new RowStyle(SizeType.Percent, 100f));
            leftPane.Controls.Add(leftStack);

            title = new Label
            {
                Text = "Welcome to Mondas",
                Font = new Font("Segoe UI Semibold", 36f, FontStyle.Bold),
                ForeColor = Color.White,
                AutoSize = true,
                Margin = new Padding(0, 0, 0, 8),
                Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right
            };
            leftStack.Controls.Add(title, 0, 0);

            subtitle = new Label
            {
                Text = "Please sign in to continue",
                Font = new Font("Segoe UI", 13f),
                ForeColor = Color.FromArgb(230, 245, 255),
                AutoSize = true,
                Margin = new Padding(0, 0, 0, 0),
                Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right
            };
            leftStack.Controls.Add(subtitle, 0, 1);

            footer = new Label
            {
                Text = $"© {DateTime.Now.Year} Mondas Learning",
                Font = new Font("Segoe UI", 7f, FontStyle.Italic),
                ForeColor = Color.White,
                BackColor = Color.Transparent,
                AutoSize = true
            };
            leftPane.Controls.Add(footer);
            leftPane.Resize += (s, e) =>
            {
                footer.Location = new Point(10, leftPane.ClientSize.Height - footer.Height - 10);
                UpdateHeroWrap();
            };

            rightPane = new Panel { Dock = DockStyle.Fill, Padding = new Padding(24) };
            root.Controls.Add(rightPane, 1, 0);

            var card = new Panel { Dock = DockStyle.Fill, BackColor = Color.White, Padding = new Padding(28) };
            card.Paint += Card_Paint;
            rightPane.Controls.Add(card);

            formGrid = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                ColumnCount = 2,
                RowCount = 9,
                AutoSize = false
            };
            formGrid.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50f));
            formGrid.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50f));
            formGrid.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            formGrid.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            formGrid.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            formGrid.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            formGrid.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            formGrid.RowStyles.Add(new RowStyle(SizeType.Absolute, 52));
            formGrid.RowStyles.Add(new RowStyle(SizeType.Absolute, 48));
            formGrid.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            formGrid.RowStyles.Add(new RowStyle(SizeType.Percent, 100f));
            card.Controls.Add(formGrid);

            var hdr = new Label
            {
                Text = "Get started",
                Font = new Font("Segoe UI Semibold", 24f, FontStyle.Bold),
                ForeColor = Color.FromArgb(34, 34, 34),
                AutoSize = true,
                Margin = new Padding(0, 0, 0, 2),
                Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top
            };
            formGrid.Controls.Add(hdr, 0, 0);
            formGrid.SetColumnSpan(hdr, 2);

            var hint = new Label
            {
                Text = "Sign in or create your Mondas account to continue.",
                Font = new Font("Segoe UI", 10.5f),
                ForeColor = Color.Gray,
                AutoSize = true,
                Margin = new Padding(0, 0, 0, 12),
                Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top
            };
            formGrid.Controls.Add(hint, 0, 1);
            formGrid.SetColumnSpan(hint, 2);

            txtEmail = MakeTextBox("Email address");
            txtPassword = MakeTextBox("Password");
            txtPassword.Tag = new PlaceholderState { Text = "Password", IsPassword = true };
            SetPlaceholder(txtPassword);
            txtPassword.GotFocus += (s, e) => RemovePlaceholder(txtPassword);
            txtPassword.LostFocus += (s, e) => { if (string.IsNullOrEmpty(txtPassword.Text)) SetPlaceholder(txtPassword); };
            txtPassword.UseSystemPasswordChar = true;

            formGrid.Controls.Add(txtEmail, 0, 2);
            formGrid.SetColumnSpan(txtEmail, 2);
            formGrid.Controls.Add(txtPassword, 0, 3);
            formGrid.SetColumnSpan(txtPassword, 2);

            chkRemember = new CheckBox
            {
                Text = "Remember me",
                Font = new Font("Segoe UI", 10f),
                AutoSize = true,
                Margin = new Padding(2, 6, 0, 0),
                Anchor = AnchorStyles.Left | AnchorStyles.Top
            };
            formGrid.Controls.Add(chkRemember, 0, 4);

            btnForgot = MakeLinkButton("Forgot Password?");
            btnForgot.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            formGrid.Controls.Add(btnForgot, 1, 4);

            btnSignIn = MakePrimaryButton("Sign In");
            formGrid.Controls.Add(btnSignIn, 0, 5);
            formGrid.SetColumnSpan(btnSignIn, 2);

            btnGoogle = MakeOutlinedButton("Login with Google");
            formGrid.Controls.Add(btnGoogle, 0, 6);
            formGrid.SetColumnSpan(btnGoogle, 2);

            btnSignUp = MakeLinkButton("Sign Up");
            btnSignUp.TextAlign = ContentAlignment.MiddleCenter;
            btnSignUp.Anchor = AnchorStyles.Top;
            formGrid.Controls.Add(btnSignUp, 0, 7);
            formGrid.SetColumnSpan(btnSignUp, 2);

            AcceptButton = btnSignIn;

            UpdateHeroWrap();
        }

        void UpdateHeroWrap()
        {
            int w = Math.Max(200, leftPane.ClientSize.Width - leftPane.Padding.Horizontal);
            title.MaximumSize = new Size(w, 0);
            subtitle.MaximumSize = new Size(w, 0);
        }

        void Wire()
        {
            AttachPlaceholder(txtEmail, "Email address", false);
            btnSignIn.Click += (s, e) =>
            {
                var email = GetValue(txtEmail);
                var pwd = GetValue(txtPassword);
                if (string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(pwd))
                {
                    MessageBox.Show(this, "Please enter both your email and password.", "Mondas",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                btnSignIn.Enabled = false;
                btnSignIn.Text = "Signing in…";
                var t = new Timer { Interval = 900 };
                t.Tick += (s2, e2) =>
                {
                    t.Stop();
                    btnSignIn.Enabled = true;
                    btnSignIn.Text = "Sign In";
                    MessageBox.Show(this, $"Welcome back, {email}!", "Mondas",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                };
                t.Start();
            };
        }

        TextBox MakeTextBox(string placeholder)
        {
            var tb = new TextBox
            {
                Font = new Font("Segoe UI", 10.5f),
                Dock = DockStyle.Fill,
                Margin = new Padding(0, 6, 0, 0),
                AutoSize = false,
                MinimumSize = new Size(0, 40)
            };
            AttachPlaceholder(tb, placeholder, false);
            return tb;
        }

        Button MakePrimaryButton(string text)
        {
            var b = new Button
            {
                Text = text,
                Font = new Font("Segoe UI Semibold", 11f, FontStyle.Bold),
                BackColor = Color.FromArgb(42, 101, 255),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Dock = DockStyle.Fill,
                MinimumSize = new Size(0, 46),
                Margin = new Padding(0, 14, 0, 10)
            };
            b.FlatAppearance.BorderSize = 0;
            b.FlatAppearance.MouseOverBackColor = Color.FromArgb(33, 80, 200);
            b.FlatAppearance.MouseDownBackColor = Color.FromArgb(28, 70, 180);
            return b;
        }

        Button MakeOutlinedButton(string text)
        {
            var b = new Button
            {
                Text = text,
                Font = new Font("Segoe UI", 10f),
                BackColor = Color.White,
                ForeColor = Color.Black,
                FlatStyle = FlatStyle.Flat,
                Dock = DockStyle.Fill,
                MinimumSize = new Size(0, 44),
                Margin = new Padding(0, 0, 0, 10)
            };
            b.FlatAppearance.BorderColor = Color.Silver;
            b.FlatAppearance.BorderSize = 1;
            b.FlatAppearance.MouseOverBackColor = Color.Gainsboro;
            b.FlatAppearance.MouseDownBackColor = Color.Silver;
            return b;
        }

        Button MakeLinkButton(string text)
        {
            var b = new Button
            {
                Text = text,
                Font = new Font("Segoe UI", 10f),
                BackColor = Color.White,
                ForeColor = Color.FromArgb(42, 101, 255),
                FlatStyle = FlatStyle.Flat,
                AutoSize = true,
                Margin = new Padding(0, 6, 0, 0)
            };
            b.FlatAppearance.BorderSize = 0;
            b.FlatAppearance.MouseOverBackColor = Color.White;
            b.FlatAppearance.MouseDownBackColor = Color.White;
            return b;
        }

        void LeftPane_Paint(object sender, PaintEventArgs e)
        {
            var g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;
            var rect = leftPane.ClientRectangle;
            using (var lg = new LinearGradientBrush(rect, Color.Empty, Color.Empty, 22f))
            {
                var cb = new ColorBlend
                {
                    Colors = new[]
                    {
                        Color.FromArgb(56,118,255),
                        Color.FromArgb(76,138,255),
                        Color.FromArgb(104,160,255)
                    },
                    Positions = new[] { 0f, .55f, 1f }
                };
                lg.InterpolationColors = cb;
                g.FillRectangle(lg, rect);
            }
            int h = Math.Max(160, rect.Height / 3);
            var waveRect = new Rectangle(0, rect.Bottom - h, rect.Width, h);
            using (var path = new GraphicsPath())
            {
                path.AddBezier(new Point(0, waveRect.Top + h / 3),
                               new Point(rect.Width / 4, waveRect.Top),
                               new Point(rect.Width / 2, waveRect.Bottom),
                               new Point(rect.Width, waveRect.Top + h / 2));
                path.AddLine(rect.Width, rect.Bottom, 0, rect.Bottom);
                path.CloseFigure();
                using (var br = new LinearGradientBrush(waveRect, Color.FromArgb(36, Color.White), Color.FromArgb(12, Color.White), 90f))
                    g.FillPath(br, path);
            }
        }

        void Card_Paint(object sender, PaintEventArgs e)
        {
            var g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;
            var r = ((Control)sender).ClientRectangle;
            var rect = new Rectangle(r.X, r.Y, r.Width - 1, r.Height - 1);
            using (var path = Rounded(rect, 18))
            using (var br = new SolidBrush(Color.White))
            using (var pen = new Pen(Color.FromArgb(240, 242, 247)))
            {
                using (var shadowPath = Rounded(new Rectangle(rect.X + 2, rect.Y + 8, rect.Width, rect.Height), 22))
                using (var pgb = new PathGradientBrush(shadowPath))
                {
                    pgb.CenterColor = Color.FromArgb(36, 0, 0, 0);
                    pgb.SurroundColors = new[] { Color.FromArgb(0, 0, 0, 0) };
                    g.FillPath(pgb, shadowPath);
                }
                g.FillPath(br, path);
                g.DrawPath(pen, path);
            }
        }

        GraphicsPath Rounded(Rectangle bounds, int radius)
        {
            int d = radius * 2;
            var path = new GraphicsPath();
            path.AddArc(bounds.X, bounds.Y, d, d, 180, 90);
            path.AddArc(bounds.Right - d, bounds.Y, d, d, 270, 90);
            path.AddArc(bounds.Right - d, bounds.Bottom - d, d, d, 0, 90);
            path.AddArc(bounds.X, bounds.Bottom - d, d, d, 90, 90);
            path.CloseFigure();
            return path;
        }

        sealed class PlaceholderState { public string Text; public bool IsPassword; }

        void AttachPlaceholder(TextBox tb, string text, bool isPassword)
        {
            tb.Tag = new PlaceholderState { Text = text, IsPassword = isPassword };
            SetPlaceholder(tb);
            tb.GotFocus += (s, e) => RemovePlaceholder(tb);
            tb.LostFocus += (s, e) => { if (string.IsNullOrEmpty(tb.Text)) SetPlaceholder(tb); };
            tb.KeyDown += (s, e) => { if (e.KeyCode == Keys.Enter) btnSignIn.PerformClick(); };
        }

        void SetPlaceholder(TextBox tb)
        {
            var st = (PlaceholderState)tb.Tag;
            tb.ForeColor = Color.FromArgb(150, 160, 170);
            tb.Text = st.Text;
            tb.UseSystemPasswordChar = false;
        }

        void RemovePlaceholder(TextBox tb)
        {
            var st = (PlaceholderState)tb.Tag;
            if (tb.ForeColor.ToArgb() == Color.FromArgb(150, 160, 170).ToArgb() && tb.Text == st.Text)
            {
                tb.Text = string.Empty;
                tb.ForeColor = Color.Black;
                tb.UseSystemPasswordChar = st.IsPassword;
            }
        }

        string GetValue(TextBox tb)
        {
            bool isPlaceholder = tb.ForeColor.ToArgb() == Color.FromArgb(150, 160, 170).ToArgb();
            return isPlaceholder ? string.Empty : tb.Text;
        }

        void Start_Load(object sender, EventArgs e) { }
        void label1_Click(object sender, EventArgs e) { }
        void label3_Click(object sender, EventArgs e) { }
        void textBoxExt2_TextChanged(object sender, EventArgs e) { }
        void checkBoxAdv1_CheckStateChanged(object sender, EventArgs e) { }
        void sfButton1_Click(object sender, EventArgs e) { }
    }
}
