using System;
using System.Windows.Forms;
using ConnCore;

namespace Ely_adm
{
    public partial class set_n : Form
    {
        sn_Control sn = new sn_Control();
        string path;
        int mode;

        public set_n(int mode, string path)
        {
            InitializeComponent();

            this.path = path;
            this.mode = mode;

            switch (mode)
            {
                case 1:
                    {
                        Text = "Добавить";
                        break;
                    }
                case 2:
                    {
                        Text = "Редактировать";

                        comboBox1.DataSource = sn.sn_ListOfMonth(path);
                        comboBox1.DisplayMember = "count_m";

                        button3.Visible = true;
                        break;
                    }
                case 3:
                    {
                        Text = "Удалить";

                        comboBox1.DataSource = sn.sn_ListOfMonth(path);
                        comboBox1.DisplayMember = "count_m";

                        textBox1.Enabled = false;
                        break;
                    }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            switch (mode)
            {
                case 1:
                    {
                        if (string.IsNullOrEmpty(comboBox1.Text) || string.IsNullOrEmpty(textBox1.Text))
                            MessageBox.Show("Заполнены не все поля!");
                        else
                        {
                            sn.sn_AddCondition(path, comboBox1.Text, textBox1.Text);
                            Close();
                        }
                        break;
                    }
                case 2:
                    {
                        if (string.IsNullOrEmpty(comboBox1.Text) || string.IsNullOrEmpty(textBox1.Text))
                            MessageBox.Show("Заполнены не все поля!");
                        else
                        {
                            sn.sn_UpdateCondition(path, comboBox1.Text, textBox1.Text);
                            Close();
                        }
                        break;
                    }
                case 3:
                    {
                        if (string.IsNullOrEmpty(comboBox1.Text))
                            MessageBox.Show("Не выбран номер месяца!");
                        else
                        {
                            sn.sn_DeleteCondition(path, comboBox1.Text);
                            Close();
                        }

                        break;
                    }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(comboBox1.Text))
                MessageBox.Show("Не выбран номер месяц!");
            else
            {
                textBox1.Text = sn.sn_SeeByMonth(path, comboBox1.Text);
            }
        }
    }
}
