using PL.cart;
using PL.customer;
using PL.orders;
using PL.products;
using PL.Simulator;
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
            startManager.Visibility = Visibility.Visible;
            startCustomer.Visibility = Visibility.Visible;
            managerLogin.Visibility = Visibility.Collapsed;
            shortToCart.Visibility = Visibility.Collapsed;
            returnCustomer.Visibility = Visibility.Collapsed;
            returnManager.Visibility = Visibility.Collapsed;

        }
        public void customer_Click(object o, RoutedEventArgs e)
        {
            startManager.Visibility = Visibility.Hidden;
            startCustomer.Visibility = Visibility.Hidden;
            managerLogin.Visibility = Visibility.Hidden;
            frame.Content = new MainCustomer(this, my_cart);

        }
  

        public void manager_Click(object o, RoutedEventArgs e)
        {
          

            startManager.Visibility=Visibility.Hidden;
            startCustomer.Visibility = Visibility.Hidden;
            managerLogin.Visibility=Visibility.Visible;
          
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
                managerLogin.Visibility = Visibility.Hidden;
                frame.Content = new MainManager(this);
                password.Password = "";
            }
            else
            {
                worngPassword.Visibility = Visibility.Visible;
                password.Clear();
            }


        }
   
        public void returnToTheMainWindow_Click(object o, RoutedEventArgs e)
        {
            frame.Content = null;
            return_back(o, e);
        }



        private void shortToCart_Click(object sender, RoutedEventArgs e)
        {
            frame.Content = new cartListPage(my_cart, this);
            return_back(sender, e);
        }

        private void returnToCustomerPage_Click(object sender, RoutedEventArgs e)
        {
           frame.Content=new MainCustomer(this,my_cart);
        }

        private void returnToManagerPage_Click(object sender, RoutedEventArgs e)
        {
            frame.Content = new MainManager(this);

        }
        private void simulator_Click(object sender, RoutedEventArgs e)
        {
            
        }
    }
}
