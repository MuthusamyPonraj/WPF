using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Collections.ObjectModel;
using Syncfusion.Windows.Controls.Grid;
using Syncfusion.Windows.Shared;

namespace BasicFilteringDemo
{
    class ViewModel : NotificationObject
    {
        Northwind northWind;
        public ViewModel()
        {
            ProductInfo = this.GetProductInfo();            
        }

        private List<Products> _productInfo;

        /// <summary>
        /// Gets or sets the product info.
        /// </summary>
        /// <value>The product info.</value>
        public List<Products> ProductInfo
        {
            get
            {
                return _productInfo;
            }
            set
            {
                _productInfo = value;
                RaisePropertyChanged("ProductInfo");
            }
        }

        /// <summary>
        /// Gets the product info.
        /// </summary>
        /// <returns></returns>
        private List<Products> GetProductInfo()
        {
            List<Products> productInfo = new List<Products>();
            if (!LayoutControl.IsInDesignMode)
            {
                northWind = new Northwind(string.Format(@"Data Source= {0}", LayoutControl.FindFile("Northwind.sdf")));
                var ords = northWind.Products.Take(500);
                foreach (var em in ords)
                {

                    productInfo.Add(em);
                }
            }
            return productInfo;
        }      
    }
}
