using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PL.PO
{

    public class ProductItem : INotifyPropertyChanged
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

        private string? _Name;
        public string? Name
        {
            get { return _Name;}
            set
            {
                _Name = value;
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("CustomerName"));
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
        private BO.HebCategory? _Category;
        public BO.HebCategory? Category
        {
            get { return _Category; }
            set
            {
                _Category = value;
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("Category"));
                }
            }
        }
        private int _AmountInCart;
        public int AmountInCart
        {
            get { return _AmountInCart; }
            set
            {
                _AmountInCart = value;
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("AmountInCart"));
                }
            }
        }
        private bool _InStock;
        public bool InStock
        {
            get { return _InStock; }
            set
            {
                _InStock = value;
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("InStock"));
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
