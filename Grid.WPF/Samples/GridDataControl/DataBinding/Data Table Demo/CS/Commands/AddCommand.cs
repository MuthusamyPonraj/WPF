using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Data;
using Syncfusion.Windows.Controls.Grid;

namespace DataTableDemo
{
    #region Add Command

    public class EmployeeAddBehavior : EmployeeCommandBehaviour<EmployeeDetail>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="EmployeeAddBehavior"/> class.
        /// </summary>
        public EmployeeAddBehavior()
            : base((s, e) =>
            {
                ManipulatorViewModel viewModel = new ManipulatorViewModel(null, false);
                ManipulatorView addView = new ManipulatorView(viewModel);
                addView.Owner = Application.Current.MainWindow;

                if ((bool)addView.ShowDialog())
                {
                    return viewModel.EmployeeInfo;
                }
                return null;
            })
        { }
    }

    public class EmployeeAddCommand : EmployeeCommand<EmployeeDetail, EmployeeAddBehavior>
    { }

    #endregion
}
