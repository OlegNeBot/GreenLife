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
    /// Главное окно
    /// </summary>
    public partial class MainWindow : Window
    {
        #region [Fields]

        private readonly Account _account = null;
        private Page _page;

        #endregion

        #region [Constructors]

        public MainWindow(Account acc)
        {
            _account = acc;
            
            InitializeComponent();

            PagesShow.Navigate(new MainPage(_account, MainBtn));
            MainBtn.IsEnabled = false;
        }

        public MainWindow() 
        {
            InitializeComponent();

            PagesShow.Navigate(new MainPage(MainBtn));
            MainBtn.IsEnabled = false;

        }

        #endregion

        #region [Buttons]

        private void CheckListBtn_Click(object sender, RoutedEventArgs e)
        {
            if (_account != null)
            {
                _page = new CheckBoxPage(_account, CheckListBtn, this);
                RedirectTo(_page, CheckListBtn);
            }
            else
            {
                MessageBox.Show("Чтобы отмечать привычки, нужно зарегистрироваться!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void AccountBtn_Click(object sender, RoutedEventArgs e)
        {
            if (_account == null)
                MessageBox.Show("Чтобы зайти на страницу аккаунта, необходимо зарегистрироваться!", "Внимание!", MessageBoxButton.OK, MessageBoxImage.Warning);
            else 
            {
                _page = new AccPage(_account, AccountBtn);
                RedirectTo(_page, AccountBtn);
            }
        }

        private void MainBtn_Click(object sender, RoutedEventArgs e)
        {
            if (_account != null)
            {
                _page = new MainPage(_account, MainBtn);
                RedirectTo(_page, MainBtn);
            }
            else
            {
                _page = new MainPage(MainBtn);
                RedirectTo(_page, MainBtn);
            }
        }

        private void MemoBtn_Click(object sender, RoutedEventArgs e)
        {
                _page = new MemoPage(MemoBtn, this);
                RedirectTo(_page, MemoBtn);
        }

        private void SettingsBtn_Click(object sender, RoutedEventArgs e)
        {
            if (_account != null)
            {
                _page = new SettingsPage(_account, SettingsBtn, this);
                RedirectTo(_page, SettingsBtn);
            }
            else
            {
                _page = new SettingsPage(SettingsBtn, this);
                RedirectTo(_page, SettingsBtn);
            }
        }

        #endregion

        #region [Methods]

        private void RedirectTo(Page page, Button b)
        {
            PagesShow.Navigate(page);
            b.IsEnabled = false;
        }

        #endregion
    }
}
