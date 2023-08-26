using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SQLite;
using System.IO;

namespace ConnCore
{
    public class sn_Control
    {
        connection_strings cstr;

        public DataSet sn_ReadTables(string path)
        {
            DataTable dt1 = new DataTable();
            DataTable dt2 = new DataTable();
            DataSet ds = new DataSet();
            SQLiteConnection conn = new SQLiteConnection("Data Source=" + path + "; Version=3;");
            try
            {
                conn.Open();
            }
            catch (SQLiteException ex)
            {

            }
            if (conn.State == ConnectionState.Open)
            {
                SQLiteDataAdapter adapter1 = new SQLiteDataAdapter("SELECT * FROM table1", conn);
                adapter1.Fill(dt1);
                SQLiteDataAdapter adapter2 = new SQLiteDataAdapter("SELECT * FROM table2", conn);
                adapter2.Fill(dt2);
                conn.Close();
            }
            ds.Tables.Add(dt1);
            ds.Tables.Add(dt2);
            return ds;
        }

        public void sn_RefreshTime(string path, string month, string st_d, string calc_d)
        {
            if (File.Exists(path))
            {
                SQLiteConnection conn = new SQLiteConnection("Data Source=" + path + "; Version=3;");
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
                    cmd.CommandText = "DELETE FROM table1";
                    cmd.ExecuteNonQuery();
                    cmd.CommandText = "INSERT INTO table1 (month, stop_date, calc_date) VALUES ('" + month + "', '" + st_d + "', '" + calc_d + "')";
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
            }
            else
            {

            }
        }

        public void sn_DropTableCondition(string path)
        {
            if (File.Exists(path))
            {
                SQLiteConnection conn = new SQLiteConnection("Data Source=" + path + "; Version=3;");
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
                    cmd.CommandText = "DELETE FROM table2";
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
            }
            else
            {

            }
        }

        public void sn_AddCondition(string path, string count_m, string name_q)
        {
            if (File.Exists(path))
            {
                SQLiteConnection conn = new SQLiteConnection("Data Source=" + path + "; Version=3;");
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
                    cmd.CommandText = "INSERT INTO table2 (count_m, name_q) VALUES ('" + count_m + "', '" + name_q + "')";
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
            }
            else
            {

            }
        }

        public void sn_UpdateCondition(string path, string count_m, string name_q)
        {
            if (File.Exists(path))
            {
                SQLiteConnection conn = new SQLiteConnection("Data Source=" + path + "; Version=3;");
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
                    cmd.CommandText = "UPDATE table2 SET name_q = '" + name_q + "' WHERE count_m = '" + count_m + "'";
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
            }
            else
            {

            }
        }

        public void sn_DeleteCondition(string path, string count_m)
        {
            if (File.Exists(path))
            {
                SQLiteConnection conn = new SQLiteConnection("Data Source=" + path + "; Version=3;");
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
                    cmd.CommandText = "DELETE FROM table2 WHERE count_m = '" + count_m + "'";
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
            }
            else
            {

            }
        }

        public DataTable sn_ListOfMonth(string path)
        {
            DataTable dt = new DataTable();
            if (File.Exists(path))
            {
                SQLiteConnection conn = new SQLiteConnection("Data Source=" + path + "; Version=3;");
                try
                {
                    conn.Open();
                }
                catch (SQLiteException ex)
                {

                }
                if (conn.State == ConnectionState.Open)
                {
                    SQLiteDataAdapter adapter = new SQLiteDataAdapter("SELECT count_m FROM table2", conn);
                    adapter.Fill(dt);
                    conn.Close();
                }
            }
            else
            {

            }

            return dt;
        }

        public string sn_SeeByMonth(string path, string count_m)
        {
            string ss = "";
            if (File.Exists(path))
            {
                SQLiteConnection conn = new SQLiteConnection("Data Source=" + path + "; Version=3;");
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
                    cmd.CommandText = "SELECT name_q FROM table2 WHERE count_m = '" + count_m + "'";
                    ss = cmd.ExecuteScalar().ToString();
                    conn.Close();
                }
            }
            else
            {

            }

            return ss;
        }
    }
}
