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
    /// <summary>
    /// get DO Order and according to his dates' this func return the wanted OrderStatus
    /// </summary>
    /// <param name="or"></param>
    /// <returns></returns>
    private BO.OrderForList BoOrderToOrderForList(BO.Order or)
    {
        BO.OrderForList ofl=new BO.OrderForList();
        ofl.ID = or.ID;
        ofl.CustomerName = or.CustomerName;
        ofl.Status = or.Status;
        ofl.AmountOfItems = or.Items.Count();
        ofl.TotalPrice = or.TotalPrice;
        return ofl;
    }
    private IDal? Dal = DalApi.Factory.GetDal() ?? throw new BO.wrongDataException();

    /// <summary>
    /// פונקצייה שנותנת מידע על הסטטוס
    /// </summary>
    /// <param name="o"></param>
    /// <returns></returns>
    internal BO.OrderStatus getStatus(DO.Order or)
    {
        BO.OrderStatus stat = new BO.OrderStatus();
        if (or.ShipDate != null)//&&or.ShipDate!=DateTime.MinValue)
            if (or.DeliveryDate != null)//&& or.DeliveryDate != DateTime.MinValue)
                stat = BO.OrderStatus.deliveried;
            else
                stat = BO.OrderStatus.sent;
        else
            stat = BO.OrderStatus.confirm;
        return stat;
    }


    /// <summary>
    /// פונקצייה שממירה מבו לדו
    /// </summary>
    /// <param name="o"></param>
    /// <returns></returns>
    internal BO.Order? DoOrderToBo(DO.Order? o)
    {
        if (o == null)
            return null;
        DO.Order order=(DO.Order)o; //cast to not be nullable
        BO.Order? temp = new BO.Order();
        temp.ID = order.ID;
        temp.CustomerName =order.CustomerName??"";
        temp.CustomerEmail = order.CustomerEmail??"";
        temp.CustomerAddress = order.CustomerAddress??"";
        temp.OrderDate = order.OrderDate??null;
        temp.ShipDate = order.ShipDate??null;
        temp.DeliveryDate = order.DeliveryDate??null;
        temp.Status = getStatus(order);
        List<DO.OrderItem> dolst = Dal!.OrderItem.GetByOrderID(order.ID);
        // List<BO.OrderItem> bolst = new List<BO.OrderItem>();
        var result =
            from doItem in dolst
            select new BO.OrderItem
            {
                ID = doItem.ID,
                ProductID = doItem.ProductID,
                Price = doItem.Price,
                Amount = doItem.Amount,
                TotalPrice = doItem.Price * doItem.Amount
            };
            temp.Items = result.ToList();
        temp.TotalPrice =
                    temp.Items?.Sum(c => c?.Price * c?.Amount) ?? 0;
        return temp;    
    }


    public IEnumerable<BO.OrderForList?> getOrderList()
    {
        List<DO.Order?> temp = (List<DO.Order?>)Dal!.Order.GetAll(); //take the data from the factory
        List<BO.OrderForList> orders = new List<BO.OrderForList>();
        BO.Order? boorder = new BO.Order();
        BO.OrderForList? ofl= new BO.OrderForList();
        //var result =
        //    from order in temp
        //    select order;  //we want all of the orders
        //result.ToList();
        foreach (DO.Order? or in temp)
        {
            boorder = DoOrderToBo(or); //from do to bo
            ofl= BoOrderToOrderForList(boorder!);//from order to orderforlist

            orders.Add(ofl);
        }
        return orders;
    }
    public BO.Order? getOrderInfo(int orderID)
    {
        //מזהה- שהוא מספר חיובי בן 4 ספרות
        if ((orderID <= 1000) || (orderID >= 9999))
            throw new BO.wrongDataException();
        DO.Order? temp = Dal!.Order.GetById(orderID);
        BO.Order? boorder = new BO.Order();
        boorder = DoOrderToBo(temp);
        return boorder;
    }
    public BO.Order updateSentOrder(int orderID)
    {
        //מזהה- שהוא מספר חיובי בן 4 ספרות
        if ((orderID <= 1000) || (orderID >= 9999))
            throw new BO.wrongDataException();
        DO.Order temp = Dal!.Order.GetById(orderID)??throw new BO.doseNotExistException();
        if (temp.ShipDate != null)//|| temp.ShipDate !=DateTime.MinValue)
            throw new BO.wrongDataException();
        temp.ShipDate = DateTime.Now; 
        try
        {
            Dal!.Order.Update(temp);
        }
        catch(NotExistException)
        {
            throw new BO.doseNotExistException();
        }
        BO.Order? cast = DoOrderToBo(temp);//cast from do to bo
        return cast!;

    }
    public BO.Order updateDeliveryOrder(int orderID)
    {
        //מזהה- שהוא מספר חיובי בן 4 ספרות
        if ((orderID <= 1000) || (orderID >= 9999))
            throw new BO.wrongDataException();
        DO.Order temp = Dal!.Order.GetById(orderID) ?? throw new BO.doseNotExistException();
        if (temp.ShipDate == null)
            throw new Exception();///לשים חריגה מתאימה לזה
        temp.DeliveryDate = DateTime.Now;
        BO.Order? cast = new BO.Order();
        cast=DoOrderToBo(temp);//cast from do to bo 
        return cast!;

    }
    public BO.OrderTracking orderTracking(int orderID)
    {
        //מזהה- שהוא מספר חיובי בן 6 ספרות
        if ((orderID <= 1000) || (orderID >= 9999))
            throw new BO.wrongDataException();
        DO.Order temp = Dal?.Order.GetById(orderID)??throw new BO.doseNotExistException();//get the order from the data according to id
        BO.OrderTracking ot = new BO.OrderTracking();
        ot.ID = orderID;
        ot.Status =getStatus(temp);
        return ot;

    }
    //בונוס.. צריך לעשות אם רוצים.
    //public BO.OrderTracking updateAmountOrder(int orderID)
    //{
    //    //מזהה- שהוא מספר חיובי בן 6 ספרות
    //    if ((orderID <= 100000) && (orderID >= 999999))
    //        throw new wrongDataException();
    //}
}
