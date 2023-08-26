using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Ely_man
{
    public partial class svodka : UserControl
    {
        public svodka(string otdel, string month, string stop_d, string read)
        {
            InitializeComponent();

            label4.Text = otdel;
            label5.Text = month;
            label6.Text = stop_d;
            textBox1.Text = read;
        }
    }
}
