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
using tddd43.View;
using tddd43.ViewModel;

namespace tddd43
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow() {

            InitializeComponent();
            MyFrame.Navigate(new StartPage());
        }

        public void GoToStartPage()
        {
            MyFrame.Navigate(new StartPage());
        }

        public void GoToGamePage()
        {
            MyFrame.Navigate(new GamePage(false, false));
        }

        public void GoToGamePageAi()
        {
            MyFrame.Navigate(new GamePage(true, false));
        }
        public void GoToGamePageLoad()
        {
            MyFrame.Navigate(new GamePage(false, true));
        }
    }
}
