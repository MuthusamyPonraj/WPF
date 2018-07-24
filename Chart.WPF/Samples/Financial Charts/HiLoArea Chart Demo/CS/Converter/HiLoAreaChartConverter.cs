using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Data;
using Syncfusion.Windows.Chart;

namespace HiLoAreaChart
{
    public class MyConverter : IValueConverter
    {
        #region IValueConverter Members

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            ChartSeries ab = (ChartSeries)value;
            object o;
            if (ab.Label == "Tea")
            {
                o = ChartRangeAreaType.GetLowValueInterior(ab);
            }
            else
            {
                o = ChartRangeAreaType.GetHighValueInterior(ab);
            }
            return o;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
