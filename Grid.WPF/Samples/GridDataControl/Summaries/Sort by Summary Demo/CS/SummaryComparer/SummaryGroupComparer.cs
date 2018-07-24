using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Syncfusion.Windows.Data;

namespace SortbySummaryDemo
{
    public class SummaryGroupComparer : IComparer<Group>, ISortDirection
    {
        private string _PropertyName;
        /// <summary>
        /// Gets or sets the name of the property.
        /// </summary>
        /// <value>The name of the property.</value>
        public string PropertyName
        {
            get { return _PropertyName; }
            set { _PropertyName = value; }
        }

        #region IComparer<Group> Members

        /// <summary>
        /// Compares two objects and returns a value indicating whether one is less than, equal to, or greater than the other.
        /// </summary>
        /// <param name="x">The first object to compare.</param>
        /// <param name="y">The second object to compare.</param>
        /// <returns>
        /// Value
        /// Condition
        /// Less than zero
        /// <paramref name="x"/> is less than <paramref name="y"/>.
        /// Zero
        /// <paramref name="x"/> equals <paramref name="y"/>.
        /// Greater than zero
        /// <paramref name="x"/> is greater than <paramref name="y"/>.
        /// </returns>
        public int Compare(Group x, Group y)
        {
            var xsummaryValue = x.GetSummaryValue(PropertyName);
            var ysummaryValue = y.GetSummaryValue(PropertyName);
            int cmp = 0;
            bool xIsNull = (x == null) || (x != null && xsummaryValue is DBNull);
            bool yIsNull = (y == null) || (y != null && ysummaryValue is DBNull);

            if (!xIsNull && !yIsNull)
            {
                xIsNull = (xsummaryValue == null);
                yIsNull = (ysummaryValue == null);
            }

            if (yIsNull && xIsNull)
            {
                cmp = 0;
            }
            else if (xIsNull)
            {
                cmp = -1;
            }
            else if (yIsNull)
            {
                cmp = 1;
            }
            else
            {
                if (xsummaryValue != string.Empty && ysummaryValue != string.Empty)
                {
                    double xsumvalue;
                    double.TryParse(xsummaryValue.Remove(0, 7), out xsumvalue); ;
                    double ysumvalue;
                    double.TryParse(ysummaryValue.Remove(0, 7), out ysumvalue);
                    //cmp = ((IComparable)xsummaryValue).CompareTo(ysummaryValue);
                    cmp = ((IComparable)xsumvalue).CompareTo(ysumvalue);
                }
            }

            if (SortDirection == System.ComponentModel.ListSortDirection.Ascending)
                return cmp;
            else
                return -cmp;
        }
        #endregion

        private System.ComponentModel.ListSortDirection _sortDirection;
        /// <summary>
        /// Gets or sets the sort direction.
        /// </summary>
        /// <value>The sort direction.</value>
        public System.ComponentModel.ListSortDirection SortDirection
        {
            get
            {
                return _sortDirection;
            }
            set
            {
                _sortDirection = value;
            }
        }
    }
}
