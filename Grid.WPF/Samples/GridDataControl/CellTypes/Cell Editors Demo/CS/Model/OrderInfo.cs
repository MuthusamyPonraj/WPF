using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Syncfusion.Windows.Shared;
using System.ComponentModel;

namespace CellEditorsDemo
{
    public partial class OrderInfo : NotificationObject, IDataErrorInfo
    {
        #region Private members

        private int _OrderID;
        private string _CustomerID;
        private System.Nullable<int> _EmployeeID;
        private string _ShipCity;
        private string _ShipCountry;
        private double _Freight;
        private bool _isClosed;
        private DateTime? _dob;
        private int _percent;
        private string _phone;
        private double _doubleval;

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="OrderInfo"/> class.
        /// </summary>
        public OrderInfo()
        {

        }

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
                return this._OrderID;
            }
            set
            {
                this._OrderID = value;
                this.RaisePropertyChanged("OrderID");
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
                return this._CustomerID;
            }
            set
            {
                this._CustomerID = value;
                this.RaisePropertyChanged("CustomerID");
            }
        }

        /// <summary>
        /// Gets or sets the delivery.
        /// </summary>
        /// <value>The delivery.</value>
        public DateTime? Delivery
        {
            get
            {
                return this._dob;
            }
            set
            {
                this._dob = value;
                this.RaisePropertyChanged("Delivery");
            }
        }

        /// <summary>
        /// Gets or sets the employee ID.
        /// </summary>
        /// <value>The employee ID.</value>
        public System.Nullable<int> EmployeeID
        {
            get
            {
                return this._EmployeeID;
            }
            set
            {
                this._EmployeeID = value;
                this.RaisePropertyChanged("EmployeeID");
            }
        }

        /// <summary>
        /// Gets or sets the ship city.
        /// </summary>
        /// <value>The ship city.</value>
        public string ShipCity
        {
            get
            {
                return this._ShipCity;
            }
            set
            {
                this._ShipCity = value;
                this.RaisePropertyChanged("ShipCity");
            }
        }

        /// <summary>
        /// Gets or sets the ship country.
        /// </summary>
        /// <value>The ship country.</value>
        public string ShipCountry
        {
            get
            {
                return this._ShipCountry;
            }
            set
            {
                this._ShipCountry = value;
                this.RaisePropertyChanged("ShipCountry");
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
                return this._Freight;
            }
            set
            {
                this._Freight = value;
                this.RaisePropertyChanged("Freight");
            }
        }

        /// <summary>
        /// Gets or sets the phone.
        /// </summary>
        /// <value>The phone.</value>
        public string Phone
        {
            get
            {
                return this._phone;
            }
            set
            {
                this._phone = value;
                this.RaisePropertyChanged("Phone");
            }
        }

        /// <summary>
        /// Gets or sets the percent.
        /// </summary>
        /// <value>The percent.</value>
        public int Percent
        {
            get
            {
                return this._percent;
            }
            set
            {
                this._percent = value;
                this.RaisePropertyChanged("Percent");
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is closed.
        /// </summary>
        /// <value><c>true</c> if this instance is closed; otherwise, <c>false</c>.</value>
        public bool IsClosed
        {
            get
            {
                return this._isClosed;
            }

            set
            {
                this._isClosed = value;
                this.RaisePropertyChanged("IsClosed");
            }
        }

        /// <summary>
        /// Gets or sets the doubleval.
        /// </summary>
        /// <value>The doubleval.</value>
        public double Doubleval
        {
            get
            {
                return _doubleval;
            }
            set
            {
                this._doubleval = value;
                this.RaisePropertyChanged("Doubleval");
            }
        }
        
        #endregion

        #region IDataErrorInfo Members

        public string Error
        {
            get { return string.Empty; }
        }

        public string this[string columnName]
        {
            get 
            {
                if (columnName == "CustomerID")
                {
                    return string.IsNullOrEmpty(CustomerID) ? "Customer ID cannot be null or empty." : string.Empty;
                }

                if (columnName == "Delivery")
                {
                    return Delivery.HasValue && Delivery.Value.DayOfWeek == DayOfWeek.Sunday  ? "Delivery date cannot be Sunday." : string.Empty;
                }

                if (columnName == "ShipCity")
                {
                    return string.IsNullOrEmpty(ShipCity) ? "Ship City cannot be null or empty." : string.Empty;
                }

                if (columnName == "ShipCountry")
                {
                    return string.IsNullOrEmpty(ShipCountry) ? "Ship Count cannot be null or empty." : string.Empty;
                }

                if (columnName == "Freight")
                {
                    return Freight == null || Freight <= 0 ? "Freight cannot be null or 0." : string.Empty;
                }

                if (columnName == "Phone")
                {
                    return string.IsNullOrEmpty(Phone) ? "Phone cannot be null or empty." : string.Empty;
                }

                if (columnName == "Percent")
                {
                    return Percent == null || Percent <= 0 ? "Percent cannot be null or 0." : string.Empty;
                }

                if (columnName == "Doubleval")
                {
                    return Doubleval == null || Doubleval <= 0 ? "Double Value cannot be null or 0." : string.Empty;
                }

                return string.Empty;
            }
        }

        #endregion
    }
}
