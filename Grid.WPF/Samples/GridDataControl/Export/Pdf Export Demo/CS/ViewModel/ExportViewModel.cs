using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;
using ExportToPdfDemo_2010.DataModel;
using Syncfusion.Windows.Controls.Grid;

namespace ExportToPdfDemo_2010.ViewModel
{
    public class ExportViewModel
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ExportViewModel"/> class.
        /// </summary>
        public ExportViewModel()
        {
            this.OrderDetails = this.GetOrderDetails();
        }

        private ObservableCollection<Orders> _OrderDetails;

        /// <summary>
        /// Gets or sets the order details.
        /// </summary>
        /// <value>The order details.</value>
        public ObservableCollection<Orders> OrderDetails
        {
            get { return _OrderDetails; }
            set { _OrderDetails = value; }
        }

        /// <summary>
        /// Gets the order details.
        /// </summary>
        /// <returns></returns>
        public ObservableCollection<Orders> GetOrderDetails()
        {
            ObservableCollection<Orders> _Order = new ObservableCollection<Orders>();
            if (!LayoutControl.IsInDesignMode)
            {
                int i = 0;
                Northwind northWind = new Northwind(string.Format(@"Data Source = {0}", LayoutControl.FindFile("Northwind.sdf")));
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
