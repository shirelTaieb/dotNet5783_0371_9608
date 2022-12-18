﻿using DalApi;
using DO;

namespace Dal;
//doi
internal class DalOrderItem : IOrderItem
{
    DataSource? ds = DataSource.s_instance;
    public int Add(OrderItem item)
    {
        if (ds == null)
            throw new NotExistException();
        OrderItem? temp = ds?.lstOI.FirstOrDefault(oi => oi.GetValueOrDefault().ID == item.ID);
        if (temp != null)
            throw new doubleException();   //the order item is alredy exist
        else
             if (item.ID <= 1000 || item.ID >= 9999) //the id isnt valid
                item.ID = DataSource.ConfigOrderItem1.NextOrderNumber;
        ds?.lstOI.Add(item);
        return item.ID;
    }
    public OrderItem? GetById(int id)
    {
        if (ds == null)
            throw new NotExistException();
        foreach (OrderItem? temp in ds!.lstOI)
        {
            if (temp?.ID == id)
                return temp;
        }
        return null;
    }
    public void Update(OrderItem item)
    {
        if (ds == null)
            throw new NotExistException();
        foreach (OrderItem temp in ds.lstOI)
        {
            if (temp.ID == item.ID)
            {
                Delete(item.ID);
                Add(item);
            }
        }
    }
    public void Delete(int id)
    {
        if (ds == null)
            throw new NotExistException();
        if (!ds.lstOI.Remove(GetById(id)))
            throw new NotExistException();
    }

    public IEnumerable<OrderItem?> GetAll(Func<OrderItem?, bool>? filter = null)
    {
        if (ds == null)
            throw new NotExistException();
        if (filter != null)
        {
            var result =
                from item in ds!.lstOI
                where filter!(item)
                select item;
            return result.ToList();
        }
        return ds.lstOI;
    }
    public List<OrderItem> GetByOrderID(int ID)
    {
        List<OrderItem> tempList= new List<OrderItem>();
        if (ds == null)
            throw new NotExistException();
        foreach (OrderItem temp in ds!.lstOI)
        {
            if (temp.OrderID == ID)
               tempList.Add(temp);
        }
        return tempList;
    }
    public OrderItem GetByIDOrder_IDProduct(int IDOrder, int IDProduct)
    {
        if (ds == null)
            throw new NotExistException();
        foreach (OrderItem temp in ds!.lstOI)
        {
            if (temp.OrderID == IDOrder)
               if (temp.ProductID == IDProduct)
                    return temp;
        }
        throw new NotExistException();
    }
}
