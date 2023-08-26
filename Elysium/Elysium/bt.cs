using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Elysium
{
    public partial class bt : UserControl
    {
        public bt(string btName)
        {
            InitializeComponent();
            btOK.Name = btName;
        }
    }
}
