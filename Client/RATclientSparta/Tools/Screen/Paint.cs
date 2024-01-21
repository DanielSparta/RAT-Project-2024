using RATclientSparta.Server;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace RATclientSparta.Tools.ScreenShare
{
    public class Paint
    {
        private ServerData client;
        [DllImport("User32.dll")]
        public static extern IntPtr GetDC(IntPtr hwnd);
        private Graphics g;
        private SolidBrush b;
        private IntPtr desktopPtr;
        private Color CurrentColor;
        public Paint()
        {
            this.desktopPtr = GetDC(IntPtr.Zero);
            this.g = Graphics.FromHdc(desktopPtr);
            this.b = new SolidBrush(Color.Black);
            this.CurrentColor = Color.Black;
        }
        public void Painting(byte[] buffer)
        {
            string[] Location = Encoding.ASCII.GetString(buffer).Split('\0');
            Rectangle rect = new Rectangle(int.Parse(Location[0]/*X*/), int.Parse(Location[1/*Y*/]), 10/*WIDTH*/, 10/*HEIGHT*/);
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            g.FillRectangle(b, rect);
        }

        public void ScreenConfigs(byte[] buffer)
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

    }
}
