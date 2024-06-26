﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLApi
{
    public interface IOrder
    {
        /// <summary>
        /// להציג למנהל את כל ההזמנות 
        /// לכל הזמנה נציג: מספר הזמנה, שם לקוח, סטאטוס, כמות פריטים ומחיר כולל 
        /// </summary>
        /// <param name="prID"></param>
        /// <returns></returns>
        public IEnumerable<BO.OrderForList?> getOrderList();
        /// <summary>
        /// מחזיר פרטי הזמנה
        /// Exception: No Exception
        /// </summary>
        /// <param name="prID"></param>
        /// <returns></returns>
        public BO.Order? getOrderInfo(int orderID);
        /// <summary>
        /// לאפשר למנהל לעדכן שהזמנה נשלחה ללקוח 
        /// </summary>
        /// <returns></returns>
        /// 
        public BO.Order updateSentOrder(int orderID, DateTime? time = null);
        /// <summary>
        /// לאפשר למנהל לעדכן שהזמנה התקבלה 
        /// </summary>
        /// <returns></returns>
        /// 
        public BO.Order updateDeliveryOrder(int orderID, DateTime? time = null);
        /// <summary>
        /// מסך ניהול הזמנה של מנהל
        /// </summary>
        /// <param name="prID"></param>
        /// <returns></returns>
        public BO.OrderTracking orderTracking(int orderID);
        /// <summary>
        /// בונוס עדיכון הזמנה על ידי המנהל: יאפשר הוספה \ הורדה \ שינוי כמות של מוצר בהזמנה ע"י המנהל
        /// תחזיר אובייקט הזמנה מעודכן
        /// </summary>
        /// <param name="prID"></param>
        /// <returns></returns>
       // public BO.OrderTracking updateAmountOrder(int orderID);//בונוס

    }
}

