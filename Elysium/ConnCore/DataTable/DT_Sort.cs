using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace ConnCore
{
    public class DT_Sort
    {

        DataTable dt;
        DataRow[] dr;

        public DataRow[] AboutMe(DataTable input, string wl)
        {
            dr = input.Select("wl='" + wl + "'");
            return dr;
        }

        public DataTable GetWLByRG(DataTable input, string wl)
        {
            var rows = input.Select("[rg_wl] = '" + wl + "'");

            dt.Columns.Add(new DataColumn(input.Columns[2].ColumnName));

            foreach (var row in rows)
            {
                dt.Rows.Add(row[input.Columns[2].ColumnName]);
            }

            return dt;
        }

        public DataTable GetFIOByRG(DataTable input, string wl)
        {
            var rows = input.Select("[rg_wl] = '" + wl + "'");

            dt.Columns.Add(new DataColumn(input.Columns[1].ColumnName));

            foreach (var row in rows)
            {
                dt.Rows.Add(row[input.Columns[1].ColumnName]);
            }
            dt.Columns["fio"].ColumnName = "ФИО";
            return dt;
        }
    }
}
