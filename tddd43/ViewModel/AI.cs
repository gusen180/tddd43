using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using tddd43.Helpers;

namespace tddd43.ViewModel
{

    class AI
    {

        // AI,   http://sartak.org/nh/mastermind.html

        public static int currentRow;
        public static RowModel[] rowModelArray;
        public static RowScoreModel[] rowScoreModelArray;
        public static List<int[]> possibilities;
        public static int[] guess;

        public AI(bool load){
            currentRow = Game.currentRow;
            rowModelArray = Game.rowModelArray;
            rowScoreModelArray = Game.rowScoreModelArray;
            possibilities = new List<int[]>();
            if (load)
            {
                XElement xEle = XElement.Load("AiXml.xml");
                IEnumerable<XElement> combinations = xEle.Elements();
                foreach (var combination in combinations){
                    int[] temp = new int[4];
                    temp[0] = Convert.ToInt32(combination.Attribute("Spot0").Value);
                    temp[1] = Convert.ToInt32(combination.Attribute("Spot1").Value);
                    temp[2] = Convert.ToInt32(combination.Attribute("Spot2").Value);
                    temp[3] = Convert.ToInt32(combination.Attribute("Spot3").Value);
                    possibilities.Add(temp);
                }
            }
            else { 
                for (int i = 0; i < 6; i++)
                {
                    for (int j = 0; j < 6; j++)
                    {
                        for (int k = 5; k >= 0; k--)
                        {
                            for (int l = 5; l >= 0; l--)
                            {
                                possibilities.Add(new int[] { i, j, k, l });
                            }
                        }
                    }
                }
                new AiXml(possibilities);
                possibilities.RemoveAt(24);
            }
            NextAIMove();
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
            if (possibilities.Count() > 0) { 
                guess = possibilities[0];
                possibilities.RemoveAt(0);
                rowModelArray[currentRow].Spot0 = guess[0];
                rowModelArray[currentRow].Spot1 = guess[1];
                rowModelArray[currentRow].Spot2 = guess[2];
                rowModelArray[currentRow].Spot3 = guess[3];

                Game.CheckGuess();

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
                AiXml.UpdateData(possibilities);
                Console.WriteLine(possibilities.Count());
                currentRow = currentRow + 1;
            }
        }
    }
}
