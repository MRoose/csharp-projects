using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using QuestCore;
using ConnCore;

namespace Ely_adm
{
    public partial class admin_panel : Form
    {
        private Questionnaire questionnaire = new Questionnaire();
        private bool changed;

        connection_strings cstr = new connection_strings();
        Export2CSV other = new Export2CSV();
        sn_Control sn = new sn_Control();
        poj_Control poj = new poj_Control();
        tr_Control tr = new tr_Control();

        string path_set;
        

        public admin_panel()
        {
            InitializeComponent();
            tabControl1.DrawItem += new DrawItemEventHandler(tabControl1_DrawItem);
        }

        private void admin_panel_FormClosing(object sender, FormClosingEventArgs e)
        {
            AskAboutSaveCurrentQuestionnaire();
        }

        private void tabControl1_DrawItem(object sender, DrawItemEventArgs e)
        {
            Graphics g = e.Graphics;
            Brush _textBrush;

            // Get the item from the collection.
            TabPage _tabPage = tabControl1.TabPages[e.Index];

            // Get the real bounds for the tab rectangle.
            Rectangle _tabBounds = tabControl1.GetTabRect(e.Index);

            if (e.State == DrawItemState.Selected)
            {
                // Draw a different background color, and don't paint a focus rectangle.
                _textBrush = new SolidBrush(Color.Red);
                g.FillRectangle(Brushes.Yellow, e.Bounds);
            }
            else
            {
                _textBrush = new SolidBrush(e.ForeColor);
                e.DrawBackground();
            }

            // Use our own font.
            Font _tabFont = new Font("Arial", (float)12.0, FontStyle.Bold, GraphicsUnit.Pixel);

            // Draw string. Center the text.
            StringFormat _stringFlags = new StringFormat();
            _stringFlags.Alignment = StringAlignment.Center;
            _stringFlags.LineAlignment = StringAlignment.Center;
            g.DrawString(_tabPage.Text, _tabFont, _textBrush, _tabBounds, new StringFormat(_stringFlags));
        }

        private void Build()
        {
            var helper = new ControlHelper(pnMain);

            pnMain.Controls.Clear();

            foreach (var quest in questionnaire)
            {
                var pn = new QuestPanel();
                pn.Build(questionnaire, quest);
                pn.QuestionnaireListChanged += () =>
                {
                    changed = true;
                    Build();
                };
                pn.Changed += () =>
                {
                    changed = true;
                    UpdateInterface();
                };

                pnMain.Controls.Add(pn);
            }
            UpdateInterface();
            helper.ResumeDrawing();
        }

        private void UpdateInterface()
        {
            btSave.Enabled = changed;
            pnMain.Invalidate(false);
        }

        private void LoadQuestionnaireFromFile(string filePath)
        {
            questionnaire = SaverLoader.Load<Questionnaire>(filePath);
            changed = false;
            Build();
        }

        private void SaveQuestionnaireToFile(string filePath)
        {
            new QuestionnaireValidator().Validate(questionnaire);
            changed = false;
            SaverLoader.Save(questionnaire, filePath);
            UpdateInterface();
        }

        private void RunQuestionnaire()
        {
            new QuestionnaireValidator().Validate(questionnaire);
            new InterviewForm(questionnaire).ShowDialog(this);
        }

        private void AskAboutSaveCurrentQuestionnaire()
        {
            if (changed)
            {
                if (MessageBox.Show("В текущем опроснике есть несохраненные данные.\r\nВы хотите сохранить опросник?", "Несохраненные изменения", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    btSave.PerformClick();
                }
            }
        }

        private void btSave_Click(object sender, EventArgs e)
        {
            var sfd = new SaveFileDialog() { Filter = "Опросник|*.q" };
            sfd.InitialDirectory = cstr.questions;
            if (sfd.ShowDialog() == DialogResult.OK)
                SaveQuestionnaireToFile(sfd.FileName);
        }

        private void btOpen_Click(object sender, EventArgs e)
        {
            AskAboutSaveCurrentQuestionnaire();
            var ofd = new OpenFileDialog() { Filter = "Опросник|*.q" };
            ofd.InitialDirectory = cstr.questions;
            if (ofd.ShowDialog() == DialogResult.OK)
                LoadQuestionnaireFromFile(ofd.FileName);
        }

        private void btAdd_Click(object sender, EventArgs e)
        {
            new QuestionnaireManipulator().AddNewQuest(questionnaire);
            changed = true;
            Build();
        }

        private void btPlay_Click(object sender, EventArgs e)
        {
            RunQuestionnaire();
        }




        private void btOpenDB_Click(object sender, EventArgs e)
        {
            var ofd = new OpenFileDialog() { Filter = "База SQLite|*.db" };
            ofd.InitialDirectory = cstr.output;
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    dGVDB.DataSource = poj.poj_ReadTable(ofd.FileName);
                }
                catch
                {
                    MessageBox.Show("Не удалось загрузить базу(");
                }
            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            DataSet ds = new DataSet();
            ds = tr.tr_ReadTables();
            dataGridView1.DataSource = ds.Tables[0];
            dataGridView2.DataSource = ds.Tables[1];
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            new rout_set(1).ShowDialog();
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            new rout_set(2).ShowDialog();
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            new rout_set(3).ShowDialog();
        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Вы уверены, что хотите очистить всю первую таблицу с отделами?", "Удалить 1ю таблицу", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                tr.tr_DropTableOtdel();
            }
        }

