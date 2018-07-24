using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace ListDemo
{
    #region Delete Command

    public class ProductDeleteBehavior : ProductCommandBehaviour<ProductDetails>
    { }

    public class ProductDeleteCommand : ProductCommand<ProductDetails, ProductDeleteBehavior>
    { }

    #endregion
}
