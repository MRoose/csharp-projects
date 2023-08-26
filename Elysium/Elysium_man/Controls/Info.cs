using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using QuestCore;
using ConnCore;

namespace Ely_man
{
    public partial class Info : UserControl
    {
        string wl, nick;
        DataTable input;

        DT_Sort dts = new DT_Sort();
        tr_Show tr = new tr_Show();
        sn_Show sn = new sn_Show();
        poj_Show poj = new poj_Show();
        connection_strings cstr = new connection_strings();
        

        public Info()
        {
            InitializeComponent();
        }

        //любая группа
        public Info(DataTable input, string nick, int mode):this()
        {
            this.input = input;
            this.nick = nick;

            switch (mode)
            {
                //время для внесения не вышло
                case 0:
                    {
                        button4.Text = "Введите логин РГ";
                        button5.Text = "Введите логин РГ";
                        label5.Text = "Введите логин РГ";
                        break;
                    }
                //время вышло
                case 1:
                    {
                        label3.Visible = false;
                        comboBox1.Visible = false;
                        button4.Visible = false;
                        button5.Visible = false;

                        button1.Visible = false;
                        button2.Visible = false;
                        button3.Visible = false;
                        break;
                    }
            }
            
        }

        //РГ известен
        public Info(DataTable input, string wl, string nick, int mode):this()
        {
            this.input = input;
            this.nick = nick;
            this.wl = wl;

            label8.Visible = false;
            textBox1.Visible = false;
            button6.Visible = false;

            dataGridView1.DataSource = new DT_Sort().GetFIOByRG(input, wl);

            switch (mode)
            {
                //время для внесения не вышло
                case 0:
                    {                       
                        button5.Text += wl;
                        label5.Text += wl;
                        break;
                    }
                //время вышло
                case 1:
                    {
                        label3.Visible = false;
                        comboBox1.Visible = false;
                        button4.Visible = false;
                        button5.Visible = false;

                        button1.Visible = false;
                        button2.Visible = false;
                        button3.Visible = false;
                        break;
                    }
            }
            result();
        }

        void result()
        {
            if (string.IsNullOrEmpty(wl))
                MessageBox.Show("Логин руководителя не задан!");
            else
            {
                if (poj.poj_CountByWL(wl, nick) > 0)
                {
                    DataTable dr = poj.poj_ReadByWL(wl, nick);
                    textBox2.Clear(); ;
                    for (int i = 0; i < dr.Columns.Count; i++)
                    {
                        if (!string.IsNullOrEmpty(dr.Rows[0][i].ToString()))
                            textBox2.Text += dr.Rows[0][i].ToString() + "\r\n";
                    }
                }
                else textBox2.Text = "Оставленные пожелания отсутствуют.";

                DataTable emp_all = new DataTable();
                emp_all = dts.GetWLByRG(input, wl);
                comboBox1.DataSource = emp_all;
                comboBox1.DisplayMember = "wl";


                DataTable emp_get = new DataTable();
                emp_get = poj.poj_GetWLByRG(wl, nick);

                DataTable emp_bad = new DataTable();
                emp_bad = new DT_Compare().AnalizTable(emp_all, emp_get);
                checkedListBox1.DataSource = emp_bad;
                checkedListBox1.DisplayMember = "wl";

                dataGridView2.DataSource = poj.poj_ReadGroup(wl, nick);                
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < checkedListBox1.Items.Count; i++)
            {
                checkedListBox1.SetItemChecked(i, true);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < checkedListBox1.Items.Count; i++)
            {
                checkedListBox1.SetItemChecked(i, false);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (checkedListBox1.CheckedItems.Count >= 1)
            {
                StringBuilder sb = new StringBuilder();
                foreach (var item in checkedListBox1.CheckedItems)
                {
                    string curItemString = ((DataRowView)item)[checkedListBox1.DisplayMember].ToString();
                    sb.Append(curItemString + "@tinkoff.ru;");
                }
                System.Diagnostics.Process.Start("mailto:" + sb.ToString() + "?subject=Срочно оставьте пожелания!");
            }
            else MessageBox.Show("Никто не выбран!");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(comboBox1.Text))
                MessageBox.Show("А логин сотрудника кто выберет?!");
            else
            {
                string temp_wl = comboBox1.Text;
                DataRow[] about_emp = dts.AboutMe(input, temp_wl);
                string name_q = "";
                if (about_emp.Length == 1)
                {
                    DialogResult res = MessageBox.Show("При выгрузке списка вопросов ориентруемся на стаж сотрудника?", "Выбор списка пожеланий", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
                    if (res == DialogResult.Yes)
                    {
                        name_q = sn.sn_GetNameQ1(Convert.ToDateTime(about_emp[0][8]), nick);
                    }
                    if (res == DialogResult.No)
                    {
                        name_q = cstr.questions + nick + "\\" + nick + ".q";
                    }


                    if (File.Exists(name_q))
                    {
                        if (poj.poj_CountByWL(temp_wl, nick) >= 1)
                        {
                            DialogResult result = MessageBox.Show("Пожелания уже оставлены. Удаляем и оставляем новые?", "Как поступим?", MessageBoxButtons.OKCancel, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1);
                            if (result == DialogResult.OK)
                            {
                                poj.poj_DeleteByWL(temp_wl, nick);
                                new InterviewForm(Convert.ToInt32(about_emp[0][0]), temp_wl, about_emp[0][4].ToString(), name_q, cstr.output + nick + ".db").ShowDialog(this);
                            }
                            if (result == DialogResult.Cancel)
                                return;
                        }
                        else
                        {
                            new InterviewForm(Convert.ToInt32(about_emp[0][0]), temp_wl, about_emp[0][4].ToString(), name_q, cstr.output + nick + ".db").ShowDialog(this);
                        }
                    }
                    else MessageBox.Show("Не удалось найти для него список вопросов :(");
                }
                else MessageBox.Show("Не удалось найти ин-цию по сотруднику. Или он не выбран.");
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            DataRow[] about_rg = dts.AboutMe(input, wl);
            string name_q = cstr.questions + nick + "//rg_" + nick + ".q";

            if(File.Exists(name_q))
            {
                if (poj.poj_CountByWL(wl, nick) >= 1)
                {
                    DialogResult result = MessageBox.Show("Пожелания уже оставлены. Удаляем и оставляем новые?", "Как поступим?", MessageBoxButtons.YesNo, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1);
                    if (result == DialogResult.Yes)
                    {
                        poj.poj_DeleteByWL(wl, nick);
                        new InterviewForm(Convert.ToInt32(about_rg[0][0]), wl, about_rg[0][4].ToString(), name_q, cstr.output + nick + ".db").ShowDialog(this);
                    }
                    if (result == DialogResult.No)
                        return;
                }
                else
                {
                    new InterviewForm(Convert.ToInt32(about_rg[0][0]), wl, about_rg[0][4].ToString(), name_q, cstr.output + nick + ".db").ShowDialog(this);
                }
            }
            else MessageBox.Show("Не удалось найти для РГ список вопросов :(");
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(!button4.Enabled)
                button4.Enabled = true;
            button4.Text = "Оставить пожелания за " + comboBox1.Text;
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (!string.IsNullOrEmpty(wl))
                result();
            else MessageBox.Show("Логин руководителя не задан!");
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox1.Text))
                MessageBox.Show("А логин РГ кто будет вводить?!");
            else
            {
                wl = textBox1.Text;
                label5.Text += wl;
                button5.Text += wl;
                button4.Text = "Выберите выше";
                dataGridView1.DataSource = dts.GetFIOByRG(input, wl);
                result();
            }
        }

    }
}
