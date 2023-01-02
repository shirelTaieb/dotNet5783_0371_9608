using BO;
using PL.cart;
using PL.products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace PL.customer
{
    /// <summary>
    /// Interaction logic for customerProductListWindow.xaml
    /// </summary>
    public partial class customerProductListWindow : Window
    {
        private BLApi.IBl? bl = BLApi.Factory.Get();
        private BO.Cart cart= new BO.Cart();
        public customerProductListWindow(BO.Cart my_cart)
        {
            InitializeComponent();
            cart = my_cart;
            var list = bl!.Product!.getListOfProduct()!;
            var poList =
            from pro in list
            select new PO.ProductItem
            {
                ID = pro.ID,
                Name = pro.Name,
                Price = pro.Price,
                Category = (BO.HebCategory?)pro.Category,
                AmountInCart = bl.Product.getProductInfoCustomer(pro.ID, my_cart).Amount,
                InStock = bl.Product.getProductInfoCustomer(pro.ID, my_cart).InStock,
             path = pro.path
            };
            //  ListOfProducts.ItemsSource = productListWindow.IEnumerableToObserval(poList);
              ListOfProducts.ItemsSource = poList;
            cart=my_cart;
            categorySelector.ItemsSource = Enum.GetValues(typeof(HebCategory));

        }
        public void ListOfProducts_SelectionChanged(object sender, RoutedEventArgs e)
        {

        }
        public void addToCart_Click(object sender, RoutedEventArgs e)
        {
            PO.ProductItem selectPro = (PO.ProductItem)ListOfProducts.SelectedItem; 
            cartWindow newProductToCart = new cartWindow(cart,selectPro);
            newProductToCart.ShowDialog(); //לפתוח חלונית הוספה
        }

        private void priceSelector_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {

        }

        private void categorySelector_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            var item = categorySelector.SelectedItem;
            IEnumerable<BO.ProductForList?> boList = new List<BO.ProductForList?>();
            if ((int)item == 5)
            {
                boList = bl!.Product!.getListOfProduct()!; 
            }
            else
                boList = bl!.Product!.getPartOfProduct(pro => pro!.Category == (BO.Category)item)!;
            var poList =
         from pro in boList
         select new PO.ProductItem
         {
             ID = pro.ID,
             Name = pro.Name,
             Price = pro.Price,
             Category = (BO.HebCategory?)pro.Category,
             AmountInCart = bl.Product.getProductInfoCustomer(pro.ID, cart).Amount,
             InStock = bl.Product.getProductInfoCustomer(pro.ID, cart).InStock,
             path = pro.path
         };
            // ListOfProducts.ItemsSource = productListWindow.IEnumerableToObserval((IEnumerable<PO.ProductForList>)poList);
            ListOfProducts.ItemsSource = poList;
        }
        private void mouseOnTheBottun(object sender,RoutedEventArgs e)
        {
            //addToCart.IsEnabled = false;
        }
    }

}
