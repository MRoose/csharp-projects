using System;
using System.Linq;
using System.Windows.Forms;

namespace QuestCore
{
    public partial class AnswerPanel : UserControl
    {
        private Quest quest;
        private Answer answer;
        private InterviewManipulator interviewManipulator;

        /// <summary>
        /// Пользователь указал/изменил ответ
        /// </summary>
        public event Action Changed = delegate { };

        public AnswerPanel()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Построение интерфейса
        /// </summary>
        public void Build(InterviewManipulator interviewManipulator, Quest quest, Answer answer, bool readOnly)
        {
            this.interviewManipulator = interviewManipulator;
            this.quest = quest;
            this.answer = answer;

            lbQuestTitle.Text = quest.Title;

            //очищаем панель альтернатив
            pnMain.Controls.Clear();

            if (readOnly)
            {
                //строим ответы в режиме readonly
                BuildReadOnlyAnswerInterface();
            }
            else
            {
                //строим альтернативы, в зависимости от типа вопроса
                switch (quest.QuestType)
                {
                    case QuestType.Выпадающий_список: BuildSingleAnswerInterface(); break;
                    case QuestType.Строка_ввода: BuildOpenAnswerInterface(); break;
                }
            }
        }

        private void BuildSingleAnswerInterface()
        {
            //создаем комбобокс
            var cb = new ComboBox();
            var alternatives = interviewManipulator.GetAllowedAlternatives().ToList();//получаем список разрешенных к показу альтернатив
            cb.DataSource = alternatives;//отображаем список альтернатив
            cb.ValueMember = "Code";
            cb.DisplayMember = "Title";
            cb.DropDownStyle = ComboBoxStyle.DropDownList;
            cb.Parent = pnMain;
            cb.SelectedValueChanged += (o, O) => OnValueSelected((int)cb.SelectedValue);//обрабатываем выбор
            //имитируем выбор первой альтернативы
            if (alternatives.Count > 0)
                OnValueSelected(alternatives[0].Code);
        }

        private void BuildOpenAnswerInterface()
        {
            //создаем текстбокс
            var tb = new TextBox();
            tb.Parent = pnMain;
            tb.TextChanged += (o, O) => OnValueSelected(tb.Text);//обрабатываем выбор

            /*TeBo tb = new TeBo();
            tb.Parent = pnMain;
            tb.textBox1.TextChanged += (o, O) => OnValueSelected(tb.textBox1.Text);*/
        }

        private void BuildReadOnlyAnswerInterface()
        {
            //создаем лейбу
            var lb = new Label();
            //получаем альтернативу
            var alt = quest.FirstOrDefault(a => a.Code == answer.AlternativeCode);
            lb.Text = alt?.Title + " " + answer.Text;
            lb.Parent = pnMain;

            /*SeeA SA = new SeeA();
            var alt = quest.FirstOrDefault(a => a.Code == answer.AlternativeCode);
            SA.label1.Text = alt?.Title;
            SA.textBox1.Text = answer.Text;
            SA.Parent = pnMain;*/
        }

        private void OnValueSelected(int alternativeCode)
        {
            answer.AlternativeCode = alternativeCode; //отправлем выбранное значение в доменный объект
            Changed();//сигнализируем наверх, о том, что пользователь что-то выбрал
        }

        private void OnValueSelected(string text)
        {
            answer.Text = text; //отправлем выбранное значение в доменный объект
            Changed();//сигнализируем наверх, о том, что пользователь что-то выбрал
        }
    }
}
