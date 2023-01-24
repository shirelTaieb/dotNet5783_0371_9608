﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Windows;


namespace PL.PO
{
    public class Product : INotifyPropertyChanged
    {

        #region ID
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
        #endregion

        #region name
        private string? _Name;
        public string? Name
        {
            get { return _Name; }
            set
            {
                _Name = value;
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("Name"));
                }
            }
        }
        #endregion

        #region amount in stock
        private int _InStock;
        public int InStock
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
        #endregion

        #region category
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
        #endregion

        #region price
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
        #endregion

        #region path
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
        #endregion

        public event PropertyChangedEventHandler? PropertyChanged;
    }
}
 

