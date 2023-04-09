using Perfume.Common;
using Perfume.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Perfume.BL
{
    public class ProductImageBL : BaseBL<ProductImage>, IProductImageBL
    {

        #region Constructor
        public ProductImageBL(IProductImageDAL productimageDAL) : base(productimageDAL)
        {

        }
        #endregion
    }
}
