using System.ComponentModel;

namespace PL.PO
{
    public class OrderItem : INotifyPropertyChanged
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
        private int _ProductID;
        public int ProductID
        {
            get { return _ProductID; }
            set
            {
                _ProductID = value;
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("ProductID"));
                }
            }
        }
        private string? _ProductName;
        public string? ProductName
        {
            get { return _ProductName; }
            set
            {
                _ProductName = value;
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("ProductName"));
                }
            }
        }
        private double? _Price;
        public double? Price
        {
            get { return _Price; }
            set
            {
                _Price = value;
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("Price"));
                }
            }
        }


        private int _Amount;
        public int Amount
        {
            get { return _Amount; }
            set
            {
                _Amount = value;
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("Amount"));
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
        private string? _path;
        public string? path
        {
            get { return _path; }
            set
            {
                _path = value;
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("path"));
                }
            }
        }
        public event PropertyChangedEventHandler? PropertyChanged;
    }
}
