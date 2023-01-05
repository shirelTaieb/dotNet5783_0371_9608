//בס"ד
using BLApi;
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
using System.Windows.Shapes;

namespace PL.products
{
    /// <summary>
    /// Interaction logic for productWindow.xaml
    /// </summary>
    public partial class productWindow : Window
    {
        private BLApi.IBl? bl = BLApi.Factory.Get();
        private PO.Product pl=new PO.Product();
        private BO.Product UpdateOrNewProduct=new BO.Product();
        Action<PO.ProductForList> action;
        public productWindow(int ShowDetails, Action<PO.ProductForList> addToObservalCollection, PO.ProductForList? updateProduct = null) //עשינו ברירת מחדל כי תלוי אם רוצים לעדכן או להוסיף
        {
            InitializeComponent();
            categoryComboBox.ItemsSource = Enum.GetValues(typeof(HebCategory)); //קישור הקטגוריות לכומבו בוקס
            action = addToObservalCollection;


            if (updateProduct != null)  //כשרוצים לעדכן
            {
                Add.Visibility = Visibility.Hidden;
                try
                {
                    UpdateOrNewProduct = bl!.Product!.getProductInfoManager(updateProduct.ID)!;
                    pl = BoToPo(UpdateOrNewProduct);  //casting to po
                    if (ShowDetails == 1) //לפתוח קובץ לקריאה בלבד
                        productFrame.Content = new productDetailsPage(pl);
                     productAddOrUpdate.DataContext = pl;//קישור חלון העדכון לפרודקט שקיבלנו מהרשימה
                  
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else  //כשרוצים להוסיף
            {
                Update.Visibility = Visibility.Hidden;
                productAddOrUpdate.DataContext = pl;  //קישור חלון ההוספה למוצר חדש שנוסיף לרשימה

            }
        }
        private PO.Product BoToPo(BO.Product Bopro)
        {
            PO.Product p = new PO.Product();
            p.ID = Bopro.ID;
            p.Name = Bopro.Name;
            p.path = Bopro.path;
            p.InStock = Bopro.InStock;
            p.Category =(BO.HebCategory?)Bopro.Category;
            p.Price = Bopro.Price;
            return p;

        }
        private BO.Product PoToBo(PO.Product popro)
        {
            BO.Product po = new BO.Product();
            po.ID = popro.ID;
            po.Name = popro.Name;
            po.path = popro.path;
            po.InStock = popro.InStock;
            po.Category = (BO.Category?)popro.Category;
            po.Price = popro.Price;
            return po;
        }
            
        private void add_click(object sender, RoutedEventArgs e)
        {
            UpdateOrNewProduct = PoToBo(pl);
       
            //קריאה לפונקציה שבאמת תוסיף את הפרודקט
            int id=bl!.Product!.addNewProduct(UpdateOrNewProduct);
            try
            {
                action(new PO.ProductForList()
                {
                    ID = id,
                    Name = UpdateOrNewProduct.Name,
                    Category = (BO.HebCategory?)UpdateOrNewProduct.Category,
                    Price = UpdateOrNewProduct.Price,
                });
                MessageBox.Show(":) המוצר נוסף בהצלחה", "");
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        private void update_click(object sender, RoutedEventArgs e)
        {
            try
            {
                UpdateOrNewProduct = PoToBo(pl);
            bl!.Product!.updateProduct(UpdateOrNewProduct);
           
            MessageBox.Show(":) המוצר עודכן בהצלחה", "");
            //קריאה לפונקציה שבאמת תעדכן את הפרודקט
            this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void stock_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void categoryComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            pl.Category= (BO.HebCategory)categoryComboBox.SelectedItem;

        }

        private void toEdit_Click(object sender, RoutedEventArgs e)
        {
            productFrame.Content = null;//העברה לחלון הרגיל של עדכון
        }

       
        //private BO.Product castForListToRegular(BO.ProductForList pfl)
        //{
        //    return(new BO.Product { ID=pfl.ID, Category=pfl.Category, Name=pfl.Name, InStock=pfl.In} )
        //}

    }
}
