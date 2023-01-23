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
        PO.Cart POcart= new PO.Cart();
        BO.Cart BOcart=new BO.Cart();
        public ConfirmDetailsPage(ref PO.Cart poCart,ref BO.Cart boCart, MainWindow mainWindow)
        {
            InitializeComponent();
            customerData.DataContext = poCart;
            final_cartDetails.DataContext = poCart.Items;
            cartTotalPrice.DataContext = poCart.TotalPrice;
            POcart = poCart;
            BOcart = boCart;
            _mainWindow = mainWindow;
        }
        #region אישור סופי של הסל, יצירת הזמנה
        private void finalConfirmOrder_Click(object sender, RoutedEventArgs e)
        {

            BOcart.CustomerAddress = POcart.CustomerAddress;
            BOcart.CustomerEmail = POcart.CustomerEmail;
            BOcart.CustomerName = POcart.CustomerName;
            BOcart.Items =
                (from item in POcart.Items
                 select new BO.OrderItem()
                 {
                     ID = item.ID,
                     Price = item.Price,
                     ProductID = item.ProductID,
                     ProductName = item.ProductName,
                     Amount = item.Amount,
                     TotalPrice = item.TotalPrice
                 }).ToList();

            int newOrderID = 0;
            try   
            {
                newOrderID = bl!.Cart!.confirmOrder(BOcart); //אישור הזמנה
                BOcart.Items = null; //מחיקת הסל
               
            }
            catch
            {
                return; 
            }
            MessageBox.Show(string.Format(" {0}  :ההזמנה שלך אושרה בהצלחה:)  מספר ההזמנה שלך הוא", newOrderID.ToString()));
            _mainWindow.frame.Content = new MainCustomer(_mainWindow,ref BOcart);//חזרה לתפריט הראשי צריך למחוק את הכארט

        }
        #endregion
    }
}
