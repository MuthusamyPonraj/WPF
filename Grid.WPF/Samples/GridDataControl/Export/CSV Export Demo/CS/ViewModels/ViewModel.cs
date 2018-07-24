using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Syncfusion.Windows.Controls.Grid;
using System.ComponentModel;
using System.Windows;
using Syncfusion.Windows.Controls.Grid.Converter;
using Syncfusion.Windows.Shared;

namespace CSVExportDemo
{
    class ViewModel : NotificationObject
    {
        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="ViewModel"/> class.
        /// </summary>
        public ViewModel()
        {
            _orderCollection = new List<Orders>();
            this.GetOrders();
        }

        #endregion

        #region Properties

        private List<Orders> _orderCollection;

        /// <summary>
        /// Gets or sets the GDC source.
        /// </summary>
        /// <value>The GDC source.</value>
        public List<Orders> OrderCollection
        {
            get
            {
                return _orderCollection;
            }
            set
            {
                _orderCollection = value;
                RaisePropertyChanged("GDCSource");
            }
        }

        #endregion

        /// <summary>
        /// Gets the orders.
        /// </summary>
        private void GetOrders()
        {
            if (!LayoutControl.IsInDesignMode)
            {
                Northwind northWind;

                string connectionString = string.Format(@"Data Source = {0}", LayoutControl.FindFile("Northwind.sdf"));
                northWind = new Northwind(connectionString);
                var order = northWind.Orders;
                foreach (var o in order)
                {
                    _orderCollection.Add(o);
                }
            }
        }
    }
}
