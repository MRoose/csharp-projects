using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;
using System.Globalization;

namespace Time
{
    public partial class Form1 : Form
    {
        Stopwatch stopWatch = new Stopwatch();
        Stopwatch stopWatch1 = new Stopwatch();
        Stopwatch stopWatch2 = new Stopwatch();
        TimeSpan ts, ts1, ts2, ts_obed, ts_lichniy, ts_sluj;
        DateTime date1, date2, date3, date4, date5, date6, today, answer;
        string log_obed, log_lichniy, log_sluj;
        string elapsedTime, elapsedTime1, elapsedTime2, bb;
        private Stopwatch st_t = Stopwatch.StartNew();
        private Stopwatch st_t1 = Stopwatch.StartNew();
        private Stopwatch st_t2 = Stopwatch.StartNew();
        Timer timer = new Timer();
        Timer timer1 = new Timer();
        Timer timer2 = new Timer();

        /////////////////////////////////////////////////////////
        public void tickTimer(object sender, EventArgs e)
        {
            label7.Text = st_t.Elapsed.ToString("mm\\:ss");
        }
        public void tickTimer1(object sender, EventArgs e)
        {
            label8.Text = st_t1.Elapsed.ToString("mm\\:ss");
        }
        public void tickTimer2(object sender, EventArgs e)
        {
            label9.Text = st_t2.Elapsed.ToString("mm\\:ss");
        }
        /////////////////////////////////////////////////////////

        public Form1()
        {
            InitializeComponent();
            textBox1.ScrollBars = ScrollBars.Both;

            timer.Interval = 100;
            timer.Tick += new EventHandler(tickTimer);
            timer1.Interval = 100;
            timer1.Tick += new EventHandler(tickTimer1);
            timer2.Interval = 100;
            timer2.Tick += new EventHandler(tickTimer2);
        }


        private void button7_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Привет, дорогой пользователь!" + "\r\n" + "Советую создать для приложения отдельную папку. В ней будут храниться все текстовые данные. Их 2 вида :" + "\r\n" + "№1 Altair.txt - САМЫЙ ВАЖНЫЙ, в нем ведется статистика служебного режима - при открытиии приложения оттуда считывается информация, он удяляется, при закрытии приложения онсоздается, в него записывается новая статистика. Можно редактировать, но согласно алгоритму : ЧЧ:ММ:ММ (часы:минуты:секунды, н-р, 15:58:09. И НИКАК ИНАЧЕ! В последний день месяца его можно удалить или отредактировать 00:00:00 . К сожалению, на данный момент, если счетчик достигнет 25-го часа, отсчет пойдет с нуля. Позже исправлю)" + "\r\n" + "№2 ..._Altair_log.txt - после каждого закрытия создается такой файл с отчетом о всех режимах за время работы приложения и поэтому советую один раз открывать и один раз закрывать приложение в рабочий день (для Вашего удобства). В противном случае будут столько файлов, сколько открыли. Разобрать название можно таким образом - день:месяц:год:часы:минуты:секунды (время закрытия)." + "\r\n\r\n" + "Для обратной связи - лампочка ;)");
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Process.Start("mailto:developer@mail.ru");
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            {
                string date_closed = DateTime.Now.ToString("dd.MM.yyyy.HH.mm.ss") + "_Altair_log.txt";
                string path = Directory.GetCurrentDirectory();
                StreamWriter sw2 = new StreamWriter(Path.Combine(path, date_closed));
                sw2.WriteLine("Обед      : " + elapsedTime + "\r\n" + "Личный    : " + elapsedTime1 + "\r\n" + "Служебный : " + elapsedTime2);
                sw2.Close();
            }

