using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media;

namespace tddd43.Helpers {
    public class ConverterStringToBrush : IValueConverter{
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture) {
            return new BrushConverter().ConvertFromString((string)value) as Brush;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture) {
            return 0;
        }
    }
}
