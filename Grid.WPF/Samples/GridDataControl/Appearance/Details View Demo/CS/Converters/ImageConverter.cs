using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Data;
using DetailsViewDemo.DataModel;

namespace DetailsViewDemo
{
    public class ImageConverter : IValueConverter
    {
        Dictionary<int, string> Images = new Dictionary<int, string>();

        /// <summary>
        /// Initializes a new instance of the <see cref="ImageConverter"/> class.
        /// </summary>
        public ImageConverter()
        {
            Images.Add(1, @"..\..\Images\Beverages.jpg");
            Images.Add(2, @"..\..\Images\Condiments.jpg");
            Images.Add(3, @"..\..\Images\Confections.jpg");
            Images.Add(4, @"..\..\Images\DairyProducts.jpg");
            Images.Add(5, @"..\..\Images\Grains.jpg");
            Images.Add(6, @"..\..\Images\PreparedMeats.jpg");
            Images.Add(7, @"..\..\Images\Produce.jpg");
            Images.Add(8, @"..\..\Images\SeaFood.jpg");
        }


        #region IValueConverter Members

        /// <summary>
        /// Converts a value.
        /// </summary>
        /// <param name="value">The value produced by the binding source.</param>
        /// <param name="targetType">The type of the binding target property.</param>
        /// <param name="parameter">The converter parameter to use.</param>
        /// <param name="culture">The culture to use in the converter.</param>
        /// <returns>
        /// A converted value. If the method returns null, the valid null value is used.
        /// </returns>
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value != null)
            {
                return this.Images[(value as Categories).CategoryID];
            }
            return value;
        }

        /// <summary>
        /// Converts a value.
        /// </summary>
        /// <param name="value">The value that is produced by the binding target.</param>
        /// <param name="targetType">The type to convert to.</param>
        /// <param name="parameter">The converter parameter to use.</param>
        /// <param name="culture">The culture to use in the converter.</param>
        /// <returns>
        /// A converted value. If the method returns null, the valid null value is used.
        /// </returns>
        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
