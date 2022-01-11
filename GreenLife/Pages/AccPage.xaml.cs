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
    /// Страница аккаунта пользователя
    /// </summary>
    public partial class AccPage : Page
    {
        #region [Fields]

        private readonly Button _btn;

        #endregion

        #region [Constructors]

        public AccPage(Account acc, Button btn)
        {
            InitializeComponent();

            _btn = btn;
            Unloaded += AccPage_Unloaded;

            NameBlock.Text = acc.Name + acc.FamilyName;
            SexBlock.Text = "Пол: " + acc.UserSex;
            DOBBlock.Text = "Дата рождения: \n" + acc.DateOfBirth;
        }

        #endregion

        #region [Methods]

        private void AccPage_Unloaded(object sender, RoutedEventArgs e)
        {
            _btn.IsEnabled = true;
        }

        #endregion
    }
}
