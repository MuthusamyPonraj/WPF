using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Syncfusion.Windows.Controls.Grid;
using System.ComponentModel;
using System.IO;
using GridDataControlSerializationDemo.Model;

namespace GridDataControlSerializationDemo
{
    public class ViewModel
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ViewModel"/> class.
        /// </summary>
        public ViewModel()
        {
            this.GetOrderDetails();
        }

        private List<Orders> _OrderDetails;
        /// <summary>
        /// Gets or sets the order details.
        /// </summary>
        /// <value>The order details.</value>
        public List<Orders> OrderDetails
        {
            get
            {
                return _OrderDetails;
            }
            set
            {
                _OrderDetails = value;
            }
        }

        /// <summary>
        /// Gets the order details.
        /// </summary>
        private void GetOrderDetails()
        {
            Northwind northWind;

            if (!LayoutControl.IsInDesignMode)
            {
                OrderDetails = new List<Orders>();
                string connectionString = string.Format(@"Data Source = {0}", LayoutControl.FindFile("Northwind.sdf"));
                northWind = new Northwind(connectionString);
                var order = northWind.Orders.Skip(0).Take(50);
                foreach (var o in order)
                {
                    this.OrderDetails.Add(o);
                }
            }
        }
    }
}