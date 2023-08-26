using System;
using System.Data;
using System.Windows.Forms;
using ConnCore;

namespace Ely_adm
{
    public partial class rout_set2 : Form
    {
        tr_Control tr = new tr_Control();
        int mode;

        public rout_set2(int mode)
        {
            InitializeComponent();

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

                        comboBox1.DataSource = tr.tr_ListOfRole();
                        comboBox1.DisplayMember = "role";

                        button3.Visible = true;

                        break;
                    }
                case 3:
                    {
                        Text = "Удалить";

                        comboBox1.DataSource = tr.tr_ListOfRole();
                        comboBox1.DisplayMember = "role";

                        textBox1.Enabled = false;
                        textBox2.Enabled = false;

                        break;
                    }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            label4.Text = textBox2.TextLength + "/50";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            switch (mode)
            {
                case 1:
                    {
                        if (string.IsNullOrEmpty(comboBox1.Text) || string.IsNullOrEmpty(textBox1.Text) || string.IsNullOrEmpty(textBox2.Text))
                            MessageBox.Show("Заполнены не все поля!");
                        else
                        {
                            tr.tr_AddVersion(comboBox1.Text, textBox1.Text, textBox2.Text);
                            Close();
                        }

                        break;
                    }
                case 2:
                    {
                        if (string.IsNullOrEmpty(comboBox1.Text) || string.IsNullOrEmpty(textBox1.Text) || string.IsNullOrEmpty(textBox2.Text))
                            MessageBox.Show("Заполнены не все поля!");
                        else
                        {
                            tr.tr_UpdateVersion(comboBox1.Text, textBox1.Text, textBox2.Text);
                            Close();
                        }

                        break;
                    }
                case 3:
                    {
                        if (string.IsNullOrEmpty(comboBox1.Text))
                            MessageBox.Show("Не выбрана роль!");
                        else
                        {
                            tr.tr_DeleteVersion(comboBox1.Text);
                            Close();
                        }

                        break;
                    }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(comboBox1.Text))
                MessageBox.Show("Не выбрана роль!");
            else
            {
                DataTable dt = new DataTable();
                dt = tr.tr_SeeByRole(comboBox1.Text);

                textBox1.Text = dt.Rows[0][0].ToString();
                textBox2.Text = dt.Rows[0][1].ToString();
            }
        }
    }
}
