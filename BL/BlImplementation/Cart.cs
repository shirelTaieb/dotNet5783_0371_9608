using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLApi;
using DalApi;
using DO;

namespace BlImplementation
{
    internal class Cart : BLApi.ICart
    {
        private IDal? Dal = DalApi.Factory.Get()??throw new BO.wrongDataException();//עכשיו ניתן לצאת מנק הנחה שדאל שונה מנאל
        public BO.Cart addProductToCart(BO.Cart? cart, int prID)
        {
            //מזהה- שהוא מספר חיובי בן 6 ספרות
            if ((prID <= 100000) && (prID >= 999999))
                throw new BO.wrongDataException();
            if (cart == null) //if the cart is null we build a new cart.
                cart = new BO.Cart();
            DO.Product temp = new DO.Product();
            temp = Dal!.Product.GetById(prID);//get the product from Do by id\
            BO.OrderItem orit = new BO.OrderItem(); //cast from Do to bo.orderitem
            if (cart!.Items == null)//if the cart is null
            {
                cart.Items.Add(orit); //מה הבעיה לעזאזלל לקרוא לאדד על רשימה ריקה
                return cart;
            }
            if (!(cart.Items!.Exists(or => or.ID == prID ))) //if the product isnt exist in the cart.
            {
                orit.ProductID = temp.ID;
                orit.Price = temp.Price;
                orit.Amount = 1;  //this is the first from this type of product
                cart!.Items.Add(orit); //add the product to the cart
            }
            else //if the product is exist 
            {
                if (temp.InStock > 0) //there are products in stock.
                {
                    BO.OrderItem? oi = cart.Items.FirstOrDefault(or => or.ProductID == prID);
                    oi!.Amount++;   //!- because we check that the product exist in the cart.
                    cart.TotalPrice += oi.Price;//uptade the total price of the cart
                    //איך מעדכנים מחיר כולל של פריט? איפה? ת
                }
                else throw new BO.notInStockException(); //if there is no products in the stock
            }
            return cart;
        }
        public BO.Cart updatePoductAmount(BO.Cart? cart,int IDpr, int newAmount)
        {
            //בודק שהתז נכון וקיים
            BO.OrderItem? temp = new BO.OrderItem();
            temp = cart?.Items?.FirstOrDefault(ls => ls?.ProductID == IDpr);
            if (temp == null)
                throw new BO.doseNotExistException();
            if(cart==null)
                throw new BO.doseNotExistException();
            if (newAmount < temp.Amount)//אם הכמות קטנה - תקטין את הכמות בהתאם ןתעדכן מחיר כולל של פריט ושל סל קניות
            {
                // מתעלמת באלגנטיות מהבקשה:תעדכן מחיר כולל של פריט כי לא מובן
                cart.TotalPrice -= temp.Price * (temp.Amount- newAmount);
                temp.Amount = newAmount;
               // cart.TotalPrice += temp.Price * temp.Amount;
            }
            if(newAmount > temp.Amount)//אם הכמות גדלה - תפעל בדומה להוספת מוצר לסל קניות שכבר קיים בסל קניות כנ"ל
            {
                // מתעלמת באלגנטיות מהבקשה:תעדכן מחיר כולל של פריט כי לא מובן
                DO.Product temp2 = new DO.Product();
                if (temp2.InStock > 0) //there are products in stock.
                {
                   temp!.Amount++;   //!- because we check that the product exist in the cart.
                    cart.TotalPrice += temp.Price;//uptade the total price of the cart
                }
                else throw new BO.notInStockException(); //if there is no products in the stock
            }
            if(newAmount == 0)//אם הכמות נהייתה 0 - תִּמְחַק את הפריט המתאים מהסל ותעדכן מחיר כולל של סל קניות
            {
                cart.TotalPrice -= temp.Price * temp.Amount;
                Dal!.Product.Delete(IDpr);// alredy chack that its not null
            }
            return cart;
        }
        public void confirmOrder(BO.Cart? cart)
        {
            DO.Order order = new DO.Order(); //castint to not nullable order
            order.ShipDate = DateTime.MinValue;
            order.OrderDate = DateTime.MinValue;
            order.OrderDate = DateTime.Now;
            order.CustomerAddress = cart!.CustomerAddress;
            order.CustomerName = cart!.CustomerName;
            order.CustomerEmail=cart!.CustomerEmail;
            int order_id= Dal!.Order.Add(order);


        }
        public void confirmOrder11(BO.Cart? cart)
        {
            if (cart == null)
                throw  new BO.wrongDataException();
            // בדיקת נתוני לקוח תקינים
            if (cart.CustomerName == "")
                throw new BO.wrongDataException();
            if (cart.CustomerAddress == "")
                throw new BO.wrongDataException();
            if (cart.CustomerEmail == "" || cart.CustomerEmail!.Contains("@"))
                throw new BO.wrongDataException();
           //בדיקת נתוני סל קניות

        }
    }
}
