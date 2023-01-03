using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PL.PO
{
    public class Cart : INotifyPropertyChanged
    {
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
        private string? _CustomerEmail;
        public string? CustomerEmail
        {
            get { return _CustomerEmail; }
            set
            {
                _CustomerEmail = value;
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("CustomerEmail"));
                }
            }
        }
        private string? _CustomerAddress;
        public string? CustomerAddress
        {
            get { return _CustomerAddress; }
            set
            {
                _CustomerAddress = value;
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("CustomerAddress"));
                }
            }
        }
        private  List<PO.OrderItem?>? _Items;
        public  List<PO.OrderItem?>? Items
        {
            get { return _Items; }
            set
            {
                _Items = value;
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("Items"));
                }
            }
        }
        
        public event PropertyChangedEventHandler? PropertyChanged;
    }
}
