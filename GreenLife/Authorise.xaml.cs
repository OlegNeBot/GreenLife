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
using System.Windows.Shapes;
using GreenLifeLib;

namespace GreenLife
{
    /// <summary>
    /// Вход в приложение
    /// </summary>
    public partial class Authorise : Window
    {
        #region [Fields]

        public Account _account = null;

        #endregion

        #region [Constructors]

        public Authorise()
        {
            //TODO: Сделать возможность сохранения данных пользователя
            //Если первый раз зашел и файла нет - создать файл либо смотреть по бд (id или что-то такое) + статус "Unlogged"
            //Если залогинился или зарегался - менять на статус "Logged"
            InitializeComponent();
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
                //TODO: Redirect to MainWindow and close this Window
            }
        }

        private void RegButton_Click(object sender, RoutedEventArgs e)
        {
            //TODO: Redirect to Register Page
        }

        private void SimpleButton_Click(object sender, RoutedEventArgs e)
        {
            //TODO: Redirect to MainWindow
        }

        #endregion
    }
}
