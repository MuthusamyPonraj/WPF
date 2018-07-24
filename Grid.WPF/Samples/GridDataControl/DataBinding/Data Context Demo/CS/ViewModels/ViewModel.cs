using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using Syncfusion.Windows.Controls.Grid;
using System.Collections.ObjectModel;

namespace DataContextDemo
{
    class ViewModel : INotifyPropertyChanged
    {
        public ViewModel()
        {
            GDCSource = new Order();
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
                string connectionString = string.Format(@"Data Source = {0}", LayoutControl.FindFile("Northwind.sdf"));
                northWind = new Northwind(connectionString);
                var order = northWind.Orders;
                foreach (var o in order)
                {
                    this.Add(o);
                }
            }
        }
    }
}
