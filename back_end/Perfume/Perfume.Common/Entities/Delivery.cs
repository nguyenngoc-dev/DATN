using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Perfume.Common
{
    public class Delivery:Base
    {
        /// <summary>
        /// Khóa chính
        /// </summary>
       
        [PrimaryKey]
        public Guid DeliveryId { get; set; }

        /// <summary>
        /// Mã vận đơn
        /// </summary>
        public string DeliveryCode { get; set; }

        /// <summary>
        /// Tên shipper
        /// </summary>
        public string DeliveryName { get; set; }

        /// <summary>
        /// Tình trạng
        /// </summary>
        public int Status { get; set; }
    }
}
