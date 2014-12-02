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

        public string[] rowScoreArray = new string[4];

        public string Spot0
        {
            get { return rowScoreArray[0]; }
            set { rowScoreArray[0] = value; OnPropertyChanged("spot0"); }
        }

        public string Spot1
        {
            get { return rowScoreArray[1]; }
            set { rowScoreArray[1] = value; OnPropertyChanged("spot1"); }
        }

        public string Spot2
        {
            get { return rowScoreArray[2]; }
            set { rowScoreArray[2] = value; OnPropertyChanged("spot2"); }
        }

        public string Spot3
        {
            get { return rowScoreArray[3]; }
            set { rowScoreArray[3] = value; OnPropertyChanged("spot3"); }
        }

        public RowScoreModel() {
            Spot0 = "Black";
            Spot1 = "Black";
            Spot2 = "Black";
            Spot3 = "Black";
        }

        public void ChangeColor(int index, string color) {
            rowScoreArray[index] = color;
            switch (index) {
                case 0:
                    Spot0 = color;
                    break;
                case 1:
                    Spot1 = color;
                    break;
                case 2:
                    Spot2 = color;
                    break;
                case 3:
                    Spot3 = color;
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
