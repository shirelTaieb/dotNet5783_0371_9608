using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// Don't use BO because we won't see the diffrent beetwen BO and DO so we use BO/DO.the name

namespace BLApi
{
    public interface IProduct
    {
        public void addNewProduct(BO.Product? pr);
        /// <summary>
        /// מנהל מוסיף מוצר חדש
        /// </summary>
        /// <param name="IDpr"></param>
        public void deleteProduct(int IDpr);
        /// <summary>
        /// מנהל מוחק מוצר 
        /// </summary>
        /// <returns></returns>
        public IEnumerable<BO.ProductForList?> managerlistOfProduct();
        /// <summary>
        /// מציג למנהל רשימה של מוצרים כך שלכל מוצר יוצגו: מספר מוצר, שם מוצר מחיר וקטגוריה 
        /// </summary>
        /// <param name="IDpr"></param>
        /// <returns></returns>
        public BO.Product getProductByID(int IDpr);
        /// <summary>
        /// מציג למנהל לפי קוד המוצר את פרטי המוצר הבאים: מספר מוצר, שם מוצר מחיר, קטגוריה וכמות במלאי  
        /// </summary>
        /// <param name="pr"></param>
        public void updateProduct(BO.Product? pr);
        /// <summary>
        /// מנהל מוסיף מעדכן מוצר
        /// </summary>
        /// <returns></returns>
        public IEnumerable<BO.ProductItem?> coustomerlistOfProduct();
        /// <summary>
        /// לקוח מבקש קטלוג של המוצרים
        /// </summary>
        /// <param name="prID"></param>
        /// <returns></returns>
        public BO.ProductItem getProductInfo(int prID);
        /// <summary>
        /// מחזיר פרטי מוצר
        /// </summary>
        /// <param name="prID"></param>
        /// <returns></returns>
    }
}
