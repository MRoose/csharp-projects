using System;

namespace ConnCore
{
    public class hello
    {
        public string hour_now(string fio_user)
        {
            int hour = DateTime.Now.Hour;

            if (hour >= 22 && hour <= 5)
                return "Доброй ночи, "+fio_user;
            else if (hour >= 6 && hour <= 11)
                return "Доброе утро, "+ fio_user;
            else if (hour >= 12 && hour <= 17)
                return "Добрый день, "+ fio_user;
            else return "Добрый вечер, "+ fio_user;
        }
    }
}
