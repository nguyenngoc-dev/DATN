using Perfume.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Perfume.DAL
{
    public interface IDeliveryDAL : IBaseDAL<Delivery>
    {
        /// <summary>
        /// Lấy mã vận đơn
        /// </summary>
        /// <returns>Mã sản phẩm mới</returns>
        /// author:Nguyễn Văn Ngọc(30/1/2023)
        public string GetNewDeliveryCode();
    }
}
