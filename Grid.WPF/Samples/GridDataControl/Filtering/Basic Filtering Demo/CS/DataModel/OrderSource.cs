using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;
using Syncfusion.Windows.Controls.Grid;

namespace BasicFilteringDemo
{
    partial class OrderSource : ObservableCollection<BasicFilteringDemo.DataModel.OrderDetails>
    {
        Northwind northWind;

        /// <summary>
        /// Initializes a new instance of the <see cref="OrderSource"/> class.
        /// </summary>
        public OrderSource()
        {
            if (!LayoutControl.IsInDesignMode)
            {
                northWind = new Northwind(string.Format(@"Data Source= {0}", LayoutControl.FindFile("Northwind.sdf")));
                var ord = northWind.OrderDetails.Select(o => o.Products.EnglishName).Distinct().ToList();
                foreach (string em in ord)
                {
                    this.Add(new BasicFilteringDemo.DataModel.OrderDetails() { ID = em });
                }

            }
        }
    }    
}
