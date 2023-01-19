﻿using System;
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

namespace PL.orders
{
    /// <summary>
    /// Interaction logic for orderListPage.xaml
    /// </summary>
    public partial class orderListPage : Page
    {
        private BLApi.IBl? bl = BLApi.Factory.Get();
        //ObservableCollection<PO.OrderForList>? orderCollection = new ObservableCollection<PO.OrderForList>();
        public orderListPage(MainWindow mainWindow)
        {
            InitializeComponent();

            mainWindow.returnManager.Visibility = Visibility.Visible;
            var list = bl!.Order!.getOrderList();
            var poList =
                from or in list
                select new PO.OrderForList
                {
                    ID = or.ID,
                    CustomerName = or.CustomerName,
                    AmountOfItems = or.AmountOfItems,
                    Status = (BO.HebOrderStatus?)or.Status,
                    TotalPrice = or.TotalPrice

                };
            orderForListDataGrid.DataContext = tools.IEnumerableToObserval(poList);
          // IEnumerable<IGrouping<BO.OrderStatus?, BO.OrderForList>> groupings = GroupByStatus(bl!.Order!.getOrderList()!);
            //groupings = groupings.OrderBy(p => p.Key);
        }

        private void orderForListListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
        private void orderUpdate_DoubleClick(object sender, RoutedEventArgs e)
        {
            PO.OrderForList ofl = (PO.OrderForList)orderForListDataGrid.SelectedItem;
            BO.Order or = new BO.Order();
            try
            {
                or = bl!.Order!.getOrderInfo(ofl.ID)!;
                orderWindow data = new orderWindow(or);
                data.ShowDialog();
                var list = bl!.Order!.getOrderList();
                var poList =
                    from order in list
                    select new PO.OrderForList
                    {
                        ID = order.ID,
                        CustomerName = order.CustomerName,
                        AmountOfItems = order.AmountOfItems,
                        Status = (BO.HebOrderStatus?)order.Status,
                        TotalPrice = order.TotalPrice
                    };
                orderForListDataGrid.DataContext = tools.IEnumerableToObserval(poList);
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        private void groupStatus_Click(object sender, RoutedEventArgs e)
        {
            //statusSelector.Items.Add("");
            IEnumerable<IGrouping<BO.HebOrderStatus?, PO.OrderForList>> groupings = GroupByStatus(bl!.Order!.getOrderList()!);
            groupings = groupings.OrderBy(p => p.Key);
            orderForListDataGrid.DataContext = (from gru in groupings from o in gru select o).ToList();
           
        }
        IEnumerable<IGrouping<BO.HebOrderStatus?, PO.OrderForList>> GroupByStatus(IEnumerable<BO.OrderForList> listToGroup)
        {
            List<PO.OrderForList> POlist = (from or in listToGroup
                                            select new PO.OrderForList()
                                            {
                                                ID = or.ID,
                                                CustomerName = or.CustomerName,
                                                AmountOfItems = or.AmountOfItems,
                                                Status = (BO.HebOrderStatus?)or.Status,
                                                TotalPrice = or.TotalPrice
                                            }).ToList();

            return (from order in POlist
             group order by order.Status into orderinfo
             select orderinfo).ToList();
        }

    }
}
