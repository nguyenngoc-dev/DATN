using Microsoft.AspNetCore.Mvc;
using Perfume.BL;
using Perfume.Common;

namespace Perfume.API
{
    public class SaleOrdersController : BasesController<SaleOrder>
    {
        #region Field
        private ISaleOrderBL _saleorderBL;
        #endregion

        #region Constructor
        /// <summary>
        /// Hàm khởi tạo
        /// </summary>
        /// <param name="_productimageBL">Đối tượng IProductImageBL</param>
        public SaleOrdersController(ISaleOrderBL saleorderBL) : base(saleorderBL)
        {
            _saleorderBL = saleorderBL;

        }
        #endregion

    }
}
