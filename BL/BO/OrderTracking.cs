using BL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BO
{
    public class OrderTracking
    {
        public int ID { get; set; }
        public OrderStatus? Status { get; set; }
        public List<Tuple< string,DateTime?>?>? Tracking { get; set; }
        public override string ToString() => this.ToStringProperty();
    }
}
