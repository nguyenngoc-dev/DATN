using Perfume.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Perfume.BL
{
    public interface IBaseBL<T>
    {
        #region Method

        /// <summary>
        /// Lấy thông tin danh sách bảng
        /// </summary>
        /// <returns>Danh sách bảng</returns>
        /// author: Nguyễn Văn Ngọc(5/2/2023)
        public object GetAllRecords();

        /// <summary>
        /// Lấy bản ghi theo id
        /// </summary>
        /// <param name="recordId">Id của bản ghi</param>
        /// <returns>Bản ghi có id trùng</returns>
        /// author: Nguyễn Văn Ngọc(5/2/2023)
        public object GetRecordById(Guid recordId);

        /// <summary>
        /// Thêm mới bản ghi
        /// </summary>
        /// <param name="record">Đối tượng cần thêm</param>
        /// <returns>Trả về id bản ghi nếu thành công, emty id nếu thất bại</returns>
        /// author: Nguyễn Văn Ngọc(5/2/2023)
        public ServiceResponse InsertRecord(T record);

        /// <summary>
        /// Sửa thông tin bản ghi
        /// </summary>
        /// <param name="record">Đối tượng cần sửa</param>
        /// <param name="recordId">id cần sửa của đối tượng</param>
        /// <returns>Trả về id  nếu thành công, emty id nếu thất bại</returns>
        /// author: Nguyễn Văn Ngọc(5/2/2023)
        public ServiceResponse UpdateRecord(T record, Guid recordId);

        /// <summary>
        /// Xóa 1 hoặc nhiều bản ghi
        /// </summary>
        /// <param name="recordIDs">Danh sách ID của bản ghi muốn xóa</param>
        /// <returns>Số lượng bản ghi vừa xóa</returns>
        /// Author: Nguyễn Văn Ngọc (7/2/2023)
        public int DeleteRecords(List<Guid> recordIDs);
        #endregion
    }
}
