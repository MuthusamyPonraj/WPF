using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Collections.ObjectModel;
using Syncfusion.Windows.Controls.Grid;
using System.Windows.Controls;
using Syncfusion.Windows.Shared;
using ContextMenuDemo.Model;

namespace ContextMenuDemo
{
    class ViewModel : NotificationObject
    {
        #region Constructor

        public ViewModel()
        {
            this.GetProducts();
            this.DefaultChecked = true;
            this.Groupexpand = false;
            this._AddNewRowClick = new DelegateCommand<object>(HeadMenuClicked);
            this._Expandgroup = new DelegateCommand<object>(ExpandGroups);
            this._CollapseGroup = new DelegateCommand<object>(CollapseGroups);
        }

        #endregion

        #region Public properties to check the radio buttons are checked or not

        public bool DefaultChecked { get; set; }
        public bool CustomChecked { get; set; }
        public bool DefaultCustomChecked { get; set; }

        #endregion

        #region Commands for ContextMenu Click
        /// <summary>
        /// Command exposed to bind with the Radio button to get the Radio button checked state
        /// </summary>
        private DelegateCommand<object> _ContextMenuCommand;
        public DelegateCommand<object> ContextMenuCommand
        {
            get
            {
                return _ContextMenuCommand = new DelegateCommand<object>(ContextMenuChanged);
            }
        }

        /// <summary>
        /// method to process the Radio button click
        /// </summary>
        /// <param name="param"></param>
        private void ContextMenuChanged(object param)
        {
            if (param.ToString() == "Default")
                Contextmenuoptions = "Default";
            else if (param.ToString() == "Custom")
                Contextmenuoptions = "Custom";
            else if (param.ToString() == "CustomWithDefault")
                Contextmenuoptions = "CustomWithDefault";
        }
        #endregion

        #region Public Properties

        private ObservableCollection<Products> _ProductDetails;
        /// <summary>
        /// Gets or sets the product details.
        /// </summary>
        /// <value>The product details.</value>
        public ObservableCollection<Products> ProductDetails
        {
            get
            {
                return _ProductDetails;
            }
            set
            {
                _ProductDetails = value;
                RaisePropertyChanged("GDCSource");
            }
        }

        private bool _ShowAddNewRow;
        /// <summary>
        /// Gets or sets a value indicating whether [show add new row].
        /// </summary>
        /// <value><c>true</c> if [show add new row]; otherwise, <c>false</c>.</value>
        public bool ShowAddNewRow
        {
            get
            {
                return _ShowAddNewRow;
            }
            set
            {
                _ShowAddNewRow = value;
                RaisePropertyChanged("ShowAddNewRow");
            }
        }

        private bool _Groupexpand;
        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="ViewModel"/> is groupexpand.
        /// </summary>
        /// <value><c>true</c> if groupexpand; otherwise, <c>false</c>.</value>
        public bool Groupexpand
        {
            get
            {
                return _Groupexpand;
            }
            set
            {
                _Groupexpand = value;
                RaisePropertyChanged("Groupexpand");
            }
        }

        /// <summary>
        /// Property to bind the Grid's ContextmenuOptions whenever the Radiobutton options are changed this propety will automatically change the grid's option.
        /// </summary>
        private string _Contextmenuoptions;

        public string Contextmenuoptions
        {
            get
            {
                return _Contextmenuoptions;
            }
            set
            {
                _Contextmenuoptions = value;
                RaisePropertyChanged("Contextmenuoptions");
            }
        }

        #endregion

        #region GridDataControl Commands

        private DelegateCommand<object> _AddNewRowClick;

        /// <summary>
        /// Gets the add new row click.
        /// </summary>
        /// <value>The add new row click.</value>
        public DelegateCommand<object> AddNewRowClick
        {
            get { return _AddNewRowClick; }
        }

        private DelegateCommand<object> _Expandgroup;

        /// <summary>
        /// Gets the expandgroup.
        /// </summary>
        /// <value>The expandgroup.</value>
        public DelegateCommand<object> Expandgroup
        {
            get { return _Expandgroup; }
        }

        private DelegateCommand<object> _CollapseGroup;

        /// <summary>
        /// Gets the collapse group.
        /// </summary>
        /// <value>The collapse group.</value>
        public DelegateCommand<object> CollapseGroup
        {
            get { return _CollapseGroup; }
        }

        #endregion

        #region ContextMenu Click Methods

        /// <summary>
        /// Collapses the groups.
        /// </summary>
        /// <param name="param">The param.</param>
        void CollapseGroups(object param)
        {
            Groupexpand = false;
        }

        /// <summary>
        /// Expands the groups.
        /// </summary>
        /// <param name="param">The param.</param>
        void ExpandGroups(object param)
        {
            Groupexpand = true;
        }

        /// <summary>
        /// Heads the menu clicked.
        /// </summary>
        /// <param name="param">The param.</param>
        void HeadMenuClicked(object param)
        {
            this.ShowAddNewRow = !this.ShowAddNewRow;
        }

        #endregion

        #region Method to retrieve data from database

        /// <summary>
        /// Gets the products.
        /// </summary>
        void GetProducts()
        {
            ProductDetails = new ObservableCollection<Products>();
            Northwind northWind;
            if (!LayoutControl.IsInDesignMode)
            {
                northWind = new Northwind(string.Format(@"Data Source= {0}", LayoutControl.FindFile("Northwind.sdf")));
                var ords = northWind.Products.Take(50);
                foreach (var em in ords)
                {

                    this.ProductDetails.Add(em);
                }
            }
        }

        #endregion
    }
}
