using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SQLite;
using System.IO;

namespace ConnCore
{
    public class tr_Show
    {
        connection_strings cstr;
        DataTable dt;

        public bool tr_UpdateApp(string curr_ver, string role)
        {
            string version = "";
            if (File.Exists(cstr.transfer))
            {
                SQLiteConnection conn = new SQLiteConnection("Data Source=" + cstr.transfer + "; Version=3;");
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
                    cmd.CommandText = "SELECT version FROM table2 WHERE role = '" + role + "'";
                    version = cmd.ExecuteScalar().ToString();
                    conn.Close();
                }
            }
            else
            {

            }
            return curr_ver == version;
        }

        public DataTable tr_AboutByGPID(int gp_id)
        {
            if (File.Exists(cstr.transfer))
            {
                SQLiteConnection conn = new SQLiteConnection("Data Source=" + cstr.transfer + "; Version=3;");
                try
                {
                    conn.Open();
                }
                catch (SQLiteException ex)
                {

                }
                if (conn.State == ConnectionState.Open)
                {
                    SQLiteDataAdapter adapter = new SQLiteDataAdapter("SELECT role, otdel, nick, read FROM table1 WHERE gp_id = '" + gp_id + "'", conn);
                    adapter.Fill(dt);
                    conn.Close();
                }
            }
            else
            {

            }
            return dt;
        }

        public string tr_DownloadApp(int mode)
        {
            string url = "";
            if (File.Exists(cstr.transfer))
            {

                SQLiteConnection conn = new SQLiteConnection("Data Source=" + cstr.transfer + "; Version=3;");
                try
                {
                    conn.Open();
                }
                catch (SQLiteException ex)
                {

                }
                if (conn.State == ConnectionState.Open)
                {
                    string sql = "";
                    switch (mode)
                    {
                        case 1:
                            {
                                sql = "SELECT download FROM table2 WHERE role = emp";
                                break;
                            }
                        case 2:
                            {
                                sql = "SELECT download FROM table2 WHERE role = man";
                                break;
                            }
                    }
                    SQLiteCommand cmd = new SQLiteCommand(conn);
                    cmd.CommandText = sql;
                    url = cmd.ExecuteScalar().ToString();
                    conn.Close();
                }
            }
            else
            {

            }
            return url;
        }

        public int tr_CountGPID(int gp_id)
        {
            int count = 0;
            if (File.Exists(cstr.transfer))
            {
                SQLiteConnection conn = new SQLiteConnection("Data Source=" + cstr.transfer + "; Version=3;");
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
                    cmd.CommandText = "SELECT COUNT(gp_id) FROM table1 WHERE gp_id = '" + gp_id + "'";
                    count = Convert.ToInt32(cmd.ExecuteScalar());
                    conn.Close();
                }
            }
            else
            {

            }
            return count;
        }
    }
}
