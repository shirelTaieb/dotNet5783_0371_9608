using BlImplementation;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PL
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        BLApi.IBl? bl = BLApi.Factory.Get();
        public MainWindow()
        {
            InitializeComponent();
            productWindow products = new productWindow(bl);
            //products.Show();
            
        }
       
        //public void mouseEnter(object o, RoutedEventArgs e)
        //{
        //    OpenProductList.Width = 400;
        //}
        //public void mouseLeave(object o, RoutedEventArgs e)
        //{
        //    OpenProductList.Width = 200;
        //}
        public void customer_Click(object o, RoutedEventArgs e)
        {
            MainCustomer mainCustomer = new MainCustomer();
            mainCustomer.Show();
            this.Close();
        }
        public void manager_Click(object o, RoutedEventArgs e)
        {

        }
    }
}
