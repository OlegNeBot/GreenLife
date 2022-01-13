using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using GreenLifeLib;

namespace GreenLife
{
    /// <summary>
    /// Картинка памятки
    /// </summary>
    public partial class ImagePage : Page
    {
        #region [Fields]

        private readonly MainWindow _mw;

        #endregion

        #region [Constructors]

        public ImagePage(Memo memo, MainWindow mw)
        {
            InitializeComponent();

            _mw = mw;

            LoadImage(memo);
        }

        #endregion

        #region [Buttons]

        private void ReturnBtn_Click(object sender, RoutedEventArgs e)
        {
            _mw.PagesShow.GoBack();
        }

        #endregion

        #region [Methods]

        private void LoadImage(Memo memo)
        {
            string memoRef = memo.MemoRef;
            BitmapImage img = new(new Uri(memoRef));
            MemoImg.Source = img;
        }

        #endregion
    }
}
