namespace Perfume.Common
{
    public class Category:Base
    {
        #region Property
        /// <summary>
        /// Khóa chính
        /// </summary>
        public Guid CategoryId { get; set; }

        /// <summary>
        /// Mã danh mục
        /// </summary>
        public string CategoryName { get; set; } 
        #endregion
    }
}
