using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DalApi;
using System.Xml.Linq;

namespace Dal
{
    internal class DalOrder:IOrder
    {
        const string s_orders = "orders";
        public int Add(DO.Order order)
        {
            XElement ordersRootElem = XMLTools.LoadListFromXMLElement(s_orders);

            if (XMLTools.LoadListFromXMLElement(s_orders)?.Elements()
                .FirstOrDefault(st => st.ToIntNullable("ID") == order.ID) is not null)
                // fix to: throw new DalMissingIdException(id);;
                throw new Exception("id already exist");

            ordersRootElem.Add(new XElement("Order", createStudentElement(order)));
            XMLTools.SaveListToXMLElement(ordersRootElem, s_orders);

            return order.ID; ;
        }
    }
}
