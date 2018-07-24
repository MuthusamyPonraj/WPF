using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;
using Syncfusion.Windows.Controls.Grid;
using GridVisualStyleDemo.DataModel;

namespace GridVisualStyleDemo
{
    public class CustomerSource : ObservableCollection<string>
    {
        Northwind northWind;

        /// <summary>
        /// Initializes a new instance of the <see cref="CustomerSource"/> class.
        /// </summary>
        public CustomerSource()
        {
            if (!LayoutControl.IsInDesignMode)
            {
                string connectionString = string.Format(@"Data Source = {0}", LayoutControl.FindFile("Northwind.sdf"));
                northWind = new Northwind(connectionString);
                var order = northWind.Orders;
                foreach (var o in order)
                {
                    if (!this.Contains(o.CustomerID))
                        this.Add(o.CustomerID);
                }
            }
        }
    }
}
