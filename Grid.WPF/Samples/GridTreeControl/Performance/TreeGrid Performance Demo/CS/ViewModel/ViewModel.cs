using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;
using Syncfusion.Windows.Shared;
using System.Windows;
using Syncfusion.Windows.Controls.Grid;

namespace TreeGridInDepth
{
    public class ViewModel : NotificationObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ViewModel"/> class.
        /// </summary>

        #region Constructor

        public ViewModel()
        {
            this.EmployeeCount = "500";
            this.PopulateWithSampleData(500);
        }

        #endregion

        #region Public Properties

        static int baseCount = -1;

        private List<EmployeeInfo> _EmployeeDetails;

        /// <summary>
        /// Gets or sets the employee details.
        /// </summary>
        /// <value>The employee details.</value>
        public List<EmployeeInfo> EmployeeDetails
        {
            get { return _EmployeeDetails; }
            set { _EmployeeDetails = value; }
        }

        private string _LoadingTime;

        /// <summary>
        /// Gets or sets the loading time.
        /// </summary>
        /// <value>The loading time.</value>
        public string LoadingTime
        {
            get
            {
                return _LoadingTime;
            }
            set
            {
                _LoadingTime = value;
                RaisePropertyChanged("LoadingTime");
            }
        }

        private string _ExpandTime;

        public string ExpandTime
        {
            get
            {
                return _ExpandTime;
            }
            set
            {
                _ExpandTime = value;
                RaisePropertyChanged("ExpandTime");
            }
        }

        private string _CollapseTime;

        public string CollapseTime
        {
            get
            {
                return _CollapseTime;
            }
            set
            {
                _CollapseTime = value;
                RaisePropertyChanged("CollapseTime");
            }
        }
        private string _EmployeeCount;

        /// <summary>
        /// Gets or sets the employee count.
        /// </summary>
        /// <value>The employee count.</value>
        public string EmployeeCount
        {
            get
            {
                return _EmployeeCount;
            }
            set
            {
                _EmployeeCount = value;
                RaisePropertyChanged("EmployeeCount");
            }
        }

        private int _AccessType;

        /// <summary>
        /// Gets or sets the index of the access type combo box.
        /// </summary>
        /// <value>The index of the access type combo box.</value>
        public int AccessTypeComboBoxIndex
        {
            get
            {
                return _AccessType;
            }
            set
            {
                _AccessType = value;
                RaisePropertyChanged("AccessTypeComboBoxIndex");
            }
        }

        private bool _UseColumnsIsChecked;

        /// <summary>
        /// Gets or sets a value indicating whether [use columns is checked].
        /// </summary>
        /// <value>
        /// 	<c>true</c> if [use columns is checked]; otherwise, <c>false</c>.
        /// </value>
        public bool UseColumnsIsChecked
        {
            get
            {
                return _UseColumnsIsChecked;
            }
            set
            {
                _UseColumnsIsChecked = value;
                RaisePropertyChanged("UseColumnsIsChecked");
            }
        }

        private bool _PercentWidthComboIsEnabled;

        /// <summary>
        /// Gets or sets a value indicating whether [percent width combo is enabled].
        /// </summary>
        /// <value>
        /// 	<c>true</c> if [percent width combo is enabled]; otherwise, <c>false</c>.
        /// </value>
        public bool PercentWidthComboIsEnabled
        {
            get
            {
                return _PercentWidthComboIsEnabled;
            }
            set
            {
                _PercentWidthComboIsEnabled = value;
                RaisePropertyChanged("PercentWidthComboIsEnabled");
            }
        }

        private FontWeight _TextBlockFontWeight;

        /// <summary>
        /// Gets or sets the text block font weight.
        /// </summary>
        /// <value>The text block font weight.</value>
        public FontWeight TextBlockFontWeight
        {
            get
            {
                return _TextBlockFontWeight;
            }
            set
            {
                _TextBlockFontWeight = value;
                RaisePropertyChanged("TextBlockFontWeight");
            }
        }

