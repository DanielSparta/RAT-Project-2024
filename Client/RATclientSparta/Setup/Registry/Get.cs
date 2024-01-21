using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RATclientSparta.Setup.RegistryData
{
    public class RegistryGet
    {
        public string OpenedDate;
        public string OSVersion;

        public dynamic Get(string key, string value)
        {
            return Registry.GetValue(key, value, "not exist"); //not exist = the value to return if the given value not exist
        }

        public void GetClientData()
        {
            //If "OpenedAt" exist, then "OSVersion" also exist
            RegistryCheck item = new RegistryCheck();
            if (item.CheckIfExist("OpenedAt"))
            {
                using (RegistryKey a = Registry.CurrentUser.CreateSubKey(@"SOFTWARE\ClientValues"))
                {
                    this.OpenedDate = a.GetValue("OpenedAt").ToString();
                    this.OSVersion = a.GetValue("OSVersion").ToString();
                }
            }
            else
            {
                this.OpenedDate = @"""OpenedAt"" data not exist at registry key. (Probably removed by AV or by C&C Server)";
                this.OSVersion = @"""OSVersion"" data not exist at registry key. (Probably removed by AV or by C&C Server)";
            }
        }
    }
}
