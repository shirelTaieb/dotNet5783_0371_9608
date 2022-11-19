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
        for(int i = 0; i < ds.lstO.Count; i++)
        {
            
        }
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
