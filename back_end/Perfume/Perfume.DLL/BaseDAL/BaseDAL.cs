using Dapper;
using Perfume.Common;
using Perfume.Common.Resource;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Perfume.DAL
{
    public class BaseDAL<T> : IBaseDAL<T>
    {

        #region Method

        /// <summary>
        /// Xóa 1 hoặc nhiều bản ghi
        /// </summary>
        /// <param name="recordIDs">Danh sách ID của bản ghi muốn xóa</param>
        /// <returns>Số lượng bản ghi vừa xóa</returns>
        /// Author: Nguyễn Văn Ngọc (7/2/2023)
        public int DeleteRecords(List<Guid> recordIDs)
        {
            // Khai báo tên stored procedure 

            string storedProcedureName = String.Format(Resource.Proc_Delete, typeof(T).Name);

            var listRecordIDs = "";
            // Chuẩn bị tham số đầu vào cho procedure
            var parameters = new DynamicParameters();
            listRecordIDs = $"{String.Join(",", recordIDs)}";

            parameters.Add($"p_{typeof(T).Name}Ids", listRecordIDs);
            using (var mysqlConnection = new MySqlConnection(DataContext.MySQLConnectionString))
            {
                mysqlConnection.Open();

                using (var transaction = mysqlConnection.BeginTransaction())
                {
                    try
                    {
                        var numberOfAffectedRows = mysqlConnection.Execute(storedProcedureName, transaction: transaction, param: parameters, commandType: System.Data.CommandType.StoredProcedure);
                        transaction.Commit();
                        return numberOfAffectedRows;
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                        transaction.Rollback();
                        return 0;
                    }
                }
            }
        }

        /// <summary>
        /// Lấy thông tin danh sách bảng
        /// </summary>
        /// <returns>Danh sách bảng</returns>
        /// author: Nguyễn Văn Ngọc(5/2/2023)
        public object GetAllRecords()
        {
            using (var connection = new MySqlConnection(DataContext.MySQLConnectionString))
            {
                var sqlCommand = string.Format(Resource.Proc_GetAll, typeof(T).Name);
                var parameters = new DynamicParameters();
                var data = connection.Query<T>(sqlCommand, param: parameters, commandType: System.Data.CommandType.StoredProcedure).ToList();
                return data;
            }
        }

        /// <summary>
        /// Lấy bản ghi theo id
        /// </summary>
        /// <param name="recordId">Id của bản ghi</param>
        /// <returns>Bản ghi có id trùng</returns>
        /// author: Nguyễn Văn Ngọc(5/2/2023)
        public object GetRecordById(Guid recordId)
        {
            using (var connection = new MySqlConnection(DataContext.MySQLConnectionString))
            {
                var sqlCommand = string.Format(Resource.Proc_GetByID, typeof(T).Name);
                var parameters = new DynamicParameters();
                string propertyName = typeof(T).GetProperties()[0].Name;
                parameters.Add($"p_{propertyName}", recordId);
                var employee = connection.QueryFirstOrDefault(sqlCommand, param: parameters, commandType: System.Data.CommandType.StoredProcedure);
                return employee;
            }
        }

        /// <summary>
        /// Thêm mới bản ghi
        /// </summary>
        /// <param name="record">Đối tượng cần thêm</param>
        /// <returns>Trả về id bản ghi nếu thành công, emty id nếu thất bại</returns>
        /// author: Nguyễn Văn Ngọc(5/2/2023)
        public Guid InsertRecord(T record)
        {
            Guid result;
            int rowAdds = 0;
            var parameters = new DynamicParameters();
            var newRecordID = Guid.NewGuid();
            using (var connection = new MySqlConnection(DataContext.MySQLConnectionString))
            {
                connection.Open();
                HandleParams(record, newRecordID, out parameters);
                using (var transaction = connection.BeginTransaction())
                {
                    try
                    {
                        var sqlCommand = string.Format(Resource.Proc_Insert, typeof(T).Name);
                        rowAdds = connection.Execute(sqlCommand, param: parameters, commandType: System.Data.CommandType.StoredProcedure, transaction: transaction);
                        transaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        Console.WriteLine(ex.Message);
                    }

                }
                connection.Close();
            }
            if (rowAdds > 0)
            {
                result = newRecordID;
            }
            else
            {
                result = Guid.Empty;
            }
            return result;
        }

        /// <summary>
        /// Sửa thông tin bản ghi
        /// </summary>
        /// <param name="record">Đối tượng cần sửa</param>
        /// <param name="recordId">id cần sửa của đối tượng</param>
        /// <returns>Trả về id  nếu thành công, emty id nếu thất bại</returns>
        /// author: Nguyễn Văn Ngọc(5/2/2023)
        public Guid UpdateRecord(T record, Guid recordId)
        {
            Guid result;
            int rowAdds = 0;
            var parameters = new DynamicParameters();
            using (var connection = new MySqlConnection(DataContext.MySQLConnectionString))
            {
                connection.Open();
                HandleParams(record, recordId, out parameters);
                using (var transaction = connection.BeginTransaction())
                {
                    try
                    {
                        var sqlCommand = string.Format(Resource.Proc_Update, typeof(T).Name);
                        rowAdds = connection.Execute(sqlCommand, param: parameters, commandType: System.Data.CommandType.StoredProcedure, transaction: transaction);
                        transaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        Console.WriteLine(ex.Message);
                    }

                }
                connection.Close();
            }
            if (rowAdds > 0)
            {
                result = recordId;
            }
            else
            {
                result = Guid.Empty;
            }
            return result;
        }

        /// <summary>
        /// Hàm xử lí tham số trước khi thêm hoặc sửa
        /// </summary>
        /// <param name="record">Bản ghi</param>
        /// <param name="recordId">Id của bản ghi</param>
        /// <param name="parameters">Tham số đầu vào</param>
        /// Author:Nguyễn Văn Ngọc(10/2/2023)
        private void HandleParams(T record, Guid recordId, out DynamicParameters parameters)
        {
            parameters = new DynamicParameters();
            // Lấy danh sách property của nhân viên
            var properties = typeof(T).GetProperties();
            foreach (var property in properties)
            {
                string propertyName = property.Name;
                object propertyValue;

                var primaryKeyAttribute = (PrimaryKeyAttribute?)Attribute.GetCustomAttribute(property, typeof(PrimaryKeyAttribute));

                if (primaryKeyAttribute != null)
                {
                    propertyValue = recordId;
                }
                else
                {
                    propertyValue = property.GetValue(record, null);
                }
                parameters.Add($"p_{propertyName}", propertyValue);

            }
        }
        #endregion
    }
}
