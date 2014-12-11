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
        private int blue;

        public int Blue
        {
            get { return blue; }
            set { blue = value; }
        }
        private int red;

        public int Red
        {
            get { return red; }
            set { red = value; }
        }
        private int green;

        public int Green
        {
            get { return green; }
            set { green = value; }
        }
        private int purple;

        public int Purple
        {
            get { return purple; }
            set { purple = value; }
        }
        private int aqua;

        public int Aqua
        {
            get { return aqua; }
            set { aqua = value; }
        }
        private int yellow;

        public int Yellow
        {
            get { return yellow; }
            set { yellow = value; }
        }


        public ColorPaletteModel()
        {
            Blue = 0;
            Yellow = 1;
            Green = 2;
            Purple = 3;
            Aqua = 4;
            Red = 5;
        }

    }
}
