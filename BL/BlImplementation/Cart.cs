using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BO;
using BLApi;
using DalApi;

namespace BlImplementation
{
    internal class Cart : BLApi.ICart
    {
        private IDal? Dal = DalApi.Factory.Get();
        public BO.Cart addProductToCart(BO.Cart? cart,int prID)
        {

            if (cart.Items.Exists(or => or.ID == prID ))
            {
                DO.Product? temp=new DO.Product();
                DO.Product
                temp = Dal?.Product.GetById(prID);
                if(temp.inStock>0)/////yohoooo
                {
                    temp.inStock--;
                    BO.OrderItem? oi = cart.Items.FirstOrDefault(or => or.ID == prID); //מה יש לו
                }
                else throw new doseNotExistException(); //if there is no products in the stock
            }
            else
            {
                DO.Product dproduct = new DO.Product();
                dproduct = Dal.Product.GetById(prID);
                BO.OrderItem orit = new BO.OrderItem();
                orit.ProductID = dproduct.ID;
                orit.Price = dproduct.Price;
                cart.Items.Add(orit);
            }
        }
        public BO.Cart updatePoductAmount(BO.Cart? cart,int IDpr, int newAmount)
        {
            //מזהה- הוא מספר חיובי בן 6 ספרות
            if ((IDpr <= 100000) && (IDpr >= 999999))
                throw new BO.doseNotExistException();
            if(newAmount < 0)//אם הכמות קטנה - תקטין את הכמות בהתאם ןתעדכן מחיר כולל של פריט ושל סל קניות
            {

            }
            if(newAmount > 0)//אם הכמות גדלה - תפעל בדומה להוספת מוצר לסל קניות שכבר קיים בסל קניות כנ"ל

            {

            }
            if(newAmount == 0)//אם הכמות נהייתה 0 - תִּמְחַק את הפריט המתאים מהסל ותעדכן מחיר כולל של סל קניות
            {
                DO.
            }
        }
        public void confirmOrder(BO.Cart? cart)
        {


        }

    }
}
