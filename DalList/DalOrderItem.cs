using DalApi;
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
    public OrderItem GetById(int id)
    {
        if (ds == null)
            throw new NotExistException();
        OrderItem? oi = ds?.lstOI.FirstOrDefault(oi => oi?.ID == id);
        if (oi == null)//there in no order item matched in the database
            throw new NotExistException();
        return (OrderItem)oi;

    }
    public void Update(OrderItem item)
    {
        if (ds == null)
            throw new NotExistException();
        var temp = ds?.lstOI.FirstOrDefault(oi => oi?.ID == item.ID);
        if (temp != null)
        {
            Delete(item.ID);
            Add(item);
        }
    }
    public void Delete(int id)
    {
        if (ds == null)
            throw new NotExistException();
        try
        {
            ds.lstOI.Remove(GetById(id));
        }
        catch  //if the orderitem is not exist
        { throw new NotExistException(); }
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
        List<OrderItem> tempList = new List<OrderItem>();
        if (ds == null)
            throw new NotExistException();
        //איך עושים סתם פעולה בלינקקק
        //var result =
        //    from oi in ds!.lstOI
        //    where oi?.OrderID == ID
        //    select (tempList.Add((DO.OrderItem)oi));
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
        OrderItem? result = ds!.lstOI.FirstOrDefault(item => (item?.OrderID == IDOrder) && (item?.ProductID == IDProduct));
            return result ?? throw new NotExistException(); 

       
    }
}
