using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BO;
using BLApi;
using DalApi;


namespace BlImplementation;

internal class Order : BLApi.IOrder
{
    private IDal? Dal = DalApi.Factory.Get();

    public IEnumerable<BO.OrderForList?> getOrderList()
    {

    }
    public BO.Order getOrderInfo(int orderID)
    {

    }
    public BO.Order updateSentOrder(int orderID)
    {

    }
    public BO.Order updateDeliveryOrder(int orderID)
    {

    }
    public BO.OrderTracking orderTracking(int orderID)
    {

    }
    public BO.OrderTracking updateAmountOrder(int orderID)
    {

    }
}
