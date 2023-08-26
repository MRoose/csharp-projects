using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PluginBase;

namespace UCEmp
{
    public class Class1 : IPlugin
    {
        public string Name
        {
            get { return "Расписание"; }
        }

        public void Run(IHost host)
        {
            host.AddControlToMainForm(new UI());
        }
    }
}
