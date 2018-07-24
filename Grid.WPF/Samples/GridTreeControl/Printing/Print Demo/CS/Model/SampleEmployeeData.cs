using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Media.Imaging;

namespace ExpandCellLook
{
    public class EmployeesCollection : List<Employee>
    {
        public EmployeesCollection()
        {
        }

        public void PopulateWithSampleData(int count)
        {
            images = new List<BitmapImage>();

            images.Add(new BitmapImage(new Uri("pack://application:,,/images/flag_argentina.png")));
            images.Add(new BitmapImage(new Uri("pack://application:,,/images/flag_belize.png")));
            images.Add(new BitmapImage(new Uri("pack://application:,,/images/flag_bermuda.png")));
            images.Add(new BitmapImage(new Uri("pack://application:,,/images/flag_brazil.png")));
            images.Add(new BitmapImage(new Uri("pack://application:,,/images/flag_canada.png")));
            images.Add(new BitmapImage(new Uri("pack://application:,,/images/flag_colombia.png")));
            images.Add(new BitmapImage(new Uri("pack://application:,,/images/flag_costa_rica.png")));
            images.Add(new BitmapImage(new Uri("pack://application:,,/images/flag_guatemala.png")));
            images.Add(new BitmapImage(new Uri("pack://application:,,/images/flag_mexico.png")));
            images.Add(new BitmapImage(new Uri("pack://application:,,/images/flag_panama.png")));
            images.Add(new BitmapImage(new Uri("pack://application:,,/images/flag_usa.png")));
            images.Add(new BitmapImage(new Uri("pack://application:,,/images/flag_venezuela.png")));

            PopulateWithSampleData(count, false);
            
        }

        public BitmapImage GetItemBitmap(Employee emp)
        {
            return images[emp.ImageIndex];
        }

        private List<BitmapImage> images;
        public void PopulateWithFlatData(int count)
        {
            baseCount++;

            Random r = new Random(12313);
            Employee emp;

            //just generate to randon data in some manner - not really related to the TreeGrid itself...
            for (int i = 0; i < count; ++i)
            {
                emp = new Employee();
                emp.ID = i;
                emp.FirstName = string.Format("first{0}_{1}", i, baseCount);
                emp.LastName = string.Format("last{0}", i);
                emp.Salary = 30000d + r.Next(9) * 10000;
                emp.Title = string.Format("title{0}", r.Next(5));
                emp.Department = string.Format("department{0}", r.Next(4));
                emp.Rating = r.Next(100);
                emp.ImageIndex = r.Next(images.Count);
                this.Add(emp);
            }
        }
        static int baseCount = -1;

