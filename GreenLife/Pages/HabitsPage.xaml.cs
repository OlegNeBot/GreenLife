using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using GreenLifeLib;
using Microsoft.EntityFrameworkCore;

namespace GreenLife
{
    /// <summary>
    /// Страница с привычками
    /// </summary>
    public partial class HabitsPage : Page
    {
        #region [Fields]

        private int _usrId;

        #endregion

        #region [Constructors]

        public HabitsPage(CheckList cl, int usrId)
        {
            _usrId = usrId;

            InitializeComponent();

            var habits = Habit.GetHabitsOfCheckList(cl.Id);
            foreach (Habit habit in habits)
            {
                GroupBox groupBox = new() { Header = habit.HabitName };
                StackPanel newStack = new();
                newStack.Background = new SolidColorBrush(Colors.LightGreen);

                TextBlock tb = new() { Text = "Баллов: " + habit.Score };
                tb.HorizontalAlignment = HorizontalAlignment.Center;
                newStack.Children.Add(tb);

                TextBlock execBlock = new() { Text = habit.ExecProperty };
                execBlock.HorizontalAlignment = HorizontalAlignment.Center;
                newStack.Children.Add(execBlock);

                var execution = HabitPerformance.GetExecution(habit.Id, _usrId);
                TextBlock num = new() { Text = execution.NumOfExecs + "/" + habit.NumsNeeded };
                if (execution.Executed)
                    newStack.Opacity = 0.25;
                else
                    groupBox.MouseDoubleClick += Button_Click;

                num.HorizontalAlignment = HorizontalAlignment.Center;
                newStack.Children.Add(num);

                groupBox.Content = newStack;
                MainStack.Children.Add(groupBox);
            }
        }

        #endregion

        #region [Buttons]

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            GroupBox selected = (GroupBox)sender;
            using (ApplicationContext db = new())
            {
                string hName = selected.Header.ToString();
                var habit = db.Habit.Include(p => p.HabitPhrase).Where(p => p.HabitName == hName).First();
                MessageBoxResult result = MessageBox.Show("Вы уверены, что хотите отметить привычку?", "Подтверждение", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (result == MessageBoxResult.Yes)
                {
                    HabitPerformance hp = db.HabitPerformance.Where(p => p.UserId == _usrId).Where(p => p.HabitId == habit.Id).First();
                    MessageBox.Show($"{(DateTime.Now - Convert.ToDateTime(hp.DateOfExec)).TotalHours}");
                    if ((DateTime.Now - Convert.ToDateTime(hp.DateOfExec)).TotalHours > 24)
                    {
                        HabitPerformance.NewExecution(habit.Id, _usrId);
                        string phrase = habit.HabitPhrase.PhraseText;
                        MessageBox.Show(phrase, "Отметка", MessageBoxButton.OK);
                    }
                    else 
                    {
                        MessageBox.Show("С момента предыдущего выполнения еще не прошло 24 часа!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
            }
        }

        #endregion
    }
}
