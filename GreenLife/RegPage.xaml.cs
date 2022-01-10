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
        #endregion

        #region [Constructors]

        public RegPage()
        {
            InitializeComponent();
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
                //Tell to the user about wrong login (MessageBox or PopUp)
            }
            _password = RegPassBox.Password;
            _confPass = RegConfirmBox.Password;
            if (IsPassEqual(_password, _confPass))
                _password = Account.ToHash(_password);
            else
            {
                //Tell to the user about wrong password (Same)
            }
            _regDate = DateTime.Now;
            Account account = new(_login, _password, _name, _fname, _sex, _dOB, _regDate);
            Account.AddAccount(account);
            //TODO: Redirect to Questions
        }

        private void RegSexBox_Selected(object sender, RoutedEventArgs e)
        {
            ComboBox comboBox = (ComboBox)sender;
            ComboBoxItem selectedItem = (ComboBoxItem)comboBox.SelectedItem;
            MessageBox.Show(selectedItem.Content.ToString());
            _sex = selectedItem.Content.ToString();
        }

        private void DOBPicker_Changed(object sender, SelectionChangedEventArgs e)
        {
            DateTime? selectedDate = DOBPicker.SelectedDate;
            _dOB = selectedDate;
        }

        #endregion

        #region [Methods]

        private bool IsPassEqual(string _userPass, string _confPass)
        {
            if (_userPass.Equals(_confPass))
                return true;
            return false;
        }

        #endregion
    }
}
