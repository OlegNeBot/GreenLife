using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using GreenLifeLib;

namespace GreenLife
{
    /// <summary>
    /// Анкета
    /// </summary>
    public partial class QuestionPage : Page
    {
        #region [Fields]

        private bool _isntAnswered = true;
        private Question _question;
        private Answer _answer;

        private readonly LoginWindow _lw;
        private Account _acc;

        #endregion

        #region [Constructors]

        public QuestionPage(Account acc, LoginWindow lw)
        {
            InitializeComponent();

            _lw = lw;
            _acc = acc;

            var questions = Question.GetQuestions();
            foreach (Question q in questions)
            {
                int num = questions.IndexOf(q);
                QuestionLabel.Content = "Вопрос " + (num + 1);
                _isntAnswered = true;
                while (_isntAnswered)
                {
                    _question = q;
                    QuestionBlock.Text = q.QuestText;
                    var answers = Answer.GetAnswersByQuestion(q.Id).ToList();
                    foreach (Answer answ in answers)
                    {
                        RadioButton radioButton = new() { IsChecked = false, GroupName = "Answer", Content = answ.AnswerText };
                        radioButton.Background = new SolidColorBrush(Colors.LightGreen);
                        radioButton.Width = 100;
                        radioButton.Height = 150;
                        radioButton.Checked += Button_Click;
                        mainGrid.Children.Add(radioButton);
                    }
                }
            }
        }


        #endregion

        #region [Buttons]

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            RadioButton pressed = (RadioButton)sender;
            string answText = pressed.Content.ToString();
            using (ApplicationContext db = new())
            {
                _answer = db.Answer.Where(p => p.AnswerText == answText).First();
            }
                UserAnswer userAnswer = new() { Question = _question, Answer = _answer, Account = _acc };
                UserAnswer.AddUserAnswer(userAnswer);
            _isntAnswered = false;
        }

        #endregion
    }
}
