using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RATclientSparta.Setup.RegistryData
{
    public class RegistryCreate
    {
        public void Create(string name, string value)
        {
            using (RegistryKey key = Microsoft.Win32.Registry.CurrentUser.CreateSubKey(@"Software\ClientValues"))
            {
                key.SetValue(name, value);
            }
        }
    }
}
