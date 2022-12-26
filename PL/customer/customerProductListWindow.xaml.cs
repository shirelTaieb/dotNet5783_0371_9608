using System.Windows;

namespace PL.customer
{
    /// <summary>
    /// Interaction logic for customerProductListWindow.xaml
    /// </summary>
    public partial class customerProductListWindow : Window
    {
        private BLApi.IBl? bl = BLApi.Factory.Get();

        public customerProductListWindow()
        {
            InitializeComponent();
            var list = bl!.Product!.getListOfProduct();
            ListOfProducts.ItemsSource = list;
        }
        public void ListOfProducts_SelectionChanged(object sender, RoutedEventArgs e)
        {

        }
        public void addToCart_Click(object sender, RoutedEventArgs e)
        {

        }
    }

}
