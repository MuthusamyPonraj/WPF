using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Syncfusion.Windows.Controls.Grid;
using System.ComponentModel;
using Syncfusion.Windows.Shared;
using System.Collections.ObjectModel;

namespace CustomSummariesDemo
{
    class CustomSummaryViewModel : NotificationObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CustomSummaryViewModel"/> class.
        /// </summary>
        public CustomSummaryViewModel()
        {
            QuotesInfo = this.GetQuotesData();
        }
        public ObservableCollection<Quotes> _QuotesInfo;

        /// <summary>
        /// Gets or sets the quotes info.
        /// </summary>
        /// <value>The quotes info.</value>
        public ObservableCollection<Quotes> QuotesInfo
        { 
            get
            {
                return _QuotesInfo;
            }
            set
            {
                _QuotesInfo = value;
            }
        }

        /// <summary>
        /// Gets the quotes data.
        /// </summary>
        /// <returns></returns>
        public ObservableCollection<Quotes> GetQuotesData()
        {
            ObservableCollection<Quotes> _Quotes = new ObservableCollection<Quotes>();
            if (!LayoutControl.IsInDesignMode)
            {
                string connectionString = string.Format(@"Data Source = {0}", LayoutControl.FindFile("PortfolioManagerDB.sdf"));
                PortfolioManagerDB dataContext = new PortfolioManagerDB(connectionString);
                var list = dataContext.Quotes.ToList();
                foreach (var l in list)
                {
                    _Quotes.Add(l);
                }
            }
            return _Quotes;
        }

        private bool _isGroupExpanded;
        /// <summary>
        /// Gets or sets a value indicating whether this instance is group expanded.
        /// </summary>
        /// <value>
        /// 	<c>true</c> if this instance is group expanded; otherwise, <c>false</c>.
        /// </value>
        public bool IsGroupExpanded
        {
            get { return _isGroupExpanded; }
            set
            {
                _isGroupExpanded = value;
                RaisePropertyChanged("IsGroupExpanded");
            }
        }

        private DelegateCommand<object> _ExpandButton;
        /// <summary>
        /// Gets the expand button.
        /// </summary>
        /// <value>The expand button.</value>
        public DelegateCommand<object> ExpandButton
        {
            get
            {
                if (_ExpandButton == null)
                    _ExpandButton = new DelegateCommand<object>(Expand);

                return _ExpandButton;
            }           
        }

        private DelegateCommand<object> _CollapseButton;
        /// <summary>
        /// Gets the collapse button.
        /// </summary>
        /// <value>The collapse button.</value>
        public DelegateCommand<object> CollapseButton
        {
            get
            {
                if (_CollapseButton == null)
                    _CollapseButton = new DelegateCommand<object>(Collapse);

                return _CollapseButton;
            }
        }

        /// <summary>
        /// Expands the specified args.
        /// </summary>
        /// <param name="Args">The args.</param>
        public void Expand(object Args)
        {
            IsGroupExpanded = true;
        }

        /// <summary>
        /// Collapses the specified args.
        /// </summary>
        /// <param name="Args">The args.</param>
        public void Collapse(object Args)
        {
            IsGroupExpanded = false;
        }
        
    }
}
