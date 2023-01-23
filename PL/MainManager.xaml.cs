using PL.orders;
using PL.products;
using PL.Simulator;
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

namespace PL
{
    /// <summary>
    /// Interaction logic for MainManager.xaml
    /// </summary>
    public partial class MainManager : Page
    {
        MainWindow mainWindow;
        public MainManager(MainWindow Window)
        {
            InitializeComponent();
            mainWindow = Window;
            Window.returnManager.Visibility = Visibility.Collapsed;
        }
        public void products_Click(object o, RoutedEventArgs e)
        {

            mainWindow.frame.Content = new ProductListPage(mainWindow);


        }
        public void orders_Click(object o, RoutedEventArgs e)
        {

           mainWindow.frame.Content = new orderListPage(mainWindow);

        }
        private void ManagerTrack_Click(object sender, RoutedEventArgs e)
        {
            EnterIdForTrackingWindow enterID = new EnterIdForTrackingWindow(0);
            enterID.ShowDialog();
        }

        private void closeOptions_Click(object sender, RoutedEventArgs e) //אין לו עניין
        {
            mainWindow.frame.Content = null;
            
            //startManager.Visibility = Visibility.Visible;
            //optionManager.Visibility = Visibility.Hidden;
        }
        private void simulator_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("?האם אתה בטוח שברצונך להפעיל את הסימולטור", "", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                SimulatorWindow simuWindow = new SimulatorWindow();
                simuWindow.Show();
            }
        }
    }
}
