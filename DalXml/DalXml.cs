using DalApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Dal
{
    sealed internal class DalXml:IDal
    {
        public static  DalXml Instance { get; } = new DalXml();
        private DalXml() { }
        public IProduct Product { get; } = new DalProduct();
        public IOrder Order { get; } = new DalOrder();
        public IOrderItem OrderItem { get; } = new DalOrderItem();

    }
}
