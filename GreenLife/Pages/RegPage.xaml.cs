using System;
using System.Windows;
using System.Windows.Controls;
using GreenLifeLib;

namespace GreenLife
{
    /// <summary>
    /// Регистрационное окно
    /// </summary>
    public partial class RegPage : Page
    {
        #region [Fields]

        private string _sex = null;
        private DateTime? _dOB = null;
        private string _name;
        private string _fname;
        private string _login;
        private string _password;
        private string _confPass;
        private DateTime _regDate;
        private int _userId;

        private LoginWindow _lw;

        #endregion

        #region [Constructors]

        public RegPage(LoginWindow lw, int userId)
        {
            InitializeComponent();

            _lw = lw;
            _userId = userId;
        }

        #endregion

        #region [FormEvents]

        private void RegAcceptBtn_Click(object sender, RoutedEventArgs e)
        {
            _name = RegNameBox.Text;
            _fname = RegFNameBox.Text;

            _login = RegLoginBox.Text;
            if (!Account.IsLoginAvailable(_login))
            {
                MessageBox.Show("Логин уже занят!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            _password = RegPassBox.Password.Trim();
            _confPass = RegConfirmBox.Password.Trim();
            if (!IsPassEqual(_password, _confPass))
            {
                MessageBox.Show("Пароли не совпадают!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            _regDate = DateTime.Now;

            Account account = new(_login, _password, _name, _fname, _sex, _dOB, _regDate, _userId);
            Account.AddAccount(account);

            MainWindow mainWindow = new(account);
            mainWindow.Show();
            _lw.Close();
            
        }

        private void RegSexBox_Selected(object sender, RoutedEventArgs e)
        {
            ComboBox comboBox = (ComboBox)sender;
            ComboBoxItem selected = (ComboBoxItem)comboBox.SelectedItem;
            if (!(selected.Content == null))
                _sex = selected.Content.ToString();
        }

        private void DOBPicker_Changed(object sender, SelectionChangedEventArgs e)
        {
            DateTime? selected = DOBPicker.SelectedDate;
            _dOB = selected;
        }

        #endregion

        #region [Methods]

        private static bool IsPassEqual(string userPass, string confPass)
        {
            if (userPass.Equals(confPass))
                return true;
            return false;
        }

        #endregion
    }
}
