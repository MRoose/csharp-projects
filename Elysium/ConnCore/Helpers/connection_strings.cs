namespace ConnCore
{
    public class connection_strings
    {
        static string main_path = @"\\tcsbank.ru\userdata$\dko_schedule_wishes\examples\";
        //static string main_path = @"F:\Ely\";

        public string root = main_path;
        public string input = main_path + "input\\";
        public string output = main_path + "output\\";

        public string questions = main_path + "questions\\";
        public string settings = main_path + "settings\\";
        public string backups = main_path + "backups\\";
        public string source = main_path + "source\\";

        public string in_csv = main_path + "input\\input.csv";
        public string transfer = main_path + "settings\\transfer.db";
    }
}
