using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Perfume.Common
{
    /// <summary>
    /// Dữ liệu trả về từ tầng BL
    /// </summary>
    public class ServiceResponse
    {
        #region Property
        /// <summary>
        /// Valid thành công hay thất bại
        /// </summary>
        public bool Success { get; set; }

        /// <summary>
        /// Dữ liệu trả về
        /// </summary>
        public dynamic? Data { get; set; } 
        #endregion
    }
}
