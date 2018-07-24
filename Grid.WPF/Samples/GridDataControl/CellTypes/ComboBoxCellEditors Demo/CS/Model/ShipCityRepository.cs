using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;
using Syncfusion.Windows.Controls.Grid;
using ComboBoxCellEditorsDemo;
using ComboBoxDropdownCellDemo.Model;

namespace ComboBoxCellEditorsDemo
{
    class ShipCityRepository : ObservableCollection<ShipDataModel>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ShipCityRepository"/> class.
        /// </summary>
        public ShipCityRepository()
        {
            Northwind northWind;
            if (!LayoutControl.IsInDesignMode)
            {
                string connectionString = string.Format(@"Data Source = {0}", LayoutControl.FindFile("Northwind.sdf"));
                northWind = new Northwind(connectionString);
                var order = northWind.Orders.Skip(0).Take(100).ToList();
                foreach (var o in order)
                {
                    var shipdata = new ShipDataModel() { Shipcity = o.ShipCity, Shipcountry = o.ShipCountry };
                    if (!this.Contains(shipdata))
                        this.Add(shipdata);
                }
            }
        }
    }
}