using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BindingListDemo.Model;

namespace BindingListDemo
{
    #region Delete Command

    public class CustomerDeleteBehavior : CustomerCommandBehaviour<Customers>
    { }

    public class CustomerDeleteCommand : CustomerCommand<Customers, CustomerDeleteBehavior>
    { }

    #endregion
}
