﻿using System;
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

namespace PL.cart
{
    /// <summary>
    /// Interaction logic for EnterDetailsWindow.xaml
    /// </summary>
    public partial class EnterDetailsWindow : Window
    {
        private BLApi.IBl? bl = BLApi.Factory.Get();
        PO.Cart cart=new PO.Cart();
        public EnterDetailsWindow(ref PO.Cart finalCart)
        {
            InitializeComponent();
           Data.DataContext = finalCart;
           cart = finalCart;

        }
        private void Confirm_Data(object sender, RoutedEventArgs e)
        {
            if (cart.CustomerEmail != null && !cart.CustomerEmail.Contains("@"))
            {
                ERROR.Visibility = Visibility.Visible;
                Email.Clear();
            }
            else
                Close();

        }

     
    }
}