            {
                today = DateTime.Parse(bb);
                answer = today.Add(ts2);
                StreamWriter DS = new StreamWriter("Altair.txt");
                DS.WriteLine(answer.ToString("HH:mm:ss"));
                DS.Close();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            button1.Enabled = false;
            button1.BackColor = Color.Red;
            button2.Enabled = true;
            button2.BackColor = Color.Lime;
            ////////////////////////////////////////////
            stopWatch.Start();
            ///////////////////////////////////////////
            date1 = DateTime.Now;
            st_t.Restart();
            timer.Start();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            button2.Enabled = false;
            button2.BackColor = Color.Red;
            button1.Enabled = true;
            button1.BackColor = Color.Lime;
            //////////////////////////////////////////////
            stopWatch.Stop();
            ts = stopWatch.Elapsed;
            elapsedTime = String.Format("{0:00}:{1:00}:{2:00}",
            ts.Hours, ts.Minutes, ts.Seconds);
            label3.Text = elapsedTime;
            /////////////////////////////////////////////////
            date2 = DateTime.Now;
            ts_obed = date2 - date1;
            log_obed = String.Format("{0:00}:{1:00}:{2:00}",
            ts_obed.Hours, ts_obed.Minutes, ts_obed.Seconds);
            if (textBox1.Text.Length != 0)
                textBox1.Text += "\r\n" + "Обед : " + log_obed;
            if (textBox1.Text.Length == 0)
                textBox1.Text += "Обед : " + log_obed;

            timer.Stop();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            button3.Enabled = false;
            button3.BackColor = Color.Red;
            button4.Enabled = true;
            button4.BackColor = Color.Orange;
            /////////////////////////////////////////////////
            stopWatch1.Start();
            /////////////////////////////////////////////////
            date3 = DateTime.Now;
            st_t1.Restart();
            timer1.Start();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            button4.Enabled = false;
            button4.BackColor = Color.Red;
            button3.Enabled = true;
            button3.BackColor = Color.Orange;
            //////////////////////////////////////////////////
            stopWatch1.Stop();
            ts1 = stopWatch1.Elapsed;
            elapsedTime1 = String.Format("{0:00}:{1:00}:{2:00}",
            ts1.Hours, ts1.Minutes, ts1.Seconds);
            label4.Text = elapsedTime1;
            ////////////////////////////////////////////
            date4 = DateTime.Now;
            ts_lichniy = date4 - date3;
            log_lichniy = String.Format("{0:00}:{1:00}:{2:00}",
            ts_lichniy.Hours, ts_lichniy.Minutes, ts_lichniy.Seconds);
            if (textBox1.Text.Length != 0)
                textBox1.Text += "\r\n" + "Личный : " + log_lichniy;
            if (textBox1.Text.Length == 0)
                textBox1.Text += "Личный : " + log_lichniy;

            timer1.Stop();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            button5.Enabled = false;
            button5.BackColor = Color.Red;
            button6.Enabled = true;
            button6.BackColor = Color.DarkGray;

            stopWatch2.Start();
            //////////////////////////////////
            date5 = DateTime.Now;
            st_t2.Restart();
            timer2.Start();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            button6.Enabled = false;
            button6.BackColor = Color.Red;
            button5.Enabled = true;
            button5.BackColor = Color.DarkGray;
            //////////////////////////////////////////////////////
            stopWatch2.Stop();
            ts2 = stopWatch2.Elapsed;
            elapsedTime2 = String.Format("{0:00}:{1:00}:{2:00}",
            ts2.Hours, ts2.Minutes, ts2.Seconds);
            label5.Text = elapsedTime2;
            ////////////////////////////////////////////////////
            date6 = DateTime.Now;
            ts_sluj = date6 - date5;
            log_sluj = String.Format("{0:00}:{1:00}:{2:00}",
            ts_sluj.Hours, ts_sluj.Minutes, ts_sluj.Seconds);
            if (textBox1.Text.Length != 0)
                textBox1.Text += "\r\n" + "Служебный : " + log_sluj;
            if (textBox1.Text.Length == 0)
                textBox1.Text += "Служебный : " + log_sluj;

            timer2.Stop();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if (File.Exists("Altair.txt") == true)
            {
                StreamReader sw1 = new StreamReader("Altair.txt");
                bb = sw1.ReadLine();
                label6.Text = bb;
                sw1.Close();
                File.Delete("Altair.txt");
            }
            else
            {
                MessageBox.Show("Приветствую! Создан файл Altair.txt в папке с приложением." + "\r\n" + "Пожалуйста, нажмите на значок вопроса перед использованием.");
                StreamWriter swQ = new StreamWriter("Altair.txt");
                swQ.WriteLine("00:00:00");
                swQ.Close();
                StreamReader sw1 = new StreamReader("Altair.txt");
                bb = sw1.ReadLine();
                label6.Text = bb;
                sw1.Close();
                File.Delete("Altair.txt");
            }
        }

    }
}
