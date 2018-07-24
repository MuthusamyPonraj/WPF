using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;
using Syncfusion.Windows.Controls.Grid;

namespace BasicFilteringDemo
{
    public class CategorySource : ObservableCollection<string>
    {
        Northwind northWind;

        /// <summary>
        /// Initializes a new instance of the <see cref="CategorySource"/> class.
        /// </summary>
        public CategorySource()
        {
            if (!LayoutControl.IsInDesignMode)
            {
                string connectionString = string.Format(@"Data Source = {0}", LayoutControl.FindFile("Northwind.sdf"));
                northWind = new Northwind(connectionString);
                var ship = northWind.Products.Select(o => o.CategoryID).Distinct().ToList();
                foreach (int s in ship)
                {
                    this.Add(s.ToString());
                }
            }
        }
    }
}
