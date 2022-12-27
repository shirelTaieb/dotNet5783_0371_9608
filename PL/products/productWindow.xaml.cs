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

        public productWindow(BO.ProductForList? updateProduct=null) //עשינו ברירת מחדל כי תלוי אם רוצים לעדכן או להוסיף
        {
            InitializeComponent();
            categoryComboBox.ItemsSource = Enum.GetValues(typeof(HebCategory));
            productAddOrUpdate.DataContext = updateProduct; //קישור חלון העדכון לפרודקט שקיבלנו מהרשימה
            if (updateProduct != null)  //כשרוצים לעדכן
                Add.Visibility = Visibility.Hidden;
            else  //כשרוצים להוסיף
                Update.Visibility = Visibility.Hidden;
        }
        private void add_click(object sender, RoutedEventArgs e) //לא באמת מוסיףף
        {
            //קריאה לפונקציה שבאמת תוסיף את הפרודקט
            BO.Product newProduct=new BO.Product();
            Add.DataContext = newProduct;
            bl!.Product!.addNewProduct(newProduct); 
            MessageBox.Show(":) המוצר נוסף בהצלחה", "");
            this.Close();
        }
        private void update_click(object sender, RoutedEventArgs e)//לא באמת מעדכןןן
        {
            BO.Product newProduct = new BO.Product();
            Update.DataContext = newProduct;
            bl!.Product!.updateProduct(newProduct);
            MessageBox.Show(":) המוצר עודכן בהצלחה", "");
            //קריאה לפונקציה שבאמת תעדכן את הפרודקט
            this.Close();
        }

        private void stock_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void categoryComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
           
        }
    }
}
