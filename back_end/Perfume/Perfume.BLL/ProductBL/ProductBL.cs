using ClosedXML.Excel;
using DocumentFormat.OpenXml.Spreadsheet;
using Microsoft.AspNetCore.Http;
using Perfume.Common;
using Perfume.Common.Resource;
using Perfume.DAL;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Perfume.BL
{
    public class ProductBL : BaseBL<Product>, IProductBL
    {
        #region Field
        /// <summary>
        /// Interface IProductDAL
        /// </summary>
        private IProductDAL _productDAL;
        #endregion

        #region Constructor
        /// <summary>
        /// Hàm khởi tạo
        /// </summary>
        /// <param name="productDAL"></param>
        public ProductBL(IProductDAL productDAL) : base(productDAL)
        {
            _productDAL = productDAL;
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
            return _productDAL.GetPagination(productFilter.Trim(), pageNumber, pageSize);
        }

        /// <summary>
        /// Lấy mã sản phẩm mới
        /// </summary>
        /// <returns>Mã sản phẩm mới</returns>
        /// author:Nguyễn Văn Ngọc(30/1/2023)
        public string GetNewProductCode()
        {
            return _productDAL.GetNewProductCode();
        }

        /// <summary>
        /// Hàm xử lí mã trùng
        /// </summary>
        /// <param name="product">Sản phẩm</param>
        /// <param name="productId">id sản phẩm cần check</param>
        /// <returns>ServiceResponse success và dữ liệu</returns>
        /// author: Nguyễn Văn Ngọc(30/1/2023)
        protected override ServiceResponse IsDuplicateCode(Product product, Guid productId)
        {
            var checkCode = _productDAL.IsDuplicateCode(product);

            if (checkCode != null)
            {
                if (!checkCode.Equals(productId))
                {
                    return new ServiceResponse
                    {
                        Success = false,
                        Data = new ErrorResult(
                        ErrorCode.DuplicateCode,
                        Resource.DevMsg_DuplicateCode,
                        Resource.UserMsg_DuplicateCode,
                        Resource.MoreInfo_DuplicateCode)
                    };
                }
                else
                {
                    return new ServiceResponse { Success = true };
                }
            }
            return new ServiceResponse { Success = true };
        }

        /// <summary>
        /// Xuất ra excel danh sách sản phẩm
        /// </summary>
        /// <param name="productFilter">chuỗi lọc</param>
        /// <param name="pageNumber">Vị trí trang</param>
        /// <param name="pageSize">Số bản ghi một trang</param>
        /// <returns>Danh sách sản phẩm thỏa mã điều kiện lọc</returns>
        /// author: Nguyễn Văn Ngọc(30/1/2023)
        public Byte[] GetProductsExcel(string? productFilter = "", int pageNumber = 1, int pageSize = 10)
        {
            /*var employees = _productDAL.GetProductsExcel(productFilter?.Trim(), pageNumber, pageSize);

            // Khai báo Workbook
            using (var wb = new XLWorkbook())
            {
                // Khai báo số dòng bắt đầu in dữ liệu
                int currentRow = 3;
                int[] tableWidth = { 7, 18, 25, 17, 17, 25, 35, 21, 35, 21, 21, 21 };
                // Khai số thứ tự
                int numberOrder = 0;

                // Tạo một sheet mới
                var ws = wb.Worksheets.Add(typeof(Product).Name);

                // Tạo tiêu đề của sheet
                var range = ws.Range(Resource.Range_Worksheet);
                range.Merge().Value = Resource.Title_Worksheet;
                range.Style.Font.Bold = true;
                range.Style.Font.FontSize = 16;
                range.Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);

                // Set thuộc tính của thead
                for (int i = 1; i < 13; i++)
                {
                    ws.Cell(currentRow, i).Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);
                    ws.Cell(currentRow, i).Style.Fill.SetBackgroundColor(XLColor.LightGray);
                    ws.Cell(currentRow, i).Style.Font.Bold = true;
                    ws.Column(i).Width = tableWidth[i - 1];
                }

                // Set giá trị của head
                ws.Cell(currentRow, 1).Value = Resource.Number_Order;
                ws.Cell(currentRow, 2).Value = Resource.Employee_Code;
                ws.Cell(currentRow, 3).Value = Resource.FullName;
                ws.Cell(currentRow, 4).Value = Resource.Gender;
                ws.Cell(currentRow, 5).Value = Resource.DateOfBirth;
                ws.Cell(currentRow, 6).Value = Resource.Position;
                ws.Cell(currentRow, 7).Value = Resource.DepartmentName;
                ws.Cell(currentRow, 8).Value = Resource.PhoneNumber;
                ws.Cell(currentRow, 9).Value = Resource.Email;
                ws.Cell(currentRow, 10).Value = Resource.BankAccount;
                ws.Cell(currentRow, 11).Value = Resource.BankName;
                ws.Cell(currentRow, 12).Value = Resource.BankBranch;

                // Set giá trị của body
                foreach (var employee in employees)
                {
                    currentRow++;
                    numberOrder++;
                    ws.Cell(currentRow, 1).Value = numberOrder;
                    ws.Cell(currentRow, 2).Value = employee.EmployeeCode;
                    ws.Cell(currentRow, 3).Value = employee.FullName;
                    ws.Cell(currentRow, 4).Value = employee.GenderName;
                    ws.Cell(currentRow, 5).Value = employee.DateOfBirth;
                    ws.Cell(currentRow, 6).Value = employee.Position;
                    ws.Cell(currentRow, 7).Value = employee.DepartmentName;
                    ws.Cell(currentRow, 8).Value = "'" + employee.PhoneNumber;
                    ws.Cell(currentRow, 9).Value = employee.Email;
                    ws.Cell(currentRow, 10).Value = employee.BankAccount;
                    ws.Cell(currentRow, 11).Value = employee.BankName;
                    ws.Cell(currentRow, 12).Value = employee.BankBranch;


                    // Căn giữa các trường
                    ws.Cell(currentRow, 1).Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);
                    ws.Cell(currentRow, 5).Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);

                    // Set độ rộng của cột
                    
                    for (int i = 0; i < tableWidth.Length; i++)
                    {
                        ws.Column(i + 1).Width = tableWidth[i];
                    }

                }

                // Khai báo memoryStream để dữ liệu lưu trữ trên bộ nhớ
                using (var stream = new MemoryStream())
                {
                    wb.SaveAs(stream);
                    var content = stream.ToArray();
                    return content;
                }
            }*/

            return new Byte[1];
        }

        /// <summary>
        /// Ghi đè lại hàm ValidateCustom bên base
        /// </summary>
        /// <param name="product">Đối tượng product</param>
        /// <returns></returns>
        /*protected override ServiceResponse ValidateCustom(Product product)
        {
            var dateOfBirth = employee.DateOfBirth;
            var identityDate = employee.IdentityDate;
            var validateFailures = new List<string>();
            var today = DateTime.Now;
            if (dateOfBirth != null)
            {
                if (employee.DateOfBirth?.AddYears(18) > today)
                {
                    validateFailures.Add(Resource.MoreInfo_Not_Adult);
                    return new ServiceResponse
                    {
                        Success = false,
                        Data = new ErrorResult(
                        ErrorCode.InvalidInput,
                        Resource.DevMsg_ValidateFailed,
                        Resource.UserMsg_ValidateFailed,
                        validateFailures)
                    };
                }
            }
            if (identityDate != null)
            {
                if (identityDate.Value > today)
                {
                    validateFailures.Add(Resource.MoreInfo_Invalid_Date);

                    return new ServiceResponse
                    {
                        Success = false,
                        Data = new ErrorResult(
                        ErrorCode.InvalidInput,
                        Resource.DevMsg_ValidateFailed,
                        Resource.UserMsg_ValidateFailed,
                        validateFailures)
                    };
                }
            }
            return new ServiceResponse { Success = true };
        }*/
        #endregion
    }
}
