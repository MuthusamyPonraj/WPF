using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;
using Syncfusion.Windows.Controls.Grid;
using ComboBoxDropdownCellDemo.Model;

namespace ComboBoxCellEditorsDemo
{
    class ShipRepository : ObservableCollection<object>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ShipRepository"/> class.
        /// </summary>
        public ShipRepository()
        {
            Northwind northWind;
            if (!LayoutControl.IsInDesignMode)
            {
                string connectionString = string.Format(@"Data Source = {0}", LayoutControl.FindFile("Northwind.sdf"));
                northWind = new Northwind(connectionString);
                var order = northWind.Orders.Skip(0).Take(100).ToList();
                foreach (var o in order)
                {
                    if (!this.Contains(o.ShipName))
                        this.Add(o.ShipName);
                }
            }
        }
    }
}