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
            DO.Product dproduct = new DO.Product();
            dproduct= Dal.Product.GetById(prID)??throw new doseNotExistException();
            BO.OrderItem orit = new BO.OrderItem();
            orit.ProductID = dproduct.ID;
            orit.Price = dproduct.Price;
            if (cart == null)
                cart.Items.Add(orit);
            if (cart.Items.Exists(or => or.ID == prID ))
            {

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
