 using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using Syncfusion.Windows.Shared;
using System.Windows.Input;
using Syncfusion.Windows.Controls.Grid;
using System.Data;

namespace DataTableDemo
{
    public class ManipulatorViewModel : NotificationObject, IDataErrorInfo
    {
        #region IDataErrorInfo Members

        private readonly IDictionary<string, string> errorInfo = new Dictionary<string, string>();

        public string Error
        {
            get { throw new NotImplementedException(); }
        }

        /// <summary>
        /// Gets or sets the <see cref="System.String"/> with the specified column name.
        /// </summary>
        /// <value></value>
        public string this[string columnName]
        {
            get
            {
                if (this.errorInfo.ContainsKey(columnName))
                {
                    return this.errorInfo[columnName];
                }
                return null;
            }
            set
            {
                this.errorInfo[columnName] = value;
            }
        }

        /// <summary>
        /// Validates this instance.
        /// </summary>
        private void Validate()
        {
            if ((this.EmployeeID==null))
            {
                this["EmployeeID"] = this.GetErrorInfo("EmployeeID");
            }
            else
            {
                this.RemoveError("EmployeeID");
            }

            if ((this.BirthDate==null))
            {
                this["BirthDate"] = this.GetErrorInfo("BirthDate");
            }
            else
            {
                this.RemoveError("BirthDate");
            }                                

            if (string.IsNullOrEmpty(this.City))
            {
                this["City"] = this.GetErrorInfo("City");
            }
            else
            {
                this.RemoveError("City");
            }

            if (string.IsNullOrEmpty(this.FirstName))
            {
                this["FirstName"] = this.GetErrorInfo("FirstName");
            }
            else
            {
                this.RemoveError("FirstName");
            }

            if (string.IsNullOrEmpty(this.LastName))
            {
                this["LastName"] = this.GetErrorInfo("LastName");
            }
            else
            {
                this.RemoveError("LastName");
            }           
        }

        /// <summary>
        /// Removes the error.
        /// </summary>
        /// <param name="columnName">Name of the column.</param>
        private void RemoveError(string columnName)
        {
            if (this.errorInfo.ContainsKey(columnName))
            {
                this.errorInfo.Remove(columnName);
            }
        }

        /// <summary>
        /// Gets the error info.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        private string GetErrorInfo(string value)
        {
            return value + " can not be null.";
        }

        #endregion

        #region Properties

        EmployeeDetail _employeeInfo = new EmployeeDetail();


        /// <summary>
        /// Gets or sets the employee info.
        /// </summary>
        /// <value>The employee info.</value>
        public EmployeeDetail EmployeeInfo
        {
            get{ return _employeeInfo; }
            set{ _employeeInfo = value;}
        }        

        /// <summary>
        /// Gets or sets the employee ID.
        /// </summary>
        /// <value>The employee ID.</value>
        public int EmployeeID
        {
            get
            {
                return EmployeeInfo.EmployeeID;
            }
            set
            {
                EmployeeInfo.EmployeeID = value;
                RaisePropertyChanged("EmployeeID");
            }
        }

        /// <summary>
        /// Gets or sets the last name.
        /// </summary>
        /// <value>The last name.</value>
        public string LastName
        {
            get
            {
                return EmployeeInfo.LastName;
            }
            set
            {
                EmployeeInfo.LastName = value;
                RaisePropertyChanged("LastName");
            }
        }

        /// <summary>
        /// Gets or sets the title.
        /// </summary>
        /// <value>The title.</value>
        public string Title
        {
            get
            { return EmployeeInfo.Title; }
            set
            {
                EmployeeInfo.Title = value;
                RaisePropertyChanged("Title");
            }
        }

        /// <summary>
        /// Gets or sets the birth date.
        /// </summary>
        /// <value>The birth date.</value>
        public DateTime BirthDate
        {
            get
            { return EmployeeInfo.BirthDate; }
            set
            {
                EmployeeInfo.BirthDate = value;
                RaisePropertyChanged("BirthDate");
            }
        }

