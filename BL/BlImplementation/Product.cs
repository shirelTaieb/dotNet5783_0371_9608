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
    /// <summary>
    /// פונקציה שממירה מ BO לDO
    /// </summary>
    /// <param name="prod"></param>
    /// <returns></returns>
    internal DO.Product BOproductToDO(BO.Product prod)
    {
        DO.Product temp = new DO.Product();
        temp.Name = prod.Name;
        temp.Price = prod.Price;
        temp.InStock = prod.InStock;
        temp.Category = (DO.Category)prod.Category;
        return temp;
    }
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
        DO.Product temp=new DO.Product();
        temp.ID=pr.ID;
        if(Dal.Product.GetById(temp.ID)!=null)
        {
            throw new alreadyExistException();
        }
        temp = BOproductToDO(pr);
        Dal?.Product.Add(temp);
    }
    public void deleteProduct(int IDpr)
    {
        Dal.Product.Delete(IDpr);
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
        if (pr.InStock <= 0)
            throw new wrongDataException();
        //מזהה- שהוא מספר חיובי בן 6 ספרות
        if ((pr.ID <= 100000) && (pr.ID >= 999999))
            throw new wrongDataException();
        //הקוד:
        DO.Product temp = new DO.Product();
        temp = Dal?.Product.GetById(pr.ID) ?? throw new wrongDataException(); //אם התז הזה כבר קיים
        temp= BOproductToDO(pr);

    }
    public IEnumerable<BO.ProductForList?> getManagerListOfProduct()
    {
       List<BO.ProductForList?> listProductForList = new List<BO.ProductForList?>();
       List<DO.Product> lstp = Dal.Product.GetAll().ToList();
        foreach (DO.Product prop in lstp )
        {

        }
    }
    public IEnumerable<BO.ProductForList?> getCoustomerlistOfProduct()
    {

    }
    public BO.Product getProductInfoManager(int IDpr)
    {
        //מזהה- הוא מספר חיובי בן 6 ספרות
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
    public BO.Product getProductInfoCoustomer(int IDpr)
    {
        //מזהה- הוא מספר חיובי בן 6 ספרות
        if ((IDpr <= 100000) && (IDpr >= 999999))
            throw new wrongDataException();


    }
 
}
