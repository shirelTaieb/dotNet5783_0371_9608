using PL.cart;
using PL.customer;
using PL.orders;
using PL.products;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Media3D;

namespace PL
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private BLApi.IBl? bl = BLApi.Factory.Get();
        BO.Cart my_cart = new BO.Cart();
        public MainWindow()
        {
            InitializeComponent();

        }


        public void return_back(object o, RoutedEventArgs e)
        {
            customer.Visibility = Visibility.Visible;
            manager.Visibility = Visibility.Visible;
            customer.IsEnabled = true;
            manager.IsEnabled = true;
            katelog.Visibility = Visibility.Hidden;
            cart.Visibility = Visibility.Hidden;
            products.Visibility = Visibility.Hidden;
            orders.Visibility = Visibility.Hidden;
        }
        public void customer_Click(object o, RoutedEventArgs e)
        {

            return_back(o, e);
            customer.IsEnabled = false;
            katelog.Visibility = Visibility.Visible;
            cart.Visibility = Visibility.Visible;

        }
        public void Katelog_Click(object o, RoutedEventArgs e)
        {
            frame.Content = new customerListPage(my_cart);
            return_back(o, e);
            customer.Visibility = Visibility.Hidden;
            manager.Visibility = Visibility.Hidden;

        }
        public void cart_Click(object o, RoutedEventArgs e)
        {
     
            frame.Content = frame.Content = new cartListPage(my_cart);
            return_back(o, e);
            customer.Visibility = Visibility.Hidden;
            manager.Visibility = Visibility.Hidden;

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
            
            password.Visibility = Visibility.Hidden;
            products.Visibility = Visibility.Visible;
            orders.Visibility = Visibility.Visible;

        }
        public void products_Click(object o, RoutedEventArgs e)
        {
         
            frame.Content = new ProductListPage();
            return_back(o, e);
            customer.Visibility = Visibility.Hidden;
            manager.Visibility = Visibility.Hidden;
            //managerImage.Visibility = Visibility.Hidden;
            //cartImage.Visibility = Visibility.Hidden;

        }
        public void orders_Click(object o, RoutedEventArgs e)
        {
         
            frame.Content = new orderListPage();
            return_back(o, e);
            customer.Visibility = Visibility.Hidden;
            manager.Visibility = Visibility.Hidden;
            //managerImage.Visibility = Visibility.Hidden;
            //cartImage.Visibility = Visibility.Hidden;
        }
        public void returnToTheMainWindow_Click(object o, RoutedEventArgs e)
        {
            frame.Content = null;
            return_back(o, e);
        }

        
    }
}
