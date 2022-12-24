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
        public productWindow(BO.ProductForList? updateProduct=null) //עשינו ברירת מחדל כי תלוי אם רוצים לעדכן או להוסיף
        {
            InitializeComponent();
            //categoryComboBox.ItemsSource = Enum.GetValues(typeof(Category));
            productAddOrUpdate.DataContext = updateProduct; //קישור חלון העדכון לפרודקט שקיבלנו מהרשימה
            if (updateProduct != null)  //כשרוצים לעדכן
                Add.Visibility = Visibility.Hidden;
            else  //כשרוצים להוסיף
                Update.Visibility = Visibility.Hidden;
        }
        private void add_click(object sender, RoutedEventArgs e)
        {
            //קריאה לפונקציה שבאמת תוסיף את הפרודקט
            BO.Product newProduct=new BO.Product();
            productAddOrUpdate.DataContext = newProduct;
            //bl.addNewProduct(newProduct); //איך הוא אמור להכיר את bl?
            MessageBox.Show(":) המוצר נוסף בהצלחה", "");
            this.Close();
        }
        private void update_click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(":) המוצר עודכן בהצלחה", "");
            //קריאה לפונקציה שבאמת תעדכן את הפרודקט
            this.Close();
        }

        private void stock_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
