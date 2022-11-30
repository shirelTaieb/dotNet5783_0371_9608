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
        public BO.Cart addProductToCard(BO.Cart? cart)
        {

        }
        public BO.Cart updatPoductAmount(BO.Cart? cart)
        {

        }
        public void confirmOrder(BO.Cart? cart)
        {

        }

    }
}
