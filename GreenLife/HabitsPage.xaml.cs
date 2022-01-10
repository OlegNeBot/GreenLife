using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using GreenLifeLib;

namespace GreenLife
{
    /// <summary>
    /// Страница с привычками
    /// </summary>
    public partial class HabitsPage : Page
    {
        #region [Constructors]

        public HabitsPage()
        {
            InitializeComponent();
        }

        public HabitsPage(CheckList cl)
        {
            InitializeComponent();

            var _habits = Habit.GetHabitsOfCheckList(cl.Id);
            foreach (Habit _habit in _habits)
            {
                GroupBox groupBox = new() { Header = _habit.HabitName };
                StackPanel newStack = new();

                TextBlock tb = new() { Text = _habit.HabitName };
                newStack.Children.Add(tb);

                var _execution = HabitPerformance.GetExecution(_habit.Id);
                TextBlock num = new() { Text = _execution.NumOfExecs + "/" + _execution.ExecProperty };
                newStack.Children.Add(num);

                Button button = new() { Content = "Выполнить"};
                button.Click += Button_Click;
                newStack.Children.Add(button);

                groupBox.Content = newStack;
            }
        }

        #endregion

        #region [Buttons]

        private void ReturnBtn_Click(object sender, RoutedEventArgs e)
        {
            //redirect to main
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Вы уверены, что хотите отметить привычку?", "Подтверждение", MessageBoxButton.YesNo,MessageBoxImage.Question) ;
           // if (MessageBoxResult.Yes)
           //TODO: If result of the message box is "yes"
           //NewExecution()
        }

        #endregion
    }
}
