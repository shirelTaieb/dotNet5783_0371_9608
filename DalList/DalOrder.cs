using DalApi;
using DO;
using DalList;
using System;

//do
namespace Dal;

public class DalOrder : IOrder //שיננו לפובליק
{
    DataSource? ds = DataSource.s_instance;
    #region הפונקצייה מקבלת הזמנה ומוסיפה אותה לרשימה של ההזמנות ומחזירה את המזהה שהעניקה לו
    public int Add(Order order)
    {
        Order? temp = ds?.lstO.FirstOrDefault(ord => ord.GetValueOrDefault().ID == order.ID);
        if (temp != null) //the product is alredy exist
            throw new doubleException();   
        else
             if (order.ID <= 1000 || order.ID >= 9999) //the id isnt valid
                order.ID = DataSource.ConfigOrder.NextOrderNumber;
        ds?.lstO.Add(order);
        return order.ID;
    }
    #endregion

    # region פונקצייה שמחקבל מספר מזהה של הזמנה ומחזירה את פרטי ההזמנה
    public Order GetById(int id)
    {
        if (ds== null)
            throw new NotExistException();
        Order? or = ds.lstO.FirstOrDefault(ord => ord?.ID == id);
        if (or == null)
            throw new NotExistException(); //there in no order matched in the database
        return (Order)or;
    }
    #endregion

    #region פונקציה מקבלת הזמנה ומעדכנת את פרטי ההזמנה שלו
    public void Update(Order order)
    {
        if (ds == null)
            throw new NotExistException();
        var temp=ds.lstO.FirstOrDefault(ord=>ord?.ID == order.ID);
        if (temp != null)
        {
            Delete(order.ID);
            Add(order);
        }
    }
    #endregion

    #region פונקציה שמקבלת מספר מזהה ומוחקת את ההזמנה המתאימה
    public void Delete(int id)
   {
     if (ds == null)
         throw new NotExistException();
        try { ds.lstO.Remove(GetById(id)); }
        catch { throw new NotExistException(); }
   }
    #endregion

    #region פונקצייה שמקבלת ביטוי למבדה ומחזירה אוסף של כל ההזמנות שמתאימות לו
    public IEnumerable<Order?> GetAll(Func<Order?, bool>? filter = null)
    {
        if (ds == null)
            throw new NotExistException();
        if (filter!=null)
        {
            var result =
                from item in ds!.lstO
                where filter!(item)
                select item;
            return result.ToList();
        }
        return ds.lstO;
    }
    #endregion
}
