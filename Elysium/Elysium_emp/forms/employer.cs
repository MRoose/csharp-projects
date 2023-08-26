using System;
using System.Windows.Forms;
using System.Data;
using System.IO;
using ConnCore;
using QuestCore;


namespace Ely_emp
{
    public partial class emp : Form
    {
        string fio, wl, rg, rg_wl, rs, rs_wl, role, otdel, nick, read, month, stop_d, name_que, mode;
        int wfm_id, gp_id;
        string[] cmd;

        DateTime stdt;
        DataRow[] about_me;

        DataTable transfer, input, set_poj;

        tr_Show tr = new tr_Show();
        sn_Show sn = new sn_Show();
        poj_Show poj = new poj_Show();

        public emp()
        {
            InitializeComponent();
        }

        private void emp_Load(object sender, EventArgs e)
        {
            cmd = Environment.GetCommandLineArgs();

            switch (cmd.Length)
            {
                case 1:
                    {
                        wl = Environment.UserName;
                        new mutex().twice("employer");
                        break;
                    }
                case 2:
                    {
                        wl = cmd[1];
                        new mutex().twice("employer");
                        break;
                    }
                case 3:
                    {
                        wl = cmd[1];
                        if (cmd[2] != "nolimit")
                            new mutex().twice("employer");
                        break;
                    }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            name_que = sn.sn_GetNameQ1(stdt, nick);
            if(File.Exists(name_que))
            {
                if (poj.poj_CountByWL(wl, nick) >= 1)
                {
                    DialogResult result = MessageBox.Show("Пожелания уже оставлены на " + month + ". Удаляем и оставляем новые?", "Как поступим?", MessageBoxButtons.YesNo, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1);
                    if (result == DialogResult.Yes)
                    {
                        poj.poj_DeleteByWL(wl, nick);
                        new InterviewForm(wfm_id, wl, rg_wl, name_que, new connection_strings().output + nick + ".db").ShowDialog(this);
                    }
                    if (result == DialogResult.No)
                        return;
                }
                else new InterviewForm(wfm_id, wl, rg_wl, name_que, new connection_strings().output + nick + ".db").ShowDialog(this);
            }
            else MessageBox.Show("Не удалось найти для вас список вопросов :(");

        }

        

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("mailto:" + rg_wl + "@tinkoff.ru");
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("mailto:" + rs_wl + "@tinkoff.ru");
        }

        private void GetInput()
        {
            try
            {
                input = new ImportCSV().ReadCSVFile(new connection_strings().in_csv);
                if (input != null)
                    LoadInfo();
            }
            catch
            {
                GetInput();
            }
        }

