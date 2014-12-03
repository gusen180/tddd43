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
        private string blue;

        public string Blue
        {
            get { return blue; }
            set { blue = value; }
        }
        private string red;

        public string Red
        {
            get { return red; }
            set { red = value; }
        }
        private string green;

        public string Green
        {
            get { return green; }
            set { green = value; }
        }
        private string purple;

        public string Purple
        {
            get { return purple; }
            set { purple = value; }
        }
        private string brown;

        public string Brown
        {
            get { return brown; }
            set { brown = value; }
        }
        private string yellow;

        public string Yellow
        {
            get { return yellow; }
            set { yellow = value; }
        }


        public ColorPaletteModel()
        {
            Blue = "Blue";
            Red = "Red";
            Green = "Green";
            Purple = "Purple";
            Brown = "Brown";
            Yellow = "Yellow";
        }

    }
}
