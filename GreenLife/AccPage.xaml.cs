﻿using System;
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
    /// Логика взаимодействия для AccPage.xaml
    /// </summary>
    public partial class AccPage : Page
    {
        public AccPage(Account acc)
        {
            InitializeComponent();

            NameBlock.Text = acc.Name + acc.FamilyName;
            SexBlock.Text = "Пол: " + acc.UserSex;
            DOBBlock.Text = "Дата рождения: \n" + acc.DateOfBirth;
        }

        public AccPage()
        {
            InitializeComponent();
        }

        private void ReturnBtn_Click(object sender, RoutedEventArgs e)
        {
            //TODO: Redirect to Main
        }
    }
}
