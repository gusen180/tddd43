using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;
using System.Xml.Linq;
using tddd43.Helpers;

namespace tddd43.ViewModel
{
    class Game
    {
        public static int currentRow;
        public static RowModel[] rowModelArray;
        public static RowScoreModel[] rowScoreModelArray;
        public static SolutionModel solutionModel;
        public static FileSystemWatcher watcher;
        public static bool enableChange = true;
        public static DateTime lastRead = DateTime.MinValue;


        public Game(RowModel[] rowModels, RowScoreModel[] rowScoreModels, SolutionModel solution, bool loadGame = false)
        {
            rowModelArray = rowModels;
            rowScoreModelArray = rowScoreModels;
            solutionModel = solution;

            for (int i = 0; i < 10; i++)
            {
                rowModelArray[i].RowNr = i;
                rowScoreModelArray[i].RowNr = i;
            }


            watcher = new FileSystemWatcher();
            watcher.Path = System.Environment.CurrentDirectory;
            watcher.NotifyFilter = NotifyFilters.LastWrite;
            watcher.Filter = "XmlData.xml";
            watcher.Changed += new FileSystemEventHandler(OnChanged);
            watcher.EnableRaisingEvents = false;

            if (!loadGame)
            {
                new XmlHelper();
                solutionModel.CreateSolution();
                updateSolutionXml();
                currentRow = 0;
                rowModelArray[currentRow].CurrentRow = true;
            }
            else {
                LoadFromXml();
            } 
            watcher.EnableRaisingEvents = true;
        }


        private void OnChanged(object sender, FileSystemEventArgs e) {
            try {
                DateTime lastWriteTime = File.GetLastWriteTime("XmlData.xml");
                if (enableChange && lastRead != lastWriteTime) {
                    lastRead = lastWriteTime;
                    enableChange = false;
                    watcher.EnableRaisingEvents = false;
                    Console.WriteLine("OnChanged");
                    //LoadFromXml();
                }
            }

            finally {
                watcher.EnableRaisingEvents = true;
                enableChange = true;
            }
        }

        public static void LoadFromXml()
        {
            XElement xEle = XElement.Load("XmlData.xml");
            var rowData = xEle.Descendants("Rows").Descendants("Row");
            for (int i = 0; i < 10; i++ )
            {
                rowModelArray[i].CurrentRow = Convert.ToBoolean(rowData.Descendants("CurrentRow").ElementAt(i).Value);
                if (rowModelArray[i].CurrentRow)
                {
                    currentRow = Convert.ToInt32(rowData.Descendants("RowNr").ElementAt(i).Value);
                }
                rowModelArray[i].Spot0 = Convert.ToInt32(rowData.Descendants("Spot0").ElementAt(i).Value);
                rowModelArray[i].Spot1 = Convert.ToInt32(rowData.Descendants("Spot1").ElementAt(i).Value);
                rowModelArray[i].Spot2 = Convert.ToInt32(rowData.Descendants("Spot2").ElementAt(i).Value);
                rowModelArray[i].Spot3 = Convert.ToInt32(rowData.Descendants("Spot3").ElementAt(i).Value);
                rowScoreModelArray[i].Spot0 = Convert.ToInt32(rowData.Descendants("Score0").ElementAt(i).Value);
                rowScoreModelArray[i].Spot1 = Convert.ToInt32(rowData.Descendants("Score1").ElementAt(i).Value);
                rowScoreModelArray[i].Spot2 = Convert.ToInt32(rowData.Descendants("Score2").ElementAt(i).Value);
                rowScoreModelArray[i].Spot3 = Convert.ToInt32(rowData.Descendants("Score3").ElementAt(i).Value);
            }
            var solutionData = xEle.Descendants("Solution");
            solutionModel.internalSolution[0] = Convert.ToInt32(solutionData.Descendants("Spot0").First().Value);
            solutionModel.internalSolution[1] = Convert.ToInt32(solutionData.Descendants("Spot1").First().Value);
            solutionModel.internalSolution[2] = Convert.ToInt32(solutionData.Descendants("Spot2").First().Value);
            solutionModel.internalSolution[3] = Convert.ToInt32(solutionData.Descendants("Spot3").First().Value);
        }


