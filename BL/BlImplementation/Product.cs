﻿using BLApi;
using DalApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace BlImplementation;

internal class Product : BLApi.IProduct
{
    /// <summary>
    /// פונקציה שממירה מ BO לDO
    /// </summary>
    /// <param name="prod"></param>
    /// <returns></returns>
    private IDal? Dal = DalApi.Factory.GetDal() ?? throw new BO.wrongDataException();
    internal DO.Product BOproductToDO(BO.Product prod)
    {
        DO.Product temp = new DO.Product();
        temp.ID = prod.ID;  
        temp.Name = prod.Name;
        temp.Price = prod.Price;
        temp.InStock = prod.InStock;
        temp.Category = (DO.Category?)prod.Category;
        return temp;
    }
    public void addNewProduct(BO.Product? pr)
    {
        //בדיקת תקינות קלט
        //1. שם לא מחרוזת ריקה:
        if (pr.Name == "")
            throw new BO.wrongDataException();
        //מחיר - שהוא מספר חיובי
        if(pr.Price<0)
            throw new BO.wrongDataException(); 
        //כמות במלאי שאינה שלילית
        if (pr.InStock < 0)
            throw new BO.wrongDataException();
        //מזהה- שהוא מספר חיובי בן 6 ספרות
        if ((pr.ID <= 100000) && (pr.ID >= 999999))
            throw new BO.wrongDataException();
        DO.Product temp=new DO.Product();
        temp.ID=pr.ID;
        try
        {
            Dal?.Product.GetById(temp.ID);
            throw new BO.alreadyExistException();
        }
        catch  //getById say that the product is not exist
        {
            temp = BOproductToDO(pr);
            Dal?.Product.Add(temp);
        }
    }
    public void deleteProduct(int IDpr)
    {
        Dal?.Product.Delete(IDpr);
    }
    public void updateProduct(BO.Product? pr)
    {
        //בדיקת תקינות קלט
        //1. שם לא מחרוזת ריקה:
        if (pr.Name == "")
            throw new BO.wrongDataException();
        //מחיר - שהוא מספר חיובי
        if (pr.Price < 0)
            throw new BO.wrongDataException();
        //כמות במלאי שאינה שלילית
        if (pr.InStock <= 0)
            throw new BO.wrongDataException();
        //מזהה- שהוא מספר חיובי בן 6 ספרות
        if ((pr.ID <= 100000) && (pr.ID >= 999999))
            throw new BO.wrongDataException();
        //הקוד:
        DO.Product temp = new DO.Product();
       // temp = Dal?.Product.GetById(pr.ID) ?? throw new BO.wrongDataException(); //אם התז הזה כבר קיים
        temp = BOproductToDO(pr);
        Dal?.Product.Update(temp);
    }
    public IEnumerable<BO.ProductForList?> getListOfProduct()//נו זה גם לקוסטומר
    {
        //List<BO.ProductForList?> listProductForList = new List<BO.ProductForList?>();
        //BO.ProductForList temp= new BO.ProductForList();
        List<DO.Product?> lstp = (List<DO.Product?>)Dal!.Product.GetAll();
       return( from prop in lstp
           select new BO.ProductForList()
           {
               ID = (int)prop?.ID!,
               Name = prop?.Name,
               Price = prop?.Price,
               Category = (BO.Category?)prop?.Category
           }).ToList();
    }
    public BO.Product getProductInfoManager(int IDpr)
    {
        //מזהה- הוא מספר חיובי בן 6 ספרות
        if ((IDpr <= 100000) && (IDpr >= 999999))
            throw new BO.doseNotExistException();
        BO.Product pr = new BO.Product();
        DO.Product temp =Dal?.Product.GetById(IDpr)?? throw new BO.doseNotExistException();
        pr.ID = temp.ID;
        pr.Name = temp.Name;
        pr.Price = temp.Price;
        pr.Category = (BO.Category?)temp.Category;   
        pr.InStock = temp.InStock;
        pr.path = temp.path;
        return pr;
    }
    public BO.ProductItem getProductInfoCustomer(int IDpr, BO.Cart? cart)
    {
        //מזהה- הוא מספר חיובי בן 6 ספרות
        if ((IDpr <= 100000) && (IDpr >= 999999))
            throw new BO.wrongDataException();
        if (cart == null)
            throw new BO.wrongDataException();
        BO.ProductItem pr = new BO.ProductItem();
        DO.Product temp = Dal?.Product.GetById(IDpr) ?? throw new BO.doseNotExistException();
        pr.ID = IDpr;
        pr.Name = temp.Name;
        pr.Price = temp.Price;
        pr.Category = (BO.Category?)temp.Category;
        if (temp.InStock > 0)
            pr.InStock = true;
        else
            pr.InStock = false;
        BO.OrderItem? orderItem = new BO.OrderItem();
        if (cart.Items == null)
            pr.Amount = 0;
        else
        {
            orderItem = cart!.Items.FirstOrDefault(or => or.ProductID == IDpr);
            if (orderItem == null)
                pr.Amount = 0;
            else
                pr.Amount = orderItem.Amount;
        }
        return pr;
    }
 
}
