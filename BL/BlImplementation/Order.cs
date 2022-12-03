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
    private BO.Order DoOrderToBo(DO.Order o)
    {
        BO.Order temp = new BO.Order();
        temp.ID = o.ID;
        temp.CustomerName = o.CostumerName;
        temp.CustomerEmail = o.CostumerEmail;
        temp.CustomerAddress = o.CostumerAdress;
        temp.OrderDate = o.OrderDate;
        temp.ShipDate = o.ShipDate;
        temp.DeliveryDate= o.DeliveryDate;
        temp.PaymentDate = null;
        temp.Status = null;
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
        IEnumerable<DO.Order> temp = Dal.Order.GetAll().ToList(); //take the data from the factory
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
        IEnumerable<DO.Order> temp = Dal.Order.GetAll().ToList();
        DO.Order or= new DO.Order();
        temp.Where(  );   



    }
    public BO.Order updateSentOrder(int orderID)
    {
        //מזהה- שהוא מספר חיובי בן 6 ספרות
        if ((orderID <= 100000) && (orderID >= 999999))
            throw new wrongDataException();

    }
    public BO.Order updateDeliveryOrder(int orderID)
    {
        //מזהה- שהוא מספר חיובי בן 6 ספרות
        if ((orderID <= 100000) && (orderID >= 999999))
            throw new wrongDataException();
        List<DO.Order> temp = Dal.Order.GetAll().ToList();//take the data from the factory.
        var result =
            from order in temp
            where (order.ID==orderID)
            select order;
        BO.Order cast = DoOrderToBo(result);//איך ממירים מאוסף לאחד יחיד??
        cast.Status = deliveried; //למה הוא לא מזהה את האינאםםם?
        return cast;

    }
    public BO.OrderTracking orderTracking(int orderID)
    {
        //מזהה- שהוא מספר חיובי בן 6 ספרות
        if ((orderID <= 100000) && (orderID >= 999999))
            throw new wrongDataException();

    }
    public BO.OrderTracking updateAmountOrder(int orderID)
    {
        //מזהה- שהוא מספר חיובי בן 6 ספרות
        if ((orderID <= 100000) && (orderID >= 999999))
            throw new wrongDataException();
    }
}
