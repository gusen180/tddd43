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

        public Brush[] rowArray = new Brush[4];

        public Brush spot0;

        public Brush Spot0
        {
            get { return spot0; }
            set { spot0 = value; rowArray[0] = value; OnPropertyChanged("spot0"); }
        }
        private Brush spot1;

        public Brush Spot1
        {
            get { return spot1; }
            set { spot1 = value; rowArray[1] = value; OnPropertyChanged("spot1"); }
        }
        private Brush spot2;

        public Brush Spot2
        {
            get { return spot2; }
            set { spot2 = value; rowArray[2] = value; OnPropertyChanged("spot2"); }
        }
        private Brush spot3;

        public Brush Spot3
        {
            get { return spot3; }
            set { spot3 = value; rowArray[3] = value; OnPropertyChanged("spot3"); }
        }

        private Brush backgroundColor;

        public Brush BackgroundColor {
            get { return backgroundColor; }
            set { backgroundColor = value; OnPropertyChanged("backgroundColor"); }
        }

        private String allowDrop;

        public String AllowDrop {
            get { return allowDrop; }
            set { allowDrop = value; OnPropertyChanged("allowDrop"); }
        }


        public RowModel() {
            spot0 = Brushes.Gray;
            spot1 = Brushes.Gray;
            spot2 = Brushes.Gray;
            spot3 = Brushes.Gray;
            rowArray[0] = spot0;
            rowArray[1] = spot1;
            rowArray[2] = spot2;
            rowArray[3] = spot3;
            backgroundColor = Brushes.DarkGray;
            allowDrop = "False";
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
