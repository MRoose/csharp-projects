using System;
using System.Windows.Forms;
using PluginBase;
using System.Drawing;

namespace WindowsFormsApplication276
{
    public partial class MainForm : Form, IHost
    {
        private PluginManager pm = new PluginManager();

        public MainForm()
        {
            InitializeComponent();
            pm.ScanPlugins(AppDomain.CurrentDomain.BaseDirectory + "\\Plugins\\");

            foreach(var plugin in pm.Plugins)
            {
                var ctr = new UserControl1(plugin.ShowName) { Parent = flowLayoutPanel1 };
                var item = ctr.button1;
                item.Click += delegate { plugin.Run(this); };
            }
        }

        public void AddControlToMainForm(Control ctrl)
        {
            if (splitContainer1.Panel2.Contains(ctrl))
                ctrl.BringToFront();
            else splitContainer1.Panel2.Controls.Add(ctrl);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show(splitContainer1.Panel2.Controls.Count.ToString());
        }
    }
}
