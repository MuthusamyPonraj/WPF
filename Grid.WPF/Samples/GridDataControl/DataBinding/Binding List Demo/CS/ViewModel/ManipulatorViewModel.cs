 using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using Syncfusion.Windows.Shared;
using System.Windows.Input;
using BindingListDemo.Model;
using Syncfusion.Windows.Controls.Grid;

namespace BindingListDemo
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

            if (string.IsNullOrEmpty(this.CompanyName))
            {
                this["CompanyName"] = this.GetErrorInfo("CompanyName");
            }
            else
            {
                this.RemoveError("CompanyName");
            }                                

            if (string.IsNullOrEmpty(this.ContactName))
            {
                this["ContactName"] = this.GetErrorInfo("ContactName");
            }
            else
            {
                this.RemoveError("ContactName");
            }

            if (string.IsNullOrEmpty(this.ContactTitle))
            {
                this["ContactTitle"] = this.GetErrorInfo("ContactTitle");
            }
            else
            {
                this.RemoveError("ContactTitle");
            }

            if (string.IsNullOrEmpty(this.Address))
            {
                this["Address"] = this.GetErrorInfo("Address");
            }
            else
            {
                this.RemoveError("Address");
            }

            if (string.IsNullOrEmpty(this.City))
            {
                this["City"] = this.GetErrorInfo("City");
            }
            else
            {
                this.RemoveError("City");
            }

           
            if (string.IsNullOrEmpty(this.Country))
            {
                this["Country"] = this.GetErrorInfo("Country");
            }
            else
            {
                this.RemoveError("Country");
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

        Customers _CustomerInfo = new Customers();

        /// <summary>
        /// Gets or sets the customer info.
        /// </summary>
        /// <value>The customer info.</value>
        public Customers CustomerInfo
        {
            get{return _CustomerInfo;}
            set{ _CustomerInfo = value;}
        }

        /// <summary>
        /// Gets or sets the customer ID.
        /// </summary>
        /// <value>The customer ID.</value>
        public string CustomerID
        {
            get
            {
                return _CustomerInfo.CustomerID;
            }
            set
            {
                _CustomerInfo.CustomerID = value;
                RaisePropertyChanged("CustomerID");
            }
        }

        /// <summary>
        /// Gets or sets the name of the company.
        /// </summary>
        /// <value>The name of the company.</value>
        public string CompanyName
        {
            get
            {
                return _CustomerInfo.CompanyName;
            }
            set
            {
                _CustomerInfo.CompanyName = value;
                RaisePropertyChanged("CompanyName");
            }
        }

        /// <summary>
        /// Gets or sets the name of the contact.
        /// </summary>
        /// <value>The name of the contact.</value>
        public string ContactName
        {
            get
            {
                return _CustomerInfo.ContactName;
            }
            set
            {
                _CustomerInfo.ContactName = value;
                RaisePropertyChanged("ContactName");
            }
        }

        /// <summary>
        /// Gets or sets the contact title.
        /// </summary>
        /// <value>The contact title.</value>
        public string ContactTitle
        {
            get
            {
                return _CustomerInfo.ContactTitle;
            }
            set
            {
                _CustomerInfo.ContactTitle = value;
                RaisePropertyChanged("ContactTitle");
            }
        }

        /// <summary>
        /// Gets or sets the address.
        /// </summary>
        /// <value>The address.</value>
        public string Address
        {
            get
            {
                return _CustomerInfo.Address;
            }
            set
            {
                _CustomerInfo.Address = value;
                RaisePropertyChanged("Address");
            }
        }

        /// <summary>
        /// Gets or sets the city.
        /// </summary>
        /// <value>The city.</value>
        public string City
        {
            get
            {
                return _CustomerInfo.City;
            }
            set
            {
                _CustomerInfo.City = value;
                RaisePropertyChanged("City");
            }
        }

        /// <summary>
        /// Gets or sets the region.
        /// </summary>
        /// <value>The region.</value>
        public string Region
        {
            get
            {
                return _CustomerInfo.Region;
            }
            set
            {
                _CustomerInfo.Region = value;
                RaisePropertyChanged("Region");
            }
        }

        /// <summary>
        /// Gets or sets the country.
        /// </summary>
        /// <value>The country.</value>
        public string Country
        {
            get
            {
                return _CustomerInfo.Country;
            }
            set
            {
                _CustomerInfo.Country = value;
                RaisePropertyChanged("Country");
            }
        }   

        /// <summary>
        /// Gets or sets the content of the save button.
        /// </summary>
        /// <value>The content of the save button.</value>
        public string SaveButtonContent
        { get; set; }

        #endregion

        #region Constructor & Methods

        private bool _isInEdit;

        /// <summary>
        /// Initializes a new instance of the <see cref="ManipulatorViewModel"/> class.
        /// </summary>
        /// <param name="customers">The customers.</param>
        /// <param name="isInEdit">if set to <c>true</c> [is in edit].</param>
        public ManipulatorViewModel(Customers customers, bool isInEdit)
        {
            this.CountryCollection = this.GetCountryData();
            this.CityCollection = this.GetCityData();
            _isInEdit = isInEdit;
            SaveCommand = new DelegateCommand<Customers>(this.Save, this.CanSave);
            SaveButtonContent = isInEdit ? "Save" : "Add";
            CloneCustomers(customers);
           
            if (_isInEdit)
                Validate();

            this.PropertyChanged += OnPropertyChanged;
        }

        private List<string> cityCollection;

        /// <summary>
        /// Gets or sets the city collection.
        /// </summary>
        /// <value>The city collection.</value>
        public List<string> CityCollection
        {
            get { return cityCollection; }
            set { cityCollection = value; }
        }

        private List<string> countryCollection;

        /// <summary>
        /// Gets or sets the country collection.
        /// </summary>
        /// <value>The country collection.</value>
        public List<string> CountryCollection
        {
            get{return countryCollection;}
            set { countryCollection = value; }
        }

        /// <summary>
        /// Gets the city data.
        /// </summary>
        /// <returns></returns>
        private List<string> GetCityData()
        {
            List<string> data = new List<string>();
            Northwind northWind;
            if (!LayoutControl.IsInDesignMode)
            {
                string connectionString = string.Format(@"Data Source = {0}", LayoutControl.FindFile("Northwind.sdf"));
                northWind = new Northwind(connectionString);
                var customer = northWind.Customers.Skip(0).Take(50).ToList();
                foreach (var city in customer)
                {
                    data.Add(city.City);
                }

            }
            return data.Distinct().ToList();
        }

        /// <summary>
        /// Gets the country data.
        /// </summary>
        /// <returns></returns>
        private List<string> GetCountryData()
        {
            List<string> data = new List<string>();
            Northwind northWind;
            if (!LayoutControl.IsInDesignMode)
            {
                string connectionString = string.Format(@"Data Source = {0}", LayoutControl.FindFile("Northwind.sdf"));
                northWind = new Northwind(connectionString);
                var customer = northWind.Customers.Skip(0).Take(50).ToList();
                foreach (var city in customer)
                {
                    data.Add(city.Country);
                }
            }
            return data.Distinct().ToList();
        }


        /// <summary>
        /// Clones the customers.
        /// </summary>
        /// <param name="customers">The customers.</param>
        private void CloneCustomers(Customers customers)
        {
            _CustomerInfo.CustomerID = customers.City;
            _CustomerInfo.CompanyName = customers.CompanyName;
            _CustomerInfo.ContactName = customers.ContactName;
            _CustomerInfo.ContactTitle = customers.ContactTitle;
            _CustomerInfo.Address = customers.Address;
            _CustomerInfo.City = customers.City;
            _CustomerInfo.Region = customers.Region;
            _CustomerInfo.Country = customers.Country;          
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
        public ICommand SaveCommand
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
        {}

        #endregion
    }
}
