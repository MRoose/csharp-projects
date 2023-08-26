using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication276
{
    public partial class UserControl1 : UserControl
    {
        public UserControl1(string btName)
        {
            InitializeComponent();
            button1.Text = btName;
        }
    }
}
