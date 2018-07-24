using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Syncfusion.Windows.Shared;
using System.ComponentModel;

namespace ErrorInfoValidationDemo.DataModel
{
    public class OrderInfo : NotificationObject, IDataErrorInfo
    {
        #region Private members

        private int _orderId;
        private string _customerId;
        private string _productName;
        private double _unitPrice;
        private int _quantiy;
        private double _discount;
        private double _freight;
        private DateTime _orderDate;
        private string _shipPostalCode;
        private string _shipAddress;
        private DateTime _shippedDate;

        #endregion

        #region Public properties

        /// <summary>
        /// Gets or sets the order ID.
        /// </summary>
        /// <value>The order ID.</value>
        public int OrderID
        {
            get
            {
                return _orderId;
            }
            set
            {
                _orderId = value;
                RaisePropertyChanged("OrderID");
            }
        }

        /// <summary>
        /// Gets or sets the customer ID.
        /// </summary>
        /// <value>The customer ID.</value>
        public string CustomerID
        {
            get
            {
                return _customerId;
            }
            set
            {
                _customerId = value;
                RaisePropertyChanged("CustomerID");
            }
        }

        /// <summary>
        /// Gets or sets the name of the product.
        /// </summary>
        /// <value>The name of the product.</value>
        public string ProductName
        {
            get
            {
                return _productName;
            }
            set
            {
                _productName = value;
                RaisePropertyChanged("ProductName");
            }
        }

        /// <summary>
        /// Gets or sets the unit price.
        /// </summary>
        /// <value>The unit price.</value>
        public double UnitPrice
        {
            get
            {
                return _unitPrice;   
            }
            set
            {
                _unitPrice = value;
            }
        }

        /// <summary>
        /// Gets or sets the quantity.
        /// </summary>
        /// <value>The quantity.</value>
        public int Quantity
        {
            get
            {
                return _quantiy;
            }
            set
            {
                _quantiy = value;
                RaisePropertyChanged("Quantity");
            }
        }

        /// <summary>
        /// Gets or sets the discount.
        /// </summary>
        /// <value>The discount.</value>
        public double Discount
        {
            get
            {
                return _discount;
            }
            set
            {
                _discount = value;
                RaisePropertyChanged("Discount");
            }
        }

        /// <summary>
        /// Gets or sets the freight.
        /// </summary>
        /// <value>The freight.</value>
        public double Freight
        {
            get
            {
                return _freight;
            }
            set
            {
                _freight = value;
                RaisePropertyChanged("Freight");
            }
        }

        /// <summary>
        /// Gets or sets the order date.
        /// </summary>
        /// <value>The order date.</value>
        public DateTime OrderDate
        {
            get
            {
                return _orderDate;
            }
            set
            {
                _orderDate = value;
                RaisePropertyChanged("OrderDate");
            }
        }

        /// <summary>
        /// Gets or sets the shipped date.
        /// </summary>
        /// <value>The shipped date.</value>
        public DateTime ShippedDate
        {
            get
            {
                return _shippedDate;
            }
            set
            {
                _shippedDate = value;
                RaisePropertyChanged("ShippedDate");
            }
        }

        /// <summary>
        /// Gets or sets the ship postal code.
        /// </summary>
        /// <value>The ship postal code.</value>
        public string ShipPostalCode
        {
            get
            {
                return _shipPostalCode;
            }
            set
            {
                _shipPostalCode = value;
                RaisePropertyChanged("ShipPostalCode");
            }
        }

        /// <summary>
        /// Gets or sets the ship address.
        /// </summary>
        /// <value>The ship address.</value>
        public string  ShipAddress
        {
            get
            {
                return _shipAddress;
            }
            set
            {
                _shipAddress = value;
                RaisePropertyChanged("ShipAddress");
            }
        }

        #endregion

        #region IDataErrorInfo Members

        /// <summary>
        /// Gets an error message indicating what is wrong with this object.
        /// </summary>
        /// <value></value>
        /// <returns>An error message indicating what is wrong with this object. The default is an empty string ("").</returns>
        [Bindable(false)]
        public string Error
        {
            get { return string.Empty; }
        }

        /// <summary>
        /// Gets the <see cref="System.String"/> with the specified column name.
        /// </summary>
        /// <value></value>
        public string this[string columnName]
        {
            get
            {
                if(columnName == "CustomerID")
                {
                    return string.IsNullOrEmpty(this.CustomerID) ? "CustomerID cannot be null or empty." : string.Empty;
                }

                if (columnName == "ProductName")
                {
                    return string.IsNullOrEmpty(this.ProductName) ? "ProductName cannot be null or empty." : string.Empty;
                }

                if (columnName == "UnitPrice")
                {
                    return this.UnitPrice <= 10 ? "UnitPrice cannot be less than 10." : string.Empty;
                }

                if (columnName == "Quantity")
                {
                    return this.Quantity <= 0.0 ? "Quantity cannot be less than 1." : string.Empty;
                }

                if (columnName == "Discount")
                {
                    return this.Discount < 0.0 || this.Discount > 50 ? "Discount range should fall between 0 and 50." : string.Empty;
                }

                if (columnName == "Freight")
                {
                    return this.Freight <= 10 ? "Freight cannot be less than 10." : string.Empty;
                }

                if (columnName == "OrderDate")
                {
                    return this.OrderDate == null ? "Order Date cannot be null or empty." : string.Empty;
                }

                if (columnName == "ShippedDate")
                {
                    return this.ShippedDate < this.OrderDate ? "Shipped date cannot be earlier than order date" : string.Empty;
                }

                if (columnName == "ShipPostalCode")
                {
                    return string.IsNullOrEmpty(this.ShipPostalCode) ? "Ship Postal Code cannot be null or empty." : string.Empty;
                }

                if (columnName == "ShipAddress")
                {
                    return string.IsNullOrEmpty(this.ShipAddress) ? "Ship Address cannot be null or empty." : string.Empty;
                }

                return string.Empty;
            }
        }

        #endregion
    }
}