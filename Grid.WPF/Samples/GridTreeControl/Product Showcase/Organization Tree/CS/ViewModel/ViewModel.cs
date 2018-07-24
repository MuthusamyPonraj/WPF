using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Media.Imaging;

namespace OrganizationTree
{
    /// <summary>
    /// Interaction logic for EmployeeCollection class
    /// </summary>
    public class ViewModel
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ViewModel"/> class.
        /// </summary>
        public ViewModel()
        {
            this.EmployeeInfo = this.GetEmployees();
        }

        private List<EmployeeInfo> _EmployeeInfo;
        /// <summary>
        /// Gets or sets the employee info.
        /// </summary>
        /// <value>The employee info.</value>
        public List<EmployeeInfo> EmployeeInfo
        {
            get
            {
                return _EmployeeInfo;
            }
            set
            {
                _EmployeeInfo = value;
            }
        }

        /// <summary>
        /// Gets the employees.
        /// </summary>
        /// <returns></returns>
        public List<EmployeeInfo> GetEmployees()
        {
            images = new List<BitmapImage>();
            List<EmployeeInfo> model = new List<EmployeeInfo>();
            model.Add(new EmployeeInfo() { Title = "  Management", ImageIndex = 1, ReportsTo = -1, ID = 2 });
            model.Add(new EmployeeInfo() { Title = "  Accounts", ImageIndex = 2, ReportsTo = -1, ID = 3 });
            model.Add(new EmployeeInfo() { Title = "  Sales", ImageIndex = 3, ReportsTo = -1, ID = 4 });
            model.Add(new EmployeeInfo() { Title = "  Marketing", ImageIndex = 4, ReportsTo = -1, ID = 5 });
            model.Add(new EmployeeInfo() { Title = "  HumanResource", ImageIndex = 5, ReportsTo = -1, ID = 6 });
            model.Add(new EmployeeInfo() { Title = "  Purchasing", ImageIndex = 6, ReportsTo = -1, ID = 7 });
            model.Add(new EmployeeInfo() { Title = "  Production", ImageIndex = 7, ReportsTo = -1, ID = 8 });
            //Management

            model.Add(new EmployeeInfo() { FirstName = "Andrew", LastName = "Fuller", ImageIndex = 0, Weight = 80, Height = 6, Hike = "10.00%", Department = "Management", EmpID = 1001, ID = 9, DOJ = "01-09-1937", Rating = 5, Salary = 1200000, ReportsTo = 2, Title = "Vice President" });
            model.Add(new EmployeeInfo() { FirstName = "Janet", LastName = "Leverling", ImageIndex = 1, Weight = 74, Height = 5.8, Hike = "8.00%", Department = "Management", EmpID = 1002, ID = 10, DOJ = "05-07-1939", Rating = 4, Salary = 1000000, ReportsTo = 2, Title = "GM" });
            model.Add(new EmployeeInfo() { FirstName = "Steven", LastName = "Buchanan", ImageIndex = 2, Weight = 70, Height = 5.4, Hike = "7.00%", Department = "Management", EmpID = 1003, ID = 11, DOJ = "02-05-1940", Rating = 4, Salary = 900000, ReportsTo = 2, Title = "Manager" });

            //Accounts
            model.Add(new EmployeeInfo() { FirstName = "Nancy", LastName = "Davolio", ImageIndex = 3, Weight = 60, Height = 5.5, Hike = "7.20%", Department = "Accounts", EmpID = 1004, ID = 12, DOJ = "02-05-1940", Rating = 5, Salary = 850000, ReportsTo = 3, Title = "Accounts Manager" });
            model.Add(new EmployeeInfo() { FirstName = "Margaret", LastName = "Peacock", ImageIndex = 4, Weight = 62, Height = 5.4, Hike = "6.90%", Department = "Accounts", EmpID = 1008, ID = 13, DOJ = "01-09-1945", Rating = 3, Salary = 700000, ReportsTo = 3, Title = "Accountant" });
            model.Add(new EmployeeInfo() { FirstName = "Michael", LastName = "Suyama", ImageIndex = 5, Weight = 55, Height = 5.1, Hike = "6.90%", Department = "Accounts", EmpID = 1009, ID = 14, DOJ = "02-09-1945", Rating = 5, Salary = 700000, ReportsTo = 3, Title = "Accountant" });
            model.Add(new EmployeeInfo() { FirstName = "Robert", LastName = "King", ImageIndex = 6, Weight = 63, Height = 5.8, Hike = "5.70%", Department = "Accounts", EmpID = 1010, ID = 15, DOJ = "02-09-1945", Rating = 3, Salary = 650000, ReportsTo = 3, Title = "Accountant" });

            //Sales
            model.Add(new EmployeeInfo() { FirstName = "Laura", LastName = "Callahan", ImageIndex = 7, Weight = 50, Height = 5.2, Hike = "8.20%", Department = "Sales", EmpID = 1005, ID = 16, DOJ = "07-01-1942", Rating = 5, Salary = 900000, ReportsTo = 4, Title = "Sales Manager" });
            model.Add(new EmployeeInfo() { FirstName = "Anne", LastName = "Dodsworth", ImageIndex = 8, Weight = 60, Height = 5.1, Hike = "8.00%", Department = "Sales", EmpID = 1011, ID = 17, DOJ = "02-10-1945", Rating = 4, Salary = 800000, ReportsTo = 4, Title = "Sales Representative" });
            model.Add(new EmployeeInfo() { FirstName = "Albert", LastName = "Hellstern", ImageIndex = 9, Weight = 53, Height = 5.9, Hike = "6.90%", Department = "Sales", EmpID = 1012, ID = 18, DOJ = "02-10-1945", Rating = 5, Salary = 750000, ReportsTo = 4, Title = "Sales Representative" });
            model.Add(new EmployeeInfo() { FirstName = "Tim", LastName = "Smith", ImageIndex = 10, Weight = 50, Height = 5.6, Hike = "5.23%", Department = "Sales", EmpID = 1013, ID = 19, DOJ = "03-11-1945", Rating = 5, Salary = 700000, ReportsTo = 4, Title = "Sales Representative" });
            model.Add(new EmployeeInfo() { FirstName = "Justin", LastName = "Brid", ImageIndex = 11, Weight = 65, Height = 5.8, Hike = "6.00%", Department = "Sales", EmpID = 1014, ID = 20, DOJ = "03-11-1945", Rating = 5, Salary = 700000, ReportsTo = 4, Title = "Sales Representative" });

            //Back Office
            model.Add(new EmployeeInfo() { FirstName = "Caroline", LastName = "Patterson", ImageIndex = 13, Weight = 65, Height = 5, Hike = "6.00%", Department = "BackOffice", EmpID = 1006, ID = 21, DOJ = "07-01-1942", Rating = 5, Salary = 800000, ReportsTo = 5, Title = "Receptionist" });
            model.Add(new EmployeeInfo() { FirstName = "Xavier", LastName = "Martin", ImageIndex = 13, Weight = 55, Height = 5.2, Hike = "3.00%", Department = "BackOffice", EmpID = 1015, ID = 22, DOJ = "01-09-1946", Rating = 5, Salary = 700000, ReportsTo = 5, Title = "Mail Clerk" });

            //HR
            model.Add(new EmployeeInfo() { FirstName = "Laurent", LastName = "Pereira", ImageIndex = 15, Weight = 60, Height = 5.5, Hike = "6.60%", Department = "HumanResource", EmpID = 1007, ID = 23, DOJ = "01-09-1942", Rating = 5, Salary = 900000, ReportsTo = 6, Title = "HR Manager" });
            model.Add(new EmployeeInfo() { FirstName = "Syed", LastName = "Abbas", ImageIndex = 15, Weight = 52, Height = 6, Hike = "6.20%", Department = "HumanResource", EmpID = 1016, ID = 24, DOJ = "04-02-1947", Rating = 5, Salary = 650000, ReportsTo = 6, Title = "HR Assistant" });
            model.Add(new EmployeeInfo() { FirstName = "Amy", LastName = "Alberts", ImageIndex = 16, Weight = 54, Height = 5.2, Hike = "6.00%", Department = "HumanResource", EmpID = 1017, ID = 25, DOJ = "04-02-1947", Rating = 5, Salary = 650000, ReportsTo = 6, Title = "HR Assistant" });

            //Purchasing

            model.Add(new EmployeeInfo() { FirstName = "Pamela", LastName = "Ansman-Wolfe", ImageIndex = 17, Weight = 55, Height = 5.4, Hike = "7.60%", Department = "Purchasing", EmpID = 1018, ID = 26, DOJ = "04-02-1947", Rating = 3, Salary = 600000, ReportsTo = 7, Title = "Purchase Manager" });
            model.Add(new EmployeeInfo() { FirstName = "Michael", LastName = "Blythe", ImageIndex = 17, Weight = 52, Height = 6, Hike = "6.02%", Department = "Purchasing", EmpID = 1019, ID = 27, DOJ = "04-02-1947", Rating = 2, Salary = 550000, ReportsTo = 7, Title = "Store Keeper" });
            model.Add(new EmployeeInfo() { FirstName = "David", LastName = "Campbell", ImageIndex = 19, Weight = 60, Height = 5.6, Hike = "6.00%", Department = "Purchasing", EmpID = 1020, ID = 28, DOJ = "05-08-1949", Rating = 3, Salary = 450000, ReportsTo = 7, Title = "Store Keeper" });

            //Production
            model.Add(new EmployeeInfo() { FirstName = "Jillian", LastName = "Carson", ImageIndex = 21, Weight = 60, Height = 5.2, Hike = "5.00%", Department = "Production", EmpID = 1021, ID = 29, DOJ = "05-08-1949", Rating = 3, Salary = 600000, ReportsTo = 8, Title = "Production Manager" });
            model.Add(new EmployeeInfo() { FirstName = "Shu", LastName = "Ito", ImageIndex = 21, Weight = 58, Height = 5.4, Hike = "6.20%", Department = "Production", EmpID = 1022, ID = 30, DOJ = "06-01-1952", Rating = 2, Salary = 550000, ReportsTo = 8, Title = "Production Engineer" });
            model.Add(new EmployeeInfo() { FirstName = "Stephen", LastName = "Jiang", ImageIndex = 22, Weight = 55, Height = 5.2, Hike = "6.00%", Department = "Production", EmpID = 1023, ID = 31, DOJ = "06-01-1952", Rating = 3, Salary = 450000, ReportsTo = 8, Title = "Production Engineer" });

            images.Add(new BitmapImage(new Uri("pack://application:,,/images/Fuller.png")));
            images.Add(new BitmapImage(new Uri("pack://application:,,/images/Leverling.png")));
            images.Add(new BitmapImage(new Uri("pack://application:,,/images/Buchanan.png")));
            images.Add(new BitmapImage(new Uri("pack://application:,,/images/Davolio.png")));
            images.Add(new BitmapImage(new Uri("pack://application:,,/images/Peacock.png")));
            images.Add(new BitmapImage(new Uri("pack://application:,,/images/Suyama.png")));
            images.Add(new BitmapImage(new Uri("pack://application:,,/images/King.png")));
            images.Add(new BitmapImage(new Uri("pack://application:,,/images/Callahan.png")));
            images.Add(new BitmapImage(new Uri("pack://application:,,/images/Dodsworth.png")));
            images.Add(new BitmapImage(new Uri("pack://application:,,/images/NotAvailable.bmp")));
            images.Add(new BitmapImage(new Uri("pack://application:,,/images/NotAvailable.bmp")));
            images.Add(new BitmapImage(new Uri("pack://application:,,/images/NotAvailable.bmp")));
            images.Add(new BitmapImage(new Uri("pack://application:,,/images/Caroline.png")));
            images.Add(new BitmapImage(new Uri("pack://application:,,/images/NotAvailable.bmp")));
            images.Add(new BitmapImage(new Uri("pack://application:,,/images/Pereira.png")));
            images.Add(new BitmapImage(new Uri("pack://application:,,/images/NotAvailable.bmp")));
            images.Add(new BitmapImage(new Uri("pack://application:,,/images/NotAvailable.bmp")));
            images.Add(new BitmapImage(new Uri("pack://application:,,/images/NotAvailable.bmp")));
            images.Add(new BitmapImage(new Uri("pack://application:,,/images/Blythe.png")));
            images.Add(new BitmapImage(new Uri("pack://application:,,/images/NotAvailable.bmp")));
            images.Add(new BitmapImage(new Uri("pack://application:,,/images/Carson.png")));
            images.Add(new BitmapImage(new Uri("pack://application:,,/images/NotAvailable.bmp")));
            images.Add(new BitmapImage(new Uri("pack://application:,,/images/NotAvailable.bmp")));
            return model;
        }

        private List<BitmapImage> images;
        /// <summary>
        /// Gets the item bitmap.
        /// </summary>
        /// <param name="emp">The emp.</param>
        /// <returns></returns>
        
        public BitmapImage GetItemBitmap(EmployeeInfo emp)
        {
            if (emp.ReportsTo != -1)
            {
                return images[emp.ImageIndex];
            }
            return null;
        }
    }
}
