using System;
using System.Collections.Generic;
using System.IO;
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
using System.Xml.Linq;
using tddd43.Helpers;
using tddd43.ViewModel;

namespace tddd43.View {
    /// <summary>
    /// Interaction logic for GamePage.xaml
    /// </summary>
    public partial class GamePage : Page {
        private static bool ai;
        private static bool load;

        public GamePage(bool aiPlayer, bool loadGame) {
            InitializeComponent();
            ai = aiPlayer;
            load = loadGame;

            RowModel[] rowModelArray = new RowModel[10];
            RowScoreModel[] rowScoreModelArray = new RowScoreModel[10];

            TopMidBlock topMidBlock = new TopMidBlock();
            topMidBlock.DataContext = new SolutionModel();
            Grid.SetRow(topMidBlock, 0);
            Grid.SetColumn(topMidBlock, 2);
            topMidBlock.Margin = new System.Windows.Thickness { Top = 4, Bottom = 4 };
            MasterMindLeft.Children.Add(topMidBlock);

            for (int y = 1; y < 11; y++) {
                MidBlock midBlock = new MidBlock();
                rowModelArray[((11 - y) % 11) - 1] = new RowModel(load);
                midBlock.DataContext = rowModelArray[((11 - y) % 11) - 1];
                Grid.SetRow(midBlock, y);
                Grid.SetColumn(midBlock, 2);
                midBlock.Margin = new System.Windows.Thickness { Top = 4, Bottom = 4 };
                MasterMindLeft.Children.Add(midBlock);
            }

            for (int y = 1; y < 11; y++)
            {
                LeftBlock leftBlock = new LeftBlock();
                Grid.SetRow(leftBlock, y);
                Grid.SetColumn(leftBlock, 1);
                leftBlock.Margin = new System.Windows.Thickness { Top = 4, Bottom = 4, Right = 4 };
                MasterMindLeft.Children.Add(leftBlock);

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
                MasterMindLeft.Children.Add(textblock);

                RightBlock rightBlock = new RightBlock();
                rowScoreModelArray[((11 - y) % 11) - 1] = new RowScoreModel(load);
                rightBlock.DataContext = rowScoreModelArray[((11 - y) % 11) - 1];
                Grid.SetRow(rightBlock, y);
                Grid.SetColumn(rightBlock, 3);
                rightBlock.Margin = new System.Windows.Thickness { Top = 4, Bottom = 4, Left = 4 };
                MasterMindLeft.Children.Add(rightBlock);
            }

            ColorPalette colorPalette = new ColorPalette();
            colorPalette.DataContext = new ColorPaletteModel();
            Grid.SetRow(colorPalette, 1);
            Grid.SetColumn(colorPalette, 0);
            MasterMindRight.Children.Add(colorPalette);

            //Create game and ai
            if (!load)
            {
                new XmlHelper();
            }
            new Game(rowModelArray, rowScoreModelArray, (SolutionModel)topMidBlock.DataContext, load);
            if (ai || (load && File.Exists("AiXml.xml")))
            {
                new AI(load);
                ai = true;
            }
            else if (File.Exists("AiXml.xml"))
            {
                File.Delete("AiXml.xml");
            }
        }

        private void ClickEvent(object sender, RoutedEventArgs e) {
            if (ai)
            {
                AI.NextAIMove();
            }
            else 
            { 
                Game.CheckGuess();
            }
        }
        
    }
}
