using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;
using System.Data.SqlServerCe;
using Syncfusion.Windows.Shared;

namespace ListDemo
{  

    public class ProductDetails:NotificationObject
    {
        private int _productID;

        /// <summary>
        /// Gets or sets the product ID.
        /// </summary>
        /// <value>The product ID.</value>
        public int ProductID
        {
            get
            {
                return _productID;
            }
            set
            {
                _productID = value;
                RaisePropertyChanged("ProductID");
            }
        }

        public string _name;

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>The name.</value>
        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
                RaisePropertyChanged("Name");
            }
        }

        private string _productNumber;

        /// <summary>
        /// Gets or sets the product number.
        /// </summary>
        /// <value>The product number.</value>
        public string ProductNumber
        {
            get
            {
                return _productNumber;
            }
            set
            {
                _productNumber = value;
                RaisePropertyChanged("ProductNumber");
            }
        }

        private bool _makeFlag;

        /// <summary>
        /// Gets or sets a value indicating whether [make flag].
        /// </summary>
        /// <value><c>true</c> if [make flag]; otherwise, <c>false</c>.</value>
        public bool MakeFlag
        {
            get
            {
                return _makeFlag;
            }
            set
            {
                _makeFlag = value;
                RaisePropertyChanged("MakeFlag");
            }
        }

        private bool _finishedGoodsFlag;

        /// <summary>
        /// Gets or sets a value indicating whether [finished goods flag].
        /// </summary>
        /// <value><c>true</c> if [finished goods flag]; otherwise, <c>false</c>.</value>
        public bool FinishedGoodsFlag
        {
            get
            {
                return _finishedGoodsFlag;
            }
            set
            {
                _finishedGoodsFlag = value;
                RaisePropertyChanged("FinishedGoodsFlag");
            }
        }

        private string _color;

        /// <summary>
        /// Gets or sets the color.
        /// </summary>
        /// <value>The color.</value>
        public string Color
        {
            get
            {
                return _color;
            }
            set
            {
                _color = value;
                RaisePropertyChanged("Color");
            }
        }

        private int _safetyStockLevel;

        /// <summary>
        /// Gets or sets the safety stock level.
        /// </summary>
        /// <value>The safety stock level.</value>
        public int SafetyStockLevel
        {
            get
            {
                return _safetyStockLevel;
            }
            set
            {
                _safetyStockLevel = value;
                RaisePropertyChanged("SafetyStockLevel");
            }
        }

        public int _reorderPoint;

        /// <summary>
        /// Gets or sets the reorder point.
        /// </summary>
        /// <value>The reorder point.</value>
        public int ReorderPoint
        {
            get
            {
                return _reorderPoint;
            }
            set
            {
                _reorderPoint = value;
                RaisePropertyChanged("ReorderPoint");
            }
        }

        private double _standardCost;

        /// <summary>
        /// Gets or sets the standard cost.
        /// </summary>
        /// <value>The standard cost.</value>
        public double StandardCost
        {
            get
            {
                return _standardCost;
            }
            set
            {
                _standardCost = value;
                RaisePropertyChanged("StandardCost");
            }
        }

        private double _listPrice;

        /// <summary>
        /// Gets or sets the list price.
        /// </summary>
        /// <value>The list price.</value>
        public double ListPrice
        {
            get
            {
                return _listPrice;
            }
            set
            {
                _listPrice = value;
                RaisePropertyChanged("ListPrice");
            }
        }

        private string _size;

        /// <summary>
        /// Gets or sets the size.
        /// </summary>
        /// <value>The size.</value>
        public string Size
        {
            get
            {
                return _size;
            }
            set
            {
                _size = value;
                RaisePropertyChanged("Size");
            }
        }

        private int _daysToManufacture;

        /// <summary>
        /// Gets or sets the days to manufacture.
        /// </summary>
        /// <value>The days to manufacture.</value>
        public int DaysToManufacture
        {
            get
            {
                return _daysToManufacture;
            }
            set
            {
                _daysToManufacture = value;
                RaisePropertyChanged("DaysToManufacture");
            }
        }

        private DateTime _sellStartDate;

        /// <summary>
        /// Gets or sets the sell start date.
        /// </summary>
        /// <value>The sell start date.</value>
        public DateTime SellStartDate
        {
            get
            {
                return _sellStartDate;
            }
            set
            {
                _sellStartDate = value;
                RaisePropertyChanged("SellStartDate");
            }
        }

        public DateTime _sellEndDate;

        /// <summary>
        /// Gets or sets the sell end date.
        /// </summary>
        /// <value>The sell end date.</value>
        public DateTime SellEndDate
        {
            get
            {
                return _sellEndDate;
            }
            set
            {
                _sellEndDate = value;
                RaisePropertyChanged("SellEndDate");
            }
        }      

    }
}
