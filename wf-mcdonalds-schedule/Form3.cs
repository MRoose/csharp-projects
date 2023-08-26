using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace MACEMP
{
    public partial class Form3 : Form
    {
        public static string connStr_AC;
        public static MySqlConnection conn_AC;

        public Form3()
        {
            InitializeComponent();
        }
        public void mf(string f_msg)
        {
            label6.Text = f_msg;
            timer1.Start();
        }

        private void Form3_Load(object sender, EventArgs e)
        {

        }

        


        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                connStr_AC = "server= " + Properties.Settings.Default.host2 + ";user= " + Properties.Settings.Default.login2 + ";database= " + Properties.Settings.Default.ndb2 + ";port= " + Properties.Settings.Default.port2 + ";password= " + Properties.Settings.Default.pswd2 + ";";
                conn_AC = new MySqlConnection(connStr_AC);
                conn_AC.Open();

                button1.Hide();
                button2.Enabled = true;
                button3.Enabled = true;
                button4.Enabled = true;
                button5.Enabled = true;
                button6.Enabled = true;
                mf("Успешное подключение!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Проблемы с подключением.Подробнее :" + "\r\n" + ex.Message);
            }
            //MessageBox.Show(Properties.Settings.Default.host2 + Properties.Settings.Default.login2 + Properties.Settings.Default.ndb2 + Properties.Settings.Default.port2 + Properties.Settings.Default.pswd2);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            try
            {
                MySqlCommand com1 = new MySqlCommand("INSERT INTO `last_week` SELECT * FROM `now_week`;", conn_AC);
                com1.ExecuteNonQuery();
                mf("Копирование из now_week в last_week выполнено успешно!");
            }
            catch { mf("Ошибка в копировании из now_week в last_week!"); }
            
        }
        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                MySqlCommand com2 = new MySqlCommand("INSERT INTO `now_week` SELECT * FROM `next_week`;", conn_AC);
                com2.ExecuteNonQuery();
                mf("Копирование из next_week в now_week выполнено успешно!");
            }
            catch { mf("Ошибка в копировании из next_week в now_week!"); }
        }




        protected override void OnClosed(EventArgs e)
        {
            if (conn_AC.State == ConnectionState.Open)
                conn_AC.Close();
            else this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                MySqlCommand com3 = new MySqlCommand("TRUNCATE TABLE last_week;", conn_AC);
                com3.ExecuteNonQuery();
                mf("Очистка last_week выполнена успешно!");
            }
            catch { mf("Очистка last_week не выполнена. Ошибка!"); }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                MySqlCommand com4 = new MySqlCommand("TRUNCATE TABLE now_week;", conn_AC);
                com4.ExecuteNonQuery();
                mf("Очистка now_week выполнена успешно!");
            }
            catch { mf("Очистка now_week не выполнена. Ошибка!"); }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                MySqlCommand com5 = new MySqlCommand("TRUNCATE TABLE next_week;", conn_AC);
                com5.ExecuteNonQuery();
                mf("Очистка next_week выполнена успешно!");
            }
            catch { mf("Очистка next_week не выполнена. Ошибка!"); }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label6.Text = null;
        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            Form5 ff5 = new Form5();
            ff5.ShowDialog();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (checkBox1.Checked == false && checkBox2.Checked == false && checkBox3.Checked == false && checkBox4.Checked == false && checkBox5.Checked == false)
            {
                int id1 = (int)numericUpDown1.Value;
                int id2 = (int)numericUpDown2.Value;
                int id3 = (int)numericUpDown3.Value;
                int id4 = (int)numericUpDown4.Value;
                int id5 = (int)numericUpDown5.Value;
                int id6 = (int)numericUpDown6.Value;
                MySqlCommand com8 = new MySqlCommand("INSERT INTO next_week(id_employee, Monday, Tuesday, Wednesday, Thursday, Friday, Saturday, Sunday) VALUES(" + id1 + ",'" + textBox6.Text + "','" + textBox7.Text + "','" + textBox8.Text + "','" + textBox9.Text + "','" + textBox10.Text + "','" + textBox11.Text + "','" + textBox12.Text + "');" +
                                                 "INSERT INTO next_week(id_employee, Monday, Tuesday, Wednesday, Thursday, Friday, Saturday, Sunday) VALUES(" + id2 + ", '" + textBox13.Text + "', '" + textBox14.Text + "', '" + textBox15.Text + "', '" + textBox16.Text + "', '" + textBox17.Text + "', '" + textBox18.Text + "', '" + textBox19.Text + "');" +
                                                 "INSERT INTO next_week(id_employee, Monday, Tuesday, Wednesday, Thursday, Friday, Saturday, Sunday) VALUES(" + id3 + ", '" + textBox20.Text + "', '" + textBox21.Text + "', '" + textBox22.Text + "', '" + textBox23.Text + "', '" + textBox24.Text + "', '" + textBox25.Text + "', '" + textBox26.Text + "');" +
                                                 "INSERT INTO next_week(id_employee, Monday, Tuesday, Wednesday, Thursday, Friday, Saturday, Sunday) VALUES(" + id4 + ", '" + textBox27.Text + "', '" + textBox28.Text + "', '" + textBox29.Text + "', '" + textBox30.Text + "', '" + textBox31.Text + "', '" + textBox32.Text + "', '" + textBox33.Text + "');" +
                                                 "INSERT INTO next_week(id_employee, Monday, Tuesday, Wednesday, Thursday, Friday, Saturday, Sunday) VALUES(" + id5 + ", '" + textBox34.Text + "', '" + textBox35.Text + "', '" + textBox36.Text + "', '" + textBox37.Text + "', '" + textBox38.Text + "', '" + textBox39.Text + "', '" + textBox40.Text + "');" +
                                                 "INSERT INTO next_week(id_employee, Monday, Tuesday, Wednesday, Thursday, Friday, Saturday, Sunday) VALUES(" + id6 + ", '" + textBox41.Text + "', '" + textBox42.Text + "', '" + textBox43.Text + "', '" + textBox44.Text + "', '" + textBox45.Text + "', '" + textBox46.Text + "', '" + textBox47.Text + "');", conn_AC);
                com8.ExecuteNonQuery();
            }
            if (checkBox1.Checked == false && checkBox2.Checked == false && checkBox3.Checked == false && checkBox4.Checked == false && checkBox5.Checked == true)
            {
                int id1 = (int)numericUpDown1.Value;
                int id2 = (int)numericUpDown2.Value;
                int id3 = (int)numericUpDown3.Value;
                int id4 = (int)numericUpDown4.Value;
                int id5 = (int)numericUpDown5.Value;
                MySqlCommand com8 = new MySqlCommand("INSERT INTO next_week(id_employee, Monday, Tuesday, Wednesday, Thursday, Friday, Saturday, Sunday) VALUES(" + id1 + ",'" + textBox6.Text + "','" + textBox7.Text + "','" + textBox8.Text + "','" + textBox9.Text + "','" + textBox10.Text + "','" + textBox11.Text + "','" + textBox12.Text + "');" +
                                                 "INSERT INTO next_week(id_employee, Monday, Tuesday, Wednesday, Thursday, Friday, Saturday, Sunday) VALUES(" + id2 + ", '" + textBox13.Text + "', '" + textBox14.Text + "', '" + textBox15.Text + "', '" + textBox16.Text + "', '" + textBox17.Text + "', '" + textBox18.Text + "', '" + textBox19.Text + "');" +
                                                 "INSERT INTO next_week(id_employee, Monday, Tuesday, Wednesday, Thursday, Friday, Saturday, Sunday) VALUES(" + id3 + ", '" + textBox20.Text + "', '" + textBox21.Text + "', '" + textBox22.Text + "', '" + textBox23.Text + "', '" + textBox24.Text + "', '" + textBox25.Text + "', '" + textBox26.Text + "');" +
                                                 "INSERT INTO next_week(id_employee, Monday, Tuesday, Wednesday, Thursday, Friday, Saturday, Sunday) VALUES(" + id4 + ", '" + textBox27.Text + "', '" + textBox28.Text + "', '" + textBox29.Text + "', '" + textBox30.Text + "', '" + textBox31.Text + "', '" + textBox32.Text + "', '" + textBox33.Text + "');" +
                                                 "INSERT INTO next_week(id_employee, Monday, Tuesday, Wednesday, Thursday, Friday, Saturday, Sunday) VALUES(" + id5 + ", '" + textBox34.Text + "', '" + textBox35.Text + "', '" + textBox36.Text + "', '" + textBox37.Text + "', '" + textBox38.Text + "', '" + textBox39.Text + "', '" + textBox40.Text + "');", conn_AC);
                com8.ExecuteNonQuery();
            }
            if (checkBox1.Checked == false && checkBox2.Checked == false && checkBox3.Checked == false && checkBox4.Checked == true && checkBox5.Checked == true)
            {
                int id1 = (int)numericUpDown1.Value;
                int id2 = (int)numericUpDown2.Value;
                int id3 = (int)numericUpDown3.Value;
                int id4 = (int)numericUpDown4.Value;
                MySqlCommand com8 = new MySqlCommand("INSERT INTO next_week(id_employee, Monday, Tuesday, Wednesday, Thursday, Friday, Saturday, Sunday) VALUES(" + id1 + ",'" + textBox6.Text + "','" + textBox7.Text + "','" + textBox8.Text + "','" + textBox9.Text + "','" + textBox10.Text + "','" + textBox11.Text + "','" + textBox12.Text + "');" +
                                                 "INSERT INTO next_week(id_employee, Monday, Tuesday, Wednesday, Thursday, Friday, Saturday, Sunday) VALUES(" + id2 + ", '" + textBox13.Text + "', '" + textBox14.Text + "', '" + textBox15.Text + "', '" + textBox16.Text + "', '" + textBox17.Text + "', '" + textBox18.Text + "', '" + textBox19.Text + "');" +
                                                 "INSERT INTO next_week(id_employee, Monday, Tuesday, Wednesday, Thursday, Friday, Saturday, Sunday) VALUES(" + id3 + ", '" + textBox20.Text + "', '" + textBox21.Text + "', '" + textBox22.Text + "', '" + textBox23.Text + "', '" + textBox24.Text + "', '" + textBox25.Text + "', '" + textBox26.Text + "');" +
                                                 "INSERT INTO next_week(id_employee, Monday, Tuesday, Wednesday, Thursday, Friday, Saturday, Sunday) VALUES(" + id4 + ", '" + textBox27.Text + "', '" + textBox28.Text + "', '" + textBox29.Text + "', '" + textBox30.Text + "', '" + textBox31.Text + "', '" + textBox32.Text + "', '" + textBox33.Text + "');", conn_AC);
                com8.ExecuteNonQuery();
            }
            if (checkBox1.Checked == false && checkBox2.Checked == false && checkBox3.Checked == true && checkBox4.Checked == true && checkBox5.Checked == true)
            {
                int id1 = (int)numericUpDown1.Value;
                int id2 = (int)numericUpDown2.Value;
                int id3 = (int)numericUpDown3.Value;
                MySqlCommand com8 = new MySqlCommand("INSERT INTO next_week(id_employee, Monday, Tuesday, Wednesday, Thursday, Friday, Saturday, Sunday) VALUES(" + id1 + ",'" + textBox6.Text + "','" + textBox7.Text + "','" + textBox8.Text + "','" + textBox9.Text + "','" + textBox10.Text + "','" + textBox11.Text + "','" + textBox12.Text + "');" +
                                                 "INSERT INTO next_week(id_employee, Monday, Tuesday, Wednesday, Thursday, Friday, Saturday, Sunday) VALUES(" + id2 + ", '" + textBox13.Text + "', '" + textBox14.Text + "', '" + textBox15.Text + "', '" + textBox16.Text + "', '" + textBox17.Text + "', '" + textBox18.Text + "', '" + textBox19.Text + "');" +
                                                 "INSERT INTO next_week(id_employee, Monday, Tuesday, Wednesday, Thursday, Friday, Saturday, Sunday) VALUES(" + id3 + ", '" + textBox20.Text + "', '" + textBox21.Text + "', '" + textBox22.Text + "', '" + textBox23.Text + "', '" + textBox24.Text + "', '" + textBox25.Text + "', '" + textBox26.Text + "');", conn_AC);
                com8.ExecuteNonQuery();
            }
            if (checkBox1.Checked == false && checkBox2.Checked == true && checkBox3.Checked == true && checkBox4.Checked == true && checkBox5.Checked == true)
            {
                int id1 = (int)numericUpDown1.Value;
                int id2 = (int)numericUpDown2.Value;
                MySqlCommand com8 = new MySqlCommand("INSERT INTO next_week(id_employee, Monday, Tuesday, Wednesday, Thursday, Friday, Saturday, Sunday) VALUES(" + id1 + ",'" + textBox6.Text + "','" + textBox7.Text + "','" + textBox8.Text + "','" + textBox9.Text + "','" + textBox10.Text + "','" + textBox11.Text + "','" + textBox12.Text + "');" +
                                                 "INSERT INTO next_week(id_employee, Monday, Tuesday, Wednesday, Thursday, Friday, Saturday, Sunday) VALUES(" + id2 + ", '" + textBox13.Text + "', '" + textBox14.Text + "', '" + textBox15.Text + "', '" + textBox16.Text + "', '" + textBox17.Text + "', '" + textBox18.Text + "', '" + textBox19.Text + "');", conn_AC);
                com8.ExecuteNonQuery();
            }
            if (checkBox1.Checked == true && checkBox2.Checked == true && checkBox3.Checked == true && checkBox4.Checked == true && checkBox5.Checked == true)
            {
                int id1 = (int)numericUpDown1.Value;
                MySqlCommand com8 = new MySqlCommand("INSERT INTO next_week(id_employee, Monday, Tuesday, Wednesday, Thursday, Friday, Saturday, Sunday) VALUES(" + id1 + ",'" + textBox6.Text + "','" + textBox7.Text + "','" + textBox8.Text + "','" + textBox9.Text + "','" + textBox10.Text + "','" + textBox11.Text + "','" + textBox12.Text + "');", conn_AC);
                com8.ExecuteNonQuery();
            }

        }

        private void button9_Click(object sender, EventArgs e)
        {
            textBox6.Text = "0";
            textBox7.Text = "0";
            textBox8.Text = "0";
            textBox9.Text = "0";
            textBox10.Text = "0";
            textBox11.Text = "0";
            textBox12.Text = "0";
            textBox13.Text = "0";
            textBox14.Text = "0";
            textBox15.Text = "0";
            textBox16.Text = "0";
            textBox17.Text = "0";
            textBox18.Text = "0";
            textBox19.Text = "0";
            textBox20.Text = "0";
            textBox21.Text = "0";
            textBox22.Text = "0";
            textBox23.Text = "0";
            textBox24.Text = "0";
            textBox25.Text = "0";
            textBox26.Text = "0";
            textBox27.Text = "0";
            textBox28.Text = "0";
            textBox29.Text = "0";
            textBox30.Text = "0";
            textBox31.Text = "0";
            textBox32.Text = "0";
            textBox33.Text = "0";
            textBox34.Text = "0";
            textBox35.Text = "0";
            textBox36.Text = "0";
            textBox37.Text = "0";
            textBox38.Text = "0";
            textBox39.Text = "0";
            textBox40.Text = "0";
            textBox41.Text = "0";
            textBox42.Text = "0";
            textBox43.Text = "0";
            textBox44.Text = "0";
            textBox45.Text = "0";
            textBox46.Text = "0";
            textBox47.Text = "0";
        }
    }
}
