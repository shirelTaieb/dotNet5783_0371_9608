using System;
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

        private void toSent_Click(object sender, RoutedEventArgs e)
        {
            bl!.Order!.updateSentOrder(or.ID);
            MessageBox.Show("סטטוס עודכן לנשלח", "");
        }
        private void toDelivery_Click(object sender, RoutedEventArgs e)
        {
            bl!.Order!.updateDeliveryOrder(or.ID);
            MessageBox.Show("סטטוס עודכן לנמסר", "");
        }

    }
}
