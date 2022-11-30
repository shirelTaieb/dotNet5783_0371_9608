using BLApi;
using DalApi;
using BO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace BlImplementation;

internal class Product : BLApi.IProduct
{
    private IDal? Dal = DalApi.Factory.Get();
    public void addNewProduct(BO.Product? pr)
    {
        //בדיקת תקינות קלט
        //1. שם לא מחרוזת ריקה:
        if (pr.Name == "")
            throw new wrongDataException();
        //מחיר - שהוא מספר חיובי
        if(pr.Price<0)
            throw new wrongDataException();
        //כמות במלאי שאינה שלילית
        if (pr.InStock < 0)
            throw new wrongDataException();
        //מזהה- שהוא מספר חיובי בן 6 ספרות
        if ((pr.ID <= 100000) && (pr.ID >= 999999))
            throw new wrongDataException();
        
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
            DO.Product? temp= Dal?.Product.GetById(IDpr); //שיננו את ההרשאה של dalproduct לפובליק ךא בטוח שזה חוקי לבדוק
            temp.
        }
        catch (Exception? ex)    
        {
            throw ex;
        }
    }
    public void updateProduct(BO.Product? pr)
    {
        //בדיקת תקינות קלט
        //1. שם לא מחרוזת ריקה:
        if (pr.Name == "")
            throw new wrongDataException();
        //מחיר - שהוא מספר חיובי
        if (pr.Price < 0)
            throw new wrongDataException();
        //כמות במלאי שאינה שלילית
        if (pr.InStock < 0)
            throw new wrongDataException();
        //מזהה- שהוא מספר חיובי בן 6 ספרות
        if ((pr.ID <= 100000) && (pr.ID >= 999999))
            throw new wrongDataException();

    }
    public IEnumerable<BO.ProductItem?> coustomerlistOfProduct()
    {

    }
    public BO.ProductItem getProductInfo(int prID)
    {
        //מזהה- שהוא מספר חיובי בן 6 ספרות
        if ((prID <= 100000) && (prID >= 999999))
            throw new wrongDataException();
    }
}
