using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Win32;
using SpartaRATclient.FakeProgram;

namespace SpartaRATclient
{
    public class RegistryData
    {
        public string OpenedDate;
        public string OSVersion;

        public void DeleteSubKeyTree(string value)
        {
            Registry.CurrentUser.DeleteSubKeyTree(value, false);
        }

        public bool CheckIfRegistryDataExist(string value)
        {
            string RegistryPath = @"HKEY_CURRENT_USER\Software\ClientValues";
            string RegistryKey = Registry.GetValue(RegistryPath, value, null) as string;
            if (RegistryKey != null)
                return true;
            else
                return false;
        }

        public void CreateRegistryData(string name, string value)
        {
            using (RegistryKey key = Registry.CurrentUser.CreateSubKey(@"Software\ClientValues"))
            {
                key.SetValue(name, value);
            }
        }

        public void GetRegistryData()
        {
            //If "OpenedAt" exist, then "OSVersion" also exist
            if (this.CheckIfRegistryDataExist("OpenedAt"))
            {
                using (RegistryKey a = Registry.CurrentUser.CreateSubKey(@"SOFTWARE\ClientValues"))
                {
                    this.OpenedDate = a.GetValue("OpenedAt").ToString();
                    this.OSVersion = a.GetValue("OSVersion").ToString();
                }
            }
            else
            {
                this.OpenedDate = @"""OpenedAt"" data not exist at registry key";
                this.OSVersion = @"""OSVersion"" data not exist at registry key";
            }
        }
    }
}
