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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PL.products
{
    /// <summary>
    /// Interaction logic for productDetailsPage.xaml
    /// </summary>
    public partial class productDetailsPage : Page
    {
        public productDetailsPage(PO.Product product)
        {
            InitializeComponent();
            Details.DataContext = product;
            category.DataContext=product.Category;

        }
    }
}
