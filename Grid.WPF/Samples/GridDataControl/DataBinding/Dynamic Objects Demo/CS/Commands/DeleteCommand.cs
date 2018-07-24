using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DynamicObjectsDemo
{
    #region Delete Command

    public class OrderDeleteBehavior : OrderCommandBehaviour<OrderInfo>
    { }

    public class OrderDeleteCommand : OrderCommand<OrderInfo, OrderDeleteBehavior>
    { }

    #endregion
}
