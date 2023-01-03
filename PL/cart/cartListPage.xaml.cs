using System;
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

namespace PL.cart
{
    /// <summary>
    /// Interaction logic for cartListPage.xaml
    /// </summary>
    public partial class cartListPage : Page
    {
        private BLApi.IBl? bl = BLApi.Factory.Get();
        private BO.Cart cart = new BO.Cart();
        public cartListPage(BO.Cart my_cart)
        {
            InitializeComponent();
            cart = my_cart;

        }
    }
}
