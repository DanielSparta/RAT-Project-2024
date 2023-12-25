using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp8
{
    public partial class ScreenShare : Form
    {
        private Client client;

        private Graphics g;
        private double x, y = -1;
        private Pen pen;
        private bool isMouseMove = false;
        string SelectedColor = "black";

        int ClientResolutionX;
        int ClientResolutionY;

        int HostComputerX;
        int HostComputerY;
        public ScreenShare(Client client)
        {
            InitializeComponent();
            this.client = client;
            this.setup();
            this.pictureBox1.MouseClick += pictureBox1_Click;
        }

        private void setup()
        {
            string ClientResolution = this.client.ScreenResolution;

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
            Rectangle resolution = Screen.PrimaryScreen.Bounds;
            Match match1 = MatchRegex(resolution.ToString());
            this.HostComputerX = int.Parse(match1.Groups[1].Value);
            this.HostComputerY = int.Parse(match1.Groups[2].Value);

            this.Size = new Size(500, 300);
        }

        private void ScreenShare_Load(object sender, EventArgs e)
        {
            this.TopMost = true;
            client.Send(Encoding.ASCII.GetBytes("\0"), 8); //telling the client to start sharing screen
            client.screenStreamEvent += screenStream;
            this.FormClosing += fuckingCloseEvent;

            this.pen = new Pen(Color.Black, 5);

            g = pictureBox1.CreateGraphics();
            pictureBox1.MouseDown += MouseDownEvent;
            pictureBox1.MouseUp += MouseUpEvent;
            pictureBox1.MouseMove += MouseMoveEvent;
        }

        void screenStream(byte[] buffer)
        {

            if (InvokeRequired)
            {
                Invoke((MethodInvoker)delegate
                {
                    try
                    {
                        MemoryStream imageStream = new MemoryStream(buffer);
                        Image receivedImage = Image.FromStream(imageStream);
                        pictureBox1.Image = receivedImage;
                    }
                    catch { }
                });
            }
        }

        private void fuckingCloseEvent(object fuckingSender, EventArgs e)
        { 
            client.Send(Encoding.ASCII.GetBytes("\0"), 9);
        }

        private void button2_Click(object sender, EventArgs e)
        {

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
                client.Send(stats, 10); //Once for draw point
                client.Send(stats, 22); //Once for WinApi Screen click
            }
        }

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
        void MouseMoveEvent(object sender, MouseEventArgs a)
        {
            if (isMouseMove)
            {
                g.DrawLine(pen, new Point(int.Parse(a.X.ToString()), int.Parse(a.Y.ToString())), a.Location);

                x *= (ClientResolutionX / 500 + 1);
                y *= (ClientResolutionY / 300 + 1);

                byte[] stats = Encoding.ASCII.GetBytes(x.ToString() + "\0" + y.ToString());
                client.Send(stats, 10);

                x = a.X;
                y = a.Y;
            }
        }
    }
}