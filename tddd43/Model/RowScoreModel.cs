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

        //private SolidColorBrush spot0;
        public Brush[] rowScoreArray= new Brush[4];

        public Brush Spot0 {
            get { return rowScoreArray[0]; }
            set { rowScoreArray[0] = value; OnPropertyChanged("spot0"); }
        }
        //private Brush spot1;

        public Brush Spot1 {
            get { return rowScoreArray[1]; }
            set { rowScoreArray[1] = value; OnPropertyChanged("spot1"); }
        }
        //private Brush spot2;

        public Brush Spot2 {
            get { return rowScoreArray[2]; }
            set { rowScoreArray[2] = value; OnPropertyChanged("spot2"); }
        }
        //private Brush spot3;

        public Brush Spot3 {
            get { return rowScoreArray[3]; }
            set { rowScoreArray[3] = value; OnPropertyChanged("spot3"); }
        }

        public RowScoreModel() {
            rowScoreArray[0] = Brushes.Black;
            rowScoreArray[1] = Brushes.Black;
            rowScoreArray[2] = Brushes.Black;
            rowScoreArray[3] = Brushes.Black;
        }

        public void ChangeColor(int index, Brush color) {
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
            Console.WriteLine(index);
            Console.WriteLine(color);
        }

        protected void OnPropertyChanged(string name) {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }
    }
}
