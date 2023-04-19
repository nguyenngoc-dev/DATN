
using Perfume.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Perfume.BL
{
    public interface ICategoryBL : IBaseBL<Category>
    {
        /// <summary>
        /// Lấy mã danh mục mới
        /// </summary>
        /// <returns>Mã sản phẩm mới</returns>
        /// author:Nguyễn Văn Ngọc(30/1/2023)
        public string GetNewCategoryCode();
    }
}
