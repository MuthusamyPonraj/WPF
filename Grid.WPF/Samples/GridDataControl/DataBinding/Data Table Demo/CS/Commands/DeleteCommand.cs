using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace DataTableDemo
{
    #region Delete Command

    public class EmployeeDeleteBehavior : EmployeeCommandBehaviour<DataRowView>
    { }

    public class EmployeeDeleteCommand : EmployeeCommand<DataRowView, EmployeeDeleteBehavior>
    { }

    #endregion
}
