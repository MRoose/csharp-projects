using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SQLite;
using System.IO;

namespace ConnCore
{
    public class sn_Show
    {
        connection_strings cstr;
        DataTable dt;

        public DataTable sn_GetInfoSet(string nick)
        {
            if (File.Exists(cstr.settings + "set_" + nick + ".db"))
            {
                SQLiteConnection conn = new SQLiteConnection("Data Source=" + cstr.settings + "set_" + nick + ".db; Version=3;");
                try
                {
                    conn.Open();
                }
                catch (SQLiteException ex)
                {

                }
                if (conn.State == ConnectionState.Open)
                {
                    SQLiteDataAdapter adapter = new SQLiteDataAdapter("SELECT month, stop_date FROM table1", conn);
                    adapter.Fill(dt);
                    conn.Close();
                }
            }
            else
            {

            }
            return dt;
        }

        public string sn_GetNameQ1(DateTime start_date, string nick)
        {
            string name_q = "";
            if (File.Exists(cstr.settings + "set_" + nick + ".db"))
            {
                SQLiteConnection conn = new SQLiteConnection("Data Source=" + cstr.settings + "set_" + nick + ".db; Version=3;");
                try
                {
                    conn.Open();
                }
                catch (SQLiteException ex)
                {

                }
                if (conn.State == ConnectionState.Open)
                {
                    SQLiteCommand cmd = new SQLiteCommand(conn);
                    cmd.CommandText = "SELECT calc_date FROM table1";
                    int staj = ((Convert.ToDateTime(cmd.ExecuteScalar()) - start_date).Days) / 30;

                    cmd.CommandText = "SELECT COUNT(count_m) FROM table2 WHERE count_m = '" + staj + "'";
                    int count = Convert.ToInt32(cmd.ExecuteScalar());
                    if (count == 1)
                    {
                        cmd.CommandText = "SELECT name_q FROM table2 WHERE count_m = '" + staj + "'";
                        string nameofq = cmd.ExecuteScalar().ToString();
                        if (string.IsNullOrEmpty(nameofq))
                        {
                            name_q = cstr.questions + nick + "\\" + nick + ".q";
                        }
                        else
                        {
                            name_q = cstr.questions + nick + "\\" + nameofq;
                        }

                    }
                    else name_q = cstr.questions + nick + "\\" + nick + ".q";

                    conn.Close();
                }
            }
            else
            {

            }
            return name_q;
        }

        public string sn_GetNameQ2(string nick)
        {
            string name_q = cstr.questions+nick+"\\rg_"+nick+".q";
            return name_q;
        }


    }
}
