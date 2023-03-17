namespace Perfume.Common
{
    public enum ErrorCode
    {
        #region Property
        /// <summary>
        /// Lỗi do exception
        /// </summary>
        Exception = 1,

        /// <summary>
        /// Lỗi do trùng mã
        /// </summary>
        DuplicateCode = 2,

        /// <summary>
        /// Lỗi do mã bị để trống
        /// </summary>
        EmptyCode = 3,

        /// <summary>
        /// Lỗi insert thất bại
        /// </summary>
        InsertFailed = 4,

        /// <summary>
        /// Lỗi update thất bại
        /// </summary>
        UpdateFailed = 5,

        /// <summary>
        /// Lỗi delete thất bại
        /// </summary>
        DeleteFailed = 6,

        /// <summary>
        /// Dữ liệu đầu vào không hợp lệ
        /// </summary>
        InvalidInput = 7,
        #endregion
    }
}
