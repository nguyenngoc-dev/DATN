using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Perfume.Common
{
    /// <summary>
    /// Attribute dùng để xác định 1 property là khóa chính
    /// </summary>
    /// Author: Nguyễn Văn Ngọc (2/2/2023)
    [AttributeUsage(AttributeTargets.Property)]
    public class PrimaryKeyAttribute : Attribute
    {

    }

    /// <summary>
    /// Attribute dùng để xác định 1 property không được để trống
    /// </summary>
    /// Author: Nguyễn Văn Ngọc (2/2/2023)
    public class IsNotNullOrEmptyAttribute : Attribute
    {
        #region Field

        /// <summary>
        /// Message lỗi trả về cho client
        /// </summary>
        public string ErrorMessage;
        #endregion

        #region Constructor

        /// <summary>
        /// Contructor có tham số
        /// </summary>
        /// <param name="errorMessage">Tin nhắn lỗi trả về</param>
        /// Author: Nguyễn Văn Ngọc (2/2/2023)
        public IsNotNullOrEmptyAttribute(string errorMessage)
        {
            ErrorMessage = errorMessage;
        }
        #endregion
    }
    /// <summary>
    /// Attribute dùng để xác định 1 property có dữ liệu hợp lệ hay không
    /// </summary>
    /// Author: Nguyễn Văn Ngọc (2/2/2023)
    public class RegularExpressions : Attribute
    {
        #region Field

        /// <summary>
        /// Message lỗi trả về cho client
        /// </summary>
        public string ErrorMessage;

        /// <summary>
        /// Chuỗi regex
        /// </summary>
        public string Regex;
        #endregion

        #region Constructor

        /// <summary>
        /// Contructor có tham số
        /// </summary>
        /// <param name="regex">Chuỗi regex</param>
        /// <param name="propertyName">Tên thuộc tính cần regex</param>
        /// Author: Nguyễn Văn Ngọc (2/2/2023)
        public RegularExpressions(string regex, string propertyName)
        {
            Regex = regex;
            ErrorMessage = propertyName + " không đúng định dạng";

        }
        #endregion
    }
}
