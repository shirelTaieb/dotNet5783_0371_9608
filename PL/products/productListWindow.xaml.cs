using BO;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
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
            var list = bl!.Product!.getListOfProduct()!;
            var poList =
                from item in list
                select new PO.ProductForList
                {
                    ID = item.ID,
                    Name = item.Name,
                    Price = item.Price,
                    Category = (BO.HebCategory?)item.Category,
                    path = item.path
                };
            productForListDataGrid.DataContext = IEnumerableToObserval(poList);
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
            {
                var boList = bl!.Product!.getListOfProduct()!;
                var poList =
                    from pro in boList
                    select new PO.ProductForList
                    {
                        ID = pro.ID,
                        Name = pro.Name,
                        Category = (BO.HebCategory?)pro.Category,
                        Price = pro.Price,
                        path = pro.path
                    };
                productForListDataGrid.DataContext = IEnumerableToObserval(poList);
            }
            else
            {
                var boList = bl!.Product!.getPartOfProduct(pro => pro!.Category == (BO.Category)item)!;
                var poList =
                 from pro in boList
                 select new PO.ProductForList
                 {
                     ID = pro.ID,
                     Name = pro.Name,
                     Category = (BO.HebCategory?)pro.Category,
                     Price = pro.Price,
                     path = pro.path
                 };
                productForListDataGrid.DataContext = IEnumerableToObserval(poList);
            }


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
            PO.ProductForList? poUpPro = (PO.ProductForList)productForListDataGrid.SelectedItem;
            if (poUpPro != null)
            {
                productWindow updateProduct = new productWindow(poUpPro);
                updateProduct.ShowDialog();
            }
            
        }

        private void productForListDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
        public ObservableCollection<PO.ProductForList> IEnumerableToObserval(IEnumerable<PO.ProductForList> listToCast)
        {
            ObservableCollection<PO.ProductForList> result = new ObservableCollection<PO.ProductForList>();
            foreach (PO.ProductForList item in listToCast)
                result.Add(item);
            return result;

        }

    }
}
