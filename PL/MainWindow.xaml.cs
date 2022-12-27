using BlImplementation;
using Microsoft.VisualBasic;
using PL.customer;
using PL.orders;
using PL.products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Security.Cryptography.X509Certificates;
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
        private BLApi.IBl? bl = BLApi.Factory.Get();
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
            password.Visibility = Visibility.Hidden;
            enter_password.Visibility = Visibility.Hidden;
            confirm.Visibility = Visibility.Hidden;
            products.Visibility = Visibility.Hidden;
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
            customerProductListWindow productListCustomer = new customerProductListWindow();
            productListCustomer.Show();
        }
        public void cart_Click(object o, RoutedEventArgs e)
        {
            MessageBox.Show("?עוד לא עשינו, איך יהיה", "");
            MessageBox.Show("?מה, יפול מהשמיים", "");
            MessageBox.Show(" ככה זה בחיים", "");
            MessageBox.Show(" צריך לעבוד קשה", "");
            MessageBox.Show("דברים לא באים בקלות", "");
            //MessageBox.Show("גם למוצלחות כמוך", "");

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
            //SecureString? Password =null;
            //const string truePassword = "123456";
            //password.DataContext = Password;
            //SecureString s = enter_password.SecurePassword;
            //if (s == truePassword)
            //    MessageBox.Show("סיסמא נכונה", "");
            password.Visibility = Visibility.Hidden;
            enter_password.Visibility = Visibility.Hidden;
            confirm.Visibility = Visibility.Hidden;
            products.Visibility = Visibility.Visible;
            orders.Visibility = Visibility.Visible;

        }
        public void products_Click(object o, RoutedEventArgs e)
        {
            productListWindow productListManager = new productListWindow();
            productListManager.Show();
        }
        public void orders_Click(object o, RoutedEventArgs e)
        {
            orderListWindow orderListManager = new orderListWindow();
            orderListManager.Show();
            
        }
    }
}
