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
        private BO.Product UpdateOrNewProduct=new BO.Product();
        public productWindow(BO.ProductForList? updateProduct=null) //עשינו ברירת מחדל כי תלוי אם רוצים לעדכן או להוסיף
        {
            InitializeComponent();
            categoryComboBox.ItemsSource = Enum.GetValues(typeof(HebCategory));
            
           
            if (updateProduct != null)  //כשרוצים לעדכן
            {
                Add.Visibility = Visibility.Hidden;
                UpdateOrNewProduct = bl!.Product!.getProductInfoManager(updateProduct.ID)!;
                productAddOrUpdate.DataContext = UpdateOrNewProduct;//קישור חלון העדכון לפרודקט שקיבלנו מהרשימה
                //קישור חלון ההוספה למוצר חדש שנוסיף לרשימה
            }
            else  //כשרוצים להוסיף
            {
                Update.Visibility = Visibility.Hidden;
                productAddOrUpdate.DataContext = UpdateOrNewProduct; 
            }
        }
        private void add_click(object sender, RoutedEventArgs e) //לא באמת מוסיףף
        {
            //קריאה לפונקציה שבאמת תוסיף את הפרודקט
            bl!.Product!.addNewProduct(UpdateOrNewProduct);
            MessageBox.Show(":) המוצר נוסף בהצלחה", "");
            this.Close();
        }
        private void update_click(object sender, RoutedEventArgs e)//לא באמת מעדכןןן
        {
            
            bl!.Product!.updateProduct(UpdateOrNewProduct);
            MessageBox.Show(":) המוצר עודכן בהצלחה", "");
            //קריאה לפונקציה שבאמת תעדכן את הפרודקט
            this.Close();
        }

        private void stock_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void categoryComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateOrNewProduct.Category= (BO.Category)categoryComboBox.SelectedItem;

        }
        //private BO.Product castForListToRegular(BO.ProductForList pfl)
        //{
        //    return(new BO.Product { ID=pfl.ID, Category=pfl.Category, Name=pfl.Name, InStock=pfl.In} )
        //}
    }
}
