using System.Diagnostics;
using System.Windows.Forms;
using Outlook = Microsoft.Office.Interop.Outlook;

namespace ConnCore
{
    public class sender
    {
        //string owner = "m.ruzvelt@tinkoff.ru";
        string owner = "miramix00@yandex.ru";
        string subject = "Обратная связь по Elysium";

        public void Send(string body)
        {
            try
            {
                Outlook._Application _app = new Outlook.Application();
                Outlook.MailItem mail = (Outlook.MailItem)_app.CreateItem(Outlook.OlItemType.olMailItem);

                mail.To = owner;
                mail.Subject = subject;
                mail.Body = body;

                mail.Importance = Outlook.OlImportance.olImportanceNormal;
                mail.SendUsingAccount = _app.Session.Accounts[1];
                mail.Send();

                MessageBox.Show("ОС отправлена.");
            }
            catch
            {
                Process.Start("mailto:" + owner + "?subject=" + subject + "&body=" + body);
            }
        }
    }
}
