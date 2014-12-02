using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace tddd43 {
    class RowModel : INotifyPropertyChanged {

        public event PropertyChangedEventHandler PropertyChanged;

        public string[] rowArray = new string[4];

        //public Brush spot0;

        public string Spot0
        {
            get { return rowArray[0]; }
            set { rowArray[0] = value; OnPropertyChanged("spot0"); }
        }
        
        //private Brush spot1;

        public string Spot1
        {
            get { return rowArray[1]; }
            set { rowArray[1] = value; OnPropertyChanged("spot1"); }
        }

        //private Brush spot2;

        public string Spot2
        {
            get { return rowArray[2]; }
            set { rowArray[2] = value; OnPropertyChanged("spot2"); }
        }

        //private Brush spot3;

        public string Spot3
        {
            get { return rowArray[3]; }
            set { rowArray[3] = value; OnPropertyChanged("spot3"); }
        }

        private string backgroundColor;

        public string BackgroundColor {
            get { return backgroundColor; }
            set { backgroundColor = value; OnPropertyChanged("backgroundColor"); }
        }

        private bool currentRow;

        public bool CurrentRow {
            get { return currentRow; }
            set { currentRow = value; OnPropertyChanged("currentRow"); }
        }


        public RowModel() {
            Spot0 = "Gray";
            Spot1 = "Gray";
            Spot2 = "Gray";
            Spot3 = "Gray";
            backgroundColor = "DarkGray";
            currentRow = false;
        }

        protected void OnPropertyChanged(string name)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }
        
    }
}
