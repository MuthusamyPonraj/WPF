using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Collections.ObjectModel;
using System.Windows.Data;
using Syncfusion.Windows.Controls.Grid;
using Syncfusion.Windows.Shared;

namespace CustomGroupingDemo
{
    class ViewModel : NotificationObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ViewModel"/> class.
        /// </summary>
        public ViewModel()
        {
            CustomerInfo = this.GetCustomerInfo();
        }

        private ObservableCollection<Customers> _customerInfo;

        /// <summary>
        /// Gets or sets the customer info.
        /// </summary>
        /// <value>The customer info.</value>
        public ObservableCollection<Customers> CustomerInfo
        {
            get
            {
                return _customerInfo;
            }
            set
            {
                _customerInfo = value;
            }
        }

        private bool _isExpanded;

        /// <summary>
        /// Gets or sets a value indicating whether this instance is expanded.
        /// </summary>
        /// <value>
        /// 	<c>true</c> if this instance is expanded; otherwise, <c>false</c>.
        /// </value>
        public bool IsExpanded
        {
            get
            { 
                return _isExpanded;
            }
            set
            {
                _isExpanded = value;
                RaisePropertyChanged("IsExpanded");
            }
        }

        /// <summary>
        /// Command to expand the Grid Groups
        /// </summary>
        private DelegateCommand<object> _expandCommand;
        public DelegateCommand<object> ExpandCommand
        {
            get
            {
                if (_expandCommand == null)
                    _expandCommand = new DelegateCommand<object>(Expand);

                return _expandCommand;
            }            
        }       

        /// <summary>
        /// Method to expand all groups
        /// </summary>
        /// <param name="param"></param>
        public void Expand(object param)
        {
            IsExpanded = true;
        }

        /// <summary>
        /// Command to Collapse the grid Groups
        /// </summary>
        private DelegateCommand<object> _collapseCommand;
        public DelegateCommand<object> CollapseCommand
        {
            get
            {
                if (_collapseCommand == null)
                    _collapseCommand = new DelegateCommand<object>(Collapse);

                return _collapseCommand;
            }
        }    
       
        /// <summary>
        /// Method to collapse all groups
        /// </summary>
        /// <param name="param"></param>
        public void Collapse(object param)
        {
            IsExpanded = false;
        }

        /// <summary>
        /// Gets the customer info.
        /// </summary>
        /// <returns></returns>
        public ObservableCollection<Customers> GetCustomerInfo()
        {
            ObservableCollection<Customers> customerInfo = new ObservableCollection<Customers>();
            Northwind northWind;
            if (!LayoutControl.IsInDesignMode)
            {
                string connectionString = string.Format(@"Data Source = {0}", LayoutControl.FindFile("Northwind.sdf"));
                northWind = new Northwind(connectionString);
                var orders = northWind.Customers.ToList();
                foreach (var o in orders)
                {
                    customerInfo.Add(o);
                }
            }
            return customerInfo;
        }
    }   
}
