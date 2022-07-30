using SE1617_Win.GUI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinFormsApp2.GUI;

namespace WinFormsApp2
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }
        public void showToolStripMenuItem_Click(object sender, EventArgs e)
        {

            Boolean checkLogin = true;
            if (loginToolStripMenuItem.Text.Equals("Login")) checkLogin = true;
            ShowGUI f = new ShowGUI(checkLogin);
            f.TopLevel = false;
            f.FormBorderStyle = FormBorderStyle.None;
            f.Show();

            toolStripContainer1.ContentPanel.Controls.Clear();
            toolStripContainer1.ContentPanel.Controls.Add(f);
        }

        private void loginToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (loginToolStripMenuItem.Text.StartsWith("Login"))
            {
                LoginGUI f = new LoginGUI();
                DialogResult dr = f.ShowDialog();
            }
            else
            {
                Settings.UserName = "";
                MessageBox.Show("You are logged out");
            }
        }

        private void Main_Activated(object sender, EventArgs e)
        {
            if (Settings.UserName == "")
                loginToolStripMenuItem.Text = "Login";
            else
                loginToolStripMenuItem.Text = $"Logout ({Settings.UserName})";

        }
    }
}
