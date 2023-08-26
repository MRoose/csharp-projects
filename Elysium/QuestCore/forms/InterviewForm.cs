using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace QuestCore
{
    public partial class InterviewForm : Form
    {
        string name_q, wl, rg_wl, connStr;
        int mode, wfm_id;

        public bool SaveToDB { get; set; } = true;
        private Interview interview;
        private InterviewManipulator interviewManipulator;
        private Questionnaire questionnaire;
        private Anketa anketa;


        private void btBack_Click(object sender, EventArgs e)
        {
            interviewManipulator.GoToPrevQuestion();
            Build();
        }



        public InterviewForm(Questionnaire questionnaire)
        {
            InitializeComponent();
            this.questionnaire = questionnaire;
        }

        public InterviewForm(int wfm_id_p, string wl_p, string rg_wl_p, string name_q_p, string connStr_p)
        {
            InitializeComponent();
            mode = 007;
            wfm_id = wfm_id_p;
            wl = wl_p;
            rg_wl = rg_wl_p;
            name_q = name_q_p;
            connStr = connStr_p;
        }


        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            anketa = new Anketa();

            if (!string.IsNullOrEmpty(wl))
                Text = "Внесение пожелания за " + wl;
            else Text = "Отладка";


            if (questionnaire == null)
            {
                questionnaire = SaverLoader.Load<Questionnaire>(name_q);
            }

            interview = new Interview(questionnaire, anketa);
            interviewManipulator = new InterviewManipulator(interview);
            interviewManipulator.GoToNextQuestion();
            Build();
        }


        public void Build()
        {
            var helper = new ControlHelper(pnAnswers);

            pnAnswers.Controls.Clear();

            foreach (var answer in interview.PassedAnswers)
            {
                var pn = new AnswerPanel();
                pn.Build(interviewManipulator, questionnaire.First(q => q.Id == answer.QuestId), answer, true);
                pn.Parent = pnAnswers;
            }

            if (interview.CurrentAnswer != null)
            {
                var pn = new AnswerPanel();
                pn.Build(interviewManipulator, questionnaire.First(q => q.Id == interview.CurrentAnswer.QuestId), interview.CurrentAnswer, false);
                pn.Parent = pnAnswers;
            }

            btNext.Parent = interview.IsFinished ? null : pnAnswers;
            btBack.Parent = interview.IsFinished ? null : pnAnswers;
            btBack.Visible = interviewManipulator.CanGoToPrevQuestion();
            btFinish.Parent = interview.IsFinished ? pnAnswers : null;

            helper.ResumeDrawing();
        }


        private void btNext_Click(object sender, EventArgs e)
        {
            interviewManipulator.GoToNextQuestion();
            Build();
        }

        private void btFinish_Click(object sender, EventArgs e)
        {
            if (mode == 007)
            {
                try
                {
                    var addParams = new List<Tuple<string, object>>();
                    addParams.Add(new Tuple<string, object>("wfm_id", wfm_id));
                    addParams.Add(new Tuple<string, object>("wl", wl));
                    addParams.Add(new Tuple<string, object>("rg_wl", rg_wl));
                    addParams.Add(new Tuple<string, object>("s_wl", Environment.UserName));

                    var exporter = new ExportToDB();
                    exporter.ConnectionString = "Data Source=" + connStr + "; Version=3;";
                    exporter.Export(questionnaire, anketa, addParams);

                    Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Не удалось отправить пожелания. Еще раз попробуйте, пожалуйста.\r\n"+ex);
                }
            }
            else Close();
        }
    }
}
