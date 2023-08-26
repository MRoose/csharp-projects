using System;
using System.Threading;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace MACEMP
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            bool onlyInstance;

            Mutex mtx = new Mutex(true, "MACEMP", out onlyInstance); // используйте имя вашего приложения

            // Если другие процессы не владеют мьютексом, то
            // приложение запущено в единственном экземпляре
            if (onlyInstance)
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new Form1());
            }
            else
            {
                MessageBox.Show(
                   "Приложение уже запущено",
                   "Сообщение",
                   MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }
    }
}
