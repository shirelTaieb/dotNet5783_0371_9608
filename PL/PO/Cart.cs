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
        #region customer Name
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
        #endregion

        #region total price
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
        #endregion

        #region customer Email
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
        #endregion

        #region customer Address
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
        #endregion

        #region Items
        private List<PO.OrderItem?>? _Items;
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
        #endregion


        public event PropertyChangedEventHandler? PropertyChanged;
    }
}
