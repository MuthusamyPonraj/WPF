using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Media.Imaging;
using System.Globalization;
using System.Windows.Data;
using Syncfusion.Windows.Shared;

namespace OrganizationTree
{
    public class EmployeeInfo : NotificationObject
    {
        int _id;
        /// <summary>
        /// Gets or sets the ID.
        /// </summary>
        /// <value>The ID.</value>
        public int ID
        {
            get
            {
                return _id;
            }
            set
            {
                _id = value;
                RaisePropertyChanged("ID");
            }
        }

        int? _empId;
        /// <summary>
        /// Gets or sets the emp ID.
        /// </summary>
        /// <value>The emp ID.</value>
        public int? EmpID
        {
            get
            {
                return _empId;
            }
            set
            {
                _empId = value;
                RaisePropertyChanged("EmpID");
            }
        }

        string _firstName;
        /// <summary>
        /// Gets or sets the first name.
        /// </summary>
        /// <value>The first name.</value>
        public string FirstName
        {
            get
            {
                return _firstName;
            }
            set
            {
                _firstName = value;
                RaisePropertyChanged("FirstName");
            }
        }

        string _lastName;
        /// <summary>
        /// Gets or sets the last name.
        /// </summary>
        /// <value>The last name.</value>
        public string LastName
        {
            get
            {
                return _lastName;
            }
            set
            {
                _lastName = value;
                RaisePropertyChanged("LastName");
            }
        }

        string _department;
        /// <summary>
        /// Gets or sets the department.
        /// </summary>
        /// <value>The department.</value>
        public string Department
        {
            get
            {
                return _department;
            }
            set
            {
                _department = value;
                RaisePropertyChanged("Department");
            }
        }

        private string _title;
        /// <summary>
        /// Gets or sets the title.
        /// </summary>
        /// <value>The title.</value>
        public string Title
        {
            get
            {
                return _title;
            }
            set
            {
                _title = value;
                RaisePropertyChanged("Title");
            }
        }

        double? _salary;
        /// <summary>
        /// Gets or sets the salary.
        /// </summary>
        /// <value>The salary.</value>
        public double? Salary
        {
            get
            {
                return _salary;
            }
            set
            {
                _salary = value;
                RaisePropertyChanged("Salary");
            }
        }

        int _reportsTo;
        /// <summary>
        /// Gets or sets the reports to.
        /// </summary>
        /// <value>The reports to.</value>
        public int ReportsTo
        {
            get
            {
                return _reportsTo;
            }
            set
            {
                _reportsTo = value;
                RaisePropertyChanged("ReportsTo");
            }
        }

        int? _rating;
        /// <summary>
        /// Gets or sets the rating.
        /// </summary>
        /// <value>The rating.</value>
        public int? Rating
        {
            get
            {
                return _rating;
            }
            set
            {
                _rating = value;
                RaisePropertyChanged("Rating");
            }
        }

        int _imageIndex;
        /// <summary>
        /// Gets or sets the index of the image.
        /// </summary>
        /// <value>The index of the image.</value>
        public int ImageIndex
        {
            get
            {
                return _imageIndex;
            }
            set
            {
                _imageIndex = value;
                RaisePropertyChanged("ImageIndex");
            }
        }

        string _doj;
        /// <summary>
        /// Gets or sets the DOJ.
        /// </summary>
        /// <value>The DOJ.</value>
        public string DOJ
        {
            get
            {
                return _doj;
            }
            set
            {
                _doj = value;
                RaisePropertyChanged("DOJ");
            }
        }

        string _hike;
        /// <summary>
        /// Gets or sets the hike.
        /// </summary>
        /// <value>The hike.</value>
        public string Hike
        {
            get
            {
                return _hike;
            }
            set
            {
                _hike = value;
                RaisePropertyChanged("Hike");
            }
        }

        double? _height;
        /// <summary>
        /// Gets or sets the height.
        /// </summary>
        /// <value>The height.</value>
        public double? Height
        {
            get
            {
                return _height;
            }
            set
            {
                _height = value;
                RaisePropertyChanged("Height");
            }
        }

        double? _weight;
        /// <summary>
        /// Gets or sets the weight.
        /// </summary>
        /// <value>The weight.</value>
        public double? Weight
        {
            get
            {
                return _weight;
            }
            set
            {
                _weight = value;
                RaisePropertyChanged("Weight");
            }
        }
    }
}
