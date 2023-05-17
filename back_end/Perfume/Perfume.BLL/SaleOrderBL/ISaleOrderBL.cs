using Perfume.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Perfume.BL
{
    public interface ISaleOrderBL : IBaseBL<SaleOrder>
    {
        /// <summary>
        /// Lấy mã hóa đơn mới
        /// </summary>
        /// <returns>Mã sản phẩm mới</returns>
        /// author:Nguyễn Văn Ngọc(30/1/2023)
        public string GetNewSaleOrderCode();

        /// <summary>
        /// Lọc hóa đơn theo ngày
        /// </summary>
        /// <param name="fromDate"></param>
        /// <param name="toDate"></param>
        /// <returns></returns>
        public object GetPagination(DateTime fromDate, DateTime toDate);

       /// <summary>
       /// Xuất excel danh sách hóa đơn
       /// </summary>
       /// <param name="fromDate">Từ ngày</param>
       /// <param name="toDate">Đến ngày</param>
       /// <returns></returns>
        public Byte[] GetSaleOrdersExcel(DateTime fromDate, DateTime toDate);

    }
}
