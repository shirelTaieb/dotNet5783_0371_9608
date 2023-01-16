﻿//בס"ד
using BO;
using System;
using System.Windows;
using System.Windows.Controls;

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
        Action<PO.ProductForList> removeAction;
        public productWindow(int ShowDetails, Action<PO.ProductForList> addToObservalCollection, /*Action<PO.ProductForList> removeFromObserval,*/ PO.ProductForList? updateProduct = null) //עשינו ברירת מחדל כי תלוי אם רוצים לעדכן או להוסיף
        {
            InitializeComponent();
            categoryComboBox.ItemsSource = Enum.GetValues(typeof(HebCategory)); //קישור הקטגוריות לכומבו בוקס
            addAction = addToObservalCollection;
           // removeAction=removeFromObserval;

            if (updateProduct != null)  //כשרוצים לעדכן
            {
                Add.Visibility = Visibility.Hidden;
                try
                {
                    UpdateOrNewProduct = bl!.Product!.getProductInfoManager(updateProduct.ID)!;
                    pl = BoToPo(UpdateOrNewProduct);  //casting to po
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

        private void add_click(object sender, RoutedEventArgs e)
        {
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
                UpdateOrNewProduct = PoToBo(pl);
                bl!.Product!.updateProduct(UpdateOrNewProduct);
                PO.ProductForList popro=new PO.ProductForList()
                {
                    ID = UpdateOrNewProduct.ID,
                    Name = UpdateOrNewProduct.Name,
                    Category = (BO.HebCategory?)UpdateOrNewProduct.Category,
                    Price = UpdateOrNewProduct.Price,
                };
                
               // removeAction(popro);
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

        private void productFrame_Navigated(object sender, System.Windows.Navigation.NavigationEventArgs e)
        {

        }

        //private BO.Product castForListToRegular(BO.ProductForList pfl)
        //{
        //    return(new BO.Product { ID=pfl.ID, Category=pfl.Category, Name=pfl.Name, InStock=pfl.In} )
        //}

    }
    //private void ChangeImageButton_Click(object sender, RoutedEventArgs e)\\ עדכון
    //{
    //    Microsoft.Win32.OpenFileDialog f = new Microsoft.Win32.OpenFileDialog();
    //    //f.Filter = "All Files| *.*";
    //    f.Filter = "All Images Files (*.png;*.jpeg;*.gif;*.jpg;*.bmp;*.tiff;*.tif)|*.png;*.jpeg;*.gif;*.jpg;*.bmp;*.tiff;*.tif" +
    //    "|PNG Portable Network Graphics (*.png)|*.png" +
    //    "|JPEG File Interchange Format (*.jpg *.jpeg *jfif)|*.jpg;*.jpeg;*.jfif" +
    //    "|BMP Windows Bitmap (*.bmp)|*.bmp" +
    //    "|TIF Tagged Imaged File Format (*.tif *.tiff)|*.tif;*.tiff" +
    //    "|GIF Graphics Interchange Format (*.gif)|*.gif";
    //    if (f.ShowDialog() == true)
    //    {
    //        ProductImage.Source = new BitmapImage(new Uri(f.FileName));
    //        path = (ProductImage.Source).ToString();
    //    }
    //}

    //private void changeImageButton_Click(object sender, RoutedEventArgs e) \\ הוספה
    //{
    //    Microsoft.Win32.OpenFileDialog f = new Microsoft.Win32.OpenFileDialog();
    //    //f.Filter = "All Files| *.*";
    //    f.Filter = "All Images Files (*.png;*.jpeg;*.gif;*.jpg;*.bmp;*.tiff;*.tif)|*.png;*.jpeg;*.gif;*.jpg;*.bmp;*.tiff;*.tif" +
    //    "|PNG Portable Network Graphics (*.png)|*.png" +
    //    "|JPEG File Interchange Format (*.jpg *.jpeg *jfif)|*.jpg;*.jpeg;*.jfif" +
    //    "|BMP Windows Bitmap (*.bmp)|*.bmp" +
    //    "|TIF Tagged Imaged File Format (*.tif *.tiff)|*.tif;*.tiff" +
    //    "|GIF Graphics Interchange Format (*.gif)|*.gif";
    //    if (f.ShowDialog() == true)
    //    {
    //        ProductImage.Source = new BitmapImage(new Uri(f.FileName));
    //        path = (ProductImage.Source).ToString();
    //    }
    //}


}
