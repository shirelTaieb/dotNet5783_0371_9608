using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System;
//using System.Windows.UI.Xaml;


namespace PL.orders
{
    /// <summary>
    /// Interaction logic for EnterIdForTrackingWindow.xaml
    /// </summary>
    using System.Text.RegularExpressions;
    public partial class EnterIdForTrackingWindow : Window
    {
        int num;
        int id;
        private BLApi.IBl? bl = BLApi.Factory.Get();

        public EnterIdForTrackingWindow(int managerOrCustomer)
        {
            InitializeComponent();
            num = managerOrCustomer; //if it is a manger or customer
           
        }
        #region בדיקת קלט- מספרי בלבד
        private void PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }
        #endregion

        #region אירועי כפתורים
        private void keyDown(object sender, KeyEventArgs e)
        {
            if(e.Key==Key.Enter)
                trackOrder_Click(sender, e);
        }

        private void trackOrder_Click(object sender, RoutedEventArgs e)
        {
            BO.Order orderToShow = new BO.Order();
            try
            {
                id = int.Parse(ID.Text);
                orderToShow = bl!.Order!.getOrderInfo(id)!; //לבדוק אם המספר תקין!!
                if (num == 0)//for manger
                {
                    orderWindow ord = new orderWindow(orderToShow);
                    ord.Show();
                }
                if (num == 1)//for customer
                {
                    CustomerOrderTracking ord = new CustomerOrderTracking(orderToShow);
                    ord.Show();
                }
                Close();
            }
            catch (BO.wrongDataException)// ID לא חוקי
            {
                notValid.Visibility = Visibility.Visible;
                ID.Clear();
            }
            catch (BO.doseNotExistException)//מס הזמנה לא קיים
            {
                MessageBox.Show("לא קיימת הזמנה עם מספר זה", "");
                ID.Clear();
            }
            catch { };

       
        }
        #endregion
    }
}
