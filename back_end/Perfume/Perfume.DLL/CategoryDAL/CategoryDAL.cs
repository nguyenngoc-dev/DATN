﻿using Dapper;
using Perfume.Common;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Perfume.Common.Resource;

namespace Perfume.DAL
{
    public class CategoryDAL : BaseDAL<Category>,ICategoryDAL
    {

        /// <summary>
        /// Lấy mã danh mục mới
        /// </summary>
        /// <returns>Mã sản phẩm mới</returns>
        /// author:Nguyễn Văn Ngọc(30/1/2023)
        public string GetNewCategoryCode()
        {
            using (var connection = new MySqlConnection(DataContext.MySQLConnectionString))
            {
                var sqlCommand = string.Format(Resource.Proc_GetNewCode, typeof(Category).Name);
                var data = connection.QueryFirstOrDefault(sqlCommand, commandType: System.Data.CommandType.StoredProcedure);
                return data.NewCategoryCode;
            }
        }
    }
}
