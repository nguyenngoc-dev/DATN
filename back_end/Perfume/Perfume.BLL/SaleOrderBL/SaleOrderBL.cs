using Perfume.Common;
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

        #region Constructor
        public SaleOrderBL(ISaleOrderDAL saleorderDAL) : base(saleorderDAL)
        {

        }
        #endregion
    }
}
