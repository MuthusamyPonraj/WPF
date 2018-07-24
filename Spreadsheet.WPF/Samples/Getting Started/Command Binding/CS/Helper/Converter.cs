using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Data;
using System.Windows;

namespace CommandBindingDemo.Helpers
{
    public class GridCellBoldToBoolConverter : IValueConverter
    {
        #region IValueConverter Members
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return (FontWeight)value == FontWeights.Bold;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            bool val = (bool)value;
            if (val)
                return FontWeights.Bold;
            else
                return FontWeights.Normal;
        }
        #endregion
    }

    public class GridCellItalicToBoolConverter : IValueConverter
    {
        #region IValueConverter Members
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return (FontStyle)value == FontStyles.Italic;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            bool val = (bool)value;
            if (val)
                return FontStyles.Italic;
            else
                return FontStyles.Normal;
        }
        #endregion
    }

    public class GridCellUnderlineToBoolConverter : IValueConverter
    {
        #region IValueConverter Members
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return (TextDecorationCollection)value == TextDecorations.Underline;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            bool val = (bool)value;
            if (val)
                return TextDecorations.Underline;
            else
                return TextDecorations.Baseline;
        }
        #endregion
    }
}
