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
        PO.Cart? POcart=new PO.Cart();
        BO.Cart? boCart=new BO.Cart();
        public cartListPage(ref BO.Cart? my_cart,MainWindow _mainWindow)
        {
            InitializeComponent();
            mainWindow = _mainWindow;
            mainWindow.returnCustomer.Visibility = Visibility.Visible;
            boCart = my_cart;
            if (my_cart!.Items != null)
            {
                 POcart = new PO.Cart()
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
                                 ProductName=orItem.ProductName,
                                 Amount = orItem.Amount,
                                 TotalPrice = orItem.TotalPrice,
                                 path=bl!.Product!.getProductInfoManager(orItem.ProductID).path
                             }).ToList()
                };
                cartListView.ItemsSource = POcart.Items;
                cartTotalPrice.DataContext = my_cart.TotalPrice;

            }
            else
            { 
                    cartListView.ItemsSource = null;
                    nonDetail.Visibility = Visibility.Visible;
            }
        }

        private void moveToCatelog_Click(object sender, RoutedEventArgs e)
        {
            mainWindow.frame.Content = new customerListPage(ref boCart!,mainWindow); // מעבר לקטלוג המוצרים

        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            PO.OrderItem tempOrder = (PO.OrderItem)cartListView.SelectedItem;
            bl!.Cart!.updatePoductAmount(boCart, tempOrder.ProductID ,0);
            cartListView.ItemsSource=null;
            POcart!.Items!.RemoveAll(ca => ca!.ProductID == tempOrder.ProductID); //עדכון הסל במחיקת מוצר
            cartListView.ItemsSource = POcart.Items;
            cartTotalPrice.DataContext = boCart!.TotalPrice;

        }

        private void confirmOrder_Click(object sender, RoutedEventArgs e)
        {
            if (POcart!.CustomerName == null || POcart.CustomerEmail == null || POcart.CustomerAddress == null)
            {
                MessageBox.Show(":)נשמח שתמלא פרטים אישיים לפני ביצוע ההזמנה שלך", "חסרים פרטים", MessageBoxButton.OK, MessageBoxImage.Information);
                EnterDetailsWindow data = new EnterDetailsWindow(POcart);
                data.ShowDialog();
            }
            else
            {
                mainWindow.frame.Content = new ConfirmDetailsPage(ref POcart!,ref boCart, mainWindow);
                
            }

        }
        private void Personal_Data(object sender, RoutedEventArgs e)
        {
            EnterDetailsWindow detailsWindow  = new EnterDetailsWindow(POcart!); // מעבר חלונית פרטיים אישיים
            detailsWindow.Show();
        }
    }

}
