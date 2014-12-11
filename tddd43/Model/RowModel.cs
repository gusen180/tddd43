using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Xml.Linq;
using tddd43.ViewModel;

namespace tddd43 {
    class RowModel : INotifyPropertyChanged {

        public event PropertyChangedEventHandler PropertyChanged;

        public int[] rowArray = new int[4];

        private int rowNr;

        public int RowNr
        {
            get { return rowNr; }
            set { rowNr = value; }
        }

        public int Spot0
        {
            get { return rowArray[0]; }
            set
            {
                rowArray[0] = value; OnPropertyChanged("spot0");
            }
        }
        

        public int Spot1
        {
            get { return rowArray[1]; }
            set { rowArray[1] = value; OnPropertyChanged("spot1");
            }
        }


        public int Spot2
        {
            get { return rowArray[2]; }
            set
            {
                rowArray[2] = value; OnPropertyChanged("spot2");
            }
        }


        public int Spot3
        {
            get { return rowArray[3]; }
            set
            {
                rowArray[3] = value; OnPropertyChanged("spot3");
            }
        }

        private bool currentRow;

        public bool CurrentRow {
            get { return currentRow; }
            set
            {
                currentRow = value; OnPropertyChanged("currentRow");
            }
        }


        public RowModel(bool willBeLoadedLater) {
            Spot0 = 7;
            Spot1 = 7;
            Spot2 = 7;
            Spot3 = 7;
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
