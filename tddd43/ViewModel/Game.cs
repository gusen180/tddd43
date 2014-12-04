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

        // AI ska flyttas,   http://sartak.org/nh/mastermind.html
        public static List<string> notes = new List<string> { "Blue", "Red", "Green", "Purple", "Brown", "Yellow" };
        public static List<string> tune;
        //public static string[] notes = new string[6]{"Blue", "Red", "Green", "Purple", "Brown", "Yellow"};
        //public static string[] tune = new string[4] { "NoColor", "NoColor", "NoColor", "NoColor"}; 

        public Game(RowModel[] rowModels, RowScoreModel[] rowScoreModels, SolutionModel solution)
        {
            rowModelArray = rowModels;
            rowScoreModelArray = rowScoreModels;
            solutionModel = solution;
            currentRow = 0;
            rowModelArray[currentRow].BackgroundColor = "SlateGray";
            rowModelArray[currentRow].CurrentRow = true;
        }

        //public static void Drag(object sender, MouseEventArgs e)
        //{
        //    Ellipse ellipse = sender as Ellipse;
        //    if (ellipse != null && e.LeftButton == MouseButtonState.Pressed)
        //    {
        //        DragDrop.DoDragDrop(ellipse, ellipse.Fill.ToString(), DragDropEffects.Copy);
        //    }
        //}

        //public static void Drop(object sender, DragEventArgs e)
        //{
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
        //}

        public static void ChangeColor(string spot, string color)
        {
            switch (spot)
            {
                case "0":
                    rowModelArray[currentRow].Spot0 = color;
                    break;
                case "1":
                    rowModelArray[currentRow].Spot1 = color;
                    break;
                case "2":
                    rowModelArray[currentRow].Spot2 = color;
                    break;
                case "3":
                    rowModelArray[currentRow].Spot3 = color;
                    break;
                default:
                    break;
            }
        }

        private static Boolean CorrectSpotAndColor(int spot)
        {
            //Console.WriteLine(rowModelArray[currentRow].rowArray[spot]);
            //Console.WriteLine(solutionModel.internalSolution[spot]);
            //Console.WriteLine(spot);
            return rowModelArray[currentRow].rowArray[spot] == solutionModel.internalSolution[spot];
        }

        private static Boolean CorrectColor(int spot, Boolean[] spotsUsedSolution)
        {
            for (int i = 0; i < 4; i++)
            {
                if (rowModelArray[currentRow].rowArray[spot] == solutionModel.internalSolution[i] && !spotsUsedSolution[i])
                {
                    spotsUsedSolution[i] = true;
                    return true;
                }
            }
            return false;
        }

        public static void CheckGuess()
        {
            Boolean[] spotsUsedGuess = new Boolean[4] { false, false, false, false };
            Boolean[] spotsUsedSolution = new Boolean[4] { false, false, false, false };
            int correctSpotAndColor = 0;
            int correctColor = 0;
            for (int i = 0; i < 4; i++)
            {
                if (CorrectSpotAndColor(i))
                {
                    correctSpotAndColor = correctSpotAndColor + 1;
                    spotsUsedGuess[i] = true;
                    spotsUsedSolution[i] = true;
                }
            }
            for (int i = 0; i < 4; i++)
            {
                if (!spotsUsedGuess[i] && CorrectColor(i, spotsUsedSolution))
                {
                    correctColor = correctColor + 1;
                    spotsUsedGuess[i] = true;
                }
            }
            for (int i = 0; i < (correctSpotAndColor + correctColor); i++)
            {
                if (i < correctSpotAndColor)
                {
                    rowScoreModelArray[currentRow].ChangeColor(i, "Red");
                }
                else
                {
                    rowScoreModelArray[currentRow].ChangeColor(i, "White");
                }
            }

            rowModelArray[currentRow].BackgroundColor = "DarkGray";
            rowModelArray[currentRow].CurrentRow = false;
            currentRow = currentRow + 1;
            rowModelArray[currentRow].BackgroundColor = "SlateGray";
            rowModelArray[currentRow].CurrentRow = true;
        }

        public static void AINextMove()
        {
            tune.Add(notes[0]);
        } 
    }
}
