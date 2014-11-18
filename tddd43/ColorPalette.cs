using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace tddd43 {
    class ColorPalette {
        private SolidColorBrush color;

        public SolidColorBrush Color {
            get { return color; }
            set { color = value; }
        }

        public ColorPalette() {
            return;
        }
    }
}
