using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Data;

namespace RadarChart
{
    public class IsClosedConverter : IValueConverter
    {
        #region IValueConverter Members

        public object Convert(object seriesType, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            string type = seriesType as string;
            if (type == "Line" || type=="Area")
            {
                return (bool)true;
            }
            else
                return (bool)false;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotSupportedException();
        }

        #endregion
    }  
}
