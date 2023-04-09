using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Perfume.Common
{
    public  class ProductImage:Base
    {
        /// <summary>
        /// Khóa chính
        /// </summary>
        public Guid ProductImageId { get; set; }

        /// <summary>
        /// link ảnh sản phẩm
        /// </summary>
        public string ImageUrl { get; set; }

        /// <summary>
        /// id sản phẩm
        /// </summary>
        public Guid ProductId { get; set;}
    }
}
