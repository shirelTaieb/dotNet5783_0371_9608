using DalApi;
using DO;

namespace Dal;

public class DalOrderItem : IOrderItem
{
    DataSource? ds = DataSource.s_instance;
    public int Add(OrderItem item)
    {
        item.ID = DataSource.Config.NextOrderNumber;
        ds.lstOI.Add(item);
        return item.ID;
    }
    public OrderItem GetById(int id)
    {
        foreach (OrderItem temp in ds.lstOI)
        {
            if (temp.ID == id)
                return temp;
        }
        throw new Exception("no exist");
    }
    public void Update(OrderItem item)
    {
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
        if (!ds.lstOI.Remove(GetById(id)))
            throw new Exception("no exist");
    }

    //IEnumerable<T?> GetAll(Func<T?, bool>? filter = null);
    public IEnumerable<OrderItem> GetAll()
    {
        return ds.lstOI;
    }
    public List<OrderItem> GetByOrderID(int ID)
    {
        List<OrderItem> tempList= new List<OrderItem>();
        foreach (OrderItem temp in ds.lstOI)
        {
            if (temp.OrderID == ID)
               tempList.Add(temp);
        }
        return tempList;
    }
    public OrderItem GetByIDOrder_IDProduct(int IDOrder, int IDProduct)
    {
        foreach (OrderItem temp in ds.lstOI)
        {
            if (temp.OrderID == IDOrder)
               if (temp.ProductID == IDProduct)
                    return temp;
        }
        throw new Exception("no exist");
    }
}
