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

namespace GreenLife
{
    /// <summary>
    /// Авторизация
    /// </summary>
    public partial class LoginWindow : Window
    {
        #region [Constructors]

        public LoginWindow()
        {
            //TODO: Сделать возможность сохранения данных пользователя
            //Если первый раз зашел и файла нет - создать файл либо смотреть по бд (id или что-то такое) + статус "Unlogged"
            //Если залогинился или зарегался - менять на статус "Logged"
            InitializeComponent();

            PagesShow.Navigate(new AuthorisePage(this));
        }

        #endregion
    }
}
