namespace ConnCore
{
    public class feedback
    {
        public feedback()
        {
            new form_feedback().ShowDialog();
        }

        public feedback(string err)
        {
            new _dRes(err).ShowDialog();
        }
    }
}
