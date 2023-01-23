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
        int counter;
        double? total = 0;
        PO.ProductItem productitem = new PO.ProductItem();
        BO.Cart? cart=new BO.Cart();
        public cartWindow(ref BO.Cart? my_cart, PO.ProductItem proToAdd)
        {
            InitializeComponent();
            stack.DataContext=proToAdd;
            counter=proToAdd.AmountInCart;
            amount.DataContext = counter;
            total = counter * (proToAdd.Price);
            productitem = proToAdd;
            totalPrice.DataContext = total;
            cart = my_cart;
        }

        #region אירועי כפתורים
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
                NaxCount.Visibility = Visibility.Visible;


        }
        private void down_Click(object sender, RoutedEventArgs e)
        {
            NaxCount.Visibility = Visibility.Hidden;
            if (counter > 1)
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
        #endregion

    }
}
