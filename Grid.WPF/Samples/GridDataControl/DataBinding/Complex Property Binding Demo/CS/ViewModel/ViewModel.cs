#region Copyright Syncfusion Inc. 2001 - 2011
// Copyright Syncfusion Inc. 2001 - 2011. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using Syncfusion.Windows.Controls.Grid;
using Syncfusion.Windows.Shared;

namespace ComplexPropertyBindingDemo
{
    class ViewModel : NotificationObject
    {
        #region Constructor  
        Northwind northWind;

        /// <summary>
        /// Initializes a new instance of the <see cref="ViewModel"/> class.
        /// </summary>
        public ViewModel()
        {
            OrdersDetails = this.GetOrdersDetails();
            visibleColumn = new List<string>();
            visibleColumn.Add("OrderID");
            visibleColumn.Add("CustomerID");
            visibleColumn.Add("Customers.CompanyName");
            visibleColumn.Add("Customers.Address");
            visibleColumn.Add("Customers.City");
            visibleColumn.Add("Customers.Country");
        }
        #endregion

        # region Commands

        private DelegateCommand<object> _ShowHideColumnCommand;

        /// <summary>
        /// Gets the show hide column command.
        /// </summary>
        /// <value>The show hide column command.</value>
        public DelegateCommand<object> ShowHideColumnCommand
        {
            get
            {
                if (_ShowHideColumnCommand == null)
                {
                    _ShowHideColumnCommand = new DelegateCommand<object>(OnShowHideColumnCommand);
                }
                return _ShowHideColumnCommand;
            }
        }
        #endregion

        #region Methods

        /// <summary>
        /// Called when [show hide column command].
        /// </summary>
        /// <param name="param">The param.</param>
        public void OnShowHideColumnCommand(object param)
        {
            if (param != null)
            {
                VisibleColumn = null;
                if (visibleColumn.Contains(param.ToString()))
                    visibleColumn.Remove(param.ToString());
                else
                    visibleColumn.Add(param.ToString());
                VisibleColumn = visibleColumn;
            }
        }
        #endregion

        #region Properties
        public List<string> visibleColumn; 

        private List<Orders> _ordersDetails;

        /// <summary>
        /// Gets or sets the orders details.
        /// </summary>
        /// <value>The orders details.</value>
        public List<Orders> OrdersDetails
        {
            get{ return _ordersDetails;}
            set{ _ordersDetails = value;}
        }

        public List<string> _visibleColumn;

        /// <summary>
        /// Gets or sets the visible column.
        /// </summary>
        /// <value>The visible column.</value>
        public List<string> VisibleColumn
        {
            get
            {
                return _visibleColumn;
            }
            set
            {
                _visibleColumn = value;
                RaisePropertyChanged("VisibleColumn");
            }
        }

        #endregion

        /// <summary>
        /// Gets the orders details.
        /// </summary>
        /// <returns></returns>
        public List<Orders> GetOrdersDetails()
        {
            List<Orders> ordersDetails = new List<Orders>();
            if (!LayoutControl.IsInDesignMode)
            {
                string connectionString = LayoutControl.FindFile("Northwind.sdf");
                northWind = new Northwind(connectionString);
                var order = northWind.Orders;

                foreach (var o in order)
                {
                    ordersDetails.Add(o);
                }
            }
            return ordersDetails;
        }
    }  
}
