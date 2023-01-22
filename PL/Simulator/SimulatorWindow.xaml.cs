using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Windows;


namespace PL.Simulator
{

    //    /// <summary>
    //    /// Interaction logic for SimulatorWindow.xaml
    //    /// </summary>
    public partial class SimulatorWindow : Window
    {

        BackgroundWorker Tali;
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
            Tali.RunWorkerAsync();
            OrderList =
           (from or in bl!.Order!.getOrderList()
            select new PO.OrderForList()
            {
                ID = or.ID,
                CustomerName = or.CustomerName,
                AmountOfItems = or.AmountOfItems,
                Status = (BO.HebOrderStatus?)or.Status,
                TotalPrice = or.TotalPrice
            }).ToList();
            orderSimulationList.DataContext = OrderList;
        }
        private void Tali_DoWork(object sender, DoWorkEventArgs e)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
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
                        Tali.ReportProgress(5);
                        time = time.AddDays(3);
                    }
                    Thread.Sleep(2000);
                }
            }

            e.Result = "result"; //כשלחצו סטופ

        }
        private void Tali_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            // int progress = e.ProgressPercentage;
            for (int i = 0; i < OrderList.Count; i++)
            {
                if ((int)OrderList[i].Status! == 0)//הוזמן
                {
                    if (bl!.Order!.getOrderInfo(OrderList[i].ID)!.OrderDate?.AddDays(10) <= time) //צריך כבר לעדכן
                        bl!.Order!.updateSentOrder(OrderList[i].ID);
                }
                else
                {
                    if ((int?)OrderList[i].Status == 1)//נשלח
                        if (bl!.Order!.getOrderInfo(OrderList[i].ID)!.ShipDate?.AddDays(10) <= time) //צריך כבר לעדכן
                            bl!.Order!.updateDeliveryOrder(OrderList[i].ID);
                }

                OrderList = (from or in bl!.Order!.getOrderList()
                             select new PO.OrderForList()
                             {
                                 ID = or.ID,
                                 CustomerName = or.CustomerName,
                                 AmountOfItems = or.AmountOfItems,
                                 Status = (BO.HebOrderStatus?)or.Status,
                                 TotalPrice = or.TotalPrice
                             }).ToList(); //קישור הרשימה מחדש
                orderSimulationList.DataContext =OrderList;
                Thread.Sleep(50);
            }


        }
        private void Tali_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            object result = e.Result;
        }


    }
}
