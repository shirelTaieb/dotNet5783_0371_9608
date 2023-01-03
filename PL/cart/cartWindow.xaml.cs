using BO;
using System.Security.Principal;
using System.Windows;

namespace PL.cart
{
    /// <summary>
    /// Interaction logic for cartWindow.xaml
    /// </summary>
    public partial class cartWindow : Window
    {
        private BLApi.IBl? bl = BLApi.Factory.Get();
        int counter = 1;
        double? total = 0;
        PO.ProductItem productitem = new PO.ProductItem();
        BO.Cart? cart=new BO.Cart();
        public cartWindow(BO.Cart? my_cart, PO.ProductItem proToAdd)
        {
            InitializeComponent();
            stack.DataContext=proToAdd;
            amount.DataContext = counter;
            total = proToAdd.Price;//in the first time the price is for one product
            productitem = proToAdd;
            totalPrice.DataContext = total;
            cart = my_cart;
        }

        private void up_Click(object sender, RoutedEventArgs e)
        {
            NinCount.Visibility = Visibility.Hidden;
            if (counter < bl!.Product!.getProductInfoManager(productitem.ID).InStock)
            {
                total += productitem.Price;
                counter++;
                amount.DataContext = counter;
                totalPrice.DataContext = total;
            }
            else
            {
                NaxCount.Visibility = Visibility.Visible;
               // showInStock.Visibility = Visibility.Visible;
            }

        }
        private void down_Click(object sender, RoutedEventArgs e)
        {
            //showInStock.Visibility = Visibility.Hidden;
            NaxCount.Visibility = Visibility.Hidden;
            if (counter != 1)
            {
                total -= productitem.Price;
                counter--;
                amount.DataContext = counter;
                totalPrice.DataContext = total;
            }
            else
                NinCount.Visibility=Visibility.Visible;
        }
         private void addToCart_Click(object sender, RoutedEventArgs e)
        {
            bl!.Cart!.addProductToCart(cart, productitem.ID);
            bl!.Cart!.updatePoductAmount(cart, productitem.ID, counter);
            this.Close();
        }
    }
}
