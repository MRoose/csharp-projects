using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using PluginBase;

namespace pl2
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
            get { return "Black"; }
        }

        public void Run(IHost host)
        {
            host.AddControlToMainForm(this);
        }
    }
}
