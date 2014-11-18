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

namespace tddd43
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            
            TopMidBlock topMidBlock = new TopMidBlock();
            Grid.SetRow(topMidBlock, 0);
            Grid.SetColumn(topMidBlock, 2);
            topMidBlock.Margin = new System.Windows.Thickness { Top = 4, Bottom = 4 };
            MasterMind.Children.Add(topMidBlock);


            for (int y = 1; y < 11; y++)
            {
                MidBlock midBlock = new MidBlock();
                Grid.SetRow(midBlock, y);
                Grid.SetColumn(midBlock, 2);
                midBlock.Margin = new System.Windows.Thickness { Top = 4, Bottom = 4 };
                MasterMind.Children.Add(midBlock);
            }

            for (int y = 1; y < 11; y++)
            {
                LeftBlock leftBlock = new LeftBlock();
                Grid.SetRow(leftBlock, y);
                Grid.SetColumn(leftBlock, 1);
                leftBlock.Margin = new System.Windows.Thickness { Top = 4, Bottom = 4, Right = 4 };
                MasterMind.Children.Add(leftBlock);

                TextBlock textblock = new TextBlock
                {
                    Text = ((11 - y) % 11).ToString(),
                    Foreground = Brushes.Black,
                    HorizontalAlignment = HorizontalAlignment.Center,
                    VerticalAlignment = VerticalAlignment.Center,
                    FontSize = 25
                };
                Grid.SetRow(textblock, y);
                Grid.SetColumn(textblock, 1);
                MasterMind.Children.Add(textblock);

                RightBlock rightBlock = new RightBlock();
                Grid.SetRow(rightBlock, y);
                Grid.SetColumn(rightBlock, 3);
                rightBlock.Margin = new System.Windows.Thickness { Top = 4, Bottom = 4, Left = 4 };
                MasterMind.Children.Add(rightBlock);
            }

            SolidColorBrush[] colors = new SolidColorBrush[] { Brushes.Blue, Brushes.Red, Brushes.Green, Brushes.Yellow,
                                                                Brushes.Purple, Brushes.Brown, Brushes.Aqua, Brushes.LightBlue };
            for (int x = 0; x < 10; x++) {
                for (int y = 0; y < 10; y++) {

                }
            }
        }
    }
}
