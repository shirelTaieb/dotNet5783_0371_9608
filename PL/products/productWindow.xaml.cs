using BLApi;
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
        public productWindow(IBl? bl)
        {
            InitializeComponent();
        }
        private void add_click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(":) המוצר נוסף בהצלחה", "");
            //קריאה לפונקציה שבאמת תוסיף את הפרודקט
            BO.Product newProduct=new BO.Product();
            

        }
        private void update_click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(":) המוצר עודכן בהצלחה", "");
            //קריאה לפונקציה שבאמת תעדכן את הפרודקט
        }

    }
}
