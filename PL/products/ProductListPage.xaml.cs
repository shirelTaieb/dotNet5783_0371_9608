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
            #region PO המרת הרשימה ל
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
            #endregion
            productCollection = tools.IEnumerableToObserval(poList);
            productForListDataGrid.DataContext = productCollection;
            categorySelector.ItemsSource = Enum.GetValues(typeof(HebCategory));
        }

        #region אירועים
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
            seeDetails.Content=null;
            productWindow AddProduct = new productWindow(addProduct);
            AddProduct.id.Visibility = Visibility.Hidden;
            AddProduct.ShowDialog();
        }

        public void update_Click(object sender, RoutedEventArgs e)
        {
            seeDetails.Content=null;
            PO.ProductForList? poUpPro = (PO.ProductForList)productForListDataGrid.SelectedItem;
            if (poUpPro != null)
            {
                productWindow updateProduct = new productWindow(addProduct, poUpPro);
                updateProduct.ShowDialog();
                var boList = bl!.Product!.getListOfProduct()!;
                #region PO המרת הרשימה ל
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
                #endregion
                productForListDataGrid.DataContext = tools.IEnumerableToObserval(poList); //קישור הרשימה מחדש
            }

        }
      
        public void delete_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("?האם אתה בטוח שברצונך למחוק את המוצר", "", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
            {
                seeDetails.Content=null;
                PO.ProductForList proToDel = (PO.ProductForList)productForListDataGrid.SelectedItem;
                bl!.Product!.deleteProduct(proToDel.ID); //מחיקת המוצר מהנתונים
                var boList = bl!.Product!.getListOfProduct()!;
                #region POהמרת הרשימה ל
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
                #endregion
                productForListDataGrid.DataContext = tools.IEnumerableToObserval(poList); //קישור הרשימה מחדש
            }
        }
        private void seeDetails_DoubleClick(object sender, RoutedEventArgs e)
        {
            PO.ProductForList choose  = (PO.ProductForList)productForListDataGrid.SelectedItem;
           BO.Product Bopro =  bl!.Product!.getProductInfoManager(choose.ID)!;
            PO.Product POpro = new PO.Product()
            {
                ID = Bopro.ID,
                Name = Bopro.Name,
                path = Bopro.path,
                InStock = Bopro.InStock,
                Category = (BO.HebCategory?)Bopro.Category,
                Price = Bopro.Price
            }; //cast to po     
            seeDetails.Content=new productDetailsPage(POpro);
        }

        private void Page_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            seeDetails.Content = null;
        }
        #endregion

        public void addProduct(PO.ProductForList productToAdd) =>
          productCollection?.Add(productToAdd);  //פונקצית הוספה לאובסרבל
    }
}

