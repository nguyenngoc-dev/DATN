using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Perfume.Common
{
    public  class SaleOrder:Base
    {
        /// <summary>
        /// Id hóa đơn
        /// </summary>
        [PrimaryKey]
        public Guid SaleOrderId { get; set; }

        /// <summary>
        /// Mã hóa đơn
        /// </summary>
        public string SaleOrderCode { get; set; }
        /// <summary>
        /// Địa chỉ khách hàng
        /// </summary>
        public string CustomerAddress { get; set; }

        /// <summary>
        /// Sđt khách hàng
        /// </summary>
        public string CustomerPhone { get; set; }

        /// <summary>
        /// Id khách hàng
        /// </summary>
        public Guid UserId { get; set; }

        /// <summary>
        /// Họ
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Tên
        /// </summary>
        public string LastName { get; set; }
        /// <summary>
        /// id vận chuyển
        /// </summary>
        public Guid DeliveryId { get; set; }

        /// <summary>
        /// Tình trạng đơn hàng
        /// </summary>
        public int status { get; set; }

        /// <summary>
        /// Tổng tiền đơn hàng
        /// </summary>
        public int TotalPrice { get; set; }

    }
}
