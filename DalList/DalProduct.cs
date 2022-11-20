﻿using DalApi;
using DO;
using DalList;
using System;

namespace Dal;

public class DalProduct
{
    DataSource? ds = DataSource.s_instance;
    public int Add(Product item)
    {
        item.ID = DataSource.Config.NextOrderNumber;
        ds.lstP.Add(item);
        return item.ID;
    }
    public Product GetById(int id)
    {
        foreach (Product temp in ds.lstP)
        {
            if (temp.ID == id)
                return temp;
        }
        throw new Exception("no exist");
    }
    public void Update(Product item)
    {
        foreach (Product temp in ds.lstP)
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
        if (!ds.lstP.Remove(GetById(id)))
            throw new Exception("no exist");
    }

    //IEnumerable<T?> GetAll(Func<T?, bool>? filter = null);
    public IEnumerable<Product> GetAll()
    {

    }
}
