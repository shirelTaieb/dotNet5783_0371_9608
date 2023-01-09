using PL.cart;
using PL.customer;
using PL.orders;
using PL.products;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
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
            customer.IsEnabled = true;
            manager.IsEnabled = true;
            katelog.Visibility = Visibility.Hidden;
            cart.Visibility = Visibility.Hidden;
            products.Visibility = Visibility.Hidden;
         
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
         

        }
        public void cart_Click(object o, RoutedEventArgs e)
        {
     
            frame.Content = frame.Content = new cartListPage(my_cart,this);
            return_back(o, e);
            customer.Visibility = Visibility.Hidden;
            

        }

        public void manager_Click(object o, RoutedEventArgs e)
        {
            return_back(o, e);
            manager.IsEnabled = false;
            password.Visibility = Visibility.Visible;
          

        }
        private void pressEnter(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
                check_password(sender, e);
        }
        
        public void check_password(object o, RoutedEventArgs e)
        {
            worngPassword.Visibility = Visibility.Hidden;
            if (password.Password == "1234")
            {
                password.Visibility = Visibility.Hidden;
                products.Visibility = Visibility.Visible;
                password.Password = "";
                managerTrack.Visibility = Visibility.Visible;
            }
            else
            {
                worngPassword.Visibility = Visibility.Visible;
                password.Clear();
            }


        }
        public void products_Click(object o, RoutedEventArgs e)
        {
         
            frame.Content = new ProductListPage();
            return_back(o, e);
            customer.Visibility = Visibility.Hidden;


        }
        public void orders_Click(object o, RoutedEventArgs e)
        {
         
            frame.Content = new orderListPage();
            return_back(o, e);
            customer.Visibility = Visibility.Hidden;
       
        }
        public void returnToTheMainWindow_Click(object o, RoutedEventArgs e)
        {
            frame.Content = null;
            return_back(o, e);
        }

        private void ManagerTrack_Click(object sender, RoutedEventArgs e)
        {
            EnterIdForTrackingWindow enterID = new EnterIdForTrackingWindow(0);
            enterID.Show();
        }
        private void CustomerTrack_Click(object sender, RoutedEventArgs e)
        {
            EnterIdForTrackingWindow enterID = new EnterIdForTrackingWindow(1);
            enterID.Show();
        }
        
    }
}
