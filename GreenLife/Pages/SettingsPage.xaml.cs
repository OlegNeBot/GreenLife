using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
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

        private readonly Button _btn;
        private readonly MainWindow _mW;

        #endregion

        #region [Constructors]

        public SettingsPage(Account acc, Button btn, MainWindow mainWindow)
        {
            InitializeComponent();

            LogoutBtn.Background = new SolidColorBrush(Colors.AntiqueWhite);
            LogoutBtn.Foreground = new SolidColorBrush(Colors.Red);
            LogoutBtn.Content = "Выйти из аккаунта";

            _btn = btn;
            Unloaded += SettingsPage_Unloaded;

            _mW = mainWindow;
        }

        public SettingsPage(Button btn, MainWindow mainWindow)
        {   
            InitializeComponent();

            LogoutBtn.Background = new SolidColorBrush(Colors.LightGreen);
            LogoutBtn.Foreground = new SolidColorBrush(Colors.Black); 
            LogoutBtn.Content = "Авторизоваться"; 

            _btn = btn;
            Unloaded += SettingsPage_Unloaded;

            _mW = mainWindow;
        }

        #endregion

        #region [Buttons]


        private void LogoutBtn_Click(object sender, RoutedEventArgs e)
        {
            FileLogout();
            LoginWindow loginWindow = new();
                loginWindow.Show();
                _mW.Close();
        }

        #endregion

        #region [Methods]

        private void SettingsPage_Unloaded(object sender, RoutedEventArgs e)
        {
            _btn.IsEnabled = true;
        }

        private async void FileLogout()
        {
            Task n = Task.Run(async () =>
            {
                try
            {
                using (FileStream fs = new("login.json", FileMode.Open))
                {
                    Login login = await JsonSerializer.DeserializeAsync<Login>(fs);
                        fs.SetLength(0);
                    login.LoginStatus = "Unlogged";
                    await JsonSerializer.SerializeAsync<Login>(fs, login);
                }
            }
            catch (FileNotFoundException)
            {
                
            }
            });
            n.Wait();
        }

        #endregion
    }
}
