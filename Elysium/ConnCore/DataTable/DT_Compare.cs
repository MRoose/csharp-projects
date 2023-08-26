using System.Data;

namespace ConnCore
{
    public class DT_Compare
    {

        public DataTable AnalizTable(DataTable First, DataTable Second)
        {//сравнение 2-х таблиц
            DataTable table = new DataTable();

            using (DataSet ds = new DataSet())
            {
                //Добавление таблиц в DS
                ds.Tables.AddRange(new DataTable[] { First.Copy(), Second.Copy() });

                //Получение столбцов для DataRelation (1-я таблица)
                DataColumn[] firstcolumns = new DataColumn[ds.Tables[0].Columns.Count];
                for (int i = 0; i < firstcolumns.Length; i++)
                {
                    firstcolumns[i] = ds.Tables[0].Columns[i];
                }

                //Получение столбцов для DataRelation (2-я таблица)
                DataColumn[] secondcolumns = new DataColumn[ds.Tables[1].Columns.Count];
                for (int i = 0; i < secondcolumns.Length; i++)
                {
                    secondcolumns[i] = ds.Tables[1].Columns[i];
                }

                //Создание DataRelation (отношений)
                DataRelation r1 = new DataRelation(string.Empty, firstcolumns, secondcolumns, false);
                ds.Relations.Add(r1);
                DataRelation r2 = new DataRelation(string.Empty, secondcolumns, firstcolumns, false);
                ds.Relations.Add(r2);

                //Создание столбцов результирующей таблицы
                table = First.Clone();

                table.BeginLoadData();
                //Если строки из 1-й нет во 2-й, то добавляем в результирующую таблицу
                foreach (DataRow parentrow in ds.Tables[0].Rows)
                {
                    DataRow[] childrows = parentrow.GetChildRows(r1);
                    if (childrows == null || childrows.Length == 0)
                        table.LoadDataRow(parentrow.ItemArray, true);
                }
                //Если строки из 2-й нет в 1-й, то добавляем в результирующую таблицу
                /*foreach (DataRow parentrow in ds.Tables[1].Rows)
                {
                    DataRow[] childrows = parentrow.GetChildRows(r2);
                    if (childrows == null || childrows.Length == 0)
                        table.LoadDataRow(parentrow.ItemArray, true);
                }*/

                table.EndLoadData();
            }
            return table;
        }
    }
}
