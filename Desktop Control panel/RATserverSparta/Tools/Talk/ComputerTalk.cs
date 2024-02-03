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

namespace RATserverSparta.Tools.Talk
{
    public partial class ComputerTalk : Form
    {
        private Socket SocketClient;
        public ComputerTalk(Socket SocketClient)
        {
            InitializeComponent();
            this.SocketClient = SocketClient;
        }

        private void button_Click(object sender, EventArgs e)
        {
            SocketSend data = new SocketSend(this.SocketClient);
            data.Send(Encoding.ASCII.GetBytes(text.Text), 4);
        }
    }
}
