using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Xml.Linq;

namespace tddd43 {
    class SolutionModel : INotifyPropertyChanged {

        public event PropertyChangedEventHandler PropertyChanged;

        public int[] solution = new int[4];
        public int[] internalSolution = new int[4];
        
        private bool solved = false;

        public bool Solved
        {
            get { return solved; }
            set { solved = value; }
        }


        public int Spot0 {
            get { return solution[0]; }
            set
            {
                solution[0] = value; OnPropertyChanged("spot0");
                XElement xEle = XElement.Load("XmlData.xml");
                var spot = xEle.Descendants("Solution").Descendants("Spot0").ElementAt(0);
                spot.ReplaceNodes(internalSolution[0]);
                xEle.Save("XmlData.xml");
            }
        }

        public int Spot1
        {
            get { return solution[1]; }
            set
            {
                solution[1] = value; OnPropertyChanged("spot1");
                XElement xEle = XElement.Load("XmlData.xml");
                var spot = xEle.Descendants("Solution").Descendants("Spot1").ElementAt(0);
                spot.ReplaceNodes(internalSolution[1]);
                xEle.Save("XmlData.xml");
            }
        }

        public int Spot2
        {
            get { return solution[2]; }
            set
            {
                solution[2] = value; OnPropertyChanged("spot2");
                XElement xEle = XElement.Load("XmlData.xml");
                var spot = xEle.Descendants("Solution").Descendants("Spot2").ElementAt(0);
                spot.ReplaceNodes(internalSolution[2]);
                xEle.Save("XmlData.xml");
            }
        }

        public int Spot3
        {
            get { return solution[3]; }
            set
            {
                solution[3] = value; OnPropertyChanged("spot3");
                XElement xEle = XElement.Load("XmlData.xml");
                var spot = xEle.Descendants("Solution").Descendants("Spot3").ElementAt(0);
                spot.ReplaceNodes(internalSolution[3]);
                xEle.Save("XmlData.xml");
            }
        }

        public SolutionModel() {
        }

        public void CreateSolution()
        {
            Random rnd = new Random();
            internalSolution[0] = rnd.Next(6);
            internalSolution[1] = rnd.Next(6);
            internalSolution[2] = rnd.Next(6);
            internalSolution[3] = rnd.Next(6);
            Spot0 = 6;
            Spot1 = 6;
            Spot2 = 6;
            Spot3 = 6;
        }

        public void LoadSolution(XElement xEle)
        {
            var solutionData = xEle.Descendants("Solution");
            internalSolution[0] = Convert.ToInt32(solutionData.Descendants("Spot0").First().Value);
            internalSolution[1] = Convert.ToInt32(solutionData.Descendants("Spot1").First().Value);
            internalSolution[2] = Convert.ToInt32(solutionData.Descendants("Spot2").First().Value);
            internalSolution[3] = Convert.ToInt32(solutionData.Descendants("Spot3").First().Value);
            Spot0 = 6;
            Spot1 = 6;
            Spot2 = 6;
            Spot3 = 6;
        }

        protected void OnPropertyChanged(string name) {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }

    }
}