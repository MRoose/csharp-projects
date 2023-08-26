using System;
using System.Windows.Forms;
using PluginBase;

namespace WindowsFormsApplication276
{
    public partial class MainForm : Form, IHost
    {
        private PluginManager pm = new PluginManager();

        public MainForm()
        {
            InitializeComponent();

            //сканируем плагины в папке Plugins
            pm.ScanPlugins(AppDomain.CurrentDomain.BaseDirectory + "\\Plugins\\");

            //создаем меню плагинов
            var menuStrip = new MenuStrip() {Parent = this};
            var mi = (ToolStripMenuItem)menuStrip.Items.Add("Plugins");

            //перебираем плагины, создаем пункт меню для каждого
            foreach(var plugin in pm.Plugins)
            {
                var item = mi.DropDownItems.Add(plugin.Name);
                item.Click += delegate { plugin.Run(this); };//при клике на меню, запускаем плагин на выполнение
            }
        }

        public void AddControlToMainForm(Control ctrl)
        {
            this.Controls.Add(ctrl);
        }
    }
}
