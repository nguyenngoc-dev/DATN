const RESOURCES = {
  NOTIFICATION_TYPE: {
    SUCCESS: "SUCCESS",
    ERROR: "ERROR",
    INFO: "INFO",
    WARNING: "WARNING",
  },
  NOTIFICATION_TITLE: {
    SUCCESS: "Thành công",
    ERROR: "Lỗi! ",
    INFO: "Thông tin",
    WARNING: "Cảnh báo",
  },
  FORM_MESSAGE: {
    SUCCESS: {
      ADD: "Thêm vào giỏ thành công!",
      EDIT: "Sửa thành công!",
      DELETE: "Xóa khỏi giỏ thành công",
      AUTHEN:"Đăng nhập thành công",
      SREGIS:"Đăng kí tài khoản thành công"
    },
    ERROR: {
      ERRORSERVER:"Vui lòng liên hệ Store để được trợ giúp",
      INVALID_CODE:"Mã nhân viên không được để trống",
      DUPLICATE_CODE:"Mã hiện tại đang bị trùng",
      INVALID_NAME:"Tên nhân viên không được để trống",
      ERROR_DATE:"Ngày tháng không hợp lệ",
      ERROR_DEPARTMENT:"Đơn vị không hợp lệ",
      ERROR_EMAIL:"Email không đúng định dạng",
      ERROR_PHONENUMBER:"Số điện thoại không đúng định dạng",
      ERROR_BANK_ACCOUNT:"Số tài khoản không đúng định dạng",
      AUTHEN:"Tài khoản hoặc mật khẩu không chính xác",
      DUP_AUTHEN:"Tài khoản và mật khẩu đã tồn tại",
      MATCH:"Mật khẩu không khớp",
      EMPTY:"Bạn cần nhập đủ trường"
    }
  },
  DepartmentId:'DepartmentId',
  FORM_MODE: {
    ADD: "ADD",
    EDIT: "EDIT",
    DUPLICATE: "DUPLICATE",
    DELETE: "DELETE",
    ERROR:"ERROR",
    SUCCESS:"SUCCESS",
    AUTHEN:"AUTHEN",
    MATCH:"MATCH",
    SREGIS:"SREGIS",
    EMPTY:"EMPTY"
  },
  FORM_TITLE: {
    PRODUCT:{
      ADD:"Thêm sản phẩm",
      UPDATE:"Sửa sản phẩm",
      DUPLICATE:"Nhân bản"
    },
    CATEGORY: {
      ADD:"Thêm danh mục",
      UPDATE:"Sửa danh mục",
      DUPLICATE:"Nhân bản"
    }
   
  },
  MODAL_TITLE: {
    INFO: "Xác nhận",
    WARNING: "Xác nhận xóa",
    ERROR: "Dữ liệu không đúng",
  },
  MODAL_TYPE: {
    INFO: "INFO",
    WARNING: "WARNING",
    ERROR: "ERROR",
  },
  MODAL_MESSAGE: {
    INFO: "Dữ liệu đã bị thay đổi. Bạn có muốn cất không?",
    WARNING:`Bạn có chắc chắn muốn xóa không?`,
    DELETE_WARNING:(code)=>`Bạn có thực sự muốn xóa mã <${code}> không?`,
    EMPTY_EMPLOYEE:"Không có nhân viên nào được chọn"

  },
  PAGINATION: [
    {
      value: 20,
      text: "20 bản ghi trên 1 trang",
    },
    {
      value: 50,
      text: "50 bản ghi trên 1 trang",
    },
    {
      value: 100,
      text: "100 bản ghi trên 1 trang",
    },
    {
      value: 120,
      text: "120 bản ghi trên 1 trang",
    },
  ],

  STATUSCODE: {
    OK: 200,
    Created: 201,
    BadRequest: 400,
    NotFound: 404,
    ServerError: 500,
  },
  FORM_RULES: {
    NOT_EMPTY: "NOT_EMPTY",
    HAS_FORMAT: "HAS_FORMAT",
    UNIQUE: "UNIQUE",
    ADULT: "ADULT",
    MAX_LENGTH:"MAX_LENGTH"
  },
  ERROR: {
    NOT_EMPTY: (name) => `${name} không được để trống`,
    ADULT: (name) =>{
      let message = "";
      if(name == "Ngày sinh") 
        message = "Nhân viên chưa đủ 18 tuổi";
      else
        message = `${name} không hợp lệ`;
      return message;
    },
    HAS_FORMAT: (name) => `${name} chưa đúng định dạng`,
    MAX_LENGTH:(name,value) => `${name} giới hạn ${value} kí tự`
  },
  FORM_FIELD: {
    EmployeeCode: "Mã",
    FullName: "Tên",
    DepartmentId:"Danh mục",
    Position:"Chức danh",
    DateOfBirth:"Ngày sinh",
    IdentityNumber:"Số căn cước",
    IdentityDate:"Ngày cấp",
    IdentityPlace:"Nơi cấp",
    Address:"Địa chỉ",
    PhoneNumber: "Điện thoại di động",
    LandlineNumber:"Điện thoại cố định",
    Email: "Email",
    BankAccount:"Tài khoản ngân hàng",
    BankName:"Tên ngân hàng",
    BankBranch:"Chi nhánh"
  },
  STATUSCODES: {
    Unauthorized: {
      Code: 401,
      Message: "Không được xác thực"
    },
    Not_Found: {
      Code: 404,
      Message: "Không tìm thấy tài nguyên"
    },
    Gateway_Timeout: {
      Code: 504,
      Message:"Không nhận được phản hồi từ máy chủ"
    }
  }
};

export default RESOURCES;
