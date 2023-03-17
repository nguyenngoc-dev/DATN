namespace Perfume.Common
{
    /// <summary>
    /// Thông tin trả về 
    /// </summary>
    public class PagingResult
    {
        #region Property
        /// <summary>
        /// Tổng số bản ghi
        /// </summary>
        public int TotalRecord { get; set; }

        /// <summary>
        /// List trả về
        /// </summary>
        public List<Product> Data { get; set; } 

        /// <summary>
        /// Tổng số trang
        /// </summary>
        public int TotalPage { get; set; }

        /// <summary>
        /// Tổng số bản ghi một trang
        /// </summary>
        public int PageCount { get; set; }

        #endregion
    }
}
