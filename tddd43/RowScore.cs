using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace tddd43 {
    class RowScore {
        private SolidColorBrush spot0;

        public SolidColorBrush Spot0 {
            get { return spot0; }
            set { spot0 = value; }
        }
        private SolidColorBrush spot1;

        public SolidColorBrush Spot1 {
            get { return spot1; }
            set { spot1 = value; }
        }
        private SolidColorBrush spot2;

        public SolidColorBrush Spot2 {
            get { return spot2; }
            set { spot2 = value; }
        }
        private SolidColorBrush spot3;

        public SolidColorBrush Spot3 {
            get { return spot3; }
            set { spot3 = value; }
        }

        public RowScore() {
            spot0 = Brushes.Black;
            spot1 = Brushes.Black;
            spot2 = Brushes.Black;
            spot3 = Brushes.Black;
        }
    }
}
