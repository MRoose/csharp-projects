using System.Text;
using System.Data;
using System.IO;

namespace ConnCore
{
    public class ImportCSV
    {

        public DataTable ReadCSVFile(string path2CSV)
        {
            DataTable dt = new DataTable();

            if (File.Exists(path2CSV))
            {
                using (StreamReader sr = new StreamReader(path2CSV, Encoding.Default))
                {
                    string[] headers = sr.ReadLine().Split(';');
                    foreach (string header in headers)
                    {
                        dt.Columns.Add(header);
                    }
                    while (!sr.EndOfStream)
                    {
                        string[] rows = sr.ReadLine().Split(';');
                        DataRow dr = dt.NewRow();
                        for (int i = 0; i < headers.Length; i++)
                        {
                            dr[i] = rows[i];
                        }
                        dt.Rows.Add(dr);
                    }
                }
            }
            else
            {

            }

            return dt;
        }
    }
}
