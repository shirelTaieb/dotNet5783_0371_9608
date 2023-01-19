using PL.customer;
using System;
using System.Collections.Generic;
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
    /// Interaction logic for ConfirmDetailsPage.xaml
    /// </summary>
    public partial class ConfirmDetailsPage : Page
    {
        MainWindow _mainWindow;
        private BLApi.IBl? bl = BLApi.Factory.Get();
        PO.Cart cart= new PO.Cart();
        public ConfirmDetailsPage(PO.Cart poCart, MainWindow mainWindow)
        {
            InitializeComponent();
            customerData.DataContext = poCart;
            final_cartDetails.DataContext = poCart.Items;
            cartTotalPrice.DataContext = poCart.TotalPrice;
            cart = poCart;
            _mainWindow = mainWindow;
        }

        private void finalConfirmOrder_Click(object sender, RoutedEventArgs e)
        {
            BO.Cart boCart = new BO.Cart()
            {
                CustomerAddress = cart.CustomerAddress,
                CustomerEmail = cart.CustomerEmail,
                CustomerName = cart.CustomerName,
                Items =
                (from item in cart.Items
                select new BO.OrderItem()
                {
                    ID = item.ID,
                    Price = item.Price,
                    ProductID = item.ProductID,
                    Amount = item.Amount,
                    TotalPrice = item.TotalPrice
                }).ToList()
               
            };
            int newOrderID = 0;
            try   
            {
                newOrderID = bl!.Cart!.confirmOrder(boCart); //אישור הזמנה
                boCart.Items=null; //מחיקת הסל
                cart.Items = null;


            }
            catch
            {
                return; 
            }
            MessageBox.Show(string.Format(" {0}  :ההזמנה שלך אושרה בהצלחה:)  מספר ההזמנה שלך הוא", newOrderID.ToString()));
            _mainWindow.frame.Content = new MainCustomer(_mainWindow,boCart);//חזרה לתפריט הראשי צריך למחוק את הכארט

        }
    }
}
