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
            DO.Product? dproduct = Dal.Product.GetById(prID)??null;
            BO.Product bproduct = DOProductToBO(dproduct);//לממש את ההמרה
            if (cart == null)
                cart.Items.Add(bproduct);
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
