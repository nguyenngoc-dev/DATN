using Microsoft.AspNetCore.Mvc;
using Perfume.Common;
using Perfume.Common.Resource;
using Perfume.BL;


namespace Perfume.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class RegionsController : ControllerBase
    {
        #region Field

        private readonly IRegionBL _regionBL;

        #endregion

        #region Constructor

        public RegionsController(IRegionBL regionBL)
        {
            _regionBL = regionBL;
        }

        #endregion
        /// <summary>
        /// API lấy toàn bộ bản ghi trong 1 bảng
        /// </summary>
        /// <returns>Danh sách toàn bộ bản ghi trong bảng</returns>
        /// Author: Nguyễn Văn Ngọc (6/2/2023)
        [HttpGet]
        public IActionResult GetAllRecords([FromQuery] int parentID)
        {
            try
            {
                var result = _regionBL.GetAllRecords(parentID);
                return StatusCode(StatusCodes.Status200OK, result);
            }
            catch (Exception ex)
            {
                return HandleExeption(ex, Resource.MoreInfo_Exception);

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
    }
}
