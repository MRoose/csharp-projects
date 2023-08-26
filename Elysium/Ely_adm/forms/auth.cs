using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Ely_adm
{
    public partial class auth : Form
    {
        public auth()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "tcs2019" && textBox2.Text == "45k68f457g38g57k536g77f35j8g46")
            {
                Close();
            }
            else MessageBox.Show("Неверно!");
        }
    }
}
