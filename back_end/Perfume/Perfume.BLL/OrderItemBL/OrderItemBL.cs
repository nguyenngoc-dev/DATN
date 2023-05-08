using Perfume.Common;
using Perfume.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Perfume.BL
{
    public class OrderItemBL: BaseBL<OrderItem>, IOrderItemBL
    {

        #region Constructor
        public OrderItemBL(IOrderItemDAL orderitemDAL) : base(orderitemDAL)
        {

        }
        #endregion
    }
}
