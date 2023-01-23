using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tempo
{
    public enum HebOrderStatus { הוזמן, נשלח, נמסר };

    public class OrderForList
    {
        public int ID { get; set; }
        public string CustomerName { get; set; }
        public HebOrderStatus Status { get; set; }
        public int AmountOfItems { get; set; }
        public double TotalPrice { get; set; }

    }
}
