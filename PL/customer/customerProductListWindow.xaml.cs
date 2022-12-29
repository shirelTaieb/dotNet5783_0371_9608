using BO;
using System;
using System.Windows;

namespace PL.customer
{
    /// <summary>
    /// Interaction logic for customerProductListWindow.xaml
    /// </summary>
    public partial class customerProductListWindow : Window
    {
        private BLApi.IBl? bl = BLApi.Factory.Get();

        public customerProductListWindow(BO.Cart my_cart)
        {
            InitializeComponent();
            var list = bl!.Product!.IEnumerableToObserval(bl!.Product!.getListOfProduct()!);
            ListOfProducts.ItemsSource = list;
            categorySelector.ItemsSource = Enum.GetValues(typeof(HebCategory));

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
            var item = categorySelector.SelectedItem;
            if ((int)item == 5)
                ListOfProducts.ItemsSource = bl!.Product!.IEnumerableToObserval(bl!.Product!.getListOfProduct()!);
            else
                ListOfProducts.ItemsSource = bl!.Product!.IEnumerableToObserval(bl!.Product!.getPartOfProduct(pro => pro!.Category == (BO.Category)item)!);
        }
    }

}
