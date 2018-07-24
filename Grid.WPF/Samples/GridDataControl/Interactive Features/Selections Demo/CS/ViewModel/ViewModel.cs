using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Collections.ObjectModel;
using Syncfusion.Windows.Controls.Grid;
using System.Windows.Data;
using Syncfusion.Windows.Shared;
using SelectionsDemo.Model;

namespace SelectionsDemo
{
    class ViewModel : NotificationObject
    {
        #region Constructor

        public ViewModel()
        {
            this.GetCustomers();
            this.AllowSelectionMode = "None";
            this.ListboxSelectionMode = "None";
        }

        #endregion

        #region Grid Selection Properties

        private object _AllowSelectionMode;

        /// <summary>
        /// Gets or sets the allow selection mode.
        /// </summary>
        /// <value>The allow selection mode.</value>
        public object AllowSelectionMode
        {
            get
            {
                return _AllowSelectionMode;
            }
            set
            {
                _AllowSelectionMode = value;
                RaisePropertyChanged("AllowSelectionMode");
            }
        }


        private object _ListboxSelectionMode;

        /// <summary>
        /// Gets or sets the listbox selection mode.
        /// </summary>
        /// <value>The listbox selection mode.</value>
        public object ListboxSelectionMode
        {
            get
            {
                return _ListboxSelectionMode;
            }
            set
            {
                _ListboxSelectionMode = value;
                RaisePropertyChanged("ListboxSelectionMode");
            }
        }


        private ObservableCollection<Customers> _Customerdetails;

        /// <summary>
        /// Gets or sets the customerdetails.
        /// </summary>
        /// <value>The customerdetails.</value>
        public ObservableCollection<Customers> Customerdetails
        {
            get
            {
                return _Customerdetails;
            }
            set
            {
                _Customerdetails = value;
                RaisePropertyChanged("Customerdetails");
            }
        }

        #endregion

        #region Method to retrieve data from database
        /// <summary>
        /// Gets the customers.
        /// </summary>
        void GetCustomers()
        {
            Customerdetails = new ObservableCollection<Customers>();
            Northwind northWind;
            if (!LayoutControl.IsInDesignMode)
            {
                string connectionString = string.Format(@"Data Source = {0}", LayoutControl.FindFile("Northwind.sdf"));
                northWind = new Northwind(connectionString);
                var orders = northWind.Customers.ToList();
                foreach (var o in orders)
                {
                    this.Customerdetails.Add(o);
                }
            }
        }

        #endregion
    }
}