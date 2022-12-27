using BLApi;
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
using System.Windows.Shapes;

namespace PL.orders
{
    /// <summary>
    /// Interaction logic for orderListWindow.xaml
    /// </summary>
    public partial class orderListWindow : Window
    {
        private BLApi.IBl? bl = BLApi.Factory.Get();
        public orderListWindow()
        {
            InitializeComponent();
            var list = bl!.Order!.getOrderList();
            orderForListDataGrid.DataContext = list;
            orderForListDataGrid.IsReadOnly = true;
        }

        private void orderForListListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
        }
        private void orderUpdate_Click(object sender, RoutedEventArgs e)
        {
            BO.OrderForList ofl = (BO.OrderForList)orderForListDataGrid.SelectedItem;
            BO.Order or = new BO.Order();
            or = bl!.Order!.getOrderInfo(ofl.ID)!;
            orderWindow data = new orderWindow(or);
            data.Show();
        }
    }
}
