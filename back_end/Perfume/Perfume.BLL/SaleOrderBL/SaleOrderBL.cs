using Perfume.Common;
using Perfume.Common.Resource;
using ClosedXML.Excel;
using DocumentFormat.OpenXml.Spreadsheet;
using Perfume.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Perfume.BL
{
    public class SaleOrderBL : BaseBL<SaleOrder>, ISaleOrderBL
    {

        #region Field
        /// <summary>
        /// Interface IProductDAL
        /// </summary>
        private ISaleOrderDAL _saleorderDAL;
        #endregion

        #region Constructor
        /// <summary>
        /// Hàm khởi tạo
        /// </summary>
        /// <param name="productDAL"></param>
        public SaleOrderBL(ISaleOrderDAL saleorderDAL) : base(saleorderDAL)
        {
            _saleorderDAL = saleorderDAL;
        }
        /// <summary>
        /// Lấy mã hóa đơn mới
        /// </summary>
        /// <returns>Mã sản phẩm mới</returns>
        /// author:Nguyễn Văn Ngọc(30/1/2023)
        public string GetNewSaleOrderCode()
        {
            return _saleorderDAL.GetNewSaleOrderCode();
        }

        public object GetPagination(DateTime fromDate, DateTime toDate)
        {
            return _saleorderDAL.GetPagination(fromDate, toDate);
        }

        /// <summary>
        /// Xuất excel danh sách hóa đơn
        /// </summary>
        /// <param name="fromDate">Từ ngày</param>
        /// <param name="toDate">Đến ngày</param>
        /// <returns></returns>
        public Byte[] GetSaleOrdersExcel(DateTime fromDate, DateTime toDate)
        {
            var firstSaleOrders = _saleorderDAL.GetSaleOrdersExcel(fromDate, toDate);
            List<SaleOrder> saleOrders = new List<SaleOrder>();
                foreach (var item in firstSaleOrders)
                {
                   if(item.Status == 2)
                    {
                        saleOrders.Add(item);
                    }
                    
                }
            var total = 0;
            // Khai báo Workbook
            using (var wb = new XLWorkbook())
            {
                // Khai báo số dòng bắt đầu in dữ liệu
                int currentRow = 4;
                int[] tableWidth = { 7, 18, 25, 17, 50, 25, 35, 21, 35, 21, 21, 21 };
                // Khai số thứ tự
                int numberOrder = 0;

                // Tạo một sheet mới
                var ws = wb.Worksheets.Add(typeof(SaleOrder).Name);

                // Tạo tiêu đề của sheet
                var range = ws.Range(Resource.Range_Worksheet);
                range.Merge().Value = Resource.Title_Worksheet;
                range.Style.Font.Bold = true;
                range.Style.Font.FontSize = 16;
                range.Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);

                // Tạo thời gian xuất báo cáo
                var rangeDate = ws.Range(Resource.Range_Worksheet_Date);
                rangeDate.Merge().Value = string.Format(Resource.Title_Worksheet_Date, fromDate.ToString("dd/MM/yyyy"),toDate.ToString("dd/MM/yyyy")) ;
                rangeDate.Style.Font.Bold = true;
                rangeDate.Style.Font.FontSize = 13;
                rangeDate.Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);
                // Set thuộc tính của thead
                for (int i = 1; i < 9; i++)
                {
                    ws.Cell(currentRow, i).Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);
                    ws.Cell(currentRow, i).Style.Fill.SetBackgroundColor(XLColor.LightGray);
                    ws.Cell(currentRow, i).Style.Font.Bold = true;
                    ws.Column(i).Width = tableWidth[i - 1];
                }

                // Set giá trị của head
                ws.Cell(currentRow, 1).Value = Resource.Number_Order;
                ws.Cell(currentRow, 2).Value = Resource.SaleOrderCode;
                ws.Cell(currentRow, 3).Value = Resource.SaleOrderDate;
                ws.Cell(currentRow, 4).Value = Resource.CustomerName;
                ws.Cell(currentRow, 5).Value = Resource.CustomerAddress;
                ws.Cell(currentRow, 6).Value = Resource.PhoneNumber;
                ws.Cell(currentRow, 7).Value = Resource.Status;
                ws.Cell(currentRow, 8).Value = Resource.TotalPrice;
                
                // Set giá trị của body
                foreach (var saleOrder in saleOrders)
                {
                    currentRow++;
                    numberOrder++;
                    total= total + saleOrder.TotalPrice;
                    ws.Cell(currentRow, 1).Value = numberOrder;
                    ws.Cell(currentRow, 2).Value = saleOrder.SaleOrderCode;
                    ws.Cell(currentRow, 3).Value = saleOrder.CreatedDate;
                    ws.Cell(currentRow, 4).Value = saleOrder.FirstName + ' ' + saleOrder.LastName;
                    ws.Cell(currentRow, 5).Value = saleOrder.CustomerAddress;
                    ws.Cell(currentRow, 6).Value = "'" + saleOrder.CustomerPhone;
                    ws.Cell(currentRow, 7).Value = FormatStatus(saleOrder.Status);
                    ws.Cell(currentRow, 8).Value = saleOrder.TotalPrice;
                    ws.Cell(saleOrders.Count() + 5, 7).Value = "Tổng tiền";
                    ws.Cell(saleOrders.Count() + 5, 8).Value = total;
                    ws.Cell(saleOrders.Count() + 5, 7).Style.Font.Bold = true;

                    // Căn giữa các trường
                    ws.Cell(currentRow, 1).Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);
                    ws.Cell(currentRow, 3).Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);

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
            }
        }
        
        
        public string FormatStatus(int status)
        {
            if (status == 1)
            {
                return "Đang giao hàng";
            }
            else if (status == 2)
            {
                return "Giao thành công";
            }
            else if (status == 3)
            {
                return "Đơn hàng bị hủy";
            }
            else
            {
                return "Đang chuẩn bị hàng";
            }
        }
        #endregion
    }
}
