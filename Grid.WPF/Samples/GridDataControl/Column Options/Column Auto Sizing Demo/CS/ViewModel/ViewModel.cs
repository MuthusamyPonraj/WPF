using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Syncfusion.Windows.Controls.Grid;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;
using System.Windows.Data;
using Syncfusion.Windows.Shared;
using ColumnAutoSizingDemo.DataModel;

namespace ColumnAutoSizingDemo
{
    class ViewModel : NotificationObject
    {
        private ObservableCollection<Orders> _ordersDetails;

        /// <summary>
        /// Gets or sets the orders details.
        /// </summary>
        /// <value>The orders details.</value>
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

        /// <summary>
        /// Initializes a new instance of the <see cref="ViewModel"/> class.
        /// </summary>
        public ViewModel()
        {
            OrdersDetails = this.GetOrdersDetails();           
        }

       
        private string _SelectedColumn;

        /// <summary>
        /// Gets or sets the selected column.
        /// </summary>
        /// <value>The selected column.</value>
        public string SelectedColumn
        {
            get
            {
                return _SelectedColumn;
            }
            set
            {
                _SelectedColumn = value;
                RaisePropertyChanged("SelectedColumn");
            }
        }

        private string _TextValue;

        /// <summary>
        /// Gets or sets the text value.
        /// </summary>
        /// <value>The text value.</value>
        public string TextValue
        {
            get
            {
                return _TextValue;
            }
            set
            {
                _TextValue = value;
                RaisePropertyChanged("TextValue");
            }
        }      

        private string _SelectedSizer;

        /// <summary>
        /// Gets or sets the selected sizer.
        /// </summary>
        /// <value>The selected sizer.</value>
        public string SelectedSizer
        {
            get
            {
                return _SelectedSizer;
            }
            set
            {
                _SelectedSizer = value;
                RaisePropertyChanged("SelectedSizer");
            }
        }

        /// <summary>
        /// Gets the orders details.
        /// </summary>
        /// <returns></returns>
        public ObservableCollection<Orders> GetOrdersDetails()
        {
            ObservableCollection<Orders> ordersDetails = new ObservableCollection<Orders>();
            if (!LayoutControl.IsInDesignMode)
            {
                string connectionString = LayoutControl.FindFile("Northwind.sdf");
                var nw = new Northwind(connectionString);
                var orders = nw.Orders;
                foreach (var o in orders)
                {
                    ordersDetails.Add(o);
                }
            }
            return ordersDetails;
        }
    }   
}
