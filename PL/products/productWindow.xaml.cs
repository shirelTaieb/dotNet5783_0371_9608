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
        Action<PO.ProductForList> removeAction;
        public productWindow(int ShowDetails, Action<PO.ProductForList> addToObservalCollection, Action<PO.ProductForList> removeFromObserval, PO.ProductForList? updateProduct = null) //עשינו ברירת מחדל כי תלוי אם רוצים לעדכן או להוסיף
        {
            InitializeComponent();
            categoryComboBox.ItemsSource = Enum.GetValues(typeof(HebCategory)); //קישור הקטגוריות לכומבו בוקס
            addAction = addToObservalCollection;
            removeAction=removeFromObserval;

            if (updateProduct != null)  //כשרוצים לעדכן
            {
                Add.Visibility = Visibility.Hidden;
                try
                {

                    UpdateOrNewProduct = bl!.Product!.getProductInfoManager(updateProduct.ID)!;
                    pl = BoToPo(UpdateOrNewProduct);  //casting to po
                    toDell = poProTpPoProForList(pl);  //for update
                    if (ShowDetails == 1) //לפתוח קובץ לקריאה בלבד
                        productFrame.Content = new productDetailsPage(pl);
                    else
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
        private PO.ProductForList poProTpPoProForList(PO.Product pro)
        {
            PO.ProductForList p = new PO.ProductForList();  
            p.ID=pro.ID;
            p.path=pro.path;    
            p.Price=pro.Price;  
            p.Category=pro.Category;    
            p.Name=pro.Name;
            return p;
        }

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
                if (path!=null)
                    pl.path = path;
                UpdateOrNewProduct = PoToBo(pl);
                bl!.Product!.updateProduct(UpdateOrNewProduct);
                PO.ProductForList popro = new PO.ProductForList()
                {
                    ID = UpdateOrNewProduct.ID,
                    Name = UpdateOrNewProduct.Name,
                    Category = (BO.HebCategory?)UpdateOrNewProduct.Category,
                    Price = UpdateOrNewProduct.Price
                };

                removeAction(toDell);
                addAction(popro);
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
            pl.Category = (BO.HebCategory)categoryComboBox.SelectedItem;

        }

        private void toEdit_Click(object sender, RoutedEventArgs e)
        {
            productFrame.Content = null;//העברה לחלון הרגיל של עדכון
            productAddOrUpdate.DataContext = pl;//קישור חלון העדכון לפרודקט שקיבלנו מהרשימה
        }



        private void updateImage_Button(object sender, RoutedEventArgs e)// עדכון
        {
            Microsoft.Win32.OpenFileDialog f = new Microsoft.Win32.OpenFileDialog();
          f.Filter = "Image Files(*.jpeg; *.jpg; *.png; *.gif; *.bmp)|*.jpeg; *.jpg; *.png; *.gif; *.bmp"; 
           // f.Filter = "All Images Files (*.png;*.jpeg;*.gif;*.jpg;*.bmp;*.tiff;*.tif)|*.png;*.jpeg;*.gif;*.jpg;*.bmp;*.tiff;*.tif" +
           //"|PNG Portable Network Graphics (*.png)|*.png" +
           //"|JPEG File Interchange Format (*.jpg *.jpeg *jfif)|*.jpg;*.jpeg;*.jfif" +
           //"|BMP Windows Bitmap (*.bmp)|*.bmp" +
           //"|TIF Tagged Imaged File Format (*.tif *.tiff)|*.tif;*.tiff" +
           //"|GIF Graphics Interchange Format (*.gif)|*.gif";
            if (f.ShowDialog() == true)
            {
              
                product_image.Source = new BitmapImage(new Uri(f.FileName));
                String[] spearator = { "PL" };
                Int32 count = 2;
                // using the method
                String[] strlist = product_image.Source.ToString().Split(spearator, count,
                       StringSplitOptions.RemoveEmptyEntries);
                path = strlist[1];
               
                
            }

        }
    }
 

 


}
