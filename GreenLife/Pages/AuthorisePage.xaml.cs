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
    /// Вход в приложение
    /// </summary>
    public partial class AuthorisePage : Page
    {
        #region [Fields]

        private Account _account = null;
        private LoginWindow _lw;

        #endregion

        #region [Constructors]

        public AuthorisePage(LoginWindow lw)
        {
            InitializeComponent();

            _lw = lw;
        }

        #endregion

        #region [Buttons]

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            string _login = LoginTBox.Text;
            string _password = Account.ToHash(PassBox.Password);

            using (ApplicationContext db = new())
            {
                _account = (from account in db.Account
                            where account.Login == _login
                            where account.Password == _password
                            select account).First();
            }

            if (_account == null)
                MessageBox.Show("Неправильное имя пользователя или пароль!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
            else
            {
                MainWindow mainWindow = new(_account);
                RedirectToMain(mainWindow);
            }
        }

        private void RegButton_Click(object sender, RoutedEventArgs e)
        {
            _lw.PagesShow.Navigate(new RegPage(_lw));
        }

        private void SimpleButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new();
            RedirectToMain(mainWindow); 
        }

        #endregion

        #region [Methods]

        private void RedirectToMain(Window window)
        {
            window.Show();
            _lw.Close();
        }

        #endregion
    }
}
