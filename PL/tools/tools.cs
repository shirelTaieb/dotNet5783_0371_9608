using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
