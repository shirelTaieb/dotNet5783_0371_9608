using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PL.PO
{
    public class OrderForList : INotifyPropertyChanged
    {
        private int _ID;
        public int ID
        {
            get { return _ID; }
            set
            {
               _ID = value;
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("ID"));
                }
            }
        }
        private string? _CustomerName;
        public string? CustomerName
        {
            get { return _CustomerName; }
            set
            {
                _CustomerName = value;
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("CustomerName"));
                }
            }
        }
        private BO.HebOrderStatus? _Status;
        public  BO.HebOrderStatus? Status
        {
            get { return _Status; }
            set
            {
                _Status = value;
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("Status"));
                }
            }
        }
        private int _AmountOfItems;
        public int AmountOfItems
        {
            get { return _AmountOfItems; }
            set
            {
                _AmountOfItems = value;
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("AmountOfItems"));
                }
            }
        }
        private double? _TotalPrice;
        public double? TotalPrice
        {
            get { return _TotalPrice; }
            set
            {
                _TotalPrice = value;
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("TotalPrice"));
                }
            }
        }
        public event PropertyChangedEventHandler? PropertyChanged;
    }
}

