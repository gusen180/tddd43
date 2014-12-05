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

namespace tddd43
{
    /// <summary>
    /// Interaction logic for MidBlock.xaml
    /// </summary>
    public partial class MidBlock : UserControl
    {
        public MidBlock()
        {
            InitializeComponent();
        }

        private void Ellipse_Drop(object sender, DragEventArgs e)
        {
            Ellipse ellipse = sender as Ellipse;
            if (ellipse != null)
            {
                // If the DataObject contains string data, extract it. 
                if (e.Data.GetDataPresent(DataFormats.StringFormat))
                {
                    string dataString = (string)e.Data.GetData(DataFormats.StringFormat);

                    // If the string can be converted into a Brush,  
                    // convert it and apply it to the ellipse.
                    BrushConverter converter = new BrushConverter();
                    if (converter.IsValid(dataString))
                    {
                        if (dataString == Brushes.Blue.ToString())
                        {
                            Game.ChangeColor(ellipse.Uid, 0);
                        }
                        else if (dataString == Brushes.Yellow.ToString()) {
                            Game.ChangeColor(ellipse.Uid, 1);
                        }
                        else if (dataString == Brushes.Green.ToString())
                        {
                            Game.ChangeColor(ellipse.Uid, 2);
                        }
                        else if (dataString == Brushes.Purple.ToString())
                        {
                            Game.ChangeColor(ellipse.Uid, 3);
                        }
                        else if (dataString == Brushes.Aqua.ToString())
                        {
                            Game.ChangeColor(ellipse.Uid, 4);
                        }
                        else if (dataString == Brushes.Red.ToString()) {
                            Game.ChangeColor(ellipse.Uid, 5);
                        }
                    }
                }
            }
        }
    }
}
