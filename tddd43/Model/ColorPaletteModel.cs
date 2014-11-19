using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace tddd43
{
    class ColorPaletteModel
    {
        private SolidColorBrush blue;

        public SolidColorBrush Blue
        {
            get { return blue; }
            set { blue = value; }
        }
        private SolidColorBrush red;

        public SolidColorBrush Red
        {
            get { return red; }
            set { red = value; }
        }
        private SolidColorBrush green;

        public SolidColorBrush Green
        {
            get { return green; }
            set { green = value; }
        }
        private SolidColorBrush yellow;

        public SolidColorBrush Yellow
        {
            get { return yellow; }
            set { yellow = value; }
        }
        private SolidColorBrush purple;

        public SolidColorBrush Purple
        {
            get { return purple; }
            set { purple = value; }
        }
        private SolidColorBrush brown;

        public SolidColorBrush Brown
        {
            get { return brown; }
            set { brown = value; }
        }
        private SolidColorBrush aqua;

        public SolidColorBrush Aqua
        {
            get { return aqua; }
            set { aqua = value; }
        }
        private SolidColorBrush lightBlue;

        public SolidColorBrush LightBlue
        {
            get { return lightBlue; }
            set { lightBlue = value; }
        }

        public ColorPaletteModel()
        {
            Blue = Brushes.Blue;
            Red = Brushes.Red;
            Green = Brushes.Green;
            Yellow = Brushes.Yellow;
            Purple = Brushes.Purple;
            Brown = Brushes.Brown;
            Aqua = Brushes.Aqua;
            LightBlue = Brushes.LightBlue;
        }

    }
}
