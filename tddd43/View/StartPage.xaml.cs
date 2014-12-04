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
using tddd43.ViewModel;

namespace tddd43.View {
    /// <summary>
    /// Interaction logic for StartPage.xaml
    /// </summary>
    public partial class StartPage : Page {
        public StartPage() {
            InitializeComponent();
        }

        private void StartNewGameButton(object sender, RoutedEventArgs e)
        {
            var mainWnd = Application.Current.MainWindow as MainWindow;
            if (mainWnd != null)
                mainWnd.GoToGamePage();
        }

        private void StartNewAIGameButton(object sender, RoutedEventArgs e)
        {

        }
    }
}
