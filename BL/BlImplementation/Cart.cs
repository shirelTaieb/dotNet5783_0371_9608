using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLApi;
using DalApi;


namespace BlImplementation
{
    internal class Cart : BLApi.ICart
    {
        private IDal? Dal = DalApi.Factory.GetDal()??throw new BO.wrongDataException();//עכשיו ניתן לצאת מנק הנחה שדאל שונה מנאל
        public BO.Cart addProductToCart(BO.Cart? cart, int prID)
        {
            //מזהה- שהוא מספר חיובי בן 6 ספרות
            if ((prID <= 100000) && (prID >= 999999))
                throw new BO.wrongDataException();
            if (cart == null) //if the cart is null we build a new cart.
                cart = new BO.Cart();
            DO.Product? temp = new DO.Product();
            temp = Dal!.Product.GetById(prID);//get the product from Do by id
            if (temp==null)
                throw new BO.doseNotExistException();
            BO.OrderItem orit = new BO.OrderItem(); //cast from Do to bo.orderitem
            if (!(cart.Items!.Exists(or => or!.ID == prID ))) //if the product isnt exist in the cart.
            {
                orit.ProductID = temp.GetValueOrDefault().ID;
                orit.Price = temp?.Price;
                orit.ID = 0; //זה זמני, אחרי זה בהזמנה הוא מקבל מספר רץ אוטומטי
                orit.Amount = 1;  //this is the first from this type of product
                cart.Items?.Add(orit); //add the product to the cart. the cart also can be null
            }
            else //if the product is exist 
            {
                if (temp?.InStock > 0) //there are more products in stock.
                {
                    foreach (var item in cart.Items) //we do foreach because we want to change the object in the cart
                    {
                        if (item!.ID == prID)  //this loop will happen just one time
                        {
                            cart.TotalPrice += item!.Price;//uptade the total price of the cart.
                            item!.Amount++;   //!- because we check that the product exist in the cart.
                            item!.TotalPrice += item!.Price; //uptade the total price of the order item.
                        }
                    }
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
            if (newAmount < temp.Amount)//אם הכמות קטנה - תקטין את הכמות בהתאם ועדכן מחיר כולל של פריט ושל סל קניות
            {
                foreach (var item in cart.Items!) //we do foreach because we want to change the object in the cart
                {
                    if (item!.ID == IDpr) //this loop will happen just one time
                    {
                        cart.TotalPrice -= temp.Price * (temp.Amount - newAmount);
                        temp.Amount = newAmount;
                        item.TotalPrice-=temp.Price* (temp.Amount - newAmount);//uptade the total price of the order item.
                    }
                }
            }
            if(newAmount > temp.Amount)//אם הכמות גדלה - תפעל בדומה להוספת מוצר לסל קניות שכבר קיים בסל קניות כנ"ל
            {
                DO.Product temp2 = new DO.Product();
                if (temp2.InStock > 0) //there are more products in stock.
                    foreach (var item in cart.Items!) //we do foreach because we want to change the object in the cart
                    {
                        if (item!.ID == IDpr)  //this loop will happen just one time
                        {
                            cart.TotalPrice += temp.Price * (newAmount - temp.Amount);//uptade the total price of the cart.
                            item!.Amount=newAmount;   //!- because we check that the product exist in the cart.
                            cart.TotalPrice += temp.Price * (newAmount-temp.Amount);  //uptade the total price of the order item.
                        }
                    }
                else 
                    throw new BO.notInStockException(); //if there is no products in the stock
            }
            if(newAmount == 0)//אם הכמות נהייתה 0 - תִּמְחַק את הפריט המתאים מהסל ותעדכן מחיר כולל של סל קניות
            {
                cart.TotalPrice -= temp.Price * temp.Amount;
                Dal!.Product.Delete(IDpr);// already check that its not null
            }
            return cart;
        }
        public void confirmOrder(BO.Cart? cart)
        {
            if (cart == null)
                throw new BO.wrongDataException();
            // בדיקת נתוני לקוח תקינים
            if (cart.CustomerName == "")
                throw new BO.wrongDataException();
            if (cart.CustomerAddress == "")
                throw new BO.wrongDataException();
            if (cart.CustomerEmail == "" || cart.CustomerEmail!.Contains("@"))
                throw new BO.wrongDataException();
            //בדיקת נתוני סל קניות
            //..חסרררררררר
            
            DO.Order order = new DO.Order(); //casting to not nullable order
            order.ShipDate = DateTime.MinValue;
            order.OrderDate = DateTime.MinValue;
            order.OrderDate = DateTime.Now;
            order.CustomerAddress = cart!.CustomerAddress;
            order.CustomerName = cart!.CustomerName;
            order.CustomerEmail=cart!.CustomerEmail;
            int order_id= Dal!.Order.Add(order);
            foreach(var item in cart.Items!)  //casting every item in the cart, to be orderitem
            {
                DO.OrderItem temp=new DO.OrderItem();
                temp.OrderID = order_id;
                temp.Price = item?.Price;
                temp.ProductID = item!.ProductID;
                temp.Amount = item.Amount;
                Dal.OrderItem.Add(temp); //הוספה לרשימת פריטי ההזמנה
                DO.Product pr=Dal.Product.GetById(temp.ProductID)??throw new BO.doseNotExistException(); //בקשת המוצר משכבת הנתונים
                pr.InStock -= temp.Amount;//עדכון המלאי
                Dal.Product.Update((DO.Product)pr); //עדכון המוצר בשכבת הנתונים
            }

        }
    }
}
