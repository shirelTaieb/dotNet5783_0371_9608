using BLApi;

using BO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace BlImplementation;

internal class Product : IProduct
{
    //private IDal Dal = new DalList(); //?
    public void addNewProduct(BO.Product? pr)
    {

    }

    public void deleteProduct(int IDpr)
    {

    }
    public IEnumerable<BO.ProductForList?> managerlistOfProduct()
    {

    }
    public BO.Product getProductByID(int IDpr)
    {
        if ((IDpr <= 100000) && (IDpr >= 999999))
            throw new doseNotExistException();
        try
        {
            return GetByID();
        }
        catch (Exception ex)    
        {
            throw ex;
        }
    }
    public void updateProduct(BO.Product? pr)
    {

    }
    public IEnumerable<BO.ProductItem?> coustomerlistOfProduct()
    {

    }
    public BO.ProductItem getProductInfo(int prID)
    {

    }
}
