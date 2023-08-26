using System;
using System.Windows.Forms;
using ConnCore;

namespace Ely_adm
{
    public partial class month : Form
    {        
        string path;

        public month(string path)
        {
            InitializeComponent();
            this.path = path;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(comboBox1.Text))
                MessageBox.Show("Месяц выберите!");
            else
            {
                new sn_Control().sn_RefreshTime(path, comboBox1.Text, dateTimePicker1.Value.ToString("dd.MM.yyyy"), dateTimePicker2.Value.ToString("dd.MM.yyyy"));
                Close();
            }
        }
    }
}
