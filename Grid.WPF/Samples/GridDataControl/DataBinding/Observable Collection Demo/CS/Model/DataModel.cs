using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Syncfusion.Windows.Shared;

namespace ObservableCollectionDemo.Model
{
    public class ZipCodeInfo : NotificationObject
    {
        #region Properties
        private string _ZipCode;

        /// <summary>
        /// Gets or sets the zip code.
        /// </summary>
        /// <value>The zip code.</value>
        public string ZipCode
        {
            get
            {
                return _ZipCode;
            }
            set
            {
                _ZipCode = value;
                RaisePropertyChanged("ZipCode");
            }
        }
        private string _Class;

        /// <summary>
        /// Gets or sets the class.
        /// </summary>
        /// <value>The class.</value>
        public string Class
        {
            get
            {
                return _Class;
            }
            set
            {
                _Class = value;
                RaisePropertyChanged("Class");
            }
        }

        private string _StateCode;

        /// <summary>
        /// Gets or sets the state code.
        /// </summary>
        /// <value>The state code.</value>
        public string StateCode
        {
            get
            {
                return _StateCode;
            }
            set
            {
                _StateCode = value;
                RaisePropertyChanged("StateCode");
            }
        }

        private string _StateName;

        /// <summary>
        /// Gets or sets the name of the state.
        /// </summary>
        /// <value>The name of the state.</value>
        public string StateName
        {
            get
            {
                return _StateName;
            }
            set
            {
                _StateName = value;
                RaisePropertyChanged("StateName");
            }
        }

        private string _Latitude;

        /// <summary>
        /// Gets or sets the latitude.
        /// </summary>
        /// <value>The latitude.</value>
        public string Latitude
        {
            get
            {
                return _Latitude;
            }
            set
            {
                _Latitude = value;
                RaisePropertyChanged("Latitude");
            }
        }

        private string _Longitude;

        /// <summary>
        /// Gets or sets the longitude.
        /// </summary>
        /// <value>The longitude.</value>
        public string Longitude
        {
            get
            {
                return _Longitude;
            }
            set
            {
                _Longitude = value;
                RaisePropertyChanged("Longitude");
            }
        }

        private string _City;

        /// <summary>
        /// Gets or sets the city.
        /// </summary>
        /// <value>The city.</value>
        public string City
        {
            get
            {
                return _City;
            }
            set
            {
                _City = value;
                RaisePropertyChanged("City");
            }
        }

        private string _Description;

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        /// <value>The description.</value>
        public string Description
        {
            get
            {
                return _Description;
            }
            set
            {
                _Description = value;
                RaisePropertyChanged("Description");
            }
        }

        private string _StateAbbereviation;

        /// <summary>
        /// Gets or sets the state abbereviation.
        /// </summary>
        /// <value>The state abbereviation.</value>
        public string StateAbbereviation
        {
            get
            {
                return _StateAbbereviation;
            }
            set
            {
                _StateAbbereviation = value;
                RaisePropertyChanged("StateAbbereviation");
            }
        }
        #endregion
    }
}
