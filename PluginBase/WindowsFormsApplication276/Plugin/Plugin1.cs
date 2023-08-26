using System.Windows.Forms;
using PluginBase;

namespace Plugin1NS
{
    public class Plugin1 : IPlugin
    {
        public string Name
        {
            get { return "Plugin 1"; }
        }

        public void Run(IHost host)
        {
            var lb = new Label {Text = "This label was created by Plugin1", Top = 100, Left = 10, Width = 200};
            host.AddControlToMainForm(lb);
        }
    }
}
