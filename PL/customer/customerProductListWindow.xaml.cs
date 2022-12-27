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

        private void priceSelector_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {

        }

        private void categorySelector_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            
        }
    }

}
