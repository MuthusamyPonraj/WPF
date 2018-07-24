namespace SimpleMapsDemo
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

    public class SelectedValueToBrushConvertor : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            try
            {
                string color = value.ToString();
                Type colorType = (typeof(System.Windows.Media.Colors));
                object Colorobj = colorType.InvokeMember(color, BindingFlags.GetProperty, null, null, null);
                return new SolidColorBrush((Color)Colorobj);
            }
            catch(Exception e)
            {
                return e;
            }
            
        }
        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
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
    public class IndexToNavigationControlPositionConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            int index = (int)value;
            switch (index)
            {
                case 0:
                    return NavigationControlPositions.Top;
                case 1:
                    return NavigationControlPositions.Right;
                case 2:
                    return NavigationControlPositions.Bottom;
                case 3:
                    return NavigationControlPositions.Left;
                default:
                    return null;
            }
        }
        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
    public class SelectedValueToStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            int selectedIndex = (int)value;
            switch (selectedIndex)
            {
                case 0:
                    return VisualStyles.Office2007Blue;

                case 1:
                    return VisualStyles.Default;

                case 2:
                    return VisualStyles.Office2007Black;

                case 3:
                    return VisualStyles.Office2007Silver;

                case 4:
                    return VisualStyles.Blend;

                case 5:
                    return VisualStyles.VS2010;

                case 6:
                    return VisualStyles.Office2010Blue;

                case 7:
                    return VisualStyles.Office2010Black;

                case 8:
                    return VisualStyles.Office2010Silver;


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
