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
    /// Логика взаимодействия для MemoPage.xaml
    /// </summary>
    public partial class MemoPage : Page
    {
        public MemoPage()
        {
            InitializeComponent();

            var _memos = Memo.GetMemos();
            foreach (Memo _memo in _memos)
            {
                Button _button = new() { Content = _memo.MemoName};
                _button.Click += Button_Click;
                MainStack.Children.Add(_button);
            }
        }

        private void ReturnBtn_Click(object sender, RoutedEventArgs e)
        { 
            //Redirect to main
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        { 
            //TODO: Open a png-image with it
        }
    }
}
