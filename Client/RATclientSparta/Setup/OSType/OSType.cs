using RATclientSparta.Setup.RegistryData;
using System;

namespace SpartaRATclient.Setup.OSType
{
    public class OSType
    {
        public string Type()
        {
            RegistryGet item = new RegistryGet();
            int osBuild = int.Parse(item.Get(@"HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows NT\CurrentVersion", "CurrentBuildNumber"));
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
