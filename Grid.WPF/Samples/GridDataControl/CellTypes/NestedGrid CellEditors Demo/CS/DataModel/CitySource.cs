using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;
using NestedGridCellEditorsDemo.DataModel;
using Syncfusion.Windows.Controls.Grid;

namespace NestedGridCellEditorsDemo
{
    class CitySource : ObservableCollection<Orders>
    {
        IEqualityComparer<Orders> shipCityComparer = new CityComparer();

        public CitySource()
        {
            List<Orders> actualOrders = new List<Orders>();
            if (!LayoutControl.IsInDesignMode)
            {
                Northwind northWind = new Northwind(string.Format(@"Data Source= {0}", LayoutControl.FindFile("Northwind.sdf")));               
                actualOrders.AddRange(northWind.Orders);

                foreach(Orders order in actualOrders.Distinct(shipCityComparer))
                {
                    this.Add(order);
                }
            }
        }
    }

    class CountrySource : ObservableCollection<Orders>
    {
        IEqualityComparer<Orders> shipCountryComparer = new CountryComparer();

        public CountrySource()
        {
            List<Orders> actualOrders = new List<Orders>();
            if (!LayoutControl.IsInDesignMode)
            {
                Northwind northWind = new Northwind(string.Format(@"Data Source= {0}", LayoutControl.FindFile("Northwind.sdf")));
                actualOrders.AddRange(northWind.Orders);

                foreach (Orders order in actualOrders.Distinct(shipCountryComparer))
                {
                    this.Add(order);
                }
            }
        }
    }

    #region Comparer

    class CityComparer : IEqualityComparer<Orders>
    {
        #region IEqualityComparer<Orders> Members

        public bool Equals(Orders x, Orders y)
        {
            return x.ShipCity == y.ShipCity;
        }

        public int GetHashCode(Orders obj)
        {
            return obj.ShipCity.GetHashCode();
        }

        #endregion
    }

    class CountryComparer : IEqualityComparer<Orders>
    {
        #region IEqualityComparer<Orders> Members

        public bool Equals(Orders x, Orders y)
        {
            return x.ShipCountry == y.ShipCountry;
        }

        public int GetHashCode(Orders obj)
        {
            return obj.ShipCountry.GetHashCode();
        }

        #endregion
    }

    #endregion
}

