using BO;
using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;

namespace PL.orders
{
    /// <summary>
    /// Interaction logic for orderWindow.xaml
    /// </summary>
    public partial class orderWindow : Window
    {
        private BLApi.IBl? bl = BLApi.Factory.Get();
        private BO.Order or=new BO.Order();
        ObservableCollection<PO.OrderForList> orderCollection = new ObservableCollection<PO.OrderForList>();
        public orderWindow(BO.Order order)
        {
            InitializeComponent();
            Status_order.DataContext = (BO.HebOrderStatus)order.Status!; //we want that the status will be wrriten in Hebrew.
            orderUpdate.DataContext = order; //connect the order to the window
            or = order;
            if ((int)order.Status == 0) //when the order is just confirm
                toSent.Visibility = Visibility.Visible;
            if  ((int)order.Status == 1)
                toDelivery.Visibility = Visibility.Visible;
        }

        #region אירועי כפתורים
        private void toSent_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                bl!.Order!.updateSentOrder(or.ID);
                MessageBox.Show("סטטוס עודכן לנשלח", "");
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        private void toDelivery_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                bl!.Order!.updateDeliveryOrder(or.ID);
                MessageBox.Show("סטטוס עודכן לנמסר", "");
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
         private void seeAllProduct_Click(object sender, RoutedEventArgs e)
        {
            orderFrame.Content = new orderListProductPage(or);
            Return.Visibility = Visibility.Visible;
        }

        private void Return_Click(object sender, RoutedEventArgs e)
        {
            orderFrame.Content = null;
            Return.Visibility = Visibility.Collapsed;
        }
        #endregion

    }
}
