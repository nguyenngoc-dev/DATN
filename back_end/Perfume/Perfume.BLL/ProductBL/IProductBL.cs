using Perfume.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Perfume.BL
{
    public interface IProductBL:IBaseBL<Product>
    {
        #region Method

        /// <summary>
        /// Lấy sản phẩm theo bộ lọc và phân trang
        /// </summary>
        /// <param name="productFilter">chuỗi lọc</param>
        /// <param name="pageNumber">Vị trí trang</param>
        /// <param name="pageSize">Số bản ghi một trang</param>
        /// <returns>Danh sách nhân viên thỏa mã điều kiện lọc</returns>
        /// author: Nguyễn Văn Ngọc(16/1/2023)
        public object GetPagination(string? productFilter = "", int pageNumber = 1, int pageSize = 10);

        /// <summary>
        /// Lấy mã sản phẩm mới
        /// </summary>
        /// <returns>Mã sản phẩm mới</returns>
        /// author:Nguyễn Văn Ngọc(30/1/2023)
        public string GetNewProductCode();

        /// <summary>
        /// Xuất ra excel danh sách sản phẩm
        /// </summary>
        /// <param name="productFilter">chuỗi lọc</param>
        /// <param name="pageNumber">Vị trí trang</param>
        /// <param name="pageSize">Số bản ghi một trang</param>
        /// <returns>Danh sách sản phẩm thỏa mã điều kiện lọc</returns>
        /// author: Nguyễn Văn Ngọc(30/1/2023)
        public Byte[] GetProductsExcel(string? productFilter = "", int pageNumber = 1, int pageSize = 10);

        #endregion


    }
}
