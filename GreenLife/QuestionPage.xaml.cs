using System.Linq;
using System.Windows;
using System.Windows.Controls;
using GreenLifeLib;

namespace GreenLife
{
    /// <summary>
    /// Анкета
    /// </summary>
    public partial class QuestionPage : Page
    {
        #region [Fields]

        public Question _question;
        public Answer _answer;

        #endregion

        #region [Constructors]

        public QuestionPage(Account acc)
        {
            InitializeComponent();

            var _questions = Question.GetQuestions();
            for (int i = 0; i < _questions.Count; i++)
            {
                QuestionLabel.Content = "Вопрос " + (i + 1);
                while (true)
                {
                    _question = _questions[i];
                    QuestionBlock.Text = _question.QuestText;
                    var _answers = Answer.GetAnswersByQuestion(_question.Id).ToList();
                    foreach (Answer answ in _answers)
                    {
                        _answer = answ;
                        RadioButton radioButton = new() { IsChecked = false, GroupName = "Answer", Content = _answer.AnswerText };
                        radioButton.Width = 100;
                        radioButton.Height = 150;
                        radioButton.Checked += Button_Click;
                        mainGrid.Children.Add(radioButton);
                    }
                   /* Button button = new Button();
                    button.Height = 100;
                    button.Width = 150;
                    button.Content = "Отправить";
                   */
                }
            }
        }

        public QuestionPage()
        {
            InitializeComponent();
        }

        #endregion

        #region [Buttons]

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            RadioButton pressed = (RadioButton)sender;
            MessageBox.Show(pressed.Content.ToString());
            UserAnswer _userAnswer = new() { Question = _question, Answer = _answer };
            UserAnswer.AddUserAnswer(_userAnswer);
            //TODO: Continue the cycle
        }

        #endregion
    }
}
