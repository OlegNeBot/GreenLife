using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
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
            string login = LoginTBox.Text;
            string pass = PassBox.Password.Trim();
            string password = Account.ToHash(pass);

            using (ApplicationContext db = new())
            {
                try
                {
                    _account = db.Account.Where(p => p.Login == login)
                        .Where(p => p.Password.Equals(password))
                        .First();
                    MainWindow mainWindow = new(_account);
                    RedirectToMain(mainWindow);
                }

                catch (InvalidOperationException)
                {
                    MessageBox.Show("Неправильное имя пользователя или пароль!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            }
        }

        private void RegButton_Click(object sender, RoutedEventArgs e)
        {
            _lw.RegPagesShow.Navigate(new RegPage(_lw));
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
