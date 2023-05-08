using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Perfume.Common
{
    public class OrderItem:Base
    {
        [PrimaryKey]
        public Guid OrderItemId { get; set; }

        public Guid ProductId { get; set; }

        public Guid SaleOrderId  { get; set; }

        public int Quantity { get; set; }

        public int Price { get; set; }
    }
}
