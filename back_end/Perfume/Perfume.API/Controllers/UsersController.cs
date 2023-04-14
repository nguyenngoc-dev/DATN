using Microsoft.AspNetCore.Mvc;
using Perfume.BL;
using Perfume.Common;

namespace Perfume.API.Controllers
{
    public class UsersController : BasesController<User>
    {
        #region Field
        private IUserBL _userBL;
        #endregion

        #region Constructor
        /// <summary>
        /// Hàm khởi tạo
        /// </summary>
        /// <param name="_productimageBL">Đối tượng IProductImageBL</param>
        public UsersController(IUserBL userBL) : base(userBL)
        {
            _userBL = userBL;

        }
        #endregion

    }
}
