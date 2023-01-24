 //בס"ד
using BO;
using System;
using System.Net.NetworkInformation;
using System.Windows;
using System.Windows.Controls;
using BLApi;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Media.Imaging;

namespace PL.products
{
    /// <summary>
    /// Interaction logic for productWindow.xaml
    /// </summary>
    
    public partial class productWindow : Window
    {
        private BLApi.IBl? bl = BLApi.Factory.Get();
        private PO.Product pl = new PO.Product();
        private BO.Product UpdateOrNewProduct = new BO.Product();
        Action<PO.ProductForList> addAction;
        string? path;
        PO.ProductForList toDell=new PO.ProductForList();
        
        public productWindow( Action<PO.ProductForList> addToObservalCollection, PO.ProductForList? updateProduct = null) //עשינו ברירת מחדל כי תלוי אם רוצים לעדכן או להוסיף
        {
            InitializeComponent();
            categoryComboBox.ItemsSource = Enum.GetValues(typeof(HebCategory)); //קישור הקטגוריות לכומבו בוקס
            addAction = addToObservalCollection;
            #region פתיחת החלונות המתאימים
            if (updateProduct != null)  //כשרוצים לעדכן
            {
                Add.Visibility = Visibility.Hidden;
                try
                {
                    UpdateOrNewProduct = bl!.Product!.getProductInfoManager(updateProduct.ID)!;
                    pl = BoToPo(UpdateOrNewProduct);  //casting to po
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
            #endregion
        }
        #region המרות
        public PO.Product BoToPo(BO.Product Bopro)
        {
            PO.Product p = new PO.Product();
            p.ID = Bopro.ID;
            p.Name = Bopro.Name;
            p.path = Bopro.path;
            p.InStock = Bopro.InStock;
            p.Category = (BO.HebCategory?)Bopro.Category;
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
        #endregion

        #region אירועי כפתורים 
        private void add_click(object sender, RoutedEventArgs e)
        {
            pl.path = path;
            UpdateOrNewProduct = PoToBo(pl);

            //קריאה לפונקציה שבאמת תוסיף את הפרודקט
            int id = bl!.Product!.addNewProduct(UpdateOrNewProduct);
            try
            {
                addAction(new PO.ProductForList()
                {
                    ID = id,
                    Name = UpdateOrNewProduct.Name,
                    Category = (BO.HebCategory?)UpdateOrNewProduct.Category,
                    Price = UpdateOrNewProduct.Price,
                }); //קריאה לפונקציה שמוסיפה ישר לאובסרברל כולקשיין
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
                if (path!=null)   //אם אכן התקבלה תמונה חדשה
                    pl.path = path;           
                UpdateOrNewProduct = PoToBo(pl);
                bl!.Product!.updateProduct(UpdateOrNewProduct);  //קריאה לפונקציה שבאמת תעדכן את הפרודקט
                MessageBox.Show(":) המוצר עודכן בהצלחה", ""); 
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        private void categoryComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            pl.Category = (BO.HebCategory)categoryComboBox.SelectedItem;

        }
        private void updateImage_Button(object sender, RoutedEventArgs e)// עדכון
        {
            Microsoft.Win32.OpenFileDialog f = new Microsoft.Win32.OpenFileDialog();
            f.Filter = "Image Files(*.jpeg; *.jpg; *.png; *.gif; *.bmp)|*.jpeg; *.jpg; *.png; *.gif; *.bmp"; 
            if (f.ShowDialog() == true)
            {
              
                product_image.Source = new BitmapImage(new Uri(f.FileName));
                String[] strlist = product_image.Source.ToString().Split("PL", 2,
                       StringSplitOptions.RemoveEmptyEntries);
                path = strlist[1];
            }

        }
        #endregion
    }





}
