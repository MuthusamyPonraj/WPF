 using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using Syncfusion.Windows.Shared;
using System.Windows.Input;
using Syncfusion.Windows.Controls.Grid;
using System.Data;

namespace ListDemo
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

            if ((string.IsNullOrEmpty(this.Name)))
            {
                this["Name"] = this.GetErrorInfo("Name");
            }
            else
            {
                this.RemoveError("Name");
            }                                

            if (string.IsNullOrEmpty(this.ProductNumber))
            {
                this["ProductNumber"] = this.GetErrorInfo("ProductNumber");
            }
            else
            {
                this.RemoveError("ProductNumber");
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

        ProductDetails _ProductInfo = new ProductDetails();


        /// <summary>
        /// Gets or sets the Product info.
        /// </summary>
        /// <value>The Product info.</value>
        public ProductDetails ProductInfo
        {
            get
            {
                return _ProductInfo;
            }
            set
            {
                _ProductInfo = value;
            }
        }

        /// <summary>
        /// Gets or sets the product ID.
        /// </summary>
        /// <value>The product ID.</value>
        public int ProductID
        {
            get
            {
                return ProductInfo.ProductID;
            }
            set
            {
                ProductInfo.ProductID = value;
                RaisePropertyChanged("ProductID");
            }
        }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>The name.</value>
        public string Name
        {
            get
            {
                return ProductInfo.Name;
            }
            set
            {
                ProductInfo.Name = value;
                RaisePropertyChanged("Name");
            }
        }

        /// <summary>
        /// Gets or sets the product number.
        /// </summary>
        /// <value>The product number.</value>
        public string ProductNumber
        {
            get
            {
                return ProductInfo.ProductNumber;
            }
            set
            {
                ProductInfo.ProductNumber = value;
                RaisePropertyChanged("ProductNumber");
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether [finished goods flag].
        /// </summary>
        /// <value><c>true</c> if [finished goods flag]; otherwise, <c>false</c>.</value>
        public bool FinishedGoodsFlag
        {
            get
            {
                return ProductInfo.FinishedGoodsFlag;
            }
            set
            {
                ProductInfo.FinishedGoodsFlag = value;
                RaisePropertyChanged("FinishedGoodsFlag");
            }
        }

        /// <summary>
        /// Gets or sets the safety stock level.
        /// </summary>
        /// <value>The safety stock level.</value>
        public int SafetyStockLevel
        {
            get
            {
                return ProductInfo.SafetyStockLevel;
            }
            set
            {
                ProductInfo.SafetyStockLevel = value;
                RaisePropertyChanged("SafetyStockLevel");
            }
        }

        /// <summary>
        /// Gets or sets the reorder point.
        /// </summary>
        /// <value>The reorder point.</value>
        public int ReorderPoint
        {
            get
            {
                return ProductInfo.ReorderPoint;
            }
            set
            {
                ProductInfo.ReorderPoint = value;
                RaisePropertyChanged("ReorderPoint");
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether [make flag].
        /// </summary>
        /// <value><c>true</c> if [make flag]; otherwise, <c>false</c>.</value>
        public bool MakeFlag
        {
            get
            {
                return ProductInfo.MakeFlag;
            }
            set
            {
                ProductInfo.MakeFlag = value;
                RaisePropertyChanged("MakeFlag");
            }
        }

        /// <summary>
        /// Gets or sets the days to manufacture.
        /// </summary>
        /// <value>The days to manufacture.</value>
        public int DaysToManufacture
        {
            get
            {
                return ProductInfo.DaysToManufacture;
            }
            set
            {
                ProductInfo.DaysToManufacture = value;
                RaisePropertyChanged("DaysToManufacture");
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
        /// <param name="Product">The customers.</param>
        /// <param name="isInEdit">if set to <c>true</c> [is in edit].</param>
        public ManipulatorViewModel(ProductDetails Product, bool isInEdit)
        {
             
            _isInEdit = isInEdit;
            SaveCommand = new DelegateCommand<ProductDetails>(this.Save, this.CanSave);
            SaveButtonContent = isInEdit ? "Save" : "Add";
            if(isInEdit)
            CloneCustomers(Product);
           
            if (_isInEdit)
                Validate();

            this.PropertyChanged += OnPropertyChanged;
        }

        /// <summary>
        /// Clones the customers.
        /// </summary>
        /// <param name="product">The product.</param>
        private void CloneCustomers(ProductDetails product)
        {
            ProductID = product.ProductID;
            Name = product.Name;
            ProductNumber = product.ProductNumber;
            SafetyStockLevel = product.SafetyStockLevel;
            ReorderPoint = product.ReorderPoint;
            DaysToManufacture = product.DaysToManufacture;
            FinishedGoodsFlag = product.FinishedGoodsFlag;                   
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
        public DelegateCommand<ProductDetails> SaveCommand
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
        {
            
        }
        #endregion
    }
}
