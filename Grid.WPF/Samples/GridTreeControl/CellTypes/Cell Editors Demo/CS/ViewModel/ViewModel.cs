using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CellEditorsDemo
{
    public class ViewModel
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ViewModel"/> class.
        /// </summary>
        public ViewModel()
        {
            this.GetEmployeeList();   
        }

        private List<EmployeeInfo> _EmployeeList;


        /// <summary>
        /// Gets or sets the employee list.
        /// </summary>
        /// <value>The employee list.</value>
        public List<EmployeeInfo> EmployeeList
        {
            get { return _EmployeeList; }
            set { _EmployeeList = value; }
        }

        /// <summary>
        /// Gets the employee list.
        /// </summary>
        public void GetEmployeeList()
        {
            EmployeeList = new List<EmployeeInfo>();
            this.EmployeeList.Add(new EmployeeInfo() { Title = "Management", ReportsTo = -1, ID = 2 });
            this.EmployeeList.Add(new EmployeeInfo() { Title = "Accounts", ReportsTo = -1, ID = 3 });
            this.EmployeeList.Add(new EmployeeInfo() { Title = "Sales", ReportsTo = -1, ID = 4 });
            this.EmployeeList.Add(new EmployeeInfo() { Title = "Marketing", ReportsTo = -1, ID = 5 });
            this.EmployeeList.Add(new EmployeeInfo() { Title = "HumanResource", ReportsTo = -1, ID = 6 });
            this.EmployeeList.Add(new EmployeeInfo() { Title = "Purchasing", ReportsTo = -1, ID = 7 });
            this.EmployeeList.Add(new EmployeeInfo() { Title = "Production", ReportsTo = -1, ID = 8 });
            //Management

            this.EmployeeList.Add(new EmployeeInfo() { FirstName = "Andrew", LastName = "Fuller", Weight = 79.45, Height = 5.8, Hike = 0.90, Department = "Management", EmpID = 1001, ID = 9, DOJ = DateTime.Parse("01-09-1937"), Rating = 5, Salary = 1200000, ReportsTo = 2, Title = "Vice President" });
            this.EmployeeList.Add(new EmployeeInfo() { FirstName = "Janet", LastName = "Leverling", Weight = 75.25, Height = 5.2, Hike = 0.8, Department = "Management", EmpID = 1002, ID = 10, DOJ = DateTime.Parse("05-07-1939"), Rating = 4, Salary = 1000000, ReportsTo = 2, Title = "GM" });
            this.EmployeeList.Add(new EmployeeInfo() { FirstName = "Steven", LastName = "Buchanan", Weight = 80.34, Height = 6.2, Hike = 0.7, Department = "Management", EmpID = 1003, ID = 11, DOJ = DateTime.Parse("02-05-1940"), Rating = 4, Salary = 900000, ReportsTo = 2, Title = "Manager" });

            //Accounts
            this.EmployeeList.Add(new EmployeeInfo() { FirstName = "Nancy", LastName = "Davolio", Weight = 57.23, Height = 4.9, Hike = 0.72, Department = "Accounts", EmpID = 1004, ID = 12, DOJ = DateTime.Parse("02-05-1940"), Rating = 5, Salary = 850000, ReportsTo = 3, Title = "Accounts Manager" });
            this.EmployeeList.Add(new EmployeeInfo() { FirstName = "Margaret", LastName = "Peacock", Weight = 68.27, Height = 5.4, Hike = 0.69, Department = "Accounts", EmpID = 1008, ID = 13, DOJ = DateTime.Parse("01-09-1945"), Rating = 3, Salary = 700000, ReportsTo = 3, Title = "Accountant" });
            this.EmployeeList.Add(new EmployeeInfo() { FirstName = "Michael", LastName = "Suyama", Weight = 82.88, Height = 6.2, Hike = 0.69, Department = "Accounts", EmpID = 1009, ID = 14, DOJ = DateTime.Parse("02-09-1945"), Rating = 5, Salary = 700000, ReportsTo = 3, Title = "Accountant" });
            this.EmployeeList.Add(new EmployeeInfo() { FirstName = "Robert", LastName = "King", Weight = 76.19, Height = 5.6, Hike = 0.57, Department = "Accounts", EmpID = 1010, ID = 15, DOJ = DateTime.Parse("02-09-1945"), Rating = 3, Salary = 650000, ReportsTo = 3, Title = "Accountant" });

            //Sales
            this.EmployeeList.Add(new EmployeeInfo() { FirstName = "Laura", LastName = "Callahan", Weight = 68.23, Height = 5.3, Hike = 0.82, Department = "Sales", EmpID = 1005, ID = 16, DOJ = DateTime.Parse("07-01-1942"), Rating = 5, Salary = 900000, ReportsTo = 4, Title = "Sales Manager" });
            this.EmployeeList.Add(new EmployeeInfo() { FirstName = "Anne", LastName = "Dodsworth", Weight = 75.00, Height = 5.9, Hike = 0.8, Department = "Sales", EmpID = 1011, ID = 17, DOJ = DateTime.Parse("02-10-1945"), Rating = 4, Salary = 800000, ReportsTo = 4, Title = "Sales Representative" });
            this.EmployeeList.Add(new EmployeeInfo() { FirstName = "Albert", LastName = "Hellstern", Weight = 87.70, Height = 6.4, Hike = 0.69, Department = "Sales", EmpID = 1012, ID = 18, DOJ = DateTime.Parse("02-10-1945"), Rating = 5, Salary = 750000, ReportsTo = 4, Title = "Sales Representative" });
            this.EmployeeList.Add(new EmployeeInfo() { FirstName = "Tim", LastName = "Smith", Weight = 72.35, Height = 5.1, Hike = 0.52, Department = "Sales", EmpID = 1013, ID = 19, DOJ = DateTime.Parse("03-11-1945"), Rating = 5, Salary = 700000, ReportsTo = 4, Title = "Sales Representative" });
            this.EmployeeList.Add(new EmployeeInfo() { FirstName = "Justin", LastName = "Brid", Weight = 77.23, Height = 5.5, Hike = 0.6, Department = "Sales", EmpID = 1014, ID = 20, DOJ = DateTime.Parse("03-11-1945"), Rating = 5, Salary = 700000, ReportsTo = 4, Title = "Sales Representative" });

            //Back Office
            this.EmployeeList.Add(new EmployeeInfo() { FirstName = "Caroline", LastName = "Patterson", Weight = 53.23, Height = 5.1, Hike = 0.6, Department = "BackOffice", EmpID = 1006, ID = 21, DOJ = DateTime.Parse("07-01-1942"), Rating = 5, Salary = 800000, ReportsTo = 5, Title = "Receptionist" });
            this.EmployeeList.Add(new EmployeeInfo() { FirstName = "Xavier", LastName = "Martin", Weight = 82.33, Height = 6.1, Hike = 0.3, Department = "BackOffice", EmpID = 1015, ID = 22, DOJ = DateTime.Parse("01-09-1946"), Rating = 5, Salary = 700000, ReportsTo = 5, Title = "Mail Clerk" });

            //HR
            this.EmployeeList.Add(new EmployeeInfo() { FirstName = "Laurent", LastName = "Pereira", Weight = 73.00, Height = 5.4, Hike = 0.66, Department = "HumanResource", EmpID = 1007, ID = 23, DOJ = DateTime.Parse("01-09-1942"), Rating = 5, Salary = 900000, ReportsTo = 6, Title = "HR Manager" });
            this.EmployeeList.Add(new EmployeeInfo() { FirstName = "Syed", LastName = "Abbas", Weight = 67.23, Height = 5.2, Hike = 0.62, Department = "HumanResource", EmpID = 1016, ID = 24, DOJ = DateTime.Parse("04-02-1947"), Rating = 5, Salary = 650000, ReportsTo = 6, Title = "HR Assistant" });
            this.EmployeeList.Add(new EmployeeInfo() { FirstName = "Amy", LastName = "Alberts", Weight = 70.00, Height = 6.2, Hike = 0.60, Department = "HumanResource", EmpID = 1017, ID = 25, DOJ = DateTime.Parse("04-02-1947"), Rating = 5, Salary = 650000, ReportsTo = 6, Title = "HR Assistant" });


            //Purchasing

            this.EmployeeList.Add(new EmployeeInfo() { FirstName = "Pamela", LastName = "Ansman-Wolfe", Weight = 68.00, Height = 5.4, Hike = 0.76, Department = "Purchasing", EmpID = 1018, ID = 26, DOJ = DateTime.Parse("04-02-1947"), Rating = 3, Salary = 600000, ReportsTo = 7, Title = "Purchase Manager" });
            this.EmployeeList.Add(new EmployeeInfo() { FirstName = "Michael", LastName = "Blythe", Weight = 70.23, Height = 5.8, Hike = 0.62, Department = "Purchasing", EmpID = 1019, ID = 27, DOJ = DateTime.Parse("04-02-1947"), Rating = 2, Salary = 550000, ReportsTo = 7, Title = "Store Keeper" });
            this.EmployeeList.Add(new EmployeeInfo() { FirstName = "David", LastName = "Campbell", Weight = 70.00, Height = 6.2, Hike = 0.60, Department = "Purchasing", EmpID = 1020, ID = 28, DOJ = DateTime.Parse("05-08-1949"), Rating = 3, Salary = 450000, ReportsTo = 7, Title = "Store Keeper" });


            //Production
            this.EmployeeList.Add(new EmployeeInfo() { FirstName = "Jillian", LastName = "Carson", Weight = 68.00, Height = 5.4, Hike = 0.50, Department = "Production", EmpID = 1021, ID = 29, DOJ = DateTime.Parse("05-08-1949"), Rating = 3, Salary = 600000, ReportsTo = 8, Title = "Production Manager" });
            this.EmployeeList.Add(new EmployeeInfo() { FirstName = "Shu", LastName = "Ito", Weight = 70.23, Height = 5.8, Hike = 0.62, Department = "Production", EmpID = 1022, ID = 30, DOJ = DateTime.Parse("06-01-1952"), Rating = 2, Salary = 550000, ReportsTo = 8, Title = "Production Engineer" });
            this.EmployeeList.Add(new EmployeeInfo() { FirstName = "Stephen", LastName = "Jiang", Weight = 70.00, Height = 3.2, Hike = 0.60, Department = "Production", EmpID = 1023, ID = 31, DOJ = DateTime.Parse("06-01-1952"), Rating = 3, Salary = 450000, ReportsTo = 8, Title = "Production Engineer" });
        }
    }
}
