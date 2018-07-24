using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using Syncfusion.Windows.Controls.Grid;
using System.Data.SqlServerCe;
using System.Text.RegularExpressions;
using System.Windows.Media;
using System.Windows;
using System.Windows.Media.Imaging;
using System.Collections.ObjectModel;
using Syncfusion.Windows.Shared;
using StackedHeadersDemo.Model;

namespace StackedHeadersDemo
{
    public class ViewModel
    {
        private ObservableCollection<Orders> _orders = new ObservableCollection<Orders>();

        /// <summary>
        /// Gets or sets the product list.
        /// </summary>
        /// <value>The product list.</value>
        public ObservableCollection<Orders> OrderList
        {
            get{ return _orders; }
            set{ _orders = value;}
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ViewModel"/> class.
        /// </summary>
        public ViewModel()
        {
            this.PopulateData();
        }

        /// <summary>
        /// Populates the data.
        /// </summary>
        private void PopulateData()
        {
            if (!LayoutControl.IsInDesignMode)
            {
                Northwind north = new Northwind(string.Format(@"Data Source= {0}", LayoutControl.FindFile("Northwind.sdf")));
                this.OrderList = new ObservableCollection<Orders>(north.Orders.Take(150));
            }
        }
    }
}
