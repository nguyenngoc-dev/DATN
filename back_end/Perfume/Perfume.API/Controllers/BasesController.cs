using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Perfume.Common;
using Perfume.Common.Resource;
using Perfume.BL;

namespace Perfume.API
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class BasesController<T> : ControllerBase
    {
        #region Field

        private readonly IBaseBL<T> _baseBL;

        #endregion

        #region Constructor

        public BasesController(IBaseBL<T> baseBL)
        {
            _baseBL = baseBL;
        }

        #endregion

        #region Method

        /// <summary>
        /// Xóa bản ghi
        /// </summary>
        /// <param name="recordId">Id bản ghi cần xóa</param>
        /// <returns>Status code, số dòng ảnh hưởng</returns>
        /// author: Nguyễn Văn Ngọc(16/1/2023)
        [HttpDelete]
        public IActionResult DeleteRecords(List<Guid> recordIDs)
        {
            try
            {
                var result = _baseBL.DeleteRecords(recordIDs);
                // trả về số dòng ảnh hưởng
                return StatusCode(StatusCodes.Status200OK, result);
            }
            catch (Exception ex)
            {
                return HandleExeption(ex, Resource.MoreInfo_Exception);

            }
        }

        /// <summary>
        /// API lấy toàn bộ bản ghi trong 1 bảng
        /// </summary>
        /// <returns>Danh sách toàn bộ bản ghi trong bảng</returns>
        /// Author: Nguyễn Văn Ngọc (6/2/2023)
        [HttpGet]
        public IActionResult GetAllRecords()
        {
            try
            {
                var result = _baseBL.GetAllRecords();
                return StatusCode(StatusCodes.Status200OK, result);
            }
            catch (Exception ex)
            {
                return HandleExeption(ex, Resource.MoreInfo_Exception);

            }
        }

        /// <summary>
        /// Lấy bản ghi theo id
        /// </summary>
        /// <param name="recordId">id của bản ghi cần lấy</param>
        /// <returns>Status code, bản ghi có id trùng</returns>
        /// author: Nguyễn Văn Ngọc(16/1/2023)
        [HttpGet]
        [Route("{recordId}")]
        public IActionResult GetRecordById(Guid recordId)
        {
            try
            {
                var result = _baseBL.GetRecordById(recordId);
                // trả về employee
                return StatusCode(StatusCodes.Status200OK, result);

            }
            catch (Exception ex)
            {
                return HandleExeption(ex, Resource.MoreInfo_Exception);

            }
        }

        /// <summary>
        /// Thêm mới bản ghi
        /// </summary>
        /// <param name="record">Bảng cần thêm</param>
        /// <returns>Status code, Dữ liệu trả về khi thành công hoặc lỗi</returns>
        /// author: Nguyễn Văn Ngọc(16/1/2023)
        [HttpPost]
        public virtual IActionResult InsertRecord([FromBody] T record)
        {
            try
            {
                var result = _baseBL.InsertRecord(record);
                if (result.Success)
                {
                    return StatusCode(StatusCodes.Status201Created, result.Data);
                }
                else
                {
                    return StatusCode(StatusCodes.Status400BadRequest, new ErrorResult(
                    ErrorCode.InsertFailed,
                    Resource.DevMsg_InsertFailed,
                    Resource.UserMsg_InsertFailed,
                    result.Data,
                    HttpContext.TraceIdentifier));
                }
            }
            catch (Exception ex)
            {
                return HandleExeption(ex, Resource.MoreInfo_InsertFailed);
            }
        }

        /// <summary>
        /// Sửa thông tin bản ghi
        /// </summary>
        /// <param name="record">Bảng cần sửa</param>
        /// <param name="recordId">Id bản ghi cần sửa</param>
        /// <returns>Status code, Dữ liệu trả về khi thành công hoặc lỗi</returns>
        /// author: Nguyễn Văn Ngọc(16/1/2023)
        [HttpPut]
        [Route("{recordId}")]
        public virtual IActionResult UpdateRcord([FromBody] T record, [FromRoute] Guid recordId)
        {
            try
            {
                var result = _baseBL.UpdateRecord(record, recordId);

                if (result.Success)
                {
                    return StatusCode(StatusCodes.Status200OK, result.Data);
                }
                else
                {
                    return StatusCode(StatusCodes.Status400BadRequest, new ErrorResult(
                    ErrorCode.UpdateFailed,
                    Resource.DevMsg_UpdateFailed,
                    Resource.UserMsg_UpdateFailed,
                    result.Data,
                    HttpContext.TraceIdentifier));
                }
            }
            catch (Exception ex)
            {
                return HandleExeption(ex, Resource.MoreInfo_UpdateFailed);
            }
        }

        /// <summary>
        /// Hàm xử lí ngoại lệ
        /// </summary>
        /// <param name="ex">Đối tượng exeption</param>
        /// <param name="errorCode">Mã lỗi</param>
        /// <param name="moreInfo">Chi tiết lỗi</param>
        /// <returns>status code và object lỗi</returns>
        /// author: Nguyễn Văn Ngọc(30/1/2023)
        private IActionResult HandleExeption(Exception ex, object moreInfo)
        {
            Console.WriteLine(ex.Message);
            return StatusCode(StatusCodes.Status500InternalServerError, new ErrorResult(
                ErrorCode.Exception,
                Resource.DevMsg_Exception,
                Resource.UserMsg_Exception,
                moreInfo,
                HttpContext.TraceIdentifier));
        }
        #endregion
    }
}
