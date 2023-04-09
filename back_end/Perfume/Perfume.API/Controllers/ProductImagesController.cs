using Microsoft.AspNetCore.Mvc;
using Perfume.BL;
using Perfume.Common;

namespace Perfume.API
{

    public class ProductImagesController :  BasesController<ProductImage>
    {
        #region Field
        private IProductImageBL _productimageBL;
        #endregion

        #region Constructor
        /// <summary>
        /// Hàm khởi tạo
        /// </summary>
        /// <param name="_productimageBL">Đối tượng IProductImageBL</param>
        public ProductImagesController(IProductImageBL productimageBL) : base(productimageBL)
    {
            _productimageBL = productimageBL;

    }
    #endregion

}
}
