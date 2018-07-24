using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;
using System.ComponentModel;
using Syncfusion.Windows.Controls.Grid;
using System.Windows.Media;
using System.Windows.Data;

namespace TablePropertiesDemo
{
    class ViewModel:INotifyPropertyChanged
    {
        
        Order data;
        public ViewModel()
        {
           
            data=  new Order();
            GDCSource = data;
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

        public void OnPropertyChanged(string propertyName)
        {
            var handler = PropertyChanged;
            if (handler != null)
            {
                 var e = new PropertyChangedEventArgs(propertyName);
                handler(this, e);
            }

        }
        public event PropertyChangedEventHandler PropertyChanged;
    }
    public class ColorToBrushConverter : IValueConverter
    {
        #region IValueConverter Members
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            Color color = (Color)value;
            return new SolidColorBrush(color);
        }
        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return null;
        }
        #endregion
    }
}
