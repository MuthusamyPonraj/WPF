using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;
using System.ComponentModel;
using Syncfusion.Windows.Controls.Grid;
using System.Windows.Media;
using System.Windows.Controls;
using System.Windows;
using BindingListDemo.Model;
using System.Windows.Media.Imaging;
using Syncfusion.Windows.Shared;

namespace BindingListDemo
{
    class GridViewModel 
    {
        Northwind northWind;
        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="GridViewModel"/> class.
        /// </summary>
        public GridViewModel()
        {
            this.CustomerDetails = this.GetCustomerDetails();
            _addCustomer = new DelegateCommand<Customers>(AddCustomerHandler, CanAddCustomer);
            _editCustomer = new DelegateCommand<Customers>(UpdateCustomerHandler, CanUpdateCustomer);
            _deleteCustomer = new DelegateCommand<Customers>(DeleteCustomerHandler);
        }
        #endregion

        #region Command Handler

        /// <summary>
        /// Determines whether this instance [can add customer] the specified customers.
        /// </summary>
        /// <param name="customers">The customers.</param>
        /// <returns>
        /// 	<c>true</c> if this instance [can add customer] the specified customers; otherwise, <c>false</c>.
        /// </returns>
        bool CanAddCustomer(Customers customers)
        {
            return true;
        }

        /// <summary>
        /// Adds the customer handler.
        /// </summary>
        /// <param name="customers">The customers.</param>
        public void AddCustomerHandler(Customers customers)
        {
            if (customers == null)
            {
                return;
            }

            this.CustomerDetails.Add(customers);
        }

        /// <summary>
        /// Determines whether this instance [can update customer] the specified customers.
        /// </summary>
        /// <param name="customers">The customers.</param>
        /// <returns>
        /// 	<c>true</c> if this instance [can update customer] the specified customers; otherwise, <c>false</c>.
        /// </returns>
        bool CanUpdateCustomer(Customers customers)
        {
            return this.SelectedCustomer != null;
        }

        /// <summary>
        /// Updates the customer handler.
        /// </summary>
        /// <param name="customers">The customers.</param>
        public void UpdateCustomerHandler(Customers customers)
        {
            if (customers == null)
                return;
            _SelectedCustomer.CustomerID = customers.CustomerID;
            _SelectedCustomer.CompanyName = customers.CompanyName;
            _SelectedCustomer.ContactName = customers.ContactName;
            _SelectedCustomer.ContactTitle = customers.ContactTitle;
            _SelectedCustomer.Address = customers.Address;
            _SelectedCustomer.City = customers.City;
            _SelectedCustomer.Region = customers.Region;
            _SelectedCustomer.Country = customers.Country;
            _SelectedCustomer.Phone = customers.Phone;
            _SelectedCustomer.Fax = customers.Fax;
           
        }

        /// <summary>
        /// Deletes the customer handler.
        /// </summary>
        /// <param name="customers">The customers.</param>
        public void DeleteCustomerHandler(Customers customers)
        {
            if (customers == null)
                return;

            this.CustomerDetails.Remove(customers);
        }

        #endregion

        private readonly DelegateCommand<Customers> _addCustomer;
        private readonly DelegateCommand<Customers> _editCustomer;
        private readonly DelegateCommand<Customers> _deleteCustomer;

        /// <summary>
        /// Gets the add customer.
        /// </summary>
        /// <value>The add customer.</value>
        public DelegateCommand<Customers> AddCustomer
        {
            get { return _addCustomer; }
        }

        /// <summary>
        /// Gets the edit customer.
        /// </summary>
        /// <value>The edit customer.</value>
        public DelegateCommand<Customers> EditCustomer
        {
            get { return _editCustomer; }
        }

        /// <summary>
        /// Gets the delete customer.
        /// </summary>
        /// <value>The delete customer.</value>
        public DelegateCommand<Customers> DeleteCustomer
        {
            get { return _deleteCustomer; }
        }      

        #region Properties
      
        private BindingList<Customers> _customerDetails;

        /// <summary>
        /// Gets or sets the customer details.
        /// </summary>
        /// <value>The customer details.</value>
        public BindingList<Customers> CustomerDetails
        {
            get{return _customerDetails;}
            set{_customerDetails = value;}
        }

        private Customers _SelectedCustomer;

        /// <summary>
        /// Gets or sets the selected customer.
        /// </summary>
        /// <value>The selected customer.</value>
        public Customers SelectedCustomer
        {
            get{return _SelectedCustomer;}
            set{_SelectedCustomer = value;}
        }
        
        #endregion  
        
        #region Methods

        /// <summary>
        /// Gets the customer details.
        /// </summary>
        /// <returns></returns>
        public BindingList<Customers> GetCustomerDetails()
        {
            BindingList<Customers> customerDetails = new BindingList<Customers>();
            if (!LayoutControl.IsInDesignMode)
            {
                string connectionString = string.Format(@"Data Source = {0}", LayoutControl.FindFile("Northwind.sdf"));
                northWind = new Northwind(connectionString);
                var customer = northWind.Customers.Skip(0).Take(50).ToList();
                foreach (var o in customer)
                {
                    customerDetails.Add(o);
                }
            }
            return customerDetails;
        }
        #endregion    
    }   
}
