using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Collections.ObjectModel;
using Syncfusion.Windows.Controls.Grid;

namespace TableSummariesDemo
{
    class TableSummaryViewModel 
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TableSummaryViewModel"/> class.
        /// </summary>
        public TableSummaryViewModel()
        {
            OrdersInfo = this.GetOrdersData();
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
        /// Gets the orders data.
        /// </summary>
        /// <returns></returns>
        public ObservableCollection<Orders> GetOrdersData()
        {
            ObservableCollection<Orders> _Orders = new ObservableCollection<Orders>();
            //Retrieving data from database.
            if (!LayoutControl.IsInDesignMode)
            {
                string connectionString = LayoutControl.FindFile("Northwind.sdf");
                var nw = new Northwind(connectionString);
                var orders = nw.Orders.Skip(0).Take(1000).ToList();
                foreach (var o in orders)
                {
                    _Orders.Add(o);
                }
            }
            return _Orders;
        }
    }
}
