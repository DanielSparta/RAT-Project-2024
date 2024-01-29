using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RATserverSparta.GUI.Main
{
    public class Logs
    {
        private MainGUI mainGUI;
        public Logs(MainGUI instance)
        {
            this.mainGUI = instance;
        }
        public void Create(string type, string value, string date)
        {
            ListViewItem list = new ListViewItem(type);
            list.SubItems.Add(value);
            list.SubItems.Add(date);
            this.mainGUI.logView.Items.Add(list);
        }
    }
}
