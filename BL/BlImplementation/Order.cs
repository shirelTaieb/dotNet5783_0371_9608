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
        //מזהה- שהוא מספר חיובי בן 6 ספרות
        if ((orderID <= 100000) && (orderID >= 999999))
            throw new worngDataException();

    }
    public BO.Order updateSentOrder(int orderID)
    {
        //מזהה- שהוא מספר חיובי בן 6 ספרות
        if ((orderID <= 100000) && (orderID >= 999999))
            throw new worngDataException();

    }
    public BO.Order updateDeliveryOrder(int orderID)
    {
        //מזהה- שהוא מספר חיובי בן 6 ספרות
        if ((orderID <= 100000) && (orderID >= 999999))
            throw new worngDataException();

    }
    public BO.OrderTracking orderTracking(int orderID)
    {
        //מזהה- שהוא מספר חיובי בן 6 ספרות
        if ((orderID <= 100000) && (orderID >= 999999))
            throw new worngDataException();

    }
    public BO.OrderTracking updateAmountOrder(int orderID)
    {
        //מזהה- שהוא מספר חיובי בן 6 ספרות
        if ((orderID <= 100000) && (orderID >= 999999))
            throw new worngDataException();
    }
}
