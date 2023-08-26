using System.Threading;
using System.Windows.Forms;

namespace ConnCore
{
    public class mutex
    {
        public void twice(string app_name)
        {
            bool onlyInstance;
            Mutex mtx = new Mutex(true, app_name, out onlyInstance);

            if (!onlyInstance)
            {
                DialogResult result = MessageBox.Show("Одновременная работа двух моих экземпляров на одном ПК запрещена!", "Отказано в доступе!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                if (result == DialogResult.OK)
                    Application.Exit();
            }
            else return;
        }
    }
}
