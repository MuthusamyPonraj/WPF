using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;
using System.ComponentModel;
using Syncfusion.Windows.Controls.Grid;
using System.Windows.Media;
using System.Windows.Controls;
using System.Windows;
using System.Windows.Media.Imaging;
using Syncfusion.Windows.Shared;
using System.Data;
using System.Data.SqlServerCe;

namespace DataTableDemo
{
    class GridViewModel :NotificationObject
    {
        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="GridViewModel"/> class.
        /// </summary>
        public GridViewModel()
        {

            this.EmployeeDetails = this.GetEmployeeDetails();
            _addEmployee = new DelegateCommand<EmployeeDetail>(AddEmployeeHandler, CanAddEmployee);
            _editEmployee = new DelegateCommand<EmployeeDetail>(UpdateEmployeeHandler, CanUpdateEmployee);
            _deleteEmploee = new DelegateCommand<DataRowView>(DeleteEmployeeHandler);
        }
        #endregion

        #region Command Handler

        /// <summary>
        /// Determines whether this instance [can add employee] the specified employee.
        /// </summary>
        /// <param name="employee">The employee.</param>
        /// <returns>
        /// 	<c>true</c> if this instance [can add employee] the specified employee; otherwise, <c>false</c>.
        /// </returns>
        bool CanAddEmployee(EmployeeDetail employee)
        {
            return true;
        }

        /// <summary>
        /// Adds the employee handler.
        /// </summary>
        /// <param name="employee">The employee.</param>
        public void AddEmployeeHandler(EmployeeDetail employee)
        {
            if (employee == null)
            {
                return;
            }
            var row = this.EmployeeDetails.NewRow();
            row["Employee ID"] = employee.EmployeeID;
            row["Last Name"] = employee.LastName;
            row["First Name"] = employee.FirstName;
            row["Title"] = employee.Title;
            row["Birth Date"] = employee.BirthDate;
            row["Hire Date"] = employee.HireDate;
            row["City"] = employee.City;
            this.EmployeeDetails.Rows.Add(row);


        }

        /// <summary>
        /// Determines whether this instance [can update employee] the specified employee.
        /// </summary>
        /// <param name="employee">The employee.</param>
        /// <returns>
        /// 	<c>true</c> if this instance [can update employee] the specified employee; otherwise, <c>false</c>.
        /// </returns>
        bool CanUpdateEmployee(EmployeeDetail employee)
        {
            return this.SelectedEmployee != null;
        }

        /// <summary>
        /// Updates the employee handler.
        /// </summary>
        /// <param name="employee">The employee.</param>
        public void UpdateEmployeeHandler(EmployeeDetail employee)
        {
            if (employee == null)
                return;
            ((DataRowView)_SelectedEmployee)["Employee ID"] = employee.EmployeeID;
            ((DataRowView)_SelectedEmployee)["Last Name"] = employee.LastName;
            ((DataRowView)_SelectedEmployee)["First Name"] = employee.FirstName;
            ((DataRowView)_SelectedEmployee)["Title"] = employee.Title;
            ((DataRowView)_SelectedEmployee)["Birth Date"] = employee.BirthDate;
            ((DataRowView)_SelectedEmployee)["Hire Date"] = employee.HireDate;
            ((DataRowView)_SelectedEmployee)["City"] = employee.City;           
           
        }

        /// <summary>
        /// Deletes the employee handler.
        /// </summary>
        /// <param name="employee">The employee.</param>
        public void DeleteEmployeeHandler(DataRowView employee)
        {
            if (employee == null)
                return;

           this.EmployeeDetails.Rows.Remove(employee.Row);
        }

        #endregion

        private readonly DelegateCommand<EmployeeDetail> _addEmployee;
        private readonly DelegateCommand<EmployeeDetail> _editEmployee;
        private readonly DelegateCommand<DataRowView> _deleteEmploee;


        /// <summary>
        /// Gets the add employee.
        /// </summary>
        /// <value>The add employee.</value>
        public DelegateCommand<EmployeeDetail> AddEmployee
        {
            get { return _addEmployee; }
        }

        /// <summary>
        /// Gets the edit employee.
        /// </summary>
        /// <value>The edit employee.</value>
        public DelegateCommand<EmployeeDetail> EditEmployee
        {
            get { return _editEmployee; }
        }

        /// <summary>
        /// Gets the delete employee.
        /// </summary>
        /// <value>The delete employee.</value>
        public DelegateCommand<DataRowView> DeleteEmployee
        {
            get { return _deleteEmploee; }
        }   

        #region Properties

        private DataTable _employeeDetails;

        /// <summary>
        /// Gets or sets the employee details.
        /// </summary>
        /// <value>The employee details.</value>
        public DataTable EmployeeDetails
        {
            get{ return _employeeDetails; }
            set{ _employeeDetails = value;}
        }

        private DataRowView _SelectedEmployee;

        /// <summary>
        /// Gets or sets the selected customer.
        /// </summary>
        /// <value>The selected customer.</value>
        public DataRowView SelectedEmployee
        {
            get
            {
                return _SelectedEmployee;
            }
            set
            {
                _SelectedEmployee = value;
                RaisePropertyChanged("SelectedEmployee");
               
            }
        }       
        
        #endregion  
        
        #region Methods

        /// <summary>
        /// Gets the customer details.
        /// </summary>
        /// <returns></returns>
        public DataTable GetEmployeeDetails()
        {
            if (!LayoutControl.IsInDesignMode)
            {
                using (SqlCeConnection con = new SqlCeConnection(string.Format(@"Data Source = {0}", LayoutControl.FindFile("Northwind.sdf"))))
                {
                    con.Open();
                    SqlCeDataAdapter sda = new SqlCeDataAdapter("SELECT * FROM Employees", con);
                    DataTable ds = new DataTable();
                    sda.Fill(ds);
                    return ds;
                }
            }

            return new DataTable();
        }
        #endregion    
    }   
}
