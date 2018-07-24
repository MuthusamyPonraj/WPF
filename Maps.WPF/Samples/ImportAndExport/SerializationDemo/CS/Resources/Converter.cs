#region Copyright Syncfusion Inc. 2001 - 2011
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


namespace SerializationDemo
{
    public class SelectedValueToBrushConvertor : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            try
            {
                string color = System.Drawing.ColorTranslator.FromHtml(value.ToString()).Name;
                return color;
            }
            catch (Exception e)
            {
                return e;
            }

        }
        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            try
            {
                string color = value.ToString();
                Type colorType = (typeof(System.Windows.Media.Colors));
                object Colorobj = colorType.InvokeMember(color, BindingFlags.GetProperty, null, null, null);
                return new SolidColorBrush((Color)Colorobj);
            }
            catch (Exception e)
            {
                return e;
            }
        }
    }
    public class SelectedValueToFontStyle : IValueConverter
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
                Type fontType = (typeof(System.Windows.FontStyles));
                object Fontobj = fontType.InvokeMember(font, BindingFlags.GetProperty, null, null, null);
                return Fontobj;
            }
            catch (Exception e)
            {
                return e;
            }
        }
    }

    public class SelectedValueToPathLabelFontStyle : IValueConverter
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
                Type fontType = (typeof(System.Windows.FontStyles));
                object Fontobj = fontType.InvokeMember(font, BindingFlags.GetProperty, null, null, null);
                return Fontobj;
            }
            catch (Exception e)
            {
                return e;
            }
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
            return val;
        }
        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            var val = value.ToString();
            if (val == "OnMiddlePoint")
            {
                return PathLabelPosition.OnMiddlePoint;
            }
            else
            {
                return PathLabelPosition.OnPoint;
            }

        }
    }
}
