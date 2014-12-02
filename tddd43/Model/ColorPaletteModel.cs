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
        private string yellow;

        public string Yellow
        {
            get { return yellow; }
            set { yellow = value; }
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
        private string aqua;

        public string Aqua
        {
            get { return aqua; }
            set { aqua = value; }
        }
        private string lightBlue;

        public string LightBlue
        {
            get { return lightBlue; }
            set { lightBlue = value; }
        }

        public ColorPaletteModel()
        {
            Blue = "Blue";
            Red = "Red";
            Green = "Green";
            Yellow = "Yellow";
            Purple = "Purple";
            Brown = "Brown";
            Aqua = "Aqua";
            LightBlue = "LightBlue";
        }

    }
}