        private void toolStripButton6_Click(object sender, EventArgs e)
        {
            new rout_set2(1).ShowDialog();
        }

        private void toolStripButton7_Click(object sender, EventArgs e)
        {
            new rout_set2(2).ShowDialog();
        }

        private void toolStripButton8_Click(object sender, EventArgs e)
        {
            new rout_set2(3).ShowDialog();
        }

        private void toolStripButton9_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Вы уверены, что хотите очистить всю вторую таблицу про версии гаджетов?", "Удалить 2ю таблицу", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                tr.tr_DropTableVersion();
            }
        }

        private void toolStripButton11_Click(object sender, EventArgs e)
        {
            var ofd = new OpenFileDialog() { Filter = "База set_nick.db|*.db" };
            ofd.InitialDirectory = cstr.settings;
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                path_set = ofd.FileName;
                reload_set();
            }
        }

        void reload_set()
        {
            try
            {
                if (path_set.Length > 10)
                {
                    DataSet ds = new DataSet();
                    label11.Text = path_set;

                    ds = sn.sn_ReadTables(path_set);
                    label6.Text = ds.Tables[0].Rows[0][0].ToString();
                    label7.Text = ds.Tables[0].Rows[0][1].ToString();
                    label8.Text = ds.Tables[0].Rows[0][2].ToString();


                    dataGridView3.DataSource = ds.Tables[1];
                }
                else MessageBox.Show("Не выбрана БД с параметрами!");
            }
            catch
            {
                MessageBox.Show("Не удалось загрузить базу( Попробуйте внести данные и обновить ее.");
            }
        }

        private void toolStripButton10_Click(object sender, EventArgs e)
        {
            if (path_set.Length > 10)
                new month(path_set).ShowDialog();
            else MessageBox.Show("Не выбрана БД с параметрами!");
        }

        private void toolStripButton12_Click(object sender, EventArgs e)
        {
            reload_set();
        }

        private void toolStripButton16_Click(object sender, EventArgs e)
        {
            if (path_set.Length > 10)
            {
                if (MessageBox.Show("Вы уверены, что хотите очистить всю таблицу с параметрами для опросников?", "Удаление настроек", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    sn.sn_DropTableCondition(path_set);
                }
            }
            else MessageBox.Show("Не выбрана БД с параметрами!");
        }

        private void toolStripButton13_Click(object sender, EventArgs e)
        {
            new set_n(1, path_set).ShowDialog();
        }

        private void toolStripButton14_Click(object sender, EventArgs e)
        {
            new set_n(2, path_set).ShowDialog();
        }

        private void toolStripButton15_Click(object sender, EventArgs e)
        {
            new set_n(3, path_set).ShowDialog();
        }

        private void defaultToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dGVDB.ColumnCount != 0)
            {
                other.SaveToCSV(dGVDB, 0);
            }
            else MessageBox.Show("Нечего экспортировать, загрузите базу сперва!");
        }

        private void withoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dGVDB.ColumnCount != 0)
            {
                other.SaveToCSV(dGVDB, 1);
            }
            else MessageBox.Show("Нечего экспортировать, загрузите базу сперва!");
        }

        private void aNSCIIToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dGVDB.ColumnCount != 0)
            {
                other.SaveToCSV(dGVDB, 2);
            }
            else MessageBox.Show("Нечего экспортировать, загрузите базу сперва!");
        }

        private void unicodeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dGVDB.ColumnCount != 0)
            {
                other.SaveToCSV(dGVDB, 3);
            }
            else MessageBox.Show("Нечего экспортировать, загрузите базу сперва!");
        }

        private void uTF32ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dGVDB.ColumnCount != 0)
            {
                other.SaveToCSV(dGVDB, 4);
            }
            else MessageBox.Show("Нечего экспортировать, загрузите базу сперва!");
        }

        private void uTF8ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dGVDB.ColumnCount != 0)
            {
                other.SaveToCSV(dGVDB, 5);
            }
            else MessageBox.Show("Нечего экспортировать, загрузите базу сперва!");
        }

        private void uTF7ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dGVDB.ColumnCount != 0)
            {
                other.SaveToCSV(dGVDB, 6);
            }
            else MessageBox.Show("Нечего экспортировать, загрузите базу сперва!");
        }

        private void toolStripButton17_Click(object sender, EventArgs e)
        {
            DirectoryInfo dir = new DirectoryInfo(cstr.output);
            FileInfo[] files = dir.GetFiles("*.db");
            foreach (FileInfo fi in files)
            {
                checkedListBox1.Items.Add(fi.ToString());
            }
        }

        private void бэкапБезОчисткиToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void бэкапСОчисткойToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void toolStripDropDownButton1_Click(object sender, EventArgs e)
        {
            var ofd = new OpenFileDialog() { Filter = "Гаджеты|*.exe" };
            ofd.InitialDirectory = cstr.root;
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                System.Diagnostics.Process pr = new System.Diagnostics.Process();
                pr.StartInfo.FileName = ofd.FileName;
                pr.StartInfo.Arguments = toolStripTextBox1.Text + " nolimit";
                pr.Start();
            }
        }

        private void admin_panel_Load(object sender, EventArgs e)
        {
            string[] cmd = Environment.GetCommandLineArgs();
            switch(cmd.Length)
            {
                case 2:
                    {
                        if (cmd[1] == "noauth")
                            return;
                        else new auth().ShowDialog(this);
                        break;
                    }
                default:
                    {
                        new auth().ShowDialog(this);
                        break;
                    }
            }            
        }
    }
}
