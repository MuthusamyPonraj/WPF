using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;
using System.Windows;
using System.Data;

namespace DataTableDemo
{
    #region Edit Command

    public class EmployeeEditBehavior : EmployeeCommandBehaviour<EmployeeDetail>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="EmployeeEditBehavior"/> class.
        /// </summary>
        public EmployeeEditBehavior()
            : base((s, e) =>
            {
                GridViewModel vm = (GridViewModel)(s as MenuItem).DataContext;
                ManipulatorView editView = new ManipulatorView(new ManipulatorViewModel(vm.SelectedEmployee, true));
                editView.Owner = Application.Current.MainWindow;

                if ((bool)editView.ShowDialog())
                {
                    return (editView.DataContext as ManipulatorViewModel).EmployeeInfo;
                }
                return null;
            })
        { }
    }

    public class EmployeeEditCommand : EmployeeCommand<EmployeeDetail, EmployeeEditBehavior>
    { }

    #endregion
}
