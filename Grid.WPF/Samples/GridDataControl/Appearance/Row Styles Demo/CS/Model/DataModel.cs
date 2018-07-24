using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;
using System.Data.SqlServerCe;
using Syncfusion.Windows.Controls.Grid;
using Syncfusion.Windows.Shared;

namespace RowStylesDemo
{
    public class Suppliers : NotificationObject
    {
        private int _supplierID;
        /// <summary>
        /// Gets or sets the supplier ID.
        /// </summary>
        /// <value>The supplier ID.</value>
        public int SupplierID
        {
            get
            {
                return _supplierID;
            }
            set
            {
                _supplierID = value;
                RaisePropertyChanged("SupplierID");
            }
        }

        private string _companyName;
        /// <summary>
        /// Gets or sets the name of the company.
        /// </summary>
        /// <value>The name of the company.</value>
        public string CompanyName
        {
            get
            {
                return _companyName;
            }
            set
            {
                _companyName = value;
                RaisePropertyChanged("CompanyName");
            }
        }

        private string _contactName;
        /// <summary>
        /// Gets or sets the name of the contact.
        /// </summary>
        /// <value>The name of the contact.</value>
        public string ContactName
        {
            get
            {
                return _contactName;
            }
            set
            {
                _contactName = value;
                RaisePropertyChanged("ContactName");
            }
        }

        private string _contactTitle;
        /// <summary>
        /// Gets or sets the contact title.
        /// </summary>
        /// <value>The contact title.</value>
        public string ContactTitle
        {
            get
            {
                return _contactTitle;
            }
            set
            {
                _contactTitle = value;
                RaisePropertyChanged("ContactTitle");
            }
        }

        private string _address;
        /// <summary>
        /// Gets or sets the address.
        /// </summary>
        /// <value>The address.</value>
        public string Address
        {
            get
            {
                return _address;
            }
            set
            {
                _address = value;
                RaisePropertyChanged("Address");
            }
        }

        private string _city;
        /// <summary>
        /// Gets or sets the city.
        /// </summary>
        /// <value>The city.</value>
        public string City
        {
            get
            {
                return _city;
            }
            set
            {
                _city = value;
                RaisePropertyChanged("City");
            }
        }

        private string _region;
        /// <summary>
        /// Gets or sets the region.
        /// </summary>
        /// <value>The region.</value>
        public string Region
        {
            get
            {
                return _region;
            }
            set
            {
                _region = value;
                RaisePropertyChanged("Region");
            }
        }

        private string _postalCode;
        /// <summary>
        /// Gets or sets the postal code.
        /// </summary>
        /// <value>The postal code.</value>
        public string PostalCode
        {
            get
            {
                return _postalCode;
            }
            set
            {
                _postalCode = value;
                RaisePropertyChanged("PostalCode");
            }
        }

        private string _country;
        /// <summary>
        /// Gets or sets the country.
        /// </summary>
        /// <value>The country.</value>
        public string Country
        {
            get
            {
                return _country;
            }
            set
            {
                _country = value;
                RaisePropertyChanged("Country");
            }
        }

        private string _phone;
        /// <summary>
        /// Gets or sets the phone.
        /// </summary>
        /// <value>The phone.</value>
        public string Phone
        {
            get
            {
                return _phone;
            }
            set
            {
                _phone = value;
                RaisePropertyChanged("Phone");
            }
        }

        private string _fax;
        /// <summary>
        /// Gets or sets the fax.
        /// </summary>
        /// <value>The fax.</value>
        public string Fax
        {
            get
            {
                return _fax;
            }
            set
            {
                _fax = value;
                RaisePropertyChanged("Fax");
            }
        }

    }
}
