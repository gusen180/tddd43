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
using tddd43.Helpers;

namespace tddd43.ViewModel
{
    class Game
    {
        public static int currentRow;
        public static RowModel[] rowModelArray;
        public static RowScoreModel[] rowScoreModelArray;
        public static SolutionModel solutionModel;


        public Game(RowModel[] rowModels, RowScoreModel[] rowScoreModels, SolutionModel solution)
        {
            rowModelArray = rowModels;
            rowScoreModelArray = rowScoreModels;
            solutionModel = solution;
            for (int i = 0; i < 10; i++)
            {
                rowModelArray[i].RowNr = i;
                rowScoreModelArray[i].RowNr = i;
            }
            currentRow = 0;
            rowModelArray[currentRow].BackgroundColor = "SlateGray";
            rowModelArray[currentRow].CurrentRow = true;
            new XmlHelper();
        }

        public static void ChangeColor(string spot, int value)
        {
            switch (spot)
            {
                case "0":
                    rowModelArray[currentRow].Spot0 = value;
                    break;
                case "1":
                    rowModelArray[currentRow].Spot1 = value;
                    break;
                case "2":
                    rowModelArray[currentRow].Spot2 = value;
                    break;
                case "3":
                    rowModelArray[currentRow].Spot3 = value;
                    break;
                default:
                    break;
            }
        }

        private static Boolean CorrectSpotAndColor(int spot)
        {
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
                    rowScoreModelArray[currentRow].ChangeValue(i, 5);
                }
                else
                {
                    rowScoreModelArray[currentRow].ChangeValue(i, 6);
                }
            }

            if (correctSpotAndColor == 4)
            {
                solutionModel.Spot0 = solutionModel.internalSolution[0];
                solutionModel.Spot1 = solutionModel.internalSolution[1];
                solutionModel.Spot2 = solutionModel.internalSolution[2];
                solutionModel.Spot3 = solutionModel.internalSolution[3];
                rowModelArray[currentRow].CurrentRow = false;
            }
            else
            {
                rowModelArray[currentRow].BackgroundColor = "DarkGray";
                rowModelArray[currentRow].CurrentRow = false;
                currentRow = currentRow + 1;
                rowModelArray[currentRow].BackgroundColor = "SlateGray";
                rowModelArray[currentRow].CurrentRow = true;
            }

            //AI.NextAIMove();
        }

    }
}
