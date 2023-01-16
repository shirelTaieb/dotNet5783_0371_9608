using DalApi;
using System.Xml.Linq;

namespace Dal
{
    internal class DalOrder : IOrder
    {
        const string s_orders = "Order"; //the name of the file
        #region
        static IEnumerable<XElement> createOrderElement(DO.Order order)
        {
            yield return new XElement("ID", order.ID);
            if (order.CustomerName is not null)
                yield return new XElement("CustomerName", order.CustomerName);
            if (order.CustomerEmail is not null)
                yield return new XElement("CustomerEmail", order.CustomerEmail);
            if (order.CustomerAddress is not null)
                yield return new XElement("CustomerAddress", order.CustomerAddress);
            if (order.OrderDate is not null)
                yield return new XElement("OrderDate", order.OrderDate);
            if (order.ShipDate is not null)
                yield return new XElement("ShipDate", order.ShipDate);
            if (order.DeliveryDate is not null)
                yield return new XElement("DeliveryDate", order.DeliveryDate);
        }
        #endregion
        #region get order item מקבל אלמנט וממיר לאורדר אייטם
        static DO.Order? getOrder(XElement or)
        {
            if (or.ToIntNullable("ID") == null)
                return null;
            else
                return new DO.Order()
                {
                    ID = (int)or.Element("ID")!,
                    CustomerName = (string)or.Element("CustomerName")!,
                    CustomerEmail = (string)or.Element("CustomerEmail")!,
                    CustomerAddress = (string?)or.Element("CustomerAddress"),
                    OrderDate = (DateTime)or.Element("OrderDate")!,
                    ShipDate = (DateTime)or.Element("ShipDate")!,
                    DeliveryDate = (DateTime)or.Element("DeliveryDate")!
                };
        }
        #endregion
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
        public DO.Order GetById(int id)
        {
            XElement? orderElement = XMLTools.LoadListFromXMLElement(s_orders)?.Elements()
            .FirstOrDefault(pro => pro.ToIntNullable("ID") == id);
            if (orderElement == null)
                throw new NotExistException();
            else
                return (DO.Order)getOrder(orderElement!)!;
        }


        public void Update(DO.Order order)
        {
                Delete(order.ID);
                Add(order);
        }

        public void Delete(int id)
        {
            XElement ordersRoot = XMLTools.LoadListFromXMLElement(s_orders);  //get the root element of the file

            try
            {
                (ordersRoot.Elements()
            .FirstOrDefault(oi => (int?)oi.Element("ID") == id) ?? throw new NotExistException())
            .Remove();
            } //try to remove
            catch { throw new NotExistException(); }
            XMLTools.SaveListToXMLElement(ordersRoot, s_orders);
        }

        public IEnumerable<DO.Order?> GetAll(Func<DO.Order?, bool>? filter = null)
        {
            if (filter == null)
                return XMLTools.LoadListFromXMLElement(s_orders).Elements().Select(o => getOrder(o));
            else
                return XMLTools.LoadListFromXMLElement(s_orders).Elements().Select(o => getOrder(o)).Where(filter);
        }
    }
}
