using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using ConnCore;
using System.Threading;

namespace Ely_man
{
    public partial class manager : Form
    {

        string fio, wl, role, otdel, nick, read, month, stop_d;
        int gp_id;
        string[] cmd;

        DataRow[] about_me;
        DataTable transfer, input, set_poj;

        tr_Show tr = new tr_Show();
        sn_Show sn = new sn_Show();
        poj_Show poj = new poj_Show();

        public manager()
        {
            InitializeComponent();

            tabControl1.DrawItem += new DrawItemEventHandler(tabControl1_DrawItem);
        }

        private void manager_Load(object sender, EventArgs e)
        {
            cmd = Environment.GetCommandLineArgs();

            switch (cmd.Length)
            {
                case 1:
                    {
                        wl = Environment.UserName;
                        new mutex().twice("manager");
                        break;
                    }
                case 2:
                    {
                        wl = cmd[1];
                        new mutex().twice("manager");
                        break;
                    }
                case 3:
                    {
                        wl = cmd[1];
                        if(cmd[2] != "nolimit")
                            new mutex().twice("manager");
                        break;
                    }
            }
        }

        private void tabControl1_DrawItem(object sender, DrawItemEventArgs e)
        {
            Graphics g = e.Graphics;
            Brush _textBrush;

            // Get the item from the collection.
            TabPage _tabPage = tabControl1.TabPages[e.Index];

            // Get the real bounds for the tab rectangle.
            Rectangle _tabBounds = tabControl1.GetTabRect(e.Index);

            if (e.State == DrawItemState.Selected)
            {
                // Draw a different background color, and don't paint a focus rectangle.
                _textBrush = new SolidBrush(Color.Red);
                g.FillRectangle(Brushes.Yellow, e.Bounds);
            }
            else
            {
                _textBrush = new SolidBrush(e.ForeColor);
                e.DrawBackground();
            }

            // Use our own font.
            Font _tabFont = new Font("Arial", (float)12.0, FontStyle.Bold, GraphicsUnit.Pixel);

            // Draw string. Center the text.
            StringFormat _stringFlags = new StringFormat();
            _stringFlags.Alignment = StringAlignment.Center;
            _stringFlags.LineAlignment = StringAlignment.Center;
            g.DrawString(_tabPage.Text, _tabFont, _textBrush, _tabBounds, new StringFormat(_stringFlags));
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            if (tr.tr_UpdateApp("2.0", "man"))
            {
                GetInput();
            }
            else
            {
                DialogResult result = MessageBox.Show("Вышло обновление, текущую версию использовать невозможно.\r\nСкачать сейчас?", "Обновление", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                if (result == DialogResult.Yes)
                {
                    System.Diagnostics.Process.Start(tr.tr_DownloadApp(2));
                    Application.Exit();
                }
                if (result == DialogResult.No)
                    Application.Exit();
            }
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            new feedback();
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

            switch (about_me.Length)
            {
                case 1:
                    {
                        gp_id = Convert.ToInt32(about_me[0][7]);

                        switch (tr.tr_CountGPID(gp_id))
                        {
                            case 1:
                                {
                                    transfer = tr.tr_AboutByGPID(gp_id);
                                    role = transfer.Rows[0][0].ToString();

                                    switch(role)
                                    {
                                        case "rg":
                                            {
                                                go();
                                                break;
                                            }
                                        case "rs":
                                            {
                                                go();
                                                break;
                                            }
                                        case "emp":
                                            {
                                                DialogResult result = MessageBox.Show("Вы запустили гаджет, не предназначенный для вашей должности.\r\nСкачать соответствующий?", "Отказано в доступе", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                                                if (result == DialogResult.Yes)
                                                {
                                                    System.Diagnostics.Process.Start(tr.tr_DownloadApp(1));
                                                    Application.Exit();
                                                }
                                                if (result == DialogResult.No)
                                                    Application.Exit();
                                                break;
                                            }
                                        default:
                                            {
                                                DialogResult result = MessageBox.Show("Невозможно определить вашу должность.\r\nОтправить обратную связь?", "Проблемка :(", MessageBoxButtons.YesNo, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                                                if (result == DialogResult.Yes)
                                                {
                                                    new feedback("Неизвестная роль в transfer.");
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
                                    MessageBox.Show("Для ваших должности/отдела еще не запущен сбор пожеланий через гаджет :(");
                                    Application.Exit();
                                    break;
                                }
                            default:
                                {
                                    DialogResult result = MessageBox.Show("Невозможно определить ваш отдел.\r\nОтправить обратную связь?", "Проблемка :(", MessageBoxButtons.YesNo, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                                    if (result == DialogResult.Yes)
                                    {
                                        new feedback("Повторяются gp_id в transfer.");
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

        void go()
        {
            fio = about_me[0][1].ToString();
            Text = new hello().hour_now(fio);

            otdel = transfer.Rows[0][1].ToString();
            nick = transfer.Rows[0][2].ToString();
            read = transfer.Rows[0][3].ToString();
            set_poj = sn.sn_GetInfoSet(nick);
            month = set_poj.Rows[0][0].ToString();
            stop_d = set_poj.Rows[0][1].ToString();

            TabPage sv = new TabPage("Сводка");
            sv.Controls.Add(new svodka(otdel, month, stop_d, read));
            tabControl1.TabPages.Add(sv);

            int mode = 0;
            if (Convert.ToDateTime(stop_d) < DateTime.Now)
                mode = 1;

            switch (role)
            {           
                case "rg":
                    {
                        TabPage tp = new TabPage("Ваша группа");
                        tp.Controls.Add(new Info(input, wl, nick, mode));
                        tabControl1.TabPages.Add(tp);

                        break;
                    }
                case "rs":
                    {
                        DataTable rg_list = new DT_Sort().GetWLByRG(input, wl);
                        for (int i=0;i<rg_list.Rows.Count;i++)
                        {
                            string wl_temp = rg_list.Rows[i]["wl"].ToString();
                            TabPage tp = new TabPage(wl_temp);
                            tp.Controls.Add(new Info(input, wl_temp, nick, mode));
                            tabControl1.TabPages.Add(tp);
                        }

                        break;
                    }
            }
            TabPage cus = new TabPage("Другая группа");
            cus.Controls.Add(new Info(input, nick, mode));
            tabControl1.TabPages.Add(cus);
        }
        
    }
}