        private int _PercentWidthComboSelecIndex;

        /// <summary>
        /// Gets or sets the index of the percent width combo selec.
        /// </summary>
        /// <value>The index of the percent width combo selec.</value>
        public int PercentWidthComboSelecIndex
        {
            get
            {
                return _PercentWidthComboSelecIndex;
            }
            set
            {
                _PercentWidthComboSelecIndex = value;
                TreeSizingBehavior = (GridPercentColumnSizingBehavior)value;
                RaisePropertyChanged("PercentWidthComboSelecIndex");
            }
        }

        private bool _EnableNotSelection;

        /// <summary>
        /// Gets or sets a value indicating whether [enable not selection].
        /// </summary>
        /// <value><c>true</c> if [enable not selection]; otherwise, <c>false</c>.</value>
        public bool EnableNotSelection
        {
            get
            {
                return _EnableNotSelection;
            }
            set
            {
                _EnableNotSelection = value;
                RaisePropertyChanged("EnableNotSelection");
            }
        }

        private GridPercentColumnSizingBehavior _TreeSizingBehavior;

        /// <summary>
        /// Gets or sets the tree sizing behavior.
        /// </summary>
        /// <value>The tree sizing behavior.</value>
        public GridPercentColumnSizingBehavior TreeSizingBehavior
        {
            get
            {
                return _TreeSizingBehavior;
            }
            set
            {
                _TreeSizingBehavior = value;
                RaisePropertyChanged("TreeSizingBehavior");
            }
        }

        private AccessType lookUpType = AccessType.Optimized;

        /// <summary>
        /// Gets or sets the type of the look up.
        /// </summary>
        /// <value>The type of the look up.</value>
        public AccessType LookUpType
        {
            get
            {
                return lookUpType;
            }
            set
            {
                lookUpType = value;
                RaisePropertyChanged("LookUpType");
            }
        }

        #endregion

        #region Methods

        /// <summary>
        /// Populates the with sample data.
        /// </summary>
        /// <param name="count">The count.</param>
        public void PopulateWithSampleData(int count)
        {
            PopulateWithSampleData(count, false);
        }

        /// <summary>
        /// Populates the with flat data.
        /// </summary>
        /// <param name="count">The count.</param>
        public void PopulateWithFlatData(int count)
        {
            baseCount++;
            Random r = new Random(12313);
            EmployeeInfo emp;

            //just generate to randon data in some manner - not really related to the TreeGrid itself...
            for (int i = 0; i < count; ++i)
            {
                emp = new EmployeeInfo();
                emp.ID = i;
                emp.FirstName = string.Format("first{0}_{1}", i, baseCount);
                emp.LastName = string.Format("last{0}", i);
                emp.Salary = 30000d + r.Next(9) * 10000;
                emp.Title = string.Format("title{0}", r.Next(5));
                emp.Department = string.Format("department{0}", r.Next(4));
                this.EmployeeDetails.Add(emp);
            }
        }

