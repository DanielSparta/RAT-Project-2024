using System;
using System.ComponentModel;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace WindowsFormsApp8
{
    public partial class ConnectionAlert : Form
    {
        private string RemoteEndPoint;


        public ConnectionAlert(string RemoteEndPoint)
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;


            this.RemoteEndPoint = RemoteEndPoint;
            Rectangle workingArea = Screen.GetWorkingArea(this);
            this.Location = new Point(workingArea.Right - Size.Width, workingArea.Bottom - Size.Height);
        }


        private void ConnectionAlert_Load(object sender, EventArgs e)
        {
            connection.Text = RemoteEndPoint;
            backgroundWorker1.RunWorkerAsync();
        }


        private void backgroundWorker1_DoWork_1(object sender, DoWorkEventArgs e)
        {
            for (int i = 10; i >= 0; i--)
            {
                if (InvokeRequired)
                    this.BeginInvoke((MethodInvoker)(() => time.Text = i.ToString()));
                else
                    time.Text = i.ToString();
                Thread.Sleep(1000);
            }
            if(InvokeRequired)
            this.BeginInvoke((MethodInvoker)(() => this.Close()));
            else
                this.Close();
        }
    }
}
