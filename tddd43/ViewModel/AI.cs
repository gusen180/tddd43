using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tddd43.ViewModel
{

    class AI
    {

        // AI,   http://sartak.org/nh/mastermind.html

        public static int currentRow;
        public static RowModel[] rowModelArray;
        public static RowScoreModel[] rowScoreModelArray;
        public static List<int[]> possibilities;
        public static int[] guess = new int[4]{0,0,1,1};

        public AI(){
            currentRow = Game.currentRow;
            rowModelArray = Game.rowModelArray;
            rowScoreModelArray = Game.rowScoreModelArray;
            possibilities = new List<int[]>();
            for (int i = 0; i < 6; i++)
            {
                for (int j = 0; j < 6; j++)
                {
                    for (int k = 0; k < 6; k++)
                    {
                        for (int l = 0; l < 6; l++)
                        {
                            possibilities.Add(new int[] { i, j, k, l });
                        }
                    }
                }
            }
        }

        private static Boolean CorrectSpotAndColor(int[] possible, int spot)
        {
            return possible[spot] == guess[spot];
        }

        private static Boolean CorrectColor(int[] possible, int spot, Boolean[] spotsUsedSolution)
        {
            for (int i = 0; i < 4; i++)
            {
                if (possible[spot] == guess[i] && !spotsUsedSolution[i])
                {
                    spotsUsedSolution[i] = true;
                    return true;
                }
            }
            return false;
        }

        public static bool StillPossible(int[] possible, int correctSpotAndColor, int correctColor)
        {
            Boolean[] spotsUsedGuess = new Boolean[4] { false, false, false, false };
            Boolean[] spotsUsedSolution = new Boolean[4] { false, false, false, false };
            int possibleCorrectSpotAndColor = 0;
            int possibleCorrectColor = 0;
            for (int i = 0; i < 4; i++)
            {
                if (CorrectSpotAndColor(possible, i))
                {
                    possibleCorrectSpotAndColor = possibleCorrectSpotAndColor + 1;
                    spotsUsedGuess[i] = true;
                    spotsUsedSolution[i] = true;
                }
            }
            for (int i = 0; i < 4; i++)
            {
                if (!spotsUsedGuess[i] && CorrectColor(possible, i, spotsUsedSolution))
                {
                    possibleCorrectColor = possibleCorrectColor + 1;
                    spotsUsedGuess[i] = true;
                }
            }
            return correctSpotAndColor == possibleCorrectSpotAndColor && correctColor == possibleCorrectColor;
        }

        public static void NextAIMove()
        {
            if (currentRow != 0)
            {
                guess = possibilities[0];
                possibilities.RemoveAt(0);
                //skicka till game här
            }
            else
            {
                //skicka till game här
            }
            int correctSpotAndColor = 0;
            int correctColor = 0;
            for (int i = 0; i < 4; i++){
                if (rowScoreModelArray[currentRow].rowScoreArray[i] == 5)
                {
                    correctSpotAndColor = correctSpotAndColor + 1;
                }
                else if (rowScoreModelArray[currentRow].rowScoreArray[i] == 6)
                {
                    correctColor = correctColor + 1;
                }
            }
            
            for (int i = possibilities.Count() - 1; i >= 0; i--)
            {
                if (!StillPossible(possibilities[i], correctSpotAndColor, correctColor))
                {
                    possibilities.RemoveAt(i);
                }
            }
            currentRow = currentRow + 1;
            Console.WriteLine(possibilities[0][0]);
            Console.WriteLine(possibilities[0][1]);
            Console.WriteLine(possibilities[0][2]);
            Console.WriteLine(possibilities[0][3]);
            Console.WriteLine(possibilities.Count());
        }
    }
}
