using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace RATserverSparta.Client
{
    public class SocketSend
    {
        private System.Net.Sockets.Socket ClientSocket;
        public SocketSend(System.Net.Sockets.Socket clientSocket)
        {
            this.ClientSocket = clientSocket;
        }
        public dynamic Send(byte[] message, byte messageType)
        {
            //I am using TLV (Type, Length, Value) Format for the network communication! A very strong and safe way.
            //In my old project My communication way was.. for example when im sanding a chat message then a TCP Packet would sent like that: "chatHello" and then goes into if(StartsWith(chat)).. not a smart and safe way to do that, which also dont make sure that 100% of the data sent successfuly.
            //Today with TLV Format, Everything works alot better.
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

                    ClientSocket.Send(tlv);
                }
                catch { return false; }
            }
            return true;
        }
    }
}
