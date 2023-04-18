using Perfume.Common;
using Perfume.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Perfume.BL
{
    public class SaleOrderBL : BaseBL<SaleOrder>, ISaleOrderBL
    {

        #region Field
        /// <summary>
        /// Interface IProductDAL
        /// </summary>
        private ISaleOrderDAL _saleorderDAL;
        #endregion

        #region Constructor
        /// <summary>
        /// Hàm khởi tạo
        /// </summary>
        /// <param name="productDAL"></param>
        public SaleOrderBL(ISaleOrderDAL saleorderDAL) : base(saleorderDAL)
        {
            _saleorderDAL = saleorderDAL;
        }
        /// <summary>
        /// Lấy mã hóa đơn mới
        /// </summary>
        /// <returns>Mã sản phẩm mới</returns>
        /// author:Nguyễn Văn Ngọc(30/1/2023)
        public string GetNewSaleOrderCode()
        {
            return _saleorderDAL.GetNewSaleOrderCode();
        }
        #endregion
    }
}
