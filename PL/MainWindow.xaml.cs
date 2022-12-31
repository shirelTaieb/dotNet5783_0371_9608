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
            customerProductListWindow productListCustomer = new customerProductListWindow(my_cart);
            productListCustomer.Show();
        }
        public void cart_Click(object o, RoutedEventArgs e)
        {
            //MessageBox.Show("?עוד לא עשינו, איך יהיה", "");
            //MessageBox.Show("?מה, יפול מהשמיים", "");
            //MessageBox.Show(" ככה זה בחיים", "");
            //MessageBox.Show(" צריך לעבוד קשה", "");
            //MessageBox.Show("דברים לא באים בקלות", "");
            //MessageBox.Show("גם למוצלחות כמוך", "");
            cartWindow myCart = new cartWindow(my_cart);
            myCart.Show();


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
            productListWindow productListManager = new productListWindow();
            productListManager.Show();
            //Main.NavigationService.Navigate(new ProductListPage(this));
            //return_back(o, e);
            //customer.Visibility = Visibility.Hidden;
            //manager.Visibility = Visibility.Hidden;
            //managerImage.Visibility = Visibility.Hidden;
            //cartImage.Visibility = Visibility.Hidden;


        }
        public void orders_Click(object o, RoutedEventArgs e)
        {
            orderListWindow orderListManager = new orderListWindow();
            orderListManager.Show();

        }
        //public void GoBackToStartPage()
        //{
        //    Main.Content = this.Content;
        //}
    }
}
