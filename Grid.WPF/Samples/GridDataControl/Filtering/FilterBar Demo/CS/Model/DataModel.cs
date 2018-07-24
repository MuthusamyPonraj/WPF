using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;
using System.Data.SqlServerCe;
using Syncfusion.Windows.Controls.Grid;
using Syncfusion.Windows.Shared;

namespace FilterBarDemo
{
    public class ZipCodes:NotificationObject
    {
        private string _zipCode;

        /// <summary>
        /// Gets or sets the zip code.
        /// </summary>
        /// <value>The zip code.</value>
        public string ZipCode
        {
            get
            {
                return _zipCode;
            }
            set
            {
                _zipCode = value;
                RaisePropertyChanged("ZipCode");
            }
        }

        private string _class;

        /// <summary>
        /// Gets or sets the class.
        /// </summary>
        /// <value>The class.</value>
        public string Class
        {
            get
            {
                return _class;
            }
            set
            {
                _class = value;
                RaisePropertyChanged("Class");
            }
        }

        private int _stateCode;

        /// <summary>
        /// Gets or sets the state code.
        /// </summary>
        /// <value>The state code.</value>
        public int StateCode
        {
            get
            {
                return _stateCode;
            }
            set
            {
                _stateCode = value;
                RaisePropertyChanged("StateCode");
            }
        }

        private string _stateName;

        /// <summary>
        /// Gets or sets the name of the state.
        /// </summary>
        /// <value>The name of the state.</value>
        public string StateName
        {
            get
            {
                return _stateName;
            }
            set
            {
                _stateName = value;
                RaisePropertyChanged("StateName");
            }
        }

        private string _latitude;

        /// <summary>
        /// Gets or sets the latitude.
        /// </summary>
        /// <value>The latitude.</value>
        public string Latitude
        {
            get
            {
                return _latitude;
            }
            set
            {
                _latitude = value;
                RaisePropertyChanged("Latitude");
            }
        }

        private string _longitude;

        /// <summary>
        /// Gets or sets the longitude.
        /// </summary>
        /// <value>The longitude.</value>
        public string Longitude
        {
            get
            {
                return _longitude;
            }
            set
            {
                _longitude = value;
                RaisePropertyChanged("Longitude");
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

        private string _description;

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        /// <value>The description.</value>
        public string Description
        {
            get
            {
                return _description;
            }
            set
            {
                _description = value;
                RaisePropertyChanged("Description");
            }
        }

        private string _stateAbbereviation;

        /// <summary>
        /// Gets or sets the state abbereviation.
        /// </summary>
        /// <value>The state abbereviation.</value>
        public string StateAbbereviation
        {
            get
            {
                return _stateAbbereviation;
            }
            set
            {
                _stateAbbereviation = value;
                RaisePropertyChanged("StateAbbereviation");
            }
        }
    }
}


