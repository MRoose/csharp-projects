using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MACEMP
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form2 formadminlogin = new Form2();
            formadminlogin.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form4 emplo = new Form4();
            emplo.ShowDialog();
        }
    }
}
