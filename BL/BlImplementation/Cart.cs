using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BO;
using BLApi;
using DalApi;
using DO;

namespace BlImplementation
{
    internal class Cart : BLApi.ICart
    {
        private IDal? Dal = DalApi.Factory.Get();
        public BO.Cart addProductToCart(BO.Cart? cart,int prID)
        {
            //מזהה- שהוא מספר חיובי בן 6 ספרות
            if ((prID <= 100000) && (prID >= 999999))
                throw new wrongDataException();
            if (cart!=null&&cart.Items!.Exists(or => or.ID == prID ))
            {
                DO.Product temp=new DO.Product();
                temp = Dal.Product.GetById(prID);
                if(temp.InStock>0)
                { 
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
        public BO.Cart updatePoductAmount(BO.Cart? cart)
        {
  
        }
        public void confirmOrder(BO.Cart? cart)
        {

        }

    }
}
