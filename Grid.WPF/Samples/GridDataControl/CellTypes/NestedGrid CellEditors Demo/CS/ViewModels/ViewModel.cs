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
using NestedGridCellEditorsDemo.DataModel;

namespace NestedGridCellEditorsDemo
{
    public class ViewModel :NotificationObject
    {
        private ObservableCollection<Customers> _customers = new ObservableCollection<Customers>();
        private bool _allowErrorOnEditing = true;

        /// <summary>
        /// Gets or sets the product list.
        /// </summary>
        /// <value>The product list.</value>
        public ObservableCollection<Customers> CustomerList
        {
            get
            {
                return _customers;
            }
            set
            {
                _customers = value;
                RaisePropertyChanged("CustomerList");
            }
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
            Northwind north = new Northwind(string.Format(@"Data Source= {0}", LayoutControl.FindFile("Northwind.sdf")));

            this.CustomerList = new ObservableCollection<Customers>(north.Customers);
        }
    }
}
