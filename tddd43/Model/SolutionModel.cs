using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace tddd43 {
    class SolutionModel : INotifyPropertyChanged {

        public event PropertyChangedEventHandler PropertyChanged;

        public string[] solution = new string[4];
        public string[] internalSolution = new string[4];

        public string Spot0 {
            get { return solution[0]; }
            set { solution[0] = value; OnPropertyChanged("spot0"); }
        }

        public string Spot1
        {
            get { return solution[1]; }
            set { solution[1] = value; OnPropertyChanged("spot1"); }
        }

        public string Spot2
        {
            get { return solution[2]; }
            set { solution[2] = value; OnPropertyChanged("spot2"); }
        }

        public string Spot3
        {
            get { return solution[3]; }
            set { solution[3] = value; OnPropertyChanged("spot3"); }
        }

        public SolutionModel() {
            Spot0 = "White";
            Spot1 = "White";
            Spot2 = "White";
            Spot3 = "White";
            internalSolution[0] = "Blue";
            internalSolution[1] = "Blue";
            internalSolution[2] = "Green";
            internalSolution[3] = "Yellow";
        }

        protected void OnPropertyChanged(string name) {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }

    }
}