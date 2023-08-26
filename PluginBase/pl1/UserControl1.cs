using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using PluginBase;

namespace pl1
{
    public partial class UserControl1 : UserControl, IPlugin
    {
        public UserControl1()
        {
            InitializeComponent();
            this.Dock = DockStyle.Fill;
        }

        public string ShowName
        {
            get { return "Lime"; }
        }

        public void Run(IHost host)
        {
            host.AddControlToMainForm(this);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            button2.Visible = true;
            button1.Visible = false;
        }
    }
}
