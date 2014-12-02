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

        public Brush[] solution = new Brush[4];

        private int rowNr;

        public int RowNr {
            get { return rowNr; }
            set { rowNr = value; }
        }

        public Brush spot0;

        public Brush Spot0 {
            get { return spot0; }
            set { spot0 = value; OnPropertyChanged("spot0"); }
        }
        private Brush spot1;

        public Brush Spot1 {
            get { return spot1; }
            set { spot1 = value; OnPropertyChanged("spot1"); }
        }
        private Brush spot2;

        public Brush Spot2 {
            get { return spot2; }
            set { spot2 = value; OnPropertyChanged("spot2"); }
        }
        private Brush spot3;

        public Brush Spot3 {
            get { return spot3; }
            set { spot3 = value; OnPropertyChanged("spot3"); }
        }

        public SolutionModel() {
            spot0 = Brushes.White;
            spot1 = Brushes.White;
            spot2 = Brushes.White;
            spot3 = Brushes.White;
            solution[0] = Brushes.Blue;
            solution[1] = Brushes.Blue;
            solution[2] = Brushes.Green;
            solution[3] = Brushes.Yellow;
        }

        protected void OnPropertyChanged(string name) {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }

    }
}