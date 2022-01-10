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
    /// Настройки в приложении
    /// </summary>
    public partial class SettingsPage : Page
    {
        #region [Fields]

        bool _isLogged;

        #endregion

        #region [Constructors]

        public SettingsPage(Account acc)
        {
            LogoutBtn.Background = new SolidColorBrush(Colors.White);
            LogoutBtn.Foreground = new SolidColorBrush(Colors.Red);
            LogoutBtn.Content = "Выйти из аккаунта";

            InitializeComponent();

            _isLogged = true;
        }

        public SettingsPage()
        {
            LogoutBtn.Background = new SolidColorBrush(Colors.AliceBlue);
            LogoutBtn.Foreground = new SolidColorBrush(Colors.White);
            LogoutBtn.Content = "Зарегистрироваться";

            InitializeComponent();

            _isLogged = false;
        }

        #endregion

        #region [Buttons]

        private void ReturnBtn_Click(object sender, RoutedEventArgs e)
        {
            //Redirect to main
        }

        private void LogoutBtn_Click(object sender, RoutedEventArgs e)
        {
            if (!_isLogged)
            {
                //Redirect to reg
            }
            else if (_isLogged)
            {
                //Redirect to login
            }
        }

        #endregion
    }
}
