//using BO;
//using System;
//using System.Collections.Generic;
//using System.Collections.ObjectModel;
//using System.Linq;
//using System.Windows;
//using System.Windows.Controls;

//namespace PL.products
//{
//    /// <summary>
//    /// Interaction logic for ProductListPage.xaml
//    /// </summary>
//    public partial class ProductListPage : Page
//    {

//        private BLApi.IBl? bl = BLApi.Factory.Get();
//        public ObservableCollection<PO.ProductForList>? productCollection { get; set; }
//        public ProductListPage()
//        {
//            InitializeComponent();
//            var list = bl!.Product!.getListOfProduct()!;
//            var poList =
//                from item in list
//                select new PO.ProductForList
//                {
//                    ID = item.ID,
//                    Name = item.Name,
//                    Price = item.Price,
//                    Category = (BO.HebCategory?)item.Category,
//                    path = item.path
//                };
//            productCollection = IEnumerableToObserval(poList);
//            productForListDataGrid.DataContext = productCollection;
//            productForListDataGrid.IsReadOnly = true;
//            categorySelector.ItemsSource = Enum.GetValues(typeof(HebCategory));
//        }

//        private void priceSelector_SelectionChanged(object sender, SelectionChangedEventArgs e)
//        {

//        }

//        private void categorySelector_SelectionChanged(object sender, SelectionChangedEventArgs e)
//        {
//            var item = categorySelector.SelectedItem;
//            if ((int)item == 5)
//            {
//                var boList = bl!.Product!.getListOfProduct()!;
//                var poList =
//                    from pro in boList
//                    select new PO.ProductForList
//                    {
//                        ID = pro.ID,
//                        Name = pro.Name,
//                        Category = (BO.HebCategory?)pro.Category,
//                        Price = pro.Price,
//                        path = pro.path
//                    };
//                productForListDataGrid.DataContext = IEnumerableToObserval(poList);
//            }
//            else
//            {
//                var boList = bl!.Product!.getPartOfProduct(pro => pro!.Category == (BO.Category)item)!;
//                var poList =
//                 from pro in boList
//                 select new PO.ProductForList
//                 {
//                     ID = pro.ID,
//                     Name = pro.Name,
//                     Category = (BO.HebCategory?)pro.Category,
//                     Price = pro.Price,
//                     path = pro.path
//                 };
//                productForListDataGrid.DataContext = IEnumerableToObserval(poList);
//            }
//        }
//        public void Add_Click(object sender, RoutedEventArgs e)
//        {

//            productWindow AddProduct = new productWindow(addProduct);
//            AddProduct.id.Visibility = Visibility.Collapsed;
//            AddProduct.id_lable.Visibility = Visibility.Collapsed;
//            AddProduct.ShowDialog();
//            //צריך להוסיף בפועל את המוצרר


//        }


//        public void update_Click(object sender, RoutedEventArgs e)
//        {
//            PO.ProductForList? poUpPro = (PO.ProductForList)productForListDataGrid.SelectedItem;
//            if (poUpPro != null)
//            {
//                productWindow updateProduct = new productWindow(addProduct, poUpPro);
//                updateProduct.ShowDialog();
//                var boList = bl!.Product!.getListOfProduct()!;
//                var poList =
//                    from pro in boList
//                    select new PO.ProductForList
//                    {
//                        ID = pro.ID,
//                        Name = pro.Name,
//                        Category = (BO.HebCategory?)pro.Category,
//                        Price = pro.Price,
//                        path = pro.path
//                    };
//                productForListDataGrid.DataContext = IEnumerableToObserval(poList);
//            }

//        }

//        private void productForListDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
//        {

//        }
//        public ObservableCollection<PO.ProductForList> IEnumerableToObserval(IEnumerable<PO.ProductForList> listToCast)
//        {
//            productCollection = new ObservableCollection<PO.ProductForList>();
//            foreach (PO.ProductForList item in listToCast)
//                productCollection.Add(item);
//            return productCollection;

//        }
//        public void addProduct(PO.ProductForList productToAdd) => productCollection?.Add(productToAdd);
//        private void Button_Click(object sender, RoutedEventArgs e)
//        {
//            // main.GoBackToStartPage();
//        }
//    }
//}

