using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media;

namespace tddd43.Helpers {
    public class BoolToBrush : IValueConverter {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture) {
            bool? boolValue = value as bool?;
            if (boolValue == true)
            {
                return Brushes.SlateGray;
            }
            else
            {
                return Brushes.DarkGray;
            }
            
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture) {
            return 0;
        }
    }
}
