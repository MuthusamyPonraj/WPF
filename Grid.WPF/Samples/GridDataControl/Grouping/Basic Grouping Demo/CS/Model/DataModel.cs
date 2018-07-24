using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;
using System.Data.SqlServerCe;
using Syncfusion.Windows.Controls.Grid;
using Syncfusion.Windows.Shared;

namespace BasicGroupingDemo
{
    public class Suppliers:NotificationObject
    {
        private string _name;

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
                return _name;
            }
            set
            {
                _name = value;
                RaisePropertyChanged("Name");
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

        private int _reorderPoint;

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
    }
}
