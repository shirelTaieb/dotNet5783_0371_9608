using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// Don't use BO because we won't see the diffrent beetwen BO and DO so we use BO/DO.the name

namespace BLApi
{
    public class IProduct
    {
        public void addNewProduct(BO.Product? pr);//מנהל מוסיף מוצר חדש
        public void deleteProduct(int IDpr);//מנהל מוחק מוצר 
        public List<BO.ProductForList?> managerlistOfProduct();//מציג למנהל רשימה של מוצרים כך שלכל מוצר יוצגו: מספר מוצר, שם מוצר מחיר וקטגוריה 
        public BO.Product getProductByID(int IDpr);// מציג למנהל לפי קוד המוצר את פרטי המוצר הבאים: מספר מוצר, שם מוצר מחיר, קטגוריה וכמות במלאי  
        public void updateProduct(BO.Product? pr); //מנהל מוסיף מעדכן מוצר
        public List<BO.ProductItem?> getCatalogProduct();// לקוח מבקש קטלוג של המוצרים
        public BO.ProductItem getProductInfo(int prID);
    }
}
