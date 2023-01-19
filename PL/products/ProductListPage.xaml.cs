using BO;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace PL.products
{
    /// <summary>
    /// Interaction logic for ProductListPage.xaml
    /// </summary>
    public partial class ProductListPage : Page
    {

        private BLApi.IBl? bl = BLApi.Factory.Get();
        public ObservableCollection<PO.ProductForList>? productCollection { get; set; }
        public ProductListPage(MainWindow mainWindow)
        {
            InitializeComponent();
            mainWindow.returnManager.Visibility = Visibility.Visible;
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
            productCollection = tools.IEnumerableToObserval(poList);
            productForListDataGrid.DataContext = productCollection;
            productForListDataGrid.IsReadOnly = true;
            categorySelector.ItemsSource = Enum.GetValues(typeof(HebCategory));
        }

        private void showProductDetails_doubleClick(object sender, RoutedEventArgs e)
        {
            productWindow proWin = new productWindow(1, addProduct ,deleteProduct, (PO.ProductForList)productForListDataGrid.SelectedItem);
            proWin.Show();
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
                productForListDataGrid.DataContext = tools.IEnumerableToObserval(poList);
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
                productForListDataGrid.DataContext = tools.IEnumerableToObserval(poList);
            }
        }
        public void Add_Click(object sender, RoutedEventArgs e)
        {

            productWindow AddProduct = new productWindow(0, addProduct, deleteProduct);
            AddProduct.id.Visibility = Visibility.Collapsed;
            AddProduct.id_lable.Visibility = Visibility.Collapsed;
            AddProduct.ShowDialog();
            
        }


        public void update_Click(object sender, RoutedEventArgs e)
        {
            PO.ProductForList? poUpPro = (PO.ProductForList)productForListDataGrid.SelectedItem;
            if (poUpPro != null)
            {
                productWindow updateProduct = new productWindow(0, addProduct, deleteProduct, poUpPro);
                updateProduct.ShowDialog();
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
                productForListDataGrid.DataContext = tools.IEnumerableToObserval(poList);
            }

        }

        private void productForListDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        public void addProduct(PO.ProductForList productToAdd) =>
            productCollection?.Add(productToAdd);
        public void deleteProduct(PO.ProductForList productToRemove)
        {
            productCollection?.Remove(productToRemove);
        }
        public void delete_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("?האם אתה בטוח שברצונך למחוק את המוצר", "", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
            {
                PO.ProductForList proToDel = (PO.ProductForList)productForListDataGrid.SelectedItem;
                bl!.Product!.deleteProduct(proToDel.ID); //מחיקת המוצר מהנתונים
                deleteProduct(proToDel); //מחיקה מהאובסרבל
            }
        }
        
    }
}

