using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Perfume.DAL
{
    public class DataContext:IDataContext
    {
        
        #region Field

        /// <summary>
        /// Chuỗi kết nối tới MySQL
        /// </summary>
        public static string MySQLConnectionString;

        #endregion
        
        #region Method

        /// <summary>
        /// Hàm tạo kết nối tới MySQL
        /// </summary>
        /// <param name="MySQLConnectionString">Chuỗi kết nối đến MySQL</param>
        /// <returns>object </returns>
        /// Author: Nguyễn Văn Ngọc(6/2/2023)
        public object CreateConnection(string MySQLConnectionString)
        {
            return new MySqlConnection(MySQLConnectionString);
        }
        #endregion
    }
}
