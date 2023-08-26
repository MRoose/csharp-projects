using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ConnCore
{
    public partial class _dRes : Form
    {
        public _dRes(string err)
        {
            InitializeComponent();
            textBox1.Text = err;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            new sender().Send("Ошибка :"+ Environment.NewLine + textBox1.Text + Environment.NewLine + Environment.NewLine + "Описание :" + Environment.NewLine + textBox2.Text);
            Close();
        }
    }
}
