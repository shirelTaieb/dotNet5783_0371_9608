using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dal;
using BO;
using BLApi;
using DalApi;
using DO;


namespace BlImplementation;


internal class Order : BLApi.IOrder
{
    /// <summary>
    /// get DO Order and according to his dates' this func return the wanted OrderStatus
    /// </summary>
    /// <param name="or"></param>
    /// <returns></returns>
    private OrderStatus getStatus(DO.Order or)
    {
        OrderStatus stat=new OrderStatus();
        if (or.ShipDate != null)
            if (or.DeliveryDate != null)
                stat = OrderStatus.deliveried;
            else
                stat = OrderStatus.sent;
        else
            stat = OrderStatus.confirm;
        return stat;
    }
    private BO.Order? DoOrderToBo(DO.Order o)
    {
        BO.Order temp = new BO.Order();
        temp.ID = o.ID;
        temp.CustomerName = o.CostumerName;
        temp.CustomerEmail = o.CostumerEmail;
        temp.CustomerAddress = o.CostumerAdress;
        temp.OrderDate = o.OrderDate;
        temp.ShipDate = o.ShipDate;
        temp.DeliveryDate= o.DeliveryDate;
        temp.Status = getStatus(o);
        temp.Items = null;
        temp.TotalPrice = 0;
        return temp;

    }
    private OrderForList BoOrderToOrderForList(BO.Order or)
    {
        OrderForList ofl=new OrderForList();
        ofl.ID = or.ID;
        ofl.CustomerName = or.CustomerName;
        ofl.Status = or.Status;
        ofl.AmountOfItems = 1;
        ofl.TotalPrice = or.TotalPrice;
        return ofl;
    }
    private IDal? Dal = DalApi.Factory.Get();
 
    public IEnumerable<BO.OrderForList?> getOrderList()
    {
        List<DO.Order> temp = Dal.Order.GetAll().ToList(); //take the data from the factory
        List<BO.OrderForList> orders = new List<BO.OrderForList>();
        BO.Order boorder = new BO.Order();
        BO.OrderForList ofl= new BO.OrderForList();
        var result =
            from order in temp
            select order;  //we want all of the orders
        result.ToList();
        foreach (DO.Order or in result)
        {
            boorder = DoOrderToBo(or); //from do to bo
            ofl= BoOrderToOrderForList(boorder);//from order to orderforlist
            orders.Add(ofl);
        }
        return orders;
    }
    public BO.Order getOrderInfo(int orderID)
    {
        //מזהה- שהוא מספר חיובי בן 6 ספרות
        if ((orderID <= 100000) && (orderID >= 999999))
            throw new wrongDataException();
        DO.Order? temp = Dal.Order.GetById(orderID);
        BO.Order boorder = new BO.Order();
        boorder = DoOrderToBo(temp);
        return boorder;
    }
    public BO.Order updateSentOrder(int orderID)
    {
        //מזהה- שהוא מספר חיובי בן 6 ספרות
        if ((orderID <= 100000) && (orderID >= 999999))
            throw new wrongDataException();
        DO.Order? temp = Dal.Order.GetById(orderID);
        BO.Order cast = DoOrderToBo(temp);//cast from do to bo
        cast.Status = BO.OrderStatus.sent;
        return cast;

    }
    public BO.Order updateDeliveryOrder(int orderID)
    {
        //מזהה- שהוא מספר חיובי בן 6 ספרות
        if ((orderID <= 100000) && (orderID >= 999999))
            throw new wrongDataException();
        DO.Order temp = Dal.Order.GetById(orderID) ?? throw new doseNotExistException();
        BO.Order? cast = DoOrderToBo(temp);//cast from do to bo
        cast.Status = BO.OrderStatus.deliveried; 
        return cast;

    }
    public BO.OrderTracking orderTracking(int orderID)
    {
        //מזהה- שהוא מספר חיובי בן 6 ספרות
        if ((orderID <= 100000) && (orderID >= 999999))
            throw new wrongDataException();
        DO.Order temp = Dal?.Order.GetById(orderID)??throw new doseNotExistException();//get the order from the data according to id
        BO.OrderTracking ot = new BO.OrderTracking();
        ot.ID = orderID;
        ot.Status = getStatus(temp);
        return ot;

    }
    public BO.OrderTracking updateAmountOrder(int orderID)
    {
        //מזהה- שהוא מספר חיובי בן 6 ספרות
        if ((orderID <= 100000) && (orderID >= 999999))
            throw new wrongDataException();
    }
}
