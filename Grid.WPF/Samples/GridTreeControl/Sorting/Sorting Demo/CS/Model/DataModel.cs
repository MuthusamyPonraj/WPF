#region Copyright Syncfusion Inc. 2001 - 2012
// Copyright Syncfusion Inc. 2001 - 2012. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Media.Imaging;
using Syncfusion.Windows.Shared;
using System.ComponentModel;

namespace GridTreeSorting
{
    /// <summary>
    /// Code for Employee Class
    /// </summary>
    public class EmployeeInfo : INotifyPropertyChanged
    {
        int id;

        /// <summary>
        /// Gets or sets the ID.
        /// </summary>
        /// <value>The ID.</value>
        public int ID
        {
            get
            {
                return id;
            }
            set
            {
                id = value;
                RaisePropertyChanged("ID");
            }
        }

        int empId;

        /// <summary>
        /// Gets or sets the emp ID.
        /// </summary>
        /// <value>The emp ID.</value>
        public int EmpID
        {
            get
            {
                return empId;
            }
            set
            {
                empId = value;
                RaisePropertyChanged("EmpID");
            }
        }

        string firstName;

        /// <summary>
        /// Gets or sets the first name.
        /// </summary>
        /// <value>The first name.</value>
        public string FirstName
        {
            get
            {
                return firstName;
            }
            set
            {
                firstName = value;
                RaisePropertyChanged("FirstName");
            }
        }

        string lastName;

        /// <summary>
        /// Gets or sets the last name.
        /// </summary>
        /// <value>The last name.</value>
        public string LastName
        {
            get
            {
                return lastName;
            }
            set
            {
                lastName = value;
                RaisePropertyChanged("LastName");
            }
        }

        string department;

        /// <summary>
        /// Gets or sets the department.
        /// </summary>
        /// <value>The department.</value>
        public string Department
        {
            get
            {
                return department;
            }
            set
            {
                department = value;
                RaisePropertyChanged("Department");
            }
        }

        private string title;

        /// <summary>
        /// Gets or sets the title.
        /// </summary>
        /// <value>The title.</value>
        public string Title
        {
            get
            {
                return title;
            }
            set
            {
                title = value;
                RaisePropertyChanged("Title");
            }
        }

        double salary;

        /// <summary>
        /// Gets or sets the salary.
        /// </summary>
        /// <value>The salary.</value>
        public double Salary
        {
            get
            {
                return salary;
            }
            set
            {
                salary = value;
                RaisePropertyChanged("Salary");
            }
        }

        int reportsTo;

        /// <summary>
        /// Gets or sets the reports to.
        /// </summary>
        /// <value>The reports to.</value>
        public int ReportsTo
        {
            get
            {
                return reportsTo;
            }
            set
            {
                reportsTo = value;
                RaisePropertyChanged("ReportsTo");
            }
        }

        int rating;

        /// <summary>
        /// Gets or sets the rating.
        /// </summary>
        /// <value>The rating.</value>
        public int Rating
        {
            get
            {
                return rating;
            }
            set
            {
                rating = value;
                RaisePropertyChanged("Rating");
            }
        }

        DateTime doj;

        /// <summary>
        /// Gets or sets the DOJ.
        /// </summary>
        /// <value>The DOJ.</value>
        public DateTime DOJ
        {
            get
            {
                return doj;
            }
            set
            {
                doj = value;
                RaisePropertyChanged("DOJ");
            }
        }

        double hike;

        /// <summary>
        /// Gets or sets the hike.
        /// </summary>
        /// <value>The hike.</value>
        public double Hike
        {
            get
            {
                return hike;
            }
            set
            {
                hike = value;
                RaisePropertyChanged("Hike");
            }
        }

        double height;

        /// <summary>
        /// Gets or sets the height.
        /// </summary>
        /// <value>The height.</value>
        public double Height
        {
            get
            {
                return height;
            }
            set
            {
                height = value;
                RaisePropertyChanged("Height");
            }
        }

        double weight;

        /// <summary>
        /// Gets or sets the weight.
        /// </summary>
        /// <value>The weight.</value>
        public double Weight
        {
            get
            {
                return weight;
            }
            set
            {
                weight = value;
                RaisePropertyChanged("Weight");
            }
        }

        void RaisePropertyChanged(string propname)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propname));
        }
        public event PropertyChangedEventHandler PropertyChanged;
    }
}
