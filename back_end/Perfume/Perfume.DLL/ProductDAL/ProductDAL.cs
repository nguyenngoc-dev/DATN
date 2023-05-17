using Dapper;
using Perfume.Common;
using Perfume.Common.Resource;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using CloudinaryDotNet;
using CloudinaryDotNet.Actions;

namespace Perfume.DAL
{
    public class ProductDAL : BaseDAL<Product>, IProductDAL
    {
        #region Field
        /// <summary>
        /// Interface IDataContext
        /// </summary>
        private IDataContext _dataContext;
        private readonly Cloudinary _cloudinary;
        #endregion

        #region Constructor
        /// <summary>
        /// Hàm khởi tạo
        /// </summary>
        /// <param name="dataContext"></param>
        public ProductDAL(IDataContext dataContext, Cloudinary cloudinary)
        {
            _dataContext = dataContext;
            _cloudinary = cloudinary;
        }
        #endregion

        #region Method
        /// <summary>
        /// Lấy sản phẩm theo bộ lọc và phân trang
        /// </summary>
        /// <param name="productFilter">chuỗi lọc</param>
        /// <param name="pageNumber">Vị trí trang</param>
        /// <param name="pageSize">Số bản ghi một trang</param>
        /// <returns>Danh sách nhân viên thỏa mã điều kiện lọc</returns>
        /// author: Nguyễn Văn Ngọc(16/1/2023)
        public object GetPagination(string? productFilter = "", int pageNumber = 1, int pageSize = 10)
        {
            var sqlCommand = string.Format(Perfume.Common.Resource.Resource.Proc_GetFilter, typeof(Product).Name);
            var parameters = new DynamicParameters();
            parameters.Add("@p_PageSize", pageSize);
            parameters.Add("@p_PageNumber", pageNumber);
            parameters.Add("@p_ProductFilter", productFilter);
            parameters.Add("@p_TotalRecord", dbType: DbType.Int32, direction: ParameterDirection.Output);
            int totalPage = 1;
            int totalRecord;
            
            using (var connection = new MySqlConnection(DataContext.MySQLConnectionString))
            {
                // Lấy ra số bản ghi theo bộ lọc
                var data = connection.Query<Product>(sqlCommand, param: parameters, commandType: System.Data.CommandType.StoredProcedure).ToList();
                // Tổng số trang
                totalRecord = parameters.Get<int>("p_TotalRecord");
                totalPage = (int)Math.Ceiling((totalRecord * 1.0d) / pageSize);
                return new PagingResult
                {
                    PageCount = data.Count,
                    TotalRecord = totalRecord,
                    TotalPage = totalPage,
                    Data = data,
                };
            }
        }

        /// <summary>
        /// Lấy mã sản phẩm mới
        /// </summary>
        /// <returns>Mã sản phẩm mới</returns>
        /// author:Nguyễn Văn Ngọc(30/1/2023)
        public string GetNewProductCode()
        {
            using (var connection = new MySqlConnection(DataContext.MySQLConnectionString))
            {
                var sqlCommand = string.Format(Perfume.Common.Resource.Resource.Proc_GetNewCode, typeof(Product).Name);
                var data = connection.QueryFirstOrDefault(sqlCommand, commandType: System.Data.CommandType.StoredProcedure);
                return data.NewProductCode;
            }
        }

        /// <summary>
        /// Hàm xử lí mã trùng
        /// </summary>
        /// <param name="product">Sản phẩm</param>
        /// <returns>ID sản phẩm vừa kiểm tra trùng</returns>
        /// author: Nguyễn Văn Ngọc(30/1/2023)
        public object IsDuplicateCode(Product product)
        {
            using (var connection = new MySqlConnection(DataContext.MySQLConnectionString))
            {
                var sqlCommand = string.Format(Perfume.Common.Resource.Resource.Proc_GetCheckCode, typeof(Product).Name);
                var parameters = new DynamicParameters();
                parameters.Add("@p_ProductCode", product.ProductCode);
                var emp = connection.QueryFirstOrDefault(sqlCommand, param: parameters, commandType: System.Data.CommandType.StoredProcedure);
                if (emp != null)
                    return emp.ProductId;
                else
                    return emp;
            }
        }

        /// <summary>
        /// Xuất ra excel danh sách sản phẩm
        /// </summary>
        /// <param name="productFilter">chuỗi lọc</param>
        /// <param name="pageNumber">Vị trí trang</param>
        /// <param name="pageSize">Số bản ghi một trang</param>
        /// <returns>Danh sách sản phẩm thỏa mã điều kiện lọc</returns>
        /// author: Nguyễn Văn Ngọc(30/1/2023)
        public IEnumerable<Product> GetProductsExcel(string? productFilter = "", int pageNumber = 1, int pageSize = 10)
        {
            var sqlCommand = string.Format(Perfume.Common.Resource.Resource.Proc_GetFilter, typeof(Product).Name);
            var parameters = new DynamicParameters();
            parameters.Add("@p_PageSize", pageSize);
            parameters.Add("@p_PageNumber", pageNumber);
            parameters.Add("@p_ProductFilter", productFilter);
            parameters.Add("@p_TotalRecord", dbType: DbType.Int32, direction: ParameterDirection.Output);


            using (var connection = new MySqlConnection(DataContext.MySQLConnectionString))
            {
                // Lấy ra số bản ghi theo bộ lọc
                var data = connection.Query<Product>(sqlCommand, param: parameters, commandType: System.Data.CommandType.StoredProcedure).ToList();
                // Tổng số trang
                return data;
            }
        }
        protected override Product CustomParam(Product record, Guid recordId, bool isInsert)
        {
            if (!isInsert)
            {
                var imgDelete = new List<String>() { recordId.ToString() };
                var uploadResultDelete = _cloudinary.DeleteResources(imgDelete.ToArray());
            }
            var uploadParams = new ImageUploadParams()
            {
                File = new FileDescription(record.AttachFile.FileName, record.AttachFile.OpenReadStream()),
                PublicId = recordId.ToString(),
            };
            var uploadResult = _cloudinary.Upload(uploadParams);
            record.ImageUrl = uploadResult.Uri.AbsoluteUri;
            return record;
        }

        #endregion

    }
}
