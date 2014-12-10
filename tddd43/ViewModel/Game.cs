using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
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
            if (loadGame)
            {
                LoadFromXml();
            }
            else
            {
                new XmlHelper();
                solutionModel.CreateSolution();
                currentRow = 0;
                rowModelArray[currentRow].CurrentRow = true;
            }

            watcher = new FileSystemWatcher();
            watcher.Path = System.Environment.CurrentDirectory;
            watcher.NotifyFilter = NotifyFilters.LastAccess;
            watcher.Filter = "XmlData.xml";
            watcher.Changed += new FileSystemEventHandler(OnChanged);
            watcher.EnableRaisingEvents = true;
        }

        private void OnChanged(object sender, FileSystemEventArgs e)
        {
            Console.WriteLine("OnChnaged");
            LoadFromXml();
        }

        public static void UpdateXmlInt(string type, string spot, int updateValue)
        {
            watcher.EnableRaisingEvents = false;
            XElement xEle = XElement.Load("XmlData.xml");
            switch (type)
            {
                case "row":
                    var spotToUpdate = xEle.Descendants("Rows").Descendants("Row").Descendants(spot).ElementAt(currentRow);
                    spotToUpdate.ReplaceNodes(updateValue);
                    break;
                case "score":
                    var scoreToUpdate = xEle.Descendants("Rows").Descendants("Row").Descendants(spot).ElementAt(currentRow);
                    scoreToUpdate.ReplaceNodes(updateValue);
                    break;
                case "solution":
                    var solutionToUpdate = xEle.Descendants("Solution").Descendants(spot).ElementAt(0);
                    solutionToUpdate.ReplaceNodes(updateValue);
                    break;
                default:
                    break;
            }
            xEle.Save("XmlData.xml");
            watcher.EnableRaisingEvents = true;
        }

        public static void UpdateXmlBool(bool updateValue)
        {
            XElement xEle = XElement.Load("XmlData.xml");
            var spotToUpdate = xEle.Descendants("Rows").Descendants("Row").Descendants("CurrentRow").ElementAt(currentRow);
            spotToUpdate.ReplaceNodes(updateValue);
            xEle.Save("XmlData.xml");
        }

        public static void LoadFromXml()
        {
            XElement xEle = XElement.Load("XmlData.xml");
            var rowData = xEle.Descendants("Rows").Descendants("Row");
            for (int i = 0; i < 10; i++ )
            {
                rowModelArray[i].CurrentRow = Convert.ToBoolean(rowData.Descendants("CurrentRow").ElementAt(rowModelArray[i].RowNr).Value);
                if (rowModelArray[i].CurrentRow)
                {
                    currentRow = Convert.ToInt32(rowData.Descendants("RowNr").ElementAt(rowModelArray[i].RowNr).Value);
                }
                rowModelArray[i].Spot0 = Convert.ToInt32(rowData.Descendants("Spot0").ElementAt(rowModelArray[i].RowNr).Value);
                rowModelArray[i].Spot1 = Convert.ToInt32(rowData.Descendants("Spot1").ElementAt(rowModelArray[i].RowNr).Value);
                rowModelArray[i].Spot2 = Convert.ToInt32(rowData.Descendants("Spot2").ElementAt(rowModelArray[i].RowNr).Value);
                rowModelArray[i].Spot3 = Convert.ToInt32(rowData.Descendants("Spot3").ElementAt(rowModelArray[i].RowNr).Value);
                rowScoreModelArray[i].Spot0 = Convert.ToInt32(rowData.Descendants("Score0").ElementAt(rowModelArray[i].RowNr).Value);
                rowScoreModelArray[i].Spot1 = Convert.ToInt32(rowData.Descendants("Score1").ElementAt(rowModelArray[i].RowNr).Value);
                rowScoreModelArray[i].Spot2 = Convert.ToInt32(rowData.Descendants("Score2").ElementAt(rowModelArray[i].RowNr).Value);
                rowScoreModelArray[i].Spot3 = Convert.ToInt32(rowData.Descendants("Score3").ElementAt(rowModelArray[i].RowNr).Value);
            }
            solutionModel.LoadSolution(xEle);
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
                rowModelArray[currentRow].CurrentRow = false;
                currentRow = currentRow + 1;
                rowModelArray[currentRow].CurrentRow = true;
            }
        }

    }
}
