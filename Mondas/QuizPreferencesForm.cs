using Mondas.Models;
using Syncfusion.WinForms.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mondas
{
    public partial class QuizPreferencesForm : SfForm
    {
        private void gbBasics_Enter(object sender, EventArgs e) { }
        private void cmbQuestionCount_SelectedIndexChanged(object sender, EventArgs e) { }
        private void cmbTimer_SelectedIndexChanged(object sender, EventArgs e) { }
        private void cmbDifficulty_SelectedIndexChanged(object sender, EventArgs e) { }
        private void clbQuestionTypes_SelectedIndexChanged(object sender, EventArgs e) { }
        private void cmbBloom_SelectedIndexChanged(object sender, EventArgs e) { }
        private void cmbThreatVector_SelectedIndexChanged(object sender, EventArgs e) { }

        public QuizPreferences Preferences { get; private set; }

        public QuizPreferencesForm() : this(new QuizPreferences())
        {
        }

        public QuizPreferencesForm(QuizPreferences initial)
        {
            InitializeComponent();
            Preferences = Clone(initial);

            Load += QuizPreferencesForm_Load;
        }

        private void QuizPreferencesForm_Load(object sender, EventArgs e)
        {
            FillUiLists();
            ApplyToUi(Preferences);
            ApplyMode(Preferences.UseDefaults);
        }

        private void FillUiLists()
        {
            cmbQuestionCount.Items.Clear();
            cmbQuestionCount.Items.AddRange(new object[] { 5, 10, 15, 20, 25, 30 });

            cmbTimer.Items.Clear();
            cmbTimer.Items.AddRange(new object[] { "Off", "On" });

            cmbDifficulty.Items.Clear();
            cmbDifficulty.Items.Add("Any");
            cmbDifficulty.Items.AddRange(Enum.GetNames(typeof(DifficultyBand)));

            cmbBloom.Items.Clear();
            cmbBloom.Items.Add("Any");
            cmbBloom.Items.AddRange(Enum.GetNames(typeof(BloomLevel)));

            cmbThreatVector.Items.Clear();
            cmbThreatVector.Items.AddRange(new object[] { "", "Email", "SMS", "Phone", "Web", "USB" });
            cmbThreatVector.DropDownStyle = ComboBoxStyle.DropDown;

            clbTopics.Items.Clear();
            foreach (Topic t in Enum.GetValues(typeof(Topic)))
            {
                if (t == Topic.Other) continue;
                clbTopics.Items.Add(t);
            }

            clbQuestionTypes.Items.Clear();
            foreach (QuestionType qt in Enum.GetValues(typeof(QuestionType)))
            {
                clbQuestionTypes.Items.Add(qt);
            }
        }

        private void ApplyToUi(QuizPreferences p)
        {
            rbDefault.Checked = p.UseDefaults;
            rbCustom.Checked = !p.UseDefaults;

            cmbQuestionCount.SelectedItem = cmbQuestionCount.Items.Cast<object>().FirstOrDefault(x => Convert.ToInt32(x) == p.QuestionCount) ?? 15;
            cmbTimer.SelectedItem = p.TimerEnabled ? "On" : "Off";

            chkPrioritiseWeak.Checked = p.PrioritiseWeakTopics;

            SetCheckedItems(clbTopics, p.Topics);
            SetCheckedItems(clbQuestionTypes, p.QuestionTypes);

            cmbDifficulty.SelectedItem = p.Difficulty.HasValue ? p.Difficulty.Value.ToString() : "Any";

            cmbBloom.SelectedItem = p.BloomLevel.HasValue ? p.BloomLevel.Value.ToString() : "Any";
            cmbThreatVector.Text = p.ThreatVector ?? "";
        }

        private void SetCheckedItems<T>(CheckedListBox clb, List<T> values)
        {
            for (int i = 0; i <clb.Items.Count; i++)
            {
                var item = clb.Items[i];
                bool shouldCheck = values != null && values.Contains((T)item);
                clb.SetItemChecked(i, shouldCheck);
            }
        }

        private void ApplyMode(bool useDefaults)
        {
            Preferences.UseDefaults = useDefaults;

            gbBasics.Enabled = !useDefaults;
            gbTopics.Enabled = !useDefaults;
            gbDifficulty.Enabled = !useDefaults;
            gbTypes.Enabled = !useDefaults;
            gbAdvanced.Enabled = !useDefaults;
        }

        private QuizPreferences ReadFromUi()
        {
            var p = new QuizPreferences();

            p.UseDefaults = rbDefault.Checked;
            if (p.UseDefaults)
            {
                return p;
            }

            p.QuestionCount = TryGetInt(cmbQuestionCount.SelectedItem, fallback: 15);
            p.TimerEnabled = string.Equals(cmbTimer.Text, "On", StringComparison.OrdinalIgnoreCase);

            p.PrioritiseWeakTopics = chkPrioritiseWeak.Checked;

            p.Topics = clbTopics.CheckedItems.Cast<object>().OfType<Topic>().ToList();
            p.QuestionTypes = clbQuestionTypes.CheckedItems.Cast<object>().OfType<QuestionType>().ToList();

            p.Difficulty = cmbDifficulty.Text == "Any" ? (DifficultyBand?)null : Enum.TryParse<DifficultyBand>(cmbDifficulty.Text, out var d) ? d : (DifficultyBand?)null;

            p.BloomLevel = cmbBloom.Text == "Any" ? (BloomLevel?)null : Enum.TryParse<BloomLevel>(cmbBloom.Text, out var b) ? b : (BloomLevel?)null;

            p.ThreatVector = (cmbThreatVector.Text ?? "").Trim();

            return p;
        }

        private int TryGetInt(object item, int fallback)
        {
            if (item == null)
            {
                return fallback;
            }

            if (item is int i)
            {
                return i;
            }

            return int.TryParse(item.ToString(), out var parsed) ? parsed : fallback;
        }

        private static QuizPreferences Clone(QuizPreferences p)
        {
            return new QuizPreferences
            {
                UseDefaults = p.UseDefaults,
                QuestionCount = p.QuestionCount,
                TimerEnabled = p.TimerEnabled,
                PrioritiseWeakTopics = p.PrioritiseWeakTopics,
                Difficulty = p.Difficulty,
                BloomLevel = p.BloomLevel,
                ThreatVector = p.ThreatVector ?? "",
                Topics = p.Topics?.ToList() ?? new List<Topic>(),
                QuestionTypes = p.QuestionTypes?.ToList() ?? new List<QuestionType>()
            };
        }

        private void rbDefault_CheckedChanged(object sender, EventArgs e)
        {
            if (rbDefault.Checked)
            {
                ApplyMode(useDefaults: true);
            }
        }

        private void rbCustom_CheckedChanged(object sender, EventArgs e)
        {
            if (rbCustom.Checked)
            {
                ApplyMode(useDefaults: false);
            }
        }

        private void btnUseDefaults_Click(object sender, EventArgs e)
        {
            Preferences = new QuizPreferences { UseDefaults = true };
            ApplyToUi(Preferences);
            ApplyMode(true);
        }

        private void btnApply_Click(object sender, EventArgs e)
        {
            Preferences = ReadFromUi();
            DialogResult = DialogResult.OK;
            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}