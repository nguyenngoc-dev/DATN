using MySqlConnector;
using Perfume.Common.Resource;
using Perfume.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;

namespace Perfume.DAL
{
    public class DeliveryDAL : BaseDAL<Delivery>, IDeliveryDAL
    {

        /// <summary>
        /// Lấy mã vận đơn mới
        /// </summary>
        /// <returns>Mã sản phẩm mới</returns>
        /// author:Nguyễn Văn Ngọc(30/1/2023)
        public string GetNewDeliveryCode()
        {
            using (var connection = new MySqlConnection(DataContext.MySQLConnectionString))
            {
                var sqlCommand = string.Format(Resource.Proc_GetNewCode, typeof(Delivery).Name);
                var data = connection.QueryFirstOrDefault(sqlCommand, commandType: System.Data.CommandType.StoredProcedure);
                return data.NewDeliveryCode;
            }
        }
    }
}
