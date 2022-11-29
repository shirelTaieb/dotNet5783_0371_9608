using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLApi
{
    public interface ICart
    {
        public BO.Cart addProductToCard(BO.Cart? cart);
        /// <summary>
        /// מוסיף מוצר  לסל
        /// </summary>
        /// <param name="cart"></param>
        /// <returns></returns>
        public BO.Cart updatPoductAmount(BO.Cart? cart);
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
