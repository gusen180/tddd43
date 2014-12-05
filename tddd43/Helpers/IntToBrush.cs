using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media;

namespace tddd43.Helpers {
    public class IntToBrush : IValueConverter {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture) {
            int? intValue = value as int?;
            switch (intValue) {
                case 0:
                    return Brushes.Blue;
                case 1:
                    return Brushes.Yellow;
                case 2:
                    return Brushes.Green;
                case 3:
                    return Brushes.Purple;
                case 4:
                    return Brushes.Aqua;
                case 5:
                    return Brushes.Red;
                case 6:
                    return Brushes.White;
                case 7:
                    return Brushes.Gray;
                case 8:
                    return Brushes.Black;
                default:
                    return Brushes.Gray;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture) {
            return 0;
        }
    }
}
