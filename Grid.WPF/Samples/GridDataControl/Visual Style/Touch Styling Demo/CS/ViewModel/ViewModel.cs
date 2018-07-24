using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;
using Syncfusion.Windows.Controls.Grid;
using TouchStylingDemo.Model;

namespace TouchStylingDemo
{
    class ViewModel
    {
        Northwind northWind;

        /// <summary>
        /// Initializes a new instance of the <see cref="ViewModel"/> class.
        /// </summary>
        public ViewModel()
        {
            CustomerDetails = this.GetCustomerDetails();
        }
        
        private ObservableCollection<Customers> _customerDetails;

        /// <summary>
        /// Gets or sets the employee info.
        /// </summary>
        /// <value>The employee info.</value>
        public ObservableCollection<Customers> CustomerDetails
        {
            get
            {                
                return _customerDetails;
            }
            set
            {
                _customerDetails = value;
            }
        }

        /// <summary>
        /// Gets the employee info.
        /// </summary>
        /// <returns></returns>
        private ObservableCollection<Customers> GetCustomerDetails()
        {
            var customerDetails = new ObservableCollection<Customers>();

            if (!LayoutControl.IsInDesignMode)
            {
                string connectionString = string.Format(@"Data Source = {0}", LayoutControl.FindFile("Northwind.sdf"));
                northWind = new Northwind(connectionString);
                var emp = northWind.Customers.Take(100).ToList();
                foreach (var o in emp)
                {
                    customerDetails.Add(o);
                }
            }
            return customerDetails;
        }
    }
    
}
