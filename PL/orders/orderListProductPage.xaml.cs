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

namespace PL.orders
{
    /// <summary>
    /// Interaction logic for orderListProductPage.xaml
    /// </summary>
    public partial class orderListProductPage : Page
    {
        private BLApi.IBl? bl = BLApi.Factory.Get();
        public orderListProductPage(BO.Order order)
        {
            InitializeComponent();
            List<PO.OrderItem> POitems = new List<PO.OrderItem>();
            POitems =
               (from boItem in order.Items
                select new PO.OrderItem()
                {
                    ID = boItem.ID,
                    ProductID = boItem.ProductID,
                    ProductName = boItem.ProductName,
                    Price = boItem.Price,
                    Amount = boItem.Amount,
                    TotalPrice = boItem.TotalPrice
                }).ToList();
            productListOfOrder.DataContext = tools.IEnumerableToObserval(POitems);
        }

    }
}
