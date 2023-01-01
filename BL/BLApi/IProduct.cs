using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
        public IEnumerable<BO.ProductForList?> getPartOfProduct(Func<BO.ProductForList?, bool>? filter = null);
        /// <summary>
        /// Exception: No Exception
        /// </summary>
        /// <returns></returns>

        public IEnumerable<BO.ProductForList?> getListOfProduct();
        /// <summary>
        /// מציג למנהל לפי קוד המוצר את פרטי המוצר הבאים: מספר מוצר, שם מוצר מחיר, קטגוריה וכמות במלאי  
        /// Exception: No Exception
        /// </summary>
        /// <param name="pr"></param>
        public BO.Product getProductInfoManager(int IDpr);


        /// <summary>
        /// מחזיר פרטי מוצר למשתמש
        /// </summary>
        /// <param name="prID"></param>
        /// <returns></returns>
        public BO.ProductItem getProductInfoCustomer(int prID,BO.Cart cart);
    }
}
