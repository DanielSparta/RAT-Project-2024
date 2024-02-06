using RATserverSparta.Client;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RATserverSparta.Tools.Chat
{
    public partial class Chat : Form
    {
        private Client.Client ClientClassInstance;
        private Client.SocketSend Data;
        public Chat(Client.Client ClientClassInstance, System.Net.Sockets.Socket ClientSocket)
        {
            InitializeComponent();
            this.ClientClassInstance = ClientClassInstance;
            this.Data = new SocketSend(ClientSocket);
        }
        private void Chat_Load(object sender, EventArgs e)
        {
            this.TopMost = true;
            ClientClassInstance.chatMessageEvent += UpdatingMessages;
            FormClosing += OnClose;
            KeyPreview = true;
            KeyDown += KeyPressing;
        }

        private void UpdatingMessages(byte[] buffer)
        {
            string a = Encoding.UTF8.GetString(buffer);
            this.Invoke((MethodInvoker)delegate
            {
                talk.Text += "Client: " + a + Environment.NewLine;
            });
        }
        private void KeyPressing(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Data.Send(Encoding.ASCII.GetBytes("\0"), 1);
                this.Close();
            }
        }
        private void OnClose(object sender, EventArgs e)
        {
            this.Data.Send(Encoding.ASCII.GetBytes("\0"), 1);
            ClientClassInstance.chatMessageEvent -= UpdatingMessages;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (text.Text.Length > 0)
            {
                this.Data.Send(Encoding.UTF8.GetBytes(text.Text), 1);
                talk.Text += "You: " + text.Text + Environment.NewLine;
                text.Text = "";
            }
        }
    }
}
