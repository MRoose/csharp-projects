using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SQLite;
using System.IO;

namespace ConnCore
{
    public class poj_Control
    {
        connection_strings cstr;
        DataTable dt;

        public DataTable poj_ReadTable(string path)
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
                SQLiteDataAdapter adapter = new SQLiteDataAdapter("SELECT * FROM [table]", conn);
                adapter.Fill(dt);
                conn.Close();
            }
            return dt;
        }

        public void poj_DropTable(string path)
        {
            if (File.Exists(cstr.transfer))
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
                    cmd.CommandText = "DELETE FROM table";
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
            }
            else
            {

            }
        }
    }
}
