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
using System.Collections.ObjectModel;
using Syncfusion.Windows.Controls.Grid;
using Syncfusion.Windows.Data;

namespace CustomSortingDemo
{
    class ViewModel 
    {
        Northwind northWind;

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

        /// <summary>
        /// Gets the customer info.
        /// </summary>
        /// <returns></returns>
        public ObservableCollection<Customers> GetCustomerInfo()
        {
            ObservableCollection<Customers> customerInfo = new ObservableCollection<Customers>();
            if (!LayoutControl.IsInDesignMode)
            {
                string connectionString = string.Format(@"Data Source = {0}", LayoutControl.FindFile("Northwind.sdf"));
                northWind = new Northwind(connectionString);
                var customer = northWind.Customers.Skip(0).Take(100).ToList();
                foreach (var o in customer)
                {
                    customerInfo.Add(o);
                }
            }
            return customerInfo;
        }      
    }      
}
