using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using GreenLifeLib;

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

                TextBlock tb = new() { Text = habit.HabitName };
                tb.HorizontalAlignment = HorizontalAlignment.Center;
                newStack.Children.Add(tb);

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
                var habit = db.Habit.Where(p => p.HabitName == hName).First();
                MessageBoxResult result = MessageBox.Show("Вы уверены, что хотите отметить привычку?", "Подтверждение", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (result == MessageBoxResult.Yes)
                {
                    HabitPerformance.NewExecution(habit.Id, _usrId);
                    string phrase = "Вы отметили привычку " + hName;
                    MessageBox.Show(phrase, "Отметка", MessageBoxButton.OK);
                }
            }
        }

        #endregion
    }
}
