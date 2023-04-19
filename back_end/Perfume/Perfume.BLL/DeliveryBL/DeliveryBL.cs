using Perfume.Common;
using Perfume.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Perfume.BL
{
    public class DeliveryBL : BaseBL<Delivery>, IDeliveryBL
    {

        #region Field
        /// <summary>
        /// Interface IProductDAL
        /// </summary>
        private IDeliveryDAL _deliveryDAL;
        #endregion

        #region Constructor
        /// <summary>
        /// Hàm khởi tạo
        /// </summary>
        /// <param name="productDAL"></param>
        public DeliveryBL(IDeliveryDAL deliveryDAL) : base(deliveryDAL)
        {
            _deliveryDAL = deliveryDAL;
        }
        #endregion

        /// <summary>
        /// Lấy mã danh mục mới
        /// </summary>
        /// <returns>Mã sản phẩm mới</returns>
        /// author:Nguyễn Văn Ngọc(30/1/2023)
        public string GetNewDeliveryCode()
        {
            return _deliveryDAL.GetNewDeliveryCode();
        }
    }
}
