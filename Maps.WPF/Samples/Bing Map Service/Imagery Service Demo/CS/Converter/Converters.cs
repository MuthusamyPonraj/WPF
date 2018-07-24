namespace Imagery_Service_Demo
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
    using Syncfusion.Maps.Imagery.Common;

    public class SelectedIndexToMapStyleConverter: IValueConverter
    {

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            var index = 0;
            var mapstyle =(MapStyle)value;
            switch (mapstyle)
            {
                case MapStyle.Aerial:
                   index=0;
                    break;
                case MapStyle.AerialWithLabels:
                    index = 1;
                    break;
                case MapStyle.Road:
                    index = 2;
                    break;
            }
            return index;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            var index = (int)value;
            var mapstyle = MapStyle.Aerial;
            switch (index)
            {
                case 0:
                    mapstyle = MapStyle.Aerial;
                    break;
                case 1:
                    mapstyle = MapStyle.AerialWithLabels; ;
                    break;
                case 2:
                    mapstyle = MapStyle.Road;
                    break;
            }
            return mapstyle;
        }
    }
}