        //just generate some sample data...
        public void PopulateWithSampleData(int count, bool multipleRootNodes)
        {
            

            Random r = new Random(12313);
            
            //just generate to randon data in some manner - not really related to the TreeGrid itself...
            PopulateWithFlatData(count);

            //now need to set up the reportsto property...
            // first create a list of all the employees
            List<int> all = new List<int>();
            for (int i = 0; i < count; ++i)
            {
                all.Add(i);
            }
         
            //choose 2 big bosses - with half the employees reporting to each...

            //first big boss
            int randonLocation = r.Next(all.Count);
            int parentID = all[randonLocation];
            Employee bigBoss = this[parentID];
            bigBoss.FirstName = "BIGBOSS1";
            bigBoss.Salary = 200000d;
            bigBoss.ReportsTo = -1; //big boss reports to no one

            //remove boss for pool
            all.Remove(parentID);
            EmployeesCollection employeesToProcess = new EmployeesCollection();
            employeesToProcess.Add(bigBoss);

            //now loop through and set direct reports to this parent
            int half = multipleRootNodes ? all.Count / 2 : 0;
            while (all.Count > half)
            {
                EmployeesCollection nextSetToProcess = new EmployeesCollection();
              //  employeesToProcess.Sort();
                foreach (Employee e in employeesToProcess)
                {
                    int numberOfReports = r.Next(6) + 1;
                    while (numberOfReports > 0 && all.Count > half)
                    {
                        randonLocation = r.Next(all.Count);
                        int childID = all[randonLocation];
                        Employee child = this[childID];
                        nextSetToProcess.Add(child);
                        child.ReportsTo = e.ID;
                        numberOfReports--;
                        all.Remove(childID);
                    }
                    if (all.Count <= half)
                        break;
                }
                employeesToProcess = nextSetToProcess;
            }

            if (multipleRootNodes)
            {
                //second big boss
                randonLocation = r.Next(all.Count);
                parentID = all[randonLocation];
                bigBoss = this[parentID];
                bigBoss.FirstName = "BIGBOSS2";
                bigBoss.Salary = 200000d;
                bigBoss.ReportsTo = -1; //big boss reports to no one

                //remove boss for pool
                all.Remove(parentID);

                employeesToProcess = new EmployeesCollection();
                employeesToProcess.Add(bigBoss);

                //now loop through and set direct reports to this parent

                while (all.Count > 0)
                {
                    EmployeesCollection nextSetToProcess = new EmployeesCollection();
                    //employeesToProcess.Sort();
                    foreach (Employee e in employeesToProcess)
                    {
                        int numberOfReports = r.Next(6) + 1;
                        while (numberOfReports > 0 && all.Count > 0)
                        {
                            randonLocation = r.Next(all.Count);
                            int childID = all[randonLocation];
                            Employee child = this[childID];
                            nextSetToProcess.Add(child);
                            child.ReportsTo = e.ID;
                            numberOfReports--;
                            all.Remove(childID);
                        }
                        if (all.Count == 0)
                            break;
                    }
                    employeesToProcess = nextSetToProcess;
                }
            }

           
            Sort();
        }

        public int FindID(int id)
        {
            int loc = -1;

            int top = 0;
            int bot = this.Count - 1;

            int mid;
            do
            {
                mid = (top + bot) / 2;
                if (this[mid].ReportsTo > id)
                {
                    bot = mid - 1;
                }
                else if (this[mid].ReportsTo < id)
                {
                    top = mid + 1;
                }
            }
            while (bot > -1 && top < this.Count && this[mid].ReportsTo != id && bot >= top);
            if (this[mid].ReportsTo == id)
            {
                while (mid > 0 && this[mid - 1].ReportsTo == id)
                    mid--;
                loc = mid;
            }
            return loc;
        }

        public IEnumerable<Employee> GetReportees(int bossID)
        {
            //////code using LINQ
            ////return this.Where(employee => employee.ReportsTo == bossID);

           ////  code without LINQ using brute force checks
           // List<Employee> list = new List<Employee>();
           // foreach (Employee e in this)
           // {
           //     if (e.ReportsTo == bossID)
           //         list.Add(e);
           // }
           // return list;

            //code using fact that collection is ordered on ReportsTo.
            List<Employee> list = new List<Employee>();
            int loc = FindID(bossID);
            if (loc > -1)
            {
                while (loc < Count && this[loc].ReportsTo == bossID)
                    list.Add(this[loc++]);
            }

            return list;
        }


       
    }

    public class Employee : IComparable<Employee>
    {

        int id;

        public int ID
        {
            get { return id; }
            set { id = value; }
        }
        string firstName;

        public string FirstName
        {
            get { return firstName; }
            set { firstName = value; }
        }
        string lastName;

        public string LastName
        {
            get { return lastName; }
            set { lastName = value; }
        }
        string department;

        public string Department
        {
            get { return department; }
            set { department = value; }
        }

        private string title;

        public string Title
        {
            get { return title; }
            set { title = value; }
        }

        double salary;

        public double Salary
        {
            get { return salary; }
            set { salary = value; }
        }
        int reportsTo;

        public int ReportsTo
        {
            get { return reportsTo; }
            set { reportsTo = value; }
        }

        int rating;

        public int Rating
        {
            get { return rating; }
            set { rating = value; }
        }

        int imageIndex;

        public int ImageIndex
        {
            get { return imageIndex; }
            set { imageIndex = value; }
        }
         

        #region IComparable<Employee> Members

        public int CompareTo(Employee other)
        {
           // return this.reportsTo - other.reportsTo;
            if (other == null)
                return -1;

            return this.ReportsTo.CompareTo(other.ReportsTo);
        }

        #endregion
    }
}
