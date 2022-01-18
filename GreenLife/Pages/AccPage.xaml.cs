using System;
using System.Windows;
using System.Windows.Controls;
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
        private DateTime _dOB;

        #endregion

        #region [Constructors]

        public AccPage(Account acc, Button btn)
        {
            InitializeComponent();

            _btn = btn;
            Unloaded += AccPage_Unloaded;

            _dOB = acc.DateOfBirth;

            ScoreBlock.Text = "Баллы: " + acc.ScoreSum;
            NameBlock.Text = acc.Name + " " + acc.FamilyName;
            SexBlock.Text = "Пол: " + acc.UserSex;
            DOBBlock.Text = "Дата рождения: \n" + _dOB.ToShortDateString();
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
