﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Dapper;
using MySqlConnector;
using Perfume.Common;
using Perfume.BL;
using Perfume.Common.Resource;

namespace Perfume.API
{

    public class CategorysController : BasesController<Category>
    {
        #region Field
        private ICategoryBL _categoryBL;
        #endregion

        #region Constructor
        /// <summary>
        /// Hàm khởi tạo
        /// </summary>
        /// <param name="_departmentBL">Đối tượng ICategoryBL</param>
        public CategorysController(ICategoryBL categoryBL) : base(categoryBL)
        {
            _categoryBL = categoryBL;
           
        }
        #endregion
        /// <summary>
        /// Lấy mã sản phẩm mới
        /// </summary>
        /// <returns>Mã sản phẩm mới</returns>
        /// author:Nguyễn Văn Ngọc(30/1/2023)
        [HttpGet]
        [Route("new-category-code")]
        public IActionResult GetNewCategoryCode()
        {
            try
            {
                var result = _categoryBL.GetNewCategoryCode();
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
