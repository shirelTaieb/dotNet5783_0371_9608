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
    public Order GetById(int id)
    {
        if (ds== null)
            throw new NotExistException();
        Order? or = ds.lstO.FirstOrDefault(ord => ord?.ID == id);
        if (or == null)
            throw new NotExistException(); //there in no order matched in the database
        return (Order)or;
    }
    public void Update(Order order)
    {
        if (ds == null)
            throw new NotExistException();
        var temp=ds.lstO.FirstOrDefault(ord=>ord?.ID == order.ID);
        if (temp != null)
        {
            Delete(order.ID);
            Add(order);
        }
    }
   public void Delete(int id)
   {
     if (ds == null)
         throw new NotExistException();
        try { ds.lstO.Remove(GetById(id)); }
        catch { throw new NotExistException(); }
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
