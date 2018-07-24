using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Syncfusion.Windows.Data;
using System.ComponentModel;

namespace CustomSortingDemo
{
    public class CustomerInfo : IComparer<Object>, ISortDirection
    {
        /// <summary>
        /// Compares the specified x.
        /// </summary>
        /// <param name="x">The x.</param>
        /// <param name="y">The y.</param>
        /// <returns></returns>
        public int Compare(object x, object y)
        {
            int namX;
            int namY;
            if (x.GetType() == typeof(Customers))
            {
                namX = ((Customers)x).CompanyName.Length;
                namY = ((Customers)y).CompanyName.Length;
            }
            else if (x.GetType() == typeof(Group))
            {
                namX = ((Group)x).Key.ToString().Length;
                namY = ((Group)y).Key.ToString().Length;
            }
            else
            {
                namX = x.ToString().Length;
                namY = y.ToString().Length;
            }

            if (namX.CompareTo(namY) > 0)
                return SortDirection == ListSortDirection.Ascending ? 1 : -1;
            else if (namX.CompareTo(namY) == -1)
                return SortDirection == ListSortDirection.Ascending ? -1 : 1;
            else
                return 0;
        }

        private ListSortDirection _SortDirection;

        /// <summary>
        /// Gets or sets the sort direction.
        /// </summary>
        /// <value>The sort direction.</value>
        public ListSortDirection SortDirection
        {
            get
            {
                return _SortDirection;
            }
            set
            {
                _SortDirection = value;
            }
        }
    }
}
