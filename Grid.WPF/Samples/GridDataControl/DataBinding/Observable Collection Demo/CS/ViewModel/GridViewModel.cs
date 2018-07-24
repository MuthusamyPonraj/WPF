using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ObservableCollectionDemo.Model;
using System.Windows.Input;
using Syncfusion.Windows.Shared;

namespace ObservableCollectionDemo.ViewModel
{
    class GridViewModel: ZipCodeRepository
    {
        #region Properties
        
        private readonly DelegateCommand<ZipCodeInfo> _addZipCode;
        private readonly DelegateCommand<ZipCodeInfo> _editZipCode;
        private readonly DelegateCommand<ZipCodeInfo> _deleteZipCode;
        private ZipCodeInfo _selectedZipCode;

        /// <summary>
        /// Gets or sets the selected zip code.
        /// </summary>
        /// <value>The selected zip code.</value>
        public ZipCodeInfo SelectedZipCode
        {
            get { return _selectedZipCode; }
            set { _selectedZipCode = value; }
        }

        /// <summary>
        /// Gets the add zip code.
        /// </summary>
        /// <value>The add zip code.</value>
        public DelegateCommand<ZipCodeInfo> AddZipCode
        {
            get { return _addZipCode; }
        }

        /// <summary>
        /// Gets the edit zip code.
        /// </summary>
        /// <value>The edit zip code.</value>
        public DelegateCommand<ZipCodeInfo> EditZipCode
        {
            get { return _editZipCode; }
        }

        /// <summary>
        /// Gets the delete zip code.
        /// </summary>
        /// <value>The delete zip code.</value>
        public DelegateCommand<ZipCodeInfo> DeleteZipCode
        {
            get { return _deleteZipCode; }
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="GridViewModel"/> class.
        /// </summary>
        public GridViewModel()
        {
            _addZipCode = new DelegateCommand<ZipCodeInfo>(AddZipCodeHandler, CanAddZipCode);
            _editZipCode = new DelegateCommand<ZipCodeInfo>(UpdateZipCodeHandler, CanUpdateZipCode);
            _deleteZipCode = new DelegateCommand<ZipCodeInfo>(DeleteZipCodeHandler,CanDeleteZipCode);
        }

        #endregion

        #region Command Handler

        /// <summary>
        /// Determines whether this instance [can add zip code] the specified new zip code.
        /// </summary>
        /// <param name="newZipCode">The new zip code.</param>
        /// <returns>
        /// 	<c>true</c> if this instance [can add zip code] the specified new zip code; otherwise, <c>false</c>.
        /// </returns>
        bool CanAddZipCode(ZipCodeInfo newZipCode)
        {
            return true;
        }

        /// <summary>
        /// Adds the zip code handler.
        /// </summary>
        /// <param name="newZipCode">The new zip code.</param>
        public void AddZipCodeHandler(ZipCodeInfo newZipCode)
        {
            if (newZipCode == null)
            {
                return;
            }

            this.ZipCodes.Add(newZipCode);
        }

        /// <summary>
        /// Determines whether this instance [can update zip code] the specified new zip code.
        /// </summary>
        /// <param name="newZipCode">The new zip code.</param>
        /// <returns>
        /// 	<c>true</c> if this instance [can update zip code] the specified new zip code; otherwise, <c>false</c>.
        /// </returns>
        bool CanUpdateZipCode(ZipCodeInfo newZipCode)
        {
            return this.SelectedZipCode != null;
        }

        /// <summary>
        /// Determines whether this instance [can delete zip code] the specified new zip code.
        /// </summary>
        /// <param name="newZipCode">The new zip code.</param>
        /// <returns>
        /// 	<c>true</c> if this instance [can delete zip code] the specified new zip code; otherwise, <c>false</c>.
        /// </returns>
        bool CanDeleteZipCode(ZipCodeInfo newZipCode)
        {
            return this.SelectedZipCode != null;
        }

        /// <summary>
        /// Updates the zip code handler.
        /// </summary>
        /// <param name="newZipCode">The new zip code.</param>
        public void UpdateZipCodeHandler(ZipCodeInfo newZipCode)
        {
            if (newZipCode == null)
                return;

            _selectedZipCode.City = newZipCode.City;
            _selectedZipCode.Class = newZipCode.Class;
            _selectedZipCode.Description = newZipCode.Description;
            _selectedZipCode.Latitude = newZipCode.Latitude;
            _selectedZipCode.Longitude = newZipCode.Longitude;
            _selectedZipCode.StateAbbereviation = newZipCode.StateAbbereviation;
            _selectedZipCode.StateCode = newZipCode.StateCode;
            _selectedZipCode.StateName = newZipCode.StateName;
            _selectedZipCode.ZipCode = newZipCode.ZipCode;
        }

        /// <summary>
        /// Deletes the zip code handler.
        /// </summary>
        /// <param name="zipCode">The zip code.</param>
        public void DeleteZipCodeHandler(ZipCodeInfo zipCode)
        {
            if (zipCode == null)
                return;

            this.ZipCodes.Remove(zipCode);
        }

        #endregion
    }
}
