using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace MACEMP
{
    public partial class Form4 : Form
    {
        public static string connStr;
        public static MySqlConnection conn;
        public Form4()
        {
            InitializeComponent();
        }
        private void Form4_Load(object sender, EventArgs e)
        {

        }

 

        private void timer1_Tick(object sender, EventArgs e)
        {
            pictureBox1.Hide();
            tabControl1.Show();
            label44.Show();
            textBox2.Show();
            button2.Show();
            button3.Show();
        }

        public void check_update(string app11)
        {
            MySqlCommand command7777 = new MySqlCommand("SELECT info FROM about WHERE id =1", conn);
            string new_version = command7777.ExecuteScalar().ToString();
            if (new_version != app11)
            {
                DialogResult result = MessageBox.Show("Использование устаревшей версии невозможно! \r\nСкачать новую версию?", "Обновление", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
                if (result == DialogResult.Yes)
                {
                    MySqlCommand command8888 = new MySqlCommand("SELECT info FROM about WHERE id =2", conn);
                    string new_url = command8888.ExecuteScalar().ToString();
                    System.Diagnostics.Process.Start(new_url);
                    Application.Exit();
                }
                if (result == DialogResult.No)
                    Application.Exit();
            }
            if (new_version == app11)
                return;
        }
        public void reset_label()
        {
            label9.Text = null;
            label10.Text = null;
            label11.Text = null;
            label12.Text = null;
            label13.Text = null;
            label14.Text = null;
            label15.Text = null;
            label22.Text = null;
            label21.Text = null;
            label20.Text = null;
            label19.Text = null;
            label18.Text = null;
            label17.Text = null;
            label16.Text = null;
            label36.Text = null;
            label35.Text = null;
            label34.Text = null;
            label33.Text = null;
            label32.Text = null;
            label31.Text = null;
            label30.Text = null;
            label1.Text = null;
            label45.Text = null;
            label46.Text = null;
            return;
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            try
            {
                button1.Text = "Загрузка!";
                button1.Enabled = false;
                connStr = "server= 31.220.61.44" + ";user= fd56f4d8g4fg56fd" + ";database= mc_employees" + ";port= 1236" + ";password= gdf6541g8f6g74sdg8fh4f8g7f4g8fg8fgf;";
                conn = new MySqlConnection(connStr);
                conn.Open();
                button1.Hide();
                pictureBox1.Show();
                timer1.Start();
                check_update("1.0.0");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Проблемы с подключением.Подробнее :\r\n" + ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            reset_label();
            tabControl1.Hide();
            label44.Hide();
            textBox2.Hide();
            button2.Hide();
            button3.Hide();
            pictureBox1.Show();
            timer1.Start();

            string number_employee = textBox2.Text;

            try
            {
                MySqlCommand command0 = new MySqlCommand("SELECT Monday FROM last_week WHERE id_employee =" + number_employee, conn);
                if (command0.ExecuteScalar().ToString() == "0")
                    label9.Text = "Выходной";
                else label9.Text = command0.ExecuteScalar().ToString();

                MySqlCommand command1 = new MySqlCommand("SELECT Tuesday FROM last_week WHERE id_employee =" + number_employee, conn);
                if (command1.ExecuteScalar().ToString() == "0")
                    label10.Text = "Выходной";
                else label10.Text = command1.ExecuteScalar().ToString();

                MySqlCommand command2 = new MySqlCommand("SELECT Wednesday FROM last_week WHERE id_employee =" + number_employee, conn);
                if (command2.ExecuteScalar().ToString() == "0")
                    label11.Text = "Выходной";
                else label11.Text = command2.ExecuteScalar().ToString();

                MySqlCommand command3 = new MySqlCommand("SELECT Thursday FROM last_week WHERE id_employee =" + number_employee, conn);
                if (command3.ExecuteScalar().ToString() == "0")
                    label12.Text = "Выходной";
                else label12.Text = command3.ExecuteScalar().ToString();

                MySqlCommand command4 = new MySqlCommand("SELECT Friday FROM last_week WHERE id_employee =" + number_employee, conn);
                if (command4.ExecuteScalar().ToString() == "0")
                    label13.Text = "Выходной";
                else label13.Text = command4.ExecuteScalar().ToString();

                MySqlCommand command5 = new MySqlCommand("SELECT Saturday FROM last_week WHERE id_employee =" + number_employee, conn);
                if (command5.ExecuteScalar().ToString() == "0")
                    label14.Text = "Выходной";
                else label14.Text = command5.ExecuteScalar().ToString();

                MySqlCommand command6 = new MySqlCommand("SELECT Sunday FROM last_week WHERE id_employee =" + number_employee, conn);
                if (command6.ExecuteScalar().ToString() == "0")
                    label15.Text = "Выходной";
                else label15.Text = command6.ExecuteScalar().ToString();
            }
            catch (Exception)
            {
                label1.Text = "Прошедшая неделя - нет данных!";
            }

            try
            {
                MySqlCommand command7 = new MySqlCommand("SELECT Monday FROM now_week WHERE id_employee =" + number_employee, conn);
                if (command7.ExecuteScalar().ToString() == "0")
                    label22.Text = "Выходной";
                else label22.Text = command7.ExecuteScalar().ToString();

                MySqlCommand command8 = new MySqlCommand("SELECT Tuesday FROM now_week WHERE id_employee =" + number_employee, conn);
                if (command8.ExecuteScalar().ToString() == "0")
                    label21.Text = "Выходной";
                else label21.Text = command8.ExecuteScalar().ToString();

                MySqlCommand command9 = new MySqlCommand("SELECT Wednesday FROM now_week WHERE id_employee =" + number_employee, conn);
                if (command9.ExecuteScalar().ToString() == "0")
                    label20.Text = "Выходной";
                else label20.Text = command9.ExecuteScalar().ToString();

                MySqlCommand command10 = new MySqlCommand("SELECT Thursday FROM now_week WHERE id_employee =" + number_employee, conn);
                if (command10.ExecuteScalar().ToString() == "0")
                    label19.Text = "Выходной";
                else label19.Text = command10.ExecuteScalar().ToString();

                MySqlCommand command11 = new MySqlCommand("SELECT Friday FROM now_week WHERE id_employee =" + number_employee, conn);
                if (command11.ExecuteScalar().ToString() == "0")
                    label18.Text = "Выходной";
                else label18.Text = command11.ExecuteScalar().ToString();

                MySqlCommand command12 = new MySqlCommand("SELECT Saturday FROM now_week WHERE id_employee =" + number_employee, conn);
                if (command12.ExecuteScalar().ToString() == "0")
                    label17.Text = "Выходной";
                else label17.Text = command12.ExecuteScalar().ToString();

                MySqlCommand command13 = new MySqlCommand("SELECT Sunday FROM now_week WHERE id_employee =" + number_employee, conn);
                if (command13.ExecuteScalar().ToString() == "0")
                    label16.Text = "Выходной";
                else label16.Text = command13.ExecuteScalar().ToString();
            }
            catch (Exception)
            {
                label45.Text = "Текущая неделя - нет данных!";
            }

            try
            {

                MySqlCommand command14 = new MySqlCommand("SELECT Monday FROM next_week WHERE id_employee =" + number_employee, conn);
                if (command14.ExecuteScalar().ToString() == "0")
                    label36.Text = "Выходной";
                else label36.Text = command14.ExecuteScalar().ToString();

                MySqlCommand command15 = new MySqlCommand("SELECT Tuesday FROM next_week WHERE id_employee =" + number_employee, conn);
                if (command15.ExecuteScalar().ToString() == "0")
                    label35.Text = "Выходной";
                else label35.Text = command15.ExecuteScalar().ToString();

                MySqlCommand command16 = new MySqlCommand("SELECT Wednesday FROM next_week WHERE id_employee =" + number_employee, conn);
                if (command16.ExecuteScalar().ToString() == "0")
                    label34.Text = "Выходной";
                else label34.Text = command16.ExecuteScalar().ToString();

                MySqlCommand command17 = new MySqlCommand("SELECT Thursday FROM next_week WHERE id_employee =" + number_employee, conn);
                if (command17.ExecuteScalar().ToString() == "0")
                    label33.Text = "Выходной";
                else label33.Text = command17.ExecuteScalar().ToString();

                MySqlCommand command18 = new MySqlCommand("SELECT Friday FROM next_week WHERE id_employee =" + number_employee, conn);
                if (command18.ExecuteScalar().ToString() == "0")
                    label32.Text = "Выходной";
                else label32.Text = command18.ExecuteScalar().ToString();

                MySqlCommand command19 = new MySqlCommand("SELECT Saturday FROM next_week WHERE id_employee =" + number_employee, conn);
                if (command19.ExecuteScalar().ToString() == "0")
                    label31.Text = "Выходной";
                else label31.Text = command19.ExecuteScalar().ToString();

                MySqlCommand command20 = new MySqlCommand("SELECT Sunday FROM next_week WHERE id_employee =" + number_employee, conn);
                if (command20.ExecuteScalar().ToString() == "0")
                    label30.Text = "Выходной";
                else label30.Text = command20.ExecuteScalar().ToString();
            }
            catch (Exception)
            {
                label46.Text = "Следующая неделя - нет данных!";
            }

            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form6 ff6 = new Form6();
            ff6.ShowDialog();
        }







        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                MySqlCommand command211 = new MySqlCommand("SELECT `id_employee` FROM `now_week` WHERE `Monday` LIKE '0'", conn);
                MySqlDataReader MyDataReader = command211.ExecuteReader();
                ArrayList listName21 = new ArrayList();
                while (MyDataReader.Read())
                {
                    for (var i = 0; i < MyDataReader.FieldCount; i++)
                    {
                        listName21.Add(MyDataReader.GetString(i));
                    }
                }
                MyDataReader.Close();
                string value = string.Join("\r\n", listName21.ToArray());
                MessageBox.Show(value);

            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            

            
        }

        private void button5_Click(object sender, EventArgs e)
        {
                MySqlCommand command221 = new MySqlCommand("SELECT `id_employee` FROM `now_week` WHERE `Tuesday` LIKE '0'", conn);
                MySqlDataReader MyDataReader = command221.ExecuteReader();
                ArrayList listName22 = new ArrayList();
                while (MyDataReader.Read())
                {
                    for (var i = 0; i < MyDataReader.FieldCount; i++)
                    {
                        listName22.Add(MyDataReader.GetString(i));
                    }
                }
                MyDataReader.Close();
                string value = string.Join("\r\n", listName22.ToArray());
                MessageBox.Show(value);
        }

        private void button6_Click(object sender, EventArgs e)
        {
                MySqlCommand command231 = new MySqlCommand("SELECT `id_employee` FROM `now_week` WHERE `Wednesday` LIKE '0'", conn);
                MySqlDataReader MyDataReader = command231.ExecuteReader();
                ArrayList listName23 = new ArrayList();
                while (MyDataReader.Read())
                {
                    for (var i = 0; i < MyDataReader.FieldCount; i++)
                    {
                        listName23.Add(MyDataReader.GetString(i));
                    }
                }
                MyDataReader.Close();
                string value = string.Join("\r\n", listName23.ToArray());
                MessageBox.Show(value);
        }

        private void button7_Click(object sender, EventArgs e)
        {
                MySqlCommand command241 = new MySqlCommand("SELECT `id_employee` FROM `now_week` WHERE `Thursday` LIKE '0'", conn);
                MySqlDataReader MyDataReader = command241.ExecuteReader();
                ArrayList listName24 = new ArrayList();
                while (MyDataReader.Read())
                {
                    for (var i = 0; i < MyDataReader.FieldCount; i++)
                    {
                        listName24.Add(MyDataReader.GetString(i));
                    }
                }
                MyDataReader.Close();
                string value = string.Join("\r\n", listName24.ToArray());
                MessageBox.Show(value);
        }

        private void button8_Click(object sender, EventArgs e)
        {
                MySqlCommand command251 = new MySqlCommand("SELECT `id_employee` FROM `now_week` WHERE `Friday` LIKE '0'", conn);
                MySqlDataReader MyDataReader = command251.ExecuteReader();
                ArrayList listName25 = new ArrayList();
                while (MyDataReader.Read())
                {
                    for (var i = 0; i < MyDataReader.FieldCount; i++)
                    {
                        listName25.Add(MyDataReader.GetString(i));
                    }
                }
                MyDataReader.Close();
                string value = string.Join("\r\n", listName25.ToArray());
                MessageBox.Show(value);
        }

        private void button9_Click(object sender, EventArgs e)
        {
                MySqlCommand command261 = new MySqlCommand("SELECT `id_employee` FROM `now_week` WHERE `Saturday` LIKE '0'", conn);
                MySqlDataReader MyDataReader = command261.ExecuteReader();
                ArrayList listName26 = new ArrayList();
                while (MyDataReader.Read())
                {
                    for (var i = 0; i < MyDataReader.FieldCount; i++)
                    {
                        listName26.Add(MyDataReader.GetString(i));
                    }
                }
                MyDataReader.Close();
                string value = string.Join("\r\n", listName26.ToArray());
                MessageBox.Show(value);
        }

        private void button10_Click(object sender, EventArgs e)
        {
                MySqlCommand command271 = new MySqlCommand("SELECT `id_employee` FROM `now_week` WHERE `Sunday` LIKE '0'", conn);
                MySqlDataReader MyDataReader = command271.ExecuteReader();
                ArrayList listName27 = new ArrayList();
                while (MyDataReader.Read())
                {
                    for (var i = 0; i < MyDataReader.FieldCount; i++)
                    {
                        listName27.Add(MyDataReader.GetString(i));
                    }
                }
                MyDataReader.Close();
                string value = string.Join("\r\n", listName27.ToArray());
                MessageBox.Show(value);
        }

        private void button17_Click(object sender, EventArgs e)
        {
                MySqlCommand command311 = new MySqlCommand("SELECT `id_employee` FROM `next_week` WHERE `Monday` LIKE '0'", conn);
                MySqlDataReader MyDataReader = command311.ExecuteReader();
                ArrayList listName31 = new ArrayList();
                while (MyDataReader.Read())
                {
                    for (var i = 0; i < MyDataReader.FieldCount; i++)
                    {
                        listName31.Add(MyDataReader.GetString(i));
                    }
                }
                MyDataReader.Close();
                string value = string.Join("\r\n", listName31.ToArray());
                MessageBox.Show(value);
        }

        private void button16_Click(object sender, EventArgs e)
        {
                MySqlCommand command321 = new MySqlCommand("SELECT `id_employee` FROM `next_week` WHERE `Tuesday` LIKE '0'", conn);
                MySqlDataReader MyDataReader = command321.ExecuteReader();
                ArrayList listName32 = new ArrayList();
                while (MyDataReader.Read())
                {
                    for (var i = 0; i < MyDataReader.FieldCount; i++)
                    {
                        listName32.Add(MyDataReader.GetString(i));
                    }
                }
                MyDataReader.Close();
                string value = string.Join("\r\n", listName32.ToArray());
                MessageBox.Show(value);
        }

        private void button15_Click(object sender, EventArgs e)
        {
                MySqlCommand command331 = new MySqlCommand("SELECT `id_employee` FROM `next_week` WHERE `Wednesday` LIKE '0'", conn);
                MySqlDataReader MyDataReader = command331.ExecuteReader();
                ArrayList listName33 = new ArrayList();
                while (MyDataReader.Read())
                {
                    for (var i = 0; i < MyDataReader.FieldCount; i++)
                    {
                        listName33.Add(MyDataReader.GetString(i));
                    }
                }
                MyDataReader.Close();
                string value = string.Join("\r\n", listName33.ToArray());
                MessageBox.Show(value);
        }

        private void button14_Click(object sender, EventArgs e)
        {
                MySqlCommand command341 = new MySqlCommand("SELECT `id_employee` FROM `next_week` WHERE `Saturday` LIKE '0'", conn);
                MySqlDataReader MyDataReader = command341.ExecuteReader();
                ArrayList listName34 = new ArrayList();
                while (MyDataReader.Read())
                {
                    for (var i = 0; i < MyDataReader.FieldCount; i++)
                    {
                        listName34.Add(MyDataReader.GetString(i));
                    }
                }
                MyDataReader.Close();
                string value = string.Join("\r\n", listName34.ToArray());
                MessageBox.Show(value);
        }

        private void button13_Click(object sender, EventArgs e)
        {
                MySqlCommand command351 = new MySqlCommand("SELECT `id_employee` FROM `next_week` WHERE `Friday` LIKE '0'", conn);
                MySqlDataReader MyDataReader = command351.ExecuteReader();
                ArrayList listName35 = new ArrayList();
                while (MyDataReader.Read())
                {
                    for (var i = 0; i < MyDataReader.FieldCount; i++)
                    {
                        listName35.Add(MyDataReader.GetString(i));
                    }
                }
                MyDataReader.Close();
                string value = string.Join("\r\n", listName35.ToArray());
                MessageBox.Show(value);
        }

        private void button12_Click(object sender, EventArgs e)
        {
                MySqlCommand command361 = new MySqlCommand("SELECT `id_employee` FROM `next_week` WHERE `Saturday` LIKE '0'", conn);
                MySqlDataReader MyDataReader = command361.ExecuteReader();
                ArrayList listName36 = new ArrayList();
                while (MyDataReader.Read())
                {
                    for (var i = 0; i < MyDataReader.FieldCount; i++)
                    {
                        listName36.Add(MyDataReader.GetString(i));
                    }
                }
                MyDataReader.Close();
                string value = string.Join("\r\n", listName36.ToArray());
                MessageBox.Show(value);
        }

        private void button11_Click(object sender, EventArgs e)
        {
                MySqlCommand command371 = new MySqlCommand("SELECT `id_employee` FROM `next_week` WHERE `Sunday` LIKE '0'", conn);
                MySqlDataReader MyDataReader = command371.ExecuteReader();
                ArrayList listName37 = new ArrayList();
                while (MyDataReader.Read())
                {
                    for (var i = 0; i < MyDataReader.FieldCount; i++)
                    {
                        listName37.Add(MyDataReader.GetString(i));
                    }
                }
                MyDataReader.Close();
                string value = string.Join("\r\n", listName37.ToArray());
                MessageBox.Show(value);
        }

        protected override void OnClosed(EventArgs e)
        {
                conn.Close();
                this.Close();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (textBox2.Text.Length == 0)
                if (e.KeyChar == '0') e.Handled = true;
            char number = e.KeyChar;

            if (!Char.IsDigit(number))
            {
                e.Handled = true;
            }
        }
    }
}
