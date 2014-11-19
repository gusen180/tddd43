using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;

namespace tddd43.ViewModel
{
    class Game
    {
        public static void Drag(object sender, MouseEventArgs e)
        {
            Ellipse ellipse = sender as Ellipse;
            if (ellipse != null && e.LeftButton == MouseButtonState.Pressed)
            {
                DragDrop.DoDragDrop(ellipse, ellipse.Fill.ToString(), DragDropEffects.Copy);
            }
        }

        public static void Drop(object sender, DragEventArgs e, MidBlock midBlock)
        {
            Ellipse ellipse = sender as Ellipse;
            RowModel rowModel = midBlock.DataContext as RowModel;
            if (ellipse != null && rowModel != null)
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
                        Brush newFill = (Brush)converter.ConvertFromString(dataString);
                        rowModel.spot0 = newFill;
                    }
                }
            }
        }
    }
}
