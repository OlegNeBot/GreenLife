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
    /// Памятки
    /// </summary>
    public partial class MemoPage : Page
    {
        #region [Fields]

        private readonly Button _btn;

        #endregion

        #region [Constructors]

        public MemoPage(Button btn)
        {
            InitializeComponent();

            _btn = btn;
            Unloaded += MemoPage_Unloaded;

            var _memos = Memo.GetMemos();
            foreach (Memo _memo in _memos)
            {
                Button button = new() { Content = _memo.MemoName};
                button.Click += Button_Click;
                MainStack.Children.Add(button);
            }
        }

        #endregion

        #region [Buttons]

        private void Button_Click(object sender, RoutedEventArgs e)
        { 
            //TODO: Open a png-image with it
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
