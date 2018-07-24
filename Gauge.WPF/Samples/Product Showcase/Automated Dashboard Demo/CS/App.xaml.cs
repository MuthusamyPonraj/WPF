using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Windows;
using System.Windows.Data;
using System.Globalization;
using Syncfusion.Windows.Gauge;
using Syncfusion.Licensing;
 using System.IO;
 using System.Reflection;
 using System.Text;

namespace CarDashboard_new
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
     public partial class App : Application
    {
        public App()   {   SyncfusionLicenseProvider.RegisterLicense(DemoCommon.FindLicenseKey());   }
    }
    public static class DemoCommon
    {
        /// <summary>
        /// Helper method to find a syncfusion license key from the Common folder
        /// </summary>
        /// <param name="fileName">File name of the syncfusion license key</param>
        /// <returns></returns>
        public static string FindLicenseKey()
        {
            int levelsToCheck = 12;
            string filePath = @"Common\SyncfusionLicense.txt";

            string rootPath = System.IO.Path.GetDirectoryName(Assembly.GetEntryAssembly().CodeBase.Replace(@"file:///", ""));

            for (int n = 0; n < levelsToCheck; n++)
            {
                string fileDataPath = System.IO.Path.Combine(rootPath, filePath);
                if (System.IO.File.Exists(fileDataPath))
                    return File.ReadAllText(fileDataPath, Encoding.UTF8);
                rootPath = Directory.GetParent(rootPath).FullName;
            }
            return string.Empty;
        }
    }

    public class DoubleToStringConverter : IValueConverter
    {
        /// <summary>
        /// Converts Radius into Diameter
        /// </summary>
        /// <param name="value">Value to be converted</param>
        /// <param name="targetType">The type of the binding target property.</param>
        /// <param name="parameter">The converter parameter to use.</param>
        /// <param name="culture">The culture to use in the converter.</param>
        /// <returns>Converted value</returns>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if ((double)value == 0)
                return "0000";
            string str = ((double)value * 1000).ToString();
            if (str.Length > 4 )
            {
                if (str.IndexOf('.') != -1)
                {
                    return str.Substring(0, str.IndexOf('.'));
                }
                return str.Substring(0, 4);
            }
            else
            {
                return str;
            }
        }

        /// <summary>
        /// Empty converter.
        /// </summary>
        /// <param name="value">The value that is produced by the binding target.</param>
        /// <param name="targetType">The type to convert to.</param>
        /// <param name="parameter">The converter parameter to use.</param>
        /// <param name="culture">The culture to use in the converter.</param>
        /// <returns>ConverBack is not possible, hence returns "null"</returns>
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return (double)value / 1000;
        }
    }

    public class DoubleToStatusConverter : IValueConverter
    {
        /// <summary>
        /// Converts Radius into Diameter
        /// </summary>
        /// <param name="value">Value to be converted</param>
        /// <param name="targetType">The type of the binding target property.</param>
        /// <param name="parameter">The converter parameter to use.</param>
        /// <param name="culture">The culture to use in the converter.</param>
        /// <returns>Converted value</returns>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if ((double)value <= 0)
                return "EMPTY";
            else if ((double)value == 20)
                return "FULL";
            else if ((double)value <= 3)
                return "VLOW";
            else if ((double)value <= 7)
                return "LOW";
            else if ((double)value <= 15)
                return "GOOD";
            else if ((double)value <= 20)
                return "VGOOD";
            else
                return "ERROR";
        }

        /// <summary>
        /// Empty converter.
        /// </summary>
        /// <param name="value">The value that is produced by the binding target.</param>
        /// <param name="targetType">The type to convert to.</param>
        /// <param name="parameter">The converter parameter to use.</param>
        /// <param name="culture">The culture to use in the converter.</param>
        /// <returns>ConverBack is not possible, hence returns "null"</returns>
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return (double)value;
        }
    }
    
    public class SpeedToMilesConverter : IValueConverter
    {
        private double miles = 123456;
        private static double oldValue=0;
        private static double newValue;

        /// <summary>
        /// Converts Radius into Diameter
        /// </summary>
        /// <param name="value">Value to be converted</param>
        /// <param name="targetType">The type of the binding target property.</param>
        /// <param name="parameter">The converter parameter to use.</param>
        /// <param name="culture">The culture to use in the converter.</param>
        /// <returns>Converted value</returns>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            int pointer = (int)Math.Floor((double)value);
            newValue = pointer;
            if (oldValue != newValue)
            {
                if (pointer <= 25)
                {
                    if (pointer % 9 == 0)
                        miles += 1;
                }
                else if (pointer <= 50)
                {
                    if (pointer % 8 == 0)
                        miles += 1;
                }
                else if (pointer <= 75)
                {
                    if (pointer % 7 == 0)
                        miles += 1;
                }
                else if (pointer <= 100)
                {
                    if (pointer % 6 == 0)
                        miles += 1;
                }
                else if (pointer <= 125)
                {
                    if (pointer % 5 == 0)
                        miles += 1;
                }
                else if (pointer <= 140)
                {
                    if (pointer % 4 == 0)
                        miles += 1;
                }
                else
                {
                    if (pointer % 10 == 0)
                        miles += 1;
                }
            }
            oldValue = newValue;
            return miles;
        }

        /// <summary>
        /// Empty converter.
        /// </summary>
        /// <param name="value">The value that is produced by the binding target.</param>
        /// <param name="targetType">The type to convert to.</param>
        /// <param name="parameter">The converter parameter to use.</param>
        /// <param name="culture">The culture to use in the converter.</param>
        /// <returns>ConverBack is not possible, hence returns "null"</returns>
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return (double)value;
        }
    }
    
}
