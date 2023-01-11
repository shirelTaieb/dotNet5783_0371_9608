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
    /// Interaction logic for CustomerOrderTracking.xaml
    /// </summary>
    public partial class CustomerOrderTracking : Window
    {
        private BLApi.IBl? bl = BLApi.Factory.Get();
        private BO.Order or = new BO.Order();
        public CustomerOrderTracking(BO.Order order)
        {
            InitializeComponent();
            Status_order.DataContext = (BO.HebOrderStatus)order.Status!; //we want that the status will be wrriten in Hebrew.
            orderTracking.DataContext = order; //connect the order to the window
            or = order;
        }


    }
}
