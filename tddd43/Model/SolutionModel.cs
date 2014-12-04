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

        public int[] solution = new int[4];
        public int[] internalSolution = new int[4];

        public int Spot0 {
            get { return solution[0]; }
            set { solution[0] = value; OnPropertyChanged("spot0"); }
        }

        public int Spot1
        {
            get { return solution[1]; }
            set { solution[1] = value; OnPropertyChanged("spot1"); }
        }

        public int Spot2
        {
            get { return solution[2]; }
            set { solution[2] = value; OnPropertyChanged("spot2"); }
        }

        public int Spot3
        {
            get { return solution[3]; }
            set { solution[3] = value; OnPropertyChanged("spot3"); }
        }

        public SolutionModel() {
            Spot0 = 6;
            Spot1 = 6;
            Spot2 = 6;
            Spot3 = 6;
            Random rnd = new Random();
            internalSolution[0] = rnd.Next(6);
            internalSolution[1] = rnd.Next(6);
            internalSolution[2] = rnd.Next(6);
            internalSolution[3] = rnd.Next(6);
        }

        protected void OnPropertyChanged(string name) {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }

    }
}