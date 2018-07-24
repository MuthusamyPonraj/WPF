using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;
using System.Data.SqlServerCe;
using Syncfusion.Windows.Controls.Grid;
using Syncfusion.Windows.Shared;

namespace OnDemandPagingDemo
{
    public class SalesOrderDetail : NotificationObject
    {
        private string _SalesOrderID;

        /// <summary>
        /// Gets or sets the sales order ID.
        /// </summary>
        /// <value>The sales order ID.</value>
        public string SalesOrderID
        {
            get
            {
                return _SalesOrderID;
            }
            set
            {
                _SalesOrderID = value;
                RaisePropertyChanged("SalesOrderID");
            }
        }

        private string _SalesOrderDetailID;

        /// <summary>
        /// Gets or sets the sales order detail ID.
        /// </summary>
        /// <value>The sales order detail ID.</value>
        public string SalesOrderDetailID
        {
            get
            {
                return _SalesOrderDetailID;
            }
            set
            {
                _SalesOrderDetailID = value;
                RaisePropertyChanged("SalesOrderDetailID");
            }
        }

        private string _CarrierTrackingNumber;

        /// <summary>
        /// Gets or sets the carrier tracking number.
        /// </summary>
        /// <value>The carrier tracking number.</value>
        public string CarrierTrackingNumber
        {
            get
            {
                return _CarrierTrackingNumber;
            }
            set
            {
                _CarrierTrackingNumber = value;
                RaisePropertyChanged("CarrierTrackingNumber");
            }
        }

        private int _OrderQty;

        /// <summary>
        /// Gets or sets the order qty.
        /// </summary>
        /// <value>The order qty.</value>
        public int OrderQty
        {
            get
            {
                return _OrderQty;
            }
            set
            {
                _OrderQty = value;
                RaisePropertyChanged("OrderQty");
            }
        }

        private string _ProductID;

        /// <summary>
        /// Gets or sets the product ID.
        /// </summary>
        /// <value>The product ID.</value>
        public string ProductID
        {
            get
            {
                return _ProductID;
            }
            set
            {
                _ProductID = value;
                RaisePropertyChanged("ProductID");
            }
        }
        private string _SpecialOfferID;

        /// <summary>
        /// Gets or sets the special offer ID.
        /// </summary>
        /// <value>The special offer ID.</value>
        public string SpecialOfferID
        {
            get
            {
                return _SpecialOfferID;
            }
            set
            {
                _SpecialOfferID = value;
                RaisePropertyChanged("SpecialOfferID");
            }
        }

        private double _UnitPrice;

        /// <summary>
        /// Gets or sets the unit price.
        /// </summary>
        /// <value>The unit price.</value>
        public double UnitPrice
        {
            get
            {
                return _UnitPrice;
            }
            set
            {
                _UnitPrice = value;
                RaisePropertyChanged("UnitPrice");
            }
        }

        private double _UnitPriceDiscount;

        /// <summary>
        /// Gets or sets the unit price discount.
        /// </summary>
        /// <value>The unit price discount.</value>
        public double UnitPriceDiscount
        {
            get
            {
                return _UnitPriceDiscount;
            }
            set
            {
                _UnitPriceDiscount = value;
                RaisePropertyChanged("UnitPriceDiscount");
            }
        }

        private double _LineTotal;

        /// <summary>
        /// Gets or sets the line total.
        /// </summary>
        /// <value>The line total.</value>
        public double LineTotal
        {
            get
            {
                return _LineTotal;
            }
            set
            {
                _LineTotal = value;
                RaisePropertyChanged("LineTotal");
            }
        }

        private string _rowguid;

        /// <summary>
        /// Gets or sets the rowguid.
        /// </summary>
        /// <value>The rowguid.</value>
        public string Rowguid
        {
            get
            {
                return _rowguid;
            }
            set
            {
                _rowguid = value;
                RaisePropertyChanged("Rowguid");
            }
        }
    }
}
