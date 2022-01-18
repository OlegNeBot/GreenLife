using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using GreenLifeLib;
using System.Text.Json;
using System.IO;
using System.Threading.Tasks;

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
        private Login _login;

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
            string login = LoginTBox.Text.Trim();
            string pass = PassBox.Password.Trim();
            string password = Account.ToHash(pass);

            using (ApplicationContext db = new())
            {
                try
                {
                    _account = db.Account.Where(p => p.Login == login)
                        .Where(p => p.Password.Equals(password))
                        .First();
                    _login = new() { Id = _account.UserId };
                    if ((bool)LoginCheck.IsChecked)
                        _login.LoginStatus = "Logged";
                    else 
                        _login.LoginStatus = "Unlogged";
                    LoadToFile(_login);
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
            TakeAUser();
            _lw.RegPagesShow.Navigate(new RegPage(_lw, _login.Id));
        }

        private void SimpleButton_Click(object sender, RoutedEventArgs e)
        {
            TakeAUser();
            MainWindow mainWindow = new(_login.Id);
            RedirectToMain(mainWindow); 
        }

        #endregion

        #region [Methods]

        private void RedirectToMain(Window window)
        {
            window.Show();
            _lw.Close();
        }

        public static async void LoadToFile(Login login)
        {
            using (FileStream fs = new("login.json", FileMode.Create))
            {
                await JsonSerializer.SerializeAsync<Login>(fs, login);
            }
        }

        private void TakeAUser()
        {
           Task n = Task.Run(async () =>
           {
               try
               {
                   using (FileStream fs = new("login.json", FileMode.Open))
                   {
                       _login = await JsonSerializer.DeserializeAsync<Login>(fs);
                   }
               }
               catch (FileNotFoundException)
               {
                   User user = new() { RoleId = 1};
                   using (ApplicationContext db = new())
                   {
                       db.User.Add(user);
                       db.SaveChanges();
                   }
                   for (int i = 0; i < 5; i++)
                   {
                       CheckList chL = new();
                       chL.CheckListName = chL._checklistNames[i];
                       chL.TypeId = i + 1;
                       chL.UserId = user.Id;

                       using (ApplicationContext db = new())
                       {
                           var habits = db.Habit.Where(p => p.TypeId == chL.TypeId).ToList();
                           chL.Habit = habits;
                           db.CheckList.Add(chL);
                           db.SaveChanges();
                           foreach (Habit h in habits)
                           {
                               HabitPerformance hp = new() { DateOfExec = DateTime.MinValue, HabitId = h.Id, UserId = user.Id};
                               db.HabitPerformance.Add(hp);
                               db.SaveChanges();
                           }
                       }
                   }
                   _login = new() { Id = user.Id, LoginStatus = "Unlogged" };
                   LoadToFile(_login);
               }
           });
            n.Wait();
        }

        #endregion
    }
}
