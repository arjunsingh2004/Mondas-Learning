using Mondas.Models;
using Newtonsoft.Json;
using Syncfusion.WinForms.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace Mondas
{
    public partial class PhishingDetailsForm : SfForm
    {

        private PhishingEmail _email;
        private PhishingDecisionResult _decision;
        private string _engineReason;
        private List<string> _rules;
        private DateTime? _received;
        public PhishingDetailsForm()
        {
            InitializeComponent();
        }

        public void Bind(PhishingEmail email, PhishingDecisionResult decision, string engineReason, List<string> rules, DateTime? received = null)
        {
            _email = email;
            _decision = decision;
            _engineReason = engineReason ?? "";
            _rules = rules ?? new List<string>();
            _received = received;

            DisplayAll();
        }

        private void PhishingDetailsForm_Load(object sender, EventArgs e)
        {
            if (LicenseManager.UsageMode == LicenseUsageMode.Designtime)
            {
                return;
            }

            if (_email != null || _decision != null)
            {
                DisplayAll();
            }
        }

        private void DisplayAll()
        {
            DisplayHeader();
            DisplayEmailSnap();
            DisplayDecisionSummary();
            DisplayWhy();
            DisplaySignals();
        }

        private void DisplayHeader()
        {
            if (lblHdrSub == null)
            {
                return;
            }

            var subject = (_email?.Subject ?? "").Trim();
            var sender = (_email?.SenderEmail ?? "").Trim();
            var action = _decision == null ? "" : _decision.Action.ToString().ToUpperInvariant();
            var parts = new List<string>();

            if (!string.IsNullOrWhiteSpace(action))
            {
                parts.Add(action);
            }

            if (!string.IsNullOrWhiteSpace(subject))
            {
                parts.Add(subject);
            }

            lblHdrSub.Text = parts.Count == 0 ? "-" : string.Join(" · ", parts);
        }

        private void DisplayEmailSnap()
        {
            if (_email == null)
            {
                SetText(lblMetaFromVal, "—");
                SetText(lblMetaToVal, "—");
                SetText(lblMetaSubjectVal, "—");
                SetText(lblMetaReceivedVal, "—");
                SetText(lblMetaReplyToVal, "—");
                SetText(llMetaLinkVal, "—");
                SetText(lblMetaAttachmentVal, "—");

                if (rtbEmailBody != null)
                {
                    rtbEmailBody.Text = "";
                }

                return;
            }

            SetText(lblMetaFromVal, BuildSenderDisplay(_email));
            SetText(lblMetaToVal, SafeValue(_email.ToEmail));
            SetText(lblMetaSubjectVal, SafeValue(_email.Subject));

            var rec = _received.HasValue ? _received.Value : DateTime.Now;
            SetText(lblMetaReceivedVal, rec.ToString("ddd dd MMM yyyy, HH:mm"));

            SetText(lblMetaReplyToVal, string.IsNullOrWhiteSpace(_email.ReplyToEmail) ? "—" : _email.ReplyToEmail.Trim());
            SetText(lblMetaAttachmentVal, _email.HasAttachment ? _email.Attachment.FileName : "—");
        
            if (llMetaLinkVal != null)
            {
                if (_email.HasLink)
                {
                    llMetaLinkVal.Text = string.IsNullOrWhiteSpace(_email.Link.DisplayText) ? _email.Link.Url : _email.Link.DisplayText;
                    llMetaLinkVal.Tag = _email.Link.Url;
                }
                else
                {
                    llMetaLinkVal.Text = "-";
                    llMetaLinkVal.Tag = null;
                }
            }

            if (rtbEmailBody != null)
            {
                rtbEmailBody.ReadOnly = true;
                rtbEmailBody.Text = (_email.Body ?? "").Replace("\r\n", "\n");
                rtbEmailBody.SelectionStart = 0;
                rtbEmailBody.SelectionLength = 0;
            }
        }

        private void DisplayDecisionSummary()
        {
            if (_decision == null)
            {
                SetText(lblDecisionHeadline, "—");
                SetText(lblDecisionOutcome, "—");
                SetText(lblDecisionScoreTime, "—");

                return;
            }

            var headline = string.IsNullOrWhiteSpace(_decision.Headline) ? "RESULT" : _decision.Headline.Trim();
            SetText(lblDecisionHeadline, headline.ToUpperInvariant());

            var isCorrect = _decision.IsCorrect ? "CORRECT" : "INCORRECT";
            var action = _decision.Action.ToString().Replace('_', ' ').ToUpperInvariant();
            SetText(lblDecisionOutcome, $"{isCorrect} · ACTION: {action}");

            var scoreDelta = _decision.ScoreDelta >= 0 ? "+" + _decision.ScoreDelta.ToString() : _decision.ScoreDelta.ToString();
            var timePenalty = _decision.TimePenaltySeconds <= 0 ? "0s" : Math.Round(_decision.TimePenaltySeconds).ToString() + "s";
            SetText(lblDecisionScoreTime, $"SCORE {scoreDelta} · TIME PENALTY: {timePenalty}");
        }

        private void DisplayWhy()
        {
            if (txtReason != null)
            {
                var sb = new StringBuilder();

                if (!string.IsNullOrWhiteSpace(_engineReason))
                {
                    sb.AppendLine(_engineReason.Trim());
                }

                if (!string.IsNullOrWhiteSpace(_decision?.Explanation))
                {
                    if (sb.Length > 0)
                    {
                        sb.AppendLine();
                    }

                    sb.AppendLine("Email explanation:");
                    sb.AppendLine(_decision.Explanation.Trim());
                }

                txtReason.ReadOnly = true;
                txtReason.Text = sb.Length == 0 ? "-" : sb.ToString().TrimEnd();
                txtReason.SelectionStart = 0;
                txtReason.SelectionLength = 0;
            }

            if (lbRules != null)
            {
                lbRules.BeginUpdate();
                lbRules.Items.Clear();

                var list = new List<string>();

                if (_rules != null && _rules.Count > 0)
                {
                    list.AddRange(_rules.Where(x => !string.IsNullOrWhiteSpace(x)).Select(x => x.Trim()));
                }

                if (_decision?.RulesFired != null && _decision.RulesFired.Count > 0)
                {
                    foreach (var r in _decision.RulesFired)
                    {
                        var clean = (r ?? "").Trim();

                        if (clean.Length == 0)
                        {
                            continue;
                        }

                        if (!list.Contains(clean))
                        {
                            list.Add(clean);
                        }
                    }
                }

                if (list.Count == 0)
                {
                    lbRules.Items.Add("-");
                }

                else
                {
                    for (int i = 0; i < list.Count; i++)
                    {
                        lbRules.Items.Add(list[i]);
                    }
                }

                lbRules.EndUpdate();
            }
        }

        private void DisplaySignals()
        {
            if (lvSignalsDetails == null)
            {
                return;
            }

            lvSignalsDetails.BeginUpdate();
            lvSignalsDetails.Items.Clear();
            
            var signals = _decision?.Signals ?? new List<PhishingSignal>();

            for (int i = 0; i < signals.Count; i++)
            {
                var s = signals[i];
                var item = new ListViewItem((s.Title ?? "").Trim());
                item.SubItems.Add((s.Detail ?? "").Trim());
                item.SubItems.Add(s.Weight.ToString());
                lvSignalsDetails.Items.Add(item);
            }

            if (signals.Count == 0)
            {
                var item = new ListViewItem("-");
                item.SubItems.Add("No signals provided.");
                item.SubItems.Add("0");
                lvSignalsDetails.Items.Add(item);
            }

            lvSignalsDetails.EndUpdate();
        }

        private void btnCopySummary_Click(object sender, EventArgs e)
        {
            try
            {
                var text = BuildSummaryText();

                if (string.IsNullOrWhiteSpace(text))
                {
                    return;
                }

                Clipboard.SetText(text);
            }

            catch
            {

            }
        }

        private void btnCopyEmail_Click(object sender, EventArgs e)
        {
            try
            {
                var text = BuildEmailText();

                if (string.IsNullOrWhiteSpace(text))
                {
                    return;
                }

                Clipboard.SetText(text);
            }

            catch
            {

            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private string BuildSummaryText()
        {
            var sb = new StringBuilder();

            sb.AppendLine("Mondas Phishing Simulator - Decision Details");
            sb.AppendLine();

            if (_email != null)
            {
                sb.AppendLine("Subject: " + SafeValue(_email.Subject));
                sb.AppendLine("From: " + BuildSenderDisplay(_email));
                sb.AppendLine("To: " + SafeValue(_email.ToEmail));

                if (_received.HasValue)
                {
                    sb.AppendLine("Received: " + _received.Value.ToString("ddd dd MMM yyyy, HH:mm"));
                }

                if (!string.IsNullOrWhiteSpace(_email.ReplyToEmail))
                {
                    sb.AppendLine("Reply To: " + _email.ReplyToEmail.Trim());
                }

                if (_email.HasLink)
                {
                    sb.AppendLine("Link: " + (_email.Link?.Url ?? ""));
                }

                if (_email.HasAttachment)
                {
                    sb.AppendLine("Attachment: " + (_email.Attachment?.FileName ?? ""));
                }

                if (_email.Tags != null && _email.Tags.Count > 0)
                {
                    sb.AppendLine("Tags: " + string.Join(", ", _email.Tags));
                }
            }

            sb.AppendLine();

            if (_decision != null)
            {
                sb.AppendLine("Action: " + _decision.Action.ToString());
                sb.AppendLine("Correct: " + (_decision.IsCorrect ? "Yes" : "No"));
                sb.AppendLine("Headline: " + SafeValue(_decision.Headline));
                sb.AppendLine("ScoreDelta: " + _decision.ScoreDelta.ToString(CultureInfo.InvariantCulture));
                sb.AppendLine("TimePenaltySeconds: " + Math.Round(_decision.TimePenaltySeconds).ToString(CultureInfo.InvariantCulture));

                if (!string.IsNullOrWhiteSpace(_engineReason))
                {
                    sb.AppendLine();
                    sb.AppendLine("Engine reason:");
                    sb.AppendLine(_engineReason.Trim());
                }

                if (_decision.RulesFired != null && _decision.RulesFired.Count > 0)
                {
                    sb.AppendLine();
                    sb.AppendLine("Rules:");
                    sb.AppendLine(string.Join(", ", _decision.RulesFired));
                }

                if (_decision.Signals != null && _decision.Signals.Count > 0)
                {
                    sb.AppendLine();
                    sb.AppendLine("Signals:");
                    for (int i = 0; i < _decision.Signals.Count; i++)
                    {
                        var signal = _decision.Signals[i];
                        sb.AppendLine("- " + SafeValue(signal.Title) + " (W=" + signal.Weight.ToString(CultureInfo.InvariantCulture) + "): " + SafeValue(signal.Detail));
                    }
                }

                if (!string.IsNullOrWhiteSpace(_decision.Explanation))
                {
                    sb.AppendLine();
                    sb.AppendLine("Explanation:");
                    sb.AppendLine(_decision.Explanation.Trim());
                }
            }

            return sb.ToString().TrimEnd();
        }

        private string BuildEmailText()
        {
            if (_email == null)
            {
                return "";
            }

            var sb = new StringBuilder();

            sb.AppendLine("From: " + BuildSenderDisplay(_email));
            sb.AppendLine("To: " + SafeValue(_email.ToEmail));
            sb.AppendLine("Subject: " + SafeValue(_email.Subject));

            if (_received.HasValue)
            {
                sb.AppendLine("Received: " + _received.Value.ToString("ddd dd MMM yyyy, HH:mm"));
            }

            if (!string.IsNullOrWhiteSpace(_email.ReplyToEmail))
            {
                sb.AppendLine("Reply To: " + _email.ReplyToEmail.Trim());
            }

            if (_email.HasLink)
            {
                sb.AppendLine("Link: " + (_email.Link?.Url ?? ""));
            }

            if (_email.HasAttachment)
            {
                sb.AppendLine("Attachment: " + (_email.Attachment?.FileName ?? ""));
            }

            sb.AppendLine();
            sb.AppendLine((_email.Body ?? "").Replace("\r\n", "\n").TrimEnd());

            return sb.ToString().TrimEnd();
        }

        private static string BuildSenderDisplay(PhishingEmail email)
        {
            var name = (email.SenderName ?? "").Trim();
            var emailAddress = (email.SenderEmail ?? "").Trim();

            if (name.Length == 0 && emailAddress.Length == 0)
            {
                return "-";
            }

            if (name.Length == 0)
            {
                return emailAddress;
            }

            if (emailAddress.Length == 0)
            {
                return name;
            }

            return name + " <" + emailAddress + ">";
        }

        private static string SafeValue(string s)
        {
            s = (s ?? "").Trim();
            return s.Length == 0 ? "-" : s;
        }

        private static void SetText(Label label, string text)
        {
            if (label == null)
            {
                return;
            }

            label.Text = text ?? "-";
        }

        private void llMetaLinkVal_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                var url = llMetaLinkVal?.Tag as string;

                if (string.IsNullOrWhiteSpace(url))
                {
                    return;
                }

                System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo(url) { UseShellExecute = true });
            }

            catch
            {

            }
        }
    }
}