using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using Syncfusion.Windows.Controls.Grid;
using Syncfusion.Windows.Shared;

namespace AdvancedFilterDemo
{
    class ViewModel
    {
        Northwind northWind;
        /// <summary>
        /// Initializes a new instance of the <see cref="ViewModel"/> class.
        /// </summary>
        public ViewModel()
        {
            OrderInfo = this.GetOrdersInfo();
        }

        private List<Orders> _orderInfo;

        /// <summary>
        /// Gets or sets the order info.
        /// </summary>
        /// <value>The order info.</value>
        public List<Orders> OrderInfo
        {
            get
            {
                return _orderInfo;
            }
            set
            {
                _orderInfo = value;
            }
        }

        /// <summary>
        /// Gets the orders info.
        /// </summary>
        /// <returns></returns>
        private List<Orders> GetOrdersInfo()
        {
            List<Orders> ordersInfo = new List<Orders>();
            if (!LayoutControl.IsInDesignMode)
            {
                string connectionString = string.Format(@"Data Source = {0}", LayoutControl.FindFile("Northwind.sdf"));
                northWind = new Northwind(connectionString);
                var order = northWind.Orders;
                foreach (var o in order)
                {
                    ordersInfo.Add(o);
                }
            }
            return ordersInfo;
        }
       
    }   
}
