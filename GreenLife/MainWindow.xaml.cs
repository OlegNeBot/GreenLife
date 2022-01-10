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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Account account = null;
        public MainWindow(Account acc)
        {
            InitializeComponent();

            account = acc;
            DayPhraseBlock.Text = DayPhrase.GetRandomPhrase();
            MainColorBlock.Text += PlanetColors.GetColorsByPlanet(account.Id);
        }

        public MainWindow() 
        {
            InitializeComponent();

            DayPhraseBlock.Text = DayPhrase.GetRandomPhrase();
        }
        //TODO: Do Redirect in methods
        private void CheckListBtn_Click(object sender, RoutedEventArgs e)
        { 
            
        }

        private void AccountBtn_Click(object sender, RoutedEventArgs e)
        {
            if (account == null)
                MessageBox.Show("Чтобы зайти на страницу аккаунта, необходимо зарегистрироваться!", "Внимание!", MessageBoxButton.OK, MessageBoxImage.Warning);
            else 
            { 
                
            }
        }

        private void MainBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void MemoBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void SettingsBtn_Click(object sender, RoutedEventArgs e)
        {
            
        }
    }
}
