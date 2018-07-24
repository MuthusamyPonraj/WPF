namespace Olympics_Venues_Demo
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

    public class SelectedIndexToBrushConvertor : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            var color = (value as SolidColorBrush).Color.ToString();
            int index = 0;
            switch (color)
            {

                case "#FFFFFFFF":
                    index = 0;
                    break;
                case "#FF000000":
                    index = 1;
                    break;
                case "#FF00FFFF":
                    index = 2;
                    break;
                case "#FF0000FF":
                    index = 3;
                    break;
                case "#FFFF0000":
                    index = 4;
                    break;
                case "#00FFFFFF":
                    index=5;
                    break;
            }
            return index;

        }
        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            var index = (int)value;
            var color = new SolidColorBrush(Colors.Black);
            switch (index)
            {
                case 0:
                    color = new SolidColorBrush(Colors.White);
                    break;
                case 1:
                    color = new SolidColorBrush(Colors.Black);
                    break;
                case 2:
                    color = new SolidColorBrush(Colors.Cyan);
                    break;
                case 3:
                    color = new SolidColorBrush(Colors.Blue);
                    break;
                case 4:
                    color = new SolidColorBrush(Colors.Red);
                    break;
                case 5:
                    color = new SolidColorBrush(Colors.Transparent);
                    break;
            }
            return color;
        }
    }

    public class SelectedValueToFontStyle : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            var font = value.ToString().ToLower();
            int index = 0;
            switch (font)
            {
                case "normal":
                    index = 1;
                    break;
                case "italic":
                    index = 0;
                    break;
            }
            return index;
        }
        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            var index = (int)value;
            FontStyle style = FontStyles.Normal;
            switch (index)
            {
                case 1:
                    style = FontStyles.Normal;
                    break;
                case 0:
                    style = FontStyles.Italic;
                    break;
            }
            return style;
        }
    }

    public class VisibilityConverter : IValueConverter
    {
        object symbol;
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            symbol = value;
            if (value != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return symbol;
        }
    }
}
