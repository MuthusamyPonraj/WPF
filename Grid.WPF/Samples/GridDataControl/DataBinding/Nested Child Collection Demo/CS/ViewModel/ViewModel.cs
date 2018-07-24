#region Copyright Syncfusion Inc. 2001 - 2011
// Copyright Syncfusion Inc. 2001 - 2011. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Collections.ObjectModel;
using Syncfusion.Windows.Controls.Grid;
using NestedChildCollectionDemo.Model;

namespace NestedChildCollectionDemo
{
    class ViewModel
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ViewModel"/> class.
        /// </summary>
        public ViewModel()
        {
            this.GetEmployees();
        }

        private ObservableCollection<Employees> _EmployeeDetails;
        /// <summary>
        /// Gets or sets the employee details.
        /// </summary>
        /// <value>The employee details.</value>
        public ObservableCollection<Employees> EmployeeDetails
        {
            get
            {
                return _EmployeeDetails;
            }
            set
            {
                _EmployeeDetails = value;
            }
        }

        /// <summary>
        /// Gets the employees.
        /// </summary>
        public void GetEmployees()
        {
            Northwind northWind;
            EmployeeDetails = new ObservableCollection<Employees>();
            if (!LayoutControl.IsInDesignMode)
            {
                string connectionString = string.Format(@"Data Source = {0}", LayoutControl.FindFile("Northwind.sdf"));
                northWind = new Northwind(connectionString);
                var order = northWind.Employees.Skip(0).Take(100).Select(o => o);
                foreach (var o in order)
                {
                    this.EmployeeDetails.Add(o);
                }
            }
        }

    }
}
