
using Perfume.Common;
using Perfume.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Perfume.BL
{
    public class CategoryBL : BaseBL<Category>,ICategoryBL
    {

        #region Constructor
        public CategoryBL(ICategoryDAL categoryDAL) : base(categoryDAL)
        {
           
        }
        #endregion
    }
}
