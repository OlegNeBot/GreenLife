using GreenLifeLib;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Windows;

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
            CheckIfAuthorised();

            InitializeComponent();

            RegPagesShow.Navigate(new AuthorisePage(this));
        }

        #endregion

        #region [Methods]

        private async void CheckIfAuthorised()
        {
            try
            {
                using (FileStream fs = new("login.json", FileMode.Open))
                {
                    Login login = await JsonSerializer.DeserializeAsync<Login>(fs);
                    if (login.LoginStatus.Equals("Logged"))
                    {
                        using (ApplicationContext db = new())
                        {
                            var account = db.Account.Where(p => p.User.Id == login.Id).First();
                            MainWindow mw = new(account);
                            mw.Show();
                            Close();
                        }
                    }
                }
            }
            catch (FileNotFoundException)
            {

            }
        }

        #endregion
    }
}
