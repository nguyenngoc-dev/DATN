using Dapper;
using MySqlConnector;
using Perfume.Common;
using Perfume.Common.Resource;
using System;
using System.Collections.Generic;
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
    }
}
