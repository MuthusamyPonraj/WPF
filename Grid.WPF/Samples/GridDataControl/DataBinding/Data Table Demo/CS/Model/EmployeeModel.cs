using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Syncfusion.Windows.Shared;

namespace DataTableDemo
{
    public class EmployeeDetail:NotificationObject
    {

        private int _EmployeeID;

        /// <summary>
        /// Gets or sets the employee ID.
        /// </summary>
        /// <value>The employee ID.</value>
        public int EmployeeID
        {
            get
            {
                return _EmployeeID;
            }
            set
            {
                _EmployeeID = value;
                RaisePropertyChanged("EmployeeID");
            }
        }

        private string _LastName;

        /// <summary>
        /// Gets or sets the last name.
        /// </summary>
        /// <value>The last name.</value>
        public string LastName
        {
            get
            {
                return _LastName;
            }
            set
            {
                _LastName = value;
                RaisePropertyChanged("LastName");
            }
        }


        private string _Title;

        /// <summary>
        /// Gets or sets the title.
        /// </summary>
        /// <value>The title.</value>
        public string Title
        {
            get
            { return _Title; }
            set
            {
                _Title = value;
                RaisePropertyChanged("Title");
            }
        }

        private DateTime _BirthDate;

        /// <summary>
        /// Gets or sets the birth date.
        /// </summary>
        /// <value>The birth date.</value>
        public DateTime BirthDate
        {
            get
            { return _BirthDate; }
            set
            {
                _BirthDate = value;
                RaisePropertyChanged("BirthDate");
            }
        }

        private DateTime _HireDate;

        /// <summary>
        /// Gets or sets the hire date.
        /// </summary>
        /// <value>The hire date.</value>
        public DateTime HireDate
        {
            get
            { return _HireDate; }
            set
            {
                _HireDate = value;
                RaisePropertyChanged("HireDate");
            }
        }

        private string _FirstName;

        /// <summary>
        /// Gets or sets the first name.
        /// </summary>
        /// <value>The first name.</value>
        public string FirstName
        {
            get
            { return _FirstName; }
            set
            {
                _FirstName = value;
                RaisePropertyChanged("FirstName");
            }
        }

        private string _City;

        /// <summary>
        /// Gets or sets the city.
        /// </summary>
        /// <value>The city.</value>
        public string City
        {
            get
            { return _City; }
            set
            {
                _City = value;
                RaisePropertyChanged("City");
            }
        }
    }
}
