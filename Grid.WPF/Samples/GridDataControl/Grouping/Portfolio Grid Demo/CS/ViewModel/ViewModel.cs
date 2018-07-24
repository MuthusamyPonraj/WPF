using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using Syncfusion.Windows.Controls.Grid;
using System.IO;
using System.Windows.Media;
using Syncfusion.Windows.Shared;

namespace PortfolioGridDemo
{
    class ViewModel 
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ViewModel"/> class.
        /// </summary>
        public ViewModel()
        {
            StockInfo = this.GetStockInfo();
        }

        private List<Holdings> _stockInfo;

        /// <summary>
        /// Gets or sets the stock info.
        /// </summary>
        /// <value>The stock info.</value>
        public List<Holdings> StockInfo
        {
            get
            {
                return _stockInfo;
            }
            set
            {
                _stockInfo = value;
            }
        }

        /// <summary>
        /// Gets the stock info.
        /// </summary>
        /// <returns></returns>
        public List<Holdings> GetStockInfo()
        {
            List<Holdings> stockInfo = new List<Holdings>();
            if (!LayoutControl.IsInDesignMode)
            {
                string connectionString = string.Format(@"Data Source = {0}", LayoutControl.FindFile("PortfolioManagerDB.sdf"));
                PortfolioManagerDB dataContext = new PortfolioManagerDB(connectionString);
                var list = dataContext.Holdings.ToList();
                foreach (var o in list)
                    stockInfo.Add(o);
            }
            return stockInfo;
        }
    }   
}
