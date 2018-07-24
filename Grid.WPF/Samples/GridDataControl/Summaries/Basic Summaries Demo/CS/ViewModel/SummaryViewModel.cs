using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using Syncfusion.Windows.Controls.Grid;
using System.Collections.ObjectModel;

namespace BasicSummariesDemo
{
    /// <summary>
    /// 
    /// </summary>
    public class SummaryViewModel 
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SummaryViewModel"/> class.
        /// </summary>
        public SummaryViewModel()
        {
            OrdersInfo = this.GetOrderData();
        }

        private ObservableCollection<Orders> _OrdersInfo;

        /// <summary>
        /// Gets or sets the orders info.
        /// </summary>
        /// <value>The orders info.</value>
        public ObservableCollection<Orders> OrdersInfo
        {
            get
            {
                return _OrdersInfo;
            }
            set
            {
                _OrdersInfo = value;
            }
        }

        /// <summary>
        /// Gets the order data.
        /// </summary>
        /// <returns></returns>
         public ObservableCollection<Orders> GetOrderData()
        {
            ObservableCollection<Orders> _Order = new ObservableCollection<Orders>();
            if (!LayoutControl.IsInDesignMode)
            {
                string connectionString = string.Format(@"Data Source = {0}", LayoutControl.FindFile("Northwind.sdf"));
                var northWind = new Northwind(connectionString);
                var orders = northWind.Orders.ToList();
                foreach (var o in orders)
                {
                    _Order.Add(o);
                }
            }
            return _Order;
        }
    }
}
