using System.Text;
using System.IO;
using System.Windows.Forms;

namespace ConnCore
{
    public class Export2CSV
    {
        connection_strings cstr = new connection_strings();

        public void SaveToCSV(DataGridView DGV, int mode)
        {

            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "CSV (*.csv)|*.csv";
            sfd.InitialDirectory = cstr.root;
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                MessageBox.Show("Начинаю экспорт, сообщу по окончанию.");

                int columnCount = DGV.ColumnCount;
                string columnNames = "";
                string[] output = new string[DGV.RowCount + 1];
                for (int i = 0; i < columnCount; i++)
                {
                    columnNames += DGV.Columns[i].Name.ToString() + ";";
                }
                output[0] += columnNames;
                for (int i = 1; (i - 1) < DGV.RowCount; i++)
                {
                    for (int j = 0; j < columnCount; j++)
                    {
                        output[i] += DGV.Rows[i - 1].Cells[j].Value.ToString() + ";";
                    }
                }

                switch (mode)
                {
                    case 0:
                        {
                            File.WriteAllLines(sfd.FileName, output, Encoding.Default);
                            break;
                        }
                    case 1:
                        {
                            File.WriteAllLines(sfd.FileName, output);
                            break;
                        }
                    case 2:
                        {
                            File.WriteAllLines(sfd.FileName, output, Encoding.ASCII);
                            break;
                        }
                    case 3:
                        {
                            File.WriteAllLines(sfd.FileName, output, Encoding.Unicode);
                            break;
                        }
                    case 4:
                        {
                            File.WriteAllLines(sfd.FileName, output, Encoding.UTF32);
                            break;
                        }
                    case 5:
                        {
                            File.WriteAllLines(sfd.FileName, output, Encoding.UTF7);
                            break;
                        }
                    case 6:
                        {
                            File.WriteAllLines(sfd.FileName, output, Encoding.UTF8);
                            break;
                        }
                }

                MessageBox.Show("Готово!");
            }
        }
    }
}
