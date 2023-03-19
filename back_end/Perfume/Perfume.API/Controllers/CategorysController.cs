using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Dapper;
using MySqlConnector;
using Perfume.Common;
using Perfume.BL;

namespace Perfume.API
{

    public class CategorysController : BasesController<Category>
    {
        #region Field
        private ICategoryBL _categoryBL;
        #endregion

        #region Constructor
        /// <summary>
        /// Hàm khởi tạo
        /// </summary>
        /// <param name="_departmentBL">Đối tượng ICategoryBL</param>
        public CategorysController(ICategoryBL categoryBL) : base(categoryBL)
        {
            _categoryBL = categoryBL;
           
        }
        #endregion

    }
}
