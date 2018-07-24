using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Data;

namespace SpreadsheetToPDF.Converter
{
    public class LayoutOptionsConverter : IMultiValueConverter

    {
        public object Convert(object[] values, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            int number = 0;
            foreach (object o in values)
            {
                bool result;
                if (bool.TryParse(o.ToString(), out result))
                {
                    if (result)
                    {
                        switch (number)
                        {
                            case 0:
                                return "NoScaling";
                            case 1:
                                return "FitAllRowsOnOnePage";
                            case 2:
                                return "FitAllColumnsOnOnePage";
                            default:
                                return "FitSheetOnOnePage";
                        }
                    }
                    else
                        number++;
                }
            }
            return null;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
