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
                temp = Dal.Product.GetById(prID);
                if(temp.inStock>0)/////yohoooo
                {
                    temp.inStock--;
                    BO.OrderItem? oi = cart.Items.find(or => or.ID == prID); //מה יש לו
                }
                else throw new doseNotExistException(); //if there is no products in the stock
            }
            else
            {
                DO.Product dproduct = new DO.Product();
                dproduct = Dal.Product.GetById(prID) ?? throw new doseNotExistException();
                BO.OrderItem orit = new BO.OrderItem();
                orit.ProductID = dproduct.ID;
                orit.Price = dproduct.Price;
                cart.Items.Add(orit);
            }
        }
        public BO.Cart updatPoductAmount(BO.Cart? cart)
        {
  
        }
        public void confirmOrder(BO.Cart? cart)
        {

        }

    }
}
