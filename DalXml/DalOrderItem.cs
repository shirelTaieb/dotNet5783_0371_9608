using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using DalApi;

namespace Dal
{
    internal class DalOrderItem:IOrderItem
    {
        const string s_orderItems = "OrderItem"; //the name of the file

        #region createOrderItemElement מקבל אורדר אייטם ומחזיר אלמנט
        static IEnumerable<XElement> createOrderItemElement(DO.OrderItem orit)
        {
            yield return new XElement("ID", orit.ID);
            yield return new XElement("ProductID", orit.ProductID);
            yield return new XElement("ProductName", orit.ProductName);
            yield return new XElement("OrderID", orit.OrderID);
            if (orit.Price != null)
                yield return new XElement("Price", orit.Price);
            yield return new XElement("Amount", orit.Amount);
        }
        #endregion

        #region get order item מקבל אלמנט וממיר לאורדר אייטם
        static DO.OrderItem? getOrderItem(XElement oi)
        {
            if (oi.ToIntNullable("ID") == null)
                return null;
            else
                return new DO.OrderItem()
                {
                    ID = (int)oi.Element("ID")!,
                    ProductID = (int)oi.Element("ProductID")!,
                    ProductName = (string?)oi.Element("ProductName"),
                    OrderID = (int)oi.Element("OrderID")!,
                    Price = (double?)oi.Element("Price"),
                    Amount = (int)oi.Element("Amount")!
                };
        }
        #endregion

        #region פונקציה מוסיפה פריט בהזמנה לאקסמל ומחזירה את המספר המזהה שהעניקה לו
        public int Add(DO.OrderItem oi)
        {
            XElement orderItemsRoot = XMLTools.LoadListFromXMLElement(s_orderItems);

            XElement? temp = XMLTools.LoadListFromXMLElement(s_orderItems)?.Elements().FirstOrDefault(or => or.ToIntNullable("ID") == oi.ID);
            if (temp != null)
                throw new doubleException();
            else
                if (oi.ID <= 1000 || oi.ID >= 9999) //the id isnt valid
                     oi.ID = XMLTools.ConfigOrderItem.getNumber(); //get a run number
            orderItemsRoot.Add(new XElement("OredrItem", createOrderItemElement(oi)));
            XMLTools.SaveListToXMLElement(orderItemsRoot, s_orderItems); // return to the xml
            return oi.ID;
        }
        #endregion

        #region פונקציה מקבלת מספר מזהה של הזמנה במוצר ומחזירה את הפריט
        public DO.OrderItem GetById(int id)
        {
            XElement? orderItemElement = XMLTools.LoadListFromXMLElement(s_orderItems)?.Elements()
            .FirstOrDefault(pro => pro.ToIntNullable("ID") == id);
            if (orderItemElement == null) //there is no match product
                throw new NotExistException();
            else
                return (DO.OrderItem)getOrderItem(orderItemElement!)!; //return the orderItem
        }
        #endregion

        #region פונקציה מוחקת 
        public void Delete(int id)
        {
            XElement orderItemsRoot = XMLTools.LoadListFromXMLElement(s_orderItems);  //get the root element of the file

            try
            {
                (orderItemsRoot.Elements()
            .FirstOrDefault(or => (int?)or.Element("ID") == id) ?? throw new NotExistException())
            .Remove();
            } //try to remove
            catch { throw new NotExistException(); }
            XMLTools.SaveListToXMLElement(orderItemsRoot, s_orderItems); //save the orderItems after the deleting
        }
        #endregion

        #region פונקציה מעדכנת
        public void Update(DO.OrderItem orit)
        {
            Delete(orit.ID);
            Add(orit);
        }
        #endregion

        #region מחזירה אוסף של פרטי ההזמנה
        public IEnumerable<DO.OrderItem?> GetAll(Func<DO.OrderItem?, bool>? filter = null)
        {
            if (filter == null)
                return XMLTools.LoadListFromXMLElement(s_orderItems).Elements().Select(o => getOrderItem(o));
            else
                return XMLTools.LoadListFromXMLElement(s_orderItems).Elements().Select(o => getOrderItem(o)).Where(filter);
        }
        #endregion

        #region פונקציה מקבלת מספר מזהה של הזמנה ומחזירה את אוסף האורדר אייטם המתאימים
        public List<DO.OrderItem?> GetByOrderID(int ID)
        {
            return XMLTools.LoadListFromXMLElement(s_orderItems).Elements()
                .Select(o => getOrderItem(o)).Where(item=>item?.OrderID == ID).ToList()
                ?? throw new NotExistException(); 

        }
        #endregion

        #region מקבלת מספר מזהה של הזמנה ומספר מזהה של מוצר ומחיזר את פרטי האורד אייטם המתאים 
        public DO.OrderItem GetByIDOrder_IDProduct(int IDOrder, int IDProduct)
        {
            XElement? temp = XMLTools.LoadListFromXMLElement(s_orderItems)?.Elements()
            .FirstOrDefault(item => (item?.ToIntNullable("OrderID") == IDOrder) && (item?.ToIntNullable("ProductID") == IDProduct));
            if (temp == null) //there is no orderItem that match to these id.
                throw new NotExistException();
            else
                return (DO.OrderItem)getOrderItem(temp)!;
        }
        #endregion
    }
}
