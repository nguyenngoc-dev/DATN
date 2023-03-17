
namespace Perfume.Common
{
    public class ErrorResult
    {
        #region Property
        /// <summary>
        /// Mã lỗi
        /// </summary>
        public ErrorCode ErrorCode { get; set; }

        /// <summary>
        /// Lỗi dành cho lập trình viên
        /// </summary>
        public string DevMsg { get; set; }

        /// <summary>
        /// 
        ///Lỗi cho người dùng
        /// </summary>
        public string UserMsg { get; set; }

        /// <summary>
        /// Thêm thông tin lỗi
        /// </summary>
        public object? MoreInfo { get; set; }

        /// <summary>
        /// id để fix lỗi
        /// </summary>
        public string? TraceId { get; set; }
        #endregion

        #region Constructor

        /// <summary>
        /// Khởi tạo không tham số
        /// </summary>
        /// Author: Nguyễn Văn Ngọc(4/2/2023)
        public ErrorResult()
        {

        }

        /// <summary>
        /// Khởi tạo có tham số
        /// </summary>
        /// <param name="errorCode">Mã lỗi</param>
        /// <param name="devMsg">Lỗi dành cho lập trình viên</param>
        /// <param name="userMsg">Lỗi cho người dùng</param>
        /// <param name="moreInfo">Thêm thông tin</param>
        /// <param name="traceId">Id để fix lỗi</param>
        public ErrorResult(ErrorCode errorCode,string devMsg, string userMsg, object? moreInfo = null, string? traceId = null)
        {
            ErrorCode = errorCode;
            DevMsg = devMsg;
            UserMsg = userMsg;
            MoreInfo = moreInfo;
            TraceId = traceId;
        }
        #endregion
    }
}
