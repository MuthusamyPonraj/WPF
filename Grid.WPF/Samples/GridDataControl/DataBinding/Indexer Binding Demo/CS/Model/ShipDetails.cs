using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IndexerBindingDemo
{
    public class ShipDetail : List<PropertyInfo>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ShipDetail"/> class.
        /// </summary>
        public ShipDetail()
        {
            this.Capacity = 4;

            this.Add(new PropertyInfo { Key = "ShipCountry", Value = "" });
            this.Add(new PropertyInfo { Key = "ShipCity", Value = "" });
            this.Add(new PropertyInfo { Key = "ShipCode", Value = "" });
            this.Add(new PropertyInfo { Key = "ShipVia", Value = "" });
        }

        /// <summary>
        /// Gets or sets the <see cref="IndexerBindingDemo.Model.Property"/> with the specified key.
        /// </summary>
        /// <value></value>
        public PropertyInfo this[string Key]
        {
            get
            {
                var s = this.Where(o => o.Key == Key).Single();
                return (s as PropertyInfo);
            }
            set
            {
                var s = this.Where(o => o.Key == Key).Single();
                s = value;
            }
        }
    }
}
