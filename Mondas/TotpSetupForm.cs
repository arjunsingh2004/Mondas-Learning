using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Syncfusion.WinForms.Controls;
using Mondas.Contracts.Services;
using Mondas.Services;

namespace Mondas
{
    public partial class TotpSetupForm : Form
    {
        private readonly TotpService _totp;
        private readonly QrCodeService _qr;

        private readonly string _issuer = "Mondas";
        private readonly string _email;

        private string _secretBase32;
        private bool _verified;

        public TotpSetupForm(string email)
        {
            InitializeComponent();

            _email = email ?? "";

            _totp = new TotpService();
            _qr = new QrCodeService();
        }

        private void TotpSetupForm_Load(object sender, EventArgs e)
        {
            btnContinue.Enabled = false;
            StartFreshSetup();
        }

        private void StartFreshSetup()
        {
            _verified = false;
            btnContinue.Enabled = false;

            lblStatus.Text = "";
            lblStatus.ForeColor = Color.Gray;

            var secretBytes = _totp.GenerateSecretBytes(20);
            _secretBase32 = Base32.Encode(secretBytes);

            txtSecret.ReadOnly = true;
            txtSecret.Text = _secretBase32;

            var otpUri = _totp.BuildOtpAuthUri(_issuer, _email, _secretBase32);

            picQr.SizeMode = PictureBoxSizeMode.Zoom;

            var bmp = _qr.GenerateQrBitmap(otpUri, pixelsPerModule: 8);
            var old = picQr.Image;
            picQr.Image = bmp;
            old?.Dispose();

            txtCode.Text = "";
            txtCode.Focus();
        }

        private void btnVerify_Click(object sender, EventArgs e)
        {
            var code = (txtCode.Text ?? "").Trim().Replace(" ", "");

            if (code.Length != 6)
            {
                SetStatus("Enter the 6-digit code from your authenticator app.", isError: true);
                return;
            }
        
            if (string.IsNullOrWhiteSpace(_secretBase32))
            {
                SetStatus("Secret key is missing. Please restart the setup process.", isError: true);
                return;
            }

            var ok = _totp.VerifyCode(_secretBase32, code);

            if (!ok)
            {
                SetStatus("Code is incorrect. Please try again.", isError: true);
                return;
            }

            _verified = true;
            btnContinue.Enabled = true;

            SetStatus("Code verified! Click Continue to finish setup.", isError: false);
        }

        private void btnContinue_Click(object sender, EventArgs e)
        {
            if (!_verified)
            {
                SetStatus("Please verify the code before continuing.", isError: true);
                return;
            }

            DialogResult = DialogResult.OK;
            Close();
        }
   
        private void SetStatus(string message, bool isError)
        {
            lblStatus.Text = message;
            lblStatus.ForeColor = isError ? Color.Firebrick : Color.Green;
        }
   
        public string GetVerifiedSecretBase32()
        {
            return _verified ? (_secretBase32 ?? "") : "";
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            var img = picQr?.Image;
            if (picQr != null) picQr.Image = null;
            img?.Dispose();
            base.OnFormClosed(e);
        }
    }
}