using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using Syncfusion.Windows.Shared;
using ObservableCollectionDemo.Model;
using System.Windows.Input;
using Syncfusion.Windows.Controls.Grid;

namespace ObservableCollectionDemo.ViewModel
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
            if (string.IsNullOrEmpty(this.City))
            {
                this["City"] = this.GetErrorInfo("City");
            }
            else
            {
                this.RemoveError("City");
            }

            if (string.IsNullOrEmpty(this.Class))
            {
                this["Class"] = this.GetErrorInfo("Class");
            }
            else
            {
                this.RemoveError("Class");
            }

            if (string.IsNullOrEmpty(this.Latitude))
            {
                this["Latitude"] = this.GetErrorInfo("Latitude");
            }
            else
            {
                this.RemoveError("Latitude");
            }

            if (string.IsNullOrEmpty(this.Longitude))
            {
                this["Longitude"] = this.GetErrorInfo("Longitude");
            }
            else
            {
                this.RemoveError("Longitude");
            }

            if (string.IsNullOrEmpty(this.StateAbbereviation))
            {
                this["StateAbbereviation"] = this.GetErrorInfo("State Abbereviation");
            }
            else
            {
                this.RemoveError("StateAbbereviation");
            }

            if (string.IsNullOrEmpty(this.StateCode))
            {
                this["StateCode"] = this.GetErrorInfo("StateCode");
            }
            else
            {
                this.RemoveError("StateCode");
            }

            if (string.IsNullOrEmpty(this.StateName))
            {
                this["StateName"] = this.GetErrorInfo("State Name");
            }
            else
            {
                this.RemoveError("StateName");
            }

            if (string.IsNullOrEmpty(this.ZipCode))
            {
                this["ZipCode"] = this.GetErrorInfo("ZipCode");
            }
            else
            {
                this.RemoveError("ZipCode");
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

        ZipCodeInfo _zipInfo = new ZipCodeInfo();

        /// <summary>
        /// Gets or sets the zip info.
        /// </summary>
        /// <value>The zip info.</value>
        public ZipCodeInfo ZipInfo
        {
            get
            {
                return _zipInfo;
            }
            set
            {
                _zipInfo = value;
            }
        }

        /// <summary>
        /// Gets or sets the zip code.
        /// </summary>
        /// <value>The zip code.</value>
        public string ZipCode
        {
            get
            {
                return _zipInfo.ZipCode;
            }
            set
            {
                _zipInfo.ZipCode = value;
                RaisePropertyChanged("ZipCode");
            }
        }

        /// <summary>
        /// Gets or sets the class.
        /// </summary>
        /// <value>The class.</value>
        public string Class
        {
            get
            {
                return _zipInfo.Class;
            }
            set
            {
                _zipInfo.Class = value;
                RaisePropertyChanged("Class");
            }
        }

        /// <summary>
        /// Gets or sets the state code.
        /// </summary>
        /// <value>The state code.</value>
        public string StateCode
        {
            get
            {
                return _zipInfo.StateCode;
            }
            set
            {
                _zipInfo.StateCode = value;
                RaisePropertyChanged("StateCode");
            }
        }

        /// <summary>
        /// Gets or sets the name of the state.
        /// </summary>
        /// <value>The name of the state.</value>
        public string StateName
        {
            get
            {
                return _zipInfo.StateName;
            }
            set
            {
                _zipInfo.StateName = value;
                RaisePropertyChanged("StateName");
            }
        }

        /// <summary>
        /// Gets or sets the latitude.
        /// </summary>
        /// <value>The latitude.</value>
        public string Latitude
        {
            get
            {
                return _zipInfo.Latitude;
            }
            set
            {
                _zipInfo.Latitude = value;
                RaisePropertyChanged("Latitude");
            }
        }

        /// <summary>
        /// Gets or sets the longitude.
        /// </summary>
        /// <value>The longitude.</value>
        public string Longitude
        {
            get
            {
                return _zipInfo.Longitude;
            }
            set
            {
                _zipInfo.Longitude = value;
                RaisePropertyChanged("Longitude");
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
                return _zipInfo.City;
            }
            set
            {
                _zipInfo.City = value;
                RaisePropertyChanged("City");
            }
        }

        /// <summary>
        /// Gets or sets the state abbereviation.
        /// </summary>
        /// <value>The state abbereviation.</value>
        public string StateAbbereviation
        {
            get
            {
                return _zipInfo.StateAbbereviation;
            }
            set
            {
                _zipInfo.StateAbbereviation = value;
                RaisePropertyChanged("StateAbbereviation");
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
        /// <param name="zipCodeInfo">The zip code info.</param>
        /// <param name="isInEdit">if set to <c>true</c> [is in edit].</param>
        public ManipulatorViewModel(ZipCodeInfo zipCodeInfo, bool isInEdit)
        {
            _isInEdit = isInEdit;
            SaveCommand = new DelegateCommand<ZipCodeInfo>(this.Save, this.CanSave);
            SaveButtonContent = isInEdit ? "Save" : "Add";
            CloneZipCode(zipCodeInfo);

            if (_isInEdit)
                Validate();

            this.PropertyChanged += OnPropertyChanged;
        }

        /// <summary>
        /// Clones the zip code.
        /// </summary>
        /// <param name="zipCodeInfo">The zip code info.</param>
        private void CloneZipCode(ZipCodeInfo zipCodeInfo)
        {
            _zipInfo.City = zipCodeInfo.City;
            _zipInfo.Class = zipCodeInfo.Class;
            _zipInfo.Description = zipCodeInfo.Description;
            _zipInfo.Latitude = zipCodeInfo.Latitude;
            _zipInfo.Longitude = zipCodeInfo.Longitude;
            _zipInfo.StateAbbereviation = zipCodeInfo.StateAbbereviation;
            _zipInfo.StateCode = zipCodeInfo.StateCode;
            _zipInfo.StateName = zipCodeInfo.StateName;
            _zipInfo.ZipCode = zipCodeInfo.ZipCode;
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
        public DelegateCommand<ZipCodeInfo> SaveCommand
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
