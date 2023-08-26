using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MACEMP
{
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
        }

        private void Form5_Load(object sender, EventArgs e)
        {
            textBox1.Text = Properties.Settings.Default.host2;
            textBox2.Text = Properties.Settings.Default.ndb2;
            textBox3.Text = Properties.Settings.Default.login2;
            textBox4.Text = Properties.Settings.Default.pswd2;
            textBox5.Text = Properties.Settings.Default.port2;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.host2 = textBox1.Text;
            Properties.Settings.Default.ndb2 = textBox2.Text;
            Properties.Settings.Default.login2 = textBox3.Text;
            Properties.Settings.Default.pswd2 = textBox4.Text;
            Properties.Settings.Default.port2 = textBox5.Text;
            Properties.Settings.Default.Save();
            this.Close();
        }
    }
}
