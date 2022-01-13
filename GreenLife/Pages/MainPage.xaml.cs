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
    /// Главная страница
    /// </summary>
    public partial class MainPage : Page
    {
        #region [Fields]

        private readonly Button _btn = null;

        #endregion

        #region [Constructors]

        public MainPage(Button btn)
        {
            InitializeComponent();
            DayPhraseBlock.Text = DayPhrase.GetRandomPhrase();
            _btn = btn;
            Unloaded += MainPage_Unloaded;
        }

        public MainPage(Account acc, Button btn)
        {
            InitializeComponent();

            _btn = btn;
            Unloaded += MainPage_Unloaded;
            DayPhraseBlock.Text = DayPhrase.GetRandomPhrase();

            //TODO: Do in MainPage a colors and elems showing
            //MainColorBlock.Text += PlanetColors.GetColorsByPlanet(account.Id);
        }

        #endregion

        #region [Events]

        private void MainPage_Unloaded(object sender, RoutedEventArgs e)
        {
            _btn.IsEnabled = true;
        }

        #endregion
    }
}
