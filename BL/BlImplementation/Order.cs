using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dal;
using BLApi;
using DalApi;
using System.Data;

namespace BlImplementation;


internal class Order : BLApi.IOrder
{
    private IDal? Dal = DalApi.Factory.Get() ?? throw new BO.wrongDataException();
    #region הפונקציה מקבלת ישרות הזמנה וממירה אותה לישרות הזמנה לרשימה
    private BO.OrderForList BoOrderToOrderForList(BO.Order or)
    {
        BO.OrderForList ofl = new BO.OrderForList();
        ofl.ID = or.ID;
        ofl.CustomerName = or.CustomerName;
        ofl.Status = or.Status;
        ofl.AmountOfItems = or.Items!.Count();
        ofl.TotalPrice = or.TotalPrice;
        return ofl;
    }
    #endregion

    #region  פונקצייה מקבלת ישות הזמנה שנותנת מידע על הסטטוס שלה
    internal BO.OrderStatus getStatus(DO.Order or)
    {
        BO.OrderStatus stat = new BO.OrderStatus();
        if (or.ShipDate != null)
            if (or.DeliveryDate != null)
                stat = BO.OrderStatus.deliveried;
            else
                stat = BO.OrderStatus.sent;
        else
            stat = BO.OrderStatus.confirm;
        return stat;
    }
    #endregion

    #region פונקצייה שממירה מBO לDO
    internal BO.Order? DoOrderToBo(DO.Order? o)
    {
        if (o == null)
            return null;
        DO.Order order = (DO.Order)o; //cast to not be nullable
        BO.Order? temp = new BO.Order();
        temp.ID = order.ID;
        temp.CustomerName = order.CustomerName ?? "";
        temp.CustomerEmail = order.CustomerEmail ?? "";
        temp.CustomerAddress = order.CustomerAddress ?? "";
        temp.OrderDate = order.OrderDate ?? null;
        temp.ShipDate = order.ShipDate ?? null;
        temp.DeliveryDate = order.DeliveryDate ?? null;
        temp.Status = getStatus(order);
        List<DO.OrderItem?> dolst = Dal!.OrderItem.GetByOrderID(order.ID);
        var result =
            from doItem in dolst
            select new BO.OrderItem
            {
                ID = (int)doItem?.ID!,
                ProductID = (int)doItem?.ProductID!,
                ProductName = (string?)doItem?.ProductName,
                Price = doItem?.Price,
                Amount = (int)doItem?.Amount!,
                TotalPrice = doItem?.Price * doItem?.Amount
            };
        temp.Items = result.ToList();
        temp.TotalPrice =
                    temp.Items?.Sum(c => c?.Price * c?.Amount) ?? 0;
        return temp;
    }
    #endregion

    #region פונקציה מחזירה אוסף של הרשימה של ההזמנות
    public IEnumerable<BO.OrderForList?> getOrderList()
    {
        IEnumerable<DO.Order?> temp = Dal!.Order.GetAll(); //take the data from the factory
                                                           //List<BO.OrderForList> orders = new List<BO.OrderForList>();

        List<BO.OrderForList> orders =
            (from ord in temp
             let boorder= DoOrderToBo(ord)!
             select (BoOrderToOrderForList(boorder))).ToList();
        return orders;
    }
    #endregion

    #region הפונקציה מקבלת מזפר מזהה של הזמנה ומחזירה ישות אורדר בהתאם (את פרטי ההזמנה)ג
    public BO.Order? getOrderInfo(int orderID)
    {
        //מזהה- שהוא מספר חיובי בן 4 ספרות
        if ((orderID <= 1000) || (orderID >= 9999))
            throw new BO.wrongDataException();
        DO.Order temp;
        try { temp = Dal!.Order.GetById(orderID); }
        catch { throw new BO.doseNotExistException(); }
        BO.Order? boorder = new BO.Order();
        boorder = DoOrderToBo(temp);
        return boorder;
    }
    #endregion

    #region פונקציה מעדכנת את הסטטוס לנשלח. זורקת חריגות בהתאם
    public BO.Order updateSentOrder(int orderID, DateTime? time = null)
    {
        //מזהה- שהוא מספר חיובי בן 4 ספרות
        if ((orderID <= 1000) || (orderID >= 9999))
            throw new BO.wrongDataException();
        DO.Order temp;
        try { temp = Dal!.Order.GetById(orderID); } catch { throw new BO.doseNotExistException(); }
        if (temp.ShipDate != null)
            throw new BO.wrongDataException();
        if (time == null)
            temp.ShipDate = DateTime.Now;
        else
            temp.ShipDate = time;
        try
        {
            Dal!.Order.Update(temp);
        }
        catch (NotExistException)
        {
            throw new BO.doseNotExistException();
        }
        BO.Order? cast = DoOrderToBo(temp);//cast from do to bo
        return cast!;
    }
    #endregion

    #region פונקציה מעדכנת את הסטטוס לנשלח. זורקת חריגות בהתאם
    public BO.Order updateDeliveryOrder(int orderID, DateTime? time = null)
    {
        //מזהה- שהוא מספר חיובי בן 4 ספרות
        if ((orderID <= 1000) || (orderID >= 9999))
            throw new BO.wrongDataException();
        DO.Order temp;
        try { temp = Dal!.Order.GetById(orderID); } catch { throw new BO.doseNotExistException(); }
        if (temp.ShipDate == null)
            throw new BO.doseNotSentYet();
        if (temp.DeliveryDate != null)
            throw new BO.wrongDataException();
        if (time == null)
            temp.DeliveryDate = DateTime.Now;
        else
            temp.DeliveryDate = time;
        try
        {
            Dal!.Order.Update(temp);
        }
        catch (NotExistException)
        {
            throw new BO.doseNotExistException();
        }
        BO.Order? cast = new BO.Order();
        cast = DoOrderToBo(temp);//cast from do to bo 
        return cast!;
    }
    #endregion

    #region הפונקציה מקבלת מספר מזהה להזמנה ומחזירה מעקב על ההזמנה
    public BO.OrderTracking orderTracking(int orderID)
    {
        //מזהה- שהוא מספר חיובי בן 6 ספרות
        if ((orderID <= 1000) || (orderID >= 9999))
            throw new BO.wrongDataException();
        DO.Order temp;
        try { temp = Dal!.Order.GetById(orderID); } catch { throw new BO.doseNotExistException(); }//get the order from the data according to id
        BO.OrderTracking ot = new BO.OrderTracking();
        ot.ID = orderID;
        ot.Status = getStatus(temp);
        ot.Tracking = new List<Tuple<string, DateTime?>?>();
        ot.Tracking.Add(new Tuple<string, DateTime?>("Order Date: ", temp.OrderDate));
        if (temp.ShipDate != null)
            ot.Tracking.Add(new Tuple<string, DateTime?>( "Ship Date: ", temp.ShipDate));
        if (temp.DeliveryDate != null)
            ot.Tracking.Add(new Tuple<string, DateTime?>("Delivery Date: ",temp.DeliveryDate));
        return ot;
    }
    #endregion
}
