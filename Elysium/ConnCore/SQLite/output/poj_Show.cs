using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SQLite;
using System.IO;

namespace ConnCore
{
    public class poj_Show
    {
        connection_strings cstr;
        DataTable dt;

        public DataTable poj_ReadByWL(string wl, string nick)
        {
            if (File.Exists(cstr.output + nick + ".db"))
            {
                SQLiteConnection conn = new SQLiteConnection("Data Source=" + cstr.output + nick + ".db; Version=3;");
                try
                {
                    conn.Open();
                }
                catch (SQLiteException ex)
                {

                }
                if (conn.State == ConnectionState.Open)
                {
                    SQLiteDataAdapter adapter = new SQLiteDataAdapter("SELECT * FROM [table] WHERE wl = '" + wl + "'", conn);
                    adapter.Fill(dt);
                    conn.Close();
                }
                dt.Columns.Remove("wfm_id");
                dt.Columns.Remove("wl");
                dt.Columns.Remove("rg_wl");
                dt.Columns["s_wl"].ColumnName = "кем оставлено";
            }
            else
            {

            }
            return dt;
        }

        public DataTable poj_ReadGroup(string wl, string nick)
        {
            if (File.Exists(cstr.output + nick + ".db"))
            {
                SQLiteConnection conn = new SQLiteConnection("Data Source=" + cstr.output + nick + ".db; Version=3;");
                try
                {
                    conn.Open();
                }
                catch (SQLiteException ex)
                {

                }
                if (conn.State == ConnectionState.Open)
                {
                    SQLiteDataAdapter adapter = new SQLiteDataAdapter("SELECT * FROM [table] WHERE rg_wl = '" + wl + "'", conn);
                    adapter.Fill(dt);
                    conn.Close();
                }
                dt.Columns.Remove("wfm_id");
                dt.Columns.Remove("rg_wl");
                dt.Columns["wl"].ColumnName = "логины";
                dt.Columns["s_wl"].ColumnName = "кем оставлено";
            }
            else
            {

            }
            return dt;
        }

        public void poj_DeleteByWL(string wl, string nick)
        {
            if (File.Exists(cstr.output + nick + ".db"))
            {
                SQLiteConnection conn = new SQLiteConnection("Data Source=" + cstr.output + nick + ".db; Version=3;");
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
                    cmd.CommandText = "DELETE FROM [table] WHERE wl = '" + wl + "'";
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
            }
            else
            {

            }
        }

        public DataTable poj_GetWLByRG(string wl, string nick)
        {
            if (File.Exists(cstr.output + nick + ".db"))
            {
                SQLiteConnection conn = new SQLiteConnection("Data Source=" + cstr.output + nick + ".db; Version=3;");
                try
                {
                    conn.Open();
                }
                catch (SQLiteException ex)
                {

                }
                if (conn.State == ConnectionState.Open)
                {
                    SQLiteDataAdapter adapter = new SQLiteDataAdapter("SELECT wl FROM [table] WHERE rg_wl = '" + wl + "'", conn);
                    adapter.Fill(dt);
                    conn.Close();
                }
            }
            else
            {

            }
            return dt;
        }

        public int poj_CountByWL(string wl, string nick)
        {
            int count = 0;
            if (File.Exists(cstr.output + nick + ".db"))
            {
                SQLiteConnection conn = new SQLiteConnection("Data Source=" + cstr.output + nick + ".db; Version=3;");
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
                    cmd.CommandText = "SELECT COUNT(wl) FROM [table] WHERE wl = '" + wl + "'";
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
