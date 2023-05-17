using Dapper;
using MySqlConnector;
using Perfume.Common.Resource;
using Perfume.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Perfume.DAL
{
    public class RegionDAL : IRegionDAL
    {
        /// <summary>
        /// Lấy thông tin danh sách bảng
        /// </summary>
        /// <returns>Danh sách bảng</returns>
        /// author: Nguyễn Văn Ngọc(5/2/2023)
        public object GetAllRecords(int parentID)
        {
            using (var connection = new MySqlConnection(DataContext.MySQLConnectionString))
            {
                // Chuẩn bị tham số đầu vào cho procedure
                var parameters = new DynamicParameters();
                parameters.Add($"p_ParentID", parentID);
                var sqlCommand = string.Format(Resource.Proc_GetAll, typeof(Region).Name);
                var data = connection.Query<Region>(sqlCommand, param: parameters, commandType: System.Data.CommandType.StoredProcedure).ToList();
                return data;
            }
        }
    }
}
