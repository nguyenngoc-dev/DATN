using Perfume.DAL;
using Perfume.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Perfume.BL
{
    public class RegionBL:IRegionBL
    {
        #region Field
        /// <summary>
        /// Interface IBaseDAL
        /// </summary>
        private readonly IRegionDAL _regionDAL;

        #endregion

        #region Constructor
        /// <summary>
        /// Hàm khởi tạo
        /// </summary>
        /// <param name="baseDAL"></param>
        public RegionBL(IRegionDAL regionDAL)
        {
            _regionDAL = regionDAL;
        }

        /// <summary>
        /// Lấy thông tin danh sách bảng
        /// </summary>
        /// <returns>Danh sách bảng</returns>
        /// author: Nguyễn Văn Ngọc(5/2/2023)
        public object GetAllRecords(int parentID)
        {
            return _regionDAL.GetAllRecords(parentID);
        }

        #endregion
    }
}
