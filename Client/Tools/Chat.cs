using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace SpartaRATclient
{
    public partial class Chat : Form
    {
        private readonly Server client;
        private bool formClose = false;
        public Chat(Server instance)
        {
            InitializeComponent();
            this.client = instance;
        }
        private void Chat_Load(object sender, EventArgs e)
        {
            this.TopMost = true;
            this.StartPosition = FormStartPosition.CenterScreen;
            client.ChatMessageEvent += UpdatingMessages;
            client.LostConnectionEvent += LostConnection;

            this.FormClosing += FormClose;
        }

        void FormClose(object sender, FormClosingEventArgs e)
        {
            if (this.formClose != true)
            {
                e.Cancel = true;
                client.Send(Encoding.ASCII.GetBytes("I tried to close this form, im such a loser!"), 1);
                textBox.Text += "You: " + "I tried to close this form, im such a loser!" + Environment.NewLine;
            }
        }

        private void UpdatingMessages(byte[] b)
        {
            string a = Encoding.ASCII.GetString(b);

            if (a == "\0")
            {
                this.formClose = true;
                if (InvokeRequired)
                    this.Invoke((MethodInvoker)delegate
                    {
                        this.Close();
                    });
                else
                    this.Close();
            }
            else
            {
                    if (InvokeRequired)
                    {
                        this.Invoke((MethodInvoker)delegate
                        {
                            textBox.Text += "Server: " + a + Environment.NewLine;
                        });
                    }
                    else
                        textBox.Text += "Server: " + a + Environment.NewLine;
                
            }
        }


        private void LostConnection()
        {
            CloseDelegates();
            this.formClose = true;
            if (!InvokeRequired)
                this.Close();
            else
                this.Invoke((MethodInvoker)delegate
                {
                    this.Close();
                });
        }

        void CloseDelegates()
        {
            client.ChatMessageEvent -= UpdatingMessages;
            client.LostConnectionEvent -= LostConnection;
        }



        private void button1_Click(object sender, EventArgs e)
        {
            client.Send(Encoding.ASCII.GetBytes(Talk.Text), 1);
            textBox.Text += "You: " + Talk.Text + Environment.NewLine;
            Talk.Text = "";
        }
    }
}
