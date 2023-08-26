using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Security.Cryptography;
using System.Reflection;

namespace Launcher
{
    public partial class Launcher : Form
    {
        public Launcher()
        {
            InitializeComponent();
        }

        string setEmp = @"F:\Ely\settings\employee.txt";
        //string setEmp = @"\\tcsbank.ru\userdata$\dko_schedule_wishes\settings\employee.txt";
        string setMan = @"\\tcsbank.ru\userdata$\dko_schedule_wishes\settings\manager.txt";
        string DocDir = Environment.GetFolderPath(Environment.SpecialFolder.Personal) + "\\Elysium\\";
        string DiskDir = @"F:\Ely\resources\";
        //string DiskDir = @"\\tcsbank.ru\userdata$\dko_schedule_wishes\resources\";

        private void btEmployee_Click(object sender, EventArgs e)
        {
            try
            {
                main(File.ReadAllLines(setEmp));
            }
            catch (Exception)
            {
                MessageBox.Show("Не получилось, еще раз попробуйте.");
                groupBox1.Visible = true;
                pictureBox1.Visible = false;
                label1.Text = "Жду выбор";
            }
        }

        private void btManager_Click(object sender, EventArgs e)
        {
            try
            {
                main(File.ReadAllLines(setMan));
            }
            catch
            {
                MessageBox.Show("Не получилось, еще раз попробуйте.");
                groupBox1.Visible = true;
                pictureBox1.Visible = false;
                label1.Text = "Жду выбор";
            }            
        }

        public void main(string[] ActualFiles)
        {
            groupBox1.Visible = false;
            pictureBox1.Visible = true;

            if (!Directory.Exists(DocDir))
            {
                label1.Text = "Создаю папку в документах";
                Directory.CreateDirectory(DocDir);
            }

            progressBar1.Maximum = ActualFiles.Length;
            for (int i=0; i<ActualFiles.Length;i++)
            {
                label1.Text = "Проверяю файлы : " + (i+1) + "/" + ActualFiles.Length;
                progressBar1.Value = i+1;
                if(!File.Exists(DocDir + ActualFiles[i]))
                {
                    File.Copy(DiskDir + ActualFiles[i], DocDir + ActualFiles[i]);
                }
                else
                {
                    if(getMD5(DiskDir + ActualFiles[i]) != getMD5(DocDir + ActualFiles[i]))
                    {
                        File.Copy(DiskDir + ActualFiles[i], DocDir + ActualFiles[i], true);
                    }
                }
            }
            label1.Text = "Проверка прошла успешно!";
            progressBar1.Value = 0;
            label1.Text = "Запускаю...";

            Assembly assembly = Assembly.LoadFile(DocDir + ActualFiles[0]);
            Type type = assembly.GetType("Elysium.LetsGo");
            Form form = (Form)Activator.CreateInstance(type);
            form.ShowDialog();



            label1.Text = "В работе...";
        }

        private string getMD5(string path)
        {
            using (FileStream fs = File.OpenRead(path))
            {
                MD5 md5 = new MD5CryptoServiceProvider();
                byte[] fileData = new byte[fs.Length];
                fs.Read(fileData, 0, (int)fs.Length);
                byte[] checkSum = md5.ComputeHash(fileData);
                string result = BitConverter.ToString(checkSum).Replace(" - ", string.Empty);
                return result;
            }
        }
    }
}
