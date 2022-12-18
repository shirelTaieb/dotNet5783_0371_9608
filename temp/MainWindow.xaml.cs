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

namespace temp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            System.Windows.Data.CollectionViewSource orderViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("orderViewSource")));
            // Load data by setting the CollectionViewSource.Source property:
            // orderViewSource.Source = [generic data source]
            System.Windows.Data.CollectionViewSource orderViewSource1 = ((System.Windows.Data.CollectionViewSource)(this.FindResource("orderViewSource1")));
            // Load data by setting the CollectionViewSource.Source property:
            // orderViewSource1.Source = [generic data source]
            System.Windows.Data.CollectionViewSource orderViewSource2 = ((System.Windows.Data.CollectionViewSource)(this.FindResource("orderViewSource2")));
            // Load data by setting the CollectionViewSource.Source property:
            // orderViewSource2.Source = [generic data source]
            System.Windows.Data.CollectionViewSource orderViewSource3 = ((System.Windows.Data.CollectionViewSource)(this.FindResource("orderViewSource3")));
            // Load data by setting the CollectionViewSource.Source property:
            // orderViewSource3.Source = [generic data source]
        }
    }
}
