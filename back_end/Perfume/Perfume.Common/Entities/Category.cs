namespace Perfume.Common
{
    public class Category:Base
    {
        #region Property
        /// <summary>
        /// Khóa chính
        /// </summary>
      
        [PrimaryKey]
        public Guid CategoryId { get; set; }

        /// <summary>
        /// Mã danh mục
        /// </summary>
        public string CategoryCode { get; set; }
        /// <summary>
        /// Tên danh mục
        /// </summary>
        public string CategoryName { get; set; } 
        /// <summary>
        /// Tổng số sp mỗi danh mục
        /// </summary>
        public int TotalQuantity { get; set; }
        #endregion
    }
}
