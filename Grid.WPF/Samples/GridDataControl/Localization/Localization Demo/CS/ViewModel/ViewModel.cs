using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Syncfusion.Windows.Controls.Grid;
using System.Collections.ObjectModel;
using System.ComponentModel;
using LocalizationDemo.Model;

namespace LocalizationDemo
{
    class ViewModel
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ViewModel"/> class.
        /// </summary>
        public ViewModel()
        {
            this.GetOrders();
        }

        private ObservableCollection<Orders> _OrderDetails;
        /// <summary>
        /// Gets or sets the order details.
        /// </summary>
        /// <value>The order details.</value>
        public ObservableCollection<Orders> OrderDetails
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
        /// Gets the orders.
        /// </summary>
        void GetOrders()
        {
            Northwind northWind;
            if (!LayoutControl.IsInDesignMode)
            {
                OrderDetails = new ObservableCollection<Orders>();
                string connectionString = string.Format(@"Data Source = {0}", LayoutControl.FindFile("Northwind.sdf"));
                northWind = new Northwind(connectionString);
                var order = northWind.Orders.Skip(0).Take(100).ToList();
                foreach (var o in order)
                {
                    this.OrderDetails.Add(o);
                }
            }
        }
    }
}