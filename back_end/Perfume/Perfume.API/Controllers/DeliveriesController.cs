﻿using Microsoft.AspNetCore.Mvc;
using Perfume.BL;
using Perfume.Common.Resource;
using Perfume.Common;

namespace Perfume.API.Controllers
{
    public class DeliveriesController : BasesController<Delivery>
    {
        #region Field
        private IDeliveryBL _deliveryBL;
        #endregion

        #region Constructor
        /// <summary>
        /// Hàm khởi tạo
        /// </summary>
        /// <param name="_departmentBL">Đối tượng IDeliveryBL</param>
        public DeliveriesController(IDeliveryBL deliveryBL) : base(deliveryBL)
        {
            _deliveryBL = deliveryBL;

        }
        #endregion
        /// <summary>
        /// Lấy mã sản phẩm mới
        /// </summary>
        /// <returns>Mã sản phẩm mới</returns>
        /// author:Nguyễn Văn Ngọc(30/1/2023)
        [HttpGet]
        [Route("new-delivery-code")]
        public IActionResult GetNewDeliveryCode()
        {
            try
            {
                var result = _deliveryBL.GetNewDeliveryCode();
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
