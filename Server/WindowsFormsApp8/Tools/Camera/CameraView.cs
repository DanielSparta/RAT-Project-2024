using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp8
{
    public partial class CameraView : Form
    {
        private readonly Client client;
        public CameraView(Client client)
        {
            InitializeComponent();
            client.a_CameraShareEvent += ShowImage;
            this.FormClosing += OnFormClose;
            this.client = client;

            client.Send(Encoding.ASCII.GetBytes("\0"), 18); //telling client to start sharing cam
        }

        private void CameraView_Load(object sender, EventArgs e)
        {
            
        }

        private void ShowImage(byte[] data)
        {
            this.Invoke((MethodInvoker)delegate
            {
                try
                {
                    MemoryStream stream = new MemoryStream(data);
                    Image image = Image.FromStream(stream);
                    pictureBox1.Image = image;
                }
                catch { }
            });
        }

        private void OnFormClose(object sender, FormClosingEventArgs e)
        {
            client.a_CameraShareEvent -= ShowImage;
            client.Send(Encoding.ASCII.GetBytes("\0"), 19); //telling client to stop sharing cam
        }
    }
}
