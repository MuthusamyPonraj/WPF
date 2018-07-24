using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using Syncfusion.Windows.Shared;
using System.Windows.Input;
using Syncfusion.Windows.Controls.Grid;
using System.Dynamic;

namespace DynamicObjectsDemo
{
    public class ManipulatorViewModel : NotificationObject, IDataErrorInfo
    {
        #region IDataErrorInfo Members

        private readonly IDictionary<string, string> errorInfo = new Dictionary<string, string>();

        public string Error
        {
            get { throw new NotImplementedException(); }
        }

        /// <summary>
        /// Gets or sets the <see cref="System.String"/> with the specified column name.
        /// </summary>
        /// <value></value>
        public string this[string columnName]
        {
            get
            {
                if (this.errorInfo.ContainsKey(columnName))
                {
                    return this.errorInfo[columnName];
                }
                return null;
            }
            set
            {
                this.errorInfo[columnName] = value;
            }
        }

        /// <summary>
        /// Validates this instance.
        /// </summary>
        private void Validate()
        {
            if (string.IsNullOrEmpty(this.CustomerID))
            {
                this["CustomerID"] = this.GetErrorInfo("CustomerID");
            }
            else
            {
                this.RemoveError("CustomerID");
            }         

            if (string.IsNullOrEmpty(this.ShipCity))
            {
                this["ShipCity"] = this.GetErrorInfo("ShipCity");
            }
            else
            {
                this.RemoveError("ShipCity");
            }

            if (string.IsNullOrEmpty(this.ShipCountry))
            {
                this["ShipCountry"] = this.GetErrorInfo("ShipCountry");
            }
            else
            {
                this.RemoveError("ShipCountry");
            }           
        }

        /// <summary>
        /// Removes the error.
        /// </summary>
        /// <param name="columnName">Name of the column.</param>
        private void RemoveError(string columnName)
        {
            if (this.errorInfo.ContainsKey(columnName))
            {
                this.errorInfo.Remove(columnName);
            }
        }

        /// <summary>
        /// Gets the error info.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        private string GetErrorInfo(string value)
        {
            return value + " can not be null.";
        }

        #endregion

        #region Properties

        private OrderInfo _ordersInfo = new OrderInfo();

        /// <summary>
        /// Gets or sets the orders info.
        /// </summary>
        /// <value>The orders info.</value>
        public OrderInfo OrdersInfo
        {
            get{ return _ordersInfo; }
            set{ _ordersInfo = value;}
        }

        /// <summary>
        /// Gets or sets the order ID.
        /// </summary>
        /// <value>The order ID.</value>
        public int OrderID
        {
            get
            {
                return OrdersInfo.OrderID;
            }
            set
            {
                OrdersInfo.OrderID = value;
                this.RaisePropertyChanged("OrderID");
            }
        }

        private List<string> _Shipcitycollec;

        /// <summary>
        /// Gets or sets the shipcitycollec.
        /// </summary>
        /// <value>The shipcitycollec.</value>
        public List<string> Shipcitycollec
        {
            get { return _Shipcitycollec; }
            set { _Shipcitycollec = value; }
        }

        private List<string> _ShipCountrycollec;

        /// <summary>
        /// Gets or sets the ship countrycollec.
        /// </summary>
        /// <value>The ship countrycollec.</value>
        public List<string> ShipCountrycollec
        {
            get { return _ShipCountrycollec; }
            set { _ShipCountrycollec = value; }
        }

        /// <summary>
        /// Gets or sets the customer ID.
        /// </summary>
        /// <value>The customer ID.</value>
        public string CustomerID
        {
            get
            {
                return OrdersInfo.CustomerID;
            }
            set
            {
                OrdersInfo.CustomerID = value;
                this.RaisePropertyChanged("CustomerID");
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
                return OrdersInfo.EmployeeID;
            }
            set
            {
                OrdersInfo.EmployeeID = value;
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
                return OrdersInfo.ShipCity;
            }
            set
            {
                OrdersInfo.ShipCity = value;
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
                return OrdersInfo.ShipCountry;
            }
            set
            {
                OrdersInfo.ShipCountry = value;
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
                return OrdersInfo.Freight;
            }
            set
            {
                OrdersInfo.Freight = value;
                this.RaisePropertyChanged("Freight");
            }
        }

