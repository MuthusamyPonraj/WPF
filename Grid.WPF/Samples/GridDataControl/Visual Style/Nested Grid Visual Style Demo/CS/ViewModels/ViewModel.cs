using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Data;
using System.ComponentModel;
using Syncfusion.Windows.Controls.Grid;
using System.Collections.ObjectModel;
using System.IO;
using System.Windows.Media.Imaging;
using System.Windows.Controls;
using NestedGridVisualStyleDemo.DataModel;

namespace NestedGridVisualStyleDemo
{
    class ViewModel 
    {
        Northwind northWind;

        /// <summary>
        /// Initializes a new instance of the <see cref="ViewModel"/> class.
        /// </summary>
        public ViewModel()
        {
            OrdersDetails = this.GetOrdersDetails();
        }

        private List<Orders> ordersDetails;

        /// <summary>
        /// Gets or sets the orders details.
        /// </summary>
        /// <value>The orders details.</value>
        public List<Orders> OrdersDetails
        {
            get
            {
                return ordersDetails;
            }
            set
            {
                ordersDetails = value;
            }
        }

        #region Private Method

        /// <summary>
        /// Gets the order details.
        /// </summary>
        /// <returns></returns>
          private List<Orders> GetOrdersDetails()
        {
            List<Orders> orderDetails = new List<Orders>();
            if (!LayoutControl.IsInDesignMode)
            {
                string connectionString = string.Format(@"Data Source = {0}", LayoutControl.FindFile("Northwind.sdf"));
                northWind = new Northwind(connectionString);
                var order = northWind.Orders;
                foreach (var o in order)
                {
                    orderDetails.Add(o);
                }
            }
            return orderDetails;
        }
        #endregion
    }
}
