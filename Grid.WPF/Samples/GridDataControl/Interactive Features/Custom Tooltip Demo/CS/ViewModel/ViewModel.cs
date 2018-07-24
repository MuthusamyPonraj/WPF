using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;
using System.Data.Linq;
using System.Windows.Data;
using Syncfusion.Windows.Controls.Grid;
using System.Windows.Media.Imaging;
using System.IO;
using System.Windows.Controls;

namespace ToolTipsDemo
{
    class ViewModel
    {
        Northwind northWind;

        /// <summary>
        /// Initializes a new instance of the <see cref="ViewModel"/> class.
        /// </summary>
        public ViewModel()
        {
            EmployeeDetails = this.GetEmployeeDetails();
        }
        
        private ObservableCollection<Employees> _employeeDetails;

        /// <summary>
        /// Gets or sets the employee info.
        /// </summary>
        /// <value>The employee info.</value>
        public ObservableCollection<Employees> EmployeeDetails
        {
            get
            {                
                return _employeeDetails;
            }
            set
            {
                _employeeDetails = value;
            }
        }

        /// <summary>
        /// Gets the employee info.
        /// </summary>
        /// <returns></returns>
        private ObservableCollection<Employees> GetEmployeeDetails()
        {
            var employeeDetails = new ObservableCollection<Employees>();

            if (!LayoutControl.IsInDesignMode)
            {
                string connectionString = string.Format(@"Data Source = {0}", LayoutControl.FindFile("Northwind.sdf"));
                northWind = new Northwind(connectionString);
                var emp = northWind.Employees.Take(10).ToList();
                foreach (var o in emp)
                {
                    employeeDetails.Add(o);
                }
            }
            return employeeDetails;
        }
    }
}
