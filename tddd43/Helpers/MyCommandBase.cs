using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using tddd43.ViewModel;

namespace tddd43.Helpers
{
    public static class MyCommandBase
    {
        static RoutedCommand drag = new RoutedCommand("Drag", typeof(MyCommandBase));

        public static RoutedCommand Drag { get { return drag; } }


    }
}
