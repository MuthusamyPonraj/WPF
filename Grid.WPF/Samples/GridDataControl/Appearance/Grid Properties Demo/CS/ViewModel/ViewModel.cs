using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;
using System.ComponentModel;
using Syncfusion.Windows.Controls.Grid;
using System.Windows.Media;
using System.Windows.Data;
using Syncfusion.Windows.Shared;
using GridPropertiesDemo.DataModel;

namespace GridPropertiesDemo
{
    class ViewModel
    {

        Northwind northWind;
        /// <summary>
        /// Initializes a new instance of the <see cref="ViewModel"/> class.
        /// </summary>
        public ViewModel()
        {
            OrderDetails = this.GetOrderDetails();
        }

        private ObservableCollection<Orders> _orderDetails;

        /// <summary>
        /// Gets or sets the order details.
        /// </summary>
        /// <value>The order details.</value>
        public ObservableCollection<Orders> OrderDetails
        {
            get
            {
                return _orderDetails;
            }
            set
            {
                _orderDetails = value;                
            }
        }

        /// <summary>
        /// Gets the order details.
        /// </summary>
        /// <returns></returns>
        public ObservableCollection<Orders> GetOrderDetails()
        {
            ObservableCollection<Orders> orderDetails = new ObservableCollection<Orders>();
            if (!LayoutControl.IsInDesignMode)
            {
                string connectionString = string.Format(@"Data Source = {0}", LayoutControl.FindFile("Northwind.sdf"));
                northWind = new Northwind(connectionString);
                var order = northWind.Orders.Skip(0).Take(100).ToList();
                foreach (var o in order)
                {
                    orderDetails.Add(o);
                }
            }
            return orderDetails;
        }
    }
}
