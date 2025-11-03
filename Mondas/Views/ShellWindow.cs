using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Mondas.Contracts.Views;

using Syncfusion.WinForms.Controls;

namespace Mondas.Views
{
    public partial class ShellWindow : SfForm,IShellWindow
    {
        public ShellWindow()
        {
            InitializeComponent();
        }

         public void CloseWindow()
        {
           
        }

        public Panel GetNavigationFrame()
            => this.panel1;

        public void ShowWindow()
            => Show();

	 private void ShellWindow_Resize(object sender, System.EventArgs e)
        {

            if (this.panel1.Controls.Count > 0)
            {
                var selectedControl = this.panel1.Controls[0];
                if (selectedControl != null)
                {
                    int x = (this.panel1.Width - selectedControl.Width) / 2;
                    int y = (this.panel1.Height - selectedControl.Height) / 2;
                    selectedControl.Location = new System.Drawing.Point(x, y);
                }
            }
        }

             private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}
