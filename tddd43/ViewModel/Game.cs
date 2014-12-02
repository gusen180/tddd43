using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;

namespace tddd43.ViewModel
{
    class Game
    {
        public static int currentRow;
        public static RowModel[] rowModelArray;
        public static RowScoreModel[] rowScoreModelArray;
        public static SolutionModel solutionModel;

        public Game(RowModel[] rowModels, RowScoreModel[] rowScoreModels, SolutionModel solution) {
            rowModelArray = rowModels;
            rowScoreModelArray = rowScoreModels;
            solutionModel = solution;
            currentRow = 0;
            rowModelArray[currentRow].BackgroundColor = Brushes.SlateGray;
            rowModelArray[currentRow].AllowDrop = "True";
        }

        public static void Drag(object sender, MouseEventArgs e)
        {
            Ellipse ellipse = sender as Ellipse;
            if (ellipse != null && e.LeftButton == MouseButtonState.Pressed)
            {
                DragDrop.DoDragDrop(ellipse, ellipse.Fill.ToString(), DragDropEffects.Copy);
            }
        }

        public static void Drop(object sender, DragEventArgs e)
        {
            //Ellipse ellipse = sender as Ellipse;
            //if (ellipse != null)
            //{
            //    // If the DataObject contains string data, extract it. 
            //    if (e.Data.GetDataPresent(DataFormats.StringFormat))
            //    {
            //        string dataString = (string)e.Data.GetData(DataFormats.StringFormat);

            //        // If the string can be converted into a Brush,  
            //        // convert it and apply it to the ellipse.
            //        BrushConverter converter = new BrushConverter();
            //        if (converter.IsValid(dataString))
            //        {
            //            Brush newFill = (Brush)converter.ConvertFromString(dataString);
            //            switch (ellipse.Uid) {
            //                case "0":
            //                    rowModelArray[currentRow].Spot0 = newFill;
            //                    break;
            //                case "1":
            //                    rowModelArray[currentRow].Spot1 = newFill;
            //                    break;
            //                case "2":
            //                    rowModelArray[currentRow].Spot2 = newFill;
            //                    break;
            //                case "3":
            //                    rowModelArray[currentRow].Spot3 = newFill;
            //                    break;
            //                default:
            //                    break;
            //            }
            //        }
            //    }
            //}
        }

        private static Boolean CorrectSpotAndColor(int spot) {
            return rowModelArray[currentRow].rowArray[spot].ToString() == solutionModel.solution[spot].ToString();
        }

        private static Boolean CorrectColor(int spot) {
            for (int i = 0; i < 4; i++) {
                if (rowModelArray[currentRow].rowArray[i].ToString() == solutionModel.solution[spot].ToString()) {
                    return true;
                }
            }
            return false;
        }

        public static void Accept(object sender, RoutedEventArgs e) {
        //    Boolean[] spotsUsed = new Boolean[4] { false, false, false, false };
        //    int correctSpotAndColor = 0;
        //    int correctColor = 0;
        //    for (int i = 0; i < 4; i++) {
        //        if (CorrectSpotAndColor(i)) {
        //            correctSpotAndColor = correctSpotAndColor + 1;
        //            rowModelArray[currentRow].rowArray[i] = Brushes.Black;
        //            spotsUsed[i] = true;
        //        }
        //    }
        //    for (int i = 0; i < 4; i++) {
        //        if (!spotsUsed[i] && CorrectColor(i)) {
        //            correctColor = correctColor + 1;
        //            spotsUsed[i] = true;
        //        }
        //    }
        //    for (int i = 0; i < (correctSpotAndColor + correctColor); i++) {
        //        if (i < correctSpotAndColor) {
        //            rowScoreModelArray[currentRow].ChangeColor(i, Brushes.Red);
        //        }
        //        else {
        //            rowScoreModelArray[currentRow].ChangeColor(i, Brushes.White);
        //        }
        //    }

        //    rowModelArray[currentRow].BackgroundColor = Brushes.DarkGray;
        //    rowModelArray[currentRow].AllowDrop = "False";
        //    currentRow = currentRow + 1;
        //    rowModelArray[currentRow].BackgroundColor = Brushes.SlateGray;
        //    rowModelArray[currentRow].AllowDrop = "True";
        }
    }
}
