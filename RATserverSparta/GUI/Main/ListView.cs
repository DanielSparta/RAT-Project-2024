using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RATserverSparta.GUI.Main
{
    public class ListView
    {
        private MainGUI mainGUI;
        public ListView(MainGUI insatnce)
        {
            this.mainGUI = insatnce;
        }
        public void ListViewAction(string type, Socket Socket, byte[] message, int index)
        {
            if (type == "Adding")
            {
                ListViewItem i = new ListViewItem(Socket.RemoteEndPoint.ToString());
                i.ForeColor = System.Drawing.Color.Red;
                this.mainGUI.Invoke((MethodInvoker)delegate
                {
                    this.mainGUI.ClientsList.Items.AddRange(new ListViewItem[] { i });
                    ListViewItem CurrentListviewItemSelected = this.mainGUI.ClientsList.FindItemWithText(Socket.RemoteEndPoint.ToString());
                    for (int a = 0; a < 7; a++)
                        CurrentListviewItemSelected.SubItems.Add("");
                });
            }

            if (type == "Editing")
            {
                this.mainGUI.Invoke((MethodInvoker)delegate
                {
                    ListViewItem CurrentListviewItemSelected = this.mainGUI.ClientsList.FindItemWithText(Socket.RemoteEndPoint.ToString());
                    if (CurrentListviewItemSelected != null)
                    {
                        string data = Encoding.ASCII.GetString(message);
                        if (!data.EndsWith("(Probably removed by AV or by C&C Server)"))
                            this.mainGUI.ClientsList.Items[CurrentListviewItemSelected.Index].SubItems[index].Text = data;
                        else
                        {
                            Logs log = new Logs(this.mainGUI);
                            log.Create("[ERROR]", "Removed registry key detected at client", DateTime.Now.ToString());
                        }
                    }
                });
            }

            if (type == "Removing")
            {
                this.mainGUI.Invoke((MethodInvoker)delegate
                {
                    ListViewItem CurrentListviewItemSelected = this.mainGUI.ClientsList.FindItemWithText(Socket.RemoteEndPoint.ToString());
                    if (CurrentListviewItemSelected != null)
                        this.mainGUI.ClientsList.Items.Remove(CurrentListviewItemSelected);
                });
            }
        }
    }
}
