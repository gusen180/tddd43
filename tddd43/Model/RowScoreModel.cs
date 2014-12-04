using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace tddd43 {
    class RowScoreModel : INotifyPropertyChanged {

        public event PropertyChangedEventHandler PropertyChanged;

        public int[] rowScoreArray = new int[4];

        public int Spot0
        {
            get { return rowScoreArray[0]; }
            set { rowScoreArray[0] = value; OnPropertyChanged("spot0"); }
        }

        public int Spot1
        {
            get { return rowScoreArray[1]; }
            set { rowScoreArray[1] = value; OnPropertyChanged("spot1"); }
        }

        public int Spot2
        {
            get { return rowScoreArray[2]; }
            set { rowScoreArray[2] = value; OnPropertyChanged("spot2"); }
        }

        public int Spot3
        {
            get { return rowScoreArray[3]; }
            set { rowScoreArray[3] = value; OnPropertyChanged("spot3"); }
        }

        public RowScoreModel() {
            Spot0 = 8;
            Spot1 = 8;
            Spot2 = 8;
            Spot3 = 8;
        }

        public void ChangeColor(int index, int value) {
            switch (index) {
                case 0:
                    Spot0 = value;
                    break;
                case 1:
                    Spot1 = value;
                    break;
                case 2:
                    Spot2 = value;
                    break;
                case 3:
                    Spot3 = value;
                    break;
                default:
                    break;
            }
        }

        protected void OnPropertyChanged(string name) {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }
    }
}
