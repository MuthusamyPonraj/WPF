using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using Syncfusion.Windows.Controls.Grid;
using System.Collections.ObjectModel;
using Syncfusion.Windows.Shared;
using ColumnOptionsDemo.DataModel;
namespace ColumnOptionsDemo
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

        private ObservableCollection<Orders> _ordersDetails;

        /// <summary>
        /// Gets or sets the orders info.
        /// </summary>
        /// <value>The orders info.</value>
        public ObservableCollection<Orders> OrdersDetails
        {
            get
            {
                return _ordersDetails;
            }
            set
            {
                _ordersDetails = value;
            }
        }

        public ObservableCollection<Orders> GetOrdersDetails()
        {
            ObservableCollection<Orders> ordersDetails = new ObservableCollection<Orders>();
            if (!LayoutControl.IsInDesignMode)
            {
                string connectionString = string.Format(@"Data Source = {0}", LayoutControl.FindFile("Northwind.sdf"));
                northWind = new Northwind(connectionString);
                var order = northWind.Orders.Skip(0).Take(100).ToList();
                foreach (var o in order)
                {
                    ordersDetails.Add(o);
                }
            }
            return ordersDetails;
        }
    }
}
