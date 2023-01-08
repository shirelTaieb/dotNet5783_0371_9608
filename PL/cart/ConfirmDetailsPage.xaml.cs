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

namespace PL.cart
{
    /// <summary>
    /// Interaction logic for ConfirmDetailsPage.xaml
    /// </summary>
    public partial class ConfirmDetailsPage : Page
    {
        public ConfirmDetailsPage(PO.Cart poCart)
        {
            InitializeComponent();
            customerData.DataContext = poCart;
            final_cartDetails.DataContext = poCart.Items;

        }

        private void finalConfirmOrder_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
