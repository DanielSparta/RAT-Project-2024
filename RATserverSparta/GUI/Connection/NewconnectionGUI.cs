using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RATserverSparta.GUI
{
    public partial class NewconnectionGUI : Form
    {
        private string RemoteEndPoint;
        public NewconnectionGUI(string RemoteEndPoint)
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;
            this.RemoteEndPoint = RemoteEndPoint;
            Rectangle workingArea = Screen.GetWorkingArea(this);
            this.Location = new Point(workingArea.Right - Size.Width, workingArea.Bottom - Size.Height);
        }

        private void NewconnectionGUI_Load(object sender, EventArgs e)
        {
            connection.Text = RemoteEndPoint;
            backgroundWorker1.RunWorkerAsync();
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            for (int i = 10; i >= 0; i--)
            {
                if (InvokeRequired)
                    this.BeginInvoke((MethodInvoker)(() => time.Text = i.ToString()));
                else
                    time.Text = i.ToString();
                Thread.Sleep(1000);
            }
            if (InvokeRequired)
                this.BeginInvoke((MethodInvoker)(() => this.Close()));
            else
                this.Close();
        }
    }
}
