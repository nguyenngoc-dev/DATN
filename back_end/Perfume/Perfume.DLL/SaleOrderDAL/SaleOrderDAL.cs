using Dapper;
using MySqlConnector;
using Perfume.Common;
using Perfume.Common.Resource;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Perfume.DAL
{
    public class SaleOrderDAL : BaseDAL<SaleOrder>, ISaleOrderDAL
    {
        /// <summary>
        /// Lấy mã hóa đơn mới
        /// </summary>
        /// <returns>Mã sản phẩm mới</returns>
        /// author:Nguyễn Văn Ngọc(30/1/2023)
        public string GetNewSaleOrderCode()
        {
            using (var connection = new MySqlConnection(DataContext.MySQLConnectionString))
            {
                var sqlCommand = string.Format(Resource.Proc_GetNewCode, typeof(SaleOrder).Name);
                var data = connection.QueryFirstOrDefault(sqlCommand, commandType: System.Data.CommandType.StoredProcedure);
                return data.NewSaleOrderCode;
            }
        }

        public object GetPagination(DateTime fromDate, DateTime toDate)
        {
            var sqlCommand = string.Format(Resource.Proc_GetFilter, typeof(SaleOrder).Name);
            var parameters = new DynamicParameters();
            parameters.Add("@p_FromDate", fromDate);
            parameters.Add("@p_ToDate", toDate);
            parameters.Add("@p_TotalRecord", dbType: DbType.Int32, direction: ParameterDirection.Output);
            int totalPage = 1;
            int totalRecord;

            using (var connection = new MySqlConnection(DataContext.MySQLConnectionString))
            {
                // Lấy ra số bản ghi theo bộ lọc
                var data = connection.Query<SaleOrder>(sqlCommand, param: parameters, commandType: System.Data.CommandType.StoredProcedure).ToList();
                // Tổng số trang
                totalRecord = parameters.Get<int>("p_TotalRecord");
                return new 
                {
                    PageCount = data.Count,
                    TotalRecord = totalRecord,
                    Data = data,
                };
            }
        }

        /// <summary>
        /// Xuất excel danh sách hóa đơn
        /// </summary>
        /// <param name="fromDate">từ ngày</param>
        /// <param name="toDate">đến ngày</param>
        /// <returns></returns>
        public IEnumerable<SaleOrder> GetSaleOrdersExcel(DateTime fromDate, DateTime toDate)
        {
            var sqlCommand = string.Format(Resource.Proc_GetFilter, typeof(SaleOrder).Name);
            var parameters = new DynamicParameters();
            parameters.Add("@p_FromDate", fromDate);
            parameters.Add("@p_ToDate", toDate);
            parameters.Add("@p_TotalRecord", dbType: DbType.Int32, direction: ParameterDirection.Output);
            int totalPage = 1;
            int totalRecord;

            using (var connection = new MySqlConnection(DataContext.MySQLConnectionString))
            {
                // Lấy ra số bản ghi theo bộ lọc
                var data = connection.Query<SaleOrder>(sqlCommand, param: parameters, commandType: System.Data.CommandType.StoredProcedure).ToList();
                // Tổng số trang
                totalRecord = parameters.Get<int>("p_TotalRecord");
                return data;
            }
        }
    }
}
