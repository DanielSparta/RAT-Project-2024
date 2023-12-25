using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp8
{
    public class SocketServer
    {
        protected Dictionary<string, Client> ClientInstance = new Dictionary<string, Client>();

        public delegate void newInstance(Client client);
        public event newInstance n_newInstance;

        private Main form;
        private Label label;
        private TextBox HostValue;
        public SocketServer(Main instance, Label label, TextBox HostValue)
        {
            this.form = instance;
            this.label = label;
            this.HostValue = HostValue;
            this.n_newInstance = delegate { };
        }

        public void CreateServer()
        {
            if (HostValue.Text == "")
            {
                MessageBox.Show("Please select a host ip address at the Settings");
                return;
            }
            new Thread(() =>
            {
                Socket server = default(Socket);
                IPEndPoint localEndPoint = default(IPEndPoint);
                try
                {
                    int MaxConnections = 100;
                    int ConnectedClients = 0;

                    server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                    localEndPoint = new IPEndPoint(IPAddress.Parse(HostValue.Text), 81);
                    server.Bind(localEndPoint);
                    MessageBox.Show("Server Created - " + HostValue.Text + ":81");
                    server.Listen(0);


                    while (ConnectedClients < MaxConnections)
                    {
                        Socket client = null;
                        try
                        {
                            client = default(Socket);
                            client = server.Accept();

                            Task.Run(() =>
                            {
                                int openedTimes = Application.OpenForms.OfType<ConnectionAlert>().Count();
                                if (openedTimes <= 2)//in case of too much connections
                                {
                                    Thread run = new Thread(new ThreadStart(() =>
                                    {
                                        ConnectionAlert connection = new ConnectionAlert(client.RemoteEndPoint.ToString());
                                        connection.ShowDialog();
                                    }));
                                    run.Start();
                                }
                            });
                            ConnectedClients++;
                            form.Invoke((MethodInvoker)delegate
                            {
                                label.Text = ConnectedClients.ToString();
                            });

                            new Thread(
                            () =>
                            {
                                string ClientEndpoint = client.RemoteEndPoint.ToString();
                                Client clientInstance = new Client(form, client);
                                n_newInstance.Invoke(clientInstance);
                                this.ClientInstance[ClientEndpoint] = clientInstance;
                                clientInstance.Receive(client);
                            }
                            ).Start();
                        }
                        catch (Exception e)
                        {
                            MessageBox.Show(e.ToString());
                        }

                        Thread.Sleep(100);
                    }
                    MessageBox.Show("Maximum clients reached. If you want to let more clients connect to you then create a server again.");
                    server.Close();
                }
                catch { }
            }).Start();
        }

        public Client GetInstance(string a)
        {
            return this.ClientInstance[a];
        }
    }
}