using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApp8
{
    public partial class Chat : Form
    {
        private Client Client;

        public Chat(Client instance)
        {
            InitializeComponent();
            this.Client = instance;
        }


        private void Chat_Load(object sender, EventArgs e)
        {
            this.TopMost = true;

            Client.chatMessageEvent += UpdatingMessages;
            Client.LostConnectionEvent += LostConnection;
            FormClosing += OnClose;

            KeyPreview = true;
            KeyDown += KeyPressing;
        }


        private void KeyPressing(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                Client.Send(Encoding.ASCII.GetBytes("\0"), 1);
                CloseDelegates();
                this.Close();
            }
        }


        private void UpdatingMessages(byte[] buffer)
        {
            string a = Encoding.ASCII.GetString(buffer);

            this.Invoke((MethodInvoker)delegate
            {
                talk.Text += "Client: " + a + Environment.NewLine;
            });

        }


        private void LostConnection()
        {
                CloseDelegates();
            
                this.Invoke((MethodInvoker)delegate
                {
                    this.Close();
                });
        }
        
        private void OnClose(object sender, EventArgs e)
        {
            Client.Send(Encoding.ASCII.GetBytes("\0"), 1);
            CloseDelegates();
        }

        private void CloseDelegates()
        {
            Client.chatMessageEvent -= UpdatingMessages;
            Client.LostConnectionEvent -= LostConnection;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (text.Text.Length > 0)
            {
                Client.Send(Encoding.ASCII.GetBytes(text.Text), 1);
                talk.Text += "You: " + text.Text + Environment.NewLine;
                text.Text = "";
            }
        }
    }
}
