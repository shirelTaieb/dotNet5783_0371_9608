using DalApi;
using DO;

namespace Dal;
//doi
public class DalOrderItem : IOrderItem
{
    DataSource? ds = DataSource.s_instance;
    public int Add(OrderItem item)
    {
        if (ds == null)
            throw new Exception("no exist");
        //item.ID = DataSource.Config.NextOrderNumber;
        ds.lstOI.Add(item);
        return item.ID;
    }
    public OrderItem GetById(int id)
    {
        if (ds == null)
            throw new Exception("no exist");
        foreach (OrderItem temp in ds.lstOI)
        {
            if (temp.ID == id)
                return temp;
        }
        throw new Exception("no exist");
    }
    public void Update(OrderItem item)
    {
        if (ds == null)
            throw new Exception("no exist");
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
            throw new Exception("no exist");
        if (!ds.lstOI.Remove(GetById(id)))
            throw new Exception("no exist");
    }

    //IEnumerable<T?> GetAll(Func<T?, bool>? filter = null);
    public IEnumerable<OrderItem> GetAll()
    {
        if (ds == null)
            throw new Exception("no exist");
        return ds.lstOI;
    }
    public List<OrderItem> GetByOrderID(int ID)
    {
        List<OrderItem> tempList= new List<OrderItem>();
        if (ds == null)
            throw new Exception("no exist");
        foreach (OrderItem temp in ds.lstOI)
        {
            if (temp.OrderID == ID)
               tempList.Add(temp);
        }
        return tempList;
    }
    public OrderItem GetByIDOrder_IDProduct(int IDOrder, int IDProduct)
    {
        if (ds == null)
            throw new Exception("no exist");
        foreach (OrderItem temp in ds.lstOI)
        {
            if (temp.OrderID == IDOrder)
               if (temp.ProductID == IDProduct)
                    return temp;
        }
        throw new Exception("no exist");
    }
}
