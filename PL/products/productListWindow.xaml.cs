using BLApi;
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
using System.Windows.Shapes;

namespace PL.products
{
    /// <summary>
    /// Interaction logic for productListWindow.xaml
    /// </summary>
    public partial class productListWindow : Window
    {
        public productListWindow(IBl? bl)
        {
            InitializeComponent();
            var list= bl!.Product!.getListOfProduct();
            DataContext = list;
        }

        private void price_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            MessageBox.Show("סיננת לפי מחיר", "");
        }

        private void category_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
