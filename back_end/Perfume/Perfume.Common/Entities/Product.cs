
using System.ComponentModel.DataAnnotations;

namespace Perfume.Common
{
    /// <summary>
    /// Thông tin nhân viên
    /// </summary>
    public class Product:Base
    {
        #region Property

        /// <summary>
        /// Khóa chính
        /// </summary>
        
        [PrimaryKey]
        public Guid ProductId { get; set; }

        /// <summary>
        /// Mã sản phẩm
        /// </summary>
        
        [IsNotNullOrEmpty("Mã sản phẩm không được để trống")]
        [MaxLength(20)]
        public string ProductCode { get; set; }

        /// <summary>
        /// Tên sản phẩm
        /// </summary>
        
        [IsNotNullOrEmpty("Tên sản phẩm không được để trống")]
        [MaxLength(100)]
        public string ProductName { get; set; }

        /// <summary>
        /// ID danh mục
        /// </summary>
        public Guid CategoryId { get; set; }

        /// <summary>
        /// Tên danh mục
        /// </summary>
        public string? CategoryName { get; set; }
        /// <summary>
        /// Giá sản phẩm
        /// </summary>
        public double Price { get; set; }

        /// <summary>
        /// Số lượng
        /// </summary>
        public int Quantity { get; set; }

        /// <summary>
        /// Số lượng đã bán
        /// </summary>
        public int QuantityPurchased { get; set; }

        /// <summary>
        /// Mô tả
        /// </summary>
        public string ShortDescription { get; set; }

        /// <summary>
        /// Mô tả chi tiết
        /// </summary>
        public string DetailDescription { get; set; }
        #endregion

    }
}