        /// <summary>
        /// Gets or sets the hire date.
        /// </summary>
        /// <value>The hire date.</value>
        public DateTime HireDate
        {
            get
            { return EmployeeInfo.HireDate; }
            set
            {
                EmployeeInfo.HireDate = value;
                RaisePropertyChanged("HireDate");
            }
        }

        /// <summary>
        /// Gets or sets the first name.
        /// </summary>
        /// <value>The first name.</value>
        public string FirstName
        {
            get
            { return EmployeeInfo.FirstName; }
            set
            {
                EmployeeInfo.FirstName = value;
                RaisePropertyChanged("FirstName");
            }
        }

        /// <summary>
        /// Gets or sets the city.
        /// </summary>
        /// <value>The city.</value>
        public string City
        {
            get
            { return EmployeeInfo.City; }
            set
            {
                EmployeeInfo.City = value;
                RaisePropertyChanged("City");
            }
        }

        /// <summary>
        /// Gets or sets the content of the save button.
        /// </summary>
        /// <value>The content of the save button.</value>
        public string SaveButtonContent
        {
            get;
            set;
        }

        #endregion

        #region Constructor & Methods

        private bool _isInEdit;

        /// <summary>
        /// Initializes a new instance of the <see cref="ManipulatorViewModel"/> class.
        /// </summary>
        /// <param name="employee">The customers.</param>
        /// <param name="isInEdit">if set to <c>true</c> [is in edit].</param>
        public ManipulatorViewModel(DataRowView employee, bool isInEdit)
        {
             
            _isInEdit = isInEdit;
            SaveCommand = new DelegateCommand<EmployeeDetail>(this.Save, this.CanSave);
            SaveButtonContent = isInEdit ? "Save" : "Add";
            if(isInEdit)
            CloneCustomers(employee);
           
            if (_isInEdit)
                Validate();

            this.PropertyChanged += OnPropertyChanged;
        }

        /// <summary>
        /// Clones the customers.
        /// </summary>
        /// <param name="employee">The employee.</param>
        private void CloneCustomers(DataRowView employee)
        {
            EmployeeID = Int32.Parse( employee["Employee ID"].ToString());
            LastName = employee["Last Name"].ToString();
            FirstName= employee["First Name"].ToString();
            Title = employee["Title"].ToString();
            BirthDate= DateTime.Parse( employee["Birth Date"].ToString());
            HireDate = DateTime.Parse( employee["Hire Date"].ToString());
            City = employee["City"].ToString();           
        }

        /// <summary>
        /// Called when [property changed].
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="System.ComponentModel.PropertyChangedEventArgs"/> instance containing the event data.</param>
        void OnPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (this._isInEdit)
                this.Validate();

            this.SaveCommand.CanExecute(null);
        }

        #endregion

        #region Save Command

        /// <summary>
        /// Gets or sets the save command.
        /// </summary>
        /// <value>The save command.</value>
        public DelegateCommand<EmployeeDetail> SaveCommand
        {
            get;
            set;
        }

        /// <summary>
        /// Determines whether this instance can save the specified arg.
        /// </summary>
        /// <param name="arg">The arg.</param>
        /// <returns>
        /// 	<c>true</c> if this instance can save the specified arg; otherwise, <c>false</c>.
        /// </returns>
        private bool CanSave(object arg)
        {
            if (_isInEdit)
            {
                return this.errorInfo.Count == 0;
            }
            else
            {
                this.Validate();
                bool result = this.errorInfo.Count == 0;
                this.errorInfo.Clear();
                return result;
            }
        }

        /// <summary>
        /// Saves the specified obj.
        /// </summary>
        /// <param name="obj">The obj.</param>
        private void Save(object obj)
        {
            
        }
        #endregion
    }
}
