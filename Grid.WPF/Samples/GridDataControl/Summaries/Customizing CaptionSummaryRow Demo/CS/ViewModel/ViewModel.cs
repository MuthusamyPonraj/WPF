using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;
using System.ComponentModel;
using Syncfusion.Windows.Controls.Grid;
using Syncfusion.Windows.Shared;
using CustomizingCaptionSummaryRow_Demo.Model;

namespace CustomizingCaptionSummaryRow_Demo
{
    public class ViewModel : NotificationObject
    {
        private ObservableCollection<Products> _productDetails;

        /// <summary>
        /// Gets or sets the orders details.
        /// </summary>
        /// <value>The orders details.</value>
        public ObservableCollection<Products> ProductsDetails
        {
            get
            {
                return _productDetails;
            }
            set
            {
                _productDetails = value;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ViewModel"/> class.
        /// </summary>
        public ViewModel()
        {
            ProductsDetails = this.GetOrdersDetails();
        }


      

        /// <summary>
        /// Gets the orders details.
        /// </summary>
        /// <returns></returns>
        public ObservableCollection<Products> GetOrdersDetails()
        {
            ObservableCollection<Products> ordersDetails = new ObservableCollection<Products>();
            if (!LayoutControl.IsInDesignMode)
            {
                string connectionString = LayoutControl.FindFile("Northwind.sdf");
                var nw = new Northwind(connectionString);
                var products = nw.Products;
                foreach (var o in products)
                {
                    ordersDetails.Add(o);
                }
            }
            return ordersDetails;
        }
    }
}
