using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Diagnostics;
using System.Threading;
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

    //    /// <summary>
    //    /// Interaction logic for SimulatorWindow.xaml
    //    /// </summary>
    public partial class SimulatorWindow : Window
    {
       
        BackgroundWorker Tali;
        private BLApi.IBl? bl = BLApi.Factory.Get();
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
            //Tali.RunWorkerAsync(argu);

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
        private void Tali_DoWork(object sender, DoWorkEventArgs e)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            while(true)
            {
                if (Tali.CancellationPending == true)
                {
                    e.Cancel = true;//?
                    break;
                }
                else
                {
                    Thread.Sleep(2000);
                    if (Tali.WorkerReportsProgress == true)
                        Tali.ReportProgress(3); //כמה זמן להוסיף
                }
            }

            e.Result = "result"; //כשלחצו סטופ

        }
        private void Tali_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
           // int progress = e.ProgressPercentage;


        }
        private void Tali_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            object result = e.Result;
        }


    }
    }
