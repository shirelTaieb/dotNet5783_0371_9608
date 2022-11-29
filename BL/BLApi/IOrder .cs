using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
    public interface IOrder
    {
        public BO.Order getOrderInfo(int orderID);
        /// <summary>
        /// מחזיר פרטי הזמנה
        /// </summary>
        /// <param name="prID"></param>
        /// <returns></returns>
        public BO.Order updateSentOrder(int orderID);
        /// <summary>
    /// לאפשר למנהל לעדכן שהזמנה נשלחה ללקוח 
    /// </summary>
    /// <returns></returns>
    /// 
        public BO.Order updateDeliveryOrder(int orderID);
        /// <summary>
    /// לאפשר למנהל לעדכן שהזמנה התקבלה 
    /// </summary>
    /// <returns></returns>
    /// 
}

