using System;
using System.Windows.Forms;

namespace ConnCore
{
    public partial class form_feedback : Form
    {
        public form_feedback()
        {
            InitializeComponent();
        }

        private void feedback1_Load(object sender, EventArgs e)
        {
            MessageBox.Show("Коллеги, просьба не отправлять через эту форму пожелания к расписанию. Обратная связь поступает разработчику, который не работает в отделе УОП. С вопросами по расписанию обращайтесь напрямую к коллегам из УОП через инсайт, пожалуйста. Спасибо за понимание ;)");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            new sender().Send(textBox1.Text);
            Close();
        }
    }
}
