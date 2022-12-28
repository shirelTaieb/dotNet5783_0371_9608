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
            orderUpdate.DataContext = order;
            UpdateOrder = order;
            //statusComboBox.ItemsSource = Enum.GetValues(typeof(BO.HebOrderStatus));
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
