
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using BO;
using System.Collections;

namespace PL
{
    public static class tools
    {
        public static ObservableCollection<PO.ProductItem?> IEnumerableToObserval(IEnumerable<PO.ProductItem> listToCast)
        {
            ObservableCollection<PO.ProductItem?> ProductsColllection = new ObservableCollection<PO.ProductItem?>();
            foreach (PO.ProductItem item in listToCast)
                ProductsColllection.Add(item);
            return ProductsColllection;
        }
        public static ObservableCollection<PO.OrderForList> IEnumerableToObserval(IEnumerable<PO.OrderForList> listToCast)
        {
            ObservableCollection<PO.OrderForList> orderCollection = new ObservableCollection<PO.OrderForList>();
            foreach (PO.OrderForList item in listToCast)
                orderCollection.Add(item);
            return orderCollection;
        }
        public static ObservableCollection<PO.ProductForList> IEnumerableToObserval(IEnumerable<PO.ProductForList> listToCast)
        {
            ObservableCollection<PO.ProductForList> productCollection = new ObservableCollection<PO.ProductForList>();
            foreach (PO.ProductForList item in listToCast)
                productCollection.Add(item);
            return productCollection;
        }
        public static ObservableCollection<PO.OrderItem> IEnumerableToObserval(IEnumerable<PO.OrderItem> listToCast)
        {
            ObservableCollection<PO.OrderItem> orderCollection = new ObservableCollection<PO.OrderItem>();
            foreach (PO.OrderItem item in listToCast)
                orderCollection.Add(item);
            return orderCollection;
        }
        #region מתודה שהופכת ישות למחרוזת לצורך הצגת הפרטים
        public static string ToStringProperty<T>(this T t, string suffix = "")
        //מתודה להפיכת ישות למחרוזת לצורך הצגת הפרטים
        {
            string str = "";
            foreach (PropertyInfo prop in t!.GetType().GetProperties())
            {
                var value = prop.GetValue(t, null);
                if (value != null) //if it is null we dont want that it won't be printed
                {
                    if (value is not string && value is IEnumerable)
                    {
                        str = str + "\n" + prop.Name + ":";
                        foreach (var item in (IEnumerable)value)
                            str += item.ToStringProperty("      ");
                    }

                    else
                        str += "\n" + suffix + prop.Name + ": " + value;
                }
            }
            str += "\n";
            return str;
        }
        #endregion

    }
}
