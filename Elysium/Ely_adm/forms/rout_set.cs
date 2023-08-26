using System;
using System.Data;
using System.Windows.Forms;
using ConnCore;

namespace Ely_adm
{
    public partial class rout_set : Form
    {
        tr_Control tr = new tr_Control();
        int mode;

        public rout_set(int mode)
        {
            InitializeComponent();
            this.mode = mode;


            switch(mode)
            {
                case 1:
                    {
                        Text = "Добавить";
                        break;
                    }
                case 2:
                    {
                        Text = "Редактировать";

                        comboBox2.DataSource = tr.tr_ListOfGPID();
                        comboBox2.DisplayMember = "gp_id";

                        button3.Visible = true;

                        break;
                    }
                case 3:
                    {
                        Text = "Удалить";

                        comboBox2.DataSource = tr.tr_ListOfGPID();
                        comboBox2.DisplayMember = "gp_id";

                        comboBox1.Enabled = false;
                        textBox2.Enabled = false;
                        textBox3.Enabled = false;
                        textBox4.Enabled = false;

                        break;
                    }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            label6.Text = textBox4.TextLength + "/1000";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            switch (mode)
            {
                case 1:
                    {
                        if (string.IsNullOrEmpty(comboBox2.Text) || string.IsNullOrEmpty(comboBox1.Text) || string.IsNullOrEmpty(textBox2.Text) || string.IsNullOrEmpty(textBox3.Text))
                            MessageBox.Show("Заполнены не все поля!");
                        else
                        {
                            tr.tr_AddOtdel(comboBox2.Text, comboBox1.Text, textBox2.Text, textBox3.Text, textBox4.Text);
                            Close();
                        }

                        break;
                    }
                case 2:
                    {
                        if (string.IsNullOrEmpty(comboBox2.Text) || string.IsNullOrEmpty(comboBox1.Text) || string.IsNullOrEmpty(textBox2.Text) || string.IsNullOrEmpty(textBox3.Text))
                            MessageBox.Show("Заполнены не все поля!");
                        else
                        {
                            tr.tr_UpdateOtdel(comboBox2.Text, comboBox1.Text, textBox2.Text, textBox3.Text, textBox4.Text);
                            Close();
                        }

                        break;
                    }
                case 3:
                    {
                        if (string.IsNullOrEmpty(comboBox2.Text))
                            MessageBox.Show("Не выбран gp_id!");
                        else
                        {
                            tr.tr_DeleteOtdel(comboBox2.Text);
                            Close();
                        }

                        break;
                    }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(comboBox2.Text))
                MessageBox.Show("Не выбран gp_id!");
            else
            {
                DataTable dt = new DataTable();
                dt = tr.tr_SeeByGPID(comboBox2.Text);

                comboBox1.Text = dt.Rows[0][0].ToString();
                textBox2.Text = dt.Rows[0][1].ToString();
                textBox3.Text = dt.Rows[0][2].ToString();
                textBox4.Text = dt.Rows[0][3].ToString();
            }
        }
    }
}
