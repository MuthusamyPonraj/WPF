using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;
using Syncfusion.Windows.Controls.Grid;
using System.ComponentModel;

namespace ColumnBasedSizingDemo
{
    class ViewModel : INotifyPropertyChanged
    {
        public ViewModel()
        {
            GDCSource = new Order();
            GridLengthUnit = new DataGridLengthUnitTypes();
        }

        private Order gdcsource;
        public Order GDCSource
        {
            get
            {
                return gdcsource;
            }
            set
            {
                gdcsource = value;
                OnPropertyChanged("GDCSource");
            }
        }

        private DataGridLengthUnitTypes gridLengthUnit;
        public DataGridLengthUnitTypes GridLengthUnit
        {
            get
            {
                return gridLengthUnit;
            }
            set
            {
                gridLengthUnit = value;
                OnPropertyChanged("GridLengthUnit");
            }
        }
        #region INotifyPropertyChanged Members

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                var e = new PropertyChangedEventArgs(propertyName);
                handler(this, e);
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        #endregion
    }
    public class Order : ObservableCollection<Orders>
    {
        Northwind northWind;
        public Order()
        {
            if (!LayoutControl.IsInDesignMode)
            {
                string connectionString = LayoutControl.FindFile("Northwind.sdf");
                var nw = new Northwind(connectionString);
                var orders = nw.Orders;
                foreach (var o in orders)
                {
                    this.Add(o);
                }
            }
        }
    }

    public class DataGridLengthUnitTypes : List<GridControlLengthUnitType>
    {
        public DataGridLengthUnitTypes()
        {
            Add(GridControlLengthUnitType.Auto);
            Add(GridControlLengthUnitType.SizeToCells);
            Add(GridControlLengthUnitType.SizeToHeader);
            Add(GridControlLengthUnitType.Star);
            Add(GridControlLengthUnitType.None);
        }
    }  
}
