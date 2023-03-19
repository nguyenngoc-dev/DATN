using Perfume.Common;
using Perfume.Common.Resource;
using Perfume.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Perfume.BL
{
    public class BaseBL<T> : IBaseBL<T>
    {
        #region Field
        /// <summary>
        /// Interface IBaseDAL
        /// </summary>
        private readonly IBaseDAL<T> _baseDAL;

        #endregion

        #region Constructor
        /// <summary>
        /// Hàm khởi tạo
        /// </summary>
        /// <param name="baseDAL"></param>
        public BaseBL(IBaseDAL<T> baseDAL)
        {
            _baseDAL = baseDAL;
        }

        #endregion

        #region Method

        /// <summary>
        /// Xóa 1 hoặc nhiều bản ghi
        /// </summary>
        /// <param name="recordIDs">Danh sách ID của bản ghi muốn xóa</param>
        /// <returns>Số lượng bản ghi vừa xóa</returns>
        /// Author: Nguyễn Văn Ngọc (7/2/2023)
        public int DeleteRecords(List<Guid> recordIDs)
        {
            return _baseDAL.DeleteRecords(recordIDs);
        }

        /// <summary>
        /// Lấy thông tin danh sách bảng
        /// </summary>
        /// <returns>Danh sách bảng</returns>
        /// author: Nguyễn Văn Ngọc(5/2/2023)
        public object GetAllRecords()
        {
            return _baseDAL.GetAllRecords();
        }

        /// <summary>
        /// Lấy bản ghi theo id
        /// </summary>
        /// <param name="recordId">Id của bản ghi</param>
        /// <returns>Bản ghi có id trùng</returns>
        /// author: Nguyễn Văn Ngọc(5/2/2023)
        public object GetRecordById(Guid recordId)
        {
            return _baseDAL.GetRecordById(recordId);
        }

        /// <summary>
        /// Thêm mới bản ghi
        /// </summary>
        /// <param name="record">Đối tượng cần thêm</param>
        /// <returns>Trả về id bản ghi nếu thành công, emty id nếu thất bại</returns>
        /// author: Nguyễn Văn Ngọc(5/2/2023)
        public ServiceResponse InsertRecord(T record)
        {

            var validate = ValidateRequestData(record, Guid.Empty);
            ServiceResponse serviceResponse;
            if (validate.Success)
            {

                var recordId = _baseDAL.InsertRecord(record);
                if (recordId != Guid.Empty)
                {
                    serviceResponse = new ServiceResponse
                    {
                        Success = true,
                        Data = recordId
                    };
                }
                else
                {

                    serviceResponse = new ServiceResponse
                    {
                        Success = false,
                        Data = new ErrorResult(
                        ErrorCode.InsertFailed,
                        Resource.DevMsg_InsertFailed,
                        Resource.UserMsg_InsertFailed,
                        Resource.MoreInfo_InsertFailed
                        )
                    };
                }
                return serviceResponse;
            }
            else
            {
                return new ServiceResponse
                {
                    Success = false,
                    Data = validate.Data
                };
            }
        }

        /// <summary>
        /// Sửa thông tin bản ghi
        /// </summary>
        /// <param name="record">Đối tượng cần sửa</param>
        /// <param name="recordId">id cần sửa của đối tượng</param>
        /// <returns>Trả về id  nếu thành công, emty id nếu thất bại</returns>
        /// author: Nguyễn Văn Ngọc(5/2/2023)
        public ServiceResponse UpdateRecord(T record, Guid recordId)
        {
            var validate = ValidateRequestData(record, recordId);

            if (validate != null && validate.Success)
            {

                var employeeId = _baseDAL.UpdateRecord(record, recordId);
                if (employeeId != Guid.Empty)
                {
                    return new ServiceResponse
                    {
                        Success = true,
                        Data = employeeId
                    };
                }
                else
                {
                    return new ServiceResponse
                    {
                        Success = false,
                        Data = new ErrorResult(
                        ErrorCode.UpdateFailed,
                        Resource.DevMsg_UpdateFailed,
                        Resource.UserMsg_UpdateFailed,
                        Resource.MoreInfo_UpdateFailed)
                    };
                }

            }
            else
            {
                return new ServiceResponse
                {
                    Success = false,
                    Data = validate.Data
                };
            }
        }

        /// <summary>
        /// Hàm xử lí mã trùng
        /// </summary>
        /// <param name="record">Đối tượng check</param>
        /// <param name="recordId">Id Đối tượng check</param>
        /// <returns>ID nhân viên vừa kiểm tra trùng</returns>
        /// author: Nguyễn Văn Ngọc(30/1/2023)
        protected virtual ServiceResponse IsDuplicateCode(T record, Guid recordId)
        {
            return new ServiceResponse { Success = true };
        }

        /// <summary>
        /// Hàm validate dữ liệu 
        /// </summary>
        /// <param name="record">Đối tượng cần validate</param>
        /// <returns>ServiceResponse thành công hoặc thất bại và dữ liệu</returns>
        /// Author: Nguyễn Văn Ngọc(4/2/2023)
        private ServiceResponse ValidateRequestData(T record, Guid recordId)
        {
            var properties = typeof(T).GetProperties();
            var checkCode = IsDuplicateCode(record, recordId);
            var validateFailures = new List<string>();
            var validateCustom = ValidateCustom(record);
            var regexProperty = new Regex("");
            foreach (var property in properties)
            {
                var propertyValue = property.GetValue(record);
                var isNotNullOrEmptyAttribute = (IsNotNullOrEmptyAttribute?)Attribute.GetCustomAttribute(property, typeof(IsNotNullOrEmptyAttribute));
                var regex = (RegularExpressions?)Attribute.GetCustomAttribute(property, typeof(RegularExpressions));
                if(regex != null)
                {
                     regexProperty = new Regex(regex.Regex);
                }
                if (isNotNullOrEmptyAttribute != null && string.IsNullOrEmpty(propertyValue?.ToString().Trim()))
                {
                    validateFailures.Add(isNotNullOrEmptyAttribute.ErrorMessage);
                }
                if(regex != null && !string.IsNullOrEmpty(propertyValue?.ToString()) && !regexProperty.IsMatch(propertyValue.ToString().Trim()))
                {
                    validateFailures.Add(regex.ErrorMessage);
                }
                
            }
            if (validateFailures.Count > 0)
            {
                return new ServiceResponse
                {
                    Success = false,
                    Data = new ErrorResult(
                        ErrorCode.InvalidInput,
                        Resource.DevMsg_ValidateFailed,
                        Resource.UserMsg_ValidateFailed,
                        validateFailures
                    )
                };
            }
            else
            {
                if (checkCode.Success)
                {
                    if (validateCustom.Success)
                    {
                        return new ServiceResponse { Success = true };
                    }
                    else
                    {
                        return validateCustom;
                    }

                }
                else
                {
                    return checkCode;
                }
            }
        } 
       
        /// <summary>
        /// Custom validate cho từng đối tượng kế thừa base
        /// </summary>
        /// <param name="record">Đối tượng kế thừa base</param>
        /// <returns></returns>
        protected virtual ServiceResponse ValidateCustom(T record)
        {
            return new ServiceResponse{ Success = true};
        }
        #endregion
    }
}
