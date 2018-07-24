using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Data;
using Syncfusion.Windows.Chart;

namespace Serialization
{
    public class RangeConverter : IValueConverter
    {
        #region IValueConverter Members

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            DoubleRange Range = (DoubleRange)value;
            DoubleRange RangeValue = new DoubleRange(Math.Round(Range.Start, 3), Math.Round(Range.End, 3));
            return RangeValue;

        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return value;
        }

        #endregion
    }
}
