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
using DetailsViewDemo.DataModel;

namespace DetailsViewDemo
{
    public class ViewModel :NotificationObject
    {
        private ObservableCollection<Products> _products = new ObservableCollection<Products>();

        /// <summary>
        /// Gets or sets the product list.
        /// </summary>
        /// <value>The product list.</value>
        public ObservableCollection<Products> ProductList
        {
            get
            {
                return _products;
            }
            set
            {
                _products = value;
                RaisePropertyChanged("ProductList");
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
            if (!LayoutControl.IsInDesignMode)
            {
                Northwind north = new Northwind(string.Format(@"Data Source= {0}", LayoutControl.FindFile("Northwind.sdf")));
                this.ProductList = new ObservableCollection<Products>(north.Products);
            }
        }
    }
}
