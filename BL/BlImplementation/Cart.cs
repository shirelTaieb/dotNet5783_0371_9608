using DalApi;
using System.Security.Cryptography;

namespace BlImplementation
{
    internal class Cart : BLApi.ICart
    {
        private IDal? Dal = DalApi.Factory.Get() ?? throw new BO.wrongDataException();//עכשיו ניתן לצאת מנק הנחה שדאל שונה מנאל
        public BO.Cart addProductToCart(BO.Cart? cart, int prID)
        {
            //מזהה- שהוא מספר חיובי בן 6 ספרות
            if ((prID <= 100000) || (prID >= 999999))
                throw new BO.wrongDataException();
            if (cart == null) //if the cart is null we build a new cart.
                cart = new BO.Cart();
            DO.Product? temp = new DO.Product();
            temp = Dal!.Product.GetById(prID);//get the product from Do by id
            if (temp == null)
                throw new BO.doseNotExistException();
            BO.OrderItem orit = new BO.OrderItem(); //cast from Do to bo.orderitem
            if (!(cart.Items!.Exists(or => or!.ProductID == prID))) //if the product isnt exist in the cart.
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
                    var result = cart.Items.FirstOrDefault(item => item?.ProductID == prID);
                    updatePoductAmount(cart, prID, (result!.Amount) + 1);
                }
                else throw new BO.notInStockException(); //if there is no products in the stock
            }
            return cart;
        }
        public BO.Cart updatePoductAmount(BO.Cart? cart, int IDpr, int newAmount)
        {
            //בודק שהתז נכון וקיים
            BO.OrderItem? temp = new BO.OrderItem();
            temp = cart?.Items?.FirstOrDefault(ls => ls?.ProductID == IDpr);
            if (temp == null)  //the product is not exist in the cart
                throw new BO.doseNotExistException();
            if (cart == null)
                throw new BO.doseNotExistException();
            if (newAmount == 0)//אם הכמות נהייתה 0 - תִּמְחַק את הפריט המתאים מהסל ותעדכן מחיר כולל של סל קניות
            {
                cart.TotalPrice -= temp.Price * temp.Amount;
                cart?.Items?.Remove(temp);
            }
            if (newAmount < temp.Amount)//אם הכמות קטנה - תקטין את הכמות בהתאם ועדכן מחיר כולל של פריט ושל סל קניות
            {
                foreach (var item in cart!.Items!) //we do foreach because we want to change the object in the cart
                {
                    if (item!.ID == IDpr) //this loop will happen just one time
                    {
                        cart.TotalPrice -= temp.Price * (temp.Amount - newAmount);
                        temp.Amount = newAmount;
                        item.TotalPrice -= temp.Price * (temp.Amount - newAmount);//uptade the total price of the order item.
                    }
                }
            }
            if (newAmount > temp.Amount)//אם הכמות גדלה - תפעל בדומה להוספת מוצר לסל קניות שכבר קיים בסל קניות כנ"ל
            {
                DO.Product? newProductToAdd = new DO.Product();
                newProductToAdd = Dal!.Product.GetById(IDpr);
                if (newProductToAdd == null)
                    throw new BO.doseNotExistException();
                if (newProductToAdd?.InStock >= (newAmount - temp.Amount)) //there are enagh products in stock.
                    foreach (var item in cart!.Items!) //we do foreach because we want to change the object in the cart
                    {
                        if (item!.ProductID == IDpr)  //this loop will happen just one time
                        {
                            cart.TotalPrice += temp.Price * (newAmount - temp.Amount);//uptade the total price of the cart.
                            item!.Amount = newAmount;   //!- because we check that the product exist in the cart.
                            item.TotalPrice += temp.Price * (newAmount - temp.Amount);  //uptade the total price of the order item.
                        }
                    }
                else
                    throw new BO.notInStockException(); //if there is no enagh products in the stock
            }

            return cart!;
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
            if (cart.CustomerEmail == "" || !cart.CustomerEmail!.Contains("@"))
                throw new BO.wrongDataException();
            //בדיקת נתוני סל קניות
            //..חסרררררררר

            DO.Order order = new DO.Order(); //casting to not nullable order
            order.ShipDate = null;//DateTime.MinValue;
            order.OrderDate = null;//DateTime.MinValue;
            order.OrderDate = DateTime.Now;
            order.CustomerAddress = cart!.CustomerAddress;
            order.CustomerName = cart!.CustomerName;
            order.CustomerEmail = cart!.CustomerEmail;
            int order_id = Dal!.Order.Add(order);

            var castListToDo =
                from item in cart.Items!
                select new DO.OrderItem() //casting every item in the cart, to be orderitem
                {
                    OrderID = order_id,
                    ProductID = item.ProductID,
                    Price = item.Price,
                    Amount = item.Amount,
                };
            //var adding =
            //from item in castListToDo
            //select Dal!.OrderItem.Add(item); //הוספה לרשימת פריטי ההזמנה

            //var updateing =
            //    from item in castListToDo
            //    //let pr = Dal.Product.GetById(item.ProductID) ?? throw new BO.doseNotExistException()
            //     //pr.InStock -= item.Amount
            //    select Dal.Product.Update(new DO.Product() pr=Dal.Product.GetById(item.ProductID) ?? throw new BO.doseNotExistException())
            //  );
            //איך ממירים גם את זה ללינקקקק?
            foreach (var item in castListToDo)  
            {
                Dal.OrderItem.Add(item); //הוספה לרשימת פריטי ההזמנה
                DO.Product pr = Dal.Product.GetById(item.ProductID) ?? throw new BO.doseNotExistException(); //בקשת המוצר משכבת הנתונים
                pr.InStock -= item.Amount;//עדכון המלאי
                Dal.Product.Update(pr); //עדכון המוצר בשכבת הנתונים
            }

        }
    }
}
