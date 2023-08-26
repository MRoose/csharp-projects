using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SQLite;
using System.IO;

namespace ConnCore
{
    public class tr_Control
    {
        connection_strings cstr;
        DataTable dt;

        public DataSet tr_ReadTables()
        {
            DataTable dt1 = new DataTable();
            DataTable dt2 = new DataTable();
            DataSet ds = new DataSet();
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

        public void tr_DropTableOtdel()
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
                    SQLiteCommand cmd = new SQLiteCommand(conn);
                    cmd.CommandText = "DELETE FROM table1";
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
            }
            else
            {

            }
        }

        public void tr_DropTableVersion()
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

        public void tr_DeleteOtdel(string gp_id)
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
                    SQLiteCommand cmd = new SQLiteCommand(conn);
                    cmd.CommandText = "DELETE FROM table1 WHERE gp_id = '" + gp_id + "'";
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
            }
            else
            {

            }
        }

        public void tr_DeleteVersion(string role)
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
                    SQLiteCommand cmd = new SQLiteCommand(conn);
                    cmd.CommandText = "DELETE FROM table2 WHERE role = '" + role + "'";
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
            }
            else
            {

            }
        }

        public void tr_AddOtdel(string gp_id, string role, string otdel, string nick, string read)
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
                    SQLiteCommand cmd = new SQLiteCommand(conn);
                    cmd.CommandText = "INSERT INTO table1 (gp_id, role, otdel, nick, read) VALUES ('" + gp_id + "', '" + role + "', '" + otdel + "', '" + nick + "', '" + read + "')";
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
            }
            else
            {

            }
        }

        public void tr_AddVersion(string role, string version, string downl)
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
                    SQLiteCommand cmd = new SQLiteCommand(conn);
                    cmd.CommandText = "INSERT INTO table2 (role, version, download) VALUES ('" + role + "', '" + version + "', '" + downl + "')";
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
            }
            else
            {

            }
        }

        public void tr_UpdateOtdel(string gp_id, string role, string otdel, string nick, string read)
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
                    SQLiteCommand cmd = new SQLiteCommand(conn);
                    cmd.CommandText = "UPDATE table1 SET role = '" + role + "', otdel = '" + otdel + "', nick = '" + nick + "', read = '" + read + "' WHERE gp_id = '" + gp_id + "'";
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
            }
            else
            {

            }
        }

        public void tr_UpdateVersion(string role, string version, string downl)
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
                    SQLiteCommand cmd = new SQLiteCommand(conn);
                    cmd.CommandText = "UPDATE table2 SET version = '" + version + "', download = '" + downl + "' WHERE role = '" + role + "'";
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
            }
            else
            {

            }
        }

        public DataTable tr_SeeByGPID(string gp_id)
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

        public DataTable tr_SeeByRole(string role)
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
                    SQLiteDataAdapter adapter = new SQLiteDataAdapter("SELECT version, download FROM table2 WHERE role = '" + role + "'", conn);
                    adapter.Fill(dt);
                    conn.Close();
                }
            }
            else
            {

            }

            return dt;
        }

        public DataTable tr_ListOfGPID()
        {
            DataTable dt = new DataTable();
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
                    SQLiteDataAdapter adapter = new SQLiteDataAdapter("SELECT gp_id FROM table1", conn);
                    adapter.Fill(dt);
                    conn.Close();
                }
            }
            else
            {

            }

            return dt;
        }

        public DataTable tr_ListOfRole()
        {
            DataTable dt = new DataTable();
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
                    SQLiteDataAdapter adapter = new SQLiteDataAdapter("SELECT role FROM table2", conn);
                    adapter.Fill(dt);
                    conn.Close();
                }
            }
            else
            {

            }

            return dt;
        }
    }
}
