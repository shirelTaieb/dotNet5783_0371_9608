using PL.customer;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace PL.cart
{
    /// <summary>
    /// Interaction logic for cartListPage.xaml
    /// </summary>
    public partial class cartListPage : Page
    {
        private BLApi.IBl? bl = BLApi.Factory.Get();
        MainWindow mainWindow;
        BO.Cart? cart;
        public cartListPage(BO.Cart? my_cart,MainWindow _mainWindow)
        {
            InitializeComponent();
            mainWindow = _mainWindow;
            cart=my_cart;
            if (my_cart!.Items != null)
            {
                PO.Cart cart = new PO.Cart()
                {
                    CustomerName = my_cart.CustomerName,
                    CustomerEmail = my_cart.CustomerEmail,
                    CustomerAddress = my_cart.CustomerAddress,
                    TotalPrice = my_cart.TotalPrice,
                    Items = (from orItem in my_cart.Items
                             select new PO.OrderItem()
                             {
                                 ID = orItem.ID,
                                 Price = orItem.Price,
                                 ProductID = orItem.ProductID,
                                 ProductName=bl!.Product!.getProductInfoManager(orItem.ProductID).Name,
                                 Amount = orItem.Amount,
                                 TotalPrice = orItem.TotalPrice
                             }).ToList()
                };
                cartListView.ItemsSource = cart.Items;
            }
            else
            {
                    cartListView.ItemsSource = null;
                    nonDetail.Visibility = Visibility.Visible;
            }
        }

        private void moveToCatelog_Click(object sender, RoutedEventArgs e)
        {
            mainWindow.frame.Content = new customerListPage(cart!); // מעבר לקטלוג המוצרים

        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            if (cartListView.SelectedItems == null);
            PO.OrderItem tempOrder = (PO.OrderItem)cartListView.SelectedItem;
            bl!.Cart!.updatePoductAmount(cart, tempOrder.ProductID ,0);
        }
    }
}
