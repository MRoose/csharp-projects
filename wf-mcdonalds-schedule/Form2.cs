using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Cryptography;

namespace MACEMP
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        public static string MD5Hash(string input)
        {
            StringBuilder hash = new StringBuilder();
            MD5CryptoServiceProvider md5provider = new MD5CryptoServiceProvider();
            byte[] bytes = md5provider.ComputeHash(new UTF8Encoding().GetBytes(input));

            for (int i = 0; i < bytes.Length; i++)
            {
                hash.Append(bytes[i].ToString("x2"));
            }
            return hash.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void button2_Click(object sender, EventArgs e)
        {
            string str1 = DateTime.Now.ToString("HH:mm");
            string str2 = DateTime.Now.ToString("dd");
            if (MD5Hash(textBox1.Text) == "ad1943a9fd6d3d7ee1e6af41a5b0d3e7" && MD5Hash(textBox2.Text) == "32b82a15a0c14ead539d66dc1304e695" && textBox3.Text == str2 && textBox4.Text == str1)
            {
                Form3 adminconsole = new Form3();
                adminconsole.ShowDialog();
                this.Close();
            }
            else MessageBox.Show("Идентификация не пройдена!");
        }
    }
}
