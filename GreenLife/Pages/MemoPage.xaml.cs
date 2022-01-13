using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using GreenLifeLib;

namespace GreenLife
{
    /// <summary>
    /// Памятки
    /// </summary>
    public partial class MemoPage : Page
    {
        #region [Fields]

        private readonly Button _btn;
        private readonly MainWindow _mw;

        #endregion

        #region [Constructors]

        public MemoPage(Button btn, MainWindow mw)
        {
            InitializeComponent();

            _btn = btn;
            _mw = mw;
            Unloaded += MemoPage_Unloaded;

            var memos = Memo.GetMemos();
            foreach (Memo memo in memos)
            {
                Button button = new() { Content = memo.MemoName};
                button.Background = new SolidColorBrush(Colors.LightGreen);
                button.Width = 190;
                button.Click += Button_Click;
                MainStack.Children.Add(button);
            }
        }

        #endregion

        #region [Buttons]

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            using (ApplicationContext db = new())
            {
                var memo = db.Memo.Where(p => p.MemoName.Equals(button.Content.ToString())).First();
                _mw.PagesShow.Navigate(new ImagePage(memo, _mw));
            }
        }

        #endregion

        #region [Methods]

        private void MemoPage_Unloaded(object sender, RoutedEventArgs e)
        {
            _btn.IsEnabled = true;
        }

        #endregion
    }
}
