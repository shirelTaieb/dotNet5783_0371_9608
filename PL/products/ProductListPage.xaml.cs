using BO;
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

namespace PL.products
{
    /// <summary>
    /// Interaction logic for ProductListPage.xaml
    /// </summary>
    public partial class ProductListPage : Page
    { 
        private BLApi.IBl? bl = BLApi.Factory.Get();
        public ProductListPage()
        {
            InitializeComponent();
            //var list = bl!.Product!.getListOfProduct();
            //productForListDataGrid.DataContext = list;
            //productForListDataGrid.IsReadOnly = true;


            // categorySelector.ItemsSource = Enum.GetValues(typeof(BO.Category));
        }

        //private void priceSelector_SelectionChanged(object sender, SelectionChangedEventArgs e)
        //{

        //}

        //private void categorySelector_SelectionChanged(object sender, SelectionChangedEventArgs e)
        //{
        //    var item = categorySelector.SelectedItem;

        //}
        //public void Add_Click(object sender, RoutedEventArgs e)
        //{

        //    productWindow AddProduct = new productWindow();
        //    AddProduct.id.Visibility = Visibility.Collapsed;
        //    AddProduct.id_lable.Visibility = Visibility.Collapsed;
        //    AddProduct.ShowDialog();
        //    //צריך להוסיף בפועל את המוצרר

        //}


        //public void update_Click(object sender, RoutedEventArgs e)
        //{
        //    BO.ProductForList? upPro = (ProductForList)productForListDataGrid.SelectedItem;
        //    if (upPro != null)
        //    {
        //        productWindow updateProduct = new productWindow(upPro);
        //        updateProduct.id.IsReadOnly = true;
        //        updateProduct.ShowDialog();
        //    }
        //}

    }
}

