using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Syncfusion.Windows.Controls.Grid;
using System.ComponentModel;
using Syncfusion.Windows.Shared;
using DataBoundTemplateDemo.Model;

namespace DataBoundTemplateDemo
{
    class ViewModel
    {
        static Northwind northWind;

        /// <summary>
        /// Initializes a new instance of the <see cref="ViewModel"/> class.
        /// </summary>
        public ViewModel()
        {
            this.GetOrders();
        }

        private List<Orders> _OrderDetails;
        /// <summary>
        /// Gets or sets the order details.
        /// </summary>
        /// <value>The order details.</value>
        public List<Orders> OrderDetails
        {
            get { return _OrderDetails; }
            set { _OrderDetails = value;}
        }

        private static List<CustomerDetails> customersList = null;
        /// <summary>
        /// Gets the customers.
        /// </summary>
        /// <value>The customers.</value>
        public static List<CustomerDetails> Customers
        {
            get
            {
                if (customersList == null)
                {
                    customersList = northWind.Customers.Select(c =>
                        new CustomerDetails
                        {
                            CustomerID = c.CustomerID,
                            Name = c.ContactName
                        }).ToList();
                }

                return customersList.GetRange(0, customersList.Count);
            }
        }

        /// <summary>
        /// Gets the orders.
        /// </summary>
        void GetOrders()
        {
            OrderDetails = new List<Orders>();
            if (!LayoutControl.IsInDesignMode)
            {
                string connectionString = string.Format(@"Data Source = {0}", LayoutControl.FindFile("Northwind.sdf"));
                northWind = new Northwind(connectionString);
                var order = northWind.Orders.Skip(0).Take(50);
                foreach (var o in order)
                    OrderDetails.Add(o);
            }
        }
    }
}
