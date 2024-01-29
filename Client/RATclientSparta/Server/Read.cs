using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace RATclientSparta.Server
{
    public class ReadData
    {
        private Socket ServerSocket;
        public ReadData(Socket ServerSocket)
        {
            this.ServerSocket = ServerSocket;
        }
        public byte[] Read(int bytes)
        {
            byte[] buffer = new byte[bytes];
            int bytesRead = 0;
            while (bytesRead < bytes)
                bytesRead += this.ServerSocket.Receive(buffer, bytesRead, bytes - bytesRead, SocketFlags.None);
            return buffer;
        }
    }
}
