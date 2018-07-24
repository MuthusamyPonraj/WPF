using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;
using ComboBoxCellEditorsDemo;
using Syncfusion.Windows.Controls.Grid;
using ComboBoxDropdownCellDemo.Model;

namespace ComboBoxCellEditorsDemo
{
    class ShipCountryRepository : ObservableCollection<ShipContryData>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ShipCountryRepository"/> class.
        /// </summary>
        public ShipCountryRepository()
        {
            Northwind northWind;
            if (!LayoutControl.IsInDesignMode)
            {
                string connectionString = string.Format(@"Data Source = {0}", LayoutControl.FindFile("Northwind.sdf"));
                northWind = new Northwind(connectionString);
                var order = northWind.Orders.Skip(0).Take(100).ToList();
                foreach (var o in order)
                {
                    var shipcountrydata = new ShipContryData() { Shipcountry = o.ShipCountry, Shipcity = o.ShipCity };
                    if (!this.Contains(shipcountrydata))
                        this.Add(shipcountrydata);
                }
            }
        }
    }
}
