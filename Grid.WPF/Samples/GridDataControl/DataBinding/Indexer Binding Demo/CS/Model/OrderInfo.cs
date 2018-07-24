using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IndexerBindingDemo
{
    public class OrderInfo
    {
        #region Private Members

        private int _OrderID;
        private string _CustomerID;
        private System.Nullable<int> _EmployeeID;
        private double _Freight;
        private bool _isClosed;
        private ShipDetail _shipDetails = new ShipDetail();

        #endregion

        /// <summary>
        /// Initializes a new instance of the <see cref="OrderInfo"/> class.
        /// </summary>
        public OrderInfo()
        {

        }

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
            }
        }

        /// <summary>
        /// Gets or sets the ship details.
        /// </summary>
        /// <value>The ship details.</value>
        public ShipDetail ShipDetails
        {
            get
            {
                return this._shipDetails;
            }
            set
            {
                this._shipDetails = value;
            }
        }
    }
}
