using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Syncfusion.Windows.Controls.Grid;
using System.Windows.Data;
using System.ComponentModel;
using System.Collections.ObjectModel;

namespace SortbySummaryDemo
{
    class SummaryViewModel
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SummaryViewModel"/> class.
        /// </summary>
        public SummaryViewModel()
        {
            OrderInfo = this.GetOrderData();
        }

        private ObservableCollection<Orders> _OrderInfo;
        /// <summary>
        /// Gets or sets the order info.
        /// </summary>
        /// <value>The order info.</value>
        public ObservableCollection<Orders> OrderInfo
        {
            get
            {
                return _OrderInfo;
            }
            set
            {
                _OrderInfo = value;
            }
        }

        /// <summary>
        /// Gets the order data.
        /// </summary>
        /// <returns></returns>
        public ObservableCollection<Orders> GetOrderData()
        {
            Northwind northWind = null;
            ObservableCollection<Orders> _Orders = new ObservableCollection<Orders>();
            if (!LayoutControl.IsInDesignMode)
            {
                string connectionString = string.Format(@"Data Source = {0}", LayoutControl.FindFile("Northwind.sdf"));
                northWind = new Northwind(connectionString);
                var orders = northWind.Orders.ToList();
                foreach (var o in orders)
                {
                    _Orders.Add(o);
                }
            }
            return _Orders;
        }
    }
}
