#region
// Copyright Syncfusion Inc. 2001 - 2011. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion

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


namespace Path_Support_Demo_2010
{
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
                    index = 0;
                    break;
                case "italic":
                    index = 1;
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
                case 0:
                    style = FontStyles.Normal;
                    break;
                case 1:
                    style = FontStyles.Italic;
                    break;
            }
            return style;
        }
    }

    public class SelectedIndexToPathLabelFontStyle : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            var font = value.ToString().ToLower();
            int index = 0;
            switch (font)
            {
                case "normal":
                    index = 0;
                    break;
                case "italic":
                    index = 1;
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
                case 0:
                    style = FontStyles.Normal;
                    break;
                case 1:
                    style = FontStyles.Italic;
                    break;
            }
            return style;
        }
    }

    public class SelectedValueToTextWarp : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            string val = value.ToString();
            return val;
        }
        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            try
            {
                string font = value.ToString();
                Type warpType = (typeof(System.Windows.TextWrapping));
                object Warpobj = warpType.InvokeMember(font, BindingFlags.GetProperty, null, null, null);
                return Warpobj.ToString();
            }
            catch (Exception e)
            {
                return e;
            }
        }
    }
    public class SelectedValueToLabelPoint : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            var val = (PathLabelPosition)value;
            if (val.ToString() == "OnMiddlePoint")
            {
                return 0;
            }
            else
            {
                return 1;
            }

        }
        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            var val = value.ToString();
            if (val == "0")
            {
                return PathLabelPosition.OnMiddlePoint;
            }
            else
            {
                return PathLabelPosition.OnPoint;
            }

        }
    }

    public class EnableDisableCerter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
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
            throw new NotImplementedException();
        }
    }
    
}
