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
            statusComboBox.ItemsSource = Enum.GetValues(typeof(BO.HebOrderStatus));
        }


    }
}
