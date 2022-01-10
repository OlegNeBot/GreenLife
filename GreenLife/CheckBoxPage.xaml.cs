using System.Windows;
using System.Windows.Controls;
using GreenLifeLib;

namespace GreenLife
{
    /// <summary>
    /// Чек-листы
    /// </summary>
    public partial class CheckBoxPage : Page
    {
        #region [Constructors]

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

        #endregion

        #region [Buttons]

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

        #endregion
    }
}
