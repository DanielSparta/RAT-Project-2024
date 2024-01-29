using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace RATserverSparta.Client
{
    public class SocketRead
    {
        public byte[] Read(Socket c, int bytes)
        {
            byte[] buffer = new byte[bytes];
            int bytesRead = 0;
            while (bytesRead < bytes)
                bytesRead += c.Receive(buffer, bytesRead, bytes - bytesRead, SocketFlags.None);

            return buffer;
        }
    }
}
