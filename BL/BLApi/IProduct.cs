using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BLApi
{
    public interface IProduct
    {
        /// <summary>
        /// מנהל מוסיף מוצר חדש
        /// </summary>
        /// <param name="IDpr"></param>
        public void addNewProduct(BO.Product? pr);


        /// <summary>
        /// מנהל מוחק מוצר 
        /// </summary>
        /// <returns></returns>
        public void deleteProduct(int IDpr);


        /// <summary>
        /// מנהל מוסיף מעדכן מוצר
        /// </summary>
        /// <returns></returns>
        public void updateProduct(BO.Product? pr);


        /// <summary>
        /// מציג למנהל רשימה של מוצרים כך שלכל מוצר יוצגו: מספר מוצר, שם מוצר מחיר וקטגוריה 
        /// </summary>
        /// <param name="IDpr"></param>
        /// <returns></returns>
        public IEnumerable<BO.ProductForList?> getManagerListOfProduct();

        /// <summary>
        /// מחזיר למשתמש את הרשימה של המוצרים= יעני לקטלוג
        /// </summary>
        /// <param name="prID"></param>
        /// <returns></returns>
        public IEnumerable<BO.ProductForList?> getCoustomerlistOfProduct();


        /// <summary>
        /// מציג למנהל לפי קוד המוצר את פרטי המוצר הבאים: מספר מוצר, שם מוצר מחיר, קטגוריה וכמות במלאי  
        /// </summary>
        /// <param name="pr"></param>
        public BO.Product getProductInfoManager(int IDpr);


        /// <summary>
        /// מחזיר פרטי מוצר למשתמש
        /// </summary>
        /// <param name="prID"></param>
        /// <returns></returns>
        public BO.Product getProductInfoCoustomer(int prID);
    }
}
