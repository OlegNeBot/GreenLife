using System.Windows;
using System.Windows.Controls;
using GreenLifeLib;

namespace GreenLife
{
    /// <summary>
    /// Логика взаимодействия для CheckBoxPage.xaml
    /// </summary>
    public partial class CheckBoxPage : Page
    {
        public CheckBoxPage(Account acc)
        {
            InitializeComponent();
            var _checkBoxes = CheckList.GetCheckLists(acc.Id);
            foreach (CheckList _box in _checkBoxes)
            {
                Button b = new Button { Content = _box.CheckListName };
                b.Click += Button_Click;
                MainGrid.Children.Add(b);
            }
        }

        public CheckBoxPage()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button pressed = (Button)sender;
            MessageBox.Show(pressed.Content.ToString());
            //Redirect to Habit page with checklist in constructor
        }

        private void ReturnBtn_Click(object sender, RoutedEventArgs e)
        { 
            //Redirect to main
        }
    }
}
