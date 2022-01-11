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
        #region [Fields]

        private readonly Button _btn;

        #endregion

        #region [Constructors]

        public CheckBoxPage(Account acc, Button btn)
        {
            InitializeComponent();

            _btn = btn;
            Unloaded += CheckBoxPage_Unloaded;

            //TODO: Do in a method
            var checkBoxes = CheckList.GetCheckLists(acc.Id);
            foreach (CheckList box in checkBoxes)
            {
                Button b = new() { Content = box.CheckListName };
                b.Click += Button_Click;
                MainStack.Children.Add(b);
            }
        }

        public CheckBoxPage(Button btn)
        {
            InitializeComponent();

            _btn = btn;
            Unloaded += CheckBoxPage_Unloaded;

            //Add standart CheckLists
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

        #region [Methods]

        private void CheckBoxPage_Unloaded(object sender, RoutedEventArgs e)
        {
            _btn.IsEnabled = true;
        }

        #endregion
    }
}
