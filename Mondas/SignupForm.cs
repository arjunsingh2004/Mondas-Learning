using Syncfusion.WinForms.Controls;
using System;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using Mondas.Services;

namespace Mondas
{
    public partial class SignupForm : SfForm
    {
        private readonly SqliteUserRepository _users;
        private readonly PasswordHasher _hasher;

        public SignupForm()
        {
            InitializeComponent();

            var dbPath = Path.Combine(AppContext.BaseDirectory, "mondas.db");
            _users = new SqliteUserRepository(dbPath);
            _hasher = new PasswordHasher();
        }

        private void SignupForm_Load(object sender, EventArgs e)
        {
            WirePlaceholder(txtFullName, "FULL NAME", false);
            WirePlaceholder(txtEmail, "EMAIL ADDRESS", false);
            WirePlaceholder(txtPassword, "PASSWORD", true);
            WirePlaceholder(txtConfirmPassword, "CONFIRM PASSWORD", true);
        }

        private void btnSignUp_Click(object sender, EventArgs e)
        {
            var fullName = ReadValue(txtFullName, "FULL NAME");
            var email = ReadValue(txtEmail, "EMAIL ADDRESS");
            var password = ReadValue(txtPassword, "PASSWORD");
            var confirm = ReadValue(txtConfirmPassword, "CONFIRM PASSWORD");

            if (string.IsNullOrWhiteSpace(fullName) || string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(password) || string.IsNullOrWhiteSpace(confirm))
            {
                MessageBox.Show(this, "Fill in all fields.", "Mondas", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!email.Contains("@") || !email.Contains("."))
            {
                MessageBox.Show(this, "Enter a valid email address.", "Mondas", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (password.Length < 8)
            {
                MessageBox.Show(this, "Password must be at least 8 characters.", "Mondas", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (password != confirm)
            {
                MessageBox.Show(this, "Passwords do not match.", "Mondas", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (chkTerms != null && !chkTerms.Checked)
            {
                MessageBox.Show(this, "You must accept the terms to continue.", "Mondas", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                var cleanEmail = (email ?? "").Trim().ToLowerInvariant();

                if (_users.EmailExists(cleanEmail))
                {
                    MessageBox.Show(this, "An account already exists with that email", "Mondas", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                string secretBase32;

                using (var setup = new TotpSetupForm(cleanEmail))
                {
                    var result = setup.ShowDialog(this);
                    
                    if (result != DialogResult.OK)
                    {
                        MessageBox.Show(this, "2FA setup was cancelled. Account not created.", "Mondas", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }

                    secretBase32 = setup.GetVerifiedSecretBase32();
                }
            
                if (string.IsNullOrWhiteSpace(secretBase32))
                {
                    MessageBox.Show(this, "2FA setup failed. Account not created.", "Mondas", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                var hashResult = _hasher.Hash(password);

                var userId = _users.CreateUser(fullName.Trim(), cleanEmail, hashResult.HashBase64, hashResult.SaltBase64, hashResult.Iterations);

                _users.SetTotp(userId, secretBase32, true);

                MessageBox.Show(this, "Account created!", "Mondas", MessageBoxButtons.OK, MessageBoxIcon.Information);

                DialogResult = DialogResult.OK;
                Close();
                return;
            }

            catch (Exception ex)
            {
                MessageBox.Show(this, "Signup failed: " + ex.Message, "Mondas", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void lnkSignIn_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    
        private void WirePlaceholder(TextBox tb, string placeholder, bool isPassword)
        {
            if (tb == null)
            {
                return;
            }

            tb.Text = placeholder;
            tb.ForeColor = Color.Gray;
            tb.UseSystemPasswordChar = false;

            tb.GotFocus += (s, e) =>
            {
                if (tb.Text == placeholder && tb.ForeColor == Color.Gray)
                {
                    tb.Text = "";
                    tb.ForeColor = Color.Black;
                    tb.UseSystemPasswordChar = isPassword;
                }
            };

            tb.LostFocus += (s, e) =>
            {
                if (string.IsNullOrWhiteSpace(tb.Text))
                {
                    tb.UseSystemPasswordChar = false;
                    tb.Text = placeholder;
                    tb.ForeColor = Color.Gray;
                }
            };
        }
    
        private string ReadValue(TextBox tb, string placeholder)
        {
            if (tb == null)
            {
                return "";
            }

            if (tb.Text == placeholder && tb.ForeColor == Color.Gray)
            {
                return "";
            }

            return (tb.Text ?? "").Trim();
        }
    }
}