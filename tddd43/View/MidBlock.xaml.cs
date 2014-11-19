using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using tddd43.ViewModel;

namespace tddd43
{
    /// <summary>
    /// Interaction logic for MidBlock.xaml
    /// </summary>
    public partial class MidBlock : UserControl
    {
        public MidBlock()
        {
            this.DataContext = new RowModel();
            InitializeComponent();
        }

        private void Ellipse_Drop(object sender, DragEventArgs e)
        {
            Game.Drop(sender, e, this);
        }
    }
}