        /// <summary>
        /// Gets or sets the content of the save button.
        /// </summary>
        /// <value>The content of the save button.</value>
        public string SaveButtonContent
        {
            get;
            set;
        }

        #endregion

        #region Constructor & Methods

        private bool _isInEdit;

        /// <summary>
        /// Initializes a new instance of the <see cref="ManipulatorViewModel"/> class.
        /// </summary>
        /// <param name="OrdersInfo">The orders info.</param>
        /// <param name="isInEdit">if set to <c>true</c> [is in edit].</param>
        public ManipulatorViewModel(dynamic OrdersInfo, bool isInEdit)
        {
            _isInEdit = isInEdit;
            SaveCommand = new DelegateCommand<OrderInfo>(this.Save, this.CanSave);
            SaveButtonContent = isInEdit ? "Save" : "Add";
            if(_isInEdit)
            CloneZipCode(OrdersInfo);

            if (_isInEdit)
                Validate();
            ShipCountrycollec = this.GetShipcountrylist();
           Shipcitycollec = this.GetShicitylist();

            this.PropertyChanged += OnPropertyChanged;
        }

        /// <summary>
        /// Gets the shicitylist.
        /// </summary>
        /// <returns></returns>
        private List<string> GetShicitylist()
        {
            List<string> data = new List<string>();
            var orders = OrderInfoRepository.Model;
            
            foreach (var i in orders.ShipCity)
            {
                 for (int j = 0; j < i.Value.Count(); j++)
                {
                    data.Add(i.Value[j]);
                }
            }
            return data.Distinct().ToList();        
        }

        /// <summary>
        /// Gets the shipcountrylist.
        /// </summary>
        /// <returns></returns>
        private List<string> GetShipcountrylist()
        {
            List<string> data = new List<string>();
            var orders = OrderInfoRepository.Model;
            return orders.ShipCountries;   
        }


        /// <summary>
        /// Clones the zip code.
        /// </summary>
        /// <param name="ordersInfo">The orders info.</param>
        private void CloneZipCode(dynamic ordersInfo)
        {
            OrdersInfo.OrderID = ordersInfo.OrderID;
            OrdersInfo.CustomerID = ordersInfo.CustomerID;
            OrdersInfo.EmployeeID = ordersInfo.EmployeeID;
            OrdersInfo.ShipCity = ordersInfo.ShipCity;
            OrdersInfo.Freight = ordersInfo.Freight;
            OrdersInfo.ShipCountry = ordersInfo.ShipCountry; 
        }

        /// <summary>
        /// Called when [property changed].
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="System.ComponentModel.PropertyChangedEventArgs"/> instance containing the event data.</param>
        void OnPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (this._isInEdit)
                this.Validate();

            this.SaveCommand.CanExecute(null);
        }

        #endregion

        #region Save Command

        /// <summary>
        /// Gets or sets the save command.
        /// </summary>
        /// <value>The save command.</value>
        public DelegateCommand<OrderInfo> SaveCommand
        {
            get;
            set;
        }

        /// <summary>
        /// Determines whether this instance can save the specified arg.
        /// </summary>
        /// <param name="arg">The arg.</param>
        /// <returns>
        /// 	<c>true</c> if this instance can save the specified arg; otherwise, <c>false</c>.
        /// </returns>
        private bool CanSave(object arg)
        {
            if (_isInEdit)
            {
                return this.errorInfo.Count == 0;
            }
            else
            {
                this.Validate();
                bool result = this.errorInfo.Count == 0;
                this.errorInfo.Clear();
                return result;
            }
        }

        /// <summary>
        /// Saves the specified obj.
        /// </summary>
        /// <param name="obj">The obj.</param>
        private void Save(object obj)
        { }
        #endregion
    }
}
