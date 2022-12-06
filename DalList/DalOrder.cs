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
        if (ds == null)
            throw new NotExistException();
        order.ID = DataSource.Config.NextOrderNumber;
        ds.lstO.Add(order);
        return order.ID ;
    }
    public Order GetById(int id)
    {
        if (ds== null)
            throw new NotExistException();
        foreach (Order temp in ds.lstO)
        {
            if (temp.ID==id)
                return temp;
        }
        throw new NotExistException();
    }
    public void Update(Order order)
    {
        if (ds == null)
            throw new NotExistException();
        foreach (Order temp in ds.lstO)
        {
            if (temp.ID == order.ID)
            {
                Delete(order.ID);
                Add(order);
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
