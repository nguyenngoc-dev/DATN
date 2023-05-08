using Microsoft.AspNetCore.Mvc;
using Perfume.BL;
using Perfume.Common;

namespace Perfume.API.Controllers
{
    public class OrderItemsController : BasesController<OrderItem>
    {
        #region Field
        private IOrderItemBL _orderitemBL;
    #endregion

    #region Constructor
    /// <summary>
    /// Hàm khởi tạo
    /// </summary>
    /// <param name="_productimageBL">Đối tượng IProductImageBL</param>
    public OrderItemsController(IOrderItemBL orderitemBL) : base(orderitemBL)
    {
            _orderitemBL = orderitemBL;

    }
    #endregion

}
}
