using DalApi;
using DO;

namespace Dal;
//dp
public class DalProduct : IProduct
{
    DataSource? ds = DataSource.s_instance;
    public int Add(Product item)
    {
        Product? temp = ds?.lstP.FirstOrDefault(pro => pro.GetValueOrDefault().ID == item.ID);
        if (temp != null)
            throw new doubleException();   ///the product is alredy exist
        else
             if (item.ID <= 100000 || item.ID >= 999999) //the id isnt valid
            item.ID = DataSource.ConfigProduct.NextProductNumber;
        ds?.lstP.Add(item);
        return item.ID;
    }
    public Product GetById(int id)
    {
        if (ds == null)
            throw new NotExistException();
        Product? pro = ds.lstP.FirstOrDefault(pro => pro?.ID == id);
        if (pro == null)//there in no order item matched in the database
            throw new NotExistException();
        return (Product)pro;
    }
    public void Update(Product item)
    {
        if (ds == null)
            throw new NotExistException();
        var temp = ds?.lstP.FirstOrDefault(pro => pro?.ID == item.ID);
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
        try { ds.lstP.Remove(GetById(id)); }
        catch { throw new NotExistException(); }
    }

    public IEnumerable<Product?> GetAll(Func<Product?, bool>? filter = null)
    {
        if (ds == null)
            throw new NotExistException();
        if (filter != null)
        {
            var result =
                from item in ds!.lstP
                where filter!(item)
                select item;
            return result.ToList();
        }
        return ds.lstP;
    }
}
