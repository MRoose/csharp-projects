using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using PluginBase;

namespace Elysium
{
    public partial class LetsGo : Form, IHost
    {

        private PluginManager pm = new PluginManager();

        public LetsGo()
        {
            InitializeComponent();

            pm.ScanPlugins(AppDomain.CurrentDomain.BaseDirectory + "\\Plugins\\");

            foreach (var plugin in pm.Plugins)
            {
                var ctr = new bt(plugin.Name) { Parent = flowLayoutPanel1 };
                var item = ctr.btOK;
                item.Click += delegate { plugin.Run(this); };
            }
        }

        public void AddControlToMainForm(Control ctrl)
        {
            if (scMain.Panel2.Contains(ctrl))
                ctrl.BringToFront();
            else scMain.Panel2.Controls.Add(ctrl);
        }
    }
}