        /// <summary>
        /// Populates the with sample data.
        /// </summary>
        /// <param name="count">The count.</param>
        /// <param name="multipleRootNodes">if set to <c>true</c> [multiple root nodes].</param>
        public void PopulateWithSampleData(int count, bool multipleRootNodes)
        {
            this.EmployeeDetails = new List<EmployeeInfo>();
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
			if(all.Count>0)
			{
            int randonLocation = r.Next(all.Count);
            int parentID = all[randonLocation];
            EmployeeInfo bigBoss = this.EmployeeDetails[parentID];
            bigBoss.FirstName = "BIGBOSS1";
            bigBoss.Salary = 200000d;
            bigBoss.ReportsTo = -1; //big boss reports to no one

            //remove boss for pool
            all.Remove(parentID);
            ObservableCollection<EmployeeInfo> employeesToProcess = new ObservableCollection<EmployeeInfo>();
            employeesToProcess = new ObservableCollection<EmployeeInfo>();
            employeesToProcess.Add(bigBoss);

            //now loop through and set direct reports to this parent
            int half = multipleRootNodes ? all.Count / 2 : 0;
            while (all.Count > half)
            {
                ObservableCollection<EmployeeInfo> nextSetToProcess = new ObservableCollection<EmployeeInfo>();
                nextSetToProcess = new ObservableCollection<EmployeeInfo>();

                foreach (EmployeeInfo e in employeesToProcess)
                {
                    int numberOfReports = r.Next(6) + 1;
                    while (numberOfReports > 0 && all.Count > half)
                    {
                        randonLocation = r.Next(all.Count);
                        int childID = all[randonLocation];
                        EmployeeInfo child = this.EmployeeDetails[childID];
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
                bigBoss = this.EmployeeDetails[parentID];
                bigBoss.FirstName = "BIGBOSS2";
                bigBoss.Salary = 200000d;
                bigBoss.ReportsTo = -1; //big boss reports to no one

                //remove boss for pool
                all.Remove(parentID);
                employeesToProcess = new ObservableCollection<EmployeeInfo>();
                employeesToProcess.Add(bigBoss);

                //now loop through and set direct reports to this parent
                while (all.Count > 0)
                {
                    ObservableCollection<EmployeeInfo> nextSetToProcess = new ObservableCollection<EmployeeInfo>();
                    foreach (EmployeeInfo e in employeesToProcess)
                    {
                        int numberOfReports = r.Next(6) + 1;
                        while (numberOfReports > 0 && all.Count > 0)
                        {
                            randonLocation = r.Next(all.Count);
                            int childID = all[randonLocation];
                            EmployeeInfo child = this.EmployeeDetails[childID];
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

            if (LookUpType == AccessType.Optimized)
            {
                this.EmployeeDetails.Sort();
            }
        }
		}

        /// <summary>
        /// Finds the ID.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <returns></returns>
        public int FindID(int id)
        {
            int loc = -1;

            int top = 0;
            int bot = this.EmployeeDetails.Count - 1;

            int mid;
			if(this.EmployeeDetails.Count==0)
			return loc;
            do
            {
                mid = (top + bot) / 2;
                if (this.EmployeeDetails[mid].ReportsTo > id)
                {
                    bot = mid - 1;
                }
                else if (this.EmployeeDetails[mid].ReportsTo < id)
                {
                    top = mid + 1;
                }
            }
            while (bot > -1 && top < this.EmployeeDetails.Count && this.EmployeeDetails[mid].ReportsTo != id && bot >= top);
            if (this.EmployeeDetails[mid].ReportsTo == id)
            {
                while (mid > 0 && this.EmployeeDetails[mid - 1].ReportsTo == id)
                    mid--;
                loc = mid;
            }
            return loc;
        }

        /// <summary>
        /// Gets the reportees.
        /// </summary>
        /// <param name="bossID">The boss ID.</param>
        /// <returns></returns>
        public IEnumerable<EmployeeInfo> GetReportees(int bossID)
        {
            switch (LookUpType)
            {

                case AccessType.LINQ:
                    return this.EmployeeDetails.Where(employee => employee.ReportsTo == bossID);
                case AccessType.Linear:
                    {
                        List<EmployeeInfo> list = new List<EmployeeInfo>();
                        foreach (EmployeeInfo e in EmployeeDetails)
                        {
                            if (e.ReportsTo == bossID)
                                list.Add(e);
                        }
                        return list;
                    }
                case AccessType.Optimized:
                default:
                    {
                        List<EmployeeInfo> list = new List<EmployeeInfo>();
                        int loc = FindID(bossID);
                        if (loc > -1)
                        {
                            while (loc < this.EmployeeDetails.Count && this.EmployeeDetails[loc].ReportsTo == bossID)
                                list.Add(this.EmployeeDetails[loc++]);
                        }

                        return list;
                    }
            }
        }

        #endregion
    }
}
