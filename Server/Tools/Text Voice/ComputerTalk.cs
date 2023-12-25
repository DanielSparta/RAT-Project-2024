using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp8
{
    public partial class ComputerTalk : Form
    {
        private Client client;
        public ComputerTalk(Client client)
        {
            InitializeComponent();
            this.client = client;
        }

        private void ComputerTalk_Load(object sender, EventArgs e)
        {
            
        }

        private void button_Click(object sender, EventArgs e)
        {
            client.Send(Encoding.ASCII.GetBytes(text.Text), 4);
        }
    }
}
