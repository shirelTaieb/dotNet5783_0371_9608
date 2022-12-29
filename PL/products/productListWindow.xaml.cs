﻿using BO;
using System;
using System.Windows;
using System.Windows.Controls;

namespace PL.products
{
    /// <summary>
    /// Interaction logic for productListWindow.xaml
    /// </summary>
    public partial class productListWindow : Window
    {
        private BLApi.IBl? bl = BLApi.Factory.Get();
        public productListWindow()
        {
            InitializeComponent();
            var list = bl!.Product!.IEnumerableToObserval(bl!.Product!.getListOfProduct()!);
            productForListDataGrid.DataContext = list;
            productForListDataGrid.IsReadOnly = true;
            categorySelector.ItemsSource = Enum.GetValues(typeof(HebCategory));

        }

        private void priceSelector_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void categorySelector_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var item = categorySelector.SelectedItem;
            if ((int)item == 5)
                productForListDataGrid.DataContext = bl!.Product!.IEnumerableToObserval(bl!.Product!.getListOfProduct()!);
            else
                productForListDataGrid.DataContext= bl!.Product!.IEnumerableToObserval(bl!.Product!.getPartOfProduct(pro=>pro!.Category==(BO.Category)item)!);



        }
        public void Add_Click(object sender, RoutedEventArgs e) 
        {

            productWindow AddProduct = new productWindow();
            AddProduct.id.Visibility = Visibility.Collapsed;
            AddProduct.id_lable.Visibility = Visibility.Collapsed;
            AddProduct.ShowDialog();
            //צריך להוסיף בפועל את המוצרר

        }


        public void update_Click(object sender, RoutedEventArgs e) 
        {
            BO.ProductForList? upPro = (ProductForList)productForListDataGrid.SelectedItem;
            if (upPro != null)
            { 
                productWindow updateProduct = new productWindow(upPro);
                updateProduct.ShowDialog();
            }
        }

        private void productForListDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
