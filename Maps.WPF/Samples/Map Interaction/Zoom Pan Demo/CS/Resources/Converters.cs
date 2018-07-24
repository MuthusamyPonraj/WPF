namespace ZoomPanDemo
{
    using System;
    using System.Net;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Documents;
    using System.Windows.Ink;
    using System.Windows.Input;
    using System.Windows.Media;
    using System.Windows.Media.Animation;
    using System.Windows.Shapes;
    using System.Windows.Data;
    using Syncfusion.Windows.Controls.Map;
    using System.Reflection;

    public class SelectedIndexToZoomModeCoverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            int index = (int)value;
            switch (index)
            {
                case 0:
                    return ZoomingMode.SingleClick;
                case 1:
                    return ZoomingMode.DoubleClick;
                default:
                    return null;
            }
        }
        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
