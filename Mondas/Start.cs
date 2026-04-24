using Syncfusion.WinForms.Controls;

namespace Mondas
{
    public partial class Start : SfForm
    {
        public Start()
        {
            InitializeComponent();
        }

        private void btnStart_Click(object sender, System.EventArgs e)
        {
            var login = new LoginForm();
            login.FormClosed += (s, args) => Close();
            login.Show();
            Hide();
        }
    }
}