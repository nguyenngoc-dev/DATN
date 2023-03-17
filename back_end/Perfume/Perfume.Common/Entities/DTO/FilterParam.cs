using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Perfume.Common
{
    public class FilterParam
    {
        #region Property
        /// <summary>
        /// Chuỗi tìm kiếm
        /// </summary>
        public string? EmployeeFilter { get; set; }

        /// <summary>
        /// Số bản ghi một trang
        /// </summary>
        public int PageSize { get; set; }

        /// <summary>
        /// Vị trí trang
        /// </summary>
        public int PageNumber { get; set; }
        #endregion
    }
}
