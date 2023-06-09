﻿
using Perfume.Common;
using Perfume.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Perfume.BL
{
    public class CategoryBL : BaseBL<Category>,ICategoryBL
    {

        #region Field
        /// <summary>
        /// Interface IProductDAL
        /// </summary>
        private ICategoryDAL _categoryDAL;
        #endregion

        #region Constructor
        /// <summary>
        /// Hàm khởi tạo
        /// </summary>
        /// <param name="productDAL"></param>
        public CategoryBL(ICategoryDAL categoryDAL) : base(categoryDAL)
        {
            _categoryDAL = categoryDAL;
        }
        #endregion

        /// <summary>
        /// Lấy mã danh mục mới
        /// </summary>
        /// <returns>Mã sản phẩm mới</returns>
        /// author:Nguyễn Văn Ngọc(30/1/2023)
        public string GetNewCategoryCode()
        {
            return _categoryDAL.GetNewCategoryCode();
        }
    }
}
