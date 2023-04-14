using Perfume.Common;
using Perfume.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Perfume.BL
{
    public class UserBL : BaseBL<User>, IUserBL
    {

        #region Constructor
        public UserBL(IUserDAL userDAL) : base(userDAL)
        {

        }
        #endregion
    }
}