        private void LoadInfo()
        {
            about_me = new DT_Sort().AboutMe(input, wl);

            switch(about_me.Length)
            {
                case 1:
                    {
                        gp_id = Convert.ToInt32(about_me[0][7]);                        

                        switch(tr.tr_CountGPID(gp_id))
                        {
                            case 1:
                                {
                                    transfer = tr.tr_AboutByGPID(gp_id);
                                    role = transfer.Rows[0][0].ToString();

                                    if (role == "emp")
                                    {
                                        {
                                            wfm_id = Convert.ToInt32(about_me[0][0]);
                                            fio = about_me[0][1].ToString();
                                            wl = about_me[0][2].ToString();
                                            rg = about_me[0][3].ToString();
                                            rg_wl = about_me[0][4].ToString();
                                            rs = about_me[0][5].ToString();
                                            rs_wl = about_me[0][6].ToString();
                                            stdt = Convert.ToDateTime(about_me[0][8]);

                                            Text = new hello().hour_now(fio);

                                            otdel = transfer.Rows[0][1].ToString();
                                            nick = transfer.Rows[0][2].ToString();
                                            read = transfer.Rows[0][3].ToString();
                                        }

                                        {
                                            label1.Visible = true;
                                            label2.Visible = true;
                                            label3.Visible = true;
                                            label4.Visible = true;
                                            label5.Visible = true;
                                        }

                                        {
                                            linkLabel1.Visible = true;
                                            linkLabel1.Text = rg;

                                            linkLabel2.Visible = true;
                                            linkLabel2.Text = rs;

                                            label6.Visible = true;
                                            label6.Text = otdel;

                                            textBox1.Visible = true;
                                            textBox1.Text += read;
                                        }

                                        {
                                            set_poj = sn.sn_GetInfoSet(nick);

                                            month = set_poj.Rows[0][0].ToString();
                                            stop_d = set_poj.Rows[0][1].ToString();

                                            label7.Visible = true;
                                            label7.Text = month;
                                            label8.Visible = true;
                                            label8.Text = stop_d;

                                            if (Convert.ToDateTime(stop_d) > DateTime.Now)
                                            {
                                                button1.Visible = true;
                                            }
                                            else label8.ForeColor = System.Drawing.Color.Red;
                                        }
                                        toolStripButton2.Enabled = true;
                                        show_poj();
                                    }
                                    else if(role == "rg" || role == "rs")
                                    {
                                        DialogResult result = MessageBox.Show("Вы запустили гаджет, не предназначенный для вашей должности.\r\nСкачать соответствующий?", "Отказано в доступе", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                                        if (result == DialogResult.Yes)
                                        {
                                            System.Diagnostics.Process.Start(tr.tr_DownloadApp(2));
                                            Application.Exit();
                                        }
                                        if (result == DialogResult.No)
                                            Application.Exit();
                                    }
                                    else
                                    {
                                        DialogResult result = MessageBox.Show("Невозможно определить вашу должность.\r\nОтправить обратную связь?", "Проблемка :(", MessageBoxButtons.YesNo, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                                        if (result == DialogResult.Yes)
                                        {
                                            new feedback("Неизвестная роль в БД transfer.");
                                            Application.Exit();
                                        }
                                        if (result == DialogResult.No)
                                            Application.Exit();
                                    }

                                    break;
                                }
                            case 0:
                                {
                                    MessageBox.Show("Для ваших должности/отдела еще не запущен сбор пожеланий через гаджет :(");
                                    Application.Exit();
                                    break;
                                }
                            default:
                                {
                                    DialogResult result = MessageBox.Show("Невозможно определить ваш отдел.\r\nОтправить обратную связь?", "Проблемка :(", MessageBoxButtons.YesNo, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                                    if (result == DialogResult.Yes)
                                    {
                                        new feedback("Повторяются gp_id в БД transfer.");
                                        Application.Exit();
                                    }
                                    if (result == DialogResult.No)
                                        Application.Exit();
                                    break;
                                }
                        }

                        break;
                    }
                case 0:
                    {
                        MessageBox.Show("Вы не найдены в базе сотрудников, используемой этим гаджетом :(");
                        Application.Exit();
                        break;
                    }
                default:
                    {
                        DialogResult result = MessageBox.Show("Вас невозможно определить.\r\nОтправить обратную связь?", "Проблемка :(", MessageBoxButtons.YesNo, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                        if (result == DialogResult.Yes)
                        {
                            new feedback("В базе несколько строк по сотруднику.");
                            Application.Exit();
                        }
                        if (result == DialogResult.No)
                            Application.Exit();
                        break;
                    }
            }
        }

        private void show_poj()
        {
            if (poj.poj_CountByWL(wl, nick) > 0)
            {
                DataTable dr = poj.poj_ReadByWL(wl, nick);
                label10.Text = "";
                for (int i = 0; i < dr.Columns.Count; i++)
                {
                    if (!string.IsNullOrEmpty(dr.Rows[0][i].ToString()))
                        label10.Text += dr.Rows[0][i].ToString() + "\r\n";
                }
                flowLayoutPanel1.Visible = true;
            }
            else
            {
                textBox1.Text += "\r\n" + "Оставленные пожелания отсутствуют.";
                if(flowLayoutPanel1.Visible)
                    flowLayoutPanel1.Visible = false;
            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            if (tr.tr_UpdateApp("2.0", "emp"))
            {
                GetInput();
            }
            else
            {
                DialogResult result = MessageBox.Show("Вышло обновление, текущую версию использовать невозможно.\r\nСкачать сейчас?", "Обновление", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                if (result == DialogResult.Yes)
                {
                    System.Diagnostics.Process.Start(tr.tr_DownloadApp(1));
                    Application.Exit();
                }
                if (result == DialogResult.No)
                    Application.Exit();
            }
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            show_poj();
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            new feedback();
        }
    }
}
