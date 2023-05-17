using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Dapper;
using MySqlConnector;
using Perfume.Common;
using Perfume.Common.Resource;
using Perfume.BL;

namespace Perfume.API
{
    public class ProductsController : BasesController<Product>
    {
        #region Field

        private IProductBL _productBL;

        #endregion

        #region Constructor
        public ProductsController(IProductBL productBL) :base(productBL)
        {
            _productBL = productBL;
        }
        #endregion

        #region Method

        /// <summary>
        /// Lấy sản phẩm theo bộ lọc và phân trang
        /// </summary>
        /// <param name="filterParam">đối tượng lọc</param>
        /// <returns>status code và dữ liệu</returns>
        /// author: Nguyễn Văn Ngọc(16/1/2023)
        [HttpPost("filter")]
        public IActionResult GetPagination( [FromBody] FilterParam filterParam)
        {
            try
            {
               var result = _productBL.GetPagination(filterParam.ProductFilter, filterParam.PageNumber, filterParam.PageSize);
                    return StatusCode(StatusCodes.Status200OK, result);

            }
            catch (Exception ex)
            {
                return HandleExeption(ex,ErrorCode.Exception,Resource.MoreInfo_Exception);
            }

        }

        /// <summary>
        /// Lấy mã sản phẩm mới
        /// </summary>
        /// <returns>Mã sản phẩm mới</returns>
        /// author:Nguyễn Văn Ngọc(30/1/2023)
        [HttpGet]
        [Route("new-product-code")]
        public IActionResult GetNewProductCode()
        {
            try
            {
                var result = _productBL.GetNewProductCode();
                return StatusCode(StatusCodes.Status200OK, result);
                

            }
            catch (Exception ex)
            {
                return HandleExeption(ex,ErrorCode.Exception, Resource.MoreInfo_Exception);

            }
        }

        /// <summary>
        /// Hàm xử lí ngoại lệ
        /// </summary>
        /// <param name="ex"></param>
        /// <returns>status code và object lỗi</returns>
        /// author: Nguyễn Văn Ngọc(30/1/2023)
        private IActionResult HandleExeption(Exception ex, ErrorCode errorCode,string moreInfo)
        {
            Console.WriteLine(ex.Message);
            return StatusCode(StatusCodes.Status500InternalServerError, new ErrorResult(
                errorCode,
                Resource.DevMsg_Exception,
                Resource.UserMsg_Exception,
                moreInfo,
                HttpContext.TraceIdentifier));
        }

        /// <summary>
        /// Xuất khẩu ra excel
        /// </summary>
        /// <param name="filterParam">Đối tượng nhận tham số</param>
        /// <returns>File danh sách sản phẩm</returns>
        /// author: Nguyễn Văn Ngọc(30/1/2023)
        [HttpPost]
        [Route("get-employees-excel")]
        public IActionResult GetProductsExcel([FromBody] FilterParam filterParam)
        {
            try
            {
                var content = _productBL.GetProductsExcel(filterParam.ProductFilter, filterParam.PageNumber, filterParam.PageSize);
                return File(content, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "Danh_sach_sản phẩm.xlsx");
            }
            catch (Exception ex)
            {
                return HandleExeption(ex, ErrorCode.Exception, Resource.MoreInfo_Exception);
            }
        }
        public override IActionResult InsertRecord([FromForm] Product record)
        {
            return base.InsertRecord(record);
        }
        public override IActionResult UpdateRcord([FromForm] Product record, [FromRoute] Guid recordId)
        {
            return base.UpdateRcord(record, recordId);
        }
        #endregion
    }
}
