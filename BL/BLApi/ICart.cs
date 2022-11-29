using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLApi
{
    internal class ICart
    {
        public BO.Cart addProductToCard(BO.Cart? cart);// מוסיף מוצר  לסל
        public BO.Cart updatPoductAmount(BO.Cart? cart);// מעדכן כמות פריט בסל
        public void confirmOrder(BO.Cart? cart);//אישור הזמנה

    }
}
