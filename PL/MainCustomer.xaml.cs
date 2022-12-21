using PL.products;
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

namespace PL
{
    /// <summary>
    /// Interaction logic for MainCustomer.xaml
    /// </summary>
    public partial class MainCustomer : Window
    {
        BLApi.IBl? bl = BLApi.Factory.Get();

        public MainCustomer()
        {
            InitializeComponent();
        }
        public void Katelog_Click(object o, RoutedEventArgs e)
        {
            productListWindow productList = new productListWindow(bl);
            productList.Show();
        }
    }
}
