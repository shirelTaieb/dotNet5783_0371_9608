using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Windows;
using System.Windows.Controls;


namespace PL.Simulator
{

    //    /// <summary>
    //    /// Interaction logic for SimulatorWindow.xaml
    //    /// </summary>
    public partial class SimulatorWindow : Window
    {

        BackgroundWorker Tali;
        //Stopwatch stopwatch = new Stopwatch();
        private BLApi.IBl? bl = BLApi.Factory.Get();
        DateTime time = DateTime.Now;
        List<PO.OrderForList> OrderList = new List<PO.OrderForList>();
        public SimulatorWindow()
        {
            InitializeComponent();
            Tali = new BackgroundWorker();
            Tali.DoWork += Tali_DoWork!;
            Tali.ProgressChanged += Tali_ProgressChanged!;
            Tali.RunWorkerCompleted += Tali_RunWorkerCompleted!;
            Tali.WorkerReportsProgress = true;
            Tali.WorkerSupportsCancellation = true;
            //Random rand = new Random();
            //int argu = rand.Next(5, 10);
            var boList = bl!.Order!.getOrderList();
            OrderList =
           (from or in boList
            select new PO.OrderForList()
            {
                ID = or.ID,
                CustomerName = or.CustomerName,
                AmountOfItems = or.AmountOfItems,
                Status = (BO.HebOrderStatus?)or.Status,
                TotalPrice = or.TotalPrice
            }).ToList();
            orderSimulationList.DataContext = tools.IEnumerableToObserval(OrderList);
        }
        private void Tali_DoWork(object sender, DoWorkEventArgs e)
        {
          
            while (true)
            {
                if (Tali.CancellationPending == true)
                {
                    e.Cancel = true;//?
                    break;
                }
                else
                {
                    if (Tali.WorkerReportsProgress == true)
                    {
                        time = time.AddDays(2);

                        Tali.ReportProgress(5);
                        
                    }
                    Thread.Sleep(2000);
                }
            }
        

            //e.Result = "result"; //כשלחצו סטופ

        }
        private void Tali_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            OrderList.Clear();
            var boList = bl!.Order!.getOrderList();
            OrderList = (from or in boList
                         select new PO.OrderForList()
                         {
                             ID = or.ID,
                             CustomerName = or.CustomerName,
                             AmountOfItems = or.AmountOfItems,
                             Status = (BO.HebOrderStatus?)or.Status,
                             TotalPrice = or.TotalPrice
                         }).ToList(); //קישור הרשימה מחדש
            orderSimulationList.DataContext = tools.IEnumerableToObserval(OrderList);
            // int progress = e.ProgressPercentage;
            foreach (var order in OrderList)
            {
                if ((int)order.Status! == 0)//הוזמן
                {
                    if (bl!.Order!.getOrderInfo(order.ID)!.OrderDate?.AddDays(10) <= time) //צריך כבר לעדכן
                    {
                        bl!.Order!.updateSentOrder(order.ID,time);
                        order.Status = BO.HebOrderStatus.נשלח;
                    }
                }
                else
                {
                    if ((int?)order.Status == 1)//נשלח
                        if (bl!.Order!.getOrderInfo(order.ID)!.ShipDate?.AddDays(10) <= time) //צריך כבר לעדכן
                        {
                            bl!.Order!.updateDeliveryOrder(order.ID,time);
                            order.Status = BO.HebOrderStatus.נמסר;
                        }
                }
        
                //Thread.Sleep(50);

            }
        }
        private void Tali_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
           // object result = e.Result;
        }
        private void start_Click(object sender, RoutedEventArgs e)
        {
            startButton.IsEnabled = false;
            Tali.RunWorkerAsync();
        }
        private void stop_Click(object sender, RoutedEventArgs e)
        {
            if (Tali.WorkerSupportsCancellation == true)
            {
                
                startButton.IsEnabled = true;
                Tali.CancelAsync();
            }
        }
        private void showOrderDetails_doubleClick(object sender, RoutedEventArgs e)
        { 
            
            MessageBox.Show ((bl!.Order!.orderTracking(((PO.OrderForList?)orderSimulationList!.SelectedItem!).ID)).ToString(), "");
        }
    }
}
