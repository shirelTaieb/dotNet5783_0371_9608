using DalApi;
using DO;
using DalList;
using System;

//do
namespace Dal;

public class DalOrder : IOrder //שיננו לפובליק
{
    DataSource? ds = DataSource.s_instance;
    
    public int Add(Order order)
    {
        Order? temp = ds?.lstO.FirstOrDefault(ord => ord.GetValueOrDefault().ID == order.ID);
        if (temp != null)
            throw new doubleException();   //the product is alredy exist
        else
             if (order.ID <= 1000 || order.ID >= 9999) //the id isnt valid
                order.ID = DataSource.ConfigOrder.NextOrderNumber;
        ds?.lstO.Add(order);
        return order.ID;
    }
    public Order? GetById(int id)
    {
        if (ds== null)
            throw new NotExistException();
        foreach (Order? temp in ds.lstO)
        {
            if (temp?.ID==id)
                return temp;
        }
        return null;
    }
    public void Update(Order order)
    {
        if (ds == null)
            throw new NotExistException();
        foreach (Order? temp in ds.lstO)
        {
            if (temp?.ID == order.ID)
            {
                Delete(order.ID);
                Add(order);
                return;
            }
        }
    }
   public void Delete(int id)
   {
     if (ds == null)
         throw new NotExistException();
     if (!ds.lstO.Remove(GetById(id)))
         throw new NotExistException();
   }    

    public IEnumerable<Order?> GetAll(Func<Order?, bool>? filter = null)
    {
        if (ds == null)
            throw new NotExistException();
        if (filter!=null)
        {
            var result =
                from item in ds!.lstO
                where filter!(item)
                select item;
            return result.ToList();
        }
        return ds.lstO;
    }
}
