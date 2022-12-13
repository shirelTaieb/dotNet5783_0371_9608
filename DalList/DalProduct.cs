using DalApi;
using DO;
using DalList;
using System;

namespace Dal;
//dp
public class DalProduct : IProduct
{
    DataSource? ds = DataSource.s_instance;
    public int Add(Product item)
    {
        if (GetById(item.ID) != null)
            throw new doubleException();
        item.ID = DataSource.ConfigProduct.NextProductNumber;
        ds?.lstP.Add(item);
        return item.ID;
    }
    public Product? GetById(int id)
    {
        if(ds == null)
            throw new NotExistException();
        foreach (Product temp in ds.lstP)
        {
            if (temp.ID == id)
                return temp;
        }
        return null;
    }
    public void Update(Product item)
    {
        if (ds == null)
            throw new NotExistException();
        foreach (Product? temp in ds.lstP)
        {
            if (temp?.ID == item.ID)
            {
                //temp?.Name = item.Name;
                //Delete(item.ID);
                //Add(item);
            }
        }
    }
    public void Delete(int id)
    {
        if (ds == null)
            throw new NotExistException();
        if (!ds.lstP.Remove(GetById(id)))
            throw new NotExistException();
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
