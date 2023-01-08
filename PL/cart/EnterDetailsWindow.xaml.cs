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

namespace PL.cart
{
    /// <summary>
    /// Interaction logic for EnterDetailsWindow.xaml
    /// </summary>
    public partial class EnterDetailsWindow : Window
    {
        private BLApi.IBl? bl = BLApi.Factory.Get();
        PO.Cart cart=new PO.Cart();
        public EnterDetailsWindow(PO.Cart finalCart)
        {
            InitializeComponent();

            finalCart.CustomerName= Name.Text;
            finalCart.CustomerAddress = CustomerAddress.Text;
            finalCart.CustomerEmail = Email.Text;
            cart = finalCart;

                //tempCart.CustomerName = finalCart.CustomerName;
                //tempCart.CustomerAddress = finalCart.CustomerAddress;
                //tempCart.CustomerEmail= finalCart.CustomerEmail;



        }
        private void Confirm_Data(object sender, RoutedEventArgs e)
        {
            Close();

        }

        private void Email_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (cart.CustomerAddress != null && !cart.CustomerAddress.Contains("@"))
                ERROR.Visibility = Visibility.Visible;
        

        }
    }
}
