using DalApi;
using DO;
using DalList;
using System;

//do
namespace Dal;

public class DalOrder : IOrder
{
    DataSource? ds = DataSource.s_instance;
    
    public int Add(Order order)
    {
        //if (ds.lstO.Find(order) != null)??
        //    throw new NotImplementedException();
        order.ID = DataSource.Config.NextOrderNumber;
        ds.lstO.Add(order);
        return order.ID;
    }
    public Order GetById(int id)
    {
      foreach (Order temp in ds.lstO)
        {
            if (temp.ID==id)
                return temp;
        }
        throw new Exception("no exist");
    }
    public void Update(Order order)
    {
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
            if (!ds.lstO.Remove(GetById(id)))
                throw new Exception("no exist");
        }
    

    //IEnumerable<T?> GetAll(Func<T?, bool>? filter = null);
    public IEnumerable<Order> GetAll()
    {
        return ds.lstO;
    }
}
