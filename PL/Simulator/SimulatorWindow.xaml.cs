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
using System.ComponentModel;


namespace PL.Simulator
{
   // BackgroundWorker worker;
    /// <summary>
    /// Interaction logic for SimulatorWindow.xaml
    /// </summary>
    public partial class SimulatorWindow : Window
    {
        private BLApi.IBl? bl = BLApi.Factory.Get();
        public SimulatorWindow()
        {
            InitializeComponent();
            //worker = new BackgroundWorker();
            //worker.DoWork += Worker_DoWork;
            //worker.ProgressChanged += Worker_ProgressChanged;
            //worker.RunWorkerCompleted += Worker_RunWorkerCompleted;

            //worker.WorkerReportsProgress = true;
            //worker.RunWorkerAsync("argument");


            orderSimulationList.DataContext =
                from or in bl!.Order!.getOrderList()
                select new PO.OrderForList()
                {
                    ID = or.ID,
                    CustomerName = or.CustomerName,
                    AmountOfItems = or.AmountOfItems,
                    Status = (BO.HebOrderStatus?)or.Status,
                    TotalPrice = or.TotalPrice
                };
        }
    }
}
