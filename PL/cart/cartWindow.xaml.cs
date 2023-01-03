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
        public cartWindow(BO.Cart? my_cart, PO.ProductItem proToAdd)
        {
            InitializeComponent();
            amount.DataContext = counter;
            total = proToAdd.Price;//in the first time the price is for one product
            productitem = proToAdd;
            totalPrice.DataContext = total;
        }

        private void up_Click(object sender, RoutedEventArgs e)
        {
            if (counter < bl!.Product!.getProductInfoManager(productitem.ID).InStock)
            {
                total += productitem.Price;
                counter++;
            }
            else
            {
                MessageBox.Show("במלאי יש {counter} מוצרים בלבד", "");
            }

        }
        private void down_Click(object sender, RoutedEventArgs e)
        {
            if (counter != 1)
            {
                total -= productitem.Price;
                counter--;
            }
            else
                MessageBox.Show("אין אפשרות להוסיף פחות ממוצר אחד", "");
        }
    }
}
