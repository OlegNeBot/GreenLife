using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Linq;
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
        private readonly MainWindow _mw;

        #endregion

        #region [Constructors]

        public CheckBoxPage(Account acc, Button btn, MainWindow mw)
        {
            InitializeComponent();

            _btn = btn;
            _mw = mw;
            Unloaded += CheckBoxPage_Unloaded;

            var checkBoxes = CheckList.GetCheckLists();
            foreach (CheckList box in checkBoxes)
            {
                Button b = new() { Content = box.CheckListName};
                b.Click += Button_Click;
                b.Background = new SolidColorBrush(Colors.LightGreen);
                MainStack.Children.Add(b);
            }
        }

        public CheckBoxPage(Button btn, MainWindow mw)
        {
            InitializeComponent();

            _btn = btn;
            Unloaded += CheckBoxPage_Unloaded;

            var checkBoxes = CheckList.GetCheckLists();
            foreach (CheckList box in checkBoxes)
            {
                Button b = new() { Content = box.CheckListName };
                b.Click += Button_Click;
                b.Background = new SolidColorBrush(Colors.LightGreen);
                MainStack.Children.Add(b);
            }
        }

        #endregion

        #region [Buttons]

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button pressed = (Button)sender;
            string content = pressed.Content.ToString();
            //MessageBox.Show("Эта функция находится в разработке!", "Внимание", MessageBoxButton.OK, MessageBoxImage.Information);
            using (ApplicationContext db = new())
            {
                var chL = db.CheckList.Where(p => p.CheckListName == content).First();

                _mw.PagesShow.Navigate(new HabitsPage(chL));
            }
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
