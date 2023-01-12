using DalApi;
using System.Xml.Linq;

namespace Dal
{
    internal class DalOrder : IOrder
    {
        const string s_orders = "orders";
        static IEnumerable<XElement> createOrderElement(DO.Order order)
        {
            yield return new XElement("ID", order.ID);
            if (order.FirstName is not null)
                yield return new XElement("FirstName", student.FirstName);
            if (student.LastName is not null)
                yield return new XElement("LastName", student.LastName);
            if (student.StudentStatus is not null)
                yield return new XElement("StudentStatus", student.StudentStatus);
            if (student.BirthDate is not null)
                yield return new XElement("BirthDate", student.BirthDate);
            if (student.LastName is not null)
                yield return new XElement("Grade", student.Grade);
        }
        public int Add(DO.Order order)
        {
            XElement ordersRoot = XMLTools.LoadListFromXMLElement(s_orders);

            XElement? temp = XMLTools.LoadListFromXMLElement(s_orders)?.Elements().FirstOrDefault(st => st.ToIntNullable("ID") == order.ID);
            if (temp != null)
                throw new doubleException();
            else
                 if (order.ID <= 1000 || order.ID >= 9999) //the id isnt valid
                     order.ID = XMLTools.ConfigOrder.getNumber(); //get a run number
            ordersRoot.Add(new XElement("Order", createOrderElement(order)));
            XMLTools.SaveListToXMLElement(ordersRoot, s_orders); //to return to the xml

            return order.ID; 
        }
    }
}
