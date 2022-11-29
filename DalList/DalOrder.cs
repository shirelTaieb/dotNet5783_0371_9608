using DalApi;
using DO;
using DalList;
using System;

//do
namespace Dal;

internal class DalOrder : IOrder
{
    DataSource? ds = DataSource.s_instance;
    
    public int Add(Order order)
    {
        if (ds == null)
            throw new NotExistException();
       // order.ID = DataSource.Config.NextOrderNumber;
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
    

    //IEnumerable<T?> GetAll(Func<T?, bool>? filter = null);
    public IEnumerable<Order> GetAll()
    {
        if (ds == null)
            throw new NotExistException();
        return ds.lstO;
    }
}
