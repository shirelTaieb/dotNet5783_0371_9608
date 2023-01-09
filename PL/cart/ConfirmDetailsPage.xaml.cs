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
        private BLApi.IBl? bl = BLApi.Factory.Get();
        PO.Cart cart= new PO.Cart();
        public ConfirmDetailsPage(PO.Cart poCart)
        {
            InitializeComponent();
            customerData.DataContext = poCart;
            final_cartDetails.DataContext = poCart.Items;
            cart = poCart;

        }

        private void finalConfirmOrder_Click(object sender, RoutedEventArgs e)
        {
            BO.Cart boCart = new BO.Cart()
            {
                CustomerAddress = cart.CustomerAddress,
                CustomerEmail = cart.CustomerEmail,
                CustomerName = cart.CustomerName,
                Items =
                (from item in cart.Items
                select new BO.OrderItem()
                {
                    ID = item.ID,
                    Price = item.Price,
                    ProductID = item.ProductID,
                    Amount = item.Amount,
                    TotalPrice = item.TotalPrice
                }).ToList()
               
            };
            try
            {
                bl!.Cart!.confirmOrder(boCart);
            }
            catch
            {

            }
           
        }
    }
}
