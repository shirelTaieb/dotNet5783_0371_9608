using BlImplementation;
using Microsoft.VisualBasic;
using PL.orders;
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
          

        }
       
        //public void mouseEnter(object o, RoutedEventArgs e)
        //{
        //    OpenProductList.Width = 400;
        //}
        //public void mouseLeave(object o, RoutedEventArgs e)
        //{
        //    OpenProductList.Width = 200;
        //}
        public void return_back(object o, RoutedEventArgs e)
        {
            customer.IsEnabled = true;
            manager.IsEnabled = true;
            katelog.Visibility = Visibility.Hidden;
            cart.Visibility = Visibility.Hidden;
            password.Visibility = Visibility.Hidden;
            enter_password.Visibility = Visibility.Hidden;
            confirm.Visibility = Visibility.Hidden;
            addProduct.Visibility = Visibility.Hidden;
            updateProduct.Visibility = Visibility.Hidden;
            orders.Visibility = Visibility.Hidden;
        }
        public void customer_Click(object o, RoutedEventArgs e)
        {
            //MainCustomer mainCustomer = new MainCustomer();
            //mainCustomer.Show();
            //this.Close();
            return_back(o,e);
            customer.IsEnabled =false;
            katelog.Visibility = Visibility.Visible;
            cart.Visibility = Visibility.Visible;
        }
        public void Katelog_Click(object o, RoutedEventArgs e)
        {
            productListWindow productList = new productListWindow(bl);
            productList.Show();
        }
        public void manager_Click(object o, RoutedEventArgs e)
        {
            return_back(o, e);
            manager.IsEnabled = false;
            password.Visibility = Visibility.Visible;
            enter_password.Visibility = Visibility.Visible;
            confirm.Visibility = Visibility.Visible;

        }
        public void check_password(object o, RoutedEventArgs e)
        {
            //const string truePassword = "123456";
            //if ((string)enter_password.DataContext == truePassword)
            //    MessageBox.Show("סיסמא נכונה", "");
            password.Visibility = Visibility.Hidden;
            enter_password.Visibility = Visibility.Hidden;
            confirm.Visibility = Visibility.Hidden;
            addProduct.Visibility = Visibility.Visible;
            updateProduct.Visibility = Visibility.Visible;
            orders.Visibility = Visibility.Visible;

        }
        public void addProduct_Click(object o, RoutedEventArgs e)
        {
            productWindow add = new productWindow(bl);
            add.Show();
        }
        public void updateProduct_Click(object o, RoutedEventArgs e)
        {
            productWindow update = new productWindow(bl);
            update.Show();
        }
        public void orders_Click(object o, RoutedEventArgs e)
        {
            orderListWindow newOrderList = new orderListWindow(bl);
            newOrderList.Show();
        }
    }
}
