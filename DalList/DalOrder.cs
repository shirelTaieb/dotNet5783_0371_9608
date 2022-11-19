using DalApi;
using DO;
using DalList;

namespace Dal;

public class DalOrder : IOrder
{
    DataSource ds = DataSource.s_instance;
    
    public int Add(Order order)
    {
        if (ds.lstO.FirstOrDefault() != null)
            throw new NotImplementedException();
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

    }
    public void Delete(int id)
    {

    }

    //IEnumerable<T?> GetAll(Func<T?, bool>? filter = null);
    public IEnumerable<Order> GetAll()
    {

    }
}
