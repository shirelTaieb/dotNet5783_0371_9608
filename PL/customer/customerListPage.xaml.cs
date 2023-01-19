using BO;
using PL.cart;
using PL.products;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Drawing;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PL.customer
{
    /// <summary>
    /// Interaction logic for customerListPage.xaml
    /// </summary>
    public partial class customerListPage : Page
    {

        private BLApi.IBl? bl = BLApi.Factory.Get();
        private BO.Cart cart = new BO.Cart();
        ObservableCollection<PO.ProductItem?> observalProducts=new ObservableCollection<PO.ProductItem?>();
        public customerListPage(ref BO.Cart my_cart,MainWindow mainWindow)
        {

            InitializeComponent();
            mainWindow.returnCustomer.Visibility = Visibility.Visible;
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
                AmountInCart = bl.Product.getProductInfoCustomer(pro.ID, cart).Amount,
                InStock = bl.Product.getProductInfoCustomer(pro.ID, cart).InStock,
                path = pro.path
            };
            ListOfProducts.ItemsSource =tools.IEnumerableToObserval(poList);
            cart = my_cart;
            categorySelector.ItemsSource = Enum.GetValues(typeof(HebCategory));

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
            ListOfProducts.ItemsSource = tools.IEnumerableToObserval(
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
         });  //cast to list of PO.productItem
            
        }
        public void productData_Click(object sender, RoutedEventArgs e)
        {
            PO.ProductItem? item= ListOfProducts.SelectedItem as PO.ProductItem;
            if (item != null)
            {
                cartWindow data = new cartWindow(ref cart, item);
                data.ShowDialog();
                ListOfProducts.ItemsSource = tools.IEnumerableToObserval(
                    from pro in bl!.Product!.getListOfProduct()!
                    select new PO.ProductItem
                    {
                        ID = pro.ID,
                        Name = pro.Name,
                        Price = pro.Price,
                        Category = (BO.HebCategory?)pro.Category,
                        AmountInCart = bl.Product.getProductInfoCustomer(pro.ID, cart).Amount,
                        InStock = bl.Product.getProductInfoCustomer(pro.ID, cart).InStock,
                        path = pro.path
                    }); //קישור הרשימה מחדש
       
      
            }

        }

        private void ListOfProducts_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
