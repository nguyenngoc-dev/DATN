using Microsoft.AspNetCore.Mvc;
using Perfume.BL;
using Perfume.Common;
using Perfume.Common.Resource;

namespace Perfume.API
{
    public class SaleOrdersController : BasesController<SaleOrder>
    {
        #region Field
        private ISaleOrderBL _saleorderBL;
        #endregion

        #region Constructor
        /// <summary>
        /// Hàm khởi tạo
        /// </summary>
        /// <param name="_productimageBL">Đối tượng IProductImageBL</param>
        public SaleOrdersController(ISaleOrderBL saleorderBL) : base(saleorderBL)
        {
            _saleorderBL = saleorderBL;

        }
        #endregion
        /// <summary>
        /// Lấy mã sản phẩm mới
        /// </summary>
        /// <returns>Mã sản phẩm mới</returns>
        /// author:Nguyễn Văn Ngọc(30/1/2023)
        [HttpGet]
        [Route("new-sale-order-code")]
        public IActionResult GetNewProductCode()
        {
            try
            {
                var result = _saleorderBL.GetNewSaleOrderCode();
                return StatusCode(StatusCodes.Status200OK, result);


            }
            catch (Exception ex)
            {
                return HandleExeption(ex, ErrorCode.Exception, Resource.MoreInfo_Exception);

            }
        }
        /// <summary>
        /// Hàm xử lí ngoại lệ
        /// </summary>
        /// <param name="ex"></param>
        /// <returns>status code và object lỗi</returns>
        /// author: Nguyễn Văn Ngọc(30/1/2023)
        private IActionResult HandleExeption(Exception ex, ErrorCode errorCode, string moreInfo)
        {
            Console.WriteLine(ex.Message);
            return StatusCode(StatusCodes.Status500InternalServerError, new ErrorResult(
                errorCode,
                Resource.DevMsg_Exception,
                Resource.UserMsg_Exception,
                moreInfo,
                HttpContext.TraceIdentifier));
        }

    }
}
