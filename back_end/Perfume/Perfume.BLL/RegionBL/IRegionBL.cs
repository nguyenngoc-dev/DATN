using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Perfume.BL
{
    public interface IRegionBL
    {
        /// <summary>
        /// Lấy thông tin danh sách bảng
        /// </summary>
        /// <returns>Danh sách bảng</returns>
        /// author: Nguyễn Văn Ngọc(5/2/2023)
        public object GetAllRecords(int parentID);
    }
}
