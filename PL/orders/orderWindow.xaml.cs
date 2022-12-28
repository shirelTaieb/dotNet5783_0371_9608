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
        private BO.Order UpdateOrder = new BO.Order();
        public orderWindow(BO.Order order)
        {
            InitializeComponent();
            Status_order.DataContext = (BO.HebOrderStatus)order.Status!; //we want that the status will be wrriten in Hebrew.
            orderUpdate.DataContext = order; //connect the order to the window
            UpdateOrder = order;
        }

        //private void statusComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        //{
        //    if ((int)statusComboBox.SelectedItem == 1)
        //        bl!.Order!.updateSentOrder(UpdateOrder.ID);

        //    if ((int)statusComboBox.SelectedItem == 2)
        //        bl!.Order!.updateDeliveryOrder(UpdateOrder.ID);

        //}
    }
}
