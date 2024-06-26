﻿using PL.cart;
using PL.customer;
using PL.orders;
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

namespace PL
{
    /// <summary>
    /// Interaction logic for MainCustomer.xaml
    /// </summary>
    public partial class MainCustomer : Page
    {
        MainWindow mainWindow;
        BO.Cart my_cart = new BO.Cart();
        public MainCustomer(MainWindow window,ref BO.Cart cart)
        {
            InitializeComponent();
            my_cart = cart;
            mainWindow = window;
            window.returnCustomer.Visibility = Visibility.Collapsed;

        }
        #region אירועי כפתורים
        public void Katelog_Click(object o, RoutedEventArgs e)
        {
            mainWindow.frame.Content = new customerListPage(ref my_cart,mainWindow);
        }
        public void cart_Click(object o, RoutedEventArgs e)
        {

            mainWindow.frame.Content  = new cartListPage(ref my_cart, mainWindow);

        }

        private void CustomerTrack_Click(object sender, RoutedEventArgs e)
        {
            EnterIdForTrackingWindow enterID = new EnterIdForTrackingWindow(1);
            enterID.ShowDialog();
        }
        #endregion
    }
}
