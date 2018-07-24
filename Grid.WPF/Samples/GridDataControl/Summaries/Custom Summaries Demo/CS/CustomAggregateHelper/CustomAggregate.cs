using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Syncfusion.Windows.Data;
using CustomSummariesDemo;

namespace CustomSummariesDemo
{
    class CustomAggregate : ISummaryAggregate
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CustomAggregate"/> class.
        /// </summary>
        public CustomAggregate()
        {
        }

        /// <summary>
        /// Gets or sets the STD dev.
        /// </summary>
        /// <value>The STD dev.</value>
        public double StdDev
        {
            get;
            set;
        }

        #region ISummaryAggregate Members

        /// <summary>
        /// Calculates the aggregate func.
        /// </summary>
        /// <returns></returns>
        public Action<System.Collections.IEnumerable, string, System.ComponentModel.PropertyDescriptor> CalculateAggregateFunc()
        {
            return (items, property, pd) =>
            {
                // type cast to the underlying source, so we get to call the LINQ method directly
                var enumerableItems = items as IEnumerable<Quotes>;
                if (pd.Name == "StdDev")
                {
                    this.StdDev = enumerableItems.StdDev<Quotes>(q => q.Change);
                }
            };
        }

        #endregion
    }

    public static class LinqExtensions
    {
        /// <summary>
        /// STDs the dev.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="values">The values.</param>
        /// <param name="selector">The selector.</param>
        /// <returns></returns>
        public static double StdDev<T>(this IEnumerable<T> values, Func<T, double?> selector)
        {
            double ret = 0;
            var count = values.Count();
            if (count > 0)
            {
                //Compute the Average
                double? avg = values.Average(selector);

                //Perform the Sum of (value-avg)^2
                double sum = values.Select(selector).Sum(d =>
                {
                    if (d.HasValue)
                    {
                        return Math.Pow(d.Value - avg.Value, 2);
                    }
                    return 0.0;
                });

                //Put it all together
                ret = Math.Sqrt((sum) / (count - 1));
            }
            return ret;
        }
    }
}