        public static void UpdateRowModel(string spot, int value)
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

        public static void updateRowXml(bool finished)
        {
            watcher.EnableRaisingEvents = false;
            XElement xEle = XElement.Load("XmlData.xml");

            var spot0 = xEle.Descendants("Rows").Descendants("Row").Descendants("Spot0").ElementAt(currentRow);
            spot0.ReplaceNodes(rowModelArray[currentRow].Spot0);
            var spot1 = xEle.Descendants("Rows").Descendants("Row").Descendants("Spot1").ElementAt(currentRow);
            spot1.ReplaceNodes(rowModelArray[currentRow].Spot1);
            var spot2 = xEle.Descendants("Rows").Descendants("Row").Descendants("Spot2").ElementAt(currentRow);
            spot2.ReplaceNodes(rowModelArray[currentRow].Spot2);
            var spot3 = xEle.Descendants("Rows").Descendants("Row").Descendants("Spot3").ElementAt(currentRow);
            spot3.ReplaceNodes(rowModelArray[currentRow].Spot3);

            var score0 = xEle.Descendants("Rows").Descendants("Row").Descendants("Score0").ElementAt(currentRow);
            score0.ReplaceNodes(rowScoreModelArray[currentRow].Spot0);
            var score1 = xEle.Descendants("Rows").Descendants("Row").Descendants("Score1").ElementAt(currentRow);
            score1.ReplaceNodes(rowScoreModelArray[currentRow].Spot1);
            var score2 = xEle.Descendants("Rows").Descendants("Row").Descendants("Score2").ElementAt(currentRow);
            score2.ReplaceNodes(rowScoreModelArray[currentRow].Spot2);
            var score3 = xEle.Descendants("Rows").Descendants("Row").Descendants("Score3").ElementAt(currentRow);
            score3.ReplaceNodes(rowScoreModelArray[currentRow].Spot3);

            var notCurrent = xEle.Descendants("Rows").Descendants("Row").Descendants("CurrentRow").ElementAt(currentRow);
            notCurrent.ReplaceNodes(false);
            if (!finished) {
                var current = xEle.Descendants("Rows").Descendants("Row").Descendants("CurrentRow").ElementAt(currentRow + 1);
                current.ReplaceNodes(true);
            }
            xEle.Save("XmlData.xml");
            watcher.EnableRaisingEvents = true;
        }

        public static void updateSolutionXml()
        {
            watcher.EnableRaisingEvents = false;
            XElement xEle = XElement.Load("XmlData.xml");

            var spot0 = xEle.Descendants("Solution").Descendants("Spot0").ElementAt(0);
            spot0.ReplaceNodes(solutionModel.internalSolution[0]);
            var spot1 = xEle.Descendants("Solution").Descendants("Spot1").ElementAt(0);
            spot1.ReplaceNodes(solutionModel.internalSolution[1]);
            var spot2 = xEle.Descendants("Solution").Descendants("Spot2").ElementAt(0);
            spot2.ReplaceNodes(solutionModel.internalSolution[2]);
            var spot3 = xEle.Descendants("Solution").Descendants("Spot3").ElementAt(0);
            spot3.ReplaceNodes(solutionModel.internalSolution[3]);

            xEle.Save("XmlData.xml");
            watcher.EnableRaisingEvents = true;
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
                updateRowXml(true);
            }
            else
            {
                updateRowXml(false);
                rowModelArray[currentRow].CurrentRow = false;
                currentRow = currentRow + 1;
                rowModelArray[currentRow].CurrentRow = true;
            }
        }

    }
}
