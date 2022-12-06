using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLApi
{
    public interface ICart
    {
        public BO.Cart addProductToCart(BO.Cart? cart,int IDpr);
        /// <summary>
        /// מוסיף מוצר  לסל
        /// </summary>
        /// <param name="cart"></param>
        /// <returns></returns>
        public BO.Cart updatePoductAmount(BO.Cart? cart,int id, int newAmount);
        /// <summary>
        /// מעדכן כמות פריט בסל
        /// </summary>
        /// <param name="cart"></param>
        public void confirmOrder(BO.Cart? cart);
        /// <summary>
        /// פרטי הזמנה
        /// </summary>
        /// <param name="cart"></param>
    }
}
