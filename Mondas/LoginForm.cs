using Syncfusion.WinForms.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Mondas.Services;
using Mondas.Contracts.Services;
using System.Linq.Expressions;

namespace Mondas
{
    public partial class LoginForm : SfForm
    {
        private readonly SqliteUserRepository _users;
        private readonly PasswordHasher _hasher;
        private readonly TotpService _totp;

        private UserRow _pendingUser;

        private readonly string _rememberPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Mondas", "remember.txt");

        public LoginForm()
        {
            InitializeComponent();

            var dbPath = Path.Combine(AppContext.BaseDirectory, "mondas.db");
            _users = new SqliteUserRepository(dbPath);
            _hasher = new PasswordHasher();
            _totp = new TotpService();
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            if (lblStatus != null)
            {
                lblStatus.Text = "";
            }

            if (tlpTwoFa != null)
            {
                tlpTwoFa.Visible = false;
            }

            if (btnVerifyCode != null)
            {
                btnVerifyCode.Enabled = false;
            }

            WirePlaceholder(txtEmail, "EMAIL ADDRESS", false);
            WirePlaceholder(txtPassword, "PASSWORD", true);

            LoadRememberedEmail();

            if (txtTwoFaCode != null)
            {
                txtTwoFaCode.TextChanged += (s, args) =>
                {
                    var okLen = txtTwoFaCode.Text != null && txtTwoFaCode.Text.Trim().Replace(" ", "").Length == 6;
                    btnVerifyCode.Enabled = okLen && _pendingUser != null;
                };
            }
        }

        private void tlpSidebar_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnSignIn_Click(object sender, EventArgs e)
        {
            SetStatus("");

            var email = ReadValue(txtEmail, "EMAIL ADDRESS");
            var password = ReadValue(txtPassword, "PASSWORD");

            if (string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(password))
            {
                SetStatus("Enter your email and password.");
                return;
            }

            UserRow user;

            try
            {
                user = _users.GetByEmail(email);
            }

            catch (Exception ex)
            {
                SetStatus("Error accessing user data: " + ex.Message);
                return;
            }
        
            if (user == null)
            {
                SetStatus("No account found with that email.");
                return;
            }

            var ok = _hasher.Verify(password, user.PasswordHash, user.PasswordSalt, user.PasswordIterations);

            if (!ok)
            {
                SetStatus("Incorrect password.");
                return;
            }

            if (chkRemember != null && chkRemember.Checked)
            {
                SaveRememberedEmail(user.Email);
            }

            else
            {
                ClearRememberedEmail();
            }

            if (user.TotpEnabled)
            {
                _pendingUser = user;

                if (tlpTwoFa != null)
                {
                    tlpTwoFa.Visible = true;
                }
                
                SetStatus("Enter the 6-digit code from your authenticator app.");

                if (txtTwoFaCode != null)
                {
                    txtTwoFaCode.Text = "";
                    txtTwoFaCode.Focus();
                }

                return;
            }
        
            _pendingUser = null;
            CompleteLogin(user);
        }

        private void btnVerifyCode_Click(object sender, EventArgs e)
        {
            if (_pendingUser == null)
            {
                SetStatus("No pending 2FA verification.");
                return;
            }

            var code = (txtTwoFaCode != null ? txtTwoFaCode.Text : "") ?? "";
            code = code.Trim().Replace(" ", "");

            if (code.Length != 6)
            {
                SetStatus("Enter the 6-digit code from your authenticator app.");
                return;
            }


            if (string.IsNullOrWhiteSpace(_pendingUser.TotpSecretBase32))
            {
                SetStatus("2FA secret missing. Re-setup 2FA.");
                return;
            }

            var ok = _totp.VerifyCode(_pendingUser.TotpSecretBase32, code);

            if (!ok)
            {
                SetStatus("Invalid code. Try again,");
                return;
            }

            var user = _pendingUser;
            _pendingUser = null;

            CompleteLogin(user);
        }

        private void CompleteLogin(UserRow user)
        {
            SetStatus("Signed in.");

            var dashboard = new DashboardForm(user.Id);
            dashboard.Show();
            Hide();
        }

        private void tlpRoot_Paint(object sender, PaintEventArgs e)
        {

        }

        private void lnkSignUp_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            using (var f = new SignupForm())
            {
                Hide();
                var result = f.ShowDialog(this);
                Show();

                if (result == DialogResult.OK)
                {
                    SetStatus("Account created. Please sign in.");
                }
            }
        }

        private void lnkForgot_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MessageBox.Show(this, "AS: Implement forgot password here", "Mondas", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    
        private void SetStatus(string msg)
        {
            if (lblStatus == null)
            {
                return;
            }

            lblStatus.Text = msg ?? "";
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

            return tb.Text == null ? "" : tb.Text.Trim();
        }
    
        private void LoadRememberedEmail()
        {
            try
            {
                if (!File.Exists(_rememberPath))
                {
                    return;
                }

                var email = File.ReadAllText(_rememberPath).Trim();

                if (!string.IsNullOrWhiteSpace(email))
                {
                    if (txtEmail != null)
                    {
                        txtEmail.ForeColor = Color.Black;
                        txtEmail.Text = email;
                    }
                
                    if (chkRemember != null)
                    {
                        chkRemember.Checked = true;
                    }
                }
            }
            
            catch 
            {
                
            }
        }
    
        private void SaveRememberedEmail(string email)
        {
            try
            {
                var dir = Path.GetDirectoryName(_rememberPath);
                if (!Directory.Exists(dir))
                {
                    Directory.CreateDirectory(dir);
                }

                File.WriteAllText(_rememberPath, email ?? "");
            }

            catch
            {

            }
        }
    
        private void ClearRememberedEmail()
        {
            try
            {
                if (File.Exists(_rememberPath))
                {
                    File.Delete(_rememberPath);
                }
            }

            catch
            {

            }
        }
    }
}