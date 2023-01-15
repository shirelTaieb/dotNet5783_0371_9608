using DalApi;
using System.Xml.Linq;

namespace Dal
{
    internal class DalOrder : IOrder
    {
        const string s_orders = "Orders"; //the name of the file
        static IEnumerable<XElement> createOrderElement(DO.Order order)
        {
            yield return new XElement("ID", order.ID);
            if (order.CustomerName is not null)
                yield return new XElement("FirstName", order.CustomerName);
            if (order.CustomerEmail is not null)
                yield return new XElement("LastName", order.CustomerEmail);
            if (order.CustomerAddress is not null)
                yield return new XElement("StudentStatus", order.CustomerAddress);
            if (order.OrderDate is not null)
                yield return new XElement("BirthDate", order.OrderDate);
            if (order.ShipDate is not null)
                yield return new XElement("Grade", order.ShipDate);
            if (order.DeliveryDate is not null)
                yield return new XElement("Grade", order.DeliveryDate);

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
    //    public Order GetById(int id)
    //    {
    //        if (ds == null)
    //            throw new NotExistException();
    //        Order? or = ds.lstO.FirstOrDefault(ord => ord?.ID == id);
    //        if (or == null)
    //            throw new NotExistException(); //there in no order matched in the database
    //        return (Order)or;
    //    }
    //    public void Update(Order order)
    //    {
    //        if (ds == null)
    //            throw new NotExistException();
    //        var temp = ds.lstO.FirstOrDefault(ord => ord?.ID == order.ID);
    //        if (temp != null)
    //        {
    //            Delete(order.ID);
    //            Add(order);
    //        }
    //    }
    //    public void Delete(int id)
    //    {
    //        if (ds == null)
    //            throw new NotExistException();
    //        try { ds.lstO.Remove(GetById(id)); }
    //        catch { throw new NotExistException(); }
    //    }

    //    public IEnumerable<Order?> GetAll(Func<Order?, bool>? filter = null)
    //    {
    //        if (ds == null)
    //            throw new NotExistException();
    //        if (filter != null)
    //        {
    //            var result =
    //                from item in ds!.lstO
    //                where filter!(item)
    //                select item;
    //            return result.ToList();
    //        }
    //        return ds.lstO;
    //    }
    //}
}
