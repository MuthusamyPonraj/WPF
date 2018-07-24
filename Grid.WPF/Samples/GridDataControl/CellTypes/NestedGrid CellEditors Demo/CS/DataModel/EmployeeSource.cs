using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;
using Syncfusion.Windows.Controls.Grid;
using NestedGridCellEditorsDemo.DataModel;

namespace NestedGridCellEditorsDemo
{
    class EmployeeSource : ObservableCollection<EmployeeInfo>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="EmployeeSource"/> class.
        /// </summary>
        public EmployeeSource()
        {
            if (!LayoutControl.IsInDesignMode)
            {
                Northwind northWind = new Northwind(string.Format(@"Data Source= {0}", LayoutControl.FindFile("Northwind.sdf")));

                foreach (Employees emp in northWind.Employees)
                {
                    EmployeeInfo empInfo = new EmployeeInfo();
                    empInfo.ID = emp.EmployeeID;
                    empInfo.FirstName = emp.FirstName;
                    empInfo.LastName = emp.LastName;
                    empInfo.Title = emp.Title;

                    this.Add(empInfo);
                }
            }
        }
    }
}
